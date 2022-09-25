using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Controles_Standar
{
    public class FComboBox : ComboBox
    {
        public FComboBox()
        {
            this.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormattingEnabled = true;
            this.Size = new System.Drawing.Size(128, 23);

            FunControles.DarFormatoComboBox(this);
        }
    }
}
