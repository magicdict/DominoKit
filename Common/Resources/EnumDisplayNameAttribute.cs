using System;

namespace BussinessLogic.Enterprise
{
    public class EnumDisplayNameAttribute : Attribute
    {
        private string _displayName;
        public EnumDisplayNameAttribute(string displayName)
        {
            this._displayName = displayName;
        }
        public string DisplayName
        {
            get { return _displayName; }
        }
    }
}