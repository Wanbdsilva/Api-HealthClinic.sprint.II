using Microsoft.EntityFrameworkCore;
using Web.Api.Health_Clinic.Contexts;
using Web.Api.Health_Clinic.Domains;
using Web.Api.Health_Clinic.Interfaces;

namespace Web.Api.Health_Clinic.Repositories
{
    public class ClinicaRepository : IClinicaRepository
    {
        private readonly HealtContext _clinica;

        public ClinicaRepository()
        {
            _clinica = new HealtContext();
        }
        public void Atualizar(Guid id, Clinica clinica)
        {
            try
            {
                Clinica clinicaBuscada = _clinica.Clinica.Find(id)!;

                if (clinicaBuscada != null)
                {
                    clinicaBuscada.CNPJ = clinica.CNPJ;
                    clinicaBuscada.Endereco = clinica.Endereco;
                    clinicaBuscada.NomeFantasia = clinica.NomeFantasia;
                }

                _clinica.Clinica.Update(clinicaBuscada!);

                _clinica.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Clinica BuscarPorId(Guid id)
        {
            try
            {
                return _clinica.Clinica.Find(id)!;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Cadastrar(Clinica clinica)
        {
            try
            {
                _clinica.Clinica.Add(clinica);

                _clinica.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            };
        }

        public void Deletar(Guid id)
        {
            try
            {
                Clinica clinicaBuscada = _clinica.Clinica.Find(id)!;

                if (clinicaBuscada != null)
                {
                    _clinica.Clinica.Remove(clinicaBuscada);
                }

                _clinica.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Clinica> Listar()
        {
            try
            {
                return _clinica.Clinica.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
