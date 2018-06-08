using System;
using System.Threading.Tasks;
using Microsoft.Extensions.CommandLineUtils;

namespace SignAndAlign
{
    class Program
    {
        static void Main(string[] args)
        {            
            var app = new CommandLineApplication();

            var apk = app.Command("apk",config => {
                config.Description = "Sign and align the apk.";
                config.HelpOption("--help");
                var apkname= config.Argument("apkname", "The name of the apk.",false);
                var keystorename = config.Argument("keystore","The name of your keystore.",false);
                var keypass = config.Argument("password","The password for your keystore.",false);
                config.OnExecute(()=>{

                    try{
                        var alignedFileName = Align.AlignApk(apkname.Value);

                        Console.WriteLine("");
                        Console.WriteLine("Success aligning apk.");
                        Console.WriteLine("");

                        var signedFileName = Sign.SignApk(alignedFileName, keystorename.Value, keypass.Value);

                        Console.WriteLine("");
                        Console.WriteLine("Success signing apk.");
                        Console.WriteLine("");

                        return 0;

                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine("");
                        Console.WriteLine(ex.Message);
                        Console.WriteLine("");

                        return 1;
                    }                 

                });
            });
            
            apk.Command("align", config=>{
                config.OnExecute(()=>{
                    Console.WriteLine("Only align the apk.");
                    return 1; //not implemented
                });
            });

            apk.Command("sign", config=>{
                config.OnExecute(()=>{
                    Console.WriteLine("Only sign the apk.");
                    return 1; //not implemented
                });
            });            

            app.HelpOption("--help");

            var result =  app.Execute(args);
            Environment.Exit(result);
        }
    }
}
