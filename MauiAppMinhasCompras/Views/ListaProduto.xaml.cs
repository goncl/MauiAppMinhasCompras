namespace MauiAppMinhasCompras.Views;

public partial class ListaProduto : ContentPage
{
	public ListaProduto()
	{
		InitializeComponent();
	}

    //quando o usuário clicar no botão de Adicionar.
    private void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        try
		{
             //ele será levado para a tela de cadastro de novo produto.
            Navigation.PushAsync(new Views.NovoProduto());
		} catch(Exception ex)
		{
            //Se qualquer erro acontecer dentro do try, mostra a mensagem de erro detalhada.
            DisplayAlert("OPS!", ex.Message, "OK");
		}
    }
}