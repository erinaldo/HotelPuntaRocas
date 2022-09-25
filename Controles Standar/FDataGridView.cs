using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Controles_Standar
{
    public class FDataGridView : DataGridView
    {
        public FDataGridView()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            string color = Controles_Standar.Properties.Resources.ColorTema;
            Color tema = Color.FromArgb(int.Parse(color.Substring(0, 3)), int.Parse(color.Substring(3, 3)), int.Parse(color.Substring(6, 3)));
            /*Asignaion de style*/
            this.AllowUserToAddRows = false;
            this.AllowUserToDeleteRows = false;
            this.EnableHeadersVisualStyles = false;
            this.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            this.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.ColumnHeadersHeight = 23;
            this.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            /**/
            this.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.BackgroundColor = System.Drawing.SystemColors.Window;
            this.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MultiSelect = false;
            this.ReadOnly = true;
            this.RowHeadersVisible = false;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.BackColor = Color.DimGray;
            dataGridViewCellStyle3.ForeColor = Color.White;
            dataGridViewCellStyle3.SelectionBackColor = tema;
            this.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;

            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.SelectionBackColor = tema;
            dataGridViewCellStyle2.SelectionForeColor = Color.White;
            this.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;

        }
    }
}
