using Serilog.Core;
using Serilog.Events;

namespace nightly.serilog.xamarin.Enrichers
{
    public class DevelopmentEnricher : ILogEventEnricher
    {
        private readonly bool _isDevelopment;
        private LogEventProperty _cachedProperty;

        public DevelopmentEnricher(bool isDevelopment)
        {
            this._isDevelopment = isDevelopment;
        }

        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            this._cachedProperty ??= propertyFactory.CreateProperty("Development",_isDevelopment);
            logEvent.AddPropertyIfAbsent(this._cachedProperty);
        }
    }
}