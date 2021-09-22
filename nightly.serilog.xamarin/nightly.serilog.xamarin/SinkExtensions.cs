using System;
using nightly.serilog.xamarin.Sinks;
using Serilog;
using Serilog.Configuration;

namespace nightly.serilog.xamarin
{
    public static class SinkExtensions
    {
        public static LoggerConfiguration DebugConsole(
            this LoggerSinkConfiguration loggerConfiguration,
            IFormatProvider formatProvider = null)
        {
            return loggerConfiguration.Sink(new DebugConsoleSink(formatProvider));
        }
    }
}