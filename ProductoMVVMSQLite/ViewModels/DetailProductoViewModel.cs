using ProductoMVVMSQLite.Models;
using ProductoMVVMSQLite.Utils;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProductoMVVMSQLite.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class DetailProductoViewModel
    {
        private int _idProducto = 0;
        public string Nombre { get; set; }
        public string Cantidad { get; set; }
        public string Descripcion { get; set; }
        private Producto ProductoEncontrado { get; set; }

        public DetailProductoViewModel() { }

        public DetailProductoViewModel (Producto producto)
        {
            _idProducto = producto.IdProducto;
            ProductoEncontrado = producto;
            Nombre = producto.Nombre;
            Descripcion = producto.Descripcion;
            Cantidad = producto.Cantidad.ToString();
        }

        public DetailProductoViewModel(int IdProducto)
        {
            _idProducto = IdProducto;
            ProductoEncontrado = App.productoRepository.Get(_idProducto);
            Nombre = ProductoEncontrado.Nombre;
            Descripcion = ProductoEncontrado.Descripcion;
            Cantidad = ProductoEncontrado.Cantidad.ToString();

        }

        public ICommand GuardarProducto =>
            new Command(async () =>
            {
                if (_idProducto == 0)
                {
                    Producto producto = new Producto
                    {
                        Nombre = Nombre,
                        Descripcion = Descripcion,
                        Cantidad = Int32.Parse(Cantidad),
                    };
                    App.productoRepository.Add(producto);

                }
                else
                {
                    ProductoEncontrado.Nombre = Nombre;
                    ProductoEncontrado.Cantidad = Int32.Parse(Cantidad);
                    ProductoEncontrado.Descripcion = Descripcion;

                    App.productoRepository.Update(ProductoEncontrado);

                }
                Util.ListaProductos.Clear();
                App.productoRepository.GetAll().ForEach(Util.ListaProductos.Add);
                await App.Current.MainPage.Navigation.PopAsync();
            });

    }
}
