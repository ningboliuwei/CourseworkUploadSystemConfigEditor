using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ConfigEditor : System.Web.UI.Page
{
	private const string KEYWORD = "CourseworkUploadSystem4";
	private const string CONFIG_FILE_NAME = "config.txt";
	protected void Page_Load(object sender, EventArgs e)
	{
		if (!Page.IsPostBack)
		{
			ShowDirsInDropDownList();
		}
	}

	protected void btnSave_OnClick(object sender, EventArgs e)
	{
		SaveConfigFile(dplDir.SelectedValue + "\\" + CONFIG_FILE_NAME);
	}

	private void ShowDirsInDropDownList()
	{
		string rootDir = Server.MapPath("");
		string[] allDirs = Directory.GetDirectories(rootDir);
		//List<string> courseworkDirs = new List<string>();

		dplDir.Items.Add("请选择课程");

		foreach (string dir in allDirs)
		{
			if (dir.ToUpper().Contains(KEYWORD.ToUpper()))
			{
				ListItem item = new ListItem();

				item.Text = dir.Substring(dir.LastIndexOf("\\") + 1).ToUpper().Replace(KEYWORD.ToUpper(), "");
				item.Value = dir;
				dplDir.Items.Add(item);
			}
		}

		dplDir.SelectedIndex = 0;
	}
	protected void dplDir_SelectedIndexChanged(object sender, EventArgs e)
	{
		ShowConfigFile(dplDir.SelectedValue + "\\" + CONFIG_FILE_NAME);
	}

	private void SaveConfigFile(string filePath)
	{
		try
		{
			if (File.Exists(filePath))
			{
				StreamWriter streamWriter = new StreamWriter(filePath, false, Encoding.Default);

				streamWriter.Write(txtEditor.Text.Trim());
				streamWriter.Close();

				lblInfo.Text = "配置文件保存成功";
			}
		}
		catch (Exception exception)
		{

			throw new Exception(exception.Message);
		}
	}

	private void ShowConfigFile(string filePath)
	{
		try
		{
			if (File.Exists(filePath))
			{
				StreamReader streamReader = new StreamReader(filePath, Encoding.Default);

				txtEditor.Text = streamReader.ReadToEnd();
				streamReader.Close();
			}
		}
		catch (Exception exception)
		{

			throw new Exception(exception.Message);
		}
	}
}