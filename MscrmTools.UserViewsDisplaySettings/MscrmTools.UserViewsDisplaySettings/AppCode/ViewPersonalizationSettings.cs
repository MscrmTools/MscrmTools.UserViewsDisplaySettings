using System;
using System.Runtime.Serialization;

namespace MscrmTools.UserViewsDisplaySettings.AppCode
{
    [DataContract]
    public class ViewPersonalizationSettings
    {
        [DataMember(Name = "viewPersonalizationSettingsInfo")]
        public ViewPersonalizationSettingsInfo Info { get; set; }
    }

    [DataContract]
    public class ViewPersonalizationSettingsInfo
    {
        [DataMember(Name = "hiddenSavedQueryIds")]
        public string[] HiddenSavedQueryIds { get; set; }

        [DataMember(Name = "hiddenUserQueryIds")]
        public string[] HiddenUserQueryIds { get; set; }

        [DataMember(Name = "sortOrder")]
        public int SortOrder { get; set; }
    }
}