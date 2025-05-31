using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Net;
using System.Security.Policy;
using System.Text.RegularExpressions;
using System.Collections.Specialized;
using QYArticleUpdater.Main;
namespace QYArticleUpdater
{
	public partial class PictureIO : Form
	{
		Image img;
		string[] files;
		public PictureIO()
		{
			InitializeComponent();
			this.PictureInput.AllowDrop = true;
			// ע��DragEnter�¼�
			this.PictureInput.DragEnter += new DragEventHandler(PictureInput_DragEnter);

			// ע��DragDrop�¼�
			this.PictureInput.DragDrop += new DragEventHandler(PictureInput_DragDrop);
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
						// ����PictureBox��ͼ��
						this.PictureInput.Image = Image.FromFile(file);
						break; // ֻ������һ��ͼ���ļ�
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
				// ����Ϸŵ������Ƿ�����ļ�
				string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

				// ����Ƿ���ͼ���ļ�
				foreach (var file in files)
				{
					if (file.EndsWith(".jpg") || file.EndsWith(".jpeg") || file.EndsWith(".png") || file.EndsWith(".bmp") || file.EndsWith(".webp"))
					{
						e.Effect = DragDropEffects.Copy; // ��������
						return;
					}
				}
			}
			PictureInput_BackgroundImageChanged();
			e.Effect = DragDropEffects.None; // �������κ��Ϸ�
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
			// ȷ����ͼ��Ҫ����
			if (PictureInput.Image == null) return;

			// ���ñ�����������ָ��JPEG����
			ImageCodecInfo jpgEncoder = GetEncoder(ImageFormat.Jpeg);
			EncoderParameters encoderParams = new EncoderParameters(1);

			int quality = Convert.ToInt32(QualitySelector.SelectedItem.ToString().TrimEnd('%'));
			encoderParams.Param[0] = new EncoderParameter(Encoder.Quality, quality);
			// ����һ���µ�Bitmap�������ڱ����������С���ʽ��ͼ��
			Bitmap bitmap = new Bitmap(PictureInput.Image);
			// �����ڴ���
			using (MemoryStream ms = new MemoryStream())
			{
				// ��bitmap����ΪJPEG��ʽ���ڴ����У�ͬʱӦ��JPEG��������
				bitmap.Save(ms, jpgEncoder, encoderParams);

				// ���ڴ��������µ�Image����
				Image img = Image.FromStream(ms);
				img = ResizeImage(img, new Size(Convert.ToInt32(resolutionX.Text), Convert.ToInt32(resolutionY.Text)));

				//img = ResizeImage(img, new Size(Convert.ToInt32(resolutionX.Text), Convert.ToInt32(resolutionY.Text)));
				img.Save(OutputPath.Text + "\\" + Suffix1.Text + "-" + DateTime.Now.ToString("MM-dd-hh-mm-ss") + ".jpg", ImageFormat.Jpeg);

				// �ͷ���Դ
				img.Dispose();
			}

			// �ͷ�bitmap��Դ
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
			// ȷ����ͼ��Ҫ����
			if (PictureInput.Image == null) return;

			// ���ñ�����������ָ��JPEG����
			ImageCodecInfo jpgEncoder = GetEncoder(ImageFormat.Jpeg);
			EncoderParameters encoderParams = new EncoderParameters(1);

			int quality = Convert.ToInt32(QualitySelector.SelectedItem.ToString().TrimEnd('%'));
			encoderParams.Param[0] = new EncoderParameter(Encoder.Quality, quality);
			// ����һ���µ�Bitmap�������ڱ����������С���ʽ��ͼ��
			Bitmap bitmap = new Bitmap(PictureInput.Image);
			// �����ڴ���
			using (MemoryStream ms = new MemoryStream())
			{
				// ��bitmap����ΪJPEG��ʽ���ڴ����У�ͬʱӦ��JPEG��������
				bitmap.Save(ms, jpgEncoder, encoderParams);

				// ���ڴ��������µ�Image����
				Image img = Image.FromStream(ms);
				img = ResizeImage(img, new Size(Convert.ToInt32(resolutionX.Text), Convert.ToInt32(resolutionY.Text)));
				img.Save(OutputPath.Text + "\\" + Suffix1.Text + ".jpg", ImageFormat.Jpeg);
				//img = Image.FromFile($"{OutputPath.Text}\\{Suffix1.Text}.jpg");

				// �����ļ�·������
				StringCollection filePaths = new StringCollection();
				string tempFilePath = OutputPath.Text + "\\" + Suffix1.Text + ".jpg";
				filePaths.Add(tempFilePath);

				// ���ļ�·�����Ϸ��������
				Clipboard.SetFileDropList(filePaths);
				// ��ͼ���Ƶ�������
				//Clipboard.SetImage(img);

				// �ͷ���Դ
				img.Dispose();
			}

			// �ͷ�bitmap��Դ
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
				// ��ȡPictureBox�Ĵ�С
				Size picBoxSize = PictureInput.Size;

				// ��ȡPictureBox��ͼ���ʵ�ʴ�С
				Size imgSize = PictureInput.Image.Size;

				// ����ͼ�����ű���
				double scaleWidth = (double)picBoxSize.Width / imgSize.Width;
				double scaleHeight = (double)picBoxSize.Height / imgSize.Height;

				// ����PictureBox��SizeModeȷ��ʹ���ĸ����ű���
				double scale = Math.Max(scaleWidth, scaleHeight);
				if (PictureInput.SizeMode == PictureBoxSizeMode.AutoSize || PictureInput.SizeMode == PictureBoxSizeMode.Normal)
				{
					scale = 1.0; // ���ͼƬû�б����ţ������ű���Ϊ1
				}

				// ��ȡ���λ�������PictureBox������
				clickPoint = new Point(e.X, e.Y);
				// ���ǵ�PictureBox���ܵĹ���ƫ��
				Point scrollOffset = PictureInput.Parent is Panel panel ? new Point(panel.AutoScrollPosition.X, panel.AutoScrollPosition.Y) : Point.Empty;

				// ����������ԭͼ�е�����
				Point originalPoint = new Point((int)((clickPoint.X - scrollOffset.X) / scale), (int)((clickPoint.Y - scrollOffset.Y) / scale));

				groupBox3.Enabled = true;
				if (originalPoint.X < 0) originalPoint.X = 0;
				if (originalPoint.Y < 0) originalPoint.Y = 0;
				if (originalPoint.X > picBoxSize.Width) originalPoint.X = picBoxSize.Width;
				if (originalPoint.Y > picBoxSize.Height) originalPoint.Y = picBoxSize.Height;
				ClickedPoint.Text = $"��ѡ������: {originalPoint.X}, {originalPoint.Y}";
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

			// �ָ��
			int splitX = clickPoint.X;
			int splitY = clickPoint.Y;
			if (splitX < 0) splitX = 0;
			if (splitY < 0) splitY = 0;
			if (splitX > originalImage.Width) splitX = originalImage.Width;
			if (splitY > originalImage.Height) splitY = originalImage.Height;
			// �ָ�ͼ��
			Bitmap topLeft = CropImage(originalImage, new Rectangle(0, 0, splitX, splitY));
			Bitmap topRight = CropImage(originalImage, new Rectangle(splitX, 0, originalImage.Width - splitX, splitY));
			Bitmap bottomLeft = CropImage(originalImage, new Rectangle(0, splitY, splitX, originalImage.Height - splitY));
			Bitmap bottomRight = CropImage(originalImage, new Rectangle(splitX, splitY, originalImage.Width - splitX, originalImage.Height - splitY));

			Bitmap Top = CropImage(originalImage, new Rectangle(0, 0, originalImage.Width, splitY));
			Bitmap Bottom = CropImage(originalImage, new Rectangle(0, splitY, originalImage.Width, originalImage.Height - splitY));
			Bitmap Left = CropImage(originalImage, new Rectangle(0, 0, splitX, originalImage.Height));
			Bitmap Right = CropImage(originalImage, new Rectangle(splitX, 0, originalImage.Width - splitX, originalImage.Height));

			if (sender.ToString().Contains("����"))
			{
				PictureInput.Image = topLeft;
			}
			else if (sender.ToString().Contains("����"))
			{
				PictureInput.Image = bottomLeft;
			}
			else if (sender.ToString().Contains("����"))
			{
				PictureInput.Image = topRight;
			}
			else if (sender.ToString().Contains("����"))
			{
				PictureInput.Image = bottomRight;
			}
			else if (sender.ToString().Contains("��"))
			{
				PictureInput.Image = Top;
			}
			else if (sender.ToString().Contains("��"))
			{
				PictureInput.Image = Bottom;
			}
			else if (sender.ToString().Contains("��"))
			{
				PictureInput.Image = Left;
			}
			else if (sender.ToString().Contains("��"))
			{
				PictureInput.Image = Right;
			}
			ClickedPoint.Text = $"��ѡ������: ";
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
			// �������ı���ʽ��ȡ����������
			var clipboardText = Clipboard.GetText();
			if (!string.IsNullOrEmpty(clipboardText) && clipboardText.StartsWith("data:image"))
			{
				try
				{
					// ������URIת��ΪImage����
					PictureInput.Image = ConvertDataUriToImage(clipboardText);
				}
				catch (Exception ex)
				{
					MessageBox.Show("�޷�������URI����ͼƬ: " + ex.Message);
				}
			}
		}

		private Image ConvertDataUriToImage(string dataUri)
		{
			// �Ƴ�"data:image/png;base64,"ǰ׺
			string base64String = dataUri.Split(',')[1];
			byte[] imageBytes = Convert.FromBase64String(base64String);

			// ʹ���ڴ�������ͼ��
			using (MemoryStream ms = new MemoryStream(imageBytes))
			{
				return Image.FromStream(ms);
			}
		}
		/// <summary>
		/// ճ��ͼ��
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
			// ȷ����ͼ��Ҫ����
			if (PictureInput.Image == null) return 0;

			// ���ñ�����������ָ��JPEG����
			ImageCodecInfo jpgEncoder = GetEncoder(ImageFormat.Jpeg);
			EncoderParameters encoderParams = new EncoderParameters(1);

			int quality = Convert.ToInt32(Convert.ToString(QualitySelector.SelectedItem).TrimEnd('%'));
			encoderParams.Param[0] = new EncoderParameter(Encoder.Quality, quality);
			img = ResizeImage(img, new Size(Convert.ToInt32(resolutionX.Text), Convert.ToInt32(resolutionY.Text)));
			// ����һ���µ�Bitmap�������ڱ����������С���ʽ��ͼ��
			Bitmap bitmap = new Bitmap(img);
			// �����ڴ���
			MemoryStream ms = new MemoryStream();

			// ��bitmap����ΪJPEG��ʽ���ڴ����У�ͬʱӦ��JPEG��������
			bitmap.Save(ms, jpgEncoder, encoderParams);
			long len = ms.Length;//��ȡͼƬ��С


			// �ͷ���Դ
			img.Dispose();


			// �ͷ�bitmap��Դ
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
				// ��PictureBox�е�ͼ������񻯴���
				Bitmap originalImage = new Bitmap(PictureInput.Image);
				Bitmap sharpenedImage = ImageSharpener.Sharpen(originalImage, 1.5f); // ����factorֵ�Կ����񻯳̶�

				// ���������ͼ�����û�PictureBox
				PictureInput.Image?.Dispose(); // �ͷ�ԭʼͼ����Դ
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
		/// ת��iframe
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void convertIframeButton_Click(object sender, EventArgs e)
		{
			if (inputsharediframebox.Text.StartsWith("<iframe"))//ʾ�����룺<iframe src="//player.bilibili.com/player.html?isOutside=true&aid=113809956084766&bvid=BV1XacweXEC2&cid=27816494236&p=1" scrolling="no" border="0" frameborder="no" framespacing="0" allowfullscreen="true"></iframe>
			{//Ԥ�������<p style = "text-align: center;"><iframe id="vplay" frameborder="0"  src="//player.bilibili.com/player.html?isOutside=true&aid=113804218271116&bvid=BV1yscHeFEMt&cid=27798341903&p=1&autoplay=0" allowFullScreen="true"></iframe></p>
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

