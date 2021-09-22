using System;
using Serilog.Core;
using Serilog.Events;

namespace nightly.serilog.xamarin.Enrichers
{
    public class SessionIdEnricher : ILogEventEnricher
    {
        private LogEventProperty _cachedProperty;

        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            this._cachedProperty ??= propertyFactory.CreateProperty("SessionId",Guid.NewGuid().ToString("N"));
            logEvent.AddPropertyIfAbsent(this._cachedProperty);
        }
    }
}