using CoreEscuela.Util;

namespace CoreEscuela.Entidades
{
    public class Escuela : ObjetoEscuelaBase, iLugar
    {
        public int AñoDeCreación { get; set; }

        public string Pais { get; set; }

        public string Ciudad { get; set; }

        public string Dirección { get; set; }



        public TiposEscuela TipoEscuela { get; set; }
        public List<Curso> Cursos { get; set; }


        public Escuela(string nombre, int año) => (Nombre, AñoDeCreación) = (nombre, año);

        public Escuela(string nombre, int año, TiposEscuela tipo, string pais = "", string ciudad = "")
        {
            (Nombre, AñoDeCreación) = (nombre, año);
            Pais = pais;
            Ciudad = ciudad;
        }

        public override string ToString()
        {
            return $"Nombre: \"{Nombre}\", Tipo: {TipoEscuela} , {System.Environment.NewLine}Pais: {Pais}, Ciudad: {Ciudad}";
        }

        public void LimpiarLugar()
        {
            Printer.DrawLine();
            System.Console.WriteLine("Limpiando Escuela...");
            
            foreach (var curso in Cursos)
            {
                curso.LimpiarLugar();
            }
            Printer.Writetitle($"Escuela {Nombre} Limpia");
            Printer.Beep(1000, cantidad: 3);
        }
    }
}
