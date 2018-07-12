using System;
using System.Data;

namespace BrSoftNet.App.Business.Processes.Security.Entities
{
    [Serializable]
    public class RazaoSocialLogin
    {
        #region Properties

        public string RazaoSocial { get; set; }

        #endregion

        #region Constructors

        public RazaoSocialLogin(DataRow _Row) 
        {
            RazaoSocial = _Row["RazaoSocial"].ToString();
        }

        public RazaoSocialLogin() { }

        #endregion
    }
}
