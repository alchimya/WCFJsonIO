/// <summary> 
/// I "borrowed" this class from
/// http://www.productiverage.com/wcf-cors-plus-json-rest-complete-example
/// It allows to enable CORS on your server
/// See Web.config behaviorExtensions
/// </summary> 
namespace WCFJsonIO.Security.CORS
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.ServiceModel;
    using System.ServiceModel.Channels;
    using System.ServiceModel.Configuration;
    using System.ServiceModel.Description;
    using System.ServiceModel.Dispatcher;
    using System.Web;


    public class CORSEnablingBehavior
        : BehaviorExtensionElement, IEndpointBehavior
    {
        public void AddBindingParameters(
          ServiceEndpoint endpoint,
          BindingParameterCollection bindingParameters) { }

        public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime) { }

        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
        {
            endpointDispatcher.DispatchRuntime.MessageInspectors.Add(
              new CORSHeaderInjectingMessageInspector()
            );
        }

        public void Validate(ServiceEndpoint endpoint) { }

        public override Type BehaviorType { get { return typeof(CORSEnablingBehavior); } }

        protected override object CreateBehavior() { return new CORSEnablingBehavior(); }


        private class CORSHeaderInjectingMessageInspector : IDispatchMessageInspector
        {
            public object AfterReceiveRequest(
              ref Message request,
              IClientChannel channel,
              InstanceContext instanceContext)
            {
                return null;
            }

            private static IDictionary<string, string> _headersToInject = new Dictionary<string, string>{
            { "Access-Control-Allow-Origin", "*" },
            { "Access-Control-Request-Method", "POST,GET,PUT,DELETE,OPTIONS" },
            { "Access-Control-Allow-Headers", "X-Requested-With,Content-Type" },
            {"Cache-Control", "no-cache"},
            {"Access-Control-Max-Age", "1728000"}

          };

            public void BeforeSendReply(ref Message reply, object correlationState)
            {
                var httpHeader = reply.Properties["httpResponse"] as HttpResponseMessageProperty;
                foreach (var item in _headersToInject)
                    httpHeader.Headers.Add(item.Key, item.Value);
            }
        }

    }
}