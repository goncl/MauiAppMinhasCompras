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

    //Esse � o m�todo de evento que ser� chamado quando o usu�rio clicar no bot�o Salvar.
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
                await DisplayAlert("Erro", "Por favor, digite um pre�o maior que zero.", "OK");
                return;
            }

            //Aqui ele insere o produto no banco de dados SQLite.
            //App.DB � a inst�ncia do banco que foi criado antes.
            //Insert(p) � um m�todo ass�ncrono que grava o objeto Produto na tabela correspondente.
            //await faz o c�digo esperar a conclus�o da opera��o antes de seguir.
            await App.DB.Insert(p);

            //Em caso de sucesso, Exibe uma mensagem na tela para o usu�rio.
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