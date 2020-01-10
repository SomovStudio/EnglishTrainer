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
	/// Description of PracticeForm.
	/// </summary>
	public partial class PracticeForm : Form
	{
		public PracticeForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		OleDb oleDb;
		DataTable foldersTable;			// папки
		DataTable filesTable; 			// файлы
		String openFolder = ""; 		// открытая папка
		bool folderExplore = true; 		// флаг отображения элементов в папках
		int selectTableLine = 0; // выбранная строка в таблице
		
		public void TableRefresh(String actionFolder = null)
		{
			try{
				if(actionFolder == null) TableRefreshLocal(openFolder);
				else TableRefreshLocal(actionFolder);
			}catch(Exception ex){
				oleDb.Error();
				Utilits.Console.LogError(ex.Message, false, true);
			}
		}
		
		void TableRefreshLocal(String actionFolder)
		{
			listView1.Items.Clear();
			// Папки
			oleDb = new OleDb(Config.databaseFile);
			oleDb.dataSet.Clear();
			oleDb.dataSet.DataSetName = "Practice";
			if(actionFolder == "") {
				oleDb.oleDbCommandSelect.CommandText = "SELECT * FROM Practice WHERE (type = '"+Constants.TYPE_FOLDER+"') ORDER BY name ASC";
			}else{
				oleDb.oleDbCommandSelect.CommandText = "SELECT * FROM Practice WHERE (type = '"+Constants.TYPE_FOLDER+"' AND name = '" + actionFolder + "') ORDER BY name ASC";
			}
			if(oleDb.ExecuteFill("Practice")){
				foldersTable = oleDb.dataSet.Tables["Practice"].Copy();
			}else{
				Utilits.Console.LogError("Ошибка выполнения запроса к таблице Номенклатура при отборе папок.", false, true);
				oleDb.Error();
				return;
			}
			// Файлы			
			oleDb.dataSet.Clear();
			oleDb.dataSet.DataSetName = "Practice";
			if(actionFolder == "" && folderExplore == true) {
				oleDb.oleDbCommandSelect.CommandText = "SELECT * FROM Practice WHERE (type = '"+Constants.TYPE_FILE+"' AND parent = '') ORDER BY name ASC";
			}else{
				if(folderExplore == false) oleDb.oleDbCommandSelect.CommandText = "SELECT * FROM Practice WHERE (type = '"+Constants.TYPE_FILE+"') ORDER BY name ASC";
				else oleDb.oleDbCommandSelect.CommandText = "SELECT * FROM Practice WHERE (type = '"+Constants.TYPE_FILE+"' AND parent = '"+actionFolder+"') ORDER BY name ASC";
			}
			if(oleDb.ExecuteFill("Practice")){
				filesTable = oleDb.dataSet.Tables["Practice"].Copy();
			}else{
				Utilits.Console.LogError("Ошибка выполнения запроса к таблице Номенклатура при отборе файлов.", false, true);
				oleDb.Error();
				return;
			}
			// ОТОБРАЖЕНИЕ: "Папок"
			ListViewItem ListViewItem_add;
			foreach(DataRow rowFolder in foldersTable.Rows)
    		{
				ListViewItem_add = new ListViewItem();
				if(actionFolder == "") ListViewItem_add.SubItems.Add(rowFolder["name"].ToString());
				else ListViewItem_add.SubItems.Add("..");
				ListViewItem_add.StateImageIndex = 0;
				ListViewItem_add.SubItems.Add("Папка");
				ListViewItem_add.SubItems.Add(rowFolder["ID"].ToString());
				ListViewItem_add.SubItems.Add(rowFolder["name"].ToString());
				listView1.Items.Add(ListViewItem_add);
			}
			// ОТОБРАЖЕНИЕ "Файлов"
			foreach(DataRow rowElement in filesTable.Rows)
    		{
				ListViewItem_add = new ListViewItem();
				ListViewItem_add.SubItems.Add(rowElement["name"].ToString());
				ListViewItem_add.StateImageIndex = 1;
				ListViewItem_add.SubItems.Add("");
				ListViewItem_add.SubItems.Add(rowElement["ID"].ToString());
				ListViewItem_add.SubItems.Add(rowElement["name"].ToString());
				listView1.Items.Add(ListViewItem_add);
			}
			// ВЫБОР: выдиляем ранее выбранный элемент.
			listView1.SelectedIndices.IndexOf(selectTableLine);
		}
		
		void hierarchy() // иерархическое отображение
		{
			if(folderExplore){
				folderExplore = false;
				TableRefresh(""); // отображается всё содержимое
			}else{
				folderExplore = true;
				TableRefresh(openFolder); //возвращаемся в последнюю активную папку.
			}
		}
		
		void showOpenCloseFolder() // показать открытую папку
		{
			if(listView1.Items[listView1.SelectedIndices[0]].SubItems[2].Text.ToString() == "Папка" && folderExplore){
				if(listView1.Items[listView1.SelectedIndices[0]].SubItems[1].Text.ToString() != ".."){
					openFolder = listView1.Items[listView1.SelectedIndices[0]].SubItems[1].Text.ToString();
					TableRefresh(openFolder);
				}else {
					openFolder = "";
					TableRefresh(openFolder);
				}
			}	
		}
		
		void search()
		{
			try{
				searchLocal();
				Utilits.Console.Log(this.Text + ": поиск завершен.");
			}catch(Exception ex){
				oleDb.Error();
				Utilits.Console.LogError(ex.Message.ToString(), false, true);
			}
			if(toolStripComboBox1.Text != "") toolStripComboBox1.Items.Add(toolStripComboBox1.Text);
		}
		
		void searchLocal()
		{
			DataTable table;
			oleDb = new OleDb(Config.databaseFile);
			oleDb.dataSet.Clear();
			oleDb.dataSet.DataSetName = "Practice";
			oleDb.oleDbCommandSelect.CommandText = "SELECT * FROM Practice WHERE (name LIKE '%" + toolStripComboBox1.Text + "%') ORDER BY name ASC";
			if(oleDb.ExecuteFill("Practice")){
				table = oleDb.dataSet.Tables["Practice"];
			}else{
				Utilits.Console.LogError("Ошибка поиска.", false, true);
				oleDb.Error();
				return;
			}
			listView1.Items.Clear();
			ListViewItem ListViewItem_add;
			foreach(DataRow row in table.Rows)
        	{
				ListViewItem_add = new ListViewItem();
				ListViewItem_add.SubItems.Add(row["name"].ToString());
				if(row["type"].ToString() == Constants.TYPE_FOLDER){
					ListViewItem_add.StateImageIndex = 0;
					ListViewItem_add.SubItems.Add("Папка");
				}else{
					ListViewItem_add.StateImageIndex = 1;
					ListViewItem_add.SubItems.Add("");
				}
				ListViewItem_add.SubItems.Add(row["ID"].ToString());
				ListViewItem_add.SubItems.Add(row["name"].ToString());
				listView1.Items.Add(ListViewItem_add);
			}
		}
		
		void addFolder()
		{
			PracticeFolderForm pfForm = new PracticeFolderForm();
			pfForm.MdiParent = Forms.FClient;
			pfForm.ThisIsNew = true;
			pfForm.DataType = Constants.TYPE_FOLDER_NEW;
			pfForm.ParentForm = this;
			pfForm.Show();
		}
		
		void editFolder()
		{
			if(listView1.SelectedIndices.Count > 0){
				if(listView1.Items[listView1.SelectedIndices[0]].SubItems[2].Text.ToString() == "Папка" 
				   && listView1.Items[listView1.SelectedIndices[0]].SubItems[1].Text.ToString() != ".." 
				   && listView1.SelectedItems[0].StateImageIndex == 0){
					
					PracticeFolderForm pfForm = new PracticeFolderForm();
					pfForm.MdiParent = Forms.FClient;
					pfForm.ThisIsNew = false;
					pfForm.ID = listView1.Items[listView1.SelectedIndices[0]].SubItems[3].Text;
					pfForm.DataType = Constants.TYPE_FOLDER_EDIT;
					pfForm.ParentForm = this;
					pfForm.Show();
					
				}
			}
		}
		
		void deleteFolder()
		{
			if(listView1.SelectedIndices.Count > 0){
				if(listView1.Items[listView1.SelectedIndices[0]].SubItems[2].Text.ToString() == "Папка" 
				   && listView1.Items[listView1.SelectedIndices[0]].SubItems[1].Text.ToString() != ".." 
				   && listView1.SelectedItems[0].StateImageIndex == 0){
					String folderID = listView1.Items[listView1.SelectedIndices[0]].SubItems[3].Text.ToString();
					String folderName = listView1.Items[listView1.SelectedIndices[0]].SubItems[1].Text.ToString();
					
					if(MessageBox.Show("Удалить безвозвратно папку '" + folderName + "' и всё её содержимое ?"  ,"Вопрос:", MessageBoxButtons.YesNo) == DialogResult.Yes){
						
						QueryOleDb query = new QueryOleDb(Config.databaseFile);
						query.SetCommand("DELETE FROM Practice WHERE (parent ='" + folderName +"')");
						if(query.Execute()){
							query = new QueryOleDb(Config.databaseFile);
							query.SetCommand("DELETE FROM Practice WHERE (id = " + folderID +")");
							if(query.Execute()){
								query.Dispose();
								Utilits.Console.Log("Удаление папки '" + folderName + "' прошло успешно.");
							}else{
								query.Dispose();
								Utilits.Console.LogError("Папку '" + folderName + "' не удалось удалить!", false, true);
							}
						}else{
							query.Dispose();
							Utilits.Console.LogError("Ошибка удаления файлов в папке '" + folderName + "'", false, true);
						}
						
						TableRefresh("");
					}
				}
			}
		}
		
		void addFile()
		{
			PracticeFileForm pfForm = new PracticeFileForm();
			pfForm.MdiParent = Forms.FClient;
			pfForm.ThisIsNew = true;
			pfForm.DataType = Constants.TYPE_FILE_NEW;
			pfForm.ParentForm = this;
			pfForm.ParentFolder = openFolder;
			pfForm.Show();
		}
		
		void editFile()
		{
			if(listView1.SelectedIndices.Count > 0){
				if(listView1.Items[listView1.SelectedIndices[0]].SubItems[2].Text.ToString() == "" 
				   && listView1.Items[listView1.SelectedIndices[0]].SubItems[1].Text.ToString() != ".." 
				   && listView1.SelectedItems[0].StateImageIndex == 1){
					
					PracticeFileForm pfForm = new PracticeFileForm();
					pfForm.MdiParent = Forms.FClient;
					pfForm.ThisIsNew = false;
					pfForm.ID = listView1.Items[listView1.SelectedIndices[0]].SubItems[3].Text;
					pfForm.DataType = Constants.TYPE_FILE_EDIT;
					pfForm.ParentForm = this;
					pfForm.ParentFolder = openFolder;
					pfForm.Show();
					
				}
			}
		}
		
		void deleteFile()
		{
			if(listView1.SelectedIndices.Count > 0){
				if(listView1.Items[listView1.SelectedIndices[0]].SubItems[2].Text.ToString() != "Папка" 
				   && listView1.Items[listView1.SelectedIndices[0]].SubItems[1].Text.ToString() != ".." 
				   && listView1.SelectedItems[0].StateImageIndex == 1)
				{
					String fileID = listView1.Items[listView1.SelectedIndices[0]].SubItems[3].Text.ToString();
					String fileName = listView1.Items[listView1.SelectedIndices[0]].SubItems[1].Text.ToString();
					
					if(MessageBox.Show("Удалить безвозвратно тест '" + fileName + "' ?"  ,"Вопрос:", MessageBoxButtons.YesNo) == DialogResult.Yes){
						
						QueryOleDb query = new QueryOleDb(Config.databaseFile);
						query.SetCommand("DELETE FROM Practice WHERE (ID = " + fileID +")");
						if(query.Execute()){
							
						}else{
							query.Dispose();
							Utilits.Console.LogError("Ошибка удаления теста '" + fileName + "'", false, true);
						}
						
						TableRefresh("");
					}
				}
			}
		}
		
		void testRun()
		{
			if(listView1.SelectedIndices.Count > 0){
				if(listView1.Items[listView1.SelectedIndices[0]].SubItems[2].Text.ToString() == "" 
				   && listView1.Items[listView1.SelectedIndices[0]].SubItems[1].Text.ToString() != ".." 
				   && listView1.SelectedItems[0].StateImageIndex == 1){
					TestForm tForm = new TestForm();
					tForm.MdiParent = Forms.FClient;
					tForm.Text = "Тест: " + listView1.Items[listView1.SelectedIndices[0]].SubItems[1].Text;
					tForm.ID = listView1.Items[listView1.SelectedIndices[0]].SubItems[3].Text;
					tForm.Show();
				}
			}
		}
		
		void PracticeFormLoad(object sender, EventArgs e)
		{
			TableRefresh("");
		}
		void PracticeFormFormClosed(object sender, FormClosedEventArgs e)
		{
			Forms.FPractice = null;
		}
		void ToolStripButton10Click(object sender, EventArgs e)
		{
			TableRefresh(openFolder);
		}
		void ToolStripButton7Click(object sender, EventArgs e)
		{
			hierarchy();  // иерархическое отображение
		}
		void ListView1SelectedIndexChanged(object sender, EventArgs e)
		{
			// выбранная строка таблицы
			if(listView1.SelectedItems.Count > 0) selectTableLine = listView1.SelectedItems[0].Index; // индекс выбраной строки
		}
		void ListView1DoubleClick(object sender, EventArgs e)
		{
			showOpenCloseFolder(); // показать открытую папку
		}
		void ToolStripButton9Click(object sender, EventArgs e)
		{
			openFolder = "";
			search(); // поиск
		}
		void ToolStripComboBox1KeyDown(object sender, KeyEventArgs e)
		{
			if(e.KeyData == Keys.Enter){
				search(); // поиск
			}
		}
		void ButtonCloseClick(object sender, EventArgs e)
		{
			Close();
		}
		void ToolStripButton4Click(object sender, EventArgs e)
		{
			addFolder();
		}
		void ToolStripButton5Click(object sender, EventArgs e)
		{
			editFolder();
		}
		void ToolStripButton6Click(object sender, EventArgs e)
		{
			deleteFolder();
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
		void СоздатьПапкуToolStripMenuItemClick(object sender, EventArgs e)
		{
			addFolder();
		}
		void ИзменитьПапкуToolStripMenuItemClick(object sender, EventArgs e)
		{
			editFolder();
		}
		void УдалитьПапкуToolStripMenuItemClick(object sender, EventArgs e)
		{
			deleteFolder();
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
		void ToolStripButton8Click(object sender, EventArgs e)
		{
			testRun();
		}
		void ВыполнитьТестToolStripMenuItemClick(object sender, EventArgs e)
		{
			testRun();
		}
	}
}
