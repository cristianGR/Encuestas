using System;
using System.Collections.Generic;
using System.Text;

namespace Encuestas
{
    class Encuesta
    {
        public string Nombre { get; set; }
        public DateTime Cumpleaños { get; set; }
        public string EquipoFavorito { get; set; }

        public override string ToString()
        {
            return $"{Nombre}|{Cumpleaños}|{EquipoFavorito}";
        } 

    }
}
