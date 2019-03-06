using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WSTareas.Model;
using WSTareas.Model.DataContracts;

namespace WSTareas
{
    [ServiceContract]
    public interface ITareasService
    {

        [OperationContract]
        [WebGet(UriTemplate = "/Tareas/", ResponseFormat = WebMessageFormat.Json)]
        IEnumerable<Tarea> GetTareas();

        [OperationContract]
        [WebGet(UriTemplate = "/Tareas/{id}", ResponseFormat = WebMessageFormat.Json)]
        Tarea GetTareaByID(string id);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/Tareas/", RequestFormat = WebMessageFormat.Json)]
        void AddTarea(TareaDataContract tarea);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "/Tareas/", RequestFormat = WebMessageFormat.Json)]
        void UpdateTarea(TareaDataContract tarea);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "/Tareas/{id}", RequestFormat = WebMessageFormat.Json)]
        void DeleteTarea(string id);
    }
}
