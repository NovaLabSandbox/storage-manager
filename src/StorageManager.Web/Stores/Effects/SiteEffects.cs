using Fluxor;

using StorageManager.Client.Contracts;
using StorageManager.Web.Stores.Actions;

namespace StorageManager.Web.Stores.Effects
{
    public class SiteEffects(ISiteClient siteClient)
    {
        [EffectMethod]
        public async Task HandleFetchAllSitesAction(FetchAllSitesAction _, IDispatcher dispatcher)
        {
            var sites = await siteClient.GetAllSitesAsync();
            dispatcher.Dispatch(new FetchAllSitesSuccessAction(sites.ToList()));
        }

        [EffectMethod]
        public async Task HandleFetchSiteDetailsAction(FetchSiteDetailsAction action, IDispatcher dispatcher)
        {
            var details = await siteClient.GetSiteByIdAsync(action.SiteId);
            dispatcher.Dispatch(new FetchSiteDetailsSuccessAction(action.SiteId, details));
        }
    }
}
