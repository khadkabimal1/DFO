using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Data.OleDb;
using System.Configuration;
using System.IO;

namespace school_management_system
{
    class Class1
    {

        public static void DecimalNumberOnly(ref TextBox textBox, ref KeyEventArgs e)
        {
            if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
            {
                if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
                {
                    if (e.KeyCode == Keys.Back)
                        e.SuppressKeyPress = false;
                    else if (e.KeyCode == Keys.Delete)
                        e.SuppressKeyPress = false;
                    else if (e.KeyCode == Keys.Left)
                        e.SuppressKeyPress = false;
                    else if (e.KeyCode == Keys.Right)
                        e.SuppressKeyPress = false;
                    else if (e.KeyCode == Keys.Home)
                        e.SuppressKeyPress = false;
                    else if (e.KeyCode == Keys.End)
                        e.SuppressKeyPress = false;
                    else if (e.KeyCode == Keys.Home && e.Shift)
                        e.SuppressKeyPress = false;
                    else if (e.KeyCode == Keys.End && e.Shift)
                        e.SuppressKeyPress = false;
                    else if (e.KeyCode == Keys.C && e.Control)
                        e.SuppressKeyPress = false;
                    else if (e.KeyCode == Keys.OemPeriod)
                        e.SuppressKeyPress = false;
                    else if (e.KeyCode == Keys.Decimal)
                        e.SuppressKeyPress = false;
                    else if (e.KeyCode == Keys.F4 && e.Alt)
                        e.SuppressKeyPress = false;
                    else
                        e.SuppressKeyPress = true;
                }
            }
            if (textBox.Text.Length == 0 && (e.KeyCode == Keys.Decimal || e.KeyCode == Keys.OemPeriod))
                e.SuppressKeyPress = true;
            if (textBox.Text.IndexOf('.') > 0 && (e.KeyCode == Keys.Decimal || e.KeyCode == Keys.OemPeriod))
                e.SuppressKeyPress = true;
        }
        
        public static void NumberOnly(ref TextBox textBox, ref KeyEventArgs e)
        {
            if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
            {
                if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
                {
                    if (e.KeyCode == Keys.Back)
                        e.SuppressKeyPress = false;
                    else if (e.KeyCode == Keys.Delete)
                        e.SuppressKeyPress = false;
                    else if (e.KeyCode == Keys.Left)
                        e.SuppressKeyPress = false;
                    else if (e.KeyCode == Keys.Right)
                        e.SuppressKeyPress = false;
                    else if (e.KeyCode == Keys.Home)
                        e.SuppressKeyPress = false;
                    else if (e.KeyCode == Keys.End)
                        e.SuppressKeyPress = false;
                    else if (e.KeyCode == Keys.Home && e.Shift)
                        e.SuppressKeyPress = false;
                    else if (e.KeyCode == Keys.End && e.Shift)
                        e.SuppressKeyPress = false;
                    else if (e.KeyCode == Keys.C && e.Control)
                        e.SuppressKeyPress = false;
                    else if (e.KeyCode == Keys.F4 && e.Alt)
                        e.SuppressKeyPress = false;
                    else
                        e.SuppressKeyPress = true;
                }
            }
        }
    }
}
