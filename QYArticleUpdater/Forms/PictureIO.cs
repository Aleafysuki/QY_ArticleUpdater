using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Net;
using System.Security.Policy;
using System.Text.RegularExpressions;
using System.Collections.Specialized;
using QYArticleUpdater.Main;
using System.IO;

namespace QYArticleUpdater
{
	public partial class PictureIO : Form
	{
		Image img;
		string[] files;
		public PictureIO()
		{
			InitializeComponent();
			PictureInput.AllowDrop = true;
			// 注册DragEnter事件
			PictureInput.DragEnter += new DragEventHandler(PictureInput_DragEnter);

			// 注册DragDrop事件
			PictureInput.DragDrop += new DragEventHandler(PictureInput_DragDrop);
			if (File.Exists("C:\\settings.txt") || File.Exists("settings.txt"))
			{
				files = (File.Exists("C:\\settings.txt") ? File.ReadAllLines("C:\\settings.txt") : File.ReadAllLines("settings.txt"));
				foreach (string file in files)
				{
					if (file.StartsWith("OutputPath1="))
					{ OutputPath.Text = file.Split('=')[1]; }
					else if (file.StartsWith("OutputPath2="))
					{ //outputpath2.Text = file.Split('=')[1]; }
						if (file.StartsWith("resolution1="))
						{
							resolutionX.Text = file.Split('=')[1].Split(',')[0];
							resolutionY.Text = file.Split('=')[1].Split(',')[1];
						}
						if (file.StartsWith("resolution2="))
						{
							//resolutionX2.Text = file.Split('=')[1].Split(',')[0];
							//resolutionY2.Text = file.Split('=')[1].Split(',')[1];
						}
					}
				}
				groupBox3.Enabled = false;
				QualitySelector.SelectedIndex = 0;
			}
		}
		/// <summary>
		/// 将图片按比例缩放到合适的尺寸并输出
		/// </summary>
		/// <param name="img">需要处理的图片</param>
		/// <param name="resolution">所需的分辨率，resolution[0]为横向分辨率，resolution[1]为纵向分辨率</param>
		/// <returns>调整后的图片</returns>
		public static Image AdjustToSelectedResolution(Image img, int[] resolution)
		{
			if (img == null)
			{
				throw new ArgumentNullException(nameof(img), "图片引用错误");
			}

			if (resolution == null || resolution.Length < 2)
			{
				throw new ArgumentException("分辨率必须只包含两个参数且必须为整数，resolution[0]为横向分辨率，resolution[1]为纵向分辨率", nameof(resolution));
			}

			int maxWidth = resolution[0];
			int maxHeight = resolution[1];

			// 计算原始图片的宽高比
			float aspectRatio = (float)img.Width / img.Height;
			float targetAspectRatio = (float)maxWidth / maxHeight;

			// 创建一个新的Bitmap对象来保存调整后的图片
			Bitmap resizedImage = new Bitmap(maxWidth, maxHeight);

			using (Graphics graphics = Graphics.FromImage(resizedImage))
			{
				graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
				graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
				graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
				graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;

				if (aspectRatio >= targetAspectRatio)
				{
					// 如果图像更“宽”，则按高度缩放
					int newHeight = maxHeight;
					int newWidth = (int)(newHeight * aspectRatio);
					Rectangle sourceRect = new Rectangle(0, 0, img.Width, img.Height);
					Rectangle destRect = new Rectangle(-(newWidth - maxWidth) / 2, 0, newWidth, newHeight);
					graphics.DrawImage(img, destRect, sourceRect, GraphicsUnit.Pixel);
				}
				else
				{
					// 如果图像更“高”或正好，则按宽度缩放
					int newWidth = maxWidth;
					int newHeight = (int)(newWidth / aspectRatio);
					Rectangle sourceRect = new Rectangle(0, 0, img.Width, img.Height);
					Rectangle destRect = new Rectangle(0, -(newHeight - maxHeight) / 2, newWidth, newHeight);
					graphics.DrawImage(img, destRect, sourceRect, GraphicsUnit.Pixel);
				}

				// 裁剪到目标尺寸
				Rectangle cropRect = new Rectangle(0, 0, maxWidth, maxHeight);
				Bitmap finalImage = resizedImage.Clone(cropRect, resizedImage.PixelFormat);
				return finalImage;
			}
		}
		#region pictures
		private void PictureInput_DragDrop(object sender, DragEventArgs e)
		{
			string[] files;
			try
			{
				files = (string[])e.Data.GetData(DataFormats.FileDrop);
				foreach (var file in files)
				{
					if (file.EndsWith(".jpg") || file.EndsWith(".jpeg") || file.EndsWith(".png") || file.EndsWith(".bmp") || file.EndsWith(".webp"))
					{
						// 将PictureBox的图像设置为拖放的图像
						this.PictureInput.Image = Image.FromFile(file);
						break; // 只处理第一个图像文件
					}
				}
			}
			catch (Exception)
			{

				string imageData = e.Data.GetData(DataFormats.Text).ToString();
				PictureInput.Image = LoadImageFromUrl(imageData);
			}
			img = PictureInput.Image;
			PictureInput.Size = img.Size;
		}

		private void PictureInput_DragEnter(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
			{
				// 检查拖放的内容是否包含文件
				string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

				// 检查是否为图像文件
				foreach (var file in files)
				{
					if (file.EndsWith(".jpg") || file.EndsWith(".jpeg") || file.EndsWith(".png") || file.EndsWith(".bmp") || file.EndsWith(".webp"))
					{
						e.Effect = DragDropEffects.Copy; // 允许复制
						return;
					}
				}
			}
			PictureInput_BackgroundImageChanged();
			e.Effect = DragDropEffects.None; // 不允许任何合法
			if (e.Data.GetDataPresent(DataFormats.Text))
			{
				e.Effect = DragDropEffects.All;
			}
		}
		private Image LoadImageFromUrl(string url)
		{
			using (WebClient wc = new WebClient())
			{
				byte[] imageBytes = wc.DownloadData(url);
				MemoryStream ms = new MemoryStream(imageBytes);
				PictureInput_BackgroundImageChanged();
				return Image.FromStream(ms);
			}

		}

		private void Generator_Click(object sender, EventArgs e)
		{
			// 确保有图像要处理
			if (PictureInput.Image == null) return;

			// 设置编码器参数以指定JPEG质量
			ImageCodecInfo jpgEncoder = GetEncoder(ImageFormat.Jpeg);
			EncoderParameters encoderParams = new EncoderParameters(1);

			int quality = Convert.ToInt32(QualitySelector.SelectedItem.ToString().TrimEnd('%'));
			encoderParams.Param[0] = new EncoderParameter(Encoder.Quality, quality);
			// 创建一个新的Bitmap对象用于保存调整大小和格式的图像
			Bitmap bitmap = new Bitmap(PictureInput.Image);
			// 创建内存流
			using (MemoryStream ms = new MemoryStream())
			{
				// 将bitmap保存为JPEG格式到内存流中，同时应用JPEG压缩参数
				bitmap.Save(ms, jpgEncoder, encoderParams);

				// 从内存流创建新的Image对象
				Image img = Image.FromStream(ms);
				img = ResizeImage(img, new Size(Convert.ToInt32(resolutionX.Text), Convert.ToInt32(resolutionY.Text)));

				//img = ResizeImage(img, new Size(Convert.ToInt32(resolutionX.Text), Convert.ToInt32(resolutionY.Text)));
				img.Save(OutputPath.Text + "\\" + Suffix1.Text + "-" + DateTime.Now.ToString("MM-dd-hh-mm-ss") + ".jpg", ImageFormat.Jpeg);

				// 释放资源
				img.Dispose();
			}

			// 释放bitmap资源
			bitmap.Dispose();
			//if(!int.TryParse(resolutionY.Text,))resolutionY.Text = "1920";

			//Clipboard.SetImage(img);
		}
		private ImageCodecInfo GetEncoder(ImageFormat format)
		{
			ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();
			foreach (ImageCodecInfo codec in codecs)
			{
				if (codec.FormatID == format.Guid)
				{
					return codec;
				}
			}
			return null;
		}
		private void CopyGenerator_Click(object sender, EventArgs e)
		{
			// 确保有图像要处理
			if (PictureInput.Image == null) return;

			// 设置编码器参数以指定JPEG质量
			ImageCodecInfo jpgEncoder = GetEncoder(ImageFormat.Jpeg);
			EncoderParameters encoderParams = new EncoderParameters(1);

			int quality = Convert.ToInt32(QualitySelector.SelectedItem.ToString().TrimEnd('%'));
			encoderParams.Param[0] = new EncoderParameter(Encoder.Quality, quality);
			// 创建一个新的Bitmap对象用于保存调整大小和格式的图像
			Bitmap bitmap = new Bitmap(PictureInput.Image);
			// 创建内存流
			using (MemoryStream ms = new MemoryStream())
			{
				// 将bitmap保存为JPEG格式到内存流中，同时应用JPEG压缩参数
				bitmap.Save(ms, jpgEncoder, encoderParams);

				// 从内存流创建新的Image对象
				Image img = Image.FromStream(ms);
				img = ResizeImage(img, new Size(Convert.ToInt32(resolutionX.Text), Convert.ToInt32(resolutionY.Text)));
				img.Save(OutputPath.Text + "\\" + Suffix1.Text + ".jpg", ImageFormat.Jpeg);
				//img = Image.FromFile($"{OutputPath.Text}\\{Suffix1.Text}.jpg");

				// 创建文件路径集合
				StringCollection filePaths = new StringCollection();
				string tempFilePath = OutputPath.Text + "\\" + Suffix1.Text + ".jpg";
				filePaths.Add(tempFilePath);

				// 将文件路径复制到剪贴板
				Clipboard.SetFileDropList(filePaths);
				// 将图像复制到剪贴板
				//Clipboard.SetImage(img);

				// 释放资源
				img.Dispose();
			}

			// 释放bitmap资源
			bitmap.Dispose();

			//Clipboard.SetImage(img);
		}

		public Image ResizeImage(Image imgToResize, Size size)
		{
			var ratioX = (double)size.Width / imgToResize.Width;
			var ratioY = (double)size.Height / imgToResize.Height;
			var ratio = Math.Min(ratioX, ratioY);

			var newWidth = (int)(imgToResize.Width * ratio);
			var newHeight = (int)(imgToResize.Height * ratio);

			var newImage = new Bitmap(newWidth, newHeight);
			using (var gr = Graphics.FromImage(newImage))
			{
				gr.CompositingMode = CompositingMode.SourceCopy;
				gr.CompositingQuality = CompositingQuality.HighQuality;
				gr.InterpolationMode = InterpolationMode.HighQualityBicubic;
				gr.SmoothingMode = SmoothingMode.HighQuality;
				gr.PixelOffsetMode = PixelOffsetMode.HighQuality;

				using (var wrapMode = new ImageAttributes())
				{
					wrapMode.SetWrapMode(WrapMode.TileFlipXY);
					gr.DrawImage(imgToResize, new Rectangle(0, 0, newWidth, newHeight),
								 0, 0, imgToResize.Width, imgToResize.Height, GraphicsUnit.Pixel, wrapMode);
				}
			}

			return newImage;
		}
		Point clickPoint = new Point(0, 0);
		private bool mouseloc = false;
		private void PictureInput_MouseClick(object sender, MouseEventArgs e)
		{
			if (e.Button != MouseButtons.None) mouseloc = true;
			else return;
			if (PictureInput.Image != null)
			{
				// 获取PictureBox的大小
				Size picBoxSize = PictureInput.Size;

				// 获取PictureBox中图像的实际大小
				Size imgSize = PictureInput.Image.Size;

				// 计算图像的缩放比例
				double scaleWidth = (double)picBoxSize.Width / imgSize.Width;
				double scaleHeight = (double)picBoxSize.Height / imgSize.Height;

				// 根据PictureBox的SizeMode确定使用哪个缩放比例
				double scale = Math.Max(scaleWidth, scaleHeight);
				if (PictureInput.SizeMode == PictureBoxSizeMode.AutoSize || PictureInput.SizeMode == PictureBoxSizeMode.Normal)
				{
					scale = 1.0; // 如果图片没有被缩放，则缩放比例为1
				}

				// 获取鼠标位置相对于PictureBox的坐标
				clickPoint = new Point(e.X, e.Y);
				// 考虑到PictureBox可能的滚动偏移
				Point scrollOffset = PictureInput.Parent is Panel panel ? new Point(panel.AutoScrollPosition.X, panel.AutoScrollPosition.Y) : Point.Empty;

				// 转换坐标到原图中的坐标
				Point originalPoint = new Point((int)((clickPoint.X - scrollOffset.X) / scale), (int)((clickPoint.Y - scrollOffset.Y) / scale));

				groupBox3.Enabled = true;
				if (originalPoint.X < 0) originalPoint.X = 0;
				if (originalPoint.Y < 0) originalPoint.Y = 0;
				if (originalPoint.X > picBoxSize.Width) originalPoint.X = picBoxSize.Width;
				if (originalPoint.Y > picBoxSize.Height) originalPoint.Y = picBoxSize.Height;
				ClickedPoint.Text = $"已选择坐标: {originalPoint.X}, {originalPoint.Y}";
			}
		}
		private Bitmap CropImage(Image source, Rectangle rect)
		{
			try
			{
				Bitmap cropped = new Bitmap(rect.Width, rect.Height);
				using (Graphics g = Graphics.FromImage(cropped))
				{
					g.DrawImage(source, new Rectangle(0, 0, cropped.Width, cropped.Height), rect, GraphicsUnit.Pixel);
				}
				return cropped;
			}
			catch (Exception) { }
			return new Bitmap(source.Width, source.Height);
		}

		private void Cropper_Click(object sender, EventArgs e)
		{
			Image originalImage = PictureInput.Image;

			// 分割点
			int splitX = clickPoint.X;
			int splitY = clickPoint.Y;
			if (splitX < 0) splitX = 0;
			if (splitY < 0) splitY = 0;
			if (splitX > originalImage.Width) splitX = originalImage.Width;
			if (splitY > originalImage.Height) splitY = originalImage.Height;
			// 分割图像
			Bitmap topLeft = CropImage(originalImage, new Rectangle(0, 0, splitX, splitY));
			Bitmap topRight = CropImage(originalImage, new Rectangle(splitX, 0, originalImage.Width - splitX, splitY));
			Bitmap bottomLeft = CropImage(originalImage, new Rectangle(0, splitY, splitX, originalImage.Height - splitY));
			Bitmap bottomRight = CropImage(originalImage, new Rectangle(splitX, splitY, originalImage.Width - splitX, originalImage.Height - splitY));

			Bitmap Top = CropImage(originalImage, new Rectangle(0, 0, originalImage.Width, splitY));
			Bitmap Bottom = CropImage(originalImage, new Rectangle(0, splitY, originalImage.Width, originalImage.Height - splitY));
			Bitmap Left = CropImage(originalImage, new Rectangle(0, 0, splitX, originalImage.Height));
			Bitmap Right = CropImage(originalImage, new Rectangle(splitX, 0, originalImage.Width - splitX, originalImage.Height));

			if (sender.ToString().Contains("左上"))
			{
				PictureInput.Image = topLeft;
			}
			else if (sender.ToString().Contains("左下"))
			{
				PictureInput.Image = bottomLeft;
			}
			else if (sender.ToString().Contains("右上"))
			{
				PictureInput.Image = topRight;
			}
			else if (sender.ToString().Contains("右下"))
			{
				PictureInput.Image = bottomRight;
			}
			else if (sender.ToString().Contains("上"))
			{
				PictureInput.Image = Top;
			}
			else if (sender.ToString().Contains("下"))
			{
				PictureInput.Image = Bottom;
			}
			else if (sender.ToString().Contains("左"))
			{
				PictureInput.Image = Left;
			}
			else if (sender.ToString().Contains("右"))
			{
				PictureInput.Image = Right;
			}
			ClickedPoint.Text = $"已选择坐标: ";
			groupBox3.Enabled = false;
			img = PictureInput.Image;
			PictureInput_BackgroundImageChanged();
		}
		private void PasteImage(object sender, EventArgs e)
		{
			if (Clipboard.ContainsImage())
			{
				PictureInput.Image = Clipboard.GetImage();
				img = PictureInput.Image;
			}
			else if (Clipboard.ContainsText())
			{
				if (Clipboard.GetText().Contains("data:image"))
				{
					TryPasteFromClipboard();
				}
				else if (Clipboard.GetText().Contains("//"))
				{
					LoadImageFromUrl(Clipboard.GetText().Split('?')[0].Split('@')[0]);
				}
			}
			PictureInput_BackgroundImageChanged();
		}
		private void TryPasteFromClipboard()
		{
			// 尝试以文本格式获取剪贴板内容
			var clipboardText = Clipboard.GetText();
			if (!string.IsNullOrEmpty(clipboardText) && clipboardText.StartsWith("data:image"))
			{
				try
				{
					// 将数据URI转换为Image对象
					PictureInput.Image = ConvertDataUriToImage(clipboardText);
				}
				catch (Exception ex)
				{
					MessageBox.Show("无法从数据URI创建图片: " + ex.Message);
				}
			}
		}

		private Image ConvertDataUriToImage(string dataUri)
		{
			// 移除"data:image/png;base64,"前缀
			string base64String = dataUri.Split(',')[1];
			byte[] imageBytes = Convert.FromBase64String(base64String);

			// 使用内存流创建图像
			using (MemoryStream ms = new MemoryStream(imageBytes))
			{
				return Image.FromStream(ms);
			}
		}
		/// <summary>
		/// 粘贴图像
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void PasteImage(object sender, KeyEventArgs e)
		{
			if (e.Control && e.KeyCode == Keys.V)
			{
				if (Clipboard.ContainsImage())
				{
					PictureInput.Image = Clipboard.GetImage();
					img = PictureInput.Image;
				}
			}
		}

		private void WindowTop(object sender, EventArgs e)
		{
			TopMost = 窗口置顶ToolStripMenuItem.Checked;
		}

		private void TransparencySet(object sender, EventArgs e)
		{
			if (sender.ToString() == "0%") Opacity = 1;
			else
			{
				Opacity = 1 - Convert.ToDouble(sender.ToString().Substring(0, 2)) / 100;
			}
		}

		private void PictureBoxReset(object sender, EventArgs e)
		{
			PictureInput.Size = new Size(559, 520);
		}

		private void PictureInput_MouseUp(object sender, MouseEventArgs e)
		{
			mouseloc = false;
		}

		private void PictureInput_BackgroundImageChanged()
		{
			PicFileSize.Text = Convert.ToString(PicLengthCalculate(PictureInput.Image) / 1024) + 'K';
		}
		private long PicLengthCalculate(Image img)
		{
			// 确保有图像要处理
			if (PictureInput.Image == null) return 0;

			// 设置编码器参数以指定JPEG质量
			ImageCodecInfo jpgEncoder = GetEncoder(ImageFormat.Jpeg);
			EncoderParameters encoderParams = new EncoderParameters(1);

			int quality = Convert.ToInt32(Convert.ToString(QualitySelector.SelectedItem).TrimEnd('%'));
			encoderParams.Param[0] = new EncoderParameter(Encoder.Quality, quality);
			img = ResizeImage(img, new Size(Convert.ToInt32(resolutionX.Text), Convert.ToInt32(resolutionY.Text)));
			// 创建一个新的Bitmap对象用于保存调整大小和格式的图像
			Bitmap bitmap = new Bitmap(img);
			// 创建内存流
			MemoryStream ms = new MemoryStream();

			// 将bitmap保存为JPEG格式到内存流中，同时应用JPEG压缩参数
			bitmap.Save(ms, jpgEncoder, encoderParams);
			long len = ms.Length;//获取图片大小


			// 释放资源
			img.Dispose();


			// 释放bitmap资源
			bitmap.Dispose();
			return len;
		}

		private void QualitySelector_SelectedIndexChanged(object sender, EventArgs e)
		{
			PictureInput_BackgroundImageChanged();
		}

		private void ImageSherpen_Click(object sender, EventArgs e)
		{
			if (PictureInput.Image != null)
			{
				// 对PictureBox中的图像进行锐化处理
				Bitmap originalImage = new Bitmap(PictureInput.Image);
				Bitmap sharpenedImage = ImageSharpener.Sharpen(originalImage, 1.5f); // 调整factor值可控制锐化程度

				// 将锐化后的图像显示给用户PictureBox
				PictureInput.Image?.Dispose(); // 释放原始图像资源
				PictureInput.Image = sharpenedImage;
			}
			PictureInput_BackgroundImageChanged();
		}

		private void resolution_TextChanged(object sender, EventArgs e)
		{
			PictureInput_BackgroundImageChanged();
		}
		#endregion
		Image[] MainFormImage;
		public void PicTransmission(Image[] images)
		{
			MainFormImage = images;
		}
		#region iFrames
		/// <summary>
		/// 转换iframe
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void convertIframeButton_Click(object sender, EventArgs e)
		{
			if (inputsharediframebox.Text.StartsWith("<iframe"))//示例代码：<iframe src="//player.bilibili.com/player.html?isOutside=true&aid=113809956084766&bvid=BV1XacweXEC2&cid=27816494236&p=1" scrolling="no" border="0" frameborder="no" framespacing="0" allowfullscreen="true"></iframe>
			{//预览代码：<p style = "text-align: center;"><iframe id="vplay" frameborder="0"  src="//player.bilibili.com/player.html?isOutside=true&aid=113804218271116&bvid=BV1yscHeFEMt&cid=27798341903&p=1&autoplay=0" allowFullScreen="true"></iframe></p>
				outputsharediframebox.Text = "<iframe id=\"vplay\" frameborder=\"0\"  "
					+ inputsharediframebox.Text.Replace("<iframe", string.Empty).Replace("\" scrolling=\"no\" border=\"0\" frameborder=\"no\" framespacing=\"0\" allowfullscreen=\"true\"></iframe>", string.Empty)
					+ "&autoplay=0\" allowFullScreen=\"true\"></iframe>";
			}
			else if (inputsharediframebox.Text.StartsWith("BV"))
			{
				outputsharediframebox.Text = $"<p style = \"text-align: center;\"><iframe id=\"vplay\" frameborder=\"0\"  src=\"//player.bilibili.com/player.html?isOutside=true&bvid={inputsharediframebox.Text}&p=1&autoplay=0\" allowFullScreen=\"true\"></iframe></p>";
			}
			else
			{
				copycomplete.Visible = false;
				return;
			}

			copycomplete.Visible = true;
			Clipboard.SetText(outputsharediframebox.Text);
		}

		private void inputsharediframebox_TextChanged(object sender, EventArgs e)
		{
			outputsharediframebox.Text = string.Empty;
			copycomplete.Visible = false;
		}
		#endregion
	}
}
