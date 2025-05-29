using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace QieYouArticleUpdater.Main
{
	internal class ImageSharpener
	{
		public static Bitmap Sharpen(Bitmap image, float factor)
		{
			// 定义一个锐化卷积矩阵
			/*float[][] sharpenMatrix = new float[][]
			{
			new float[] { 0, -1, 0 },
			new float[] { -1, factor + 4, -1 },
			new float[] { 0, -1, 0 }
			};*/
			float[,] SharpenMatrix = {
	{ -0.1f, -0.2f, -0.1f },
	{ -0.2f,  1.8f, -0.2f },
	{ -0.1f, -0.2f, -0.1f }

};
			return ConvolutionFilter(image, SharpenMatrix, 1, 0);
		}

		private static Bitmap ConvolutionFilter(Bitmap sourceImage,
			float[,] filterMatrix,
			float factor,
			int bias)
		{
			BitmapData srcData = sourceImage.LockBits(new Rectangle(0, 0, sourceImage.Width, sourceImage.Height),
													   ImageLockMode.ReadOnly,
													   PixelFormat.Format24bppRgb);

			byte[] pixelBuffer = new byte[srcData.Stride * sourceImage.Height];
			byte[] resultBuffer = new byte[srcData.Stride * sourceImage.Height];

			Marshal.Copy(srcData.Scan0, pixelBuffer, 0, pixelBuffer.Length);
			sourceImage.UnlockBits(srcData);

			int filterWidth = filterMatrix.GetLength(0);
			int filterHeight = filterMatrix.GetLength(1);
			int filterOffset = (filterWidth - 1) / 2;
			int calcOffset = 0;

			for (int offsetY = filterOffset; offsetY < sourceImage.Height - filterOffset; offsetY++)
			{
				for (int offsetX = filterOffset; offsetX < sourceImage.Width - filterOffset; offsetX++)
				{
					int blue = 0;
					int green = 0;
					int red = 0;

					for (int filterY = -filterOffset; filterY <= filterOffset; filterY++)
					{
						for (int filterX = -filterOffset; filterX <= filterOffset; filterX++)
						{
							calcOffset = ((offsetY + filterY) * srcData.Stride) + (offsetX + filterX) * 3;

							blue += pixelBuffer[calcOffset] * (int)filterMatrix[filterY + filterOffset, filterX + filterOffset];
							green += pixelBuffer[calcOffset + 1] * (int)filterMatrix[filterY + filterOffset, filterX + filterOffset];
							red += pixelBuffer[calcOffset + 2] * (int)filterMatrix[filterY + filterOffset, filterX + filterOffset];
						}
					}

					calcOffset = offsetY * srcData.Stride + offsetX * 3;

					blue = Math.Max(Math.Min((int)(factor * blue + bias), 255), 0);
					green = Math.Max(Math.Min((int)(factor * green + bias), 255), 0);
					red = Math.Max(Math.Min((int)(factor * red + bias), 255), 0);

					resultBuffer[calcOffset] = (byte)(blue);
					resultBuffer[calcOffset + 1] = (byte)(green);
					resultBuffer[calcOffset + 2] = (byte)(red);
				}
			}

			Bitmap resultImage = new Bitmap(sourceImage.Width, sourceImage.Height);
			BitmapData resultData = resultImage.LockBits(new Rectangle(0, 0, resultImage.Width, resultImage.Height),
														 ImageLockMode.WriteOnly,
														 PixelFormat.Format24bppRgb);

			Marshal.Copy(resultBuffer, 0, resultData.Scan0, resultBuffer.Length);
			resultImage.UnlockBits(resultData);

			return resultImage;
		}
	}
}
