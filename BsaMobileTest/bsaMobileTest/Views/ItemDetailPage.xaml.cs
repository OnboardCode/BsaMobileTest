using bsaMobileTest.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace bsaMobileTest.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}