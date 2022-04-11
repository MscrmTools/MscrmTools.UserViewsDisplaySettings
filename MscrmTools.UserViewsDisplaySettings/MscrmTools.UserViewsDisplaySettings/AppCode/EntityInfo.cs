using Microsoft.Xrm.Sdk.Metadata;
using System;

namespace MscrmTools.UserViewsDisplaySettings.AppCode
{
    internal class EntityInfo
    {
        private EntityMetadata _emd;

        public EntityInfo(EntityMetadata emd)
        {
            _emd = emd;
        }

        public string LogicalName => _emd.LogicalName;
        public int ObjectTypeCode => _emd.ObjectTypeCode.Value;

        public override string ToString()
        {
            return LogicalName;
        }
    }
}