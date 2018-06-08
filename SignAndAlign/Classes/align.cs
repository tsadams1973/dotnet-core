using System;
using System.Diagnostics;
using System.Text;

namespace SignAndAlign
{

    static class Align
    {
        private const string ALIGNMENT = @"C:\Android\android-sdk\build-tools\27.0.3\zipalign.exe";
        private const string ALIGNMENT_ARGS = "-f -v 4 ";
        private const string OUT_FILE = "release-aligned.apk";

        public static string AlignApk(string apkName)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo(ALIGNMENT);

            startInfo.Arguments = String.Format("{0} {1} {2}", ALIGNMENT_ARGS, apkName, OUT_FILE);
            startInfo.RedirectStandardOutput = true;

            try{    
                
                using( Process runningProcess = Process.Start(startInfo))
                {
                    StringBuilder sb = new StringBuilder();

                    while (!runningProcess.HasExited)
                    {
                        sb.Append(runningProcess.StandardOutput.ReadToEnd());
                    }
                    Console.WriteLine(sb.ToString());
                }
                                 
                return OUT_FILE;
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
            
        }
        

    }

}