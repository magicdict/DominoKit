/*
 * Created by SharpDevelop.
 * User: scs
 * Date: 2014/12/30
 * Time: 14:07
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using DevKit.Common;
namespace DevKit.CodeSnippetMgr
{
	/// <summary>
	/// Description of codeSnippet.
	/// </summary>
	[Serializable]
	public class codeSnippet
	{
		/// <summary>
		/// 目录列表
		/// </summary>
		public static string[] strCatalog = {
			"WEB前端",
			"数据库",
			"Spring框架",
			".Net MVC"
		};
		/// <summary>
		/// 标题
		/// </summary>
		public string Title = string.Empty;
		/// <summary>
		/// 描述
		/// </summary>
		public string Descrpition = string.Empty;
		/// <summary>
		/// 类别
		/// </summary>
		public string Catalog = string.Empty;
		/// <summary>
		/// Tag
		/// </summary>
		public string Tag = string.Empty;
		/// <summary>
		/// 代码
		/// </summary>
		public string Code = string.Empty;
		/// <summary>
		/// 检索
		/// </summary>
		/// <param name="strKeyword">检索关键字</param>
		/// <returns></returns>
		public static Func<codeSnippet,Boolean> Search(string strKeyword)
		{
			Func<codeSnippet,Boolean> func = (x) => {
				return x.Title.Contains(strKeyword) ||
				x.Descrpition.Contains(strKeyword) ||
				x.Tag.Contains(strKeyword);
			};
			return func;
		}
	}
}
