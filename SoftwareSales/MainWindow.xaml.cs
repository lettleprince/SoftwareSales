// Group2: Jingfei Yao, Grace Pauly, Xiaotong Han.

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

/*
 * Group 2/10 Problem – Software Sales
 * A software company sells a package that retails for $99. Quantity discounts are given according to the following table:
 * Quantity Discount
 * 10-19 20%
 * 20-49 30%
 * 50-99 40%
 * 100 or more 50%
 * Create an application that lets the user enter the number of packages purchased. 
 * The program should then display the amount of the discount (if any) and the total amount of the purchase after the discount.
*/
namespace SoftwareSales
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
    }
}
