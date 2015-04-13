using System;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace DevKit.Common
{
	public static class Utility
	{

		#region"Excel"
		/// <summary>
		/// 获得数字，默认是0
		/// </summary>
		/// <param name="Cell"></param>
		/// <returns></returns>
		public static int GetExcelIntValue(dynamic Cell)
		{
			int t;
			int.TryParse(Cell.Text, out t);
			return t;
		}
		/// <summary>
		/// 获得布尔值，默认是False
		/// </summary>
		/// <param name="Cell"></param>
		/// <returns></returns>
		public static bool GetExcelBooleanValue(dynamic Cell)
		{
			return !String.IsNullOrEmpty(Cell.Text);
		}
		#endregion

		#region "类型"
		/// <summary>
		/// 获得字符枚举值
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="strEnum"></param>
		/// <returns></returns>
		/// <param name = "Default"></param>
		public static T GetEnum<T>(string strEnum, T Default)
		{
			if (string.IsNullOrEmpty(strEnum))
				return Default;
			try {
				T EnumValue = (T)Enum.Parse(typeof(T), strEnum);
				return EnumValue;
			} catch (Exception) {
				return Default;
			}
		}
		#endregion

		#region "Resource "
		/// <summary>
		/// 获得嵌入式资源
		/// 必须保证资源和本函数在同一个DLL中
		/// </summary>
		/// <param name="saveFilename"></param>
		/// <param name="ResFilename"></param>
		public static void getResource(String saveFilename, String ResFilename)
		{
			Assembly asm = Assembly.GetExecutingAssembly();
			if (File.Exists(saveFilename)) {
				File.Delete(saveFilename);
			}
			Stream Read = new FileStream(saveFilename, FileMode.Create);
			asm.GetManifestResourceStream("DevKit.Common.Resources." + ResFilename).CopyTo(Read);
			Read.Close();
		}
		/// <summary>
		/// 保存对象
		/// </summary>
		/// <param name="filename"></param>
		/// <param name="Obj"></param>
		public static void SaveObjAsXml<T>(string filename, T Obj)
		{
			var settings = new XmlWriterSettings();
			settings.Indent = true;
			//NewLineChars对于String属性的东西无效
			//这是对于XML中换行有效，
			//String的换行会变成Console的NewLine /n
			settings.NewLineChars = System.Environment.NewLine;
			var xml = new XmlSerializer(typeof(T));
			var writer = XmlWriter.Create(filename, settings);
			var ns = new XmlSerializerNamespaces();
			ns.Add("","");
			xml.Serialize(writer, Obj,ns);
			writer.Close();
		}
		/// <summary>
		/// 读取对象
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="filename"></param>
		/// <returns></returns>
		public static T LoadObjFromXml<T>(string filename)
		{
			var setting = new XmlReaderSettings();
			var xml = new XmlSerializer(typeof(T));
			var reader = XmlReader.Create(filename, setting);
			T obj = (T)xml.Deserialize(reader);
			reader.Close();
			return obj;
		}
		/// <summary>
		/// 深拷贝
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		public static T DeepCopy<T>(T obj)
		{
			var bFormatter = new BinaryFormatter();
			var stream = new MemoryStream();
			bFormatter.Serialize(stream, obj);
			stream.Seek(0, SeekOrigin.Begin);
			return (T)bFormatter.Deserialize(stream);
		}
		#endregion
        
		#region"UI"
		/// <summary>
		/// 枚举填充Combox
		/// </summary>
		/// <param name="combox"></param>
		/// <param name="enumType"></param>
		/// <param name = "IsEditMode"></param>
		public static void FillComberWithEnum(ComboBox combox, Type enumType, bool IsEditMode = true)
		{
			combox.Items.Clear();
			if (!IsEditMode)
				combox.Items.Add("<All>");
			foreach (var item in Enum.GetValues(enumType)) {
				combox.Items.Add(item.ToString());
			}
			combox.SelectedIndex = 0;
		}
		/// <summary>
		/// 使用字符填充combox
		/// </summary>
		/// <param name="combox"></param>
		/// <param name="EnumList"></param>
		/// <param name = "IsEditMode"></param>
		public static void FillComberWithArray(ComboBox combox, string[] EnumList, bool IsEditMode = true)
		{
			combox.Items.Clear();
			if (!IsEditMode)
				combox.Items.Add("<All>");
			foreach (var item in EnumList) {
				combox.Items.Add(item);
			}
			combox.SelectedIndex = 0;

		}
		/// <summary>
		/// 自动调整列宽度
		/// </summary>
		/// <param name="lstview"></param>
		public static void ListViewColumnResize(ListView lstview)
		{
			var ColumnWidth = new int[lstview.Columns.Count];
			lstview.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
			for (int i = 0; i < lstview.Columns.Count; i++) {
				ColumnWidth[i] = lstview.Columns[i].Width;
			}
			lstview.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
			for (int i = 0; i < lstview.Columns.Count; i++) {
				ColumnWidth[i] = Math.Max(lstview.Columns[i].Width, ColumnWidth[i]);
			}
			for (int i = 0; i < lstview.Columns.Count; i++) {
				lstview.Columns[i].Width = ColumnWidth[i];
			}
		}
		/// <summary>
		/// 输入框
		/// </summary>
		/// <param name = "Prompt"></param>
		/// <param name="Title"></param>
		/// <returns></returns>
		public static string InputBox(string Prompt, string Title = "中和软件")
		{
			return Microsoft.VisualBasic.Interaction.InputBox(Prompt, Title);
		}
        /// <summary>
        /// 消息框
        /// </summary>
        /// <param name="Prompt"></param>
        /// <param name="Title"></param>
        public static void MessageBox(string Prompt, string Title = "中和软件")
        {
           Microsoft.VisualBasic.Interaction.MsgBox(Prompt,Microsoft.VisualBasic.MsgBoxStyle.OkOnly,Title);
        }
		/// <summary>
		/// 格式化窗体
		/// </summary>
		/// <param name="orgForm"></param>
		/// <returns></returns>
		/// <param name = "ShowDialog"></param>
		public static void SetUp(Form orgForm, Boolean ShowDialog = true)
		{
			orgForm.Text += " - 中和软件";
			orgForm.StartPosition = FormStartPosition.CenterParent;
			orgForm.FormBorderStyle = FormBorderStyle.FixedToolWindow;
			if (ShowDialog)
				orgForm.ShowDialog();
		}
		/// <summary>
		/// 文件对话框模式
		/// </summary>
		public enum FileDialogMode
		{
			/// <summary>
			/// 打开文件
			/// </summary>
			Open,
			/// <summary>
			/// 保存文件
			/// </summary>
			Save
		}
		/// <summary>
		/// 选取文件
		/// </summary>
		/// <param name="mode">模式</param>
		/// <param name="Filter">过滤器</param>
		/// <returns></returns>
		public static string PickFile(FileDialogMode mode, string Filter = "*.*(All Files)|*.*")
		{
			FileDialog dialog;
			if (mode == FileDialogMode.Open) {
				dialog = new OpenFileDialog();
			} else {
				dialog = new SaveFileDialog();
			}
			dialog.Filter = Filter;
			if (dialog.ShowDialog() == DialogResult.OK) {
				return dialog.FileName;
			}
			return string.Empty;
		}
		/// <summary>
		/// XML
		/// </summary>
		public static string XmlFilter = "*.xml(XML Files)|*.xml";
		/// <summary>
		/// Xlsx
		/// </summary>
		public static string XlsxFilter = "*.xlsx(Excel Files)|*.xlsx";
		/// <summary>
		/// CShapr
		/// </summary>
		public static string CSFilter = "*.cs(C# SourceCode)|*.cs";
        /// <summary>
        /// CSHTML
        /// </summary>
        public static string CSHTMLFilter = "*.cshtml(C# HTML SourceCode)|*.cshtml";
		/// <summary>
		/// Java
		/// </summary>
		public static string JavaFilter = "*.java(Java SourceCode)|*.java";
		/// <summary>
		/// Sql
		/// </summary>
		public static string SqlFilter = "*.sql(Sql files)|*.sql";
		/// <summary>
		/// 选择文件夹
		/// </summary>
		/// <returns></returns>
		public static string PickFolder()
		{
			FolderBrowserDialog dialog = new FolderBrowserDialog();
			if (dialog.ShowDialog() == DialogResult.OK) {
				return dialog.SelectedPath;
			}
			return string.Empty;
		}
		#endregion

	}
}
