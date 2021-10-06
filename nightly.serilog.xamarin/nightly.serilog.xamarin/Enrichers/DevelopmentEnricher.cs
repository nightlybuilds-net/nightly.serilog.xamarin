using Serilog.Core;
using Serilog.Events;

namespace nightly.serilog.xamarin.Enrichers
{
    public class DevelopmentEnricher : ILogEventEnricher
    {
        private LogEventProperty _cachedProperty;

        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            this._cachedProperty ??= propertyFactory.CreateProperty("Development",true);
            logEvent.AddPropertyIfAbsent(this._cachedProperty);
        }
    }
}