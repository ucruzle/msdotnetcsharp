using System;
using System.Collections.Generic;
using System.Linq;
using TesteCodeFirst.Entities;
using TesteCodeFirst.Utils.ORM;

namespace TesteCodeFirst.DAL
{
    public class ProfissionalDAO : BaseRepository<Profissional>
    {
        public List<ResumoDadosProfissional> ListarResumoProfissionais()
        {
            List<ResumoDadosProfissional> profissionais =
                this.GetQueryable()
                    .OrderBy(p => p.NmProfissional)
                    .Select(p => new ResumoDadosProfissional()
                           {
                               Id = p.Id.Value,
                               CPF = p.CPF,
                               NmProfissional = p.NmProfissional,
                               DsOcupacao = p.Ocupacao.NomeOcupacao,
                               VlHora = p.VlHora.Value
                           })
                    .ToList();
            return profissionais;
        }

        public bool CPFJaExistente(int id, string cpf)
        {
            var profissionaisEncontrados =
                this.GetQueryable()
                    .Where(p => p.Id != id &&
                                p.CPF == cpf);
            return (profissionaisEncontrados.Count() > 0);
        }
    }
}