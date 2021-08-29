using Serilog.Core;
using Serilog.Events;

namespace nightly.serilog.xamarin.enrichers.DeviceInfo
{
    public class DeviceTypeEnricher : ILogEventEnricher
    {
        private LogEventProperty _cachedProperty;

        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            this._cachedProperty ??= propertyFactory.CreateProperty("DeviceType", Xamarin.Essentials.DeviceInfo.DeviceType);
            logEvent.AddPropertyIfAbsent(this._cachedProperty);
        }
    }
}