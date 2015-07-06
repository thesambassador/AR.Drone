using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;

using OpenCvSharp.CPlusPlus;
using OpenCvSharp;

using AR.Drone.Video;

namespace AR.Drone.Guide
{
	public class ImageUtilities
	{
		public static void Test(ref Bitmap frame){

            Mat img = OpenCvSharp.Extensions.BitmapConverter.ToMat(frame);
            Mat outImg = new Mat();

           // Cv2.CvtColor(img, img, ColorConversion.RgbaToGray);
			
			//Cv2.Threshold(img, img, 230, 255, ThresholdType.Binary);

            Cv2.Canny(img, outImg, 25, 255, 3);

            CvLineSegmentPoint[] lines = Cv2.HoughLinesP(outImg, 1, Cv.PI / 180, 50, 50, 10);

            foreach (CvLineSegmentPoint line in lines)
            {
                CvScalar color = new CvScalar(0, 0, 255);   
                Cv2.Line(outImg, line.P1, line.P2, color, 2);
            }

            Window window = new Window("Test", outImg);
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
