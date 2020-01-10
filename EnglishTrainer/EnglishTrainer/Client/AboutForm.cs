/*
 * Created by SharpDevelop.
 * User: Catfish
 * Date: 02.02.2019
 * Time: 9:37
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace EnglishTrainer.Client
{
	/// <summary>
	/// Description of AboutForm.
	/// </summary>
	public partial class AboutForm : Form
	{
		public AboutForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		void LinkLabel4LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			try{
				System.Diagnostics.Process.Start(@"https://www.gnu.org/licenses/gpl-3.0.en.html");
			}catch(Exception ex){
				Utilits.Console.LogError(ex.Message, false, true);
			}
		}
		void LinkLabel1LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			try{
				System.Diagnostics.Process.Start(@"mailto:somov.studio@gmail.com");
			}catch(Exception ex){
				MessageBox.Show(ex.Message, "Ошибка");
			}
		}
		void LinkLabel2LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			try{
				System.Diagnostics.Process.Start(@"https://somovstudio.github.io/");
			}catch(Exception ex){
				Utilits.Console.LogError(ex.Message, false, true);
			}
		}
		void LinkLabel3LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			try{
				System.Diagnostics.Process.Start(@"https://github.com/SomovStudio/EnglishTrainer");
			}catch(Exception ex){
				Utilits.Console.LogError(ex.Message, false, true);
			}
		}
	}
}
