using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

using OpenCvSharp;
using OpenCvSharp.CPlusPlus;

namespace TestLineDetection
{
	class LineDetectionUtilities
	{
		public static void DetectAndDrawLines(Bitmap bmp)
		{
			//convert to opencv format
			Mat mat = OpenCvSharp.Extensions.BitmapConverter.ToMat(bmp);

			DetectAndDrawLines(mat);

		}

		public static void DetectAndDrawLines(Mat mat)
		{
			//size down to a smaller image?
			OpenCvSharp.CPlusPlus.Size size = new OpenCvSharp.CPlusPlus.Size(mat.Width, mat.Height);
			Mat img = new Mat(size, MatType.CV_8UC1);
			Mat orig = new Mat(size, mat.Type());
			Cv2.Resize(mat, img, size);
			Cv2.Resize(mat, orig, size);

			//go to greyscale and then threshhold
			Cv2.CvtColor(img, img, ColorConversion.BgrToGray);
			Cv2.Threshold(img, img, 200, 255, ThresholdType.Binary);

			//now skeletonize our image
			Mat skel = Skeleton(img);

			List<CvLineSegmentPolar> lines = GetAndFilterLines(skel);
			ShowLinesOverOriginal(orig, ref lines);
		}

		public static List<CvLineSegmentPolar> DetectLines(Mat mat)
		{
			OpenCvSharp.CPlusPlus.Size size = new OpenCvSharp.CPlusPlus.Size(mat.Width, mat.Height);
			Mat img = new Mat(size, MatType.CV_8UC1);
			Mat orig = new Mat(size, mat.Type());
			Cv2.Resize(mat, img, size);
			Cv2.Resize(mat, orig, size);

			//go to greyscale and then threshhold
			Cv2.CvtColor(img, img, ColorConversion.BgrToGray);
			Cv2.Threshold(img, img, 200, 255, ThresholdType.Binary);

			//now skeletonize our image
			Mat skel = Skeleton(img);

			List<CvLineSegmentPolar> lines = GetAndFilterLines(skel);
			return lines;
		}

		private static List<CvLineSegmentPolar> GetAndFilterLines(Mat skel, double rho = 1, double theta = Cv.PI / 180, int threshold = 30)
		{
			CvLineSegmentPolar[] lines = Cv2.HoughLines(skel, rho, theta, threshold);
			//normalize the rhos/thetas, some of the rhos end up negative which makes it harder to compare lines
			for (int i = 0; i < lines.Length; i++)
			{
				if (lines[i].Rho < 0)
				{
					lines[i].Rho *= -1;
					lines[i].Theta -= (float)Cv.PI;
				}
			}

			List<CvLineSegmentPolar> groupedLines = GroupSimilarLines(ref lines);
			return groupedLines;
		}

		private static List<CvLineSegmentPolar> GroupSimilarLines(ref CvLineSegmentPolar[] lines)
		{
			List<CvLineSegmentPolar> detectedLines = new List<CvLineSegmentPolar>(lines);
			List<CvLineSegmentPolar> groupedLines = new List<CvLineSegmentPolar>();
			double thetaThreshold = 3;
			double rhoThreshold = 10;

			while (detectedLines.Count > 0)
			{
				CvLineSegmentPolar l1 = detectedLines[0];
				detectedLines.RemoveAt(0);

				int num = 1;
				float avgRho = l1.Rho;
				float avgTheta = l1.Theta;
				for (int i = detectedLines.Count - 1; i >= 0; i--)
				{
					CvLineSegmentPolar l2 = detectedLines[i];
					if (Math.Abs(l1.Theta - l2.Theta) <= thetaThreshold && Math.Abs(l1.Rho - l2.Rho) <= rhoThreshold)
					{
						avgRho += l2.Rho;
						avgTheta += l2.Theta;
						num++;
						detectedLines.RemoveAt(i);
					}
				}

				avgRho /= num;
				avgTheta /= num;
				groupedLines.Add(new CvLineSegmentPolar(avgRho, avgTheta));
			}
			return groupedLines;
		}

		private static void ShowLinesOverOriginal(Mat orig, ref List<CvLineSegmentPolar> lines)
		{
			CvScalar color = new CvScalar(0, 0, 255);
			CvScalar color2 = new CvScalar(0, 255, 0);
			int f = 0;
			foreach (CvLineSegmentPolar line in lines)
			{
				CvPoint p1, p2;
				double a = Math.Cos(line.Theta);
				double b = Math.Sin(line.Theta);
				double x0 = a * line.Rho;
				double y0 = b * line.Rho;
				p1.X = Cv.Round(x0 + 1000 * (-b));
				p1.Y = Cv.Round(y0 + 1000 * (a));
				p2.X = Cv.Round(x0 - 1000 * (-b));
				p2.Y = Cv.Round(y0 - 1000 * (a));

				if (f > 1)
					Cv2.Line(orig, p1, p2, color, 2);
				else
					Cv2.Line(orig, p1, p2, color2, 2);
				f++;
			}
			Window windowf = new Window(lines.Count.ToString(), orig);
		}

		public static void DrawLinesOnBitmap(Bitmap bmp, List<CvLineSegmentPolar> lines)
		{
			Graphics g = Graphics.FromImage(bmp);
			Pen redPen = new Pen(Color.Red, 3);
			System.Drawing.Point p1 = new System.Drawing.Point();
			System.Drawing.Point p2 = new System.Drawing.Point();

			foreach (CvLineSegmentPolar line in lines)
			{
				double a = Math.Cos(line.Theta);
				double b = Math.Sin(line.Theta);
				double x0 = a * line.Rho;
				double y0 = b * line.Rho;

				p1.X = Cv.Round(x0 + 1000 * (-b));
				p1.Y = Cv.Round(y0 + 1000 * (a));
				p2.X = Cv.Round(x0 - 1000 * (-b));
				p2.Y = Cv.Round(y0 - 1000 * (a));

				g.DrawLine(redPen, p1, p2);
			}
	
		}

		

		private static Mat Skeleton(Mat img)
		{
			//create temporary stuff
			Mat skel = new Mat(img.Size(), MatType.CV_8UC1, new Scalar(0));
			Mat temp = new Mat(img.Size(), MatType.CV_8UC1);
			Mat eroded = new Mat();

			Mat element = Cv2.GetStructuringElement(StructuringElementShape.Cross, Cv.Size(3, 3));
			bool done = false;
			do
			{
				Cv2.Erode(img, eroded, element);
				Cv2.Dilate(eroded, temp, element);
				Cv2.Subtract(img, temp, temp);
				Cv2.BitwiseOr(skel, temp, skel);
				eroded.CopyTo(img);

				done = (Cv2.CountNonZero(img) == 0);
			}
			while (!done);
			return skel;
		}

		


	}
}
