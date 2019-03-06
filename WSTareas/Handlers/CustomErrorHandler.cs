using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.Web;
using WSTareas.Model;
using WSTareas.Model.Context;

namespace WSTareas.Handlers
{
    public class CustomErrorHandler : IErrorHandler
    {
        IErrorHandler baseErrorHandler;
        ExceptionLogContext exceptionContext;

        public CustomErrorHandler(IErrorHandler errorHandler)
        {
            baseErrorHandler = errorHandler;
            exceptionContext = new ExceptionLogContext();
        }

        public bool HandleError(Exception error)
        {
            exceptionContext.Exceptions.Add(GenerarNuevoLog(error));
            exceptionContext.SaveChanges();

            return baseErrorHandler.HandleError(error);
        }

        public void ProvideFault(Exception error, MessageVersion version, ref Message fault)
        {
            this.baseErrorHandler.ProvideFault(error, version, ref fault);
        }

        private ExceptionLog GenerarNuevoLog(Exception error)
        {
            var log = new ExceptionLog();

            log.Mensaje = error.Message;
            log.StackTrace = error.StackTrace;

            return log;
        }
    }
}