using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;

using OpenCV.Net;
using System.Windows.Forms;

namespace AR.Drone.Guide
{
	public class ImageUtilities
	{
		public static void Test(){
			OpenFileDialog dlg = new OpenFileDialog();
			dlg.Title = "Open Img";

			if (dlg.ShowDialog() == DialogResult.OK)
			{
				Bitmap img = new Bitmap(dlg.FileName);

				BitmapData data = img.LockBits(new Rectangle(0, 0, img.Width, img.Height), ImageLockMode.ReadWrite, img.PixelFormat);
				IntPtr ptr = data.Scan0;

				Mat ocv = new Mat(img.Height, img.Width, Depth.U8, 3, ptr);
				
				


				NamedWindow window = new NamedWindow("Test", WindowFlags.AutoSize);
				window.ShowImage(ocv);

				img.UnlockBits(data);

			}
			
			
			
		}

		public static Boolean[,] ThresholdToBoolean(Image img, int intensity)
		{
			Boolean[,] result = new Boolean[img.Width, img.Height];

			Bitmap bmp = new Bitmap(img);
			Rectangle rect = new Rectangle(0, 0, img.Width, img.Height);

			System.Drawing.Imaging.BitmapData bmpData = bmp.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadOnly, img.PixelFormat);
			IntPtr ptr = bmpData.Scan0;
			int bytes = bmpData.Stride * bmpData.Height;
			byte[] rgbValues = new byte[bytes];

			System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, bytes);

			int pixelByteSize = Image.GetPixelFormatSize(bmpData.PixelFormat) / 8;

			byte r, g, b = 0;

			for (int x = 0; x < img.Width; x++)
			{
				for (int y = 0; y < img.Height; y++)
				{
					int pos = y * bmpData.Stride + x * pixelByteSize;

					r = rgbValues[pos];
					g = rgbValues[pos + 1];
					b = rgbValues[pos + 2];

					if ((r + g + b) / 3 >= intensity)
					{
						result[x, y] = true;
					}
					else
					{
						result[x, y] = false;
					}
				}
			}

			System.Runtime.InteropServices.Marshal.Copy(rgbValues, 0, ptr, bytes);
			bmp.UnlockBits(bmpData);

			return result;
		}



	}
}
