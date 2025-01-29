using CommunityToolkit.Mvvm.ComponentModel;
using Controller.Maui.ViewModels;
namespace Controller.Maui.Views;

public partial class MoveView : ContentPage
{
	public MoveView(MoveViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
       
	}
}