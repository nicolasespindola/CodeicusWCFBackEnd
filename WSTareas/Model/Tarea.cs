using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WSTareas.Model
{
    public class Tarea
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int? ID { get; set; }

        [Required]
        public string Titulo { get; set; }

        [Required]
        public string Descripcion { get; set; }

        [Required]
        public DateTime FechaInicio { get; set; }

        [Required]
        public DateTime FechaFin { get; set; }


        public void Update(string titulo, string descripcion, DateTime fechaInicio, DateTime fechaFin)
        {
            this.Titulo = titulo;
            this.Descripcion = descripcion;
            this.FechaInicio = fechaInicio;
            this.FechaFin = fechaFin;
        }
    }
}