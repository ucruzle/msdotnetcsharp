using ConsultaAereo.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConsultaAereo.Api
{
    public class PassagemAereaRepositorio
    {
        private IList<PassagemAerea> _passagens;

        public PassagemAereaRepositorio()
        {
            this._passagens = new List<PassagemAerea>()
            {
                new PassagemAerea()
                {
                    Id = 1,
                    DataIda = new DateTime(2014, 1, 30),
                    DataVolta = new DateTime(2014, 2, 10),
                    Origem = new Aeroporto()
                    {
                        Id = 1,
                        Sigla = "NVT",
                        NomeCompleto = "Aeroporto Internacional de Navegantes"
                    },
                    Destino = new Aeroporto()
                    {
                        Id = 2,
                        Sigla = "CGH",
                        NomeCompleto = "Aeroporto de Congonhas"
                    },
                    QuantidadePax = 1
                },
                new PassagemAerea()
                {
                    Id = 2,
                    DataIda = new DateTime(2014, 3, 20),
                    DataVolta = new DateTime(2014, 3, 30),
                    Origem = new Aeroporto()
                    {
                        Id = 3,
                        Sigla = "GRU",
                        NomeCompleto = "Aeroporto Internacional de Guarulhos"
                    },
                    Destino = new Aeroporto()
                    {
                        Id = 4,
                        Sigla = "MIA",
                        NomeCompleto = "Aeroporto Internacional de Miami"
                    },
                    QuantidadePax = 1
                },
                new PassagemAerea()
                {
                    Id = 3,
                    DataIda = new DateTime(2014, 3, 30),
                    DataVolta = new DateTime(2014, 4, 13),
                    Origem = new Aeroporto()
                    {
                        Id = 4,
                        Sigla = "MIA",
                        NomeCompleto = "Aeroporto Internacional de Miami"
                    },
                    Destino = new Aeroporto()
                    {
                        Id = 3,
                        Sigla = "GRU",
                        NomeCompleto = "Aeroporto Internacional de Guarulhos"
                    },
                    QuantidadePax = 1
                },
                new PassagemAerea()
                {
                    Id = 4,
                    DataIda = new DateTime(2014, 3, 13),
                    DataVolta = new DateTime(2014, 4, 13),
                    Origem = new Aeroporto()
                    {
                        Id = 3,
                        Sigla = "GRU",
                        NomeCompleto = "Aeroporto Internacional de Guarulhos"
                    },
                    Destino = new Aeroporto()
                    {
                        Id = 5,
                        Sigla = "CDG",
                        NomeCompleto = "Aeroporto Internacional de Paris"
                    },
                    QuantidadePax = 2
                },
                new PassagemAerea()
                {
                    Id = 5,
                    DataIda = new DateTime(2014, 5, 10),
                    DataVolta = new DateTime(2014, 5, 25),
                    Origem = new Aeroporto()
                    {
                        Id = 6,
                        Sigla = "FLN",
                        NomeCompleto = "Aeroporto Internacional de Florianópolis"
                    },
                    Destino = new Aeroporto()
                    {
                        Id = 7,
                        Sigla = "BSB",
                        NomeCompleto = "Aeroporto Internacional de Brasília"
                    },
                    QuantidadePax = 3
                }
            };
        }

        public IQueryable<PassagemAerea> ObterTodas()
        {
            return this._passagens.AsQueryable<PassagemAerea>();
        }

        public void Atualizar(PassagemAerea passagemAerea)
        {
            var passagemAtual = this.Obter(passagemAerea.Id);
            this.Remover(passagemAtual);
            this.Adicionar(passagemAerea);
        }

        public void Adicionar(PassagemAerea passagemAerea)
        {
            this._passagens.Add(passagemAerea);
        }

        public PassagemAerea Obter(int key)
        {
            return this._passagens.FirstOrDefault(p => p.Id == key);
        }

        public void Remover(PassagemAerea passagemAerea)
        {
            this._passagens.Remove(passagemAerea);
        }
    }
}