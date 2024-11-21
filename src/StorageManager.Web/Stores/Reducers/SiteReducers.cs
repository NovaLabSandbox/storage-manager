using Fluxor;

using StorageManager.Web.Stores.Actions;
using StorageManager.Web.Stores.States;

namespace StorageManager.Web.Stores.Reducers
{
    public static class SiteReducers
    {
        [ReducerMethod]
        public static SiteState ReduceFetchAllSitesAction(SiteState siteState, FetchAllSitesAction _)
            => new SiteState(null, true, siteState.SelectedId, siteState.SelectedSite);

        [ReducerMethod]
        public static SiteState ReduceFetchAllSitesSuccessAction(SiteState siteState, FetchAllSitesSuccessAction action)
            => new SiteState(action.Sites, false, siteState.SelectedId, siteState.SelectedSite);

        [ReducerMethod]
        public static SiteState ReduceFetchSiteDetailsAction(SiteState siteState, FetchSiteDetailsAction action)
            => new SiteState(siteState.Sites, true, action.SiteId, null);

        [ReducerMethod]
        public static SiteState ReduceFetchSiteDetailsSuccessAction(SiteState siteState, FetchSiteDetailsSuccessAction action)
            => new SiteState(siteState.Sites, false, action.SiteId, action.SiteDetails);        
        
        [ReducerMethod]
        public static SiteState ReduceResetSelectedSiteAction(SiteState siteState, ResetSelectedSiteAction _)
            => new SiteState(siteState.Sites, false, null, null);
    }
}
