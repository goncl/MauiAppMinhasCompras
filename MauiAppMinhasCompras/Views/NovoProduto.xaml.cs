using MauiAppMinhasCompras.Models;
using Microsoft.Maui.Controls.PlatformConfiguration;
using System.Threading.Tasks;

namespace MauiAppMinhasCompras.Views;

public partial class NovoProduto : ContentPage
{
	public NovoProduto()
	{
		InitializeComponent();
	}

    //Esse é o método de evento que será chamado quando o usuário clicar no botão Salvar.
    private async void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        try
        {
            //Monta um objeto Produto chamado p com os campos
            Produto p = new Produto
            {
                Descricao = txt_descricao.Text,
                Quantidade = Convert.ToDouble(txt_quantidade.Text),
                Preco = Convert.ToDouble(txt_preco.Text)
            };

            if (p.Preco <= 0)
            {
                await DisplayAlert("Erro", "Por favor, digite um preço maior que zero.", "OK");
                return;
            }

            //Aqui ele insere o produto no banco de dados SQLite.
            //App.DB é a instância do banco que foi criado antes.
            //Insert(p) é um método assíncrono que grava o objeto Produto na tabela correspondente.
            //await faz o código esperar a conclusão da operação antes de seguir.
            await App.DB.Insert(p);

            //Em caso de sucesso, Exibe uma mensagem na tela para o usuário.
            await DisplayAlert("Sucesso!", "Registro Inserido!", "OK");

            await Navigation.PopAsync();
        }
        catch (Exception ex)
        {
            //Se qualquer erro acontecer dentro do try, mostra a mensagem de erro detalhada.
            await DisplayAlert("OPS!", ex.Message, "OK");
        }
    }
}