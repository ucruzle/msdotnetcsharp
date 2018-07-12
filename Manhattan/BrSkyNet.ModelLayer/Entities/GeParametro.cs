using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BrSkyNet.ModelLayer.Entities
{
    [Table("ge_parametro")]
    public class GeParametro
    {
        [Key]
        [Required(ErrorMessage = "Campo obrigatório.")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("ID Tabela")]
        public int? id_tabela { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Diretório Logo Empresa")]
        public string dir_logo_empresa { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Diretório Relatórios Pagamentos")]
        public string dir_pgm_relatorio { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Diretório Logo Empresa")]
        public string dir_relatorio { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Diretório Backup")]
        public string dir_backup { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Diretório Script")]
        public string dir_script { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Diretório Importação")]
        public string dir_importacao { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Diretório Exportação Excel")]
        public string dir_exportacao_excel { get; set; }

        //[Column("cod_tipo_proc_esp")]
        [ForeignKey("GeTipoProcessoEsp")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Tipo Processo Especial")]
        public int? cod_tipo_proc_esp { get; set; }

        public GeTipoProcesso GeTipoProcessoEsp { get; set; }

        //[Column("cod_tipo_proc_int")]
        [ForeignKey("GeTipoProcessoInt")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Tipo Processo Interno")]
        public int? cod_tipo_proc_int { get; set; }

        public GeTipoProcesso GeTipoProcessoInt { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Exibe Acesso Formulário")]
        public string mostra_form_menu { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Diretório Foto")]
        public string dir_foto { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Diretório Servidor")]
        public string dir_servidor { get; set; }
    }
}
