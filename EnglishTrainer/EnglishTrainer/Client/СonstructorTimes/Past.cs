/*
 * Created by SharpDevelop.
 * User: Catfish
 * Date: 13.01.2019
 * Time: 11:07
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Net;
using System.Windows.Forms;
using EnglishTrainer.Client.Catalogs;
using EnglishTrainer.Data;
using EnglishTrainer.Utilits;

namespace EnglishTrainer.Client.СonstructorTimes
{
	/// <summary>
	/// Description of Present.
	/// </summary>
	public partial class Past : Form
	{
		public Past()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		/*
		public String Translate(String word)
		{
		    var toLanguage = "en";		//English
		    var fromLanguage = "ru";	//Russian
		    var url = @"https://translate.googleapis.com/translate_a/single?client=gtx&sl={fromLanguage}&tl={toLanguage}&dt=t&q={HttpUtility.UrlEncode(word)}";
		    var webClient = new WebClient
		    {
		        Encoding = System.Text.Encoding.UTF8
		    };
		    var result = webClient.DownloadString(url);
		    try
		    {
		        result = result.Substring(4, result.IndexOf("\"", 4, StringComparison.Ordinal) - 4);
		        return result;
		    }
		    catch
		    {
		        return "Error";
		    }
		}
		*/
		
		/*
		public string TranslateText(string input, string languagePair)
		{
		    string url = String.Format("http://www.google.com/translate_t?hl=en&ie=UTF8&text={0}&langpair={1}", input, languagePair);
		    WebClient webClient = new WebClient();
		    webClient.Encoding = System.Text.Encoding.Default;
		    string result = webClient.DownloadString(url);
		    result = result.Substring(result.IndexOf("TRANSLATED_TEXT"));
		    result = result.Substring(result.IndexOf("'")+1);
		    result = result.Substring(0, result.IndexOf("'"));
		    return result;
		}
		*/
		
		void GetWord(string dataType, TextBox textbox, string verbType = null)
		{
			if(dataType == Constants.DATA_TYPE_VOCABULARY){
				VocabularyForm vform = new VocabularyForm();
				vform.MdiParent = Forms.FClient;
				vform.ShowReturnValue();
				vform.TextBoxReturnValue = textbox;
				vform.Show();
			}
			if(dataType == Constants.DATA_TYPE_REGULAR_VERBS){
				RegularVerbsForm rvform = new RegularVerbsForm();
				rvform.MdiParent = Forms.FClient;
				rvform.ShowReturnValue();
				rvform.TextBoxReturnValue = textbox;
				rvform.ChangeVerbType = verbType;
				rvform.Show();
			}
			if(dataType == Constants.DATA_TYPE_IRREGULAR_WORDS){
				IrregularVerbsForm ivform = new IrregularVerbsForm();
				ivform.MdiParent = Forms.FClient;
				ivform.ShowReturnValue();
				ivform.TextBoxReturnValue = textbox;
				ivform.ChangeVerbType = verbType;
				ivform.Show();
			}
			if(dataType == Constants.DATA_TYPE_MODAL_VERBS){
				ModalVerbsForm mvform = new ModalVerbsForm();
				mvform.MdiParent = Forms.FClient;
				mvform.ShowReturnValue();
				mvform.TextBoxReturnValue = textbox;
				mvform.Show();
			}
			if(dataType == Constants.DATA_TYPE_PRONOUNS){
				PronounsForm pform = new PronounsForm();
				pform.MdiParent = Forms.FClient;
				pform.ShowReturnValue();
				pform.TextBoxReturnValue = textbox;
				pform.Show();
			}
			if(dataType == Constants.DATA_TYPE_ARTICLES){
				ArticlesForm aform = new ArticlesForm();
				aform.MdiParent = Forms.FClient;
				aform.ShowReturnValue();
				aform.TextBoxReturnValue = textbox;
				aform.Show();
			}
			if(dataType == Constants.DATA_TYPE_NOUNS){
				NounsForm nform = new NounsForm();
				nform.MdiParent = Forms.FClient;
				nform.ShowReturnValue();
				nform.TextBoxReturnValue = textbox;
				nform.Show();
			}
			if(dataType == Constants.DATA_TYPE_ADJECTIVE){
				AdjectiveForm aform = new AdjectiveForm();
				aform.MdiParent = Forms.FClient;
				aform.ShowReturnValue();
				aform.TextBoxReturnValue = textbox;
				aform.Show();
			}
			if(dataType == Constants.DATA_TYPE_NUMERAL){
				NumeralForm nform = new NumeralForm();
				nform.MdiParent = Forms.FClient;
				nform.ShowReturnValue();
				nform.TextBoxReturnValue = textbox;
				nform.Show();
			}
			if(dataType == Constants.DATA_TYPE_ADVERB){
				AdverbForm aform = new AdverbForm();
				aform.MdiParent = Forms.FClient;
				aform.ShowReturnValue();
				aform.TextBoxReturnValue = textbox;
				aform.Show();
			}
			if(dataType == Constants.DATA_TYPE_CONDITIONS){
				ConditionsForm cform = new ConditionsForm();
				cform.MdiParent = Forms.FClient;
				cform.ShowReturnValue();
				cform.TextBoxReturnValue = textbox;
				cform.Show();
			}
			if(dataType == Constants.DATA_TYPE_PREPOSITION){
				PrepositionForm pform = new PrepositionForm();
				pform.MdiParent = Forms.FClient;
				pform.ShowReturnValue();
				pform.TextBoxReturnValue = textbox;
				pform.Show();
			}
			if(dataType == Constants.DATA_TYPE_UNION){
				UnionForm uform = new UnionForm();
				uform.MdiParent = Forms.FClient;
				uform.ShowReturnValue();
				uform.TextBoxReturnValue = textbox;
				uform.Show();
			}
			if(dataType == Constants.DATA_TYPE_PARTICLES){
				ParticlesForm pform = new ParticlesForm();
				pform.MdiParent = Forms.FClient;
				pform.ShowReturnValue();
				pform.TextBoxReturnValue = textbox;
				pform.Show();
			}
			if(dataType == Constants.DATA_TYPE_MODAL_WORDS){
				ModalWordsForm mwform = new ModalWordsForm();
				mwform.MdiParent = Forms.FClient;
				mwform.ShowReturnValue();
				mwform.TextBoxReturnValue = textbox;
				mwform.Show();
			}
			if(dataType == Constants.DATA_TYPE_INTRO_WORDS){
				IntroWordsForm iwform = new IntroWordsForm();
				iwform.MdiParent = Forms.FClient;
				iwform.ShowReturnValue();
				iwform.TextBoxReturnValue = textbox;
				iwform.Show();
			}
			if(dataType == Constants.DATA_TYPE_INTERJECTIONS){
				InterjectionsForm iform = new InterjectionsForm();
				iform.MdiParent = Forms.FClient;
				iform.ShowReturnValue();
				iform.TextBoxReturnValue = textbox;
				iform.Show();
			}
			
		}
		
		void PresentLoad(object sender, EventArgs e)
		{
	
		}
		
		void ToolStripButton2Click(object sender, EventArgs e)
		{
			textBox2.Clear();
		}
		
		void ToolStripButton3Click(object sender, EventArgs e)
		{
			if(textBox1.Text == "") textBox1.Text = textBox2.Text;
			else textBox1.Text += Environment.NewLine + textBox2.Text;
		}
		
		void ToolStripButton4Click(object sender, EventArgs e)
		{
			textBox3.Clear();
			textBox3.Text = YandexTranslator.Translate(textBox2.Text, YandexTranslator.LangEnRu, YandexTranslator.Key);
		}
		
		void ToolStripButton1Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_VOCABULARY, textBox2);
		}
		
		void ToolStripButton13Click(object sender, EventArgs e)
		{
			textBox3.Text =	"Синтаксис: [Местоимение] + [глагол V2/V + окончание ed] + [Что; Где; Когда]" + Environment.NewLine +
							"[ I, He, She, It, You, We, They ] + [ V2 / V + ed ]";
		}
		void ToolStripButton6Click(object sender, EventArgs e)
		{
			textBox5.Clear();
		}
		void ToolStripButton7Click(object sender, EventArgs e)
		{
			if(textBox1.Text == "") textBox1.Text = textBox5.Text;
			else textBox1.Text += Environment.NewLine + textBox5.Text;
		}
		void ToolStripButton5Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_VOCABULARY, textBox5);
		}
		void ToolStripButton8Click(object sender, EventArgs e)
		{
			textBox4.Clear();
			textBox4.Text = YandexTranslator.Translate(textBox5.Text, YandexTranslator.LangEnRu, YandexTranslator.Key);
		}
		void ToolStripButton14Click(object sender, EventArgs e)
		{
			textBox4.Text = "Синтаксис: [Местоимение] + [did] + [not] + [V1/V] + [Что; Где; Когда]" + Environment.NewLine +
							"[ I, He, She, It, You, We, They ] + [ did ] + [ not ] + [ V1 / V ]";
		}
		void ToolStripButton9Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_VOCABULARY, textBox7);
		}
		void ToolStripButton11Click(object sender, EventArgs e)
		{
			if(textBox1.Text == "") textBox1.Text = textBox7.Text;
			else textBox1.Text += Environment.NewLine + textBox7.Text;
		}
		void ToolStripButton10Click(object sender, EventArgs e)
		{
			textBox7.Clear();
		}
		void ToolStripButton12Click(object sender, EventArgs e)
		{
			textBox6.Clear();
			textBox6.Text = YandexTranslator.Translate(textBox7.Text, YandexTranslator.LangEnRu, YandexTranslator.Key);
		}
		void ToolStripButton15Click(object sender, EventArgs e)
		{
			textBox6.Text = "Синтаксис: [Did] + [Местоимение] + [V1/V] + [Что; Где; Когда] ?" + Environment.NewLine +
							"[ Did ] + [ I, He, She, It, You, We, They ] + [ V1 / V ] ?";
		}
		void ПравильныеГлаголыToolStripMenuItemClick(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_REGULAR_VERBS, textBox2, Constants.VERB_PAST_SIMPLE);
		}
		void НеправильныеГлаголыToolStripMenuItemClick(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_IRREGULAR_WORDS, textBox2, Constants.VERB_PAST_SIMPLE);
		}
		void МодальныеГлаголыToolStripMenuItemClick(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_MODAL_VERBS, textBox2);
		}
		void МестоимениеToolStripMenuItemClick(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_PRONOUNS, textBox2);
		}
		void АртикльToolStripMenuItemClick(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_ARTICLES, textBox2);
		}
		void ToolStripMenuItem6Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_NOUNS, textBox5);
		}
		void ПрилагательноеToolStripMenuItemClick(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_ADJECTIVE, textBox2);
		}
		void ЧислительноеToolStripMenuItemClick(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_NUMERAL, textBox2);
		}
		void НаречиеToolStripMenuItemClick(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_ADVERB, textBox2);
		}
		void УсловноеНаклонениеToolStripMenuItemClick(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_CONDITIONS, textBox2);
		}
		void ПредлогToolStripMenuItemClick(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_PREPOSITION, textBox2);
		}
		void СоюзToolStripMenuItemClick(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_UNION, textBox2);
		}
		void ЧастицыToolStripMenuItemClick(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_PARTICLES, textBox2);
		}
		void МодальноеСловоToolStripMenuItemClick(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_MODAL_WORDS, textBox2);
		}
		void ВводныеСловаToolStripMenuItemClick(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_INTRO_WORDS, textBox2);
		}
		void МеждометияToolStripMenuItemClick(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_INTERJECTIONS, textBox2);
		}
		void ToolStripMenuItem1Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_REGULAR_VERBS, textBox5, Constants.VERB_INFINITIVE);
		}
		void ToolStripMenuItem2Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_IRREGULAR_WORDS, textBox5, Constants.VERB_INFINITIVE);
		}
		void ToolStripMenuItem3Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_MODAL_VERBS, textBox5);
		}
		void ToolStripMenuItem4Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_PRONOUNS, textBox5);
		}
		void ToolStripMenuItem5Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_ARTICLES, textBox5);
		}
		void ToolStripMenuItem7Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_ADJECTIVE, textBox5);
		}
		void ToolStripMenuItem8Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_NUMERAL, textBox5);
		}
		void ToolStripMenuItem9Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_ADVERB, textBox5);
		}
		void ToolStripMenuItem10Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_CONDITIONS, textBox5);
		}
		void ToolStripMenuItem11Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_PREPOSITION, textBox5);
		}
		void ToolStripMenuItem12Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_UNION, textBox5);
		}
		void ToolStripMenuItem13Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_PARTICLES, textBox5);
		}
		void ToolStripMenuItem14Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_MODAL_WORDS, textBox5);
		}
		void ToolStripMenuItem15Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_INTRO_WORDS, textBox5);
		}
		void ToolStripMenuItem16Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_INTERJECTIONS, textBox5);
		}
		void ToolStripMenuItem17Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_REGULAR_VERBS, textBox7, Constants.VERB_INFINITIVE);
		}
		void ToolStripMenuItem18Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_IRREGULAR_WORDS, textBox7, Constants.VERB_INFINITIVE);
		}
		void ToolStripMenuItem19Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_MODAL_VERBS, textBox7);
		}
		void ToolStripMenuItem20Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_PRONOUNS, textBox7);
		}
		void ToolStripMenuItem21Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_ARTICLES, textBox7);
		}
		void ToolStripMenuItem22Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_NOUNS, textBox7);
		}
		void ToolStripMenuItem23Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_ADJECTIVE, textBox7);
		}
		void ToolStripMenuItem24Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_NUMERAL, textBox7);
		}
		void ToolStripMenuItem25Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_ADVERB, textBox7);
		}
		void ToolStripMenuItem26Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_CONDITIONS, textBox7);
		}
		void ToolStripMenuItem27Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_PREPOSITION, textBox7);
		}
		void ToolStripMenuItem28Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_UNION, textBox7);
		}
		void ToolStripMenuItem29Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_PARTICLES, textBox7);
		}
		void ToolStripMenuItem30Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_MODAL_WORDS, textBox7);
		}
		void ToolStripMenuItem31Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_INTRO_WORDS, textBox7);
		}
		void ToolStripMenuItem32Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_INTERJECTIONS, textBox7);
		}
		void ToolStripButton30Click(object sender, EventArgs e)
		{
			
			textBox12.Text =	"Синтаксис: [Местоимение] + [was/were] + [глагол V4/V + окончание ing] + [Что; Где; Когда]" + Environment.NewLine +
							"[ I, He, She, It ] + [ was ] + [ V4 / V + ing ]" + Environment.NewLine +
							"[ We, You, They ] + [ were ] + [ V4 / V + ing ]";
		}
		void ToolStripButton25Click(object sender, EventArgs e)
		{

			textBox10.Text =	"Синтаксис: [Местоимение] + [was/were] + [not] + [V4/V + окончание ing] + [Что; Где; Когда]" + Environment.NewLine +
							"[ I, He, She, I t] + [ was ] + [ not ] + [ V4 / V + ing ]" + Environment.NewLine +
							"[ We, You, They ] + [ were ] + [ not ] + [ V4 / V + ing ]";
		}
		void ToolStripButton20Click(object sender, EventArgs e)
		{
			textBox8.Text =	"Синтаксис: [Was/Were] + [Местоимение] + [V4/V + окончание ing] + [Что; Где; Когда] ?" + Environment.NewLine +
							"[ Was ] + [ I, He, She, It ] + [ V4 / V + ing ] ?" + Environment.NewLine +
							"[ Were ] + [ We, You, They ] + [ V4 / V + ing ] ?";
		}
		void ToolStripButton29Click(object sender, EventArgs e)
		{
			textBox12.Clear();
			textBox12.Text = YandexTranslator.Translate(textBox13.Text, YandexTranslator.LangEnRu, YandexTranslator.Key);
		}
		void ToolStripButton24Click(object sender, EventArgs e)
		{
			textBox10.Clear();
			textBox10.Text = YandexTranslator.Translate(textBox11.Text, YandexTranslator.LangEnRu, YandexTranslator.Key);
		}
		void ToolStripButton19Click(object sender, EventArgs e)
		{
			textBox8.Clear();
			textBox8.Text = YandexTranslator.Translate(textBox9.Text, YandexTranslator.LangEnRu, YandexTranslator.Key);
		}
		void ToolStripButton28Click(object sender, EventArgs e)
		{
			textBox13.Clear();
		}
		void ToolStripButton23Click(object sender, EventArgs e)
		{
			textBox11.Clear();
		}
		void ToolStripButton18Click(object sender, EventArgs e)
		{
			textBox9.Clear();
		}
		void ToolStripButton27Click(object sender, EventArgs e)
		{
			if(textBox1.Text == "") textBox1.Text = textBox13.Text;
			else textBox1.Text += Environment.NewLine + textBox13.Text;
		}
		void ToolStripButton22Click(object sender, EventArgs e)
		{
			if(textBox1.Text == "") textBox1.Text = textBox11.Text;
			else textBox1.Text += Environment.NewLine + textBox11.Text;
		}
		void ToolStripButton17Click(object sender, EventArgs e)
		{
			if(textBox1.Text == "") textBox1.Text = textBox9.Text;
			else textBox1.Text += Environment.NewLine + textBox9.Text;
		}
		void ToolStripButton26Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_VOCABULARY, textBox13);
		}
		void ToolStripMenuItem65Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_REGULAR_VERBS, textBox13, Constants.VERB_PRESENT_PARTICIPLE);
		}
		void ToolStripMenuItem66Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_IRREGULAR_WORDS, textBox13, Constants.VERB_PRESENT_PARTICIPLE);
		}
		void ToolStripMenuItem67Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_MODAL_VERBS, textBox13);
		}
		void ToolStripMenuItem68Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_PRONOUNS, textBox13);
		}
		void ToolStripMenuItem69Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_ARTICLES, textBox13);
		}
		void ToolStripMenuItem70Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_NOUNS, textBox13);
		}
		void ToolStripMenuItem71Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_ADJECTIVE, textBox13);
		}
		void ToolStripMenuItem72Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_NUMERAL, textBox13);
		}
		void ToolStripMenuItem73Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_ADVERB, textBox13);
		}
		void ToolStripMenuItem74Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_CONDITIONS, textBox13);
		}
		void ToolStripMenuItem75Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_PREPOSITION, textBox13);
		}
		void ToolStripMenuItem76Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_UNION, textBox13);
		}
		void ToolStripMenuItem77Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_PARTICLES, textBox13);
		}
		void ToolStripMenuItem78Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_MODAL_WORDS, textBox13);
		}
		void ToolStripMenuItem79Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_INTRO_WORDS, textBox13);
		}
		void ToolStripMenuItem80Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_INTERJECTIONS, textBox13);
		}
		void ToolStripButton21Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_VOCABULARY, textBox11);
		}
		void ToolStripMenuItem49Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_REGULAR_VERBS, textBox11, Constants.VERB_PRESENT_PARTICIPLE);
		}
		void ToolStripMenuItem50Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_IRREGULAR_WORDS, textBox11, Constants.VERB_PRESENT_PARTICIPLE);
		}
		void ToolStripMenuItem51Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_MODAL_VERBS, textBox11);
		}
		void ToolStripMenuItem52Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_PRONOUNS, textBox11);
		}
		void ToolStripMenuItem53Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_ARTICLES, textBox11);
		}
		void ToolStripMenuItem54Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_NOUNS, textBox11);
		}
		void ToolStripMenuItem55Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_ADJECTIVE, textBox11);
		}
		void ToolStripMenuItem56Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_NUMERAL, textBox11);
		}
		void ToolStripMenuItem57Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_ADVERB, textBox11);
		}
		void ToolStripMenuItem58Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_CONDITIONS, textBox11);
		}
		void ToolStripMenuItem59Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_PREPOSITION, textBox11);
		}
		void ToolStripMenuItem60Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_UNION, textBox11);
		}
		void ToolStripMenuItem61Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_PARTICLES, textBox11);
		}
		void ToolStripMenuItem62Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_MODAL_WORDS, textBox11);
		}
		void ToolStripMenuItem63Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_INTRO_WORDS, textBox11);
		}
		void ToolStripMenuItem64Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_INTERJECTIONS, textBox11);
		}
		void ToolStripButton16Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_VOCABULARY, textBox9);
		}
		void ToolStripMenuItem33Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_REGULAR_VERBS, textBox9, Constants.VERB_PRESENT_PARTICIPLE);
		}
		void ToolStripMenuItem34Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_IRREGULAR_WORDS, textBox9, Constants.VERB_PRESENT_PARTICIPLE);
		}
		void ToolStripMenuItem35Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_MODAL_VERBS, textBox9);
		}
		void ToolStripMenuItem36Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_PRONOUNS, textBox9);
		}
		void ToolStripMenuItem37Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_ARTICLES, textBox9);
		}
		void ToolStripMenuItem38Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_NOUNS, textBox9);
		}
		void ToolStripMenuItem39Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_ADJECTIVE, textBox9);
		}
		void ToolStripMenuItem40Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_NUMERAL, textBox9);
		}
		void ToolStripMenuItem41Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_ADVERB, textBox9);
		}
		void ToolStripMenuItem42Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_CONDITIONS, textBox9);
		}
		void ToolStripMenuItem43Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_PREPOSITION, textBox9);
		}
		void ToolStripMenuItem44Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_UNION, textBox9);
		}
		void ToolStripMenuItem45Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_PARTICLES, textBox9);
		}
		void ToolStripMenuItem46Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_MODAL_WORDS, textBox9);
		}
		void ToolStripMenuItem47Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_INTRO_WORDS, textBox9);
		}
		void ToolStripMenuItem48Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_INTERJECTIONS, textBox9);
		}
		void ToolStripButton45Click(object sender, EventArgs e)
		{
			textBox18.Text =	"Синтаксис: [Местоимение] + [had] + [глагол V3/V + окончание ed] + [Что; Где; Когда]" + Environment.NewLine +
							"[ I, He, She, It, We, You, They ] + [ had ] + [ V3 / V + ed ]";
		}
		void ToolStripButton40Click(object sender, EventArgs e)
		{
			textBox16.Text =	"Синтаксис: [Местоимение] + [had] + [not] + [V3/V + окончание ed] + [Что; Где; Когда]" + Environment.NewLine +
							"[ I, He, She, It, We, You, They ] + [ had ] + [ not ]+ [ V3 / V + ed ]";
		}
		void ToolStripButton35Click(object sender, EventArgs e)
		{
			textBox14.Text =	"Синтаксис: [Had] + [Местоимение] + [V3/V + окончание ed] + [Что; Где; Когда] ?" + Environment.NewLine +
							"[ Had ] + [ I, He, She, It, We, You, They ] + [ V3 / V + ed ] ?";
		}
		void ToolStripButton44Click(object sender, EventArgs e)
		{
			textBox18.Clear();
			textBox18.Text = YandexTranslator.Translate(textBox19.Text, YandexTranslator.LangEnRu, YandexTranslator.Key);
		}
		void ToolStripButton43Click(object sender, EventArgs e)
		{
			textBox19.Clear();
		}
		void ToolStripButton39Click(object sender, EventArgs e)
		{
			textBox16.Clear();
			textBox16.Text = YandexTranslator.Translate(textBox17.Text, YandexTranslator.LangEnRu, YandexTranslator.Key);
		}
		void ToolStripButton38Click(object sender, EventArgs e)
		{
			textBox17.Clear();
		}
		void ToolStripButton34Click(object sender, EventArgs e)
		{
			textBox14.Clear();
			textBox14.Text = YandexTranslator.Translate(textBox15.Text, YandexTranslator.LangEnRu, YandexTranslator.Key);
		}
		void ToolStripButton33Click(object sender, EventArgs e)
		{
			textBox15.Clear();
		}
		void ToolStripButton42Click(object sender, EventArgs e)
		{
			if(textBox1.Text == "") textBox1.Text = textBox19.Text;
			else textBox1.Text += Environment.NewLine + textBox19.Text;
		}
		void ToolStripButton37Click(object sender, EventArgs e)
		{
			if(textBox1.Text == "") textBox1.Text = textBox17.Text;
			else textBox1.Text += Environment.NewLine + textBox17.Text;
		}
		void ToolStripButton32Click(object sender, EventArgs e)
		{
			if(textBox1.Text == "") textBox1.Text = textBox15.Text;
			else textBox1.Text += Environment.NewLine + textBox15.Text;
		}
		void ToolStripButton41Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_VOCABULARY, textBox19);
		}
		void ToolStripMenuItem113Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_REGULAR_VERBS, textBox19, Constants.VERB_PAST_PARTICIPLE);
		}
		void ToolStripMenuItem114Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_IRREGULAR_WORDS, textBox19, Constants.VERB_PAST_PARTICIPLE);
		}
		void ToolStripMenuItem115Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_MODAL_VERBS, textBox19);
		}
		void ToolStripMenuItem116Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_PRONOUNS, textBox19);
		}
		void ToolStripMenuItem117Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_ARTICLES, textBox19);
		}
		void ToolStripMenuItem118Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_NOUNS, textBox19);
		}
		void ToolStripMenuItem119Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_ADJECTIVE, textBox19);
		}
		void ToolStripMenuItem120Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_NUMERAL, textBox19);
		}
		void ToolStripMenuItem121Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_ADVERB, textBox19);
		}
		void ToolStripMenuItem122Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_CONDITIONS, textBox19);
		}
		void ToolStripMenuItem123Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_PREPOSITION, textBox19);
		}
		void ToolStripMenuItem124Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_UNION, textBox19);
		}
		void ToolStripMenuItem125Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_PARTICLES, textBox19);
		}
		void ToolStripMenuItem126Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_MODAL_WORDS, textBox19);
		}
		void ToolStripMenuItem127Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_INTRO_WORDS, textBox19);
		}
		void ToolStripMenuItem128Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_INTERJECTIONS, textBox19);
		}
		void ToolStripButton36Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_VOCABULARY, textBox17);
		}
		void ToolStripMenuItem97Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_REGULAR_VERBS, textBox17, Constants.VERB_PAST_PARTICIPLE);
		}
		void ToolStripMenuItem98Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_IRREGULAR_WORDS, textBox17, Constants.VERB_PAST_PARTICIPLE);
		}
		void ToolStripMenuItem99Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_MODAL_VERBS, textBox17);
		}
		void ToolStripMenuItem100Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_PRONOUNS, textBox17);
		}
		void ToolStripMenuItem101Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_ARTICLES, textBox17);
		}
		void ToolStripMenuItem102Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_NOUNS, textBox17);
		}
		void ToolStripMenuItem103Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_ADJECTIVE, textBox17);
		}
		void ToolStripMenuItem104Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_NUMERAL, textBox17);
		}
		void ToolStripMenuItem105Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_ADVERB, textBox17);
		}
		void ToolStripMenuItem106Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_CONDITIONS, textBox17);
		}
		void ToolStripMenuItem107Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_PREPOSITION, textBox17);
		}
		void ToolStripMenuItem108Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_UNION, textBox17);
		}
		void ToolStripMenuItem109Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_PARTICLES, textBox17);
		}
		void ToolStripMenuItem110Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_MODAL_WORDS, textBox17);
		}
		void ToolStripMenuItem111Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_INTRO_WORDS, textBox17);
		}
		void ToolStripMenuItem112Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_INTERJECTIONS, textBox17);
		}
		void ToolStripButton31Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_VOCABULARY, textBox15);
		}
		void ToolStripMenuItem81Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_REGULAR_VERBS, textBox15, Constants.VERB_PAST_PARTICIPLE);
		}
		void ToolStripMenuItem82Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_IRREGULAR_WORDS, textBox15, Constants.VERB_PAST_PARTICIPLE);
		}
		void ToolStripMenuItem83Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_MODAL_VERBS, textBox15);
		}
		void ToolStripMenuItem84Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_PRONOUNS, textBox15);
		}
		void ToolStripMenuItem85Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_ARTICLES, textBox15);
		}
		void ToolStripMenuItem86Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_NOUNS, textBox15);
		}
		void ToolStripMenuItem87Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_ADJECTIVE, textBox15);
		}
		void ToolStripMenuItem88Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_NUMERAL, textBox15);
		}
		void ToolStripMenuItem89Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_ADVERB, textBox15);
		}
		void ToolStripMenuItem90Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_CONDITIONS, textBox15);
		}
		void ToolStripMenuItem91Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_PREPOSITION, textBox15);
		}
		void ToolStripMenuItem92Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_UNION, textBox15);
		}
		void ToolStripMenuItem93Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_PARTICLES, textBox15);
		}
		void ToolStripMenuItem94Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_MODAL_WORDS, textBox15);
		}
		void ToolStripMenuItem95Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_INTRO_WORDS, textBox15);
		}
		void ToolStripMenuItem96Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_INTERJECTIONS, textBox15);
		}
		void ToolStripButton60Click(object sender, EventArgs e)
		{
			textBox24.Text = "Синтаксис: [Местоимение] + [had] + [been] + [глагол V4/V + окончание ing] + [Что; Где; Когда]" + Environment.NewLine +
							"[ I, He, She, It, We, You, They ] + [ had ] + [ been ]  + [ V4 / V + ing ]";
		}
		void ToolStripButton55Click(object sender, EventArgs e)
		{
			textBox22.Text = "Синтаксис: [Местоимение] + [had] + [not] + [been] + [V4/V + окончание ing] + [Что; Где; Когда]" + Environment.NewLine +
							"[ I, He, She, It, We, You, They ] + [ had ] + [ not ]+ [ been ] + [ V4 / V + ing ]";
		}
		void ToolStripButton50Click(object sender, EventArgs e)
		{
			textBox20.Text = "Синтаксис: [Had] + [Местоимение] + [been] + [V4/V + окончание ing] + [Что; Где; Когда] ?" + Environment.NewLine +
							"[ Had ] + [ I, He, She, It, We, You, They ] + [ been ] + [ V4 / V + ing ] ?";
		}
		void ToolStripButton59Click(object sender, EventArgs e)
		{
			textBox24.Clear();
			textBox24.Text = YandexTranslator.Translate(textBox25.Text, YandexTranslator.LangEnRu, YandexTranslator.Key);
		}
		void ToolStripButton54Click(object sender, EventArgs e)
		{
			textBox22.Clear();
			textBox22.Text = YandexTranslator.Translate(textBox23.Text, YandexTranslator.LangEnRu, YandexTranslator.Key);
		}
		void ToolStripButton49Click(object sender, EventArgs e)
		{
			textBox20.Clear();
			textBox20.Text = YandexTranslator.Translate(textBox21.Text, YandexTranslator.LangEnRu, YandexTranslator.Key);
		}
		void ToolStripButton58Click(object sender, EventArgs e)
		{
			textBox25.Clear();
		}
		void ToolStripButton53Click(object sender, EventArgs e)
		{
			textBox23.Clear();
		}
		void ToolStripButton48Click(object sender, EventArgs e)
		{
			textBox21.Clear();
		}
		void ToolStripButton57Click(object sender, EventArgs e)
		{
			if(textBox1.Text == "") textBox1.Text = textBox25.Text;
			else textBox1.Text += Environment.NewLine + textBox25.Text;
		}
		void ToolStripButton52Click(object sender, EventArgs e)
		{
			if(textBox1.Text == "") textBox1.Text = textBox23.Text;
			else textBox1.Text += Environment.NewLine + textBox23.Text;
		}
		void ToolStripButton47Click(object sender, EventArgs e)
		{
			if(textBox1.Text == "") textBox1.Text = textBox21.Text;
			else textBox1.Text += Environment.NewLine + textBox21.Text;
		}
		void ToolStripButton56Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_VOCABULARY, textBox25);
		}
		void ToolStripMenuItem161Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_REGULAR_VERBS, textBox25, Constants.VERB_PRESENT_PARTICIPLE);
		}
		void ToolStripMenuItem162Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_IRREGULAR_WORDS, textBox25, Constants.VERB_PRESENT_PARTICIPLE);
		}
		void ToolStripMenuItem163Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_MODAL_VERBS, textBox25);
		}
		void ToolStripMenuItem164Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_PRONOUNS, textBox25);
		}
		void ToolStripMenuItem165Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_ARTICLES, textBox25);
		}
		void ToolStripMenuItem166Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_NOUNS, textBox25);
		}
		void ToolStripMenuItem167Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_ADJECTIVE, textBox25);
		}
		void ToolStripMenuItem168Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_NUMERAL, textBox25);
		}
		void ToolStripMenuItem169Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_ADVERB, textBox25);
		}
		void ToolStripMenuItem170Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_CONDITIONS, textBox25);
		}
		void ToolStripMenuItem171Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_PREPOSITION, textBox25);
		}
		void ToolStripMenuItem172Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_UNION, textBox25);
		}
		void ToolStripMenuItem173Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_PARTICLES, textBox25);
		}
		void ToolStripMenuItem174Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_MODAL_WORDS, textBox25);
		}
		void ToolStripMenuItem175Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_INTRO_WORDS, textBox25);
		}
		void ToolStripMenuItem176Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_INTERJECTIONS, textBox25);
		}
		void ToolStripButton51Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_VOCABULARY, textBox23);
		}
		void ToolStripMenuItem145Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_REGULAR_VERBS, textBox23, Constants.VERB_PRESENT_PARTICIPLE);
		}
		void ToolStripMenuItem146Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_IRREGULAR_WORDS, textBox23, Constants.VERB_PRESENT_PARTICIPLE);
		}
		void ToolStripMenuItem147Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_MODAL_VERBS, textBox23);
		}
		void ToolStripMenuItem148Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_PRONOUNS, textBox23);
		}
		void ToolStripMenuItem149Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_ARTICLES, textBox23);
		}
		void ToolStripMenuItem150Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_NOUNS, textBox23);
		}
		void ToolStripMenuItem151Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_ADJECTIVE, textBox23);
		}
		void ToolStripMenuItem152Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_NUMERAL, textBox23);
		}
		void ToolStripMenuItem153Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_ADVERB, textBox23);
		}
		void ToolStripMenuItem154Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_CONDITIONS, textBox23);
		}
		void ToolStripMenuItem155Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_PREPOSITION, textBox23);
		}
		void ToolStripMenuItem156Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_UNION, textBox23);
		}
		void ToolStripMenuItem157Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_PARTICLES, textBox23);
		}
		void ToolStripMenuItem158Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_MODAL_WORDS, textBox23);
		}
		void ToolStripMenuItem159Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_INTRO_WORDS, textBox23);
		}
		void ToolStripMenuItem160Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_INTERJECTIONS, textBox23);
		}
		void ToolStripButton46Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_VOCABULARY, textBox21);
		}
		void ToolStripMenuItem129Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_REGULAR_VERBS, textBox21, Constants.VERB_PRESENT_PARTICIPLE);
		}
		void ToolStripMenuItem130Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_IRREGULAR_WORDS, textBox21, Constants.VERB_PRESENT_PARTICIPLE);
		}
		void ToolStripMenuItem131Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_MODAL_VERBS, textBox21);
		}
		void ToolStripMenuItem132Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_PRONOUNS, textBox21);
		}
		void ToolStripMenuItem133Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_ARTICLES, textBox21);
		}
		void ToolStripMenuItem134Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_NOUNS, textBox21);
		}
		void ToolStripMenuItem135Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_ADJECTIVE, textBox21);
		}
		void ToolStripMenuItem136Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_NUMERAL, textBox21);
		}
		void ToolStripMenuItem137Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_ADVERB, textBox21);
		}
		void ToolStripMenuItem138Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_CONDITIONS, textBox21);
		}
		void ToolStripMenuItem139Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_PREPOSITION, textBox21);
		}
		void ToolStripMenuItem140Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_UNION, textBox21);
		}
		void ToolStripMenuItem141Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_PARTICLES, textBox21);
		}
		void ToolStripMenuItem142Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_MODAL_WORDS, textBox21);
		}
		void ToolStripMenuItem143Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_INTRO_WORDS, textBox21);
		}
		void ToolStripMenuItem144Click(object sender, EventArgs e)
		{
			GetWord(Constants.DATA_TYPE_INTERJECTIONS, textBox21);
		}
		
		
	}
}
