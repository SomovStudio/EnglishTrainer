/*
 * Created by SharpDevelop.
 * User: Catfish
 * Date: 03.02.2019
 * Time: 13:45
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace EnglishTrainer.Client.PracticeTests
{
	/// <summary>
	/// Description of AnswersTestsForm.
	/// </summary>
	public partial class AnswersTestsForm : Form
	{
		public AnswersTestsForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		public ListView ParentListView;
		public TestForm ParentTestForm;
		int index = 0;
		
		void AnswersTestsFormLoad(object sender, EventArgs e)
		{
			if(ParentListView.Items.Count > 0){
				label1.Text = ParentListView.Items[index].SubItems[1].Text;
				label3.Text = ParentListView.Items[index].SubItems[2].Text;
				label2.Text = ParentListView.Items[index].SubItems[5].Text;
				textBox2.Text = ParentListView.Items[index].SubItems[3].Text;
			}else{
				Utilits.Console.LogError("Тест не содержит вопросов.");
				Close();
			}
		}
		void Button2Click(object sender, EventArgs e)
		{
			/* Далее */
			try{
				ParentListView.Items[index].SubItems[3].Text = textBox2.Text;
			
				index++;
				if(index > 0) button1.Visible = true;
				if(index >= ParentListView.Items.Count){
					index = ParentListView.Items.Count - 1;
					button2.Visible = false;
					buttonEnd.Visible = true;
				}
				label1.Text = ParentListView.Items[index].SubItems[1].Text;
				label3.Text = ParentListView.Items[index].SubItems[2].Text;
				label2.Text = ParentListView.Items[index].SubItems[5].Text;
				textBox2.Text = ParentListView.Items[index].SubItems[3].Text;
			}catch(Exception ex){
				Utilits.Console.LogError(ex.Message.ToString(), false, true);
				Close();
			}
		}
		void Button1Click(object sender, EventArgs e)
		{
			/* Назад */
			try{
				index--;
				if(index <= 0)
				{
					index = 0;
					button1.Visible = false;
				}
				label1.Text = ParentListView.Items[index].SubItems[1].Text;
				label3.Text = ParentListView.Items[index].SubItems[2].Text;
				label2.Text = ParentListView.Items[index].SubItems[5].Text;
				textBox2.Text = ParentListView.Items[index].SubItems[3].Text;
				buttonEnd.Visible = false;
				button2.Visible = true;
			}catch(Exception ex){
				Utilits.Console.LogError(ex.Message.ToString(), false, true);
				Close();
			}
		}
		void ButtonEndClick(object sender, EventArgs e)
		{
			Close();
			try{
				ParentTestForm.Check();
			}catch(Exception ex){
				Utilits.Console.LogError(ex.Message.ToString(), false, true);
			}
		}
		void ButtonCloseClick(object sender, EventArgs e)
		{
			Close();
		}
	}
}
