using AppListaSupermercado.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppListaSupermercado.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListaProdutos : ContentPage
    {
        ObservableCollection<Produto> lista_produtos = new ObservableCollection<Produto>();
        public ListaProdutos()
        {
            InitializeComponent();

            lst_produtos.ItemsSource = lista_produtos;
        }

        private void Btn_formProduto(object sender, EventArgs e)
        {
            Navigation.PushAsync(new FormularioCadastro());
        }

        private void lts_produtos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }

        private void MenuItem_Clicked(object sender, EventArgs e)
        {

        }

        private void ToolbarItem_Clicked_Somar(object sender, EventArgs e)
        {

        }

        private void ToolbarItem_Clicked_Novo(object sender, EventArgs e)
        {
            try
            {
                Navigation.PushAsync(new NovoProduto());
            } catch(Exception ex)
            {
                DisplayAlert("Ops", ex.Message, "Ok");
            }

        }

        private void txt_Busca_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        protected override void OnAppearing()
        {
            if (lista_produtos.Count == 0)
            {
                System.Threading.Tasks.Task.Run(async() =>
                {
                    List<Produto> temp = await App.Database.GetAll();
                } //aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
            }
        }
    }
}