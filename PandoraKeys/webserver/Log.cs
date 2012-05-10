/*
 * Copyright (C) 2012 David W. Bullington, 
 * and individual contributors.
 *
 * This program is free software; you can redistribute it and/or
 * modify it under the terms of the GNU General Public License
 * as published by the Free Software Foundation; either version 3
 * of the License, or (at your option) any later version.
 * 
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with this program; if not, write to the Free Software
 * Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
 */
using System.Windows.Forms;

namespace PandoraKeys
{
    public partial class Log : Form
    {
        private Tuner _tuner;


        public void setTuner(Tuner tu)
        {
            _tuner = tu;

        }
        public Log()
        {
            InitializeComponent();
                       
        }

        private void Log_FormClosed(object sender, FormClosedEventArgs e)
        {
            _tuner.StopLogging();
        }
        public void LogText(string text)
        {
            if (this.Visible) textlog.Text += text;

        }

        private void Log_Resize(object sender, System.EventArgs e)
        {
            textlog.Width = this.Width -16;
            textlog.Height = this.Height -45;
        }

    }
}
