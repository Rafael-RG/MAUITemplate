
using Template.Common.Pages;
using Template.ViewModels;

namespace Template.Pages;

/// <summary>
/// Home UI
/// </summary>
public partial class HomePage
{
	int count = 0;

	/// <summary>
	/// Receives the depedencies by DI
	/// </summary>
	public HomePage(HomeViewModel viewModel) : base(viewModel, "Home")
	{
		InitializeComponent();
		//this.BindingContext = viewModel;
	}


	private void OnCounterClicked(object sender, EventArgs e)
	{
		count++;

		if (count == 1)
			CounterBtn.Text = $"Clicked {count} time";
		else
			CounterBtn.Text = $"Clicked {count} times";

		SemanticScreenReader.Announce(CounterBtn.Text);
	}
}

