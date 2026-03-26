using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency_DB_GUI.Utils
{
    internal class ProcessController
    {
        public class ProcessResult
        {
            public int ExitCode { get; set; }
            public string Output { get; set; }
            public string Error { get; set; }
            public bool Success => ExitCode == 0;
        }

        public static ProcessResult Run(string fileName, string arguments, int timeout = 30000)
        {
            var startInfo = new ProcessStartInfo
            {
                FileName = fileName,
                Arguments = arguments,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = true,
                StandardOutputEncoding = System.Text.Encoding.UTF8,
                StandardErrorEncoding = System.Text.Encoding.UTF8
            };

            var result = new ProcessResult();

            using (var process = new Process { StartInfo = startInfo })
            {
                try
                {
                    process.Start();

                    // Читаем вывод асинхронно, чтобы избежать deadlock
                    var outputTask = process.StandardOutput.ReadToEndAsync();
                    var errorTask = process.StandardError.ReadToEndAsync();

                    if (process.WaitForExit(timeout))
                    {
                        result.Output = outputTask.Result;
                        result.Error = errorTask.Result;
                        result.ExitCode = process.ExitCode;
                    }
                    else
                    {
                        process.Kill();
                        result.Error = "Превышено время ожидания";
                        result.ExitCode = -1;
                    }
                }
                catch (Exception ex)
                {
                    result.Error = ex.Message;
                    result.ExitCode = -1;
                }
            }

            return result;
        }

        public static async Task<ProcessResult> RunAsync(string fileName, string arguments, int timeout = 30000)
        {
            var startInfo = new ProcessStartInfo
            {
                FileName = fileName,
                Arguments = arguments,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = true,
                StandardOutputEncoding = System.Text.Encoding.UTF8,
                StandardErrorEncoding = System.Text.Encoding.UTF8
            };

            var result = new ProcessResult();

            using (var process = new Process { StartInfo = startInfo })
            {
                try
                {
                    process.Start();

                    var outputTask = process.StandardOutput.ReadToEndAsync();
                    var errorTask = process.StandardError.ReadToEndAsync();

                    var waitTask = Task.Run(() => process.WaitForExit(timeout));

                    if (await waitTask)
                    {
                        result.Output = await outputTask;
                        result.Error = await errorTask;
                        result.ExitCode = process.ExitCode;
                    }
                    else
                    {
                        process.Kill();
                        result.Error = "Превышено время ожидания";
                        result.ExitCode = -1;
                    }
                }
                catch (Exception ex)
                {
                    result.Error = ex.Message;
                    result.ExitCode = -1;
                }
            }

            return result;
        }
    }
}
