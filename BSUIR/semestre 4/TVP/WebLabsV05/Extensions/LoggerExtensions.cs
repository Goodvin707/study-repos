using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebLabsV05.Services;

namespace WebLabsV05.Extensions
{
    public static class LoggerExtensions
    {        public static ILoggerFactory AddFileLogger(this ILoggerFactory factory, string path)
        {
            factory.AddProvider(new FileLoggerProvider(path));
            return factory;
        }

        public static ILoggingBuilder AddFileLogger(this ILoggingBuilder builder, string path)
        {
            builder.AddProvider(new FileLoggerProvider(path));
            return builder;
        }
    }
}
