using CoreEscuela.Entidades;
using System.Linq;

namespace CoreEscuela
{
    public sealed class EscuelaEngine
    {
        public Escuela Escuela { get; set; }

        public EscuelaEngine()
        {
            Escuela = new Escuela("Platzi Academy", 2012, TiposEscuela.Primaria,
                ciudad: "Bogotá", pais: "Colombia");
        }

        public void Inicializar()
        {
            Escuela = new Escuela("Platzi Academy", 2012, TiposEscuela.Secundaria, pais: "España", ciudad: "Madrid");

            CargaCursos(Escuela);
            cargarAsignaturas();
            cargarEvaluaciones();
        }

        public Dictionary<LlavesDiccionario, IEnumerable<ObjetoEscuelaBase>> GetDiccioonarioObjetos()
        {
            var listaTemp = new List<Evaluacion>();
            var listatempas = new List<Asignatura>();
            var listatempal = new List<Alumno>();

            var diccionario = new Dictionary<LlavesDiccionario, IEnumerable<ObjetoEscuelaBase>>();

            diccionario.Add(LlavesDiccionario.ESCUELA, new[] { Escuela });
            diccionario.Add(LlavesDiccionario.CURSO, Escuela.Cursos.Cast<ObjetoEscuelaBase>());

            foreach (var cur in Escuela.Cursos)
            {
                listatempas.AddRange(cur.Asignaturas);
                listatempal.AddRange(cur.Alumnos);


                foreach (var alum in cur.Alumnos)
                {

                    listaTemp.AddRange(alum.Evaluaciones);
                }
            }
            diccionario.Add(LlavesDiccionario.ASIGNATURA, listatempas.Cast<ObjetoEscuelaBase>());
            diccionario.Add(LlavesDiccionario.ALUMNO, listatempal.Cast<ObjetoEscuelaBase>());
            diccionario.Add(LlavesDiccionario.EVALUACION, listaTemp.Cast<ObjetoEscuelaBase>());

            return diccionario;
        }

        public IReadOnlyList<ObjetoEscuelaBase> GetObjetosEscuela(
                    bool traeEvaluaciones = true,
                    bool traeAlumnos = true,
                    bool traeAsignaturas = true,
                    bool traeCursos = true
                    )
        {
            return GetObjetosEscuela(out int dummy, out dummy, out dummy, out dummy);
        }

        public IReadOnlyList<ObjetoEscuelaBase> GetObjetosEscuela(
                    out int conteoEvaluaciones,
                    bool traeEvaluaciones = true,
                    bool traeAlumnos = true,
                    bool traeAsignaturas = true,
                    bool traeCursos = true
                    )
        {
            return GetObjetosEscuela(out conteoEvaluaciones, out int dummy, out dummy, out dummy);
        }

        public IReadOnlyList<ObjetoEscuelaBase> GetObjetosEscuela(
                    out int conteoEvaluaciones,
                    out int conteoAlumnos,
                    bool traeEvaluaciones = true,
                    bool traeAlumnos = true,
                    bool traeAsignaturas = true,
                    bool traeCursos = true
                    )
        {
            return GetObjetosEscuela(out conteoEvaluaciones, out conteoAlumnos, out int dummy, out dummy);
        }

        public IReadOnlyList<ObjetoEscuelaBase> GetObjetosEscuela(
                    out int conteoEvaluaciones,
                    out int conteoAlumnos,
                    out int conteoAsignaturas,
                    bool traeEvaluaciones = true,
                    bool traeAlumnos = true,
                    bool traeAsignaturas = true,
                    bool traeCursos = true
                    )
        {
            return GetObjetosEscuela(out conteoEvaluaciones, out conteoAlumnos, out conteoAsignaturas, out int dummy);
        }


        public IReadOnlyList<ObjetoEscuelaBase> GetObjetosEscuela(
            out int conteoEvaluaciones,
            out int conteoAlumnos,
            out int conteoAsignaturas,
            out int conteoCursos,
            bool traeEvaluaciones = true,
            bool traeAlumnos = true,
            bool traeAsignaturas = true,
            bool traeCursos = true
            )
        {
            conteoEvaluaciones = 0;
            conteoAsignaturas = 0;
            conteoAlumnos = 0;
            conteoCursos = 0;

            var listaObj = new List<ObjetoEscuelaBase>();
            listaObj.Add(Escuela);

            if (traeCursos)
            {
                listaObj.AddRange(Escuela.Cursos);
            }

            conteoCursos = Escuela.Cursos.Count;
            foreach (var curso in Escuela.Cursos)
            {
                conteoAsignaturas += curso.Asignaturas.Count;
                conteoAlumnos += curso.Alumnos.Count;

                if (traeAsignaturas)
                {
                    listaObj.AddRange(curso.Asignaturas);
                }

                if (traeAlumnos)
                {
                    listaObj.AddRange(curso.Alumnos);
                }

                if (traeEvaluaciones)
                {
                    foreach (var alumno in curso.Alumnos)
                    {
                        listaObj.AddRange(alumno.Evaluaciones);
                        conteoEvaluaciones += alumno.Evaluaciones.Count;
                    }
                }
            }

            return listaObj.AsReadOnly();
        }


        #region Métodos de Carga de Datos
        private void cargarEvaluaciones()
        {
            foreach (var curso in Escuela.Cursos)
            {
                foreach (var asignatura in curso.Asignaturas)
                {
                    foreach (var alumno in curso.Alumnos)
                    {
                        var rnd = new Random(System.Environment.TickCount);
                        for (int i = 0; i < 5; i++)
                        {
                            var ev = new Evaluacion
                            {
                                Nombre = $"{asignatura.Nombre} Ev#{i + 1}",
                                Alumno = alumno,
                                Asignatura = asignatura,
                                Nota = (float)(5 * rnd.NextDouble())
                            };
                            alumno.Evaluaciones.Add(ev);

                        }
                    }
                }
                {

                }
            }
        }

        private void cargarAsignaturas()
        {
            foreach (var curso in Escuela.Cursos)
            {
                List<Asignatura> listaAsignaturas = new List<Asignatura>(){
                    new Asignatura{Nombre = "Matemáticas"},
                    new Asignatura{Nombre = "Educación Física"},
                    new Asignatura{Nombre = "Castellano"},
                    new Asignatura{Nombre = "Ciencias Naturales"}
                };
                curso.Asignaturas = listaAsignaturas;
            }
        }

        private static List<Alumno> GenerarAlumnosAlAzar(int cantidad)
        {
            string[] nombre1 = { "Alba", "Pedro", "Juan", "Miguel", "Sofía", "Pedro", "Alfredo" };
            string[] apellido = { "García", "González", "Fernández", "López", "Martínez", "Pérez", "Gómez" };
            string[] nombre2 = { "María", "Ana", "Lucía", "Julieta", "Sara", "Camila", "Valentina" };

            var listaAlumnos = from n1 in nombre1
                               from n2 in nombre2
                               from a1 in apellido
                               select new Alumno { Nombre = $"{n1} {n2} {a1}" };

            return listaAlumnos.OrderBy((al) => al.UniqueId).Take(cantidad).ToList();

        }

        private static void CargaCursos(Escuela Escuela)
        {
            Escuela.Cursos = new List<Curso>(){
                new Curso(){Nombre = "101", Jornada = TiposJornada.Mañana},
                new Curso(){Nombre = "201", Jornada = TiposJornada.Mañana},
                new Curso(){Nombre = "301", Jornada = TiposJornada.Mañana},
                new Curso(){Nombre = "401", Jornada = TiposJornada.Tarde},
                new Curso(){Nombre = "501", Jornada = TiposJornada.Tarde}
            };
            Random rnd = new Random();
            foreach (var c in Escuela.Cursos)
            {
                int cantRandom = rnd.Next(5, 20);

                c.Alumnos = GenerarAlumnosAlAzar(cantRandom);
            }
        }
        #endregion
    }
}
