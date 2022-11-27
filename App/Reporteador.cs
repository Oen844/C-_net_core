using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreEscuela.Entidades;
using CoreEscuela.Util;
using System.Linq;

namespace CoreEscuela
{
    public class Reporteador
    {
        Dictionary<LlavesDiccionario, IEnumerable<ObjetoEscuelaBase>> _diccionario;
        public Reporteador(Dictionary<LlavesDiccionario, IEnumerable<ObjetoEscuelaBase>> dicObjEsc)
        {
            if (dicObjEsc == null)
                throw new ArgumentNullException(nameof(dicObjEsc));
            _diccionario = dicObjEsc;
        }

        public IEnumerable<Evaluacion> GetListaEvaluaciones()
        {
            IEnumerable<Evaluacion> rta;
            if (_diccionario.TryGetValue(LlavesDiccionario.EVALUACION, out IEnumerable<ObjetoEscuelaBase> lista))
            {
                return rta = lista.Cast<Evaluacion>();
            }
            else
            {
                return new List<Evaluacion>();
            }

        }
        public IEnumerable<string> GetListaAsignaturas()
        {
            return GetListaAsignaturas(
                    out var dummy);
        }

        public IEnumerable<string> GetListaAsignaturas(
            out IEnumerable<Evaluacion> listaEvaluaciones)
        {
            listaEvaluaciones = GetListaEvaluaciones();

            return (from Evaluacion ev in listaEvaluaciones
                    select ev.Asignatura.Nombre).Distinct();
        }

        public Dictionary<string, IEnumerable<Evaluacion>> GetListaEvaluaXAsig()
        {
            var dictaRta = new Dictionary<String, IEnumerable<Evaluacion>>();
            var listaAsig = GetListaAsignaturas(out var listaEval);

            foreach (var asig in listaAsig)
            {
                var evalAsig = from eval in listaEval
                               where eval.Asignatura.Nombre == asig
                               select eval;
                dictaRta.Add(asig, evalAsig);
            }

            return dictaRta;
        }

        public Dictionary<string, IEnumerable<object>> GetPromedioAlumnoPorAsignatura()
        {
            var rta = new Dictionary<String, IEnumerable<object>>();
            var dicEvalXAsig = GetListaEvaluaXAsig();

            foreach (var asigConEval in dicEvalXAsig)
            {
                var promsAlumnos = from eval in asigConEval.Value
                                   group eval by new
                                   {                                       
                                       eval.Alumno.UniqueId,
                                       eval.Alumno.Nombre
                                   }
                                   into grupoEvalsAlumno
                                   select new 
                                   {
                                       alumnoId = grupoEvalsAlumno.Key.UniqueId,
                                       alumnoNombre = grupoEvalsAlumno.Key.Nombre,
                                       promedio = grupoEvalsAlumno.Average(evaluacion => evaluacion.Nota)
                                   };
                rta.Add(asigConEval.Key, promsAlumnos);
            }

            return rta;
        }

    }
}