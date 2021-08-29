using Serilog.Core;
using Serilog.Events;

namespace nightly.serilog.xamarin.enrichers.DeviceInfo
{
    public class DevicePlatformEnricher : ILogEventEnricher
    {
        private LogEventProperty _cachedProperty;

        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            this._cachedProperty ??= propertyFactory.CreateProperty("DevicePlatform", Xamarin.Essentials.DeviceInfo.Platform);
            logEvent.AddPropertyIfAbsent(this._cachedProperty);
        }
    }
}