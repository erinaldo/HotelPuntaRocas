using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Controles_Standar
{
    public class FCheckBox : CheckBox
    {
        public FCheckBox()
        {
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Transparent;
            this.FlatAppearance.BorderSize = 0;
            this.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.Size = new System.Drawing.Size(82, 19);
            this.UseVisualStyleBackColor = false;

            FunControles.DarFormatoCheckBox(this);
        }
    }
}
