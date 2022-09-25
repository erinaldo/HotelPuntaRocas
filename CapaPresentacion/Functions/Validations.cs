using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Controles_Standar;

namespace CapaPresentacion.Functions
{
    public class Validations
    {
        public static void GrillaReadOnly(FDataGridView Grilla)
        {
            Grilla.ReadOnly = false;
            for (int i = 0; i < Grilla.ColumnCount; i++)
            {
                Grilla.Columns[i].ReadOnly = true;
            }
        } 

        public static bool IsLetters(string sCaracteres)
        {
            return sCaracteres.Any(ch => ch == 46) || sCaracteres.All(ch => Char.IsLetter(ch) || ch == 32);
        }

        public static bool OnlyNumbers(KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = true;
            }
            return e.Handled;
        }

        static Regex ValidEmailRegex = CreateValidEmailRegex;

        /// <summary>
        /// Taken from http://haacked.com/archive/2007/08/21/i-knew-how-to-validate-an-email-address-until-i.aspx
        /// </summary>
        /// <returns></returns>
        private static Regex CreateValidEmailRegex
        {
            get
            {
                string validEmailPattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
                    + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)"
                    + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";

                return new Regex(validEmailPattern, RegexOptions.IgnoreCase);
            }
        }

        public static bool EmailIsValid(string emailAddress)
        {
            bool isValid = ValidEmailRegex.IsMatch(emailAddress);

            return isValid;
        }

        public static bool OnlyDecimal(object sender, KeyPressEventArgs e, char cSymbol)
        {
            e.Handled = false || !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != cSymbol;

            var textBox = sender as TextBox;
            if (textBox != null && (e.KeyChar == cSymbol && textBox.Text.IndexOf(cSymbol) > -1))
            {
                e.Handled = true;
            }
            return e.Handled;
        }
    }
}
