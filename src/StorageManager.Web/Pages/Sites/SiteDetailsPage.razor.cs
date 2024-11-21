using Fluxor;
using Fluxor.Blazor.Web.Components;

using Microsoft.AspNetCore.Components;

using StorageManager.Web.Stores.Actions;
using StorageManager.Web.Stores.States;

namespace StorageManager.Web.Pages.Sites
{
    public partial class SiteDetailsPage(IDispatcher _dispatcher, IState<SiteState> _siteState) : FluxorComponent
    {
        [Parameter]
        public string SiteId { get; set; }

        protected override void OnInitialized()
        {
            _siteState.StateChanged += (_, _) => StateHasChanged();
            _dispatcher.Dispatch(new FetchSiteDetailsAction(SiteId));
            base.OnInitialized();
        }
    }
}
