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
            _tuner.stopLoging();
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
