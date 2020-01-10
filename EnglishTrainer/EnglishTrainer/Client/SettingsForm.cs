/*
 * Created by SharpDevelop.
 * User: Catfish
 * Date: 27.01.2019
 * Time: 12:14
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using EnglishTrainer.Data;
using EnglishTrainer.Utilits;

namespace EnglishTrainer.Client
{
	/// <summary>
	/// Description of SettingsForm.
	/// </summary>
	public partial class SettingsForm : Form
	{
		public SettingsForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		
		
		void ButtonCloseClick(object sender, EventArgs e)
		{
			Close();
		}
		void SettingsFormLoad(object sender, EventArgs e)
		{
			textBox1.Text = YandexTranslator.Key;
		}
		void ButtonReturnClick(object sender, EventArgs e)
		{
			YandexTranslator.Key = textBox1.Text;
			IOFiles.SaveConfigFile();
			Close();
		}
		void LinkLabel1LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			try{
				System.Diagnostics.Process.Start(linkLabel1.Text);
			}catch(Exception ex){
				Utilits.Console.LogError(ex.Message, false, true);
			}
		}
		void SettingsFormFormClosed(object sender, FormClosedEventArgs e)
		{
			Forms.FSettings = null;
		}
	}
}
