using Fluxor;
using Fluxor.Blazor.Web.Components;

using StorageManager.Web.Stores.States;

namespace StorageManager.Web.Components.Site
{
    public partial class SiteTable(IState<SiteState> _siteState) : FluxorComponent
    {
        protected override void OnInitialized()
        {
            _siteState.StateChanged += (_,_) => StateHasChanged();
            base.OnInitialized();
        }
    }
}
