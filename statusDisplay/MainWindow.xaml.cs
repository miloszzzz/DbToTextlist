using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Globalization;
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
        bool _sclCopied = false;
        bool _textlistCopied = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void TextChangedEventHandler(object sender, TextChangedEventArgs e)
        {
            MakeStatusTexts();
        }

        private void ClickCopySclHandler(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(sclText.Text);
            _sclCopied = true;
        }

        private void ClickCpoyTextlistHandler(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(textlistText.Text);
            _textlistCopied = true;
        }

        private void CheckBoxRenumberClickHandler(object sender, RoutedEventArgs e)
        {
            MakeStatusTexts();
        }

        private void CheckBoxWithNumbersClickHandler(object sender, RoutedEventArgs e)
        {
            MakeStatusTexts();
        }


        private void MakeStatusTexts()
        {
            var statuses = Status.DbToStatusList(dbText.Text);

            textlistText.Text = statuses.GetStatusesTexts((bool)checkBoxTextlistWithNumbers.IsChecked, (bool)checkBoxRenumberTextlist.IsChecked);

            if ((bool)checkBoxRenumberTextlist.IsChecked)
            {
                sclText.Text = statuses.GetSclCode();
            }

            _sclCopied = false;
            _textlistCopied = false;
        }


        private void MakeSeqTexts()
        {
            var steps = Step.GraphToStepList(seqText.Text);
            
            textlistTextSeq.Text = steps.GetSteps((bool)checkBoxTextlistWithNumbersSeq.IsChecked, (bool)checkBoxRenumberTextlistSeq.IsChecked);

            if ((bool)checkBoxRenumberTextlistSeq.IsChecked)
            {
                sclTextSeq.Text = steps.GetSclCode();
            }
        }


        private void ClickCopySclSeqHandler(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(sclTextSeq.Text);
        }

        private void ClickCpoyTextlistSeqHandler(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(textlistTextSeq.Text);
        }

        private void SeqTextChangedEventHandler(object sender, TextChangedEventArgs e)
        {
            MakeSeqTexts();
        }

        private void CheckBoxRenumberSeqClickHandler(object sender, RoutedEventArgs e)
        {
            MakeSeqTexts();
        }

        private void CheckBoxWithNumbersSeqClickHandler(object sender, RoutedEventArgs e)
        {
            MakeSeqTexts();
        }
    }

    public class BoolToFontWeightConverter : DependencyObject, IValueConverter
    {
        public object Convert(object value, Type targetType,
                              object parameter, CultureInfo culture)
        {
            return ((bool)value) ? FontWeights.Bold : FontWeights.Normal;
        }

        public object ConvertBack(object value, Type targetType,
                                  object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
}
