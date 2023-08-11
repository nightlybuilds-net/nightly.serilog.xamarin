using System;
using Serilog.Core;
using Serilog.Events;

namespace nightly.serilog.xamarin.Sinks
{
    /// <summary>
    /// Write message on Console.Writeline
    /// Only when build in DEBUG
    /// </summary>
    public class DebugConsoleSink : ILogEventSink
    {
        private readonly IFormatProvider _formatProvider;
        private readonly bool _enabled;

        public DebugConsoleSink(IFormatProvider formatProvider, bool enabled)
        {
            this._formatProvider = formatProvider;
            _enabled = enabled;
        }

        public void Emit(LogEvent logEvent)
        {
            if (!this._enabled) return;
            this.SetConsoleColor(logEvent);
            var message = logEvent.RenderMessage(_formatProvider);
            Console.WriteLine(DateTimeOffset.Now + " "  + message);
            Console.ResetColor();
        }

        private void SetConsoleColor(LogEvent logEvent)
        {
            Console.ForegroundColor = logEvent.Level switch
            {
                LogEventLevel.Warning => ConsoleColor.Yellow,
                LogEventLevel.Error => ConsoleColor.Red,
                LogEventLevel.Fatal => ConsoleColor.Red,
                LogEventLevel.Information => ConsoleColor.DarkGreen,
                _ => Console.ForegroundColor
            };
        }
    }
}