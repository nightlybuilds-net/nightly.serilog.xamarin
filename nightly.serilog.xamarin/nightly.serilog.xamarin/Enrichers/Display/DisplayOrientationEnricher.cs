using Serilog.Core;
using Serilog.Events;
using Xamarin.Essentials;

namespace nightly.serilog.xamarin.Enrichers.Display
{
    public class DisplayOrientationEnricher : ILogEventEnricher
    {
        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            var displayInfo = DeviceDisplay.MainDisplayInfo;
            var orientation = propertyFactory.CreateProperty("DisplayOrientation",displayInfo.Orientation);
            logEvent.AddPropertyIfAbsent(orientation);
        }
    }
}