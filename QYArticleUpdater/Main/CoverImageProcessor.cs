using OpenCvSharp;
using OpenCvSharp.Extensions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
//using static OpenCvSharp.CvHaarFeature;

namespace QYArticleUpdater
{
	public class CoverImageProcessor
	{
		// 裁剪配置参数
		public class CropConfig
		{
			public int TargetWidth { get; set; } = 1000;
			public int TargetHeight { get; set; } = 600;
			public bool ProtectTextAreas { get; set; } = true;
			public bool UseObjectDetection { get; set; } = false;
			public double SaliencyThreshold { get; set; } = 0.2;
			public bool UseEdgeDetection { get; set; } = true; // 新增选项
		}

		/// <summary>
		/// 智能裁剪主方法
		/// </summary>
		/// <param name="inputImage">输入图像</param>
		/// <param name="config">裁剪配置</param>
		/// <returns>裁剪后的Bitmap图像</returns>
		public Bitmap SmartCrop(Bitmap inputImage, CropConfig config = null)
		{
			config ??= new CropConfig();

			using var src = OpenCvSharp.Extensions.BitmapConverter.ToMat(inputImage);
			var (cropPoint, cropSize) = CalculateCropArea(src, config);

			using var cropped = new Mat(src, new Rect(cropPoint, cropSize));
			return OpenCvSharp.Extensions.BitmapConverter.ToBitmap(cropped);
		}

		/// <summary>
		/// 智能裁剪并保存到文件
		/// </summary>
		/// <param name="inputPath">输入文件路径</param>
		/// <param name="outputPath">输出文件路径</param>
		/// <param name="config">裁剪配置</param>
		public void SmartCropAndSave(string inputPath, string outputPath, CropConfig config = null)
		{
			using var src = Cv2.ImRead(inputPath, ImreadModes.Color);
			if (src.Empty()) throw new FileNotFoundException("Input image not found");

			config ??= new CropConfig();
			var (cropPoint, cropSize) = CalculateCropArea(src, config);

			using var cropped = new Mat(src, new Rect(cropPoint, cropSize));
			Cv2.ImWrite(outputPath, cropped);
		}

		private (OpenCvSharp.Point, OpenCvSharp.Size) CalculateCropArea(Mat src, CropConfig config)
		{
			// 1. 预处理：缩放图像
			using var processed = PreprocessImage(src, config);

			// 2. 计算显著性区域
			var saliencyCenter = GetSaliencyCenter(processed, config);

			// 3. 检测并保护文本区域
			Rect? protectedArea = null;
			if (config.ProtectTextAreas)
			{
				protectedArea = DetectTextAreas(processed);
			}

			// 4. 计算最终裁剪区域
			return CalculateFinalCropRegion(
				src.Size(),
				processed.Size(),
				saliencyCenter,
				protectedArea,
				new OpenCvSharp.Size(config.TargetWidth, config.TargetHeight)
			);
		}

		private Mat PreprocessImage(Mat src, CropConfig config)
		{
			// 计算缩放比例（保持长宽比）
			double scale = Math.Max(
				config.TargetWidth * 1.5 / src.Width,
				config.TargetHeight * 1.5 / src.Height
			);

			if (scale < 1.0)
			{
				using var resized = new Mat();
				Cv2.Resize(src, resized,
					new OpenCvSharp.Size((int)(src.Width * scale), (int)(src.Height * scale)));
				return resized.Clone();
			}
			return src.Clone();
		}

		private OpenCvSharp.Point? GetSaliencyCenter(Mat image, CropConfig config)
		{
			// 方法1：使用边缘检测替代显著性检测
			if (config.UseEdgeDetection)
			{
				return GetEdgeBasedCenter(image);
			}

			// 方法2：使用颜色对比度（备用方案）
			return GetColorContrastCenter(image, config.SaliencyThreshold);
		}

		// 基于边缘检测的中心点计算方法
		private OpenCvSharp.Point? GetEdgeBasedCenter(Mat image)
		{
			using var gray = new Mat();
			Cv2.CvtColor(image, gray, ColorConversionCodes.BGR2GRAY);

			// 边缘检测
			using var edges = new Mat();
			Cv2.Canny(gray, edges, 50, 150);

			// 查找轮廓
			Cv2.FindContours(edges, out var contours, out _,
				RetrievalModes.List, ContourApproximationModes.ApproxSimple);

			if (contours.Length == 0)
				return null;

			// 找到最大轮廓
			var maxContour = contours[0];
			double maxArea = Cv2.ContourArea(maxContour);
			foreach (var contour in contours)
			{
				var area = Cv2.ContourArea(contour);
				if (area > maxArea)
				{
					maxArea = area;
					maxContour = contour;
				}
			}

			// 计算轮廓中心
			var moment = Cv2.Moments(maxContour);
			if (moment.M00 <= 0)
				return null;

			var centerX = (int)(moment.M10 / moment.M00);
			var centerY = (int)(moment.M01 / moment.M00);
			return new OpenCvSharp.Point(centerX, centerY);
		}

		// 基于颜色对比度的中心点计算方法
		private OpenCvSharp.Point? GetColorContrastCenter(Mat image, double threshold)
		{
			using var lab = new Mat();
			Cv2.CvtColor(image, lab, ColorConversionCodes.BGR2Lab);

			// 分离通道
			var channels = Cv2.Split(lab);
			using var lightness = channels[0];

			// 计算对比度图
			using var contrast = new Mat();
			Cv2.Laplacian(lightness, contrast, MatType.CV_32F);
			Cv2.ConvertScaleAbs(contrast, contrast);

			// 二值化
			using var binary = new Mat();
			Cv2.Threshold(contrast, binary, threshold * 255, 255, ThresholdTypes.Binary);

			// 查找轮廓
			Cv2.FindContours(binary, out var contours, out _,
				RetrievalModes.List, ContourApproximationModes.ApproxSimple);

			if (contours.Length == 0)
				return null;

			// 找到最大轮廓
			var maxContour = contours[0];
			double maxArea = Cv2.ContourArea(maxContour);
			foreach (var contour in contours)
			{
				var area = Cv2.ContourArea(contour);
				if (area > maxArea)
				{
					maxArea = area;
					maxContour = contour;
				}
			}

			// 计算轮廓中心
			var moment = Cv2.Moments(maxContour);
			if (moment.M00 <= 0)
				return null;

			var centerX = (int)(moment.M10 / moment.M00);
			var centerY = (int)(moment.M01 / moment.M00);
			return new OpenCvSharp.Point(centerX, centerY);
		}

		private Rect? DetectTextAreas(Mat image)
		{
			// 使用MSER算法检测文本区域
			using var gray = new Mat();
			Cv2.CvtColor(image, gray, ColorConversionCodes.BGR2GRAY);

			var mser = MSER.Create(
				delta: 5,
				minArea: 60,
				maxArea: 14400,
				maxVariation: 0.25,
				minDiversity: 0.2);

			OpenCvSharp.Point[][] regions;
			Rect[] bboxes;
			mser.DetectRegions(gray, out regions, out bboxes);

			if (bboxes.Length == 0)
				return null;

			// 合并所有文本区域
			Rect combinedRect = bboxes[0];
			foreach (var rect in bboxes)
			{
				combinedRect = UnionRects(combinedRect, rect);
			}
			return combinedRect;
		}

		// 自定义矩形合并方法
		private Rect UnionRects(Rect a, Rect b)
		{
			int x = Math.Min(a.X, b.X);
			int y = Math.Min(a.Y, b.Y);
			int right = Math.Max(a.X + a.Width, b.X + b.Width);
			int bottom = Math.Max(a.Y + a.Height, b.Y + b.Height);
			return new Rect(x, y, right - x, bottom - y);
		}

		private (OpenCvSharp.Point, OpenCvSharp.Size) CalculateFinalCropRegion(
			OpenCvSharp.Size originalSize,
			OpenCvSharp.Size processedSize,
			OpenCvSharp.Point? saliencyCenter,
			OpenCvSharp.Rect? protectedArea,
			OpenCvSharp.Size targetSize)
		{
			// 计算缩放比例
			double scaleX = (double)originalSize.Width / processedSize.Width;
			double scaleY = (double)originalSize.Height / processedSize.Height;

			// 转换坐标回原始尺寸
			OpenCvSharp.Point centerPoint = saliencyCenter ?? new OpenCvSharp.Point(
				processedSize.Width / 2,
				processedSize.Height / 2
			);

			int originalCenterX = (int)(centerPoint.X * scaleX);
			int originalCenterY = (int)(centerPoint.Y * scaleY);

			// 调整保护区域坐标
			Rect? originalProtectedArea = null;
			if (protectedArea.HasValue)
			{
				var p = protectedArea.Value;
				originalProtectedArea = new Rect(
					(int)(p.X * scaleX),
					(int)(p.Y * scaleY),
					(int)(p.Width * scaleX),
					(int)(p.Height * scaleY)
				);
			}

			// 计算裁剪起点
			int startX = CalculateCropStart(
				originalCenterX,
				originalSize.Width,
				targetSize.Width,
				originalProtectedArea?.X,
				originalProtectedArea?.X + originalProtectedArea?.Width ?? null
			);

			int startY = CalculateCropStart(
				originalCenterY,
				originalSize.Height,
				targetSize.Height,
				originalProtectedArea?.Y,
				originalProtectedArea?.Y + originalProtectedArea?.Height ?? null
			);

			// 确保不超出边界
			startX = Math.Max(0, Math.Min(startX, originalSize.Width - targetSize.Width));
			startY = Math.Max(0, Math.Min(startY, originalSize.Height - targetSize.Height));

			return (new OpenCvSharp.Point(startX, startY), targetSize);
		}

		private int CalculateCropStart(
			int center,
			int fullSize,
			int targetSize,
			int? protectedStart,
			int? protectedEnd)
		{
			// 默认以中心点裁剪
			int start = center - targetSize / 2;

			// 调整以保护关键区域
			if (protectedStart.HasValue && protectedEnd.HasValue)
			{
				int protectedCenter = (protectedStart.Value + protectedEnd.Value) / 2;
				int protectedSize = protectedEnd.Value - protectedStart.Value;

				// 如果保护区域大于裁剪尺寸，优先保护区域中心
				if (protectedSize > targetSize)
				{
					start = protectedCenter - targetSize / 2;
				}
				// 否则确保保护区域在裁剪区域内
				else
				{
					if (protectedStart.Value < start)
						start = protectedStart.Value;
					else if (protectedEnd.Value > start + targetSize)
						start = protectedEnd.Value - targetSize;
				}
			}

			// 边界检查
			if (start < 0) return 0;
			if (start + targetSize > fullSize) return fullSize - targetSize;
			return start;
		}
	}
}