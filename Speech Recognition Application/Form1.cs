using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Synthesis;
using System.Speech.Recognition;



namespace Speech_Recognition_Application
{ 
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                SpeechSynthesizer ss = new SpeechSynthesizer();
                ss.Volume = trackBar1.Value;
                ss.Speak(textBox1.Text);
            }
            else {
                MessageBox.Show("Please Write Something First");

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SpeechRecognitionEngine sr = new SpeechRecognitionEngine();
            Grammar word = new DictationGrammar();
            sr.LoadGrammar(word);
            try
            {
                textBox2.Text = "Listening Now...";
                sr.SetInputToDefaultAudioDevice();
                RecognitionResult result = sr.Recognize();
                textBox2.Clear();
                textBox2.Text = result.Text;
            }
            catch {
                textBox2.Text = "";
                MessageBox.Show("Mic Not Found");

            }
            finally
            {
                sr.UnloadAllGrammars();
            }

        }
    }
}
