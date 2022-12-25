using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace JogosCampeoesLoteria
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            EntryPrimeiroNumero.Text = "1";
            EntrySegundoNumero.Text = "25";
            EntryQuantidadeNumeros.Text = "15";
        }

        private async void btGerarJogo_Clicked(object sender, EventArgs e)
        {
            lblResultado.Text = "";

            if (EntryPrimeiroNumero.Text == null || EntryPrimeiroNumero.Text == "")
            {
                await DisplayAlert("Erro", "Nescessário preencher o primeiro número", "OK");
                return;
            }

            if (EntrySegundoNumero.Text == null || EntrySegundoNumero.Text == "")
            {
                await DisplayAlert("Erro", "Nescessário preencher o segundo número", "OK");
                return;
            }

            if (EntryQuantidadeNumeros.Text == null || EntryQuantidadeNumeros.Text == "")
            {
                await DisplayAlert("Erro", "Nescessário preencher a quantidade de números", "OK");
                return;
            }

            Random numAleatório = new Random();
            List<int> itens = new List<int>();
            string strResultado = "";
            int proximoNumero = 0;
            int intPrimeiroNumero = Convert.ToInt32(EntryPrimeiroNumero.Text);
            int intSegundoNumero = (Convert.ToInt32(EntrySegundoNumero.Text) + 1);
            int intQuantidadeNumero = Convert.ToInt32(EntryQuantidadeNumeros.Text);

            while (intQuantidadeNumero > 0)
            {
                proximoNumero = numAleatório.Next(intPrimeiroNumero, intSegundoNumero);

                if (!itens.Contains(proximoNumero))
                {
                    itens.Add(proximoNumero);
                    intQuantidadeNumero -= 1;
                }
            }                                                   

            var result_set = itens.OrderBy(num => num);

            foreach (int value in result_set)
            {
                strResultado += value.ToString() + " - ";                
            }

            lblResultado.Text = strResultado.Remove(strResultado.Length - 3, 3);

        }
    }
}
