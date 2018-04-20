using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DAL.Domain;

namespace BLL.Process
{
    public class cntrlDepartamento
    {
        #region Global Field

        private Departamento _objDepartamento;

        #endregion

        #region Constructor

        public cntrlDepartamento()
        {
        }

        #endregion

        #region Methods

        public Boolean Save(DS_DTO.tblDepartamentosRow pRowDepartamento)
        {
            Boolean result = false;

            if (pRowDepartamento.Id == 0 || Convert.ToString(pRowDepartamento.Id) == string.Empty)
            {
                this._objDepartamento = new Departamento();

                this._objDepartamento.Nome = pRowDepartamento.Nome;

                try
                {
                    result = this._objDepartamento.Persist();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else 
            {
                this._objDepartamento = Departamento.RetrieveObject(pRowDepartamento.Id);
                this._objDepartamento.Nome = pRowDepartamento.Nome;

                try
                {
                    result = this._objDepartamento.Update();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return result;
        }

        public static Boolean Delete(int pId)
        {
            Boolean Result = false;

            try
            {
                Result = Departamento.Delete(pId);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Result;
        }

        public DS_DTO.tblDepartamentosRow Select(int pId)
        {
            DS_DTO.tblDepartamentosDataTable tblDepartamento = new DS_DTO.tblDepartamentosDataTable();
            DS_DTO.tblDepartamentosRow rowTblDepartamento = tblDepartamento.NewtblDepartamentosRow();

            try
            {
                this._objDepartamento = Departamento.RetrieveObject(pId);

                rowTblDepartamento.Id = this._objDepartamento.Id;
                rowTblDepartamento.Nome = this._objDepartamento.Nome;
                rowTblDepartamento.FuncionariosCount = this._objDepartamento.Funcionarios.Count;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return rowTblDepartamento;
        }

        public static DS_DTO.tblDepartamentosDataTable Select()
        {
            DS_DTO.tblDepartamentosDataTable tblDepartamento = new DS_DTO.tblDepartamentosDataTable();

            try
            {
                IList listDepartamentos = Departamento.RetrieveObjects();

                for (int i = 0; i < listDepartamentos.Count; i++)
                {
                    Departamento objtemp = (Departamento)listDepartamentos[i];

                    tblDepartamento.AddtblDepartamentosRow(objtemp.Id,
                                                           objtemp.Nome,
                                                           objtemp.Funcionarios.Count);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return tblDepartamento;
        }

        #endregion
    }
}
