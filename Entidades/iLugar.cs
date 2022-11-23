using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreEscuela.Entidades
{
    public interface iLugar
    {

        public string Dirección { get; set; }

        void LimpiarLugar();
        
    }
}