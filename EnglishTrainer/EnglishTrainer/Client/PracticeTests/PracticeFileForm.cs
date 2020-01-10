/*
 * Created by SharpDevelop.
 * User: Catfish
 * Date: 02.02.2019
 * Time: 10:29
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Windows.Forms;
using EnglishTrainer.Data;
using EnglishTrainer.Database.Local;

namespace EnglishTrainer.Client.PracticeTests
{
	/// <summary>
	/// Description of PracticeFileForm.
	/// </summary>
	public partial class PracticeFileForm : Form
	{
		public PracticeFileForm()
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
		public string DataType;
		public bool ThisIsNew;
		public Form ParentForm;
		public String ParentFolder;
		
		OleDb oleDb;
		string oldName;
		List<int> idDeletedList;
		
		void addTest()
		{
			PracticeFileEditForm pfeForm = new PracticeFileEditForm();
			pfeForm.ParentListView = listView1;
			pfeForm.MdiParent = Forms.FClient;
			pfeForm.ThisIsNew = true;
			pfeForm.Show();
		}
		
		void editTest()
		{
			PracticeFileEditForm pfeForm = new PracticeFileEditForm();
			pfeForm.ParentListView = listView1;
			pfeForm.MdiParent = Forms.FClient;
			pfeForm.ThisIsNew = false;
			pfeForm.SelectIndex = listView1.SelectedIndices[0];
			pfeForm.Show();
		}
		
		void deleteTest()
		{
			int selectIndex = listView1.SelectedIndices[0];
			if(MessageBox.Show("Удалить запись '" + listView1.Items[selectIndex].SubItems[1].Text + "' ?"  ,"Вопрос:", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				if(listView1.Items[selectIndex].SubItems[5].Text != "+")
				{
					idDeletedList.Add(Convert.ToInt32(listView1.Items[selectIndex].SubItems[5].Text));
				}
				listView1.Items[selectIndex].Remove();
			}
		}
		
		void loadFolders()
		{
			oleDb = new OleDb(Config.databaseFile);
			oleDb.oleDbCommandSelect.CommandText = "SELECT name FROM Practice WHERE (type = '" + Constants.TYPE_FOLDER +"')";
			if(oleDb.ExecuteFill("Practice")){
				comboBox1.Items.Clear();
				foreach(DataRow row in oleDb.dataSet.Tables["Practice"].Rows){
					comboBox1.Items.Add(row["name"].ToString());
				}
			}
			comboBox1.Text = ParentFolder;
		}
		
		void initNewFile()
		{
			oleDb = new OleDb(Config.databaseFile);
			oleDb.dataSet.Clear();
			oleDb.dataSet.DataSetName = "Practice";
			
			oleDb.oleDbCommandSelect.CommandText = "SELECT * FROM Practice";
			//oleDb.ExecuteFill("Practice");
		}
		
		void initEditFile()
		{
			
			oleDb = new OleDb(Config.databaseFile);
			oleDb.dataSet.Clear();
			oleDb.dataSet.DataSetName = "Practice";
			
			oleDb.oleDbCommandSelect.CommandText = "SELECT * FROM Practice WHERE (ID = " + ID + ")";
			oleDb.ExecuteFill("Practice");
			textBox1.Text = oleDb.dataSet.Tables["Practice"].Rows[0]["ID"].ToString();
			textBox2.Text = oleDb.dataSet.Tables["Practice"].Rows[0]["name"].ToString();
			comboBox1.Text = oleDb.dataSet.Tables["Practice"].Rows[0]["parent"].ToString();
			
			oldName = textBox2.Text;
			
			/* Загрузить вложенные тесты */
			DataTable table;
			oleDb = new OleDb(Config.databaseFile);
			oleDb.dataSet.Clear();
			oleDb.dataSet.DataSetName = "Tests";
			oleDb.oleDbCommandSelect.CommandText = "SELECT * FROM Tests WHERE (IDPractice = " + textBox1.Text + ") ORDER BY ID ASC";
			if(oleDb.ExecuteFill("Tests")){
				table = oleDb.dataSet.Tables["Tests"];
				
				listView1.Items.Clear();
				ListViewItem ListViewItem_add;
				foreach(DataRow row in table.Rows)
	        	{
					ListViewItem_add = new ListViewItem();
					ListViewItem_add.SubItems.Add(row["condition"].ToString());
					ListViewItem_add.StateImageIndex = 1;
					ListViewItem_add.SubItems.Add(row["question"].ToString());
					ListViewItem_add.SubItems.Add(row["answer"].ToString());
					ListViewItem_add.SubItems.Add(row["hint"].ToString());
					ListViewItem_add.SubItems.Add(row["ID"].ToString());
					listView1.Items.Add(ListViewItem_add);
				}
				
			}else{
				Utilits.Console.LogError("Ошибка загрузки вложенных тестов.", false, true);
				oleDb.Error();
				return;
			}
		}
		
		void saveNewFile()
		{
			/* Создание теста */
			oleDb = new OleDb(Config.databaseFile);
			oleDb.dataSet.Clear();
			oleDb.dataSet.DataSetName = "Practice";
			oleDb.oleDbCommandSelect.CommandText = "SELECT * FROM Practice";
			oleDb.ExecuteFill("Practice");
			
			oleDb.oleDbCommandInsert.CommandText = "INSERT INTO Practice (type, name, parent) VALUES (@type, @name, @parent)";
			oleDb.oleDbCommandInsert.Parameters.Add("@type", OleDbType.VarChar, 255, "type");
			oleDb.oleDbCommandInsert.Parameters.Add("@name", OleDbType.VarChar, 255, "name");
			oleDb.oleDbCommandInsert.Parameters.Add("@parent", OleDbType.VarChar, 255, "parent");

			DataRow newRow = oleDb.dataSet.Tables["Practice"].NewRow();
			newRow["type"] = Constants.TYPE_FILE;
			newRow["name"] = textBox2.Text;
			newRow["parent"] = comboBox1.Text;
			oleDb.dataSet.Tables["Practice"].Rows.Add(newRow);
			
			if(oleDb.ExecuteUpdate("Practice"))
			{
				oleDb = new OleDb(Config.databaseFile);
				oleDb.dataSet.Clear();
				oleDb.dataSet.DataSetName = "Practice";
				oleDb.oleDbCommandSelect.CommandText = "SELECT * FROM Practice WHERE (name = '" + textBox2.Text + "')";
				oleDb.ExecuteFill("Practice");
				int idPractice = Convert.ToInt32(oleDb.dataSet.Tables["Practice"].Rows[0]["ID"].ToString());
				
				/* Добавление записей в тест */
				oleDb = new OleDb(Config.databaseFile);
				oleDb.dataSet.Clear();
				oleDb.dataSet.DataSetName = "Tests";
				oleDb.oleDbCommandSelect.CommandText = "SELECT * FROM Tests";
				oleDb.ExecuteFill("Tests");
				
				oleDb.oleDbCommandInsert.CommandText = "INSERT INTO Tests (IDPractice, condition, question, answer, hint) VALUES (@IDPractice, @condition, @question, @answer, @hint)";
				oleDb.oleDbCommandInsert.Parameters.Add("@IDPractice", OleDbType.Integer, 10, "IDPractice");
				oleDb.oleDbCommandInsert.Parameters.Add("@condition", OleDbType.VarChar, 255, "condition");
				oleDb.oleDbCommandInsert.Parameters.Add("@question", OleDbType.VarChar, 255, "question");
				oleDb.oleDbCommandInsert.Parameters.Add("@answer", OleDbType.VarChar, 255, "answer");
				oleDb.oleDbCommandInsert.Parameters.Add("@hint", OleDbType.VarChar, 255, "hint");
				
				newRow = null;
				foreach(ListViewItem value in listView1.Items)
				{
					newRow = oleDb.dataSet.Tables["Tests"].NewRow();
					newRow["IDPractice"] = idPractice;
					newRow["condition"] = value.SubItems[1].Text;
					newRow["question"] = value.SubItems[2].Text;
					newRow["answer"] = value.SubItems[3].Text;
					newRow["hint"] = value.SubItems[4].Text;
					oleDb.dataSet.Tables["Tests"].Rows.Add(newRow);
				}
				
				if(oleDb.ExecuteUpdate("Tests"))
				{
					Utilits.Console.Log("Тест '" + comboBox1.Text + "\\" + textBox2.Text + "' - успешно создан.");
					Close();
					(ParentForm as PracticeForm).TableRefresh();
				}else{
					Utilits.Console.LogError("Не удалось записать пункты теста '" + textBox2.Text + "'");
				}
			
			}else{
				Utilits.Console.LogError("Не удалось создать новый тест '" + textBox2.Text + "'");
			}
			
		}
		
		void saveEditFile()
		{
			/* Изменение теста */
			oleDb = new OleDb(Config.databaseFile);
			oleDb.dataSet.Clear();
			oleDb.dataSet.DataSetName = "Practice";
			oleDb.oleDbCommandSelect.CommandText = "SELECT * FROM Practice WHERE (ID = " + ID + ")";
			oleDb.ExecuteFill("Practice");
			
			oleDb.oleDbCommandUpdate.CommandText = "UPDATE Practice SET " +
					"[type] = @type, [name] = @name, [parent] = @parent " +
					"WHERE ([ID] = @ID)";
			oleDb.oleDbCommandUpdate.Parameters.Add("@type", OleDbType.VarChar, 255, "type");
			oleDb.oleDbCommandUpdate.Parameters.Add("@name", OleDbType.VarChar, 255, "name");
			oleDb.oleDbCommandUpdate.Parameters.Add("@parent", OleDbType.VarChar, 255, "parent");
			oleDb.oleDbCommandUpdate.Parameters.Add("@ID", OleDbType.Integer, 10, "ID");
			
			oleDb.dataSet.Tables["Practice"].Rows[0]["name"] = textBox2.Text;
			oleDb.dataSet.Tables["Practice"].Rows[0]["parent"] = comboBox1.Text;
			
			if(oleDb.ExecuteUpdate("Practice")){
				
				// Редактирование записей в тесте
				if(idDeletedList.Count > 0) // Удаление записей
				{
					foreach(int deleteId in idDeletedList)
					{
						QueryOleDb query = new QueryOleDb(Config.databaseFile);
						query.SetCommand("DELETE FROM Tests WHERE (ID = " + deleteId +")");
						query.Execute();
					}
				}
				
				oleDb = new OleDb(Config.databaseFile);
				oleDb.dataSet.Clear();
				oleDb.dataSet.DataSetName = "Tests";
				oleDb.oleDbCommandSelect.CommandText = "SELECT * FROM Tests WHERE (IDPractice = " + textBox1.Text + ") ORDER BY ID ASC";
				oleDb.ExecuteFill("Tests");
				
				oleDb.oleDbCommandInsert.CommandText = "INSERT INTO Tests (IDPractice, condition, question, answer, hint) VALUES (@IDPractice, @condition, @question, @answer, @hint)";
				oleDb.oleDbCommandInsert.Parameters.Add("@IDPractice", OleDbType.Integer, 10, "IDPractice");
				oleDb.oleDbCommandInsert.Parameters.Add("@condition", OleDbType.VarChar, 255, "condition");
				oleDb.oleDbCommandInsert.Parameters.Add("@question", OleDbType.VarChar, 255, "question");
				oleDb.oleDbCommandInsert.Parameters.Add("@answer", OleDbType.VarChar, 255, "answer");
				oleDb.oleDbCommandInsert.Parameters.Add("@hint", OleDbType.VarChar, 255, "hint");
				
				oleDb.oleDbCommandUpdate.CommandText = "UPDATE Tests SET " +
					"[IDPractice] = @IDPractice, [condition] = @condition, " +
					"[question] = @question, [answer] = @answer, [hint] = @hint " +
					"WHERE ([ID] = @ID)";
				oleDb.oleDbCommandUpdate.Parameters.Add("@IDPractice", OleDbType.Integer, 10, "IDPractice");
				oleDb.oleDbCommandUpdate.Parameters.Add("@condition", OleDbType.VarChar, 255, "condition");
				oleDb.oleDbCommandUpdate.Parameters.Add("@question", OleDbType.VarChar, 255, "question");
				oleDb.oleDbCommandUpdate.Parameters.Add("@answer", OleDbType.VarChar, 255, "answer");
				oleDb.oleDbCommandUpdate.Parameters.Add("@hint", OleDbType.VarChar, 255, "hint");
				oleDb.oleDbCommandUpdate.Parameters.Add("@ID", OleDbType.Integer, 10, "ID");
				
				DataRow newRow;
				foreach(ListViewItem value in listView1.Items)
				{
					if(value.SubItems[5].Text == "+")
					{
						newRow = null;
						newRow = oleDb.dataSet.Tables["Tests"].NewRow();
						newRow["IDPractice"] = textBox1.Text;
						newRow["condition"] = value.SubItems[1].Text;
						newRow["question"] = value.SubItems[2].Text;
						newRow["answer"] = value.SubItems[3].Text;
						newRow["hint"] = value.SubItems[4].Text;
						oleDb.dataSet.Tables["Tests"].Rows.Add(newRow);
					}else{
						foreach(DataRow row in oleDb.dataSet.Tables["Tests"].Rows)
						{
							if(row["ID"].ToString() == value.SubItems[5].Text.ToString())
							{
								row["condition"] = value.SubItems[1].Text;
								row["question"] = value.SubItems[2].Text;
								row["answer"] = value.SubItems[3].Text;
								row["hint"] = value.SubItems[4].Text;	
								break;
							}
						}
					}
				}
				
				if(oleDb.ExecuteUpdate("Tests"))
				{
					Utilits.Console.Log("Изменения в тесте '" + comboBox1.Text + "\\" + textBox2.Text + "' - успешно сохранены.");
					Close();
					(ParentForm as PracticeForm).TableRefresh();
				}else{
					Utilits.Console.LogError("Не удалось записать изменённые пункты теста '" + textBox2.Text + "'");
				}
				
			}else{
				Utilits.Console.LogError("Не удалось сохранить изменения в тесте '" + oldName + "'");
			}
			
		}
		
		void PracticeFileFormLoad(object sender, EventArgs e)
		{
			if(ThisIsNew){
				Text = "Новый тест";
				textBox1.Clear();
			}
			else{
				Text = "Редактировать тест";
				textBox1.Text = ID;
			}
			
			idDeletedList = new List<int>();
			
			if(DataType == Constants.TYPE_FILE_NEW) initNewFile();
			if(DataType == Constants.TYPE_FILE_EDIT) initEditFile();
			
			loadFolders();
		}
		
		void ToolStripButton1Click(object sender, EventArgs e)
		{
			addTest();
		}
		void ToolStripButton2Click(object sender, EventArgs e)
		{
			editTest();
		}
		void ToolStripButton3Click(object sender, EventArgs e)
		{
			deleteTest();
		}
		void СоздатьЗаписьToolStripMenuItemClick(object sender, EventArgs e)
		{
			addTest();
		}
		void ИзменитьЗаписьToolStripMenuItemClick(object sender, EventArgs e)
		{
			editTest();
		}
		void УдалитьЗаписьToolStripMenuItemClick(object sender, EventArgs e)
		{
			deleteTest();
		}
		void ButtonCloseClick(object sender, EventArgs e)
		{
			Close();
		}
		void ButtonSaveClick(object sender, EventArgs e)
		{
			if(DataType == Constants.TYPE_FILE_NEW) saveNewFile();
			if(DataType == Constants.TYPE_FILE_EDIT) saveEditFile();
		}
	}
}
