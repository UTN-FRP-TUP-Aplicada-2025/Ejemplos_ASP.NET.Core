using Personas.Models;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text.Json.Serialization;

namespace Personas.Services;

public class PersonasRepository
{

    List<Persona> personas = new()
    {
        new Persona{Id=1, DNI=23434434, Nombre="Daniela" }
    };

    public IEnumerable<Persona> List()
    {
        return personas;
    }

    public Persona Get(int id)
    {
        return (from p in personas where id==p.Id select p).FirstOrDefault();
    }

    public int Save(Persona nueva)
    {
        if (nueva.Id == 0)
        {
            nueva.Id = GenId();
            personas.Add(nueva);
        }
        else
        {
            Persona p = Get(nueva.Id);
            p.DNI= nueva.DNI;
            p.Nombre=nueva.Nombre;
        }
        return nueva.Id;
    }
    public int Delete(Persona persona)
    {
        return 0;
    }

    public int GenId()
    {
        return (from f in personas select f.Id).Max() + 1;
    }
}
