using MediatR;

using OneOf;

using StorageManager.Core.Results;

namespace StorageManager.Application.CQRS.Commands
{
    public class DeleteSiteCommand : IRequest<OneOf<bool, NotFoundResult, ForbiddenResult, BusinessErrorResult>>
    {
        public string SiteId { get; }

        public DeleteSiteCommand(string siteId)
        {
            SiteId = siteId;
        }
    }
}
