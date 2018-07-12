using System;
using System.Collections.ObjectModel;
using ClubeDoPedido.Modelo.Modelo;

namespace ClubeDoPedido.Services.Service
{
    public class PromocaoService
    {

        //Método serve somente como teste 
        public ObservableCollection<PromocaoDto> CarregarPromoocoes(int idParceiro)
        {
            var retornoPromocoesPorParceiroID = new ObservableCollection<PromocaoDto>();
            var listaPromocoes = new ObservableCollection<PromocaoDto> {
                new PromocaoDto{
                    ParceiroID = 1,
                    Image = "imagePromocao.png",
                    DescricaoReduzida = "Promoçao do Estabelecimento 1",
                    DescricaoDetalhada = "Imperdivel a promoção do Estabelecimento 1",
                    valorUnitario = Convert.ToDecimal(2.50) ,
                    DataInicio = Convert.ToDateTime("12/06/2017"),
                    DataFim = Convert.ToDateTime("13/07/2017"),
                    CardLimite = 10,
                    QuantidadeClick = 2,
                    QuantidadeVendida = 1
                },
                 new PromocaoDto{
                    ParceiroID = 1,
                    Image = "imagePromocao.png",
                    DescricaoReduzida = "Promoçao do Estabelecimento 1",
                    DescricaoDetalhada = "Imperdivel a promoção do Estabelecimento 1",
                    valorUnitario = Convert.ToDecimal(2.50) ,
                    DataInicio = Convert.ToDateTime("12/06/2017"),
                    DataFim = Convert.ToDateTime("13/07/2017"),
                    CardLimite = 10,
                    QuantidadeClick = 2,
                    QuantidadeVendida = 1
                },
                  new PromocaoDto{
                    ParceiroID = 1,
                    Image = "imagePromocao.png",
                    DescricaoReduzida = "Promoçao do Estabelecimento 1",
                    DescricaoDetalhada = "Imperdivel a promoção do Estabelecimento 1",
                    valorUnitario = Convert.ToDecimal(2.50) ,
                    DataInicio = Convert.ToDateTime("12/06/2017"),
                    DataFim = Convert.ToDateTime("13/07/2017"),
                    CardLimite = 10,
                    QuantidadeClick = 2,
                    QuantidadeVendida = 1
                },
                   new PromocaoDto{
                    ParceiroID = 1,
                    Image = "imagePromocao.png",
                    DescricaoReduzida = "Promoçao do Estabelecimento 1",
                    DescricaoDetalhada = "Imperdivel a promoção do Estabelecimento 1",
                    valorUnitario = Convert.ToDecimal(2.50) ,
                    DataInicio = Convert.ToDateTime("12/06/2017"),
                    DataFim = Convert.ToDateTime("13/07/2017"),
                    CardLimite = 10,
                    QuantidadeClick = 2,
                    QuantidadeVendida = 1
                },
                    new PromocaoDto{
                    ParceiroID = 1,
                    Image = "imagePromocao.png",
                    DescricaoReduzida = "Promoçao do Estabelecimento 1",
                    DescricaoDetalhada = "Imperdivel a promoção do Estabelecimento 1",
                    valorUnitario = Convert.ToDecimal(2.50) ,
                    DataInicio = Convert.ToDateTime("12/06/2017"),
                    DataFim = Convert.ToDateTime("13/07/2017"),
                    CardLimite = 10,
                    QuantidadeClick = 2,
                    QuantidadeVendida = 1
                },
                     new PromocaoDto{
                    ParceiroID = 2,
                    Image = "imagePromocao.png",
                    DescricaoReduzida = "Promoçao do Estabelecimento 2",
                    DescricaoDetalhada = "Imperdivel a promoção do Estabelecimento 2",
                    valorUnitario = Convert.ToDecimal(2.50) ,
                    DataInicio = Convert.ToDateTime("12/06/2017"),
                    DataFim = Convert.ToDateTime("13/07/2017"),
                    CardLimite = 10,
                    QuantidadeClick = 2,
                    QuantidadeVendida = 1
                },
                      new PromocaoDto{
                    ParceiroID = 2,
                    Image = "imagePromocao.png",
                    DescricaoReduzida = "Promoçao do Estabelecimento 2",
                    DescricaoDetalhada = "Imperdivel a promoção do Estabelecimento 2",
                    valorUnitario = Convert.ToDecimal(2.50) ,
                    DataInicio = Convert.ToDateTime("12/06/2017"),
                    DataFim = Convert.ToDateTime("13/07/2017"),
                    CardLimite = 10,
                    QuantidadeClick = 2,
                    QuantidadeVendida = 1
                },
                       new PromocaoDto{
                    ParceiroID = 2,
                    Image = "imagePromocao.png",
                    DescricaoReduzida = "Promoçao do Estabelecimento 2",
                    DescricaoDetalhada = "Imperdivel a promoção do Estabelecimento 2",
                    valorUnitario = Convert.ToDecimal(2.50) ,
                    DataInicio = Convert.ToDateTime("12/06/2017"),
                    DataFim = Convert.ToDateTime("13/07/2017"),
                    CardLimite = 10,
                    QuantidadeClick = 2,
                    QuantidadeVendida = 1
                },
                        new PromocaoDto{
                    ParceiroID = 3,
                    Image = "imagePromocao.png",
                    DescricaoReduzida = "Promoçao do Estabelecimento 3",
                    DescricaoDetalhada = "Imperdivel a promoção do Estabelecimento 3",
                    valorUnitario = Convert.ToDecimal(2.50) ,
                    DataInicio = Convert.ToDateTime("12/06/2017"),
                    DataFim = Convert.ToDateTime("13/07/2017"),
                    CardLimite = 10,
                    QuantidadeClick = 2,
                    QuantidadeVendida = 1
                },
                         new PromocaoDto{
                    ParceiroID = 4,
                    Image = "imagePromocao.png",
                    DescricaoReduzida = "Promoçao do Estabelecimento 4",
                    DescricaoDetalhada = "Imperdivel a promoção do Estabelecimento 4",
                    valorUnitario = Convert.ToDecimal(2.50) ,
                    DataInicio = Convert.ToDateTime("12/06/2017"),
                    DataFim = Convert.ToDateTime("13/07/2017"),
                    CardLimite = 10,
                    QuantidadeClick = 2,
                    QuantidadeVendida = 1
                },
                          new PromocaoDto{
                    ParceiroID = 4,
                    Image = "imagePromocao.png",
                    DescricaoReduzida = "Promoçao do Estabelecimento 4",
                    DescricaoDetalhada = "Imperdivel a promoção do Estabelecimento 4",
                    valorUnitario = Convert.ToDecimal(2.50) ,
                    DataInicio = Convert.ToDateTime("12/06/2017"),
                    DataFim = Convert.ToDateTime("13/07/2017"),
                    CardLimite = 10,
                    QuantidadeClick = 2,
                    QuantidadeVendida = 1
                },
                           new PromocaoDto{
                    ParceiroID = 4,
                    Image = "imagePromocao.png",
                    DescricaoReduzida = "Promoçao do Estabelecimento 4",
                    DescricaoDetalhada = "Imperdivel a promoção do Estabelecimento 4",
                    valorUnitario = Convert.ToDecimal(2.50) ,
                    DataInicio = Convert.ToDateTime("12/06/2017"),
                    DataFim = Convert.ToDateTime("13/07/2017"),
                    CardLimite = 10,
                    QuantidadeClick = 2,
                    QuantidadeVendida = 1
                },
                            new PromocaoDto{
                    ParceiroID = 5,
                    Image = "supermercadoPromocao3.png",
                    DescricaoReduzida = "Promoçao do Estabelecimento 5",
                    DescricaoDetalhada = "Imperdivel a promoção do Estabelecimento 5",
                    valorUnitario = Convert.ToDecimal(2.50) ,
                    DataInicio = Convert.ToDateTime("12/06/2017"),
                    DataFim = Convert.ToDateTime("13/07/2017"),
                    CardLimite = 10,
                    QuantidadeClick = 2,
                    QuantidadeVendida = 1
                },
                             new PromocaoDto{
                    ParceiroID = 5,
                    Image = "supermercadoPromocao2.png",
                    DescricaoReduzida = "Promoçao do Estabelecimento 5",
                    DescricaoDetalhada = "Imperdivel a promoção do Estabelecimento 5",
                    valorUnitario = Convert.ToDecimal(2.50) ,
                    DataInicio = Convert.ToDateTime("12/06/2017"),
                    DataFim = Convert.ToDateTime("13/07/2017"),
                    CardLimite = 10,
                    QuantidadeClick = 2,
                    QuantidadeVendida = 1
                },
                              new PromocaoDto{
                    ParceiroID = 5,
                    Image = "supermercadoPromocao1.png",
                    DescricaoReduzida = "Promoçao do Estabelecimento 5",
                    DescricaoDetalhada = "Imperdivel a promoção do Estabelecimento 5",
                    valorUnitario = Convert.ToDecimal(2.50) ,
                    DataInicio = Convert.ToDateTime("12/06/2017"),
                    DataFim = Convert.ToDateTime("13/07/2017"),
                    CardLimite = 10,
                    QuantidadeClick = 2,
                    QuantidadeVendida = 1
                },
                               new PromocaoDto{
                    ParceiroID = 5,
                    Image = "supermercadoPromocao.png",
                    DescricaoReduzida = "Promoçao do Estabelecimento 5",
                    DescricaoDetalhada = "Imperdivel a promoção do Estabelecimento 5",
                    valorUnitario = Convert.ToDecimal(2.50) ,
                    DataInicio = Convert.ToDateTime("12/06/2017"),
                    DataFim = Convert.ToDateTime("13/07/2017"),
                    CardLimite = 10,
                    QuantidadeClick = 2,
                    QuantidadeVendida = 1
                },
                                new PromocaoDto{
                    ParceiroID = 6,
                    Image = "farmaciaPromocao1.png",
                    DescricaoReduzida = "Promoçao do Estabelecimento 6",
                    DescricaoDetalhada = "Imperdivel a promoção do Estabelecimento 6",
                    valorUnitario = Convert.ToDecimal(2.50) ,
                    DataInicio = Convert.ToDateTime("12/06/2017"),
                    DataFim = Convert.ToDateTime("13/07/2017"),
                    CardLimite = 10,
                    QuantidadeClick = 2,
                    QuantidadeVendida = 1
                },
                                 new PromocaoDto{
                    ParceiroID = 6,
                    Image = "farmaciaPromocao2.png",
                    DescricaoReduzida = "Promoçao do Estabelecimento 6",
                    DescricaoDetalhada = "Imperdivel a promoção do Estabelecimento 6",
                    valorUnitario = Convert.ToDecimal(2.50) ,
                    DataInicio = Convert.ToDateTime("12/06/2017"),
                    DataFim = Convert.ToDateTime("13/07/2017"),
                    CardLimite = 10,
                    QuantidadeClick = 2,
                    QuantidadeVendida = 1
                },
                    new PromocaoDto{
                    ParceiroID = 6,
                    Image = "farmaciaPromocao3.png",
                    DescricaoReduzida = "Promoçao do Estabelecimento 6",
                    DescricaoDetalhada = "Imperdivel a promoção do Estabelecimento 6",
                    valorUnitario = Convert.ToDecimal(2.50) ,
                    DataInicio = Convert.ToDateTime("12/06/2017"),
                    DataFim = Convert.ToDateTime("13/07/2017"),
                    CardLimite = 10,
                    QuantidadeClick = 2,
                    QuantidadeVendida = 1
                },
                    new PromocaoDto{
                    ParceiroID = 6,
                    Image = "farmaciaPromocao4.png",
                    DescricaoReduzida = "Promoçao do Estabelecimento 6",
                    DescricaoDetalhada = "Imperdivel a promoção do Estabelecimento 6",
                    valorUnitario = Convert.ToDecimal(2.50) ,
                    DataInicio = Convert.ToDateTime("12/06/2017"),
                    DataFim = Convert.ToDateTime("13/07/2017"),
                    CardLimite = 10,
                    QuantidadeClick = 2,
                    QuantidadeVendida = 1
                },
                    new PromocaoDto{
                    ParceiroID = 6,
                    Image = "farmaciaPromocao5.png",
                    DescricaoReduzida = "Promoçao do Estabelecimento 6",
                    DescricaoDetalhada = "Imperdivel a promoção do Estabelecimento 6",
                    valorUnitario = Convert.ToDecimal(2.50) ,
                    DataInicio = Convert.ToDateTime("12/06/2017"),
                    DataFim = Convert.ToDateTime("13/07/2017"),
                    CardLimite = 10,
                    QuantidadeClick = 2,
                    QuantidadeVendida = 1
                },
                    new PromocaoDto{
                    ParceiroID = 6,
                    Image = "farmaciaPromocao1.png",
                    DescricaoReduzida = "Promoçao do Estabelecimento 6",
                    DescricaoDetalhada = "Imperdivel a promoção do Estabelecimento 6",
                    valorUnitario = Convert.ToDecimal(2.50) ,
                    DataInicio = Convert.ToDateTime("12/06/2017"),
                    DataFim = Convert.ToDateTime("13/07/2017"),
                    CardLimite = 10,
                    QuantidadeClick = 2,
                    QuantidadeVendida = 1
                },
                    new PromocaoDto{
                    ParceiroID = 6,
                    Image = "farmaciaPromocao2.png",
                    DescricaoReduzida = "Promoçao do Estabelecimento 6",
                    DescricaoDetalhada = "Imperdivel a promoção do Estabelecimento 6",
                    valorUnitario = Convert.ToDecimal(2.50) ,
                    DataInicio = Convert.ToDateTime("12/06/2017"),
                    DataFim = Convert.ToDateTime("13/07/2017"),
                    CardLimite = 10,
                    QuantidadeClick = 2,
                    QuantidadeVendida = 1
                },
                    new PromocaoDto{
                    ParceiroID = 6,
                    Image = "farmaciaPromocao3.png",
                    DescricaoReduzida = "Promoçao do Estabelecimento 6",
                    DescricaoDetalhada = "Imperdivel a promoção do Estabelecimento 6",
                    valorUnitario = Convert.ToDecimal(2.50) ,
                    DataInicio = Convert.ToDateTime("12/06/2017"),
                    DataFim = Convert.ToDateTime("13/07/2017"),
                    CardLimite = 10,
                    QuantidadeClick = 2,
                    QuantidadeVendida = 1
                },
                    new PromocaoDto{
                    ParceiroID = 3,
                    Image = "imagePromocao.png",
                    DescricaoReduzida = "Promoçao do Estabelecimento 3",
                    DescricaoDetalhada = "Imperdivel a promoção do Estabelecimento 3",
                    valorUnitario = Convert.ToDecimal(2.50) ,
                    DataInicio = Convert.ToDateTime("12/06/2017"),
                    DataFim = Convert.ToDateTime("13/07/2017"),
                    CardLimite = 10,
                    QuantidadeClick = 2,
                    QuantidadeVendida = 1
                },
                    new PromocaoDto{
                    ParceiroID = 3,
                    Image = "imagePromocao.png",
                    DescricaoReduzida = "Promoçao do Estabelecimento 3",
                    DescricaoDetalhada = "Imperdivel a promoção do Estabelecimento 3",
                    valorUnitario = Convert.ToDecimal(2.50) ,
                    DataInicio = Convert.ToDateTime("12/06/2017"),
                    DataFim = Convert.ToDateTime("13/07/2017"),
                    CardLimite = 10,
                    QuantidadeClick = 2,
                    QuantidadeVendida = 1
                },
                    new PromocaoDto{
                    ParceiroID = 2,
                    Image = "imagePromocao.png",
                    DescricaoReduzida = "Promoçao do Estabelecimento 2",
                    DescricaoDetalhada = "Imperdivel a promoção do Estabelecimento 2",
                    valorUnitario = Convert.ToDecimal(2.50) ,
                    DataInicio = Convert.ToDateTime("12/06/2017"),
                    DataFim = Convert.ToDateTime("13/07/2017"),
                    CardLimite = 10,
                    QuantidadeClick = 2,
                    QuantidadeVendida = 1
                },
                    new PromocaoDto{
                    ParceiroID = 1,
                    Image = "imagePromocao.png",
                    DescricaoReduzida = "Promoçao do Estabelecimento 1",
                    DescricaoDetalhada = "Imperdivel a promoção do Estabelecimento 1",
                    valorUnitario = Convert.ToDecimal(2.50) ,
                    DataInicio = Convert.ToDateTime("12/06/2017"),
                    DataFim = Convert.ToDateTime("13/07/2017"),
                    CardLimite = 10,
                    QuantidadeClick = 2,
                    QuantidadeVendida = 1
                },
                    new PromocaoDto{
                    ParceiroID = 1,
                    Image = "imagePromocao.png",
                    DescricaoReduzida = "Promoçao do Estabelecimento 1",
                    DescricaoDetalhada = "Imperdivel a promoção do Estabelecimento 1",
                    valorUnitario = Convert.ToDecimal(2.50) ,
                    DataInicio = Convert.ToDateTime("12/06/2017"),
                    DataFim = Convert.ToDateTime("13/07/2017"),
                    CardLimite = 10,
                    QuantidadeClick = 2,
                    QuantidadeVendida = 1
                }
            };


            foreach (var item in listaPromocoes)
            {
                if (item.ParceiroID == idParceiro)
                  retornoPromocoesPorParceiroID.Add(item);
            }

            return retornoPromocoesPorParceiroID;
        }
    }
}
