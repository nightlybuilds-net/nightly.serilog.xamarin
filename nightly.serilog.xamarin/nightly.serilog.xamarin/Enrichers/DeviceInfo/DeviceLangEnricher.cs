using System.Globalization;
using Serilog.Core;
using Serilog.Events;

namespace nightly.serilog.xamarin.Enrichers.DeviceInfo
{
    public class DeviceLangEnricher : ILogEventEnricher
    {
        private LogEventProperty _cachedProperty;

        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            this._cachedProperty ??= propertyFactory.CreateProperty("DeviceLang", CultureInfo.CurrentCulture.TwoLetterISOLanguageName);
            logEvent.AddPropertyIfAbsent(this._cachedProperty);
        }
    }
}