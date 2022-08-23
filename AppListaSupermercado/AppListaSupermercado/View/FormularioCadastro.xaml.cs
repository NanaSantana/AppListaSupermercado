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
                Produto produto_anexado = BindingContext as Produto;

                Produto p = new Produto
                {
                    Id = produto_anexado.Id,
                    NomeProduto = txt_NomeProduto.Text,
                    Quantidade = Convert.ToDouble(txt_Quantidade.Text),
                    PrecoUnitario = Convert.ToDouble(txt_Preco.Text),

                };
            }

            //PAROU AQUI, VC TROCOU O EDITAR COM O ADICIONAR SEU ANIMAL, EU TE ODEIO !!!!!!!!!!!!!


                /*await App.Database.Update(p);
                await DisplayAlert("Sucesso!!!", "Produto Editado!!!", "ok!!!");
                await Navigation.PushAsync(new ListaProdutos());
            }
            catch (Exception ex)
            {
                await DisplayAlert("ops", ex.Message, "ok");
            }
        }

        private void CadastroProduto(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ListaProdutos());
        }*/
            
}