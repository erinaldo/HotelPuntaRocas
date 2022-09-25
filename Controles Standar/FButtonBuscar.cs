using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Controles_Standar
{
    public class FButtonBuscar : Button
    {
        public FButtonBuscar()
        {
            this.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Image = global::Controles_Standar.Properties.Resources.search;
            this.Size = new System.Drawing.Size(90, 34);
            this.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.UseVisualStyleBackColor = true;
        }
    }
}
