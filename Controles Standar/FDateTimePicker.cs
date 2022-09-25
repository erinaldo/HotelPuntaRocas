using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Controles_Standar
{
    public class FDateTimePicker : DateTimePicker
    {
        public FDateTimePicker()
        {
            this.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.Size = new System.Drawing.Size(128, 23);

            FunControles.DarFormatoDateTimePicker(this);
        }
    }
}
