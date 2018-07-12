using System;
using System.Data;

namespace BrSoftNet.App.Business.Processes.Manager.Entities
{
    [Serializable]
    public class ParametroGerenciador
    {
        public int IdTabela { get; set; }
        public string DirLogoEmpresa { get; set; }
        public string DirPgmRelatorio { get; set; }
        public string DirRelatorio { get; set; }
        public string DirBackup { get; set; }
        public string DirScript { get; set; }
        public string DirImportacao { get; set; }
        public string DirExportacaoExcel { get; set; }
        public int IdTipoProcEsp { get; set; }
        public int IdTipoProcInt { get; set; }
        public string MostraFormMenu { get; set; }
        public string DirFoto { get; set; }
        public string DirServidor { get; set; }			 
        public ParametroGerenciador(DataRow _Row) 
        {
            IdTabela = int.Parse(_Row["id_tabela"].ToString());
            DirLogoEmpresa = _Row["dir_logo_empresa"].ToString();
            DirPgmRelatorio = _Row["dir_pgm_relatorio"].ToString();
            DirRelatorio = _Row["dir_relatorio"].ToString();
            DirBackup = _Row["dir_backup"].ToString();
            DirScript = _Row["dir_script"].ToString();
            DirImportacao = _Row["dir_importacao"].ToString();
            DirExportacaoExcel = _Row["dir_exportacao_excel"].ToString();
            IdTipoProcEsp = int.Parse(_Row["cod_tipo_proc_esp"].ToString());
            IdTipoProcInt = int.Parse(_Row["cod_tipo_proc_int"].ToString());
            MostraFormMenu = _Row["mostra_form_menu"].ToString();
            DirFoto = _Row["dir_foto"].ToString();
            DirServidor = _Row["dir_servidor"].ToString();			
        }
        public ParametroGerenciador() { }
    }
}
