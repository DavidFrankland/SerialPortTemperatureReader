using System;
using System.Windows.Forms;
using WindowsFormsDisplay.TemperatureService;

namespace WindowsFormsDisplay
{
    public partial class MainForm : Form
    {
        private readonly ITemperatureService temperatureService = new TemperatureServiceClient();

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
        }

        private void DisplayTimer_Tick(object sender, EventArgs e)
        {
            var temperature = temperatureService.GetTemperature();
            TemperatureLabel.Text = temperature == null ? "---" : string.Format("{0:F1}°C", temperature);
        }
    }
}
