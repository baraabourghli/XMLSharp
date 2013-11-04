using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using CodeBoxControl;
using System.Windows.Shapes;
using System.IO;
namespace PLproject
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        private CodeBoxSettings mCodeBoxSettings = null;
        public Window1()
        {
            InitializeComponent();
            mCodeBoxSettings = (CodeBoxSettings)this.Resources["coloredWordSettings"];
            textBox1.DecorationScheme = CodeBoxControl.Decorations.DecorationSchemes.CSharp3;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("\t\t        BY:\n\n BARAA AL-BOURGHI && ABD ALRHMAN KDAH");
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            Parser p = new Parser(textBox1.Text);
            if (p.program())
            {
                MessageBox.Show("THE PROGRAM is syntactically correct");
            }
            else
            {
                MessageBox.Show("THE PROGRAM is not syntactically correct");
            }
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            interpreter i = new interpreter(textBox1.Text);
            i.Fire();
        }

        private void MenuItem_Click_4(object sender, RoutedEventArgs e)
        {
            textBox1.Clear();
        }

        private void MenuItem_Click_5(object sender, RoutedEventArgs e)
        {
            //open
           
        }

        private void MenuItem_Click_6(object sender, RoutedEventArgs e)
        {
            //load
        }
    }
}
