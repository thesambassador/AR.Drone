using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading;

using AR.Drone.Infrastructure;

using OpenCvSharp.CPlusPlus;
using OpenCvSharp;

namespace AR.Drone.Guide
{
	class LineDetectorWorker : WorkerBase
	{
		private readonly ConcurrentQueue<Mat> _videoQueue;
		private readonly Action<List<CvLineSegmentPolar> > _onLinesDetected;

		public LineDetectorWorker(Action<List<CvLineSegmentPolar> > onLinesDetected)
		{
			_onLinesDetected = onLinesDetected;
			_videoQueue = new ConcurrentQueue<Mat>();
		}

		public void EnqueueFrame(Mat frame)
		{
			_videoQueue.Enqueue(frame);
		}

		protected override void Loop(System.Threading.CancellationToken token)
		{
			_videoQueue.Flush();
			while (token.IsCancellationRequested == false)
			{
				Mat frame;
				if (_videoQueue.TryDequeue(out frame))
				{
					List<CvLineSegmentPolar> list = TestLineDetection.LineDetectionUtilities.DetectLines(frame);
					_onLinesDetected(list);
				}
				else
				{
					Thread.Sleep(1);
				}
			}

		}
	}
}
