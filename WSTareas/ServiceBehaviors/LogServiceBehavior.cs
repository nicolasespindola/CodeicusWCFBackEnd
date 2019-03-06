using System;
using System.Collections.ObjectModel;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;

namespace WSTareas.ServiceBehaviors
{
    [AttributeUsage(AttributeTargets.Class)]
    public class LogServiceBehavior : Attribute, IServiceBehavior
    {
        public void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, Collection<ServiceEndpoint> endpoints, BindingParameterCollection bindingParameters)
        {
            Console.WriteLine("AddBindingParameters");
        }

        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            foreach(var endpoint in serviceDescription.Endpoints)
            {
                endpoint.EndpointBehaviors.Add(new LogEndpointBehavior());
            }
            Console.WriteLine("ApplyDispatchBehavior");
        }

        public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            Console.WriteLine("Validate");
        }
    }
}