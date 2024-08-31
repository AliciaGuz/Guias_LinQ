using System;
using System.Collections.Generic;
using System.Linq;

#region Introduccion
using LinQ;

string[] palabras; 
palabras = new string[] {"gato", 
    "perro", 
    "Lagarto", 
    "Tortuga",
    "Cocodrilo",
    "Serpiente"
};
Console.WriteLine("Mas de 5 palabras");

List<string> resultado = new List<string>();

foreach (string r in palabras)
{
    if (r.Length > 5)
    {
        resultado.Add(r);
    }
}
Console.WriteLine("------------------------------------------------");
foreach (string rList in resultado)
    Console.WriteLine(rList);
#endregion 

#region Linq
Console.WriteLine("----------------------------");
IEnumerable<string> list = from rList in palabras where rList.Length > 8 select rList;
foreach (var listado in list)
    Console.WriteLine(listado);
#endregion

Console.WriteLine("---------------------------------");

#region ListaModelos
List<Casa> ListaCasa = new List<Casa>();
List<Habitante> ListaHabitantes = new List<Habitante>();
#endregion

#region ListaCasa
ListaCasa.Add(new Casa
{
    Id = 1,
    Direccion = "3 av Norte ArcanCity",
    Ciudad = "Gothan City",
    numeroHabitaciones = 20,
});

ListaCasa.Add(new Casa
{
    Id = 2,
    Direccion = "6 av Sur smollville",
    Ciudad = "Gothan City",
    numeroHabitaciones = 5,
}); ; ;

ListaCasa.Add(new Casa
{
    Id = 3,
    Direccion = "Forest Hills, Queens, NY 11375",
    Ciudad = "New York"
});
#endregion

#region ListaHabitante
ListaHabitantes.Add(new Habitante
{
    IdHabitante = 1,
    Nombre = "Bruno Diaz",
    edad = 36,
    idCasa = 1
});
ListaHabitantes.Add(new Habitante
{
    IdHabitante = 2,
    Nombre = "Clark Kent.",
    edad = 40,
    idCasa = 2
});
ListaHabitantes.Add(new Habitante
{
    IdHabitante = 3,
    Nombre = "Peter Parker",
    edad = 25,
    idCasa = 3
});
ListaHabitantes.Add(new Habitante
{
    IdHabitante = 4,
    Nombre = "Tia Mey",
    edad = 81,
    idCasa = 3
});
ListaHabitantes.Add(new Habitante
{
    IdHabitante = 5,
    Nombre = "Luise Lain",
    edad = 40,
    idCasa = 2
});
ListaHabitantes.Add(new Habitante
{
    IdHabitante = 6,
    Nombre = "Selina Kyle",
    edad = 30,
    idCasa = 1
});
ListaHabitantes.Add(new Habitante
{
    IdHabitante = 7,
    Nombre = "Alfred",
    edad = 50,
    idCasa = 1
});
ListaHabitantes.Add(new Habitante
{
    IdHabitante = 8,
    Nombre = "Nathan Drake",
    edad = 36,
    idCasa = 1
});
#endregion

#region SentenciasLinQ
IEnumerable<Habitante> ListaEdad = from ObjetoProvicional
                                   in ListaHabitantes
                                   where ObjetoProvicional.edad > 40
                                   select ObjetoProvicional;

foreach (Habitante objetoProcicional2 in ListaEdad)
{
    Console.WriteLine(objetoProcicional2.datosHabitante());
}

IEnumerable<Habitante> listaCasaGothan = from objetoTemporalHabitante in ListaHabitantes
                                         join objetoTemporalCasa in ListaCasa
                                         on objetoTemporalHabitante.IdHabitante equals objetoTemporalCasa.Id
                                         where objetoTemporalCasa.Ciudad == "Gothan City"
                                         select objetoTemporalHabitante;
Console.WriteLine("----------------------------------------------------------------------------------------------");
foreach (Habitante h in listaCasaGothan)
{
    Console.WriteLine(h.datosHabitante());
}

#endregion

#region FirsthAndFirsthOrDefault
/* Console.WriteLine("----------------------------------------------------------------------------------------------");
var primeraCasa = ListaCasas.First(); //esto no es linQ es  una fucnin de los Ienumarable
Console.WriteLine(primeraCasa.dameDatosCasa());

//aplicando una restriccion sin restricion lambda
Habitante personaEdad = (from variableTemporalHabitante in ListaHabitantes where variableTemporalHabitante.Edad > 25 select variableTemporalHabitante).First();
Console.WriteLine(personaEdad.datosHabitante());
Console.WriteLine("---------------------------Lo mismo pero con lambdas---------------------------------------------------------");
var Habitante1 = ListaHabitantes.First(objectTemp => objectTemp.Edad >25);
Console.WriteLine(Habitante1.datosHabitante());

// Si no tenemos el elemento que buscamos entoences la sonsulta devolvera una exepcion esto detendra el codigo en su totalidad

//Casa EdadError = (from vCasaTemp in ListaCasas where vCasaTemp.Id >10 select vCasaTemp).First() ;
//Console.WriteLine(EdadError.dameDatosCasa());

Casa CasaConFirsthOrDedault = ListaCasas.FirstOrDefault(vCasa => vCasa.Id > 200);
if (CasaConFirsthOrDedault == null ) {
    Console.WriteLine("No existe !No hay!");
    return;
}
Console.WriteLine("existe !Si existe!");
*/
#endregion

#region Last
Casa ultimaCasa = ListaCasa.Last(temp => temp.Id>1);
Console.WriteLine(ultimaCasa.dameDatosCasa());
Console.WriteLine("______________________________________________");
var h1 = (from objHabitante in ListaHabitantes where objHabitante.edad>60 select objHabitante)
    .LastOrDefault();
if (h1 == null)
{
    Console.WriteLine("Hubó un falló");
    return;
}
Console.WriteLine(h1.datosHabitante());

#endregion

#region ElementAT
var terceraCasa = ListaCasa.ElementAt(2);
Console.WriteLine($"La tercera casa es {terceraCasa.dameDatosCasa()}");

var casaError = ListaCasa.ElementAtOrDefault(3);
if (casaError != null) { Console.WriteLine($"La tercera casa es {casaError.dameDatosCasa()}"); }

var segundoHabitante = (from objetoTem in ListaHabitantes select objetoTem).ElementAtOrDefault(2);
Console.WriteLine($" Segundo habitante es : {segundoHabitante.datosHabitante()}");
#endregion

#region single
try
{
    var habitantes = ListaHabitantes.Single(variableTem => variableTem.edad > 40 && variableTem.edad < 70);
    var habitante2 = (from obtem in ListaHabitantes where obtem.edad > 70 select obtem).SingleOrDefault();

    Console.WriteLine($"habitante menor de 20 años {habitantes.datosHabitante()}");
    if (habitante2 != null) Console.WriteLine($"habitante mayor de 70 años {habitante2.datosHabitante()}");
}
catch (Exception)
{
    Console.WriteLine($"Ocurrio el error");
}

#endregion

#region typeOf
var listaEmpleados = new List<Empleado>() {
    new Bombero(){ nombre = "Juanito Pascal" },
    new Profesor(){ nombre = "Raul Blanco"}
};

var profesor = listaEmpleados.OfType<Profesor>();
Console.WriteLine(profesor.Single().nombre);

#endregion


