using TallerDesarrollo.config;
using TallerDesarrollo.models;

namespace TallerDesarrollo.services;

public class EmpresaService
    {
        private readonly AppDbContext _context;

        public EmpresaService()
        {
            _context = new AppDbContext();
        }

        public void CreateEmpresa(string nombre)
        {
            try
            {
                var findEmpresa = _context.Empresas.Find(nombre);
                
                if (findEmpresa != null)
                {
                    Console.WriteLine("La empresa ya existe.");
                    return;
                }
                
                var empresa = new Empresa { Nombre = nombre };
                _context.Empresas.Add(empresa);
                _context.SaveChanges();
                Console.WriteLine("Empresa creada con éxito.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear la empresa: {ex.Message}");
            }
        }

        public List<Empresa> ReadEmpresas()
        {
            return _context.Empresas.ToList();
        }

        public void UpdateEmpresa(int codigo, string nuevoNombre)
        {
            try
            {
                var empresa = _context.Empresas.Find(codigo);
                if (empresa != null)
                {
                    empresa.Nombre = nuevoNombre;
                    _context.SaveChanges();
                    Console.WriteLine("Empresa actualizada con éxito.");
                }
                else
                {
                    Console.WriteLine("Empresa no encontrada.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al actualizar la empresa: {ex.Message}");
            }
        }

        public void DeleteEmpresa(int codigo)
        {
            try
            {
                var empresa = _context.Empresas.Find(codigo);
                if (empresa != null)
                {
                    _context.Empresas.Remove(empresa);
                    _context.SaveChanges();
                    Console.WriteLine("Empresa eliminada con éxito.");
                }
                else
                {
                    Console.WriteLine("Empresa no encontrada.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar la empresa: {ex.Message}");
            }
        }
    }