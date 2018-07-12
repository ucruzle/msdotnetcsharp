using BrSoftNet.Log.Maps;
using BrSoftNet.Log.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrSoftNet.Log.Helpers
{
    public class ServiceHelper : HelperFactory<ServiceHelper>
    {
        public MappingChanges GetMappingChanges(ChangesHeader _ChangeHeader, List<ChangeItem> _ChangeItems) 
        {
            MappingChanges _MappingChanges = null;

            List<ChangesHeader> _ChangeHeadersHelper = new List<ChangesHeader>();
            List<ChangeItem> _ChangeItemsHelper = new List<ChangeItem>();

            _ChangeHeadersHelper.Add(new ChangesHeader()
            {
                Id = _ChangeHeader.Id,
                CodigoRegistro = _ChangeHeader.CodigoRegistro,
                NomeProcesso = _ChangeHeader.NomeProcesso,
                TipoModificacao = _ChangeHeader.TipoModificacao,
                Usuario = _ChangeHeader.Usuario,
                DataHora = _ChangeHeader.DataHora,
                StatusExecucao = _ChangeHeader.StatusExecucao
            });

            foreach (ChangeItem _ChangeItem in _ChangeItems)
            {
                _ChangeItemsHelper.Add(new ChangeItem() 
                {
                    IdChangeHeader = _ChangeItem.IdChangeHeader,
                    IdItem = _ChangeItem.IdItem,
                    NomeTabela = _ChangeItem.NomeTabela,
                    NomeCampo = _ChangeItem.NomeCampo,
                    ValorAntigo = _ChangeItem.ValorAntigo,
                    ValorNovo = _ChangeItem.ValorNovo
                });
            }

            if (_MappingChanges == null)
            {
                _MappingChanges = new MappingChanges();
            }

            _MappingChanges.ChangeHeaders = _ChangeHeadersHelper;
            _MappingChanges.ChangeItems = _ChangeItemsHelper;

            return _MappingChanges;
        }

        public MappingException GetMappingExceptions(ChangesHeader _ChangeHeader, List<ChangeItem> _ChangeItems, ThrowingException _ThrowingException)
        {
            MappingException _MappingException = null;

            List<ChangesHeader> _ChangeHeadersHelper = new List<ChangesHeader>();
            List<ChangeItem> _ChangeItemsHelper = new List<ChangeItem>();
            List<ThrowingException> ThrowingExceptionsHelper = new List<ThrowingException>();

            _ChangeHeadersHelper.Add(new ChangesHeader()
            {
                Id = _ChangeHeader.Id,
                CodigoRegistro = _ChangeHeader.CodigoRegistro,
                NomeProcesso = _ChangeHeader.NomeProcesso,
                TipoModificacao = _ChangeHeader.TipoModificacao,
                Usuario = _ChangeHeader.Usuario,
                DataHora = _ChangeHeader.DataHora,
                StatusExecucao = _ChangeHeader.StatusExecucao
            });

            foreach (ChangeItem _ChangeItem in _ChangeItems)
            {
                _ChangeItemsHelper.Add(new ChangeItem()
                {
                    IdChangeHeader = _ChangeItem.IdChangeHeader,
                    IdItem = _ChangeItem.IdItem,
                    NomeTabela = _ChangeItem.NomeTabela,
                    NomeCampo = _ChangeItem.NomeCampo,
                    ValorAntigo = _ChangeItem.ValorAntigo,
                    ValorNovo = _ChangeItem.ValorNovo
                });
            }

            ThrowingExceptionsHelper.Add(new ThrowingException() 
            {
                Id = _ThrowingException.Id,
                IdChangeHeader = _ThrowingException.IdChangeHeader,
                Formulario = _ThrowingException.Formulario,
                Tarefa = _ThrowingException.Tarefa,
                FuncaoDisparador = _ThrowingException.FuncaoDisparador,
                TipoExcecao = _ThrowingException.TipoExcecao,
                MensagemExcecao = _ThrowingException.MensagemExcecao
            });

            if (_MappingException == null)
            {
                _MappingException = new MappingException();
            }

            _MappingException.ChangeHeaders = _ChangeHeadersHelper;
            _MappingException.ChangeItems = _ChangeItemsHelper;
            _MappingException.ThrowingExceptions = ThrowingExceptionsHelper;
            

            return _MappingException;
        }

        public string GetIDChanges() 
        {
            string _Id = string.Empty;
            Guid _NewGuid = Guid.NewGuid();

            _Id = "HSTID" + _NewGuid.ToString().Substring(24, 12).ToUpper();

            return _Id;
        }

        public string GetIDExceptions()
        {
            string _Id = string.Empty;
            Guid _NewGuid = Guid.NewGuid();

            _Id = "INCID" + _NewGuid.ToString().Substring(24, 12).ToUpper();

            return _Id;
        }
    }
}
