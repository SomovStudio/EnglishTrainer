/*
 * Created by SharpDevelop.
 * User: Catfish
 * Date: 12.11.2018
 * Time: 8:51
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using EnglishTrainer.Data;
using EnglishTrainer.Client;
using EnglishTrainer.Database;
using EnglishTrainer.Utilits;

namespace EnglishTrainer
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		void MainFormLoad(object sender, EventArgs e)
		{
			Forms.FMain = this;
			timer1.Start();
		}
		
		void Timer1Tick(object sender, EventArgs e)
		{
			timer1.Stop();
			
			try {
				initLocalPath();
				initResource();
				initLocalBase();
			}catch(Exception ex){
				MessageBox.Show("Произошла следующая ошибка: " + ex.Message + Environment.NewLine + Environment.NewLine + "Возможное решение проблемы: запустите программу от имени администратора.", "Сообщение");
				Application.Exit();
			}
		}
		
		
		void initLocalPath()
		{
			//определяем расположение программы (путь)
			Config.programPath = Environment.CurrentDirectory + "\\";
			//расположение папки ресурсов
			Config.resource = Config.programPath + "resource\\";
		}
		
		void initResource()
		{
			//Проверка существования папки
			if(!Directory.Exists(Config.resource)){
				//папки нет, она будет создана заново
				Directory.CreateDirectory(Config.resource);
			}
		}
		
		void initLocalBase()
		{
			// Проверка файла настроек (конфиг файл)
			if(!File.Exists(Config.resource + "config.cfg")){
				IOFiles.CreateConfigFile();
			}
			IOFiles.ReadConfigFile();
			
			// Поиск локальной базы данный Database
			Config.databaseFile = Config.resource + "database.mdb";
			if(!File.Exists(Config.databaseFile)){
				// файл не найден, он будет создан
				Config.oledbConnectString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=";
				CreateDatabaseMSAccess createDatabaseMSAccess = new CreateDatabaseMSAccess(Config.databaseFile);
				createDatabaseMSAccess.CreateDB();
			}
			
			// проверка целосности данных
			if(VerificationDatabaseMSAccess.Verification())
			{
				showClient();	
			}
			else
			{
				MessageBox.Show("База данных испорчена, её нужно удалить и перезапустить приложение." + Environment.NewLine + "При следующем запуске будет создана новая база данных.", "Сообщение");
				DialogResult dialogResult = MessageBox.Show("Удалить испорченную базу данных?", "Вопрос", MessageBoxButtons.YesNo);
				if(dialogResult == DialogResult.Yes)
				{
				    if(File.Exists(Config.databaseFile)) File.Delete(Config.databaseFile);
				}				
				Application.Exit();
			}
		}
		
		public void progressLoad(int value)
		{
			progressBar1.Visible = true;
			progressBar1.Value = value;
		}
		
		void showClient()
		{
			// Открываем окно выбора пользователя
			Forms.FClient = new FormClient();
			Forms.FClient.Show();
			Forms.FMain.Visible = false;
		}
		
		void MainFormFormClosed(object sender, FormClosedEventArgs e)
		{
			Dispose();
		}
	}
}
