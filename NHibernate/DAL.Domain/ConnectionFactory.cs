using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Cfg;

namespace DAL.Domain
{
    public class ConnectionFactory
    {
        private Configuration _objconf = null;
        private static ISessionFactory _objFactory = null;

        public ConnectionFactory()
        {
            try
            {
                #region configure xml file NHibernate

                this.objConf = new Configuration();

                #endregion

                #region Add class of domain layer

                this.objConf.AddClass(typeof(DAL.Domain.Departamento));
                this.objConf.AddClass(typeof(DAL.Domain.Funcionario));
                this.objConf.AddClass(typeof(DAL.Domain.Tarefa));

                #endregion

                #region Build a new object factory

                objFactory = this.objConf.BuildSessionFactory();

                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Configuration objConf
        {
            get { return _objconf; }

            set { _objconf = value; }
        }

        public static ISessionFactory objFactory
        {
            get { return _objFactory; }
            set { _objFactory = value; }
        }

        public static ISessionFactory getConnection()
        {
            if (objFactory == null) 
            {
                ConnectionFactory objGlobal = new ConnectionFactory();
            }

            return objFactory;
        }
    }
}
