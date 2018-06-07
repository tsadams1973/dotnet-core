using System;
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

                    

                    Console.WriteLine($"Signed {apkname.Value} using {keystorename.Value} and password {keypass.Value}.");
                    return 0;


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

            var result = app.Execute(args);
            Environment.Exit(result);
        }
    }
}
