using Serilog.Core;
using Serilog.Events;

namespace nightly.serilog.xamarin.Enrichers.DeviceInfo
{
    public class DeviceNameEnricher : ILogEventEnricher
    {
        private LogEventProperty _cachedProperty;

        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            this._cachedProperty ??= propertyFactory.CreateProperty("DeviceName", Xamarin.Essentials.DeviceInfo.Name);
            logEvent.AddPropertyIfAbsent(this._cachedProperty);
        }
    }
}