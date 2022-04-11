using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata.Query;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MscrmTools.UserViewsDisplaySettings.AppCode
{
    internal class MetadataManager
    {
        private readonly IOrganizationService _service;

        public MetadataManager(IOrganizationService service)
        {
            _service = service;
        }

        public List<EntityInfo> GetTables()
        {
            EntityQueryExpression entityQueryExpression = new EntityQueryExpression
            {
                Properties = new MetadataPropertiesExpression
                {
                    AllProperties = false,
                    PropertyNames = { "DisplayName", "SchemaName", "LogicalName", "ObjectTypeCode" }
                },
            };
            RetrieveMetadataChangesRequest retrieveMetadataChangesRequest = new RetrieveMetadataChangesRequest
            {
                Query = entityQueryExpression,
                ClientVersionStamp = null
            };
            var response = (RetrieveMetadataChangesResponse)_service.Execute(retrieveMetadataChangesRequest);

            return response.EntityMetadata.Select(e => new EntityInfo(e)).ToList();
        }
    }
}