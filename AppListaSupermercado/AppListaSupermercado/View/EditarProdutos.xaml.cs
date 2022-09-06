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
    public partial class EditarProdutos : ContentPage
    {
        public EditarProdutos()
        {
            InitializeComponent();
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            try
            {
                Produto produto_anexado = BindingContext as Produto;

                Produto p = new Produto
                {
                    //Id = ((Produto) BindingContext).Id,
                    Id = produto_anexado.Id,
                    NomeProduto = txt_NomeProduto.Text,
                    Quantidade = Convert.ToDouble(txt_Quantidade.Text),
                    PrecoUnitario = Convert.ToDouble(txt_Preco.Text),
                };

                await App.Database.Update(p);

                await DisplayAlert("Sucesso!", "Produto Editado", "OK");

                await Navigation.PushAsync(new ListaProdutos());
            }
            catch (Exception ex)
            {
                await DisplayAlert("Ops", ex.Message,"OK");
            }

        }
    }
}