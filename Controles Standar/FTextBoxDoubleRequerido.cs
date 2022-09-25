using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Controles_Standar
{
    public class FTextBoxDoubleRequerido : FTextBoxRequerido
    {
        public FTextBoxDoubleRequerido()
        {
            this.Validated += new System.EventHandler(this.FTextBoxDouble_Validated);
        }

        private void FTextBoxDouble_Validated(object sender, EventArgs e)
        {
            try
            {
                this.Text = Convert.ToDouble(this.Text).ToString("0.00");
            }
            catch
            {
                this.Text = "0.00";
            }
        }
    }
}
