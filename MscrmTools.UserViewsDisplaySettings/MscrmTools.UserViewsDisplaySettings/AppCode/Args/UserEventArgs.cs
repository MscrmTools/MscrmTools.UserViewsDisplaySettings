using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;

namespace MscrmTools.UserViewsDisplaySettings.AppCode.Args
{
    public class UserEventArgs
    {
        private readonly List<Entity> _uiSettings;
        private readonly Guid _userId;

        public UserEventArgs(Guid userId, List<Entity> uiSettings)
        {
            _userId = userId;
            _uiSettings = uiSettings;
        }

        public List<Entity> UiSettings => _uiSettings;
        public Guid UserId => _userId;
    }
}