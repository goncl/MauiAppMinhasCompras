using MauiAppMinhasCompras.Models;
using System.Collections.ObjectModel;

namespace MauiAppMinhasCompras.Views;

public partial class ListaProduto : ContentPage
{
    ObservableCollection<Produto> lista = new ObservableCollection<Produto>();
	public ListaProduto()
	{
		InitializeComponent();

        lst_produtos.ItemsSource = lista;
	}

    protected async override void OnAppearing()
    {
        List<Produto> tmp = await App.DB.GetAll();

        tmp.ForEach(i => lista.Add(i));
    }

    //quando o usu�rio clicar no bot�o de Adicionar.
    private void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        try
		{
             //O usu�rio ser� levado para a tela de cadastro de novo produto.
            Navigation.PushAsync(new Views.NovoProduto());
		} catch(Exception ex)
		{
            //Se qualquer erro acontecer dentro do try, mostra a mensagem de erro detalhada.
            DisplayAlert("OPS!", ex.Message, "OK");
		}
    }

    //Defini��o do M�todo
    private async void txt_search_TextChanged(object sender, TextChangedEventArgs e)
    {
        //A propriedade e.NewTextValue obt�m o texto que o usu�rio acabou de digitar.
        string q = e.NewTextValue;

        //limpa a lista atual, garante que os resultados da busca anterior sejam
        //removidos antes de adicionar os novos.
        lista.Clear();

        //App.DB.Search(q): Esta � a chamada para a opera��o de busca.
        List<Produto> tmp = await App.DB.Search(q);

        //tmp.ForEach(...): Itera sobre cada item na lista tmp (a lista de produtos
        //que foi retornada da busca).
        tmp.ForEach(i => lista.Add(i));
    }

    private void ToolbarItem_Clicked_1(object sender, EventArgs e)
    {
        double soma = lista.Sum(i => i.Total);

        string msg = $"O Total � {soma:C}";

        DisplayAlert("Total dos Produtos", msg, "OK");
    }

    private void MenuItem_Clicked(object sender, EventArgs e)
    {

    }
}