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


//  ИЗМЕНЕНИЕ ВАРИАНТА ОДОБРЕНО

namespace WpfApp1
{
   class Currency
    {
        virtual public double Transfer
        {
            get;
            set;
        }

        public override string ToString()
        {
            return $" перевод в рубли: {Math.Round(Transfer, 2)}.";
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType()) return false;
            Currency currency = (Currency)obj;
            return this.Transfer == currency.Transfer;
        }
    }

    class Dollar : Currency
    {
        double numberD, numberR1;

        public double NumberD
        {
            get
            {
                return numberD;
            }
            set
            {
                if (value < 0)
                {
                    throw new Exception("Ошибка! Не может быть отрицательным!");
                }
                else
                {
                    numberD = value;
                }
            }
        }

        public override double Transfer
        {
            get
            {
                numberR1 = numberD * 74.21;
                return numberR1;
            }
        }

        public override string ToString()
        {
            return $"Количество долларов: {numberD}," + base.ToString();
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType()) return false;
            Dollar dollar = (Dollar)obj;
            return this.Transfer == dollar.Transfer;
        }
    }

    class Euro : Currency
    {
        double numberE, numberR2;

        public double NumberE
        {
            get
            {
                return numberE;
            }
            set
            {
                if (value < 0)
                {
                    throw new Exception("Ошибка! Не может быть отрицательным!");
                }
                else
                {
                    numberE = value;
                }
            }
        }

        public override double Transfer
        {
            get
            {
                numberR2 = numberE * 90.29;
                return numberR2;
            }
        }

        public override string ToString()
        {
            return $"Количество евро: {numberE}," + base.ToString();
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType()) return false;
            Euro euro = (Euro)obj;
            return this.Transfer == euro.Transfer;
        }
    }

    class Yuan : Currency
    {
        double numberY, numberR3;

        public double NumberY
        {
            get
            {
                return numberY;
            }
            set
            {
                if (value < 0)
                {
                    throw new Exception("Ошибка! Не может быть отрицательным!");
                }
                else
                {
                    numberY = value;
                }
            }
        }

        public override double Transfer
        {
            get
            {
                numberR3 = numberY * 11.47;
                return numberR3;
            }
        }

        public override string ToString()
        {
            return $"Количество юань: {numberY}," + base.ToString();
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType()) return false;
            Yuan yuan = (Yuan)obj;
            return this.Transfer == yuan.Transfer;
        }
    }

    public partial class MainWindow : Window
    {
        List<Currency> currencies = new List<Currency>()
        {
            new Dollar() { NumberD = 100 },
            new Dollar() { NumberD = 500 },
            new Dollar() { NumberD = 1000 },

            new Euro() {NumberE = 100 },
            new Euro() {NumberE = 500 },
            new Euro() {NumberE = 1000 },

            new Yuan() { NumberY = 100 },
            new Yuan() { NumberY = 500 },
            new Yuan() { NumberY = 1000 },
        };

        public MainWindow()
        {
            InitializeComponent();
            updateListBox(currencies);
        }
        void updateListBox(List<Currency> currencies)
        {
            lbC.Items.Clear();
            foreach (var c in currencies)
            {
                lbC.Items.Add(c);
            }
        }

        private void btn_add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                switch (cb.SelectedIndex)
                {
                    case 0:
                        double d = double.Parse(tb.Text);
                        Dollar dollar = new Dollar()
                        {
                            NumberD = d
                        };
                        currencies.Add(dollar);
                        updateListBox(currencies);
                        break;
                    case 1:
                        double eu = double.Parse(tb.Text);
                        Euro euro = new Euro()
                        {
                            NumberE = eu
                        };
                        currencies.Add(euro);
                        updateListBox(currencies);
                        break;
                    case 2:
                        double yu = double.Parse(tb.Text);
                        Yuan yuan = new Yuan()
                        {
                            NumberY = yu
                        };
                        currencies.Add(yuan);
                        updateListBox(currencies);
                        break;
                }
            }

            catch (FormatException)
            {
                MessageBox.Show("Проверьте введенные значения", "Ошибка данных", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка данных", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void btn_D_Click(object sender, RoutedEventArgs e)
        {
            Currency[] CD = new Currency[lbC.SelectedItems.Count];
            lbC.SelectedItems.CopyTo(CD, 0);

            foreach (var cd in CD)
            {
                lbC.Items.Remove(cd);
                currencies.Remove(cd);
            }
        }
    }
}
