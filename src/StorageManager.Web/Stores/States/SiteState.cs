using Fluxor;

using StorageManager.Client.Contracts;

namespace StorageManager.Web.Stores.States
{
    [FeatureState]
    public class SiteState
    {
        public List<SiteResponse> Sites { get; }

        public bool SiteIsLoading { get; }

        public string SelectedId { get; }
        public SiteResponse SelectedSite { get; }

        public SiteState()
        {

        }

        public SiteState(List<SiteResponse> sites, bool siteIsLoading, string selectedId, SiteResponse selectedSite)
        {
            Sites = sites;
            SiteIsLoading = siteIsLoading;
            SelectedId = selectedId;
            SelectedSite = selectedSite;
        }
    }
}
