using MediatR;

using OneOf;

using StorageManager.Client.Contracts;
using StorageManager.Core.Results;

namespace StorageManager.Application.CQRS.Queries
{
    public class GetAllSitesQuery : IRequest<OneOf<List<Site>, NotFoundResult, ForbiddenResult, BusinessErrorResult>>
    {
    }
}
