namespace cal
{
    public partial class Form1 : Form
    {
        bool rezTablo = true;
        char diya = ' ';
        int operationRun = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void off_Click(object sender, EventArgs e)
        {
            Close();
        }

        void AddToScoreboard(char character)
        {
            if (rezTablo) textTablo.Text = "";
            if (textTablo.Text == "0") textTablo.Text = " ";
            textTablo.Text += $"{character}";
            rezTablo = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddToScoreboard('1');
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddToScoreboard('2');
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddToScoreboard('3');
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AddToScoreboard('4');
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AddToScoreboard('5');
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AddToScoreboard('6');
        }

        private void button7_Click(object sender, EventArgs e)
        {
            AddToScoreboard('7');
        }

        private void button8_Click(object sender, EventArgs e)
        {
            AddToScoreboard('8');
        }

        private void button9_Click(object sender, EventArgs e)
        {
            AddToScoreboard('9');
        }

        private void button10_Click(object sender, EventArgs e)
        {
            AddToScoreboard('0');
        }

        private void buttonComa_Click(object sender, EventArgs e)
        {
            bool oneComa = false;
            int tabloNum = textTablo.Text.Length;

            if (rezTablo) textTablo.Text = "";

            for (int i = 0; i < tabloNum; i++)
                if (textTablo.Text[i] == ',')
                {
                    oneComa = true;
                    break;
                }

            if (!oneComa) textTablo.Text += ",";
            rezTablo = false;
        }

        private void buttonC_Click(object sender, EventArgs e)
        {
            textTablo.Text = $"{0}";
            diya = ' ';
            operationRun = 0;
        }

        private void backSpace_Click(object sender, EventArgs e)
        {
            if (rezTablo) textTablo.Text = "0";
            else if (textTablo.Text[textTablo.Text.Length - 1] == diya)
            {
                diya = ' ';
                operationRun = 0;
                textTablo.Text = textTablo.Text.Substring(0, textTablo.Text.Length - 1);
            }
            else textTablo.Text = textTablo.Text.Substring(0, textTablo.Text.Length - 1);
            if (textTablo.Text == "") textTablo.Text = "0";
            rezTablo = false;
        }

        private void memoryOpetarion(string m)
        {
            double tablo, memory;
            try
            {
                tablo = Convert.ToDouble(textTablo.Text);
                memory = Convert.ToDouble(textMemory.Text);
            }
            catch (System.FormatException)
            {
                MessageBox.Show("Error", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textTablo.Text = $"{0}";
                textMemory.Text = $"{0}";
                return;
            }

            switch (m)
            {
                case "MS":
                    memory = tablo;
                    break;

                case "MC":
                    memory = 0;
                    break;

                case "M+":
                    memory += tablo;
                    break;

                case "M-":
                    memory -= tablo;
                    break;
            }

            textMemory.Text = $"{memory}";
            rezTablo = true;
        }

        private void writeMemory(string a)
        {
            if (textTablo.Text[textTablo.Text.Length - 1] == diya)
            {
                diya = ' ';
                operationRun = 0;
                textTablo.Text = textTablo.Text.Substring(0, textTablo.Text.Length - 1);
                memoryOpetarion(a);
            }
            else memoryOpetarion(a);
        } 

        private void buttonMS_Click(object sender, EventArgs e)
        {
            writeMemory("MS");
        }

        private void buttonMC_Click(object sender, EventArgs e)
        {
            writeMemory("MC");
        }

        private void buttonMPlus_Click(object sender, EventArgs e)
        {
            writeMemory("M+");
        }

        private void buttonMMinus_Click(object sender, EventArgs e)
        {
            writeMemory("M-");
        }

        private void operation(string operation)
        {
            double tablo;

            if (operation == "") return;

            try
            {
                tablo = Convert.ToDouble(textTablo.Text);
            }
            catch (System.FormatException)
            {
                textTablo.Text = "Error";
                return;
            }

            switch (operation)
            {
                case "sqrt":
                    if (tablo < 0)
                    {
                        MessageBox.Show("Error", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    tablo = Math.Sqrt(tablo);
                    break;

                case "%":
                    tablo *= 0.01;
                    break;

                case "1/x":
                    if (tablo == 0)
                    {
                        MessageBox.Show("Error", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    tablo = 1 / tablo;
                    break;

                case "x^2":
                    tablo = Math.Pow(tablo, 2);
                    break;

                case "lg":
                    tablo = Math.Log10(tablo);
                    break;

                case "+/-":
                    tablo *= -1;
                    break;
            }
            textTablo.Text = $"{tablo}";
            rezTablo = true;
        }

        private void buttonSqrt_Click(object sender, EventArgs e)
        {
            operation("sqrt");
        }

        private void buttonProcent_Click(object sender, EventArgs e)
        {
            operation("%");
        }

        private void buttonXdilOne_Click(object sender, EventArgs e)
        {
            operation("1/x");
        }

        private void button11_Click(object sender, EventArgs e)
        {
            operation("+/-");
        }

        private void buttonXTwo_Click(object sender, EventArgs e)
        {
            operation("x^2");
        }

        private void buttonLg_Click(object sender, EventArgs e)
        {
            operation("lg");
        }

        private void operationSearch()
        {
            if (operationRun == 2)
            {
                string a1 = "";
                string a2 = "";
                double rez = 0;

                for (int i = 0; i < textTablo.Text.Length; i++)
                    if (textTablo.Text[i] == diya)
                    {
                        for (int j = 0; j < i; j++) a1 += textTablo.Text[j];
                        for (int j = i + 1; j < textTablo.Text.Length; j++) a2 += textTablo.Text[j];
                        break;
                    }

                if (diya == '+') rez = Convert.ToDouble(a1) + Convert.ToDouble(a2);
                if (diya == '-') rez = Convert.ToDouble(a1) - Convert.ToDouble(a2);
                if (diya == '*') rez = Convert.ToDouble(a1) * Convert.ToDouble(a2);
                if (diya == '/')
                {
                    if (a1 == $"{0}" || a2 == $"{0}")
                    {
                        MessageBox.Show("Error", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textTablo.Text = $"{0}";
                        return;
                    }
                    else rez = Convert.ToDouble(a1) / Convert.ToDouble(a2);
                }
                diya = ' ';
                textTablo.Text = $"{rez}";
                operationRun = 1;
                rezTablo = true;
            }
        }

        private void addDiya(char da)
        {
            if (textTablo.Text[textTablo.Text.Length - 1] != diya)
            {
                operationRun++;
                operationSearch();
                diya = da;
                textTablo.Text += da;
                rezTablo = false;
            }
        }

        private void buttonPlus_Click(object sender, EventArgs e)
        {
            addDiya('+');
        }

        private void buttonMinus_Click(object sender, EventArgs e)
        {
            addDiya('-');
        }

        private void buttonDob_Click(object sender, EventArgs e)
        {
            addDiya('*');
        }

        private void buttonDil_Click(object sender, EventArgs e)
        {
            addDiya('/');
        }

        private void buttonRez_Click(object sender, EventArgs e)
        {
            if (textTablo.Text[textTablo.Text.Length - 1] != diya)
            {
                operationRun++;
                operationSearch();
            }
        }
    }
}