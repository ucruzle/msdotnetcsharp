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
    public class Tarefa
    {
        #region Fields

        private int _Id;
        private string _Descricao;
        private Funcionario _Funcionario;

        #endregion

        #region Constructors

        public Tarefa(int pId, Funcionario pFuncionario, string pDescricao)
        {
            pId = this._Id;
            pFuncionario = this._Funcionario;
            pDescricao = this._Descricao;
        }

        public Tarefa()
        {
        }

        #endregion

        #region Properties

        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        public Funcionario Funcionario
        { 
            get { return _Funcionario; }
            set { _Funcionario = value; }
        }

        public string Descricao
        {
            get { return _Descricao; }
            set { _Descricao = value; }
        }

        #endregion

        #region Methods

        public static Boolean Delete(int pId)
        {
            Tarefa objTarefa = null;

            ISession objSession = ConnectionFactory.getConnection().OpenSession();
            ITransaction objTransaction = objSession.BeginTransaction();

            try
            {
                objTarefa = (Tarefa)objSession.Load(typeof(DAL.Domain.Tarefa), pId);
                objSession.Delete(objTarefa);
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

        public static Tarefa RetrieveObject(int pId)
        {
            Tarefa objTarefa = null;

            ISession objSession = ConnectionFactory.getConnection().OpenSession();
            ITransaction objTransaction = objSession.BeginTransaction();

            try
            {
                objTarefa = (Tarefa)objSession.Load(typeof(DAL.Domain.Tarefa), pId);
                objSession.Close();
            }
            catch (Exception ex)
            {
                objTransaction.Rollback();
                objSession.Close();
                throw ex;
            }

            return objTarefa;
        }

        public static IList RetrieveObjects(Funcionario pFuncionario)
        {
            IList listTarefas;

            ISession objSession = ConnectionFactory.getConnection().OpenSession();
            ITransaction objTransaction = objSession.BeginTransaction();

            try
            {
                ICriteria criteria = objSession.CreateCriteria(typeof(DAL.Domain.Tarefa));
                criteria.Add(Expression.Eq("Funcionario", pFuncionario));
                listTarefas = criteria.List();
                objSession.Close();
            }
            catch (Exception ex)
            {
                listTarefas = null;
                objTransaction.Rollback();
                throw ex;
            }

            return listTarefas;
        }

        #endregion
    }
}
