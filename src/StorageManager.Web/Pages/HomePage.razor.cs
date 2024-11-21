using Fluxor;

using StorageManager.Web.Stores.Actions;

namespace StorageManager.Web.Pages
{
    public partial class HomePage(IDispatcher _dispatcher)
    {
        protected override async Task OnInitializedAsync()
        {
            _dispatcher.Dispatch(new FetchAllSitesAction());
            _dispatcher.Dispatch(new ResetSelectedSiteAction());
            await base.OnInitializedAsync();
        }
    }
}
