using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace BlazorCRUDApp.Data
{
    public class Cliente
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage ="Nome Obrigatório")]
        [MaxLength(30)]
        public string Name  { get; set; }

        [Required(ErrorMessage = "Sobrenome Obrigatório")]
        [MaxLength(30)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Dados Obrigatórios")]
        [ValidChars(ValidChars: "-.0123456789", ErrorMessage = "Só pontos e números são permitidos")]
        [ValidCpf(ErrorMessage = "Número de CPF ou CNPJ incorreto")]
        
        public  string CpfCnpj { get; set; }

        [Required(ErrorMessage = "Informar e-mail válido")]
        [EmailAddress(ErrorMessage = "Esse endereço de e-mail não é valido.")]
        public string Email { get; set; }


    }

    public class ValidChars: ValidationAttribute
    {
        private readonly string valChars;

        public ValidChars (string ValidChars)
        {
            this.valChars = ValidChars;
        }

        public override bool IsValid(object value)
        {
            if (value == null) { return false; };

            string w = value.ToString();

            for (int i = 0; i < w.Length; i++)
            {
                if (!valChars.Contains(w[i])) { return false; }
            }

            return true;
        }
    }

    public  class ValidCpf : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null) return false;

            string w = value.ToString().Replace(".", "").Replace("-", "");  //  Clear points and hifens

            if (!w.All(char.IsDigit)) return false;                       //  Somente numeros ?
            if (w.Length != 11) return false;                       //  Numero de caracteres valido ?

            //--------------------- Primeiro digito de controle ------------------------------------------------------------
            if (w[9] != CalculaDigito(w, 9)) return false;                 //  Primeiro digito de controle valido ?

            //--------------------- Segundo digito de controle --------------------------------------------------------------
            if (w[10] != CalculaDigito(w, 10)) return false;              //  Segundo digito de controle valido ?  

            return true;                                                    //  Verification digits matched                                  
        }
        public char CalculaDigito(string w, int DigitNumber)
        {
            int Digit = 0;
            for (int i = 0; i < DigitNumber; i++)                           //  Transforma char em binario                                                                         
            { Digit += (w[i] - '0') * (DigitNumber + 1 - i); }          //  w[i] - '0' =  Convert.ToInt32(w[i].ToString()) 

            Digit = (11 - (Digit %= 11)) > 9 ? 0 : (11 - (Digit %= 11));  //  11 - Resto da divisão por 11. Se for maior que 9 ==> digito = 0

            return (char)(Digit + '0');                                    //  Transforma em Ascii : ex 0 em Ascii é 48 binario
        }
    }

}