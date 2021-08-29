using Serilog.Core;
using Serilog.Events;
using Xamarin.Essentials;

namespace nightly.serilog.xamarin.Enrichers.Version
{
    public class CurrentVersionEnricher : ILogEventEnricher
    {
        private LogEventProperty _cachedProperty;

        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            this._cachedProperty ??= propertyFactory.CreateProperty("AppVersion", VersionTracking.CurrentVersion);
            logEvent.AddPropertyIfAbsent(this._cachedProperty);
        }
    }
}