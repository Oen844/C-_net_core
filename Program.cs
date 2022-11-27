// See https://aka.ms/new-console-template for more information
using CoreEscuela.Entidades;
using CoreEscuela;
using CoreEscuela.Util;
//using CoreEscuela.App;
using static System.Console;


AppDomain.CurrentDomain.ProcessExit += AccionDelEvento;


var engine = new EscuelaEngine();
engine.Inicializar();


Printer.DrawLine(20);
Printer.Writetitle("Bienvenidos a la escuela");

var reporteador = new Reporteador(engine.GetDiccioonarioObjetos());

reporteador.GetListaEvaluaciones();


// ImprimirCursosEscuela(engine.Escuela);
// var listaObjetos = engine.GetObjetosEscuela(
//     out int conteoEvaluaciones,
//     out int conteoAlumnos,
//     out int conteoAsignaturas,
//     out int conteoCursos
//     );

// var dictmb = engine.GetDiccioonarioObjetos();
// engine.imprimirDiccionario(dictmb, true);

// var listaIlugar = from obj in listaObjetos
//                   where obj is iLugar
//                   select (iLugar)obj;

//ZeldaSong();
// Printer.DrawLine(20);
// Printer.Writetitle("Prueba de polimorfismo");

// var alumnoTest = new Alumno {Nombre = "Claire Underwood"};
// ObjetoEscuelaBase ob = alumnoTest;

// Printer.Writetitle("Alumno");
// Console.WriteLine($"Alumno: {alumnoTest.Nombre}");
// Console.WriteLine($"Alumno: {alumnoTest.UniqueId}");
// Console.WriteLine($"Alumno: {alumnoTest.GetType()}");


// Printer.Writetitle("ObjetoEscuela");
// Console.WriteLine($"Obj: {ob.Nombre}");
// Console.WriteLine($"Obj: {ob.UniqueId}");
// Console.WriteLine($"Obj: {ob.GetType()}");



//engine.Escuela.LimpiarLugar();

// if( ob is Alumno)
// {
//     var alumnoRecuperado = (Alumno)ob;
//     Console.WriteLine($"alumnoRecuperado: {alumnoRecuperado.Nombre}");
// }

// Alumno alumnoRecuperado2 = ob as Alumno;
// if(alumnoRecuperado2 != null)
// {
//     Console.WriteLine($"alumnoRecuperado2: {alumnoRecuperado2.Nombre}");
// }







//********************************************************************************

void AccionDelEvento(object? sender, EventArgs e)
{
    Printer.Writetitle("Saliendo");
    //Printer.Beep(2000, cantidad: 10);
    ZeldaSong();
}



static bool Predicado(Curso curobj)
{
    return curobj.Nombre == "301";
}

static void ImprimirCursos(Curso[] arregloCursos)
{
    int contador = 0;
    while (contador < arregloCursos.Length)
    {
        Console.WriteLine($"Nombre {arregloCursos[contador].Nombre}, Id {arregloCursos[contador].UniqueId}");
        contador++;
    }
}

static void ImprimirCursosWhileDo(Curso[] arregloCursos)
{
    int contador = 0;
    do
    {
        Console.WriteLine($"Nombre {arregloCursos[contador].Nombre}, Id {arregloCursos[contador].UniqueId}");
        contador++;
    } while (contador < arregloCursos.Length);
}

static void ImprimirCursosForEach(Curso[] arregloCursos)
{
    foreach (var curso in arregloCursos)
    {
        Console.WriteLine($"Nombre {curso.Nombre}, Id {curso.UniqueId}");
    }
}

static void ImprimirCursosEscuela(Escuela escuela)
{
    Printer.Writetitle("Cursos de la escuela");
    if (escuela?.Cursos != null)
    {
        foreach (var curso in escuela.Cursos)
        {
            Console.WriteLine($"Nombre {curso.Nombre}, Id {curso.UniqueId}");
        }
    }
}

static void Beep(int hz = 2000, int tiempo = 500, int cantidad = 1)
{
    while (cantidad-- > 0)
    {
        Console.Beep(hz, tiempo);
    }
}

static void ZeldaSong(bool timbre = false)
{
    //Zelda song
    Console.Beep(987, 1000); //Si
    Console.Beep(1174, 500); //Re'
    Console.Beep(880, 1500); //La

    Console.Beep(783, 250); //Sol
    Console.Beep(880, 250); //La
    Console.Beep(987, 1000); //Si

    Console.Beep(1174, 500); //Re'
    Console.Beep(880, 1500); //La

    Console.Beep(987, 1000); //Si
    Console.Beep(1174, 500); //Re'
    Console.Beep(1760, 1000); //La'
    Console.Beep(1567, 500); //Sol'
    Console.Beep(1174, 1000); //Re'

    Console.Beep(1046, 250); //Do
    Console.Beep(987, 250); //Si
    Console.Beep(880, 1000); //La
    if (timbre == false)
    {
        timbre = true;
        ZeldaSong(true);
    }


}