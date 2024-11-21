using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;
using OneOf;

using StorageManager.Client.Contracts;
using StorageManager.Core.Results;

namespace StorageManager.Application.CQRS.Commands
{
    public class UpdateSiteCommand : IRequest<OneOf<bool, NotFoundResult, ForbiddenResult, BusinessErrorResult>>
    {
        public UpdateSiteCommand(string siteId, SiteUpdateRequest payload)
        {
            SiteId = siteId;
            Payload = payload;
        }

        public string SiteId { get; }

        public SiteUpdateRequest Payload { get; }

    }
}
