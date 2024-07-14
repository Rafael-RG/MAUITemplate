using Template.ViewModels;

namespace Template.Pages;

/// <summary>
/// Entry form UI
/// </summary>
public partial class ItemDetailPage
{

	/// <summary>
	/// Receives the depedencies by DI
	/// </summary>
	public ItemDetailPage(ItemDetailViewModel viewModel) : base(viewModel, "Detail")
	{
		InitializeComponent();
	}
}

