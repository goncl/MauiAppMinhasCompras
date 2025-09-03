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
            //App.DB é a instância do banco que foi criado antes.
            //Insert(p) é um método assíncrono que grava o objeto Produto na tabela correspondente.
            //await faz o código esperar a conclusão da operação antes de seguir.
            await App.DB.Update(p);

            //Em caso de sucesso, Exibe uma mensagem na tela para o usuário.
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