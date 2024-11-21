using StorageManager.Client.Contracts;

namespace StorageManager.Web.Stores.Actions
{
    public class FetchAllSitesAction
    {
    }

    public class FetchAllSitesSuccessAction
    {
        public List<Site> Sites { get; }

        public FetchAllSitesSuccessAction(List<Site> sites)
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
        public Site SiteDetails { get; }

        public FetchSiteDetailsSuccessAction(string siteId, Site siteDetails)
        {
            SiteId = siteId;
            SiteDetails = siteDetails;
        }
    }

    public class ResetSelectedSiteAction { }
}
