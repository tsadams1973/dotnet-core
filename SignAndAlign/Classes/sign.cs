using System;
using System.Diagnostics;
using System.Security;
using System.Text;

namespace SignAndAlign
{
    static class Sign
    {
        private const string SIGNING = @"C:\Android\android-sdk\build-tools\27.0.3\apksigner.bat";
        
        private const string OUT_FILE = "release.apk";

        public static string SignApk(string apkName, string keyStoreName, string keyStorePassword)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo(SIGNING);

            startInfo.Arguments = String.Format("sign --ks {0} --out {1} {2}", keyStoreName, OUT_FILE, apkName);            
            startInfo.RedirectStandardOutput = true;
            startInfo.RedirectStandardInput = true;

            try{    
                
                using( Process runningProcess = Process.Start(startInfo))
                {               
                    //apksigner prompts for the password here, provide it     
                    runningProcess.StandardInput.WriteLine(keyStorePassword);
                    
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