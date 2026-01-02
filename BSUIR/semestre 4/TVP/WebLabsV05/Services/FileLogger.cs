using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebLabsV05.Services
{
    public class FileLogger : ILogger
    {
        // путь к файлу логирования
        private string _filePath;
        // объект для синхронизации записи в файл
        private object _lock;
        /// <summary>
        /// Констркутор
        /// </summary>
        /// <param name="path">путь к файлу логирования</param>
        public FileLogger(string path)
        {
            _filePath = path;
            _lock = new object();
        }
        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            // логирование разрешено для уровня Infomation
            return logLevel==LogLevel.Information;
        }

        public void Log<TState>(LogLevel logLevel, 
            EventId eventId, 
            TState state, 
            Exception exception, 
            Func<TState, Exception, string> formatter)
        {
            if(formatter!=null)
            {
                lock(_lock)
                {
                    File.AppendAllText(_filePath, formatter(state, exception) 
                        + Environment.NewLine);
                }
            }
        }
    }

    public class FileLoggerProvider : ILoggerProvider
    {
        // путь к файлу логирования
        private string _filepath;
        /// <summary>
        /// Констркутор
        /// </summary>
        /// <param name="path">путь к файлу логирования</param>
        public FileLoggerProvider(string path)
        {
            _filepath = path;
        }
        public ILogger CreateLogger(string categoryName)
        {
            return new FileLogger(_filepath);
        }

        public void Dispose()
        {           
        }
        
    }

    
}
