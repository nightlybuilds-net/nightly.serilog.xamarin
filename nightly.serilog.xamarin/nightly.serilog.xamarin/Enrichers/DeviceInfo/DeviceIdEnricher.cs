using System;
using Serilog.Core;
using Serilog.Events;
using Xamarin.Essentials;

namespace nightly.serilog.xamarin.Enrichers.DeviceInfo
{
    public class DeviceIdEnricher : ILogEventEnricher
    {
        private LogEventProperty _cachedProperty;

        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            if (this._cachedProperty == null)
            {
                var idValue = SecureStorage.GetAsync("ENRICHER_ID").Result;
                if (idValue == null)
                {
                    idValue = Guid.NewGuid().ToString("N");
                    SecureStorage.SetAsync("ENRICHER_ID", idValue).Wait();
                }
                
                this._cachedProperty = propertyFactory.CreateProperty("DeviceId", idValue);
            }
            logEvent.AddPropertyIfAbsent(this._cachedProperty);
        }
    }
}