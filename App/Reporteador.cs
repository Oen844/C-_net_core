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
            if(dicObjEsc == null)
                throw new ArgumentNullException(nameof(dicObjEsc));
            _diccionario = dicObjEsc;
        }

        public IEnumerable<Escuela> GetListaEvaluaciones()
        {
            IEnumerable<Escuela> rta;
            if(_diccionario.TryGetValue(LlavesDiccionario.ESCUELA, out IEnumerable<ObjetoEscuelaBase> lista))
            {
                rta = lista.Cast<Escuela>();
            }
            else
            {
                rta = null;
            }
            

            return rta;

        }
        
    }
}