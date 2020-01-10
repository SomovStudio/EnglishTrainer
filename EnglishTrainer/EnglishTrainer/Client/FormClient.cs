/*
 * Created by SharpDevelop.
 * User: Catfish
 * Date: 12.11.2018
 * Time: 9:50
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using EnglishTrainer.Client.Catalogs;
using EnglishTrainer.Client.PracticeTests;
using EnglishTrainer.Client.СonstructorTimes;
using EnglishTrainer.Data;
using EnglishTrainer.Utilits;

namespace EnglishTrainer.Client
{
	/// <summary>
	/// Description of FormClient.
	/// </summary>
	public partial class FormClient : Form
	{
		public FormClient()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		void FormClientLoad(object sender, EventArgs e)
		{
			Utilits.Console.Log("Программа EnglishTrainer версия 1.0");
		}
		void FormClientFormClosed(object sender, FormClosedEventArgs e)
		{
			Application.Exit();
		}
		void ConsoleButtonClick(object sender, EventArgs e)
		{
			consolePanel.Visible = false;
		}
		void КонсольToolStripMenuItemClick(object sender, EventArgs e)
		{
			consolePanel.Visible = true;
		}
		void ЗакрытьПрограммуToolStripMenuItemClick(object sender, EventArgs e)
		{
			Close();
		}
		void СловарьToolStripMenuItemClick(object sender, EventArgs e)
		{
			VocabularyForm vform = new VocabularyForm();
			vform.MdiParent = this;
			vform.Show();
		}
		void PresentToolStripMenuItemClick(object sender, EventArgs e)
		{
			Present presentForm = new Present();
			presentForm.MdiParent = this;
			presentForm.Show();
		}
		void ToolStripStatusLabel2Click(object sender, EventArgs e)
		{
			try{
				System.Diagnostics.Process.Start(@"https://www.gnu.org/licenses/gpl-3.0.en.html");
			}catch(Exception ex){
				Utilits.Console.LogError(ex.Message, false, true);
			}
		}
		void МестоименияToolStripMenuItemClick(object sender, EventArgs e)
		{
			PronounsForm pform = new PronounsForm();
			pform.MdiParent = this;
			pform.Show();
		}
		void НеПравильныеГлаголыToolStripMenuItemClick(object sender, EventArgs e)
		{
			IrregularVerbsForm ivform = new IrregularVerbsForm();
			ivform.MdiParent = this;
			ivform.Show();
		}
		void МодальныеГлаголыToolStripMenuItemClick(object sender, EventArgs e)
		{
			ModalVerbsForm mvform = new ModalVerbsForm();
			mvform.MdiParent = this;
			mvform.Show();
		}
		void ПравильныеГлаголыToolStripMenuItemClick(object sender, EventArgs e)
		{
			RegularVerbsForm rvform = new RegularVerbsForm();
			rvform.MdiParent = this;
			rvform.Show();
		}
		void АртикльToolStripMenuItemClick(object sender, EventArgs e)
		{
			ArticlesForm aform = new ArticlesForm();
			aform.MdiParent = this;
			aform.Show();
		}
		void СуществительноеToolStripMenuItemClick(object sender, EventArgs e)
		{
			NounsForm nform = new NounsForm();
			nform.MdiParent = this;
			nform.Show();
		}
		void ПрилагательноеToolStripMenuItemClick(object sender, EventArgs e)
		{
			AdjectiveForm aform = new AdjectiveForm();
			aform.MdiParent = this;
			aform.Show();
		}
		void ЧислительноеToolStripMenuItemClick(object sender, EventArgs e)
		{
			NumeralForm nform = new NumeralForm();
			nform.MdiParent = this;
			nform.Show();
		}
		void НаречиеToolStripMenuItemClick(object sender, EventArgs e)
		{
			AdverbForm aform = new AdverbForm();
			aform.MdiParent = this;
			aform.Show();
		}
		void УсловноеНаклонениеToolStripMenuItemClick(object sender, EventArgs e)
		{
			ConditionsForm cform = new ConditionsForm();
			cform.MdiParent = this;
			cform.Show();
		}
		void ПредлогToolStripMenuItemClick(object sender, EventArgs e)
		{
			PrepositionForm pform = new PrepositionForm();
			pform.MdiParent = this;
			pform.Show();
		}
		void СоюзToolStripMenuItemClick(object sender, EventArgs e)
		{
			UnionForm uform = new UnionForm();
			uform.MdiParent = this;
			uform.Show();
		}
		void ЧастицыToolStripMenuItemClick(object sender, EventArgs e)
		{
			ParticlesForm pform = new ParticlesForm();
			pform.MdiParent = this;
			pform.Show();
		}
		void МодальноеСловоToolStripMenuItemClick(object sender, EventArgs e)
		{
			ModalWordsForm mwform = new ModalWordsForm();
			mwform.MdiParent = this;
			mwform.Show();
		}
		void ВводныеСловаToolStripMenuItemClick(object sender, EventArgs e)
		{
			IntroWordsForm iwform = new IntroWordsForm();
			iwform.MdiParent = this;
			iwform.Show();
		}
		void МеждометияToolStripMenuItemClick(object sender, EventArgs e)
		{
			InterjectionsForm iform = new InterjectionsForm();
			iform.MdiParent = this;
			iform.Show();
		}
		void ИсточникEngblogruToolStripMenuItemClick(object sender, EventArgs e)
		{
			try{
				System.Diagnostics.Process.Start(@"http://engblog.ru/category/grammar");
			}catch(Exception ex){
				Utilits.Console.LogError(ex.Message, false, true);
			}
		}
		void PastToolStripMenuItemClick(object sender, EventArgs e)
		{
			Past pastForm = new Past();
			pastForm.MdiParent = this;
			pastForm.Show();
		}
		void FutureToolStripMenuItemClick(object sender, EventArgs e)
		{
			Future futureForm = new Future();
			futureForm.MdiParent = this;
			futureForm.Show();
		}
		void FutureInThePastToolStripMenuItemClick(object sender, EventArgs e)
		{
			FuturePast futurePastForm = new FuturePast();
			futurePastForm.MdiParent = this;
			futurePastForm.Show();
		}
		void ToolStripButton1Click(object sender, EventArgs e)
		{
			consolePanel.Visible = true;
		}
		void ToolStripButton2Click(object sender, EventArgs e)
		{
			if(Forms.FSettings == null)
			{
				Forms.FSettings = new SettingsForm();
				Forms.FSettings.MdiParent = this;
				Forms.FSettings.Show();
			}
		}
		void ToolStripButton3Click(object sender, EventArgs e)
		{
			VocabularyForm vform = new VocabularyForm();
			vform.MdiParent = this;
			vform.Show();
		}
		void ToolStripButton4Click(object sender, EventArgs e)
		{
			Present presentForm = new Present();
			presentForm.MdiParent = this;
			presentForm.Show();
		}
		void ToolStripButton5Click(object sender, EventArgs e)
		{
			Past pastForm = new Past();
			pastForm.MdiParent = this;
			pastForm.Show();
		}
		void ToolStripButton6Click(object sender, EventArgs e)
		{
			Future futureForm = new Future();
			futureForm.MdiParent = this;
			futureForm.Show();
		}
		void Button1Click(object sender, EventArgs e)
		{
			yandexPanel.Visible = false;
		}
		void YandexПереводчикToolStripMenuItemClick(object sender, EventArgs e)
		{
			yandexPanel.Visible = true;
		}
		void RadioButton1CheckedChanged(object sender, EventArgs e)
		{
			
		}
		void RadioButton2CheckedChanged(object sender, EventArgs e)
		{
			
		}
		void Button2Click(object sender, EventArgs e)
		{
			if(radioButton1.Checked)
				resultTextBox.Text = YandexTranslator.Translate(inputTextBox.Text, YandexTranslator.LangEnRu, YandexTranslator.Key);
			if(radioButton2.Checked)
				resultTextBox.Text = YandexTranslator.Translate(inputTextBox.Text, YandexTranslator.LangRuEn, YandexTranslator.Key);
			
		}
		void ToolStripButton7Click(object sender, EventArgs e)
		{
			if(yandexPanel.Visible) yandexPanel.Visible = false;
			else yandexPanel.Visible = true;
		}
		void Button3Click(object sender, EventArgs e)
		{
			if(Forms.FSettings == null)
			{
				Forms.FSettings = new SettingsForm();
				Forms.FSettings.MdiParent = this;
				Forms.FSettings.Show();
			}
		}
		void ПравильныеГлаголыToolStripMenuItem1Click(object sender, EventArgs e)
		{
			RegularVerbsForm rvform = new RegularVerbsForm();
			rvform.MdiParent = this;
			rvform.Show();
		}
		void НеправильныеГлаголыToolStripMenuItem1Click(object sender, EventArgs e)
		{
			IrregularVerbsForm ivform = new IrregularVerbsForm();
			ivform.MdiParent = this;
			ivform.Show();
		}
		void МодальныеГлаголыToolStripMenuItem1Click(object sender, EventArgs e)
		{
			ModalVerbsForm mvform = new ModalVerbsForm();
			mvform.MdiParent = this;
			mvform.Show();
		}
		void ТестыНаHttpwwwstudyrutestToolStripMenuItemClick(object sender, EventArgs e)
		{
			try{
				System.Diagnostics.Process.Start(@"http://www.study.ru/test/");
			}catch(Exception ex){
				Utilits.Console.LogError(ex.Message, false, true);
			}
		}
		void ОПрограммеToolStripMenuItemClick(object sender, EventArgs e)
		{
			AboutForm FAbout = new AboutForm();
			FAbout.ShowDialog();
		}
		void ТестированиеЗнанийАнглийскогоЯзыкаToolStripMenuItemClick(object sender, EventArgs e)
		{
			if(Forms.FPractice == null)
			{
				Forms.FPractice = new PracticeForm();
				Forms.FPractice.MdiParent = this;
				Forms.FPractice.Show();
			}
		}
		void ToolStripButton8Click(object sender, EventArgs e)
		{
			if(Forms.FPractice == null)
			{
				Forms.FPractice = new PracticeForm();
				Forms.FPractice.MdiParent = this;
				Forms.FPractice.Show();
			}
		}
		void БлокнотToolStripMenuItemClick(object sender, EventArgs e)
		{
			try{
				System.Diagnostics.Process.Start("notepad");
			}catch(Exception ex){
				Utilits.Console.LogError(ex.Message, false, true);
			}
		}
	}
}
