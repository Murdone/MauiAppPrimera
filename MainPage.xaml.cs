using CommunityToolkit.Maui.Alerts;
using System.Diagnostics;
using Debug = System.Diagnostics.Debug;

namespace PrimerApp;

public partial class MainPage : ContentPage
{
	bool isRandom;
	string valorcolr;
	public MainPage()
	{
		InitializeComponent();
	}

	private void Sld_ValueChanged(object sender, ValueChangedEventArgs e)
	{
		if (!isRandom)
		{
            var rojo = SldRed.Value;
            var verde = SldVerde.Value;
            var azul = SldAzul.Value;
            Color color = Color.FromRgb(rojo, verde, azul);
            SetColor(color);
        }
		
	}

	private void SetColor(Color color)
	{
		Debug.WriteLine(color.ToString());
		btnRandom.BackgroundColor = color;
		Container.BackgroundColor = color;
		valorcolr = color.ToHex();
		lblHex.Text = valorcolr;
	}

	private void btnRandom_Clicked(object sender, EventArgs e)
	{
		isRandom = true;
		var random = new Random();
		var color = Color.FromRgb(
			random.Next(0,256), 
			random.Next(0, 256), 
			random.Next(0, 256)
            );
		SetColor(color);
		SldRed.Value = color.Red;
		SldAzul.Value = color.Blue;
		SldVerde.Value = color.Green;
		isRandom = false;
	}

	private async void ImageButton_Clicked(object sender, EventArgs e)
	{
		await Clipboard.SetTextAsync(valorcolr);
		var toast = Toast.Make("Color Copiado",
			CommunityToolkit.Maui.Core.ToastDuration.Long,15); // la extencion con el mismo nombre 
		await toast.Show();
	}
}

