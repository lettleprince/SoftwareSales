// Group2: Jingfei Yao, Grace Pauly, Xiaotong Han.

using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using System;

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
    public partial class MainWindow : Window
    {
        private const decimal Price = 24.99M;

        private const decimal DISCOUNT_LEVEL0 = 0M;
        private const decimal DISCOUNT_LEVEL1 = 0.2M;
        private const decimal DISCOUNT_LEVEL2 = 0.3M;
        private const decimal DISCOUNT_LEVEL3 = 0.4M;
        private const decimal DISCOUNT_LEVEL4 = 0.5M;

        private const decimal MINIMUM_LEVEL1 = 10;
        private const decimal MINIMUM_LEVEL2 = 20;
        private const decimal MINIMUM_LEVEL3 = 50;
        private const decimal MINIMUM_LEVEL4 = 100;

        private int number;

        private decimal discount;

        public MainWindow()
        {
            InitializeComponent();

            PriceLabel.Text = Price.ToString("C");

            UpdateLabelContent();
           
        }

        private void Buy_Now_Click(object sender, RoutedEventArgs e)
        {
            if (number > 0)
            {
                decimal total = number * (1 - discount) * Price;
                MessageBox.Show($"Total: {total.ToString("C")}", caption: "Buy Now");
            }
            else
            {
                MessageBox.Show("Please enter a valid quantity!", caption: "Input Error!");
            }
        }

        private void QuantityInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            string numberString = QuantityInput.Text;
            try
            {
                number = int.Parse(numberString);
            }
            catch
            {
                if (numberString == "")
                {
                    number = 0;
                } 
            }

            // filter invalid input
            if (number == 0)
            {
                numberString = "";
            }
            else
            {
                numberString = number.ToString();
            }

            QuantityInput.Text = numberString;
            QuantityInput.Select(numberString.Length, 0);

            if (number >= MINIMUM_LEVEL4)
            {
                discount = DISCOUNT_LEVEL4;
            }
            else if (number >= MINIMUM_LEVEL3)
            {
                discount = DISCOUNT_LEVEL3;
            }
            else if (number >= MINIMUM_LEVEL2)
            {
                discount = DISCOUNT_LEVEL2;
            }
            else if (number >= MINIMUM_LEVEL1)
            {
                discount = DISCOUNT_LEVEL1;
            }
            else
            {
                discount = DISCOUNT_LEVEL0;
            }

            UpdateLabelContent();
        }

        private void UpdateLabelContent()
        {
            bool haveDiscount = discount > DISCOUNT_LEVEL0;

            // show the line
            if (haveDiscount)
            {
                PriceLabel.TextDecorations = TextDecorations.Strikethrough;
            } 
            else
            {
                PriceLabel.TextDecorations = null;
            }

            // update discount price
            DiscountPriceLabel.Content = ((1 - discount) *Price).ToString("C");
            DiscountPriceLabel.Visibility = haveDiscount ? Visibility.Visible : Visibility.Hidden;
        }
    }
}
