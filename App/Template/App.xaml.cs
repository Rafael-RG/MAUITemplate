namespace Template;

public partial class App : Application
{
	/// <summary>
	/// Main app
	/// </summary>
	public App()
	{
		InitializeComponent();
		MainPage = new AppShell();
	}
}
