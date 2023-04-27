////////using System;
////////using Intel.RealSense;
////////using OpenCvSharp;

////////namespace RealSenseDepthCameraApp
////////{
////////    class Program
////////    {
////////        static void Main(string[] args)
////////        {
////////            using (var pipeline = new Pipeline())
////////            {
////////                var config = new Config();
////////                config.EnableStream(Stream.Depth, 640, 480, Format.Z16, 30);
////////                pipeline.Start(config);

////////                using (var window = new OpenCvSharp.Window("Depth Image"))
////////                {
////////                    while (OpenCvSharp.Cv2.WaitKey(1) < 0)
////////                    {
////////                        using (var frames = pipeline.WaitForFrames())
////////                        { 
////////                            using (var depthFrame = frames.DepthFrame)
////////                            {
////////                                if (depthFrame == null) continue;

////////                                var depthImage = new Mat(depthFrame.Height, depthFrame.Width, MatType.CV_16UC1, depthFrame.Data);

////////                                depthImage.ConvertTo(depthImage, MatType.CV_8UC1, 0.05);
////////                                OpenCvSharp.Cv2.ApplyColorMap(depthImage, depthImage, ColormapTypes.Jet);

////////                                for (int y = 0; y < depthImage.Rows; y += 20)
////////                                {
////////                                    for (int x = 0; x < depthImage.Cols; x += 20)
////////                                    {
////////                                        int depth = (int)(depthFrame.GetDistance(x, y) * 1000);
////////                                        if (depth > 0)
////////                                        {
////////                                            OpenCvSharp.Cv2.PutText(depthImage, depth.ToString() + "mm", new Point(x, y), HersheyFonts.HersheySimplex, 0.5, Scalar.White);
////////                                        }
////////                                    }
////////                                }

////////                                window.ShowImage(depthImage);
////////                            }
////////                        }
////////                    }
////////                }
////////            }
////////        }
////////    }
////////}

//////using System;
//////using Intel.RealSense;
//////using OpenCvSharp;

//////namespace RealSenseDepthCameraApp
//////{
//////    class Program
//////    {
//////        static void Main(string[] args)
//////        {
//////            using (var pipeline = new Pipeline())
//////            {
//////                var config = new Config();
//////                config.EnableStream(Stream.Depth, 640, 480, Format.Z16, 30);
//////                pipeline.Start(config);

//////                using (var window = new OpenCvSharp.Window("Depth Image"))
//////                {
//////                    while (OpenCvSharp.Cv2.WaitKey(1) < 0)
//////                    {
//////                        using (var frames = pipeline.WaitForFrames())
//////                        {
//////                            using (var depthFrame = frames.DepthFrame)
//////                            {
//////                                if (depthFrame == null) continue;

//////                                var depthImage = new Mat(depthFrame.Height, depthFrame.Width, MatType.CV_16UC1, depthFrame.Data);

//////                                depthImage.ConvertTo(depthImage, MatType.CV_8UC1, 0.05);
//////                                OpenCvSharp.Cv2.ApplyColorMap(depthImage, depthImage, ColormapTypes.Jet);

//////                                // Görüntüyü 3x3'lük hücrelere ayırma
//////                                int cellWidth = depthImage.Cols / 3;
//////                                int cellHeight = depthImage.Rows / 3;

//////                                for (int i = 0; i < 3; i++)
//////                                {
//////                                    for (int j = 0; j < 3; j++)
//////                                    {
//////                                        int centerX = (int)(cellWidth * (i + 0.5));
//////                                        int centerY = (int)(cellHeight * (j + 0.5));

//////                                        int depth = (int)(depthFrame.GetDistance(centerX, centerY) * 1000);
//////                                        if (depth > 0)
//////                                        {
//////                                            OpenCvSharp.Cv2.PutText(depthImage, depth.ToString() + "mm", new Point(centerX, centerY), HersheyFonts.HersheySimplex, 0.5, Scalar.White);
//////                                        }
//////                                    }
//////                                }

//////                                window.ShowImage(depthImage);
//////                            }
//////                        }
//////                    }
//////                }
//////            }
//////        }
//////    }
//////}

////using System;
////using Intel.RealSense;
////using System.Diagnostics;
////using OpenCvSharp;

////namespace RealSenseDepthCameraApp
////{
////    class Program
////    {
////        static void Main(string[] args)
////        {
////            using (var pipeline = new Pipeline())
////            {
////                var config = new Config();
////                config.EnableStream(Stream.Depth, 640, 480, Format.Z16, 30);
////                config.EnableStream(Stream.Color, 640, 480, Format.Rgb8, 30);
////                pipeline.Start(config);

////                using (var window = new OpenCvSharp.Window("Depth Image"))
////                {
////                    while (OpenCvSharp.Cv2.WaitKey(1) < 0)
////                    {
////                        using (var frames = pipeline.WaitForFrames())
////                        {
////                            using (var depthFrame = frames.DepthFrame)
////                            using (var colorFrame = frames.ColorFrame)
////                            {
////                                if (depthFrame == null || colorFrame == null) continue;

////                                var colorImage = new Mat(colorFrame.Height, colorFrame.Width, MatType.CV_8UC3, colorFrame.Data);

////                                var depthImage = new Mat(depthFrame.Height, depthFrame.Width, MatType.CV_16UC1, depthFrame.Data);
////                                depthImage.ConvertTo(depthImage, MatType.CV_8UC1, 0.05);

////                                // Görüntüyü 3x3'lük hücrelere ayırma
////                                int cellWidth = depthImage.Cols / 3;
////                                int cellHeight = depthImage.Rows / 3;

////                                for (int i = 0; i < 3; i++)
////                                {
////                                    for (int j = 0; j < 3; j++)
////                                    {
////                                        int centerX = (int)(cellWidth * (i + 0.5));
////                                        int centerY = (int)(cellHeight * (j + 0.5));

////                                        float depth = depthFrame.GetDistance(centerX, centerY) * 100; // cm cinsinden derinlik değeri
////                                        if (depth > 0)
////                                        {
////                                            OpenCvSharp.Cv2.PutText(colorImage, depth.ToString("F1") + "cm", new Point(centerX, centerY), HersheyFonts.HersheySimplex, 0.5, Scalar.White);
////                                        }
////                                    }
////                                }

////                                window.ShowImage(colorImage);
////                            }
////                        }
////                    }
////                }
////            }
////        }
////    }
////}

//using System;
//using Intel.RealSense;
//using OpenCvSharp;
//using System.Diagnostics;

//namespace RealSenseDepthCameraApp
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            using (var pipeline = new Pipeline())
//            {
//                var config = new Config();
//                config.EnableStream(Stream.Depth, 640, 480, Format.Z16, 30);
//                config.EnableStream(Stream.Color, 640, 480, Format.Rgb8, 30);
//                pipeline.Start(config);

//                using (var window = new OpenCvSharp.Window("Depth Image"))
//                {
//                    Stopwatch stopwatch = new Stopwatch();
//                    stopwatch.Start();
//                    var frameCount = 0;
//                    var cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
//                    cpuCounter.NextValue();

//                    double fps = 0.0;
//                    float cpuUsage = 0.0f;


//                    while (OpenCvSharp.Cv2.WaitKey(1) < 0)
//                    {
//                        using (var frames = pipeline.WaitForFrames())
//                        {
//                            using (var depthFrame = frames.DepthFrame)
//                            using (var colorFrame = frames.ColorFrame)
//                            {
//                                if (depthFrame == null || colorFrame == null) continue;

//                                var colorImage = new Mat(colorFrame.Height, colorFrame.Width, MatType.CV_8UC3, colorFrame.Data);

//                                var depthImage = new Mat(depthFrame.Height, depthFrame.Width, MatType.CV_16UC1, depthFrame.Data);
//                                depthImage.ConvertTo(depthImage, MatType.CV_8UC1, 0.05);

//                                int cellWidth = depthImage.Cols / 3;
//                                int cellHeight = depthImage.Rows / 3;

//                                for (int i = 0; i < 3; i++)
//                                {
//                                    for (int j = 0; j < 3; j++)
//                                    {
//                                        int centerX = (int)(cellWidth * (i + 0.5));
//                                        int centerY = (int)(cellHeight * (j + 0.5));

//                                        float depth = depthFrame.GetDistance(centerX, centerY) * 100; // cm cinsinden derinlik değeri
//                                        if (depth > 0)
//                                        {
//                                            OpenCvSharp.Cv2.PutText(colorImage, depth.ToString("F1") + "cm", new Point(centerX, centerY), HersheyFonts.HersheySimplex, 0.5, Scalar.White);
//                                        }
//                                    }
//                                }

//                                frameCount++;
//                                var elapsedMs = stopwatch.ElapsedMilliseconds;
//                                if (elapsedMs >= 1000)
//                                {
//                                    var fps = frameCount * 1000.0 / elapsedMs;
//                                    var cpuUsage = cpuCounter.NextValue();
//                                    Console.WriteLine($"FPS: {fps:F2}, CPU Usage: {cpuUsage:F2}%");

//                                    stopwatch.Restart();
//                                    frameCount = 0;
//                                }

//                                OpenCvSharp.Cv2.PutText(colorImage, $"FPS: {fps:F2}", new Point(10, 20), HersheyFonts.HersheySimplex, 0.5, Scalar.White);
//                                OpenCvSharp.Cv2.PutText(colorImage, $"CPU: {cpuUsage:F2}%", new Point(10, 40), HersheyFonts.HersheySimplex, 0.5, Scalar.White);

//                                window.ShowImage(colorImage);
//                            }
//                        }
//                    }
//                }
//            }
//        }
//    }
//}
using System;
using Intel.RealSense;
using OpenCvSharp;
using System.Diagnostics;

namespace RealSenseDepthCameraApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var pipeline = new Pipeline())
            {
                var config = new Config();
                config.EnableStream(Stream.Depth, 640, 480, Format.Z16, 30);
                config.EnableStream(Stream.Color, 640, 480, Format.Rgb8, 30);
                pipeline.Start(config);

                using (var window = new OpenCvSharp.Window("Depth Image"))
                {
                    Stopwatch stopwatch = new Stopwatch();
                    stopwatch.Start();
                    var frameCount = 0;
                    var cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
                    cpuCounter.NextValue();

                    double fps = 0.0;
                    float cpuUsage = 0.0f;

                    while (OpenCvSharp.Cv2.WaitKey(1) < 0)
                    {
                        using (var frames = pipeline.WaitForFrames())
                        {
                            using (var depthFrame = frames.DepthFrame)
                            using (var colorFrame = frames.ColorFrame)
                            {
                                if (depthFrame == null || colorFrame == null) continue;

                                var colorImage = new Mat(colorFrame.Height, colorFrame.Width, MatType.CV_8UC3, colorFrame.Data);

                                var depthImage = new Mat(depthFrame.Height, depthFrame.Width, MatType.CV_16UC1, depthFrame.Data);
                                depthImage.ConvertTo(depthImage, MatType.CV_8UC1, 0.05);

                                int cellWidth = depthImage.Cols / 3;
                                int cellHeight = depthImage.Rows / 3;

                                for (int i = 0; i < 3; i++)
                                {
                                    for (int j = 0; j < 3; j++)
                                    {
                                        int centerX = (int)(cellWidth * (i + 0.5));
                                        int centerY = (int)(cellHeight * (j + 0.5));

                                        float depth = depthFrame.GetDistance(centerX, centerY) * 100; // cm cinsinden derinlik değeri
                                        if (depth > 0)
                                        {
                                            OpenCvSharp.Cv2.PutText(colorImage, depth.ToString("F1") + "cm", new Point(centerX, centerY), HersheyFonts.HersheySimplex, 0.5, Scalar.White);
                                        }
                                    }
                                }

                                frameCount++;
                                var elapsedMs = stopwatch.ElapsedMilliseconds;
                                if (elapsedMs >= 1000)
                                {
                                    fps = frameCount * 1000.0 / elapsedMs;
                                    cpuUsage = cpuCounter.NextValue();
                                    Console.WriteLine($"FPS: {fps:F2}, CPU Usage: {cpuUsage:F2}%");

                                    stopwatch.Restart();
                                    frameCount = 0;
                                }

                                OpenCvSharp.Cv2.PutText(colorImage, $"FPS: {fps:F2}", new Point(10, 20), HersheyFonts.HersheySimplex, 0.5, Scalar.White);
                                OpenCvSharp.Cv2.PutText(colorImage, $"CPU: {cpuUsage:F2}%", new Point(10, 40), HersheyFonts.HersheySimplex, 0.5, Scalar.White);

                                window.ShowImage(colorImage);
                            }
                        }
                    }
                }
            }
        }
    }
}