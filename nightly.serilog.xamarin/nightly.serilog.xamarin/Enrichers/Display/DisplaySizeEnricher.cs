using Serilog.Core;
using Serilog.Events;
using Xamarin.Essentials;

namespace nightly.serilog.xamarin.Enrichers.Display
{
    public class DisplaySizeEnricher : ILogEventEnricher
    {
        private LogEventProperty _cachedProperty;

        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            var displayInfo = DeviceDisplay.MainDisplayInfo;
            this._cachedProperty ??= propertyFactory.CreateProperty("DisplaySize",$"{displayInfo.Width} X {displayInfo.Height}");
            logEvent.AddPropertyIfAbsent(this._cachedProperty);
        }
    }
}