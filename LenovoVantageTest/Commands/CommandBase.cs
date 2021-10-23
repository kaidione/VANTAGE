namespace LenovoVantageTest
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Management.Automation;
    using System.Management.Automation.Runspaces;

    public class CommandBase
    {


        public void RunCommand(string script, string parameter)
        {
            //Runspace runSpace = RunspaceFactory.CreateRunspace();
            //runSpace.Open();

            //Pipeline pipeliC:\vantage-uwp-automation\TestFoundation\Commands\CommandBase.csne = runSpace.CreatePipeline();
            //pipeline.Commands.AddScript(script);
            //pipeline.Commands.Add("Out-String");

            //Collection<PSObject> result = pipeline.Invoke();
            //runSpace.Close();

            IDictionary parameters = new Dictionary<string, string>();

            PowerShell ps = PowerShell.Create();
            ps.AddCommand(script);
            ps.Invoke();
        }

        public static void RunCmd(string cmdStr)
        {
            var processInfo = new ProcessStartInfo("cmd.exe", "/S /C " + cmdStr)
            {
                CreateNoWindow = true,
                UseShellExecute = true,
                WindowStyle = ProcessWindowStyle.Hidden,
                Verb = "runas"
            };

            Process.Start(processInfo);
        }

        public static void RunCmdException(string cmdStr)
        {
            try
            {
                var processInfo = new ProcessStartInfo("cmd.exe", "/S /C " + cmdStr)
                {
                    CreateNoWindow = true,
                    UseShellExecute = true,
                    WindowStyle = ProcessWindowStyle.Hidden,
                    Verb = "runas"
                };
                Process process = new Process
                {
                    StartInfo = processInfo
                };
                process.Start();
                process.WaitForExit();
                process.Close();
            }
            catch (Exception ex)
            {
                LogHelper.Logger.Instance.WriteLog("RunCmdException()" + ex.Message, LogHelper.LogType.Error);
            }
        }


        public static void RunPowershellCmdlet(List<string> cmdlets)
        {
            Runspace runspace = RunspaceFactory.CreateRunspace();
            runspace.Open();
            Pipeline pipe = runspace.CreatePipeline();
            foreach (string cmd in cmdlets)
            {
                pipe.Commands.AddScript(cmd);
            }
            pipe.Invoke();
            runspace.Close();
        }

        public static string GetPowershellCmdletResult(List<string> cmdlets)
        {
            Runspace runspace = RunspaceFactory.CreateRunspace();
            runspace.Open();
            Pipeline pipe = runspace.CreatePipeline();
            foreach (string cmd in cmdlets)
            {
                pipe.Commands.AddScript(cmd);
            }
            var result = pipe.Invoke();
            string anti = result[0].ToString();
            runspace.Close();
            return anti;
        }
    }

}
