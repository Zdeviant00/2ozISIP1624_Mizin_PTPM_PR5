using System;
using System.Windows;

namespace DepositCalculator_V4
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double sum = double.Parse(txtSum.Text);
                int months = int.Parse(txtMonths.Text);
                double annualRate = double.Parse(txtRate.Text); // вводится как % годовых (например, 10)

                if (sum <= 0 || months <= 0 || annualRate < 0)
                {
                    MessageBox.Show("Все значения должны быть положительными!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                double income = 0;

                if (rbSimple.IsChecked == true)
                {
                    // Простые проценты: ставка годовая, срок — в месяцах
                    income = sum * (annualRate / 100) * (months / 12.0);
                }
                else if (rbCompound.IsChecked == true)
                {
                    // Сложные проценты: ежемесячная капитализация
                    double monthlyRate = annualRate / 100 / 12; // доля в месяц
                    double finalAmount = sum * Math.Pow(1 + monthlyRate, months);
                    income = finalAmount - sum;
                }
                else
                {
                    MessageBox.Show("Выберите схему начисления процентов!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                lblResult.Content = $"Доход по вкладу = {income:F2}";
            }
            catch
            {
                MessageBox.Show("Ошибка ввода данных. Проверьте, что все поля заполнены числами.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}