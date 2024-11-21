using Fluxor;

using StorageManager.Client.Contracts;

namespace StorageManager.Web.Stores.States
{
    [FeatureState]
    public class SiteState
    {
        public List<Site> Sites { get; }

        public bool SiteIsLoading { get; }

        public string SelectedId { get; }
        public Site SelectedSite { get; }

        public SiteState()
        {

        }

        public SiteState(List<Site> sites, bool siteIsLoading, string selectedId, Site selectedSite)
        {
            Sites = sites;
            SiteIsLoading = siteIsLoading;
            SelectedId = selectedId;
            SelectedSite = selectedSite;
        }
    }
}
