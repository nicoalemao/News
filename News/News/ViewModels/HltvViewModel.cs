using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Input;
using News.Models;
using News.Services;
using Xamarin.Forms;

namespace News.ViewModels
{
    public class HltvViewModel : ViewModel
    {
        private readonly HltvServices hltvServices;

        public HltvResult CurrentArticle { get; set; }

        public HltvViewModel(HltvServices hltvServices)
        {
            this.hltvServices = hltvServices;
        }

        public async Task Initialize(string scope)
        {
            var resolvedScope = scope.ToLower() switch
            {
                "hltvarticle" => HltvScope.HltvArticle,
                _ => HltvScope.HltvArticle
            };

            await Initialize(resolvedScope);
        }

        public async Task Initialize(HltvScope scope)
        {
            CurrentArticle = await hltvServices.GetArticles(scope);
        }

        public ICommand ItemSelected =>
            new Command(async (selectedItem) =>
            {
                var selectedArticle = selectedItem as HltvArticle;
                var url = HttpUtility.UrlEncode(selectedArticle.link);
                await Navigation.NavigateTo($"articleview?url={url}");
            });
    }


}
