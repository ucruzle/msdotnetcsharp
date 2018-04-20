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
    public class Funcionario
    {
        #region Fields

        private int _Id;
        private string _Nome;
        private DateTime _DataAdmin;
        private DAL.Domain.Departamento _Departamento;
        private IList _Tarefas;

        #endregion

        #region Constructors

        public Funcionario(int pId, string pNome, DateTime pDataAdmin, DAL.Domain.Departamento pDepartamento)
        {
            pId = this._Id;
            pNome = this._Nome;
            pDataAdmin = this._DataAdmin;
            pDepartamento = this._Departamento;
        }

        public Funcionario()
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

        public DateTime DataAdmin
        {
            get { return _DataAdmin; }
            set { _DataAdmin = value; }
        }

        public Departamento Departamento
        {
            get { return _Departamento; }
            set { _Departamento = value; }
        }

        public IList Tarefas
        {
            get { return _Tarefas; }
            set { _Tarefas = value; }
        }

        #endregion

        #region Methods

        public static Boolean Delete(int pId)
        {
            Funcionario objFuncionario = null;

            ISession objSession = ConnectionFactory.getConnection().OpenSession();
            ITransaction objTransaction = objSession.BeginTransaction();

            try
            {
                objFuncionario = (Funcionario)objSession.Load(typeof(DAL.Domain.Funcionario), pId);
                objSession.Delete(objFuncionario);
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

        public Boolean Presist()
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

        public static Funcionario RetrieveObject(int pId)
        {
            Funcionario objFuncionario = null;

            ISession objSession = ConnectionFactory.getConnection().OpenSession();
            ITransaction objTransaction = objSession.BeginTransaction();

            try
            {
                objFuncionario = (Funcionario)objSession.Load(typeof(DAL.Domain.Funcionario), pId);
                objSession.Close();
            }
            catch (Exception ex)
            {
                objTransaction.Rollback();
                objSession.Close();
                throw ex;
            }

            return objFuncionario;
        }

        public static IList RetrieveObjects(DAL.Domain.Departamento pDepartamento)
        {
            IList listFuncionarios;

            ISession objSession = ConnectionFactory.getConnection().OpenSession();
            ITransaction objTransaction = objSession.BeginTransaction();

            try
            {
                ICriteria criteria = objSession.CreateCriteria(typeof(DAL.Domain.Funcionario));
                criteria.Add(Expression.Eq("Departamento", pDepartamento));
                listFuncionarios = criteria.List();

                objSession.Close();
            }
            catch (Exception ex)
            {
                listFuncionarios = null;
                objTransaction.Rollback();
                throw ex;
            }

            return listFuncionarios;
        }

        public static IList RetrieveObjects()
        {
            IList listFuncionarios;

            ISession objSession = ConnectionFactory.getConnection().OpenSession();
            ITransaction objTransaction = objSession.BeginTransaction();

            try
            {
                listFuncionarios = objSession.CreateCriteria(typeof(DAL.Domain.Funcionario)).List();

                objSession.Close();
            }
            catch (Exception ex)
            {
                listFuncionarios = null;
                objTransaction.Rollback();
                throw ex;
            }

            return listFuncionarios;
        }

        #endregion
    }
}
