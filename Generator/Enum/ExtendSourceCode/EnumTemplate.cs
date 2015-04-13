@model Enum
@using System.ComponentModel.DataAnnotations
@using System.Reflection
@using <%NameSpace%>

@{

    var selectList = new List<SelectListItem>();
    string optionLabel = null;
    object htmlAttributes = null;
    var enumType = (Type)Model.GetType();
    foreach (var value in Enum.GetValues(enumType))
    {

        var field = enumType.GetField(value.ToString());
        var option = new SelectListItem() { Value = value.ToString() };
        var display = field.GetCustomAttributes(typeof(EnumDisplayNameAttribute), false).FirstOrDefault() as EnumDisplayNameAttribute;
        if (display != null)
        {
            option.Text = display.DisplayName;
        }
        else
        {
            option.Text = value.ToString();
        }
        option.Selected = object.Equals(value, Model);
        selectList.Add(option);
    }
}

@Html.DropDownList("", selectList, optionLabel, htmlAttributes)