﻿using MediatR;

using OneOf;

using StorageManager.Client.Contracts;
using StorageManager.Core.Results;

namespace StorageManager.Application.CQRS.Commands
{
    public class CreateSiteCommand : IRequest<OneOf<CreatedResult<Site>, NotFoundResult, ForbiddenResult, BusinessErrorResult>>
    {
        public CreateSiteCommand(SiteCreateRequest payload)
        {
            Payload = payload;
        }

        public SiteCreateRequest Payload { get; }
    }
}
