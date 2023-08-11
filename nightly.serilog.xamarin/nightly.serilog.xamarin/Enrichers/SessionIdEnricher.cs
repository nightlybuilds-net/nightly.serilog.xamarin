using System;
using Serilog.Core;
using Serilog.Events;

namespace nightly.serilog.xamarin.Enrichers
{
    public class SessionIdEnricher : ILogEventEnricher
    {
        private LogEventProperty _cachedProperty;
        private readonly string _sessionId;

        public SessionIdEnricher(string sessionId = null)
        {
            this._sessionId = sessionId ?? Guid.NewGuid().ToString("N");
        }

        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            this._cachedProperty ??= propertyFactory.CreateProperty("SessionId",this._sessionId);
            logEvent.AddPropertyIfAbsent(this._cachedProperty);
        }
    }
}