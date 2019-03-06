using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WSTareas.Model.DataContracts
{
    [DataContract]
    public class TareaDataContract
    {
        [DataMember]
        public int? ID { get; set; }

        [DataMember]
        public string Titulo { get; set; }

        [DataMember]
        public string Descripcion { get; set; }

        [DataMember]
        public string FechaInicio { get; set; }

        [DataMember]
        public string FechaFin { get; set; }

    }
}