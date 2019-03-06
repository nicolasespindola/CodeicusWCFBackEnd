using System.IO;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Xml;
using WSTareas.Handlers;
using WSTareas.Model;
using WSTareas.Model.Context;

namespace WSTareas.ServiceBehaviors
{
    public class LogEndpointBehavior : WebHttpBehavior, IDispatchMessageInspector, IEndpointBehavior
    {
        public ApplicationLogContext applicationLogContext { get; set; }
        public LogEndpointBehavior()
        {
            applicationLogContext = new ApplicationLogContext();
        }

        public override void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
        {
            endpointDispatcher.DispatchRuntime.MessageInspectors.Add(this);

            
            IErrorHandler webHttpErrorHandler = endpointDispatcher.ChannelDispatcher.ErrorHandlers.FirstOrDefault();
            endpointDispatcher.ChannelDispatcher.ErrorHandlers.Remove(webHttpErrorHandler);

            endpointDispatcher.ChannelDispatcher.ErrorHandlers.Add(new CustomErrorHandler(webHttpErrorHandler));
        }

        public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
        {
            applicationLogContext.ApplicationLogs.Add(GenerarNuevoLog(ref request));

            applicationLogContext.SaveChanges();            

            return request.Headers.To;
        }

        public void BeforeSendReply(ref Message reply, object correlationState) { }

        private ApplicationLog GenerarNuevoLog(ref Message request)
        {
            var log = new ApplicationLog();

            log.URL = request.Headers.To.AbsoluteUri;
            log.Method = ((HttpRequestMessageProperty)request.Properties["httpRequest"]).Method;
            log.RequestBody = request.ToString();

            return log;
        }

        private string ReadRawBody(ref Message message)
        {
            XmlDictionaryReader bodyReader = message.GetReaderAtBodyContents();
            bodyReader.ReadStartElement("root");
            byte[] bodyBytes = bodyReader.ReadContentAsBase64();
            string messageBody = Encoding.UTF8.GetString(bodyBytes);

            // Now to recreate the message
            MemoryStream ms = new MemoryStream();
            XmlDictionaryWriter writer = XmlDictionaryWriter.CreateBinaryWriter(ms);
            writer.WriteStartElement("root");
            writer.WriteBase64(bodyBytes, 0, bodyBytes.Length);
            writer.WriteEndElement();
            writer.Flush();
            ms.Position = 0;
            XmlDictionaryReader reader = XmlDictionaryReader.CreateBinaryReader(ms, XmlDictionaryReaderQuotas.Max);
            Message newMessage = Message.CreateMessage(reader, int.MaxValue, message.Version);
            newMessage.Properties.CopyProperties(message.Properties);
            message = newMessage;

            return messageBody;
        }
    }
}