/*
 * Created by SharpDevelop.
 * User: Catfish
 * Date: 02.02.2019
 * Time: 10:28
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;
using EnglishTrainer.Data;
using EnglishTrainer.Database.Local;

namespace EnglishTrainer.Client.PracticeTests
{
	/// <summary>
	/// Description of PracticeFolderForm.
	/// </summary>
	public partial class PracticeFolderForm : Form
	{
		public PracticeFolderForm()
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
		
		OleDb oleDb;
		string oldName;
				
		void initNewFolder()
		{
			
			oleDb = new OleDb(Config.databaseFile);
			oleDb.dataSet.Clear();
			oleDb.dataSet.DataSetName = "Practice";
			
			oleDb.oleDbCommandSelect.CommandText = "SELECT * FROM Practice";
			//oleDb.ExecuteFill("Practice");
		}
		
		void initEditFolder()
		{
			
			oleDb = new OleDb(Config.databaseFile);
			oleDb.dataSet.Clear();
			oleDb.dataSet.DataSetName = "Practice";
			
			oleDb.oleDbCommandSelect.CommandText = "SELECT * FROM Practice WHERE (ID = " + ID + ")";
			oleDb.ExecuteFill("Practice");
			textBox1.Text = oleDb.dataSet.Tables["Practice"].Rows[0]["ID"].ToString();
			textBox2.Text = oleDb.dataSet.Tables["Practice"].Rows[0]["name"].ToString();
			
			oldName = textBox2.Text;
		}
		
		void saveNewFolder()
		{
			oleDb.dataSet.Clear();
			oleDb.dataSet.DataSetName = "Practice";
			oleDb.oleDbCommandSelect.CommandText = "SELECT * FROM Practice";
			oleDb.ExecuteFill("Practice");
			
			oleDb.oleDbCommandInsert.CommandText = "INSERT INTO Practice (type, name, parent) VALUES (@type, @name, @parent)";
			oleDb.oleDbCommandInsert.Parameters.Add("@type", OleDbType.VarChar, 255, "type");
			oleDb.oleDbCommandInsert.Parameters.Add("@name", OleDbType.VarChar, 255, "name");
			oleDb.oleDbCommandInsert.Parameters.Add("@parent", OleDbType.VarChar, 255, "parent");

			DataRow newRow = oleDb.dataSet.Tables["Practice"].NewRow();
			newRow["type"] = Constants.TYPE_FOLDER;
			newRow["name"] = textBox2.Text;
			newRow["parent"] = "";
			oleDb.dataSet.Tables["Practice"].Rows.Add(newRow);
			
			if(oleDb.ExecuteUpdate("Practice")){
				Utilits.Console.Log("Новая папка - успешно сохранена.");
				Close();
				(ParentForm as PracticeForm).TableRefresh("");
			}
		}
		
		void saveEditFolder()
		{
			oleDb.oleDbCommandUpdate.Parameters.Add("@type", OleDbType.VarChar, 255, "type");
			oleDb.oleDbCommandUpdate.Parameters.Add("@name", OleDbType.VarChar, 255, "name");
			oleDb.oleDbCommandUpdate.Parameters.Add("@parent", OleDbType.VarChar, 255, "parent");
			oleDb.oleDbCommandUpdate.Parameters.Add("@ID", OleDbType.Integer, 10, "ID");
			
			oleDb.dataSet.Tables["Practice"].Rows[0]["name"] = textBox2.Text;
			oleDb.oleDbCommandUpdate.CommandText = "UPDATE Practice SET " +
				"[type] = @type, [name] = @name, [parent] = @parent " +
				"WHERE ([ID] = @ID)";
			
			if(oleDb.ExecuteUpdate("Practice")){
				moveFilesInRenameFolder();
				Utilits.Console.Log("Изменение папки - успешно сохранена.");
				Close();
				(ParentForm as PracticeForm).TableRefresh("");
			}
		}
		
		void moveFilesInRenameFolder()
		{
			QueryOleDb query = new QueryOleDb(Config.databaseFile);
			query.SetCommand("UPDATE Practice SET parent='" + textBox2.Text + "' WHERE(parent = '" + oldName + "')");
			query.Execute();
			query.Dispose();
		}
		
		void PracticeFolderFormLoad(object sender, EventArgs e)
		{
			if(ThisIsNew){
				Text = "Новая папка";
				textBox1.Clear();
			}
			else{
				Text = "Редактировать папку";
				textBox1.Text = ID;
			}
			
			if(DataType == Constants.TYPE_FOLDER_NEW) initNewFolder();
			if(DataType == Constants.TYPE_FOLDER_EDIT) initEditFolder();
		}
		void ButtonCloseClick(object sender, EventArgs e)
		{
			Close();
		}
		void ButtonSaveClick(object sender, EventArgs e)
		{
			if(DataType == Constants.TYPE_FOLDER_NEW) saveNewFolder();
			if(DataType == Constants.TYPE_FOLDER_EDIT) saveEditFolder();
		}
		
	}
}
