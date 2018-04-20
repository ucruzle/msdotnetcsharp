using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DAL.Domain;

namespace BLL.Process
{
    public class cntrlTarefa
    {
        #region Global Field

        private Tarefa _objTarefa;

        #endregion

        #region Constructor

        public cntrlTarefa()
        {
        }

        #endregion

        #region Methods

        public static Boolean Delete(int pId)
        {
            Boolean Result = false;

            try
            {
                Result = Tarefa.Delete(pId);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Result;
        }

        public DS_DTO.tblTarefasRow Select(int pId)
        {
            DS_DTO.tblTarefasDataTable tblTarefa = new DS_DTO.tblTarefasDataTable();
            DS_DTO.tblTarefasRow rowTarefa = tblTarefa.NewtblTarefasRow();

            try
            {
                this._objTarefa = Tarefa.RetrieveObject(pId);

                rowTarefa.Id = this._objTarefa.Id;
                rowTarefa.Descricao = this._objTarefa.Descricao;
                rowTarefa.IdFuncionario = this._objTarefa.Funcionario.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return rowTarefa;
        }

        public static DS_DTO.tblTarefasDataTable SelectByFuncionario(int pIdFuncionario)
        {
            DS_DTO.tblTarefasDataTable tblTarefa = new DS_DTO.tblTarefasDataTable();

            try
            {
                IList listTarefa = Tarefa.RetrieveObjects(Funcionario.RetrieveObject(pIdFuncionario));

                for (int i = 0; i < listTarefa.Count; i++)
                {
                    Tarefa objTemp = (Tarefa)listTarefa[i];

                    tblTarefa.AddtblTarefasRow(objTemp.Id, 
                                               objTemp.Descricao, 
                                               objTemp.Funcionario.Id);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return tblTarefa;
        }

        public Boolean Save(DS_DTO.tblTarefasRow pRowTarefa)
        {
            Boolean Result = false;

            if (pRowTarefa.Id == 0 || Convert.ToString(pRowTarefa.Id) == string.Empty)
            {
                this._objTarefa = new Tarefa();
                this._objTarefa.Descricao = pRowTarefa.Descricao;
                this._objTarefa.Funcionario = Funcionario.RetrieveObject(pRowTarefa.IdFuncionario);

                try
                {
                    Result = this._objTarefa.Persist();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else 
            {
                this._objTarefa = Tarefa.RetrieveObject(pRowTarefa.Id);
                this._objTarefa.Descricao = pRowTarefa.Descricao;
                this._objTarefa.Funcionario = Funcionario.RetrieveObject(pRowTarefa.IdFuncionario);

                try
                {
                    Result = this._objTarefa.Update();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return Result;
        }

        #endregion
    }
}
