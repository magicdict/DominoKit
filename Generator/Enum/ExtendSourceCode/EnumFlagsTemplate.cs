@model Enum
@using System.Reflection
@using <%NameSpace%>
@{

    var enumType = (Type)Model.GetType();
    foreach (var value in Enum.GetValues(enumType))
    {
        var field = enumType.GetField(value.ToString());
        var display = field.GetCustomAttributes(typeof(EnumDisplayNameAttribute), false).FirstOrDefault() as EnumDisplayNameAttribute;
        @Html.CheckBox(value.ToString(), false);
        if (display != null)
        {
            @Html.Label(display.DisplayName);
        }
        else
        {
            @Html.Label(value.ToString());
        }
        <br />
    }
}