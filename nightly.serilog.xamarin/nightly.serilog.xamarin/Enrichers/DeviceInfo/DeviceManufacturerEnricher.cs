using Serilog.Core;
using Serilog.Events;

namespace nightly.serilog.xamarin.Enrichers.DeviceInfo
{
    public class DeviceManufacturerEnricher : ILogEventEnricher
    {
        private LogEventProperty _cachedProperty;

        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            this._cachedProperty ??= propertyFactory.CreateProperty("DeviceManufactorer", Xamarin.Essentials.DeviceInfo.Manufacturer);
            logEvent.AddPropertyIfAbsent(this._cachedProperty);
        }
    }
}