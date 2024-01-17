using ProductoMVVMSQLite.Models;
using ProductoMVVMSQLite.ViewModels;

namespace ProductoMVVMSQLite.Views;

public partial class NuevoProductoPage : ContentPage
{
    public NuevoProductoPage()
    {
        InitializeComponent();
        BindingContext = new NuevoProductoViewModel();
    }

    public NuevoProductoPage(int IdProducto)
    {
		InitializeComponent();
        Producto producto = App.productoRepository.Get(IdProducto);
        BindingContext = new NuevoProductoViewModel(producto);
    }
}