using System;
using System.Collections.Generic;
using System.Linq;
using WSTareas.Model;
using WSTareas.Model.Context;
using WSTareas.Model.DataContracts;
using WSTareas.ServiceBehaviors;

namespace WSTareas
{
    [LogServiceBehavior]
    public class TareasService : ITareasService
    {
        public IEnumerable<Tarea> GetTareas()
        {
            var context = new TareaContext();

            return context.Tareas.ToList();
        }

        public Tarea GetTareaByID(string id)
        {
            var context = new TareaContext();

            int idNumber = Convert.ToInt32(id);

            return context.Tareas.First(tarea => tarea.ID == idNumber);
        }

        public void AddTarea(TareaDataContract tarea)
        {
            var context = new TareaContext();

            var nuevaTarea = new Tarea();

            nuevaTarea = MapTareaToEntity(nuevaTarea, tarea);

            context.Tareas.Add(nuevaTarea);

            context.SaveChanges();
        }

        public void DeleteTarea(string id)
        {
            var context = new TareaContext();

            int idNumber = Convert.ToInt32(id);

            Tarea tarea = context.Tareas.First(t => t.ID == idNumber);

            context.Tareas.Remove(tarea);

            context.SaveChanges();
        }
        
        public void UpdateTarea(TareaDataContract tarea)
        {
            var context = new TareaContext();

            Tarea existingTarea = context.Tareas.First(t => t.ID == tarea.ID);

            existingTarea = MapTareaToEntity(existingTarea, tarea);

            context.SaveChanges();
        }
        private Tarea MapTareaToEntity(Tarea nuevaTarea, TareaDataContract tarea)
        {
            nuevaTarea.Update(tarea.Titulo, tarea.Descripcion, DateTime.ParseExact(tarea.FechaInicio, "d", null), DateTime.ParseExact(tarea.FechaFin, "d", null));
            return nuevaTarea;
        }
    }
}
