using Microsoft.Xrm.Sdk;
using System;

namespace MscrmTools.UserViewsDisplaySettings.AppCode
{
    public class ViewItem
    {
        private readonly Entity view;

        public ViewItem(Entity view)
        {
            this.view = view;
        }

        public string FetchXml
        {
            get { return view.GetAttributeValue<string>("fetchxml"); }
        }

        public Guid Id => view.Id;
        public bool IsSystemView => view.LogicalName == "savedquery";
        public string Name => view.GetAttributeValue<string>("name");

        public override string ToString()
        {
            return view.GetAttributeValue<string>("name");
        }
    }
}