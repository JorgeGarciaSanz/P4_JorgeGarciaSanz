using System;
using UnityEngine;

public class ClaseProgramacion1 : MonoBehaviour
{
    // [modificador] tipoDelDato nombreDelCampo;
    public int testInt; // 0

     // [modificador] tipoDelDato nombreDeLaPropiedad { get; set; }
     public int testIntProperty { get; set; } // 0

     // [modificador] tipoqueDevuelve nombreDelMetodo (parametros)
     public int getTestInt()
    {
        return testInt;
    }


    
}

class Persona
{
    //campos
    private string dni;
    public DateTime FechaNacimiento;

    //propiedades
    public string Nombre { get; set; }

    //metodos

    public Persona (){}

    public Persona (string nombre)
    {
        Nombre = nombre;
    }

    public Persona (DateTime fechaNacimiento)
    {
        FechaNacimiento = fechaNacimiento;
    }
    
    public void Saludar()
    {
        Console.WriteLine("Hola, soy " + Nombre);
    }

    void main()
    {
        Persona jorge = new Persona();
        jorge.Nombre = "Jorge";
        jorge.FechaNacimiento =  DateTime.Now;
    }

}

//----------------

public class ClaseBase
{
    //miembros de la clase base
}

public class ClaseDerivada : ClaseBase
{
    //miembros de la clase derivada
}   

public class Animal
{
    protected void Comer()
    {
        Console.WriteLine("El animal está comiendo.");
    }

    protected virtual void Hablar()
    {
        Console.WriteLine("El animal está hablando.");
    }
}

public class Perro : Animal
{
    protected override void Hablar()
    {
        Console.WriteLine("El perro dice: ¡Guau!");
    }

    public void main()
    {
        Animal animal = new Animal();

        Perro miPerro = new Perro();
        miPerro.Comer(); // Método heredado de la clase Animal
        miPerro.Hablar(); // Método específico de la clase Perro

        
    }
}
