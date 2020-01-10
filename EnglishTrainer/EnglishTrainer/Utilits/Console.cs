/*
 * Created by SharpDevelop.
 * User: Catfish
 * Date: 14.11.2018
 * Time: 9:18
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;
using System.Windows.Forms;
using EnglishTrainer.Data;

namespace EnglishTrainer.Utilits
{
	/// <summary>
	/// Description of Console.
	/// </summary>
	public static class Console
	{
		public static void Log(String message, bool clear = false, bool show = false)
		{
			if(Forms.FClient != null){
				if(Forms.FClient.consoleTextBox.Text.Length > 10000) Forms.FClient.consoleTextBox.Clear();
				if(show){
					Forms.FClient.consolePanel.Visible = true;
				}
				if(clear){
					Forms.FClient.consoleTextBox.Clear();
					Forms.FClient.consoleTextBox.Text = "[" + DateTime.Now.ToString() + "]: " + message;
				}else{
					Forms.FClient.consoleTextBox.Text = "[" + DateTime.Now.ToString() + "]: " + message + Environment.NewLine + Forms.FClient.consoleTextBox.Text;
				}
			}else{
				if(show) MessageBox.Show(message, "Сообщение");
			}
		}
		
		public static void LogError(String message, bool clear = false, bool show = false)
		{
			if(Forms.FClient != null){
				if(Forms.FClient.consoleTextBox.Text.Length > 10000) Forms.FClient.consoleTextBox.Clear();
				if(show){
					Forms.FClient.consolePanel.Visible = true;
				}
				if(clear){
					Forms.FClient.consoleTextBox.Clear();
					Forms.FClient.consoleTextBox.Text = "[" + DateTime.Now.ToString() + "] ОШИБКА: " + message;
				}else{
					Forms.FClient.consoleTextBox.Text = "[" + DateTime.Now.ToString() + "] ОШИБКА: " + message + Environment.NewLine + Forms.FClient.consoleTextBox.Text;
				}
				File.WriteAllText(Config.resource +  "log_error.txt", Forms.FClient.consoleTextBox.Text);
			}else{
				if(show) MessageBox.Show("ОШИБКА: " + message, "Ошибка");
				File.WriteAllText(Config.resource +  "log_error_" + String.Format("{0}_{1}_{2}_{3}_{4}", DateTime.Now.Day.ToString(),  DateTime.Now.Month.ToString(), DateTime.Now.Year.ToString(), DateTime.Now.Hour.ToString(), DateTime.Now.Second.ToString()) +".txt", message);
			}
		}
	}
}
