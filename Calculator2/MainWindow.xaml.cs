using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calculator2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static string Conteyner { get; set; } = string.Empty;
        public static string Operation { get; set; } = string.Empty;
        public static bool Period { get; set; } = false;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Border1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var border = sender as Border;
            var txtblock = border.Child as TextBlock;
            ResultTxtBlock.Text += txtblock.Text;
        }

        private void BorderSubs_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (CalculateTxtBlock.Text == string.Empty || Period == true)
            {
                Conteyner = ResultTxtBlock.Text;
                Operation = "-";
                CalculateTxtBlock.Text = ResultTxtBlock.Text + "-";
                Period = false;
                ResultTxtBlock.Text = string.Empty;
            }
            else
            {
                Calculate();
                Operation = "-";
            }
        }

        private void BorderAdd_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (CalculateTxtBlock.Text == string.Empty || Period == true)
            {
                Conteyner = ResultTxtBlock.Text;
                Operation = "+";
                CalculateTxtBlock.Text = ResultTxtBlock.Text + "+";
                Period = false;
                ResultTxtBlock.Text = string.Empty;
            }
            else
            {
                Calculate();
                Operation = "+";
            }
        }

        private void BorderDiv_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (CalculateTxtBlock.Text == string.Empty || Period == true)
            {
                Conteyner = ResultTxtBlock.Text;
                Operation = "/";
                CalculateTxtBlock.Text = ResultTxtBlock.Text + "/";
                Period = false;
                ResultTxtBlock.Text = string.Empty;
            }
            else
            {
                Calculate();
                Operation = "/";
            }
        }

        private void BorderMult_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (CalculateTxtBlock.Text == string.Empty || Period == true)
            {
                Conteyner = ResultTxtBlock.Text;
                Operation = "*";
                CalculateTxtBlock.Text = ResultTxtBlock.Text + "*";
                Period = false;
                ResultTxtBlock.Text = string.Empty;
            }
            else
            {
                Calculate();
                Operation = "*";
            }
        }
        public void Calculate()
        {
            double num1 = double.Parse(Conteyner);
            if (ResultTxtBlock.Text != string.Empty)
            {
                double num2 = double.Parse(ResultTxtBlock.Text);

                if (Operation == "*")
                {
                    CalculateTxtBlock.Text = (num1 * num2).ToString();
                }
                else if (Operation == "/")
                {
                    CalculateTxtBlock.Text = (num1 / num2).ToString();
                }
                else if (Operation == "+")
                {
                    CalculateTxtBlock.Text = (num1 + num2).ToString();
                }
                else
                {
                    CalculateTxtBlock.Text = (num1 - num2).ToString();
                }
                Conteyner = CalculateTxtBlock.Text;
                              
                CalculateTxtBlock.Text = string.Empty;
                if (Operation != "=")
                {
                    CalculateTxtBlock.Text = Conteyner;
                    ResultTxtBlock.Text = string.Empty;
                }
            }

        }

        private void BorderC_MouseDown(object sender, MouseButtonEventArgs e)
        {
            CalculateTxtBlock.Text = string.Empty;
            ResultTxtBlock.Text = string.Empty;
        }

        private void BorderEquality_MouseDown(object sender, MouseButtonEventArgs e)
        {
            string text = Conteyner + Operation + ResultTxtBlock.Text;
            Calculate();
            ResultTxtBlock.Text = CalculateTxtBlock.Text;
            CalculateTxtBlock.Text = text + "=";
            Period = true;
        }
    }
}
