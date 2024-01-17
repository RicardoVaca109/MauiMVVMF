using ProductoMVVMSQLite.Models;
using ProductoMVVMSQLite.ViewModels;

namespace ProductoMVVMSQLite.Views;

public partial class DetailProductoPage : ContentPage
{
	public DetailProductoPage()
	{
		InitializeComponent();
		BindingContext = new DetailProductoViewModel();
	}
	public DetailProductoPage(int IdProducto) 
	{
        InitializeComponent();
        Producto producto = App.productoRepository.Get(IdProducto);
		BindingContext = new DetailProductoViewModel(producto);
    }
}