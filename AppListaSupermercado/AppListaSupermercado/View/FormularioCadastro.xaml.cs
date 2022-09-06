using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AppListaSupermercado.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppListaSupermercado.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FormularioCadastro : ContentPage
    {
        public FormularioCadastro()
        {
            InitializeComponent();
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            try
            {
                Produto p = new Produto
                {
                    NomeProduto = txt_NomeProduto.Text,
                    Quantidade = Convert.ToDouble(txt_Quantidade.Text),
                    PrecoUnitario = Convert.ToDouble(txt_Preco.Text),
   

                };

                await App.Database.Insert(p);

                await DisplayAlert("Sucesso!", "Produto Cadastrado", "OK");

                await Navigation.PushAsync(new ListaProdutos());
            }
            catch (Exception ex)
            {
                await DisplayAlert("ops", ex.Message, "OK");
            }
        }
    }
}