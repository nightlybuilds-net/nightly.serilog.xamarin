using System;
using Serilog.Core;
using Serilog.Events;

namespace nightly.serilog.xamarin.Enrichers
{
    public class UserNameEnricher : ILogEventEnricher
    {
        private readonly Func<string> _usernameFunc;

        public UserNameEnricher(Func<string> usernameFunc)
        {
            this._usernameFunc = usernameFunc;
        }

        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            var property = propertyFactory.CreateProperty("UserName",this._usernameFunc.Invoke());
            logEvent.AddPropertyIfAbsent(property);
        }
    }
}