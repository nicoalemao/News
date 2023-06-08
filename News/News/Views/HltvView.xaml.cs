using News.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace News.Views
{
    public partial class HltvView : ContentPage
    {
        public HltvView()
        {
            InitializeComponent();
            Task.Run(async () => await Initialize("Hltv"));
        }

        public HltvView(string scope)
        {
            InitializeComponent();
            Title = $"{scope}";
            Task.Run(async () => await Initialize(scope));
        }

        private async Task Initialize(string scope)
        {
            var viewModel = Resolver.Resolve<HltvViewModel>();
            BindingContext = viewModel;
            await viewModel.Initialize(scope);
        }
    }
}