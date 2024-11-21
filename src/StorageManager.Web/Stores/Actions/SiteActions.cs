using StorageManager.Client.Contracts;

namespace StorageManager.Web.Stores.Actions
{
    public class FetchAllSitesAction
    {
    }

    public class FetchAllSitesSuccessAction
    {
        public List<SiteResponse> Sites { get; }

        public FetchAllSitesSuccessAction(List<SiteResponse> sites)
        {
            Sites = sites;
        }
    }

    public class FetchSiteDetailsAction
    {
        public string SiteId { get; }

        public FetchSiteDetailsAction(string siteId)
        {
            SiteId = siteId;
        }
    }

    public class FetchSiteDetailsSuccessAction
    {
        public string SiteId { get; }
        public SiteResponse SiteDetails { get; }

        public FetchSiteDetailsSuccessAction(string siteId, SiteResponse siteDetails)
        {
            SiteId = siteId;
            SiteDetails = siteDetails;
        }
    }

    public class ResetSelectedSiteAction { }
}
