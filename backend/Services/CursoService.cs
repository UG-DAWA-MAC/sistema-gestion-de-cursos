using backend.Models;
namespace backend.Services;

public class CursoService
{
    private readonly List<Curso> _cursos = new()
    {
        new Curso
        {
            Id = 1,
            Nombre = "Desarrollo de Aplicaciones Web Avanzado",
            Docente = "Ing. Barba Salazar Joel",
            Activo = true
        },
        new Curso
        {
            Id = 2,
            Nombre = "Calidad del Software",
            Docente = "Ing. Peralta Guaraca Tania",
            Activo = true
        },
        new Curso
        {
            Id = 3,
            Nombre = "Inteligencia de Negocios",
            Docente = "Ing. Tejada Yepez Silvia",
            Activo = false
        }
    };

    public List<Curso> ObtenerTodos()
    {
        return _cursos;
    }

    public Curso? ObtenerPorId(int id)
    {
        return _cursos.FirstOrDefault(curso => curso.Id == id);
    }

    public Curso Agregar(Curso curso)
    {
        curso.Id = _cursos.Count > 0
            ? _cursos.Max(c => c.Id) + 1
            : 1;

        _cursos.Add(curso);

        return curso;
    }

    public bool Actualizar(int id, Curso cursoActualizado)
    {
        var curso = ObtenerPorId(id);

        if (curso == null)
        {
            return false;
        }

        curso.Nombre = cursoActualizado.Nombre;
        curso.Docente = cursoActualizado.Docente;
        curso.Activo = cursoActualizado.Activo;

        return true;
    }

    public bool Eliminar(int id)
    {
        var curso = ObtenerPorId(id);

        if (curso == null)
        {
            return false;
        }

        _cursos.Remove(curso);
        return true;
    }
}
