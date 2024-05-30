using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
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
using statusDisplay.Models;


namespace statusDisplay
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

        private void textChangedEventHandler(object sender, TextChangedEventArgs e)
        {
            sclText.Text = dbText.Text;
            textlistText.Text = string.Empty;

            string[] lines = sclText.Text.Split("\n");
            var statuses = new List<Status>();

            foreach (string line in lines)
            {
                string[] cells = line.Split("\t");

                if (cells.Length >= 4)
                {
                    bool itsInteger = cells.Any(c => isIntegerType(c));

                    if (itsInteger)
                    {
                        Status status = new Status();

                        status.Name = cells[1];
                        status.Id = int.Parse(cells[3]);

                        statuses.Add(status);
                    }
                }
            }

            if (statuses.Count > 0)
            {
                foreach (Status status in statuses)
                {
                    textlistText.Text += status.Id + "\t" + status.Name + "\n";
                }
            }
        }

        private void clickCopySclHandler(object sender, RoutedEventArgs e)
        {

        }

        private void clickCpoyTextlistHandler(object sender, RoutedEventArgs e)
        {

        }


        private bool isIntegerType(string variableType)
        {
            string[] integerTypes = { "Int", "UInt", "SInt",
                "USInt", "LInt", "ULInt"};

            foreach (string integerType in integerTypes)
            {
                if (integerType == variableType) return true;
            }
            return false;
        }
    }
}
