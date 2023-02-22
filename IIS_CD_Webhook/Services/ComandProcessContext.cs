﻿using System;
using System.Diagnostics;

namespace IIS_CD_Webhook.Services
{
    public class ComandProcessContext : IDisposable
    {
        Process _p;
        ILogger _logger;
        public ComandProcessContext(ILogger logger) 
        {
            Process p = new Process();
            p.StartInfo.FileName = Environment.GetEnvironmentVariable("ComSpec");
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.Start();
            _p = p;
            _logger = logger;
        }

        /// <summary>
        /// コマンド実行
        /// </summary>
        /// <param name="commands"></param>
        public void DoCommands(params string[] commands)
        {
            System.IO.StreamWriter sw = _p.StandardInput;
            //エラーを出力
            foreach (var command in commands)
            { 
                sw.WriteLine(command);
            }
        }
        public void Dispose()
        {
            _p.StandardInput.Close();
            _p.Close();
            _p.Dispose();
        }
    }
}