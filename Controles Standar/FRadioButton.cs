using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Controles_Standar
{
    public class FRadioButton : RadioButton
    {
        public FRadioButton()
        {
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Size = new System.Drawing.Size(94, 19);
            this.TabStop = true;
            this.UseVisualStyleBackColor = false;

            FunControles.DarFormatoRadioButton(this);
        }
    }
}
