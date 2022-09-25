using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Controles_Standar
{
    public class FTextBox : TextBox
    {
        public FTextBox()
        {
            this.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Size = new System.Drawing.Size(144, 20);
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            FunControles.DarFormatoTextBox(this, false, false);
        }
    }
}
