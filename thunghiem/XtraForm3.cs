using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.Speech.Recognition;
using System.Globalization;

namespace unzipPackage.thunghiem
{
    public partial class XtraForm3 : DevExpress.XtraEditors.XtraForm
    {
        public XtraForm3()
        {
            InitializeComponent();
        }
        SpeechRecognitionEngine sre;
        private void XtraForm3_Load(object sender, EventArgs e)
        {
            // Create a new SpeechRecognitionEngine instance.
            sre = new SpeechRecognitionEngine(new CultureInfo("en-GB"));

            // Create a simple grammar that recognizes “red”, “green”, or “blue”.
            Choices colors = new Choices();
            colors.Add("red");
            colors.Add("green");
            colors.Add("blue");

            GrammarBuilder gb = new GrammarBuilder();
            gb.Append(colors);

            // Create the actual Grammar instance, and then load it into the speech recognizer.
            Grammar g = new Grammar(gb);
            sre.LoadGrammar(g);

            // Register a handler for the SpeechRecognized event.
            sre.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(sre_SpeechRecognized);
            sre.SetInputToDefaultAudioDevice();
            sre.RecognizeAsync(RecognizeMode.Multiple);
        }
        void sre_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            MessageBox.Show("Speech recognized: " + e.Result.Text);
        }
    }
}