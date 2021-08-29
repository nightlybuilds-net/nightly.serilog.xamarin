using System;
using nightly.serilog.xamarin.Enrichers;
using nightly.serilog.xamarin.Enrichers.DeviceInfo;
using nightly.serilog.xamarin.Enrichers.Display;
using nightly.serilog.xamarin.Enrichers.Version;
using nightly.serilog.xamarin.Sinks;
using Serilog;
using Serilog.Configuration;
using Xamarin.Essentials;

namespace nightly.serilog.xamarin
{
    public static class LoggerConfigurationExtensions
    {
        /// <summary>
        /// Add Session Id
        /// </summary>
        /// <param name="enrichment"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static LoggerConfiguration WithSessionId(this LoggerEnrichmentConfiguration enrichment)
        {
            if (enrichment == null) throw new ArgumentNullException(nameof(enrichment));
            return enrichment.With<SessionIdEnricher>();
        }
        
        /// <summary>
        /// Add all Device enrichers
        /// </summary>
        /// <param name="enrichment"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static LoggerConfiguration WithDeviceInfos(this LoggerEnrichmentConfiguration enrichment)
        {
            if (enrichment == null) throw new ArgumentNullException(nameof(enrichment));
            enrichment.With<DeviceIdiomEnricher>();
            enrichment.With<DeviceManufacturerEnricher>();
            enrichment.With<DeviceModelEnricher>();
            enrichment.With<DeviceNameEnricher>();
            enrichment.With<DeviceOsVersionEnricher>();
            enrichment.With<DevicePlatformEnricher>();
            return enrichment.With<DeviceTypeEnricher>();
        }
        
        /// <summary>
        /// Add all Display enrichers
        /// </summary>
        /// <param name="enrichment"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static LoggerConfiguration WithDisplayInfos(this LoggerEnrichmentConfiguration enrichment)
        {
            if (enrichment == null) throw new ArgumentNullException(nameof(enrichment));
            enrichment.With<DisplayDensityEnricher>();
            enrichment.With<DisplayOrientationEnricher>();
            enrichment.With<DisplayRotationEnricher>();
            return enrichment.With<DisplaySizeEnricher>();
        }
        
        /// <summary>
        /// Add all Version
        /// </summary>
        /// <param name="enrichment"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static LoggerConfiguration WithAppVersionInfos(this LoggerEnrichmentConfiguration enrichment)
        {
            if (enrichment == null) throw new ArgumentNullException(nameof(enrichment));
            enrichment.With<CurrentVersionEnricher>();
            return enrichment.With<CurrentVersionBuildEnricher>();
        }
    }
    
    public static class LoggerSinkExtensions
    {
        public static LoggerConfiguration DebugConsole(
            this LoggerSinkConfiguration loggerConfiguration,
            IFormatProvider formatProvider = null)
        {
            return loggerConfiguration.Sink(new DebugConsoleSink(formatProvider));
        }
    }
}