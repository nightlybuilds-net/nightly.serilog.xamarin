using System;
using Serilog.Core;
using Serilog.Events;
using Xamarin.Essentials;

namespace nightly.serilog.xamarin
{
    public class SessionEnricher : ILogEventEnricher
    {
        private LogEventProperty _cachedProperty;

        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            this._cachedProperty ??= propertyFactory.CreateProperty("SessionId",Guid.NewGuid().ToString("N"));
            logEvent.AddPropertyIfAbsent(this._cachedProperty);
        }
    }
}