using System.Linq;
﻿using AppListaSupermercado.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Threading.Tasks;
using System.Text;

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

        private void ToolbarItem_Clicked_Novo(object sender, EventArgs e)
        {
            try
            {
                Navigation.PushAsync(new FormularioCadastro());
            } catch (Exception ex)
            {
                DisplayAlert("Ops", ex.Message, "OK");
            }
        }

        /**
         * Método que faz a soma dos itens da ObservableCollection, isto é,
         * a soma do subtotal (preco x quantidade) de cada um dos itens do array de objetos
         */
        private void ToolbarItem_Clicked_Somar(object sender, EventArgs e)
        {
            double soma = lista_produtos.Sum(i => i.PrecoUnitario * i.Quantidade);

            string msg = "O total da compra é:" + soma;

            DisplayAlert("Ops", msg, "ok");
        }

        protected override void OnAppearing()
        {
            if (lista_produtos.Count == 0)
            {
                System.Threading.Tasks.Task.Run(async () =>
                {
                    List<Produto> temp = await App.Database.GetAll();

                    foreach (Produto item in temp)
                    {
                        lista_produtos.Add(item);
                    }

                    ref_carregando.IsRefreshing = false;
                });
            }
        }

        private async void MenuItem_Clicked(object sender, EventArgs e)
        {
            MenuItem disparador = (MenuItem)sender;

            Produto produto_selecionado = (Produto)disparador.BindingContext;

            bool confimacao = await DisplayAlert("tem certeza?", "remover item?", "Sim", "Não");

            if (confimacao)
            {
                await App.Database.Delete(produto_selecionado.Id);

                lista_produtos.Remove(produto_selecionado);
            }
        }

        /**
         * Trata o evento TextChanged da SearchBar recebendo os novos valores digitados
         */
        private void txt_Busca_TextChanged(object sender, TextChangedEventArgs e)
        {
            string buscou = e.NewTextValue;

            System.Threading.Tasks.Task.Run(async () =>
            {
                List<Produto> temp = await App.Database.Search(buscou);

                lista_produtos.Clear();

                foreach (Produto item in temp)
                {
                    lista_produtos.Add(item);
                }

                ref_carregando.IsRefreshing = false;
            });
        }

        private void lst_produtos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Navigation.PushAsync(new EditarProdutos
            {
                BindingContext = (Produto)e.SelectedItem
            });
        }
    }
}