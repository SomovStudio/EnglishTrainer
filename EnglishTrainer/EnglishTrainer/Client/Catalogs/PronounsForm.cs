/*
 * Created by SharpDevelop.
 * User: Catfish
 * Date: 17.01.2019
 * Time: 19:05
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using EnglishTrainer.Data;
using EnglishTrainer.Database.Local;

namespace EnglishTrainer.Client.Catalogs
{
	/// <summary>
	/// Description of PronounsForm.
	/// </summary>
	public partial class PronounsForm : Form
	{
		public PronounsForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		public TextBox TextBoxReturnValue;	// объект принимаемый значение

		OleDb oleDb;
		int selectTableLine = 0; // выбранная строка в таблице
		
		void PronounsFormLoad(object sender, EventArgs e)
		{
			TableRefresh();
		}
		
		public void TableRefresh()
		{
			try{
				TableRefreshLocal();
			}catch(Exception ex){
				oleDb.Error();
				Utilits.Console.LogError(ex.Message, false, true);
			}
		}
		
		void TableRefreshLocal()
		{
			oleDb = new OleDb(Config.databaseFile);
			oleDb.dataSet.Clear();
			oleDb.dataSet.DataSetName = "Pronouns";
			oleDb.oleDbCommandSelect.CommandText = "SELECT * FROM Pronouns ORDER BY ID ASC";
			if(oleDb.ExecuteFill("Pronouns")){
				listView1.Items.Clear();
				ListViewItem ListViewItem_add;
				foreach(DataRow rowElement in oleDb.dataSet.Tables[0].Rows)
	    		{
					ListViewItem_add = new ListViewItem();
					ListViewItem_add.SubItems.Add(rowElement["Pronoun"].ToString());
					ListViewItem_add.StateImageIndex = 1;
					ListViewItem_add.SubItems.Add(rowElement["Pronoun_Translation"].ToString());
					ListViewItem_add.SubItems.Add(rowElement["ID"].ToString());
					listView1.Items.Add(ListViewItem_add);
				}
			}else{
				Utilits.Console.LogError("[ОШИБКА] Ошибка выполнения запроса.", false, true);
				oleDb.Error();
				return;
			}
			// ВЫБОР: выдиляем ранее выбранный элемент.
			listView1.SelectedIndices.IndexOf(selectTableLine);
		}
		
		void search()
		{
			try{
				searchLocal();
				Utilits.Console.Log(this.Text + ": поиск завершен.");
			}catch(Exception ex){
				oleDb.Error();
				Utilits.Console.Log("[ОШИБКА]: " + ex.Message.ToString(), false, true);
			}
			if(toolStripComboBox1.Text != "") toolStripComboBox1.Items.Add(toolStripComboBox1.Text);
		}
		
		void searchLocal()
		{
			oleDb = new OleDb(Config.databaseFile);
			oleDb.dataSet.Clear();
			oleDb.dataSet.DataSetName = "Pronouns";
			oleDb.oleDbCommandSelect.CommandText = "SELECT * FROM Pronouns WHERE (Pronoun_Translation LIKE '%" + toolStripComboBox1.Text + 
				"%' OR Pronoun LIKE '%" + toolStripComboBox1.Text + "%' ) ORDER BY ID ASC";
			if(oleDb.ExecuteFill("Pronouns")){
				listView1.Items.Clear();
				ListViewItem ListViewItem_add;
				foreach(DataRow rowElement in oleDb.dataSet.Tables[0].Rows)
	    		{
					ListViewItem_add = new ListViewItem();
					ListViewItem_add.SubItems.Add(rowElement["Pronoun"].ToString());
					ListViewItem_add.StateImageIndex = 1;
					ListViewItem_add.SubItems.Add(rowElement["Pronoun_Translation"].ToString());
					ListViewItem_add.SubItems.Add(rowElement["ID"].ToString());
					listView1.Items.Add(ListViewItem_add);
				}
			}else{
				Utilits.Console.Log("[ОШИБКА] Ошибка выполнения запроса.");
				oleDb.Error();
				return;
			}
		}
		
		void PronounsFormFormClosed(object sender, FormClosedEventArgs e)
		{
	
		}
		void ButtonCloseClick(object sender, EventArgs e)
		{
			Close();
		}
		void ToolStripButton10Click(object sender, EventArgs e)
		{
			TableRefresh();
		}
		void ToolStripComboBox1KeyDown(object sender, KeyEventArgs e)
		{
			if(e.KeyData == Keys.Enter){
				search(); // поиск
			}
		}
		void ToolStripButton9Click(object sender, EventArgs e)
		{
			search(); // поиск
		}
		void ButtonReturnClick(object sender, EventArgs e)
		{
			returnValue(); // возвращает выбраные данные
		}
		
		void returnValue()
		{
			if(listView1.SelectedIndices.Count > 0){
				TextBoxReturnValue.Text += listView1.Items[listView1.SelectedIndices[0]].SubItems[1].Text.ToString();
				//TextBoxReturnValue.Text.Insert(TextBoxReturnValue.SelectionStart, listView1.Items[listView1.SelectedIndices[0]].SubItems[1].Text);
				Close();
			}
		}
		
		public void ShowReturnValue()
		{
			toolStripMenuItem2.Visible = true;
			выбратьЗаписьToolStripMenuItem.Visible = true;
			buttonReturn.Visible = true;
		}
		void ВыбратьЗаписьToolStripMenuItemClick(object sender, EventArgs e)
		{
			returnValue(); // возвращает выбраные данные
		}
		
		void addFile()
		{
			EditCatalogsForm eForm = new EditCatalogsForm();
			eForm.MdiParent = Forms.FClient;
			eForm.ThisIsNew = true;
			eForm.DataType = Constants.DATA_TYPE_PRONOUNS;
			eForm.ParentForm = this;
			eForm.Show();
		}
		
		void editFile()
		{
			if(listView1.SelectedIndices.Count > 0){
				EditCatalogsForm eForm = new EditCatalogsForm();
				eForm.MdiParent = Forms.FClient;
				eForm.ThisIsNew = false;
				eForm.ID = listView1.Items[listView1.SelectedIndices[0]].SubItems[3].Text;
				eForm.DataType = Constants.DATA_TYPE_PRONOUNS;
				eForm.ParentForm = this;
				eForm.Show();
			}
		}
		
		void deleteFile()
		{
			if(listView1.SelectedIndices.Count > 0){
				String fileID = listView1.Items[listView1.SelectedIndices[0]].SubItems[3].Text;
				String fileName = listView1.Items[listView1.SelectedIndices[0]].SubItems[1].Text;
				
				if(MessageBox.Show("Удалить безвозвратно запись '" + fileName + "' ?"  ,"Вопрос:", MessageBoxButtons.YesNo) == DialogResult.Yes){
					QueryOleDb query = new QueryOleDb(Config.databaseFile);
					query.SetCommand("DELETE FROM Pronouns WHERE (ID = " + fileID + ")");
					if(query.Execute()){
						Utilits.Console.Log("Запись: '" + fileName + "' успешно удалена.");
						TableRefresh();
					}else{
						Utilits.Console.LogError("Запись: '" + fileName + "' не удалось удалить!", false, true);
					}
				}					
			}
		}
		
		void ToolStripButton1Click(object sender, EventArgs e)
		{
			addFile();
		}
		void ToolStripButton2Click(object sender, EventArgs e)
		{
			editFile();
		}
		void ToolStripButton3Click(object sender, EventArgs e)
		{
			deleteFile();
		}
		void СоздатьЗаписьToolStripMenuItemClick(object sender, EventArgs e)
		{
			addFile();
		}
		void ИзменитьЗаписьToolStripMenuItemClick(object sender, EventArgs e)
		{
			editFile();
		}
		void УдалитьЗаписьToolStripMenuItemClick(object sender, EventArgs e)
		{
			deleteFile();
		}
		
	}
}
