using MauiAppMinhasCompras.Models;

namespace MauiAppMinhasCompras.Views;

public partial class EditarProduto : ContentPage
{
	public EditarProduto()
	{
		InitializeComponent();
	}

    private async void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        try
        {
            Produto produto_anexado = BindingContext as Produto;

            //Monta um objeto Produto chamado p com os campos
            Produto p = new Produto
            {
                Id = produto_anexado.Id,
                Descricao = txt_descricao.Text,
                Quantidade = Convert.ToDouble(txt_quantidade.Text),
                Preco = Convert.ToDouble(txt_preco.Text)
            };

            //Aqui ele insere o produto no banco de dados SQLite.
            //App.DB � a inst�ncia do banco que foi criado antes.
            //Insert(p) � um m�todo ass�ncrono que grava o objeto Produto na tabela correspondente.
            //await faz o c�digo esperar a conclus�o da opera��o antes de seguir.
            await App.DB.Update(p);

            //Em caso de sucesso, Exibe uma mensagem na tela para o usu�rio.
            await DisplayAlert("Sucesso!", "Registro Atualizado!", "OK");

            //Retorna a pagina anterior
            await Navigation.PopAsync();
        }
        catch (Exception ex)
        {
            //Se qualquer erro acontecer dentro do try, mostra a mensagem de erro detalhada.
            await DisplayAlert("OPS!", ex.Message, "OK");
        }
    }
}