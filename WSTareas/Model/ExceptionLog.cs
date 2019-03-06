using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WSTareas.Model
{
    public class ExceptionLog
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int? ID { get; set; }

        [Required]
        public string Mensaje { get; set; }

        [Required]
        public string StackTrace { get; set; }

        [Required]
        public DateTime FechaCreacion { get; set; }

        public ExceptionLog()
        {
            FechaCreacion = DateTime.Now;
        }

        public void Update(string mensaje, string stackTrace)
        {
            this.Mensaje = mensaje;
            this.StackTrace = stackTrace;
        }
    }
}