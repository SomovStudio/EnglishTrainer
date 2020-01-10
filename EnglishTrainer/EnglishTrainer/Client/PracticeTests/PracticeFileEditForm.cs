/*
 * Created by SharpDevelop.
 * User: Catfish
 * Date: 02.02.2019
 * Time: 12:29
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace EnglishTrainer.Client.PracticeTests
{
	/// <summary>
	/// Description of PracticeFileEditForm.
	/// </summary>
	public partial class PracticeFileEditForm : Form
	{
		public PracticeFileEditForm()
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
		public bool ThisIsNew;
		public int SelectIndex;
		
		void PracticeFileEditFormLoad(object sender, EventArgs e)
		{
			if(ThisIsNew)
			{
				Text = "Новая запись";
			}else {
				Text = "Редактировать запись";
				textBox1.Text = ParentListView.Items[SelectIndex].SubItems[1].Text;
				textBox2.Text = ParentListView.Items[SelectIndex].SubItems[2].Text;
				textBox3.Text = ParentListView.Items[SelectIndex].SubItems[3].Text;
				textBox4.Text = ParentListView.Items[SelectIndex].SubItems[4].Text;
			}
		}
		
		void ButtonSaveClick(object sender, EventArgs e)
		{
			try{
				if(ThisIsNew)
				{
					ListViewItem ListViewItem_add = new ListViewItem();
					ListViewItem_add.SubItems.Add(textBox1.Text);
					ListViewItem_add.StateImageIndex = 1;
					ListViewItem_add.SubItems.Add(textBox2.Text);
					ListViewItem_add.SubItems.Add(textBox3.Text);
					ListViewItem_add.SubItems.Add(textBox4.Text);
					ListViewItem_add.SubItems.Add("+");
					ParentListView.Items.Add(ListViewItem_add);
				}else{
					ParentListView.Items[SelectIndex].SubItems[1].Text = textBox1.Text;
					ParentListView.Items[SelectIndex].SubItems[2].Text = textBox2.Text;
					ParentListView.Items[SelectIndex].SubItems[3].Text = textBox3.Text;
					ParentListView.Items[SelectIndex].SubItems[4].Text = textBox4.Text;
				}
				Close();
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
