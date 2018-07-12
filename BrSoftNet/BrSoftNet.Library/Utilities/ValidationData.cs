using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BrSoftNet.Library.Utilities
{
    public class ValidationData : UtilitiesFactory<ValidationData>
    {
        public bool ValidaEMail(string _EMail) 
        {
            bool _Result = false;
            string _ExpressionRegular = @"\w+([‐+.]\w+)*@\w+([‐.]\w+)*\.\w+([‐.]\w+)*";

            Regex _Regex = new Regex(_ExpressionRegular);

            if (_Regex.IsMatch(_EMail))
            {
                _Result = true;
            }
            
            return _Result;
        }

        public bool ValidaIP(string _Ip)
        {
            bool _Result = false;
            string _ExpressionRegular = @"((25[0‐5]|2[0‐4]\d|1\d\d|[1‐9]\d|\d)\.){3}(25[0‐5]|2[0‐4]\d|1\d\d|[1‐9]\d|\d)";

            Regex _Regex = new Regex(_ExpressionRegular);

            if (_Regex.IsMatch(_Ip))
            {
                _Result = true;
            }

            return _Result;
        }

        public bool ValidaSenhaEspecial(string _SenhaEspecial)
        {
            bool _Result = false;
            string _ExpressionRegular = @"^(?=.*\d)(?=.*[a‐z])(?=.*[A‐Z])[0‐9A‐Za‐z@.]{8,}$";

            Regex _Regex = new Regex(_ExpressionRegular);

            if (_Regex.IsMatch(_SenhaEspecial))
            {
                _Result = true;
            }

            return _Result;
        }

        public bool ValidaSenha(string _Senha)
        {
            bool _Result = false;
            string _ExpressionRegular = @"^(?=.*\d)(?=.*[a‐z])(?=.*[A‐Z])\w{8,}$";

            Regex _Regex = new Regex(_ExpressionRegular);

            if (_Regex.IsMatch(_Senha))
            {
                _Result = true;
            }

            return _Result;
        }

        public bool ValidaNroCataoCredito(string _CartaoCredito)
        {
            bool _Result = false;
            string _ExpressionRegular = @"((\d{16}|\d{4}(‐\d{4}){3})|(\d{4}(\d{4}){3}))";

            Regex _Regex = new Regex(_ExpressionRegular);

            if (_Regex.IsMatch(_CartaoCredito))
            {
                _Result = true;
            }

            return _Result;
        }

        public bool ValidaNroCaixaPostal(string _CaixaPostal)
        {
            bool _Result = false;
            string _ExpressionRegular = @"\d{8}(‐\d{4})?";

            Regex _Regex = new Regex(_ExpressionRegular);

            if (_Regex.IsMatch(_CaixaPostal))
            {
                _Result = true;
            }

            return _Result;
        }

        public bool ValidaNroTelefone(string _Telefone)
        {
            bool _Result = false;
            string _ExpressionRegular = @"\(\d{2}\)–\d{3}–\d{4}";

            Regex _Regex = new Regex(_ExpressionRegular);

            if (_Regex.IsMatch(_Telefone))
            {
                _Result = true;
            }

            return _Result;
        }

        public bool ValidaHora(string _Hora)
        {
            bool _Result = false;
            string _ExpressionRegular = @"(2[0–3]|[01]\d|\d):[0–5]\d";

            Regex _Regex = new Regex(_ExpressionRegular);

            if (_Regex.IsMatch(_Hora))
            {
                _Result = true;
            }

            return _Result;
        }

        public bool ValidaData(string _Data)
        {
            bool _Result = false;
            string _ExpressionRegular = @"(30|31|2\d|1\d|0?[1–9])(?<sep>[‐/])(10|11|12|0?[1–9])\<sep>(\d{4}|\d{2})";

            Regex _Regex = new Regex(_ExpressionRegular);

            if (_Regex.IsMatch(_Data))
            {
                _Result = true;
            }

            return _Result;
        }

        public bool ValidaAceiteSomenteCaracteres(string _Caracteres)
        {
            bool _Result = false;
            string _ExpressionRegular = @"^[aA-zZ]+((\s[aA-zZ]+)+)?$";

            Regex _Regex = new Regex(_ExpressionRegular);

            if (_Regex.IsMatch(_Caracteres))
            {
                _Result = true;
            }

            return _Result;
        }

        public bool ValidaAceiteSomenteNumeros(string _Numeros)
        {
            bool _Result = false;
            string _ExpressionRegular = @"^[0-9]+$";

            Regex _Regex = new Regex(_ExpressionRegular);

            if (_Regex.IsMatch(_Numeros))
            {
                _Result = true;
            }

            return _Result;
        }

        public bool ValidaCEP(string _CEP)
        {
            bool _Result = false;
            string _ExpressionRegular = @"^\d{5}\-?\d{3}$";

            Regex _Regex = new Regex(_ExpressionRegular);

            if (_Regex.IsMatch(_CEP))
            {
                _Result = true;
            }

            return _Result;
        }

        public bool ValidaIncricaoEstadual(string _InscEst)
        {
            bool _Result = false;
            string _ExpressionRegular = @"\\d{4}.\\d{4}.\\d{4}.\\d{4}";

            Regex _Regex = new Regex(_ExpressionRegular);

            if (_Regex.IsMatch(_InscEst))
            {
                _Result = true;
            }

            return _Result;
        }

        public bool ValidaFoneDDD(string _FoneDDD)
        {
            bool _Result = false;
            string _ExpressionRegular = @"\\d{4}";

            Regex _Regex = new Regex(_ExpressionRegular);

            if (_Regex.IsMatch(_FoneDDD))
            {
                _Result = true;
            }

            return _Result;
        }
        
    }
}
