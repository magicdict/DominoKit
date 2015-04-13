using System;
using System.Collections.Generic;
using System.Reflection;
using System.Web.Mvc;

namespace <%NameSapce%>
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

    public class EnumExt
    {
        /// <summary>
        /// ����ö�ٳ�Ա��ȡ�Զ�������EnumDisplayNameAttribute������DisplayName
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public static string GetEnumCustomDescription(object e)
        {
            //��ȡö�ٵ�Type���Ͷ���
            Type t = e.GetType();
            //��ȡö�ٵ������ֶ�
            FieldInfo[] ms = t.GetFields();
            //��������ö�ٵ������ֶ�
            foreach (FieldInfo f in ms)
            {
                if (f.Name != e.ToString())
                {
                    continue;
                }
                //�ڶ�������true��ʾ����EnumDisplayNameAttribute�ļ̳���
                if (f.IsDefined(typeof(EnumDisplayNameAttribute), true))
                {
                    return
                        (f.GetCustomAttributes(typeof(EnumDisplayNameAttribute), true)[0] as EnumDisplayNameAttribute)
                            .DisplayName;
                }
            }
            //���û���ҵ��Զ������ԣ�ֱ�ӷ��������������
            return e.ToString();
        }
        /// <summary>
        /// ����ö�٣���ö���Զ�������EnumDisplayNameAttribut��Display����ֵײ��SelectListItem��
        /// </summary>
        /// <param name="enumType">ö��</param>
        /// <returns></returns>
        public static List<SelectListItem> GetSelectList(Type enumType)
        {
            List<SelectListItem> selectList = new List<SelectListItem>();
            foreach (object e in Enum.GetValues(enumType))
            {
                selectList.Add(new SelectListItem() { Text = GetEnumCustomDescription(e), Value = ((int)e).ToString() });
            }
            return selectList;
        }
    }
}
