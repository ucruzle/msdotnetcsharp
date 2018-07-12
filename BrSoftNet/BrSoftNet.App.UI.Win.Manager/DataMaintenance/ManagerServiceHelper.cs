using BrSoftNet.App.Business.Processes.Manager.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrSoftNet.App.UI.Win.Manager.DataMaintenance
{
    [Serializable]
    public class ManagerServiceHelper : MappingFactory<ManagerServiceHelper>
    {
        public LiberacaoUsuarioProcessMapping RetornaDadosLiberacaoUsuario(List<GeUsuarioProcesso> _UsuarioProcessoCollection)
        { 
            List<GeUsuarioProcesso> _UsuariosProcessos = new List<GeUsuarioProcesso>();
            LiberacaoUsuarioProcessMapping _LiberacaoUsuarioProcessMapping = null;

            foreach (GeUsuarioProcesso _UsuarioProcesso in _UsuarioProcessoCollection)
            {
                _UsuariosProcessos.Add(new GeUsuarioProcesso(_UsuarioProcesso.CodigoEmpresa, 
                                                             _UsuarioProcesso.Usuario, 
                                                             _UsuarioProcesso.CodigoProcesso));
            }

            _LiberacaoUsuarioProcessMapping = new LiberacaoUsuarioProcessMapping();

            _LiberacaoUsuarioProcessMapping.UsuariosProcessos = _UsuariosProcessos;

            return _LiberacaoUsuarioProcessMapping;
        }

        public GrupoProcessoProcessMapping RetornaDadosGrupoProcesso(List<GeGrupoProcesso> _GrupoProcessoCollection)
        {
            List<GeGrupoProcesso> _GrupoProcessos = new List<GeGrupoProcesso>();
            GrupoProcessoProcessMapping _GrupoProcessoProcessMapping = null;

            foreach (GeGrupoProcesso _GrupoProcesso in _GrupoProcessoCollection)
            {
                _GrupoProcessos.Add(new GeGrupoProcesso(_GrupoProcesso.CodigoEmpresa,
                                                        _GrupoProcesso.CodigoGrupo,
                                                        _GrupoProcesso.CodigoProcesso));
            }

            _GrupoProcessoProcessMapping = new GrupoProcessoProcessMapping();

            _GrupoProcessoProcessMapping.GrupoProcessos = _GrupoProcessos;

            return _GrupoProcessoProcessMapping;
        }
    }
}
