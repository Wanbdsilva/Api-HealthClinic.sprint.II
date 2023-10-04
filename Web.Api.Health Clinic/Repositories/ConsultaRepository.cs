using Microsoft.EntityFrameworkCore;
using Web.Api.Health_Clinic.Contexts;
using Web.Api.Health_Clinic.Domains;
using Web.Api.Health_Clinic.Interfaces;

namespace Web.Api.Health_Clinic.Repositories
{
    public class ConsultaRepository : IConsultaRepository
    {
        private readonly HealtContext _consulta;

        public ConsultaRepository()
        {
            _consulta = new HealtContext();
        }
        public void Atualizar(Guid id, Consulta consulta)
        {
            try
            {
                Consulta consultaBuscada = _consulta.Consulta.Find(id)!;

                if (consultaBuscada != null)
                {
                    consultaBuscada.DataConsulta = consulta.DataConsulta;
                    consultaBuscada.Paciente = consulta.Paciente;
                    consultaBuscada.IdConsulta = consulta.IdConsulta;
                }

                _consulta.Consulta.Update(consultaBuscada!);

                _consulta.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Consulta BuscarPorId(Guid id)
        {
            try
            {
                return _consulta.Consulta.Find(id)!;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Cadastrar(Consulta consulta)
        {
            try
            {
                _consulta.Consulta.Add(consulta);

                _consulta.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Deletar(Guid id)
        {
            try
            {
                Consulta consultaBuscada = _consulta.Consulta.Find(id)!;

                if (consultaBuscada != null)
                {
                    _consulta.Consulta.Remove(consultaBuscada);
                }

                _consulta.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Consulta> Listar()
        {
            try
            {
                return _consulta.Consulta.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
