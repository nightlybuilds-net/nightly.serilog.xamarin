using Serilog.Core;
using Serilog.Events;

namespace nightly.serilog.xamarin.enrichers.DeviceInfo
{
    public class DeviceIdiomEnricher : ILogEventEnricher
    {
        private LogEventProperty _cachedProperty;

        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            this._cachedProperty ??= propertyFactory.CreateProperty("DeviceIdiom", Xamarin.Essentials.DeviceInfo.Idiom);
            logEvent.AddPropertyIfAbsent(this._cachedProperty);
        }
    }
}