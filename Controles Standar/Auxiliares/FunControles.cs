using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ErrP = System.Windows.Forms.ErrorProvider;
using SendKey = System.Windows.Forms.SendKeys;
using System.Windows.Forms;
using System.Drawing;

namespace Controles_Standar
{
    public class FunControles
    {
        private static ErrP ErrorP = new ErrP();
        static string color = Properties.Resources.ColorTema;
        static Color tema = Color.FromArgb(int.Parse(color.Substring(0, 3)), int.Parse(color.Substring(3, 3)), int.Parse(color.Substring(6, 3)));

        public static void DarFormatoTextBox(FTextBoxRequerido txt, bool validar, bool ToUpper)
        {
            txt.GotFocus += conFoco;
            txt.LostFocus += sinFoco;
            txt.ReadOnlyChanged += conReadOnly;
            if (validar)
                txt.Validating += Validando;
            txt.KeyPress += SiguienteControl;
            txt.TextChanged += Change;
            if(ToUpper)
                txt.CharacterCasing = CharacterCasing.Upper; 
        }

        public static void DarFormatoTextBox(FTextBox txt, bool validar, bool ToUpper)
        {
            txt.GotFocus += conFoco;
            txt.LostFocus += sinFoco;
            txt.ReadOnlyChanged += conReadOnly;
            if (validar)
                txt.Validating += Validando;
            txt.KeyPress += SiguienteControl;
            txt.TextChanged += Change;
            if (ToUpper)
                txt.CharacterCasing = CharacterCasing.Upper;
        }

        public static void DarFormatoMaskedTextBox(FMaskedTextBoxRequerido txt, bool validar)
        {
            txt.GotFocus += conFoco;
            txt.LostFocus += sinFoco;
            txt.ReadOnlyChanged += conReadOnly;
            if (validar)
                txt.Validating += Validando;
            txt.KeyPress += SiguienteControl;
            txt.TextChanged += Change;
        }

        public static void DarFormatoMaskedTextBox(FMaskedTextBox txt, bool validar)
        {
            txt.GotFocus += conFoco;
            txt.LostFocus += sinFoco;
            txt.ReadOnlyChanged += conReadOnly;
            if (validar)
                txt.Validating += Validando;
            txt.KeyPress += SiguienteControl;
            txt.TextChanged += Change;
        }

        public static void DarFormatoCheckBox(FCheckBox txt)
        {            
            txt.KeyPress += SiguienteControl;
        }

        public static void DarFormatoComboBox(FComboBox txt)
        {
            txt.KeyPress += SiguienteControl;
        }

        public static void DarFormatoDateTimePicker(FDateTimePicker txt)
        {
            txt.KeyPress += SiguienteControl;
        }

        public static void DarFormatoRadioButton(FRadioButton txt)
        {
            txt.KeyPress += SiguienteControl;
        }

        public static void DarFormatoCheckedListBox(FCheckedListBox txt)
        {
            txt.KeyPress += SiguienteControl;
        }

        public static void DarFormatoListBox(FListBox txt)
        {
            txt.KeyPress += SiguienteControl;
        }
        public static void DarFormatoTreeView(FTreeView txt)
        {
            txt.KeyPress += SiguienteControl;
        }

        private static void conReadOnly(object sender, EventArgs e)
        {
            if (sender.GetType() == typeof(FTextBox))
            {
                if (((FTextBox)sender).ReadOnly == false)
                    ((FTextBox)sender).BackColor = SystemColors.Window;                    
                else
                    ((FTextBox)sender).BackColor = SystemColors.Control;
                ((FTextBox)sender).TabStop = !((FTextBox)sender).ReadOnly;
            }
            if (sender.GetType() == typeof(FMaskedTextBox))
            {
                if (((FMaskedTextBox)sender).ReadOnly == false)
                    ((FMaskedTextBox)sender).BackColor = SystemColors.Window;
                else
                    ((FMaskedTextBox)sender).BackColor = SystemColors.Control;
                ((FMaskedTextBox)sender).TabStop = !((FMaskedTextBox)sender).ReadOnly;
            }
            if (sender.GetType() == typeof(FTextBoxInt))
            {
                if (((FTextBoxInt)sender).ReadOnly == false)
                    ((FTextBoxInt)sender).BackColor = SystemColors.Window;
                else
                    ((FTextBoxInt)sender).BackColor = SystemColors.Control;
                ((FTextBoxInt)sender).TabStop = !((FTextBoxInt)sender).ReadOnly;
            }
            if (sender.GetType() == typeof(FTextBoxDouble))
            {
                if (((FTextBoxDouble)sender).ReadOnly == false)
                    ((FTextBoxDouble)sender).BackColor = SystemColors.Window;
                else
                    ((FTextBoxDouble)sender).BackColor = SystemColors.Control;
                ((FTextBoxDouble)sender).TabStop = !((FTextBoxDouble)sender).ReadOnly;
            }
            if (sender.GetType() == typeof(FTextBoxRequerido))
            {
                if (((FTextBoxRequerido)sender).ReadOnly == false)
                    ((FTextBoxRequerido)sender).BackColor = SystemColors.Window;
                else
                    ((FTextBoxRequerido)sender).BackColor = SystemColors.Control;
                ((FTextBoxRequerido)sender).TabStop = !((FTextBoxRequerido)sender).ReadOnly;
            }
            if (sender.GetType() == typeof(FMaskedTextBoxRequerido))
            {
                if (((FMaskedTextBoxRequerido)sender).ReadOnly == false)
                    ((FMaskedTextBoxRequerido)sender).BackColor = SystemColors.Window;
                else
                    ((FMaskedTextBoxRequerido)sender).BackColor = SystemColors.Control;
                ((FMaskedTextBoxRequerido)sender).TabStop = !((FMaskedTextBoxRequerido)sender).ReadOnly;
            }
            if (sender.GetType() == typeof(FTextBoxIntRequerido))
            {
                if (((FTextBoxIntRequerido)sender).ReadOnly == false)
                    ((FTextBoxIntRequerido)sender).BackColor = SystemColors.Window;
                else
                    ((FTextBoxIntRequerido)sender).BackColor = SystemColors.Control;
                ((FTextBoxIntRequerido)sender).TabStop = !((FTextBoxIntRequerido)sender).ReadOnly;
            }
            if (sender.GetType() == typeof(FTextBoxDoubleRequerido))
            {
                if (((FTextBoxDoubleRequerido)sender).ReadOnly == false)
                    ((FTextBoxDoubleRequerido)sender).BackColor = SystemColors.Window;
                else
                    ((FTextBoxDoubleRequerido)sender).BackColor = SystemColors.Control;
                ((FTextBoxDoubleRequerido)sender).TabStop = !((FTextBoxDoubleRequerido)sender).ReadOnly;
            }
        }

        private static void conFoco(object sender, EventArgs e)
        {
            if (sender.GetType() == typeof(FTextBox))
            {
                if (((FTextBox)sender).ReadOnly == false)
                {
                    ((FTextBox)sender).BackColor = tema;
                    ((FTextBox) sender).ForeColor = Color.White;
                }
                else
                {
                    ((FTextBox)sender).BackColor = SystemColors.Control;
                    ((FTextBox)sender).ForeColor = Color.Black;
                }
            }
            if (sender.GetType() == typeof(FMaskedTextBox))
            {
                if (((FMaskedTextBox)sender).ReadOnly == false)
                {
                    ((FMaskedTextBox)sender).BackColor = tema;
                    ((FMaskedTextBox)sender).ForeColor = Color.White;
                }
                else
                {
                    ((FMaskedTextBox)sender).BackColor = SystemColors.Control;
                    ((FMaskedTextBox)sender).ForeColor = Color.Black;
                }
            }
            if (sender.GetType() == typeof(FTextBoxInt))
            {
                if (((FTextBoxInt)sender).ReadOnly == false)
                {
                    ((FTextBoxInt)sender).BackColor = tema;
                    ((FTextBoxInt)sender).ForeColor = Color.White;
                }
                else
                {
                    ((FTextBoxInt)sender).BackColor = SystemColors.Control;
                    ((FTextBoxInt)sender).ForeColor = Color.Black;
                }
            }
            if (sender.GetType() == typeof(FTextBoxDouble))
            {
                if (((FTextBoxDouble)sender).ReadOnly == false)
                {
                    ((FTextBoxDouble)sender).BackColor = tema;
                    ((FTextBoxDouble)sender).ForeColor = Color.White;
                }
                else
                {
                    ((FTextBoxDouble)sender).BackColor = SystemColors.Control;
                    ((FTextBoxDouble)sender).ForeColor = Color.Black;
                }
            }
            if (sender.GetType() == typeof(FTextBoxRequerido))
            {
                if (((FTextBoxRequerido)sender).ReadOnly == false)
                {
                    ((FTextBoxRequerido)sender).BackColor = tema;
                    ((FTextBoxRequerido)sender).ForeColor = Color.White;
                }
                else
                {
                    ((FTextBoxRequerido)sender).BackColor = SystemColors.Control;
                    ((FTextBoxRequerido)sender).ForeColor = Color.Black;
                }
            }
            if (sender.GetType() == typeof(FMaskedTextBoxRequerido))
            {
                if (((FMaskedTextBoxRequerido)sender).ReadOnly == false)
                {
                    ((FMaskedTextBoxRequerido)sender).BackColor = tema;
                    ((FMaskedTextBoxRequerido)sender).ForeColor = Color.White;
                }
                else
                {
                    ((FMaskedTextBoxRequerido)sender).BackColor = SystemColors.Control;
                    ((FMaskedTextBoxRequerido)sender).ForeColor = Color.Black;
                }
            }
            if (sender.GetType() == typeof(FTextBoxIntRequerido))
            {
                if (((FTextBoxIntRequerido)sender).ReadOnly == false)
                {
                    ((FTextBoxIntRequerido)sender).BackColor = tema;
                    ((FTextBoxIntRequerido)sender).ForeColor = Color.White;
                }
                else
                {
                    ((FTextBoxIntRequerido)sender).BackColor = SystemColors.Control;
                    ((FTextBoxIntRequerido)sender).ForeColor = Color.Black;
                }
            }
            if (sender.GetType() == typeof(FTextBoxDoubleRequerido))
            {
                if (((FTextBoxDoubleRequerido)sender).ReadOnly == false)
                {
                    ((FTextBoxDoubleRequerido)sender).BackColor = tema;
                    ((FTextBoxDoubleRequerido)sender).ForeColor = Color.White;
                }
                else
                {
                    ((FTextBoxDoubleRequerido)sender).BackColor = SystemColors.Control;
                    ((FTextBoxDoubleRequerido)sender).ForeColor = Color.Black;
                }
            }
        }

        private static void sinFoco(object sender, EventArgs e)
        {
            if (sender.GetType() == typeof(FTextBox))
            {
                if (((FTextBox)sender).ReadOnly == false)
                {
                    ((FTextBox)sender).BackColor = SystemColors.Window;
                    ((FTextBox)sender).ForeColor = Color.Black;
                }
                else
                {
                    ((FTextBox)sender).BackColor = SystemColors.Control;
                    ((FTextBox)sender).ForeColor = Color.Black;
                }
            }
            if (sender.GetType() == typeof(FMaskedTextBox))
            {
                if (((FMaskedTextBox)sender).ReadOnly == false)
                {
                    ((FMaskedTextBox)sender).BackColor = SystemColors.Window;
                    ((FMaskedTextBox)sender).ForeColor = Color.Black;
                }
                else
                {
                    ((FMaskedTextBox)sender).BackColor = SystemColors.Control;
                    ((FMaskedTextBox)sender).ForeColor = Color.Black;
                }
            }
            if (sender.GetType() == typeof(FTextBoxInt))
            {
                if (((FTextBoxInt)sender).ReadOnly == false)
                {
                    ((FTextBoxInt)sender).BackColor = SystemColors.Window;
                    ((FTextBoxInt)sender).ForeColor = Color.Black;
                }
                else
                {
                    ((FTextBox)sender).BackColor = SystemColors.Control;
                    ((FTextBox)sender).ForeColor = Color.Black;
                }
            }
            if (sender.GetType() == typeof(FTextBoxDouble))
            {
                if (((FTextBoxDouble)sender).ReadOnly == false)
                {
                    ((FTextBoxDouble)sender).BackColor = SystemColors.Window;
                    ((FTextBoxDouble)sender).ForeColor = Color.Black;
                }
                else
                {
                    ((FTextBoxDouble)sender).BackColor = SystemColors.Control;
                    ((FTextBoxDouble)sender).ForeColor = Color.Black;
                }
            }
            if (sender.GetType() == typeof(FTextBoxRequerido))
            {
                if (((FTextBoxRequerido)sender).ReadOnly == false)
                {
                    ((FTextBoxRequerido)sender).BackColor = SystemColors.Window;
                    ((FTextBoxRequerido)sender).ForeColor = Color.Black;
                }
                else
                {
                    ((FTextBoxRequerido)sender).BackColor = SystemColors.Control;
                    ((FTextBoxRequerido)sender).ForeColor = Color.Black;
                }
            }
            if (sender.GetType() == typeof(FMaskedTextBoxRequerido))
            {
                if (((FMaskedTextBoxRequerido)sender).ReadOnly == false)
                {
                    ((FMaskedTextBoxRequerido)sender).BackColor = SystemColors.Window;
                    ((FMaskedTextBoxRequerido)sender).ForeColor = Color.Black;
                }
                else
                {
                    ((FMaskedTextBoxRequerido)sender).BackColor = SystemColors.Control;
                    ((FMaskedTextBoxRequerido)sender).ForeColor = Color.Black;
                }
            }
            if (sender.GetType() == typeof(FTextBoxIntRequerido))
            {
                if (((FTextBoxIntRequerido)sender).ReadOnly == false)
                {
                    ((FTextBoxIntRequerido)sender).BackColor = SystemColors.Window;
                    ((FTextBoxIntRequerido)sender).ForeColor = Color.Black;
                }
                else
                {
                    ((FTextBoxIntRequerido)sender).BackColor = SystemColors.Control;
                    ((FTextBoxIntRequerido)sender).ForeColor = Color.Black;
                }
            }
            if (sender.GetType() == typeof(FTextBoxDoubleRequerido))
            {
                if (((FTextBoxDoubleRequerido)sender).ReadOnly == false)
                {
                    ((FTextBoxDoubleRequerido)sender).BackColor = SystemColors.Window;
                    ((FTextBoxDoubleRequerido)sender).ForeColor = Color.Black;
                }
                else
                {
                    ((FTextBoxDoubleRequerido)sender).BackColor = SystemColors.Control;
                    ((FTextBoxDoubleRequerido)sender).ForeColor = Color.Black;
                }
            }
        }

        private static void Validando(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (sender.GetType() == typeof(FTextBoxRequerido))
            {
                if (((FTextBoxRequerido)sender).Text.Length == 0 && ((FTextBoxRequerido)sender).ReadOnly == false)
                {
                    ErrorP.BlinkRate = 200;
                    ErrorP.BlinkStyle = ErrorBlinkStyle.AlwaysBlink;
                    ErrorP.SetError((FTextBoxRequerido)sender, "Un dato es requerido aquí");
                    ((FTextBoxRequerido)sender).Focus();
                }
                else
                {
                    ErrorP.SetError((FTextBoxRequerido)sender, "");
                }
            }
            if (sender.GetType() == typeof(FMaskedTextBoxRequerido))
            {
                if (((FMaskedTextBoxRequerido)sender).Text.Length == 0 && ((FMaskedTextBoxRequerido)sender).ReadOnly == false)
                {
                    ErrorP.BlinkRate = 200;
                    ErrorP.BlinkStyle = ErrorBlinkStyle.AlwaysBlink;
                    ErrorP.SetError((FMaskedTextBoxRequerido)sender, "Un dato es requerido aquí");
                    ((FMaskedTextBoxRequerido)sender).Focus();
                }
                else
                {
                    ErrorP.SetError((FMaskedTextBoxRequerido)sender, "");
                }
            }
        }

        private static void SiguienteControl(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                SendKey.Send("{tab}");
            }
        }

        private static void Change(object sender, System.EventArgs e)
        {
            if (sender.GetType() == typeof(FTextBoxRequerido))
            {
                if (((FTextBoxRequerido)sender).Text.Length > 0)
                {
                    ErrorP.SetError((FTextBoxRequerido)sender, "");
                }
            }
            if (sender.GetType() == typeof(FMaskedTextBoxRequerido))
            {
                if (((FMaskedTextBoxRequerido)sender).Text.Length > 0)
                {
                    ErrorP.SetError((FMaskedTextBoxRequerido)sender, "");
                }
            }
        }
    }
}
