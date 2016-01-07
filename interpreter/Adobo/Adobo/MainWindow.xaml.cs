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

namespace Adobo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void exitRun_Click(object sender, RoutedEventArgs e)
        {
            consoleBox.FontFamily = new FontFamily("Courier New");
            consoleBox.Text = "Kamusta Mundo!";

            warningBox.FontFamily = new FontFamily("Courier New");
            warningBox.Text = "Babala sa linya 5: Naglagay ka ng BILANG sa SALITA\nMali sa linya 8: Hindi natapos ang function sa SIMULA. Pakilagyan ng WAKAS sa dulo\n";

            var column1 = new DataGridTextColumn();
            column1.Header = "Uri";
            column1.Binding = new Binding("Uri");
            variableTable.Columns.Add(column1);

            var column2 = new DataGridTextColumn();
            column2.Header = "Variable";
            column2.Binding = new Binding("Variable");
            variableTable.Columns.Add(column2);

            var column3 = new DataGridTextColumn();
            column3.Header = "Halaga";
            column3.Binding = new Binding("Halaga");
            variableTable.Columns.Add(column3);

            variableTable.Items.Add(new DataItem { Uri = "SALITA", Variable = "choice", Halaga = "c"});
        }
    }
}
