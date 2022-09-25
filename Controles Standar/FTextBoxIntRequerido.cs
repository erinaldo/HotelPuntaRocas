using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Controles_Standar
{
    public class FTextBoxIntRequerido : FTextBoxRequerido
    {
        public FTextBoxIntRequerido()
        {
            this.Validated += new System.EventHandler(this.FTextBoxInt_Validated);
        }

        private void FTextBoxInt_Validated(object sender, EventArgs e)
        {
            try
            {
                this.Text = Convert.ToDouble(this.Text).ToString();
            }
            catch
            {
                this.Text = "0";
            }
        }
    }
}
