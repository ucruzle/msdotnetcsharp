using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DAL.Domain;

namespace BLL.Process
{
    public class cntrlFuncionario
    {
        #region Global Field

        private Funcionario _objFuncionario;

        #endregion

        #region Constructor

        public cntrlFuncionario()
        {
        }

        #endregion

        #region Methods

        public Boolean Save(DS_DTO.tblFuncionariosRow pRowFuncionario)
        {
            Boolean Result = false;

            if (pRowFuncionario.Id == 0 || Convert.ToString(pRowFuncionario.Id) == string.Empty)
            {
                this._objFuncionario = new Funcionario();
                this._objFuncionario.Nome = pRowFuncionario.Nome;
                this._objFuncionario.DataAdmin = pRowFuncionario.DataAdmin;
                this._objFuncionario.Departamento = Departamento.RetrieveObject(pRowFuncionario.IdDepartamento);

                try
                {
                    Result = this._objFuncionario.Presist();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else 
            {
                this._objFuncionario = Funcionario.RetrieveObject(pRowFuncionario.Id);
                this._objFuncionario.Nome = pRowFuncionario.Nome;
                this._objFuncionario.DataAdmin = pRowFuncionario.DataAdmin;
                this._objFuncionario.Departamento = Departamento.RetrieveObject(pRowFuncionario.IdDepartamento);

                try
                {
                    Result = this._objFuncionario.Update();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return Result;
        }

        public static Boolean Delete(int pId)
        {
            Boolean Result = false;

            try
            {
                Result = Funcionario.Delete(pId);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Result;
        }

        public DS_DTO.tblFuncionariosRow Select(int pId)
        {
            DS_DTO.tblFuncionariosDataTable tblFuncionario = new DS_DTO.tblFuncionariosDataTable();
            DS_DTO.tblFuncionariosRow rowFuncionario = tblFuncionario.NewtblFuncionariosRow();

            try
            {
                this._objFuncionario = Funcionario.RetrieveObject(pId);

                rowFuncionario.Id = this._objFuncionario.Id;
                rowFuncionario.Nome = this._objFuncionario.Nome;
                rowFuncionario.DataAdmin = this._objFuncionario.DataAdmin;
                rowFuncionario.IdDepartamento = this._objFuncionario.Departamento.Id;
                rowFuncionario.TarefasCount = this._objFuncionario.Tarefas.Count;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return rowFuncionario;
        }

        public static DS_DTO.tblFuncionariosDataTable Select() 
        {
            DS_DTO.tblFuncionariosDataTable tblFuncionario = new DS_DTO.tblFuncionariosDataTable();

            try
            {
                IList listFuncionarios = Funcionario.RetrieveObjects();

                for (int i = 0; i < listFuncionarios.Count; i++)
                {
                    Funcionario objTemp = (Funcionario)listFuncionarios[i];

                    tblFuncionario.AddtblFuncionariosRow(objTemp.Id,
                                                         objTemp.Nome,
                                                         objTemp.DataAdmin,
                                                         objTemp.Departamento.Id,
                                                         objTemp.Tarefas.Count);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return tblFuncionario;
        }

        public static DS_DTO.tblFuncionariosDataTable SelectByDepartamento(int pIdDepartamento)
        {
            DS_DTO.tblFuncionariosDataTable tblFuncionario = new DS_DTO.tblFuncionariosDataTable();

            try
            {
                IList listFuncionarios = Funcionario.RetrieveObjects(Departamento.RetrieveObject(pIdDepartamento));

                for (int i = 0; i < listFuncionarios.Count; i++)
                {
                    Funcionario objTemp = (Funcionario)listFuncionarios[i];

                    tblFuncionario.AddtblFuncionariosRow(objTemp.Id, 
                                                         objTemp.Nome, 
                                                         objTemp.DataAdmin, 
                                                         objTemp.Departamento.Id, 
                                                         objTemp.Tarefas.Count);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return tblFuncionario;
        }

        #endregion
    }
}
