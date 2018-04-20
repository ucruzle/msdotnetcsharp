using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;

namespace DAL.Domain
{
    public class Departamento
    {
        #region Fields

        private int _Id;
        private string _Nome;
        private IList _Funcionarios;

        #endregion

        #region Constructors

        public Departamento(int pId, string pNome)
        {
            pId = this._Id;
            pNome = this._Nome;
        }

        public Departamento()
        {
        }

        #endregion

        #region Properties

        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        public string Nome
        {
            get { return _Nome; }
            set { _Nome = value; }
        }

        public IList Funcionarios
        {
            get { return _Funcionarios; }
            set { _Funcionarios = value; }
        }

        #endregion

        #region Methods

        public static Boolean Delete(int pId)
        {
            Departamento objDepartamento = null;

            ISession objSession = ConnectionFactory.getConnection().OpenSession();
            ITransaction objTransaction = objSession.BeginTransaction();

            try
            {
                objDepartamento = (Departamento)objSession.Load(typeof(DAL.Domain.Departamento), pId);
                objSession.Delete(objDepartamento);
                objTransaction.Commit();
                objSession.Close();
                return true;
            }
            catch (Exception ex)
            {
                objTransaction.Rollback();
                objSession.Close();
                throw ex;
            }
        }

        public Boolean Update()
        {
            ISession objSession = ConnectionFactory.getConnection().OpenSession();
            ITransaction objTransaction = objSession.BeginTransaction();

            try
            {
                objSession.Update(this);
                objTransaction.Commit();
                objSession.Close();
                return true;
            }
            catch (Exception ex)
            {
                objTransaction.Rollback();
                objSession.Close();
                throw ex;
            }
        }

        public Boolean Persist()
        {
            ISession objSession = ConnectionFactory.getConnection().OpenSession();
            ITransaction objTransaction = objSession.BeginTransaction();

            try
            {
                objSession.Save(this);
                objTransaction.Commit();
                objSession.Close();
                return true;
            }
            catch (Exception ex)
            {
                objTransaction.Rollback();
                objSession.Close();
                throw ex;
            }
        }

        public static Departamento RetrieveObject(int pId)
        {
            Departamento objDepartamento = null;

            ISession objSession = ConnectionFactory.getConnection().OpenSession();
            ITransaction objTransaction = objSession.BeginTransaction();

            try
            {
                objDepartamento = (Departamento)objSession.Load(typeof(DAL.Domain.Departamento), pId);
                objSession.Close();
            }
            catch (Exception ex)
            {
                objTransaction.Rollback();
                objSession.Close();
                throw ex;
            }

            return objDepartamento;
        }

        public static IList RetrieveObjects()
        {
            IList listDepartamentos;

            ISession objSession = ConnectionFactory.getConnection().OpenSession();
            ITransaction objTransaction = objSession.BeginTransaction();

            try
            {
                listDepartamentos = objSession.CreateCriteria(typeof(DAL.Domain.Departamento)).List();
                objSession.Close();
            }
            catch (Exception ex)
            {
                listDepartamentos = null;
                objTransaction.Rollback();
                throw ex;
            }

            return listDepartamentos;
        }

        #endregion
    }
}
