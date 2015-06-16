using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace AR.Drone.Guide
{
	public class ImageUtilities
	{
		public static Bitmap Threshold(Image img, int intensity){
			Bitmap result = new Bitmap(img);
			Rectangle rect = new Rectangle(0,0,result.Width, result.Height);

			System.Drawing.Imaging.BitmapData bmpData = result.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, img.PixelFormat);
			IntPtr ptr = bmpData.Scan0;
			int bytes = bmpData.Stride * bmpData.Height;
			byte[] rgbValues = new byte[bytes];

			System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, bytes);

			int pixelByteSize = Image.GetPixelFormatSize(bmpData.PixelFormat) / 8;

			byte r, g, b = 0;

			for (int x = 0; x < result.Width; x++)
			{
				for (int y = 0; y < result.Height; y++)
				{
					int pos = y * bmpData.Stride + x * pixelByteSize;

					r = rgbValues[pos];
					g = rgbValues[pos + 1];
					b = rgbValues[pos + 2];

					if ((r + g + b) / 3 >= intensity)
					{
						//rgbValues[pos] = 255;
						//rgbValues[pos + 1] = 255;
						//rgbValues[pos + 2] = 255;
					}
					else
					{
						//rgbValues[pos] = 0;
						//rgbValues[pos + 1] = 0;
						//rgbValues[pos + 2] = 0;
					}
				}
			}

			System.Runtime.InteropServices.Marshal.Copy(rgbValues, 0, ptr, bytes);
			result.UnlockBits(bmpData);

			return result;
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

		public static List<Point> GetConnectingWhitePixels(ref Boolean[,] thresholdedImage, int startX, int startY)
		{
			if (thresholdedImage[startX, startY] == false) return null;
			
			List<Point> result = new List<Point>();
			Queue<Point> q = new Queue<Point>();

			result.Add(new Point(startX, startY));
			q.Enqueue(new Point(startX, startY));

			while (q.Count > 0)
			{

			}


			return result;
		}


	}
}
