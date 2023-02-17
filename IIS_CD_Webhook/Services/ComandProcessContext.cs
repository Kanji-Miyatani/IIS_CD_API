using System.Diagnostics;

namespace IIS_CD_Webhook.Services
{
    public class ComandProcessContext : IDisposable
    {
        Process _p;
        public ComandProcessContext() 
        {
            Process p = new Process();
            p.StartInfo.FileName = Environment.GetEnvironmentVariable("ComSpec");
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.Start();
            _p = p;
            
        }

        /// <summary>
        /// コマンド実行
        /// </summary>
        /// <param name="commands"></param>
        public void DoCommands(params string[] commands)
        {
            System.IO.StreamWriter sw = _p.StandardInput;
            foreach (var command in commands)
            { 
                sw.WriteLine(command);
            }
        }
        public void Dispose()
        {
            _p.Close();
            _p.Dispose();
        }
    }
}
