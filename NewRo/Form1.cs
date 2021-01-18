using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewRo
{
    public partial class Form1 : Form
    {
        Neuron neuron;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            neuron = new Neuron(0.5m);
            
            neuron.OnTrain += Neuron_OnTrain;
        }

        private void Neuron_OnTrain(object sender, decimal weight)
        {
            lblError.Text = $"Error: {(sender as Neuron).LastError}";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            neuron.ResetNeuron();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            neuron.Train(100m, 62.371m);
        }

        private void bOk_Click(object sender, EventArgs e)
        {
            if (!txtValue.Text.Equals(""))
            {
                var a = neuron.InputProcessData(Convert.ToDecimal(txtValue.Text.Trim()));
                lblResult.Text = a.ToString();
            }
        }

        private void bAutotrain_Click(object sender, EventArgs e)
        {
            timer1.Enabled = !timer1.Enabled;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            neuron.Train(100, 62.371m);
        }
    }
}
