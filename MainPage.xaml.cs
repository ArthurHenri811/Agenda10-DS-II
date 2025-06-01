using System;
using Microsoft.Maui.Controls;

namespace CalculadoraCombustivel
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCalcularClicked(object sender, EventArgs e)
        {
            string marca = marcaEntry.Text?.Trim();
            string modelo = modeloEntry.Text?.Trim();
            string etanolTexto = etanolEntry.Text;
            string gasolinaTexto = gasolinaEntry.Text;

            if (string.IsNullOrWhiteSpace(marca) ||
                string.IsNullOrWhiteSpace(modelo) ||
                string.IsNullOrWhiteSpace(etanolTexto) ||
                string.IsNullOrWhiteSpace(gasolinaTexto))
            {
                resultadoLabel.TextColor = Colors.Red;
                resultadoLabel.Text = "Por favor, preencha todos os campos.";
                return;
            }

            bool etanolValido = double.TryParse(etanolTexto, out double precoEtanol);
            bool gasolinaValida = double.TryParse(gasolinaTexto, out double precoGasolina);

            if (!etanolValido || !gasolinaValida || precoEtanol <= 0 || precoGasolina <= 0)
            {
                resultadoLabel.TextColor = Colors.Red;
                resultadoLabel.Text = "Insira preços válidos para os combustíveis.";
                return;
            }

            double razao = precoEtanol / precoGasolina;
            string mensagem;

            if (razao <= 0.7)
            {
                mensagem = $"O etanol está compensando para o seu {marca} {modelo}.";
            }
            else
            {
                mensagem = $"A gasolina está compensando para o seu {marca} {modelo}.";
            }

            resultadoLabel.TextColor = Colors.DarkGreen;
            resultadoLabel.Text = mensagem;
        }
    }
}
