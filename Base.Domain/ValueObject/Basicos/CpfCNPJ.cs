using Flunt.Notifications;
using Flunt.Validations;

namespace Base.Domain.ValueObject.Basicos
{
    public class CpfCNPJ : Notifiable
    {
        public string Documento { get; private set; }

        public CpfCNPJ(string documento)
        {
            Documento = documento;
            Validar();
        }

        public void Validar()
        {
            AddNotifications(
             new Contract()
               .Requires()
               .IsTrue(ValidacaoInterna(Documento), "Documento", "CPF/CNPJ inválido.")
           );
        }

        private bool ValidacaoInterna(string documento)
        {
            if (string.IsNullOrWhiteSpace(documento))
                return false;

            var _doc = RemoverPontos(documento);

            if (_doc.Length == 14)
            {
                return IsCNPJ(_doc); ;
            }
            else
            {
                return IsCPF(_doc);
            }
        }

        private string RemoverPontos(string cnpj)
        {
            if (cnpj.Length > 0)
            {
                return cnpj.Replace(".", "").Replace("/", "").Replace("-", "").Trim();
            }

            return "";
        }

        private bool IsCNPJ(string cnpj)
        {
            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma;
            int resto;
            string digito;
            string tempCnpj;

            cnpj = cnpj.Trim();
            cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");

            if (cnpj.Length != 14)
            {
                return false;
            }

            if (cnpj.Equals("0".PadLeft(14, '0')) ||
                 cnpj.Equals("1".PadLeft(14, '1')) ||
                 cnpj.Equals("2".PadLeft(14, '2')) ||
                 cnpj.Equals("3".PadLeft(14, '3')) ||
                 cnpj.Equals("4".PadLeft(14, '4')) ||
                 cnpj.Equals("5".PadLeft(14, '5')) ||
                 cnpj.Equals("6".PadLeft(14, '6')) ||
                 cnpj.Equals("7".PadLeft(14, '7')) ||
                 cnpj.Equals("8".PadLeft(14, '8')) ||
                 cnpj.Equals("9".PadLeft(14, '9'))
                 )
            {
                return false;
            }

            tempCnpj = cnpj.Substring(0, 12);
            soma = 0;

            for (int i = 0; i < 12; i++)
            {
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];
            }

            resto = (soma % 11);

            if (resto < 2)
            {
                resto = 0;
            }
            else
            {
                resto = 11 - resto;
            }

            digito = resto.ToString();
            tempCnpj = tempCnpj + digito;
            soma = 0;

            for (int i = 0; i < 13; i++)
            {
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
            }

            resto = (soma % 11);

            if (resto < 2)
            {
                resto = 0;
            }
            else
            {
                resto = 11 - resto;
            }

            digito = digito + resto.ToString();

            return cnpj.EndsWith(digito);
        }

        private bool IsCPF(string cpf)
        {
            if (cpf == null)
            {
                return false;
            }

            if (cpf.Equals("0".PadLeft(11, '0')) ||
                 cpf.Equals("1".PadLeft(11, '1')) ||
                 cpf.Equals("2".PadLeft(11, '2')) ||
                 cpf.Equals("3".PadLeft(11, '3')) ||
                 cpf.Equals("4".PadLeft(11, '4')) ||
                 cpf.Equals("5".PadLeft(11, '5')) ||
                 cpf.Equals("6".PadLeft(11, '6')) ||
                 cpf.Equals("7".PadLeft(11, '7')) ||
                 cpf.Equals("8".PadLeft(11, '8')) ||
                 cpf.Equals("9".PadLeft(11, '9'))
                 )
            {
                return false;
            }

            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11 || cpf.Equals("00000000000"))
                return false;
            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cpf.EndsWith(digito);
        }
    }
}
