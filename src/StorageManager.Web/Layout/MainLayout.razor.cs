using Fluxor;

using Microsoft.AspNetCore.Components;

using StorageManager.Web.Stores.States;

namespace StorageManager.Web.Layout
{
    public partial class MainLayout(IState<SiteState> _siteState) : LayoutComponentBase
    {
        protected override void OnInitialized()
        {
            _siteState.StateChanged += (_, _) => StateHasChanged();
            base.OnInitialized();
        }
    }
}
