using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PracWinForms2._2
{
    public partial class Form1 : Form
    {
        const double Swim = 1.5;
        const double Bicycle = 40;
        const double Running = 10;

        double AndreyTime;
        double EgorTime;
        double MichaelTime;

        public Form1()
        {
            InitializeComponent();
        }

        private void Time_Button_Click(object sender, EventArgs e)
        {
            TimePeople();

            AndreyTime_TextBox.Text = (AndreyTime * 60).ToString();
            EgorTime_TextBox.Text = (EgorTime * 60).ToString();
            MichaelTime_TextBox.Text = (MichaelTime * 60).ToString();
        }

        private void Champ_Button_Click(object sender, EventArgs e)
        {
            TimePeople();

            string winner;
            double minTime = Math.Min(AndreyTime, Math.Min(EgorTime, MichaelTime));

            List<string> winners = new List<string>();
            if (minTime == AndreyTime)
                winners.Add("Андрей");
            if (minTime == EgorTime)
                winners.Add("Егор");
            if (minTime == MichaelTime)
                winners.Add("Михаил");

            if (winners.Count == 1)
            {
                winner = winners[0];
            }

            else if (winners.Count > 1)
            {
                winner = "Ничья";
            }

            else
            {
                winner = "Ошибка";
            }

            Champ_TextBox.Text = winner;
        }

        private void TimePeople()
        {
            try
            {
                AndreyTime = Swim / double.Parse(AndreySwimming_TextBox.Text) +
                             Bicycle / double.Parse(AndreyBicycle_TextBox.Text) +
                             Running / double.Parse(AndreyRunning_TextBox.Text);

                EgorTime = Swim / double.Parse(EgorSwimming_TextBox.Text) +
                           Bicycle / double.Parse(EgorBicycle_TextBox.Text) +
                           Running / double.Parse(EgorRunning_TextBox.Text);

                MichaelTime = Swim / double.Parse(MichaelSwimming_TextBox.Text) +
                              Bicycle / double.Parse(MichaelBicycle_TextBox.Text) +
                              Running / double.Parse(MichaelRunning_TextBox.Text);
            }

            catch (FormatException)
            {
                MessageBox.Show("Ошибка ввода. Пожалуйста, введите корректные числовые значения.",
                                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

                AndreyTime = EgorTime = MichaelTime = 0;
            }
        }
    }
}
