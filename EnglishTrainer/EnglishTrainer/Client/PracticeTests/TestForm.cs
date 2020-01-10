/*
 * Created by SharpDevelop.
 * User: Catfish
 * Date: 02.02.2019
 * Time: 9:20
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using EnglishTrainer.Data;
using EnglishTrainer.Database.Local;

namespace EnglishTrainer.Client.PracticeTests
{
	/// <summary>
	/// Description of TestForm.
	/// </summary>
	public partial class TestForm : Form
	{
		public TestForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		public string ID;
		OleDb oleDb;
		int right = 0;
		int wrong = 0;
		
		void answers()
		{
			right = 0;
			wrong = 0;
			label1.Text = "Правильных ответов: " + right;
			label2.Text = "Неправильных ответов: " + wrong;
			
			AnswersTestsForm atForm = new AnswersTestsForm();
			atForm.MdiParent = Forms.FClient;
			atForm.ParentListView = listView1;
			atForm.ParentTestForm = this;
			atForm.Show();
		}
		
		void TestFormLoad(object sender, EventArgs e)
		{
			DataTable table;
			oleDb = new OleDb(Config.databaseFile);
			oleDb.dataSet.Clear();
			oleDb.dataSet.DataSetName = "Tests";
			oleDb.oleDbCommandSelect.CommandText = "SELECT * FROM Tests WHERE (IDPractice = " + ID + ") ORDER BY ID ASC";
			if(oleDb.ExecuteFill("Tests")){
				table = oleDb.dataSet.Tables["Tests"];
				
				listView1.Items.Clear();
				ListViewItem ListViewItem_add;
				foreach(DataRow row in table.Rows)
	        	{
					ListViewItem_add = new ListViewItem();
					ListViewItem_add.SubItems.Add(row["condition"].ToString());
					ListViewItem_add.StateImageIndex = 0;
					ListViewItem_add.SubItems.Add(row["question"].ToString());
					ListViewItem_add.SubItems.Add("");
					ListViewItem_add.SubItems.Add("");
					ListViewItem_add.SubItems.Add(row["hint"].ToString());
					ListViewItem_add.SubItems.Add(row["ID"].ToString());
					listView1.Items.Add(ListViewItem_add);
				}
				
			}
		}
		
		public void Check()
		{
			DataTable table;
			table = oleDb.dataSet.Tables["Tests"];
			
			string userAnswer = "";
			string rightAnswer = "";
			
			for(int i = 0; i < table.Rows.Count; i++)
			{
				listView1.Items[i].SubItems[4].Text = table.Rows[i]["answer"].ToString();
				
				userAnswer = listView1.Items[i].SubItems[3].Text.ToLower();
				rightAnswer = table.Rows[i]["answer"].ToString().ToLower();
				
				userAnswer = userAnswer.Replace(" ", string.Empty);
				rightAnswer = rightAnswer.Replace(" ", string.Empty);
				
				if(userAnswer == rightAnswer)
				{
					listView1.Items[i].StateImageIndex = 1;
					right++;
				}else{
					listView1.Items[i].StateImageIndex = 2;
					wrong++;
				}
			}
			
			label1.Text = "Правильных ответов: " + right;
			label2.Text = "Неправильных ответов: " + wrong;
			
			if(wrong == 0)
			{
				Utilits.Console.Log(Text + " - успешно пройден! У вас " + wrong + " ошибок");
				MessageBox.Show(Text + " - успешно пройден!", "Поздравление");
			}else{
				Utilits.Console.Log(Text + " - не пройден! У вас " + wrong + " ошибок");
				MessageBox.Show(Text + " - не пройден!" + Environment.NewLine + "У вас " + wrong + " ошибок","Сообщение");
			}
		}
		
		void ToolStripButton1Click(object sender, EventArgs e)
		{
			answers();
		}
		void ОтветитьНаВопросыТестаToolStripMenuItemClick(object sender, EventArgs e)
		{
			answers();
		}
		void ButtonCloseClick(object sender, EventArgs e)
		{
			Close();
		}
	}
}
