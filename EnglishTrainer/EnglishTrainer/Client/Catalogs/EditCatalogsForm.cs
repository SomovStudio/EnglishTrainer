/*
 * Created by SharpDevelop.
 * User: Catfish
 * Date: 28.01.2019
 * Time: 9:43
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Windows.Forms;
using EnglishTrainer.Data;
using EnglishTrainer.Database.Local;

namespace EnglishTrainer.Client.Catalogs
{
	/// <summary>
	/// Description of EditCatalogsForm.
	/// </summary>
	public partial class EditCatalogsForm : Form
	{
		public EditCatalogsForm()
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
		
		void EditCatalogsFormLoad(object sender, EventArgs e)
		{
			label1.Text = "ID:";
			label1.Visible = true;
			textBox1.Visible = true;
			
			if(ThisIsNew){
				Text = "Новая запись";
				textBox1.Clear();
			}
			else{
				Text = "Редактировать запись";
				textBox1.Text = ID;
			}
						
			if(DataType == Constants.DATA_TYPE_VOCABULARY) initEngRusVocabulary();
			if(DataType == Constants.DATA_TYPE_REGULAR_VERBS) initRegularVerbs();
			if(DataType == Constants.DATA_TYPE_IRREGULAR_WORDS) initIrregularVerbs();
			if(DataType == Constants.DATA_TYPE_MODAL_VERBS) initModalVerbs();
			if(DataType == Constants.DATA_TYPE_PRONOUNS) initPronouns();
			if(DataType == Constants.DATA_TYPE_ARTICLES) initArticles();
			if(DataType == Constants.DATA_TYPE_NOUNS) initNouns();
			if(DataType == Constants.DATA_TYPE_ADJECTIVE) initAdjective();
			if(DataType == Constants.DATA_TYPE_NUMERAL) initNumeral();
			if(DataType == Constants.DATA_TYPE_ADVERB) initAdverb();
			if(DataType == Constants.DATA_TYPE_CONDITIONS) initConditions();
			if(DataType == Constants.DATA_TYPE_PREPOSITION) initPreposition();
			if(DataType == Constants.DATA_TYPE_UNION) initUnions();
			if(DataType == Constants.DATA_TYPE_PARTICLES) initParticles();
			if(DataType == Constants.DATA_TYPE_MODAL_WORDS) initModalWords();
			if(DataType == Constants.DATA_TYPE_INTRO_WORDS) initIntroductoryWords();
			if(DataType == Constants.DATA_TYPE_INTERJECTIONS) initInterjections();
		}
		void ButtonCloseClick(object sender, EventArgs e)
		{
			Close();
		}
		void ButtonSaveClick(object sender, EventArgs e)
		{
			if(DataType == Constants.DATA_TYPE_VOCABULARY) saveEngRusVocabulary();
			if(DataType == Constants.DATA_TYPE_REGULAR_VERBS) saveRegularVerbs();
			if(DataType == Constants.DATA_TYPE_IRREGULAR_WORDS) saveIrregularVerbs();
			if(DataType == Constants.DATA_TYPE_MODAL_VERBS) saveModalVerbs();
			if(DataType == Constants.DATA_TYPE_PRONOUNS) savePronouns();
			if(DataType == Constants.DATA_TYPE_NOUNS) saveNouns();
			if(DataType == Constants.DATA_TYPE_ADJECTIVE) saveAdjective();
			if(DataType == Constants.DATA_TYPE_NUMERAL) saveNumeral();
			if(DataType == Constants.DATA_TYPE_ADVERB) saveAdverb();
			if(DataType == Constants.DATA_TYPE_CONDITIONS) saveConditions();
			if(DataType == Constants.DATA_TYPE_PREPOSITION) savePreposition();
			if(DataType == Constants.DATA_TYPE_UNION) saveUnions();
			if(DataType == Constants.DATA_TYPE_PARTICLES) saveParticles();
			if(DataType == Constants.DATA_TYPE_MODAL_WORDS) saveModalWords();
			if(DataType == Constants.DATA_TYPE_INTRO_WORDS) saveIntroductoryWords();
			if(DataType == Constants.DATA_TYPE_INTERJECTIONS) saveInterjections();
		}
		
		void initEngRusVocabulary()
		{
			label2.Text = "English"; label2.Visible = true;
			textBox2.Visible = true;
			label3.Text = "Русский"; label3.Visible = true;
			textBox3.Visible = true;
			
			oleDb = new OleDb(Config.databaseFile);
			oleDb.dataSet.Clear();
			oleDb.dataSet.DataSetName = "EngRusVocabulary";
			
			if(ThisIsNew == false)
			{
				oleDb.oleDbCommandSelect.CommandText = "SELECT * FROM EngRusVocabulary WHERE (ID = " + ID + ")";
				oleDb.ExecuteFill("EngRusVocabulary");
				textBox1.Text = oleDb.dataSet.Tables["EngRusVocabulary"].Rows[0]["ID"].ToString();
				textBox2.Text = oleDb.dataSet.Tables["EngRusVocabulary"].Rows[0]["English_Word"].ToString();
				textBox3.Text = oleDb.dataSet.Tables["EngRusVocabulary"].Rows[0]["Rus_Translation"].ToString();
			}
		}
		
		void saveEngRusVocabulary()
		{
			if(ThisIsNew){
				oleDb.dataSet.Clear();
				oleDb.dataSet.DataSetName = "EngRusVocabulary";
				oleDb.oleDbCommandSelect.CommandText = "SELECT * FROM EngRusVocabulary";
				oleDb.ExecuteFill("EngRusVocabulary");
				
				oleDb.oleDbCommandInsert.CommandText = "INSERT INTO EngRusVocabulary (English_Word, Rus_Translation) VALUES (@English_Word, @Rus_Translation)";
				oleDb.oleDbCommandInsert.Parameters.Add("@English_Word", OleDbType.VarChar, 255, "English_Word");
				oleDb.oleDbCommandInsert.Parameters.Add("@Rus_Translation", OleDbType.VarChar, 255, "Rus_Translation");

				DataRow newRow = oleDb.dataSet.Tables["EngRusVocabulary"].NewRow();
				newRow["English_Word"] = textBox2.Text;
				newRow["Rus_Translation"] = textBox3.Text;
				oleDb.dataSet.Tables["EngRusVocabulary"].Rows.Add(newRow);
			}else{
				oleDb.oleDbCommandUpdate.Parameters.Add("@English_Word", OleDbType.VarChar, 255, "English_Word");
				oleDb.oleDbCommandUpdate.Parameters.Add("@Rus_Translation", OleDbType.VarChar, 255, "Rus_Translation");
				oleDb.oleDbCommandUpdate.Parameters.Add("@ID", OleDbType.Integer, 10, "ID");
				
				oleDb.dataSet.Tables["EngRusVocabulary"].Rows[0]["English_Word"] = textBox2.Text;
				oleDb.dataSet.Tables["EngRusVocabulary"].Rows[0]["Rus_Translation"] = textBox3.Text;
				oleDb.oleDbCommandUpdate.CommandText = "UPDATE EngRusVocabulary SET " +
					"[English_Word] = @English_Word, [Rus_Translation] = @Rus_Translation " +
					"WHERE ([ID] = @ID)";
			}
			
			if(oleDb.ExecuteUpdate("EngRusVocabulary")){
				Utilits.Console.Log("Словарь: Запись - успешно сохранена.");
				Close();
				(ParentForm as VocabularyForm).TableRefresh();
			}
		}
		
		void initRegularVerbs()
		{
			label2.Text = "Infinitive:"; label2.Visible = true;
			textBox2.Visible = true;
			label3.Text = "Past Simple:"; label3.Visible = true;
			textBox3.Visible = true;
			label4.Text = "Past Participle:"; label4.Visible = true;
			textBox4.Visible = true;
			label5.Text = "Present Participle:"; label5.Visible = true;
			textBox5.Visible = true;
			label6.Text = "Перевод:"; label6.Visible = true;
			textBox6.Visible = true;
			
			oleDb = new OleDb(Config.databaseFile);
			oleDb.dataSet.Clear();
			oleDb.dataSet.DataSetName = "RegularVerbs";
			
			if(ThisIsNew == false)
			{
				oleDb.oleDbCommandSelect.CommandText = "SELECT * FROM RegularVerbs WHERE (ID = " + ID + ")";
				oleDb.ExecuteFill("RegularVerbs");
				textBox1.Text = oleDb.dataSet.Tables["RegularVerbs"].Rows[0]["ID"].ToString();
				textBox2.Text = oleDb.dataSet.Tables["RegularVerbs"].Rows[0]["V1_Infivitive"].ToString();
				textBox3.Text = oleDb.dataSet.Tables["RegularVerbs"].Rows[0]["V2_PastSimple"].ToString();
				textBox4.Text = oleDb.dataSet.Tables["RegularVerbs"].Rows[0]["V3_PastParticiple"].ToString();
				textBox5.Text = oleDb.dataSet.Tables["RegularVerbs"].Rows[0]["V4_PresentParticiple"].ToString();
				textBox6.Text = oleDb.dataSet.Tables["RegularVerbs"].Rows[0]["Verb_Translation"].ToString();
			}
		}
		
		void saveRegularVerbs()
		{
			if(ThisIsNew){
				oleDb.dataSet.Clear();
				oleDb.dataSet.DataSetName = "RegularVerbs";
				oleDb.oleDbCommandSelect.CommandText = "SELECT * FROM RegularVerbs";
				oleDb.ExecuteFill("RegularVerbs");
				
				oleDb.oleDbCommandInsert.CommandText = "INSERT INTO RegularVerbs (V1_Infivitive, V2_PastSimple, V3_PastParticiple, V4_PresentParticiple, Verb_Translation) VALUES (@V1_Infivitive, @V2_PastSimple, @V3_PastParticiple, @V4_PresentParticiple, @Verb_Translation)";
				oleDb.oleDbCommandInsert.Parameters.Add("@V1_Infivitive", OleDbType.VarChar, 255, "V1_Infivitive");
				oleDb.oleDbCommandInsert.Parameters.Add("@V2_PastSimple", OleDbType.VarChar, 255, "V2_PastSimple");
				oleDb.oleDbCommandInsert.Parameters.Add("@V3_PastParticiple", OleDbType.VarChar, 255, "V3_PastParticiple");
				oleDb.oleDbCommandInsert.Parameters.Add("@V4_PresentParticiple", OleDbType.VarChar, 255, "V4_PresentParticiple");
				oleDb.oleDbCommandInsert.Parameters.Add("@Verb_Translation", OleDbType.VarChar, 255, "Verb_Translation");
				
				DataRow newRow = oleDb.dataSet.Tables["RegularVerbs"].NewRow();
				newRow["V1_Infivitive"] = textBox2.Text;
				newRow["V2_PastSimple"] = textBox3.Text;
				newRow["V3_PastParticiple"] = textBox4.Text;
				newRow["V4_PresentParticiple"] = textBox5.Text;
				newRow["Verb_Translation"] = textBox6.Text;
				oleDb.dataSet.Tables["RegularVerbs"].Rows.Add(newRow);
			}else{
				oleDb.oleDbCommandUpdate.Parameters.Add("@V1_Infivitive", OleDbType.VarChar, 255, "V1_Infivitive");
				oleDb.oleDbCommandUpdate.Parameters.Add("@V2_PastSimple", OleDbType.VarChar, 255, "V2_PastSimple");
				oleDb.oleDbCommandUpdate.Parameters.Add("@V3_PastParticiple", OleDbType.VarChar, 255, "V3_PastParticiple");
				oleDb.oleDbCommandUpdate.Parameters.Add("@V4_PresentParticiple", OleDbType.VarChar, 255, "V4_PresentParticiple");
				oleDb.oleDbCommandUpdate.Parameters.Add("@Verb_Translation", OleDbType.VarChar, 255, "Verb_Translation");
				oleDb.oleDbCommandUpdate.Parameters.Add("@ID", OleDbType.Integer, 10, "ID");
				
				oleDb.dataSet.Tables["RegularVerbs"].Rows[0]["V1_Infivitive"] = textBox2.Text;
				oleDb.dataSet.Tables["RegularVerbs"].Rows[0]["V2_PastSimple"] = textBox3.Text;
				oleDb.dataSet.Tables["RegularVerbs"].Rows[0]["V3_PastParticiple"] = textBox4.Text;
				oleDb.dataSet.Tables["RegularVerbs"].Rows[0]["V4_PresentParticiple"] = textBox5.Text;
				oleDb.dataSet.Tables["RegularVerbs"].Rows[0]["Verb_Translation"] = textBox6.Text;
				oleDb.oleDbCommandUpdate.CommandText = "UPDATE RegularVerbs SET " +
					"[V1_Infivitive] = @V1_Infivitive, [V2_PastSimple] = @V2_PastSimple, " +
					"[V3_PastParticiple] = @V3_PastParticiple, [V4_PresentParticiple] = @V4_PresentParticiple, " +
					"[Verb_Translation] = @Verb_Translation " +
					"WHERE ([ID] = @ID)";
			}
			
			if(oleDb.ExecuteUpdate("RegularVerbs")){
				Utilits.Console.Log("Правильные глаголы: Запись - успешно сохранена.");
				Close();
				(ParentForm as RegularVerbsForm).TableRefresh();
			}
		}
		
		void initIrregularVerbs()
		{
			label2.Text = "Infinitive (V1):"; label2.Visible = true;
			textBox2.Visible = true;
			label3.Text = "Past Simple (V2):"; label3.Visible = true;
			textBox3.Visible = true;
			label4.Text = "Past Participle (V3):"; label4.Visible = true;
			textBox4.Visible = true;
			label5.Text = "Present Participle (V4):"; label5.Visible = true;
			textBox5.Visible = true;
			label6.Text = "Перевод:"; label6.Visible = true;
			textBox6.Visible = true;
			
			oleDb = new OleDb(Config.databaseFile);
			oleDb.dataSet.Clear();
			oleDb.dataSet.DataSetName = "IrregularVerbs";
			
			if(ThisIsNew == false)
			{
				oleDb.oleDbCommandSelect.CommandText = "SELECT * FROM IrregularVerbs WHERE (ID = " + ID + ")";
				oleDb.ExecuteFill("IrregularVerbs");
				textBox1.Text = oleDb.dataSet.Tables["IrregularVerbs"].Rows[0]["ID"].ToString();
				textBox2.Text = oleDb.dataSet.Tables["IrregularVerbs"].Rows[0]["V1_Infivitive"].ToString();
				textBox3.Text = oleDb.dataSet.Tables["IrregularVerbs"].Rows[0]["V2_PastSimple"].ToString();
				textBox4.Text = oleDb.dataSet.Tables["IrregularVerbs"].Rows[0]["V3_PastParticiple"].ToString();
				textBox5.Text = oleDb.dataSet.Tables["IrregularVerbs"].Rows[0]["V4_PresentParticiple"].ToString();
				textBox6.Text = oleDb.dataSet.Tables["IrregularVerbs"].Rows[0]["Verb_Translation"].ToString();
			}
		}
		
		void saveIrregularVerbs()
		{
			if(ThisIsNew){
				oleDb.dataSet.Clear();
				oleDb.dataSet.DataSetName = "IrregularVerbs";
				oleDb.oleDbCommandSelect.CommandText = "SELECT * FROM IrregularVerbs";
				oleDb.ExecuteFill("IrregularVerbs");
				
				oleDb.oleDbCommandInsert.CommandText = "INSERT INTO IrregularVerbs (V1_Infivitive, V2_PastSimple, V3_PastParticiple, V4_PresentParticiple, Verb_Translation) VALUES (@V1_Infivitive, @V2_PastSimple, @V3_PastParticiple, @V4_PresentParticiple, @Verb_Translation)";
				oleDb.oleDbCommandInsert.Parameters.Add("@V1_Infivitive", OleDbType.VarChar, 255, "V1_Infivitive");
				oleDb.oleDbCommandInsert.Parameters.Add("@V2_PastSimple", OleDbType.VarChar, 255, "V2_PastSimple");
				oleDb.oleDbCommandInsert.Parameters.Add("@V3_PastParticiple", OleDbType.VarChar, 255, "V3_PastParticiple");
				oleDb.oleDbCommandInsert.Parameters.Add("@V4_PresentParticiple", OleDbType.VarChar, 255, "V4_PresentParticiple");
				oleDb.oleDbCommandInsert.Parameters.Add("@Verb_Translation", OleDbType.VarChar, 255, "Verb_Translation");
				
				DataRow newRow = oleDb.dataSet.Tables["IrregularVerbs"].NewRow();
				newRow["V1_Infivitive"] = textBox2.Text;
				newRow["V2_PastSimple"] = textBox3.Text;
				newRow["V3_PastParticiple"] = textBox4.Text;
				newRow["V4_PresentParticiple"] = textBox5.Text;
				newRow["Verb_Translation"] = textBox6.Text;
				oleDb.dataSet.Tables["IrregularVerbs"].Rows.Add(newRow);
			}else{
				oleDb.oleDbCommandUpdate.Parameters.Add("@V1_Infivitive", OleDbType.VarChar, 255, "V1_Infivitive");
				oleDb.oleDbCommandUpdate.Parameters.Add("@V2_PastSimple", OleDbType.VarChar, 255, "V2_PastSimple");
				oleDb.oleDbCommandUpdate.Parameters.Add("@V3_PastParticiple", OleDbType.VarChar, 255, "V3_PastParticiple");
				oleDb.oleDbCommandUpdate.Parameters.Add("@V4_PresentParticiple", OleDbType.VarChar, 255, "V4_PresentParticiple");
				oleDb.oleDbCommandUpdate.Parameters.Add("@Verb_Translation", OleDbType.VarChar, 255, "Verb_Translation");
				oleDb.oleDbCommandUpdate.Parameters.Add("@ID", OleDbType.Integer, 10, "ID");
				
				oleDb.dataSet.Tables["IrregularVerbs"].Rows[0]["V1_Infivitive"] = textBox2.Text;
				oleDb.dataSet.Tables["IrregularVerbs"].Rows[0]["V2_PastSimple"] = textBox3.Text;
				oleDb.dataSet.Tables["IrregularVerbs"].Rows[0]["V3_PastParticiple"] = textBox4.Text;
				oleDb.dataSet.Tables["IrregularVerbs"].Rows[0]["V4_PresentParticiple"] = textBox5.Text;
				oleDb.dataSet.Tables["IrregularVerbs"].Rows[0]["Verb_Translation"] = textBox6.Text;
				oleDb.oleDbCommandUpdate.CommandText = "UPDATE IrregularVerbs SET " +
					"[V1_Infivitive] = @V1_Infivitive, [V2_PastSimple] = @V2_PastSimple, " +
					"[V3_PastParticiple] = @V3_PastParticiple, [V4_PresentParticiple] = @V4_PresentParticiple, " +
					"[Verb_Translation] = @Verb_Translation " +
					"WHERE ([ID] = @ID)";
			}
			
			if(oleDb.ExecuteUpdate("IrregularVerbs")){
				Utilits.Console.Log("Неправильные глаголы: Запись - успешно сохранена.");
				Close();
				(ParentForm as IrregularVerbsForm).TableRefresh();
			}
		}
		
		void initModalVerbs()
		{
			label2.Text = "Модальный глагол (Modal):"; label2.Visible = true;
			textBox2.Visible = true;
			label3.Text = "Прошедшее время (Past):"; label3.Visible = true;
			textBox3.Visible = true;
			label4.Text = "Перевод:"; label4.Visible = true;
			textBox4.Visible = true;
			
			oleDb = new OleDb(Config.databaseFile);
			oleDb.dataSet.Clear();
			oleDb.dataSet.DataSetName = "ModalVerbs";
			
			if(ThisIsNew == false)
			{
				oleDb.oleDbCommandSelect.CommandText = "SELECT * FROM ModalVerbs WHERE (ID = " + ID + ")";
				oleDb.ExecuteFill("ModalVerbs");
				textBox1.Text = oleDb.dataSet.Tables["ModalVerbs"].Rows[0]["ID"].ToString();
				textBox2.Text = oleDb.dataSet.Tables["ModalVerbs"].Rows[0]["Verb_Modal"].ToString();
				textBox3.Text = oleDb.dataSet.Tables["ModalVerbs"].Rows[0]["Verb_Past"].ToString();
				textBox4.Text = oleDb.dataSet.Tables["ModalVerbs"].Rows[0]["Verb_Translation"].ToString();
			}
		}
		
		void saveModalVerbs()
		{
			if(ThisIsNew){
				oleDb.dataSet.Clear();
				oleDb.dataSet.DataSetName = "ModalVerbs";
				oleDb.oleDbCommandSelect.CommandText = "SELECT * FROM ModalVerbs";
				oleDb.ExecuteFill("ModalVerbs");
				
				oleDb.oleDbCommandInsert.CommandText = "INSERT INTO ModalVerbs (Verb_Modal, Verb_Past, Verb_Translation) VALUES (@Verb_Modal, @Verb_Past, @Verb_Translation)";
				oleDb.oleDbCommandInsert.Parameters.Add("@Verb_Modal", OleDbType.VarChar, 255, "Verb_Modal");
				oleDb.oleDbCommandInsert.Parameters.Add("@Verb_Past", OleDbType.VarChar, 255, "Verb_Past");
				oleDb.oleDbCommandInsert.Parameters.Add("@Verb_Translation", OleDbType.VarChar, 255, "Verb_Translation");
				
				DataRow newRow = oleDb.dataSet.Tables["ModalVerbs"].NewRow();
				newRow["Verb_Modal"] = textBox2.Text;
				newRow["Verb_Past"] = textBox3.Text;
				newRow["Verb_Translation"] = textBox4.Text;
				oleDb.dataSet.Tables["ModalVerbs"].Rows.Add(newRow);
			}else{
				oleDb.oleDbCommandUpdate.Parameters.Add("@Verb_Modal", OleDbType.VarChar, 255, "Verb_Modal");
				oleDb.oleDbCommandUpdate.Parameters.Add("@Verb_Past", OleDbType.VarChar, 255, "Verb_Past");
				oleDb.oleDbCommandUpdate.Parameters.Add("@Verb_Translation", OleDbType.VarChar, 255, "Verb_Translation");
				oleDb.oleDbCommandUpdate.Parameters.Add("@ID", OleDbType.Integer, 10, "ID");
				
				oleDb.dataSet.Tables["ModalVerbs"].Rows[0]["Verb_Modal"] = textBox2.Text;
				oleDb.dataSet.Tables["ModalVerbs"].Rows[0]["Verb_Past"] = textBox3.Text;
				oleDb.dataSet.Tables["ModalVerbs"].Rows[0]["Verb_Translation"] = textBox4.Text;
				oleDb.oleDbCommandUpdate.CommandText = "UPDATE ModalVerbs SET " +
					"[Verb_Modal] = @Verb_Modal, [Verb_Past] = @Verb_Past, " +
					"[Verb_Translation] = @Verb_Translation " +
					"WHERE ([ID] = @ID)";
			}
			
			if(oleDb.ExecuteUpdate("ModalVerbs")){
				Utilits.Console.Log("Модальные глаголы: Запись - успешно сохранена.");
				Close();
				(ParentForm as ModalVerbsForm).TableRefresh();
			}
		}
		
		void initPronouns()
		{
			label2.Text = "Местоимение:"; label2.Visible = true;
			textBox2.Visible = true;
			label3.Text = "Перевод:"; label3.Visible = true;
			textBox3.Visible = true;
						
			oleDb = new OleDb(Config.databaseFile);
			oleDb.dataSet.Clear();
			oleDb.dataSet.DataSetName = "Pronouns";
			
			if(ThisIsNew == false)
			{
				oleDb.oleDbCommandSelect.CommandText = "SELECT * FROM Pronouns WHERE (ID = " + ID + ")";
				oleDb.ExecuteFill("Pronouns");
				textBox1.Text = oleDb.dataSet.Tables["Pronouns"].Rows[0]["ID"].ToString();
				textBox2.Text = oleDb.dataSet.Tables["Pronouns"].Rows[0]["Pronoun"].ToString();
				textBox3.Text = oleDb.dataSet.Tables["Pronouns"].Rows[0]["Pronoun_Translation"].ToString();
			}
		}
		
		void savePronouns()
		{
			if(ThisIsNew){
				oleDb.dataSet.Clear();
				oleDb.dataSet.DataSetName = "Pronouns";
				oleDb.oleDbCommandSelect.CommandText = "SELECT * FROM Pronouns";
				oleDb.ExecuteFill("Pronouns");
				
				oleDb.oleDbCommandInsert.CommandText = "INSERT INTO Pronouns (Pronoun, Pronoun_Translation) VALUES (@Pronoun, @Pronoun_Translation)";
				oleDb.oleDbCommandInsert.Parameters.Add("@Pronoun", OleDbType.VarChar, 255, "Pronoun");
				oleDb.oleDbCommandInsert.Parameters.Add("@Pronoun_Translation", OleDbType.VarChar, 255, "Pronoun_Translation");
								
				DataRow newRow = oleDb.dataSet.Tables["Pronouns"].NewRow();
				newRow["Pronoun"] = textBox2.Text;
				newRow["Pronoun_Translation"] = textBox3.Text;
				oleDb.dataSet.Tables["Pronouns"].Rows.Add(newRow);
			}else{
				oleDb.oleDbCommandUpdate.Parameters.Add("@Pronoun", OleDbType.VarChar, 255, "Pronoun");
				oleDb.oleDbCommandUpdate.Parameters.Add("@Pronoun_Translation", OleDbType.VarChar, 255, "Pronoun_Translation");
				oleDb.oleDbCommandUpdate.Parameters.Add("@ID", OleDbType.Integer, 10, "ID");
				
				oleDb.dataSet.Tables["Pronouns"].Rows[0]["Pronoun"] = textBox2.Text;
				oleDb.dataSet.Tables["Pronouns"].Rows[0]["Pronoun_Translation"] = textBox3.Text;
				oleDb.oleDbCommandUpdate.CommandText = "UPDATE Pronouns SET " +
					"[Pronoun] = @Pronoun, [Pronoun_Translation] = @Pronoun_Translation " +
					"WHERE ([ID] = @ID)";
			}
			
			if(oleDb.ExecuteUpdate("Pronouns")){
				Utilits.Console.Log("Местоимения: Запись - успешно сохранена.");
				Close();
				(ParentForm as PronounsForm).TableRefresh();
			}
		}
		
		void initArticles()
		{
			label2.Text = "Артикль:"; label2.Visible = true;
			textBox2.Visible = true;
			label3.Text = "Перевод:"; label3.Visible = true;
			textBox3.Visible = true;
						
			oleDb = new OleDb(Config.databaseFile);
			oleDb.dataSet.Clear();
			oleDb.dataSet.DataSetName = "Articles";
			
			if(ThisIsNew == false)
			{
				oleDb.oleDbCommandSelect.CommandText = "SELECT * FROM Articles WHERE (ID = " + ID + ")";
				oleDb.ExecuteFill("Articles");
				textBox1.Text = oleDb.dataSet.Tables["Articles"].Rows[0]["ID"].ToString();
				textBox2.Text = oleDb.dataSet.Tables["Articles"].Rows[0]["Article_English"].ToString();
				textBox3.Text = oleDb.dataSet.Tables["Articles"].Rows[0]["Article_Translation"].ToString();
			}
		}
		
		void saveArticles()
		{
			if(ThisIsNew){
				oleDb.dataSet.Clear();
				oleDb.dataSet.DataSetName = "Articles";
				oleDb.oleDbCommandSelect.CommandText = "SELECT * FROM Articles";
				oleDb.ExecuteFill("Articles");
				
				oleDb.oleDbCommandInsert.CommandText = "INSERT INTO Articles (Article_English, Article_Translation) VALUES (@Article_English, @Article_Translation)";
				oleDb.oleDbCommandInsert.Parameters.Add("@Article_English", OleDbType.VarChar, 255, "Article_English");
				oleDb.oleDbCommandInsert.Parameters.Add("@Article_Translation", OleDbType.VarChar, 255, "Article_Translation");
								
				DataRow newRow = oleDb.dataSet.Tables["Articles"].NewRow();
				newRow["Article_English"] = textBox2.Text;
				newRow["Article_Translation"] = textBox3.Text;
				oleDb.dataSet.Tables["Articles"].Rows.Add(newRow);
			}else{
				oleDb.oleDbCommandUpdate.Parameters.Add("@Article_English", OleDbType.VarChar, 255, "Article_English");
				oleDb.oleDbCommandUpdate.Parameters.Add("@Article_Translation", OleDbType.VarChar, 255, "Article_Translation");
				oleDb.oleDbCommandUpdate.Parameters.Add("@ID", OleDbType.Integer, 10, "ID");
				
				oleDb.dataSet.Tables["Articles"].Rows[0]["Article_English"] = textBox2.Text;
				oleDb.dataSet.Tables["Articles"].Rows[0]["Article_Translation"] = textBox3.Text;
				oleDb.oleDbCommandUpdate.CommandText = "UPDATE Articles SET " +
					"[Article_English] = @Article_English, [Article_Translation] = @Article_Translation " +
					"WHERE ([ID] = @ID)";
			}
			
			if(oleDb.ExecuteUpdate("Articles")){
				Utilits.Console.Log("Артикли: Запись - успешно сохранена.");
				Close();
				(ParentForm as ArticlesForm).TableRefresh();
			}
		}
		
		void initNouns()
		{
			label2.Text = "Единственное число:"; label2.Visible = true;
			textBox2.Visible = true;
			label3.Text = "Множественное число:"; label3.Visible = true;
			textBox3.Visible = true;
			label4.Text = "Перевод:"; label4.Visible = true;
			textBox4.Visible = true;
						
			oleDb = new OleDb(Config.databaseFile);
			oleDb.dataSet.Clear();
			oleDb.dataSet.DataSetName = "Nouns";
			
			if(ThisIsNew == false)
			{
				oleDb.oleDbCommandSelect.CommandText = "SELECT * FROM Nouns WHERE (ID = " + ID + ")";
				oleDb.ExecuteFill("Nouns");
				textBox1.Text = oleDb.dataSet.Tables["Nouns"].Rows[0]["ID"].ToString();
				textBox2.Text = oleDb.dataSet.Tables["Nouns"].Rows[0]["Singular_Noun"].ToString();
				textBox3.Text = oleDb.dataSet.Tables["Nouns"].Rows[0]["Plural_Noun"].ToString();
				textBox4.Text = oleDb.dataSet.Tables["Nouns"].Rows[0]["Noun_Translation"].ToString();
			}
		}
		
		void saveNouns()
		{
			if(ThisIsNew){
				oleDb.dataSet.Clear();
				oleDb.dataSet.DataSetName = "Nouns";
				oleDb.oleDbCommandSelect.CommandText = "SELECT * FROM Nouns";
				oleDb.ExecuteFill("Nouns");
				
				oleDb.oleDbCommandInsert.CommandText = "INSERT INTO Nouns (Singular_Noun, Plural_Noun, Noun_Translation) VALUES (@Singular_Noun, @Plural_Noun, @Noun_Translation)";
				oleDb.oleDbCommandInsert.Parameters.Add("@Singular_Noun", OleDbType.VarChar, 255, "Singular_Noun");
				oleDb.oleDbCommandInsert.Parameters.Add("@Plural_Noun", OleDbType.VarChar, 255, "Plural_Noun");
				oleDb.oleDbCommandInsert.Parameters.Add("@Noun_Translation", OleDbType.VarChar, 255, "Noun_Translation");
								
				DataRow newRow = oleDb.dataSet.Tables["Nouns"].NewRow();
				newRow["Singular_Noun"] = textBox2.Text;
				newRow["Plural_Noun"] = textBox3.Text;
				newRow["Noun_Translation"] = textBox4.Text;
				oleDb.dataSet.Tables["Nouns"].Rows.Add(newRow);
			}else{
				oleDb.oleDbCommandUpdate.Parameters.Add("@Singular_Noun", OleDbType.VarChar, 255, "Singular_Noun");
				oleDb.oleDbCommandUpdate.Parameters.Add("@Plural_Noun", OleDbType.VarChar, 255, "Plural_Noun");
				oleDb.oleDbCommandUpdate.Parameters.Add("@Noun_Translation", OleDbType.VarChar, 255, "Noun_Translation");
				oleDb.oleDbCommandUpdate.Parameters.Add("@ID", OleDbType.Integer, 10, "ID");
				
				oleDb.dataSet.Tables["Nouns"].Rows[0]["Singular_Noun"] = textBox2.Text;
				oleDb.dataSet.Tables["Nouns"].Rows[0]["Plural_Noun"] = textBox3.Text;
				oleDb.dataSet.Tables["Nouns"].Rows[0]["Noun_Translation"] = textBox4.Text;
				oleDb.oleDbCommandUpdate.CommandText = "UPDATE Nouns SET " +
					"[Singular_Noun] = @Singular_Noun, [Plural_Noun] = @Plural_Noun, " +
					"[Noun_Translation] = @Noun_Translation " +
					"WHERE ([ID] = @ID)";
			}
			
			if(oleDb.ExecuteUpdate("Nouns")){
				Utilits.Console.Log("Существительное: Запись - успешно сохранена.");
				Close();
				(ParentForm as NounsForm).TableRefresh();
			}
		}
		
		void initAdjective()
		{
			label2.Text = "Положительная степень (Positive):"; label2.Visible = true;
			textBox2.Visible = true;
			label3.Text = "Сравнительная степень (Comparative):"; label3.Visible = true;
			textBox3.Visible = true;
			label4.Text = "Превосходная степень (Superlative):"; label4.Visible = true;
			textBox4.Visible = true;
			label5.Text = "Перевод:"; label5.Visible = true;
			textBox5.Visible = true;
						
			oleDb = new OleDb(Config.databaseFile);
			oleDb.dataSet.Clear();
			oleDb.dataSet.DataSetName = "Adjective";
			
			if(ThisIsNew == false)
			{
				oleDb.oleDbCommandSelect.CommandText = "SELECT * FROM Adjective WHERE (ID = " + ID + ")";
				oleDb.ExecuteFill("Adjective");
				textBox1.Text = oleDb.dataSet.Tables["Adjective"].Rows[0]["ID"].ToString();
				textBox2.Text = oleDb.dataSet.Tables["Adjective"].Rows[0]["Positive"].ToString();
				textBox3.Text = oleDb.dataSet.Tables["Adjective"].Rows[0]["Comparative"].ToString();
				textBox4.Text = oleDb.dataSet.Tables["Adjective"].Rows[0]["Superlative"].ToString();
				textBox5.Text = oleDb.dataSet.Tables["Adjective"].Rows[0]["Adjective_Translation"].ToString();
			}
		}
		
		void saveAdjective()
		{
			if(ThisIsNew){
				oleDb.dataSet.Clear();
				oleDb.dataSet.DataSetName = "Adjective";
				oleDb.oleDbCommandSelect.CommandText = "SELECT * FROM Adjective";
				oleDb.ExecuteFill("Adjective");
				
				oleDb.oleDbCommandInsert.CommandText = "INSERT INTO Adjective (Positive, Comparative, Superlative, Adjective_Translation) VALUES (@Positive, @Comparative, @Superlative, @Adjective_Translation)";
				oleDb.oleDbCommandInsert.Parameters.Add("@Positive", OleDbType.VarChar, 255, "Positive");
				oleDb.oleDbCommandInsert.Parameters.Add("@Comparative", OleDbType.VarChar, 255, "Comparative");
				oleDb.oleDbCommandInsert.Parameters.Add("@Superlative", OleDbType.VarChar, 255, "Superlative");
				oleDb.oleDbCommandInsert.Parameters.Add("@Adjective_Translation", OleDbType.VarChar, 255, "Adjective_Translation");
								
				DataRow newRow = oleDb.dataSet.Tables["Adjective"].NewRow();
				newRow["Positive"] = textBox2.Text;
				newRow["Comparative"] = textBox3.Text;
				newRow["Superlative"] = textBox4.Text;
				newRow["Adjective_Translation"] = textBox5.Text;
				oleDb.dataSet.Tables["Adjective"].Rows.Add(newRow);
			}else{
				oleDb.oleDbCommandUpdate.Parameters.Add("@Positive", OleDbType.VarChar, 255, "Positive");
				oleDb.oleDbCommandUpdate.Parameters.Add("@Comparative", OleDbType.VarChar, 255, "Comparative");
				oleDb.oleDbCommandUpdate.Parameters.Add("@Superlative", OleDbType.VarChar, 255, "Superlative");
				oleDb.oleDbCommandUpdate.Parameters.Add("@Adjective_Translation", OleDbType.VarChar, 255, "Adjective_Translation");
				oleDb.oleDbCommandUpdate.Parameters.Add("@ID", OleDbType.Integer, 10, "ID");
				
				oleDb.dataSet.Tables["Adjective"].Rows[0]["Positive"] = textBox2.Text;
				oleDb.dataSet.Tables["Adjective"].Rows[0]["Comparative"] = textBox3.Text;
				oleDb.dataSet.Tables["Adjective"].Rows[0]["Superlative"] = textBox4.Text;
				oleDb.dataSet.Tables["Adjective"].Rows[0]["Adjective_Translation"] = textBox5.Text;
				oleDb.oleDbCommandUpdate.CommandText = "UPDATE Adjective SET " +
					"[Positive] = @Positive, [Comparative] = @Comparative, " +
					"[Superlative] = @Superlative, [Adjective_Translation] = @Adjective_Translation " +
					"WHERE ([ID] = @ID)";
			}
			
			if(oleDb.ExecuteUpdate("Adjective")){
				Utilits.Console.Log("Прилагательное: Запись - успешно сохранена.");
				Close();
				(ParentForm as AdjectiveForm).TableRefresh();
			}
		}
		
		void initNumeral()
		{
			label2.Text = "Числительное:"; label2.Visible = true;
			textBox2.Visible = true;
			label3.Text = "Перевод:"; label3.Visible = true;
			textBox3.Visible = true;
						
			oleDb = new OleDb(Config.databaseFile);
			oleDb.dataSet.Clear();
			oleDb.dataSet.DataSetName = "Numeral";
			
			if(ThisIsNew == false)
			{
				oleDb.oleDbCommandSelect.CommandText = "SELECT * FROM Numeral WHERE (ID = " + ID + ")";
				oleDb.ExecuteFill("Numeral");
				textBox1.Text = oleDb.dataSet.Tables["Numeral"].Rows[0]["ID"].ToString();
				textBox2.Text = oleDb.dataSet.Tables["Numeral"].Rows[0]["Numeral_English"].ToString();
				textBox3.Text = oleDb.dataSet.Tables["Numeral"].Rows[0]["Numeral_Translation"].ToString();
			}
		}
		
		void saveNumeral()
		{
			if(ThisIsNew){
				oleDb.dataSet.Clear();
				oleDb.dataSet.DataSetName = "Numeral";
				oleDb.oleDbCommandSelect.CommandText = "SELECT * FROM Numeral";
				oleDb.ExecuteFill("Numeral");
				
				oleDb.oleDbCommandInsert.CommandText = "INSERT INTO Numeral (Numeral_English, Numeral_Translation) VALUES (@Numeral_English, @Numeral_Translation)";
				oleDb.oleDbCommandInsert.Parameters.Add("@Numeral_English", OleDbType.VarChar, 255, "Numeral_English");
				oleDb.oleDbCommandInsert.Parameters.Add("@Numeral_Translation", OleDbType.VarChar, 255, "Numeral_Translation");
								
				DataRow newRow = oleDb.dataSet.Tables["Numeral"].NewRow();
				newRow["Numeral_English"] = textBox2.Text;
				newRow["Numeral_Translation"] = textBox3.Text;
				oleDb.dataSet.Tables["Numeral"].Rows.Add(newRow);
			}else{
				oleDb.oleDbCommandUpdate.Parameters.Add("@Numeral_English", OleDbType.VarChar, 255, "Numeral_English");
				oleDb.oleDbCommandUpdate.Parameters.Add("@Numeral_Translation", OleDbType.VarChar, 255, "Numeral_Translation");
				oleDb.oleDbCommandUpdate.Parameters.Add("@ID", OleDbType.Integer, 10, "ID");
				
				oleDb.dataSet.Tables["Numeral"].Rows[0]["Numeral_English"] = textBox2.Text;
				oleDb.dataSet.Tables["Numeral"].Rows[0]["Numeral_Translation"] = textBox3.Text;
				oleDb.oleDbCommandUpdate.CommandText = "UPDATE Numeral SET " +
					"[Numeral_English] = @Numeral_English, [Numeral_Translation] = @Numeral_Translation " +
					"WHERE ([ID] = @ID)";
			}
			
			if(oleDb.ExecuteUpdate("Numeral")){
				Utilits.Console.Log("Числительное: Запись - успешно сохранена.");
				Close();
				(ParentForm as NumeralForm).TableRefresh();
			}
		}
		
		void initAdverb()
		{
			label2.Text = "Наречие:"; label2.Visible = true;
			textBox2.Visible = true;
			label3.Text = "Перевод:"; label3.Visible = true;
			textBox3.Visible = true;
						
			oleDb = new OleDb(Config.databaseFile);
			oleDb.dataSet.Clear();
			oleDb.dataSet.DataSetName = "Adverb";
			
			if(ThisIsNew == false)
			{
				oleDb.oleDbCommandSelect.CommandText = "SELECT * FROM Adverb WHERE (ID = " + ID + ")";
				oleDb.ExecuteFill("Adverb");
				textBox1.Text = oleDb.dataSet.Tables["Adverb"].Rows[0]["ID"].ToString();
				textBox2.Text = oleDb.dataSet.Tables["Adverb"].Rows[0]["Adverb_English"].ToString();
				textBox3.Text = oleDb.dataSet.Tables["Adverb"].Rows[0]["Adverb_Translation"].ToString();
			}
		}
		
		void saveAdverb()
		{
			if(ThisIsNew){
				oleDb.dataSet.Clear();
				oleDb.dataSet.DataSetName = "Adverb";
				oleDb.oleDbCommandSelect.CommandText = "SELECT * FROM Adverb";
				oleDb.ExecuteFill("Adverb");
				
				oleDb.oleDbCommandInsert.CommandText = "INSERT INTO Adverb (Adverb_English, Adverb_Translation) VALUES (@Adverb_English, @Adverb_Translation)";
				oleDb.oleDbCommandInsert.Parameters.Add("@Adverb_English", OleDbType.VarChar, 255, "Adverb_English");
				oleDb.oleDbCommandInsert.Parameters.Add("@Adverb_Translation", OleDbType.VarChar, 255, "Adverb_Translation");
								
				DataRow newRow = oleDb.dataSet.Tables["Adverb"].NewRow();
				newRow["Adverb_English"] = textBox2.Text;
				newRow["Adverb_Translation"] = textBox3.Text;
				oleDb.dataSet.Tables["Adverb"].Rows.Add(newRow);
			}else{
				oleDb.oleDbCommandUpdate.Parameters.Add("@Adverb_English", OleDbType.VarChar, 255, "Adverb_English");
				oleDb.oleDbCommandUpdate.Parameters.Add("@Adverb_Translation", OleDbType.VarChar, 255, "Adverb_Translation");
				oleDb.oleDbCommandUpdate.Parameters.Add("@ID", OleDbType.Integer, 10, "ID");
				
				oleDb.dataSet.Tables["Adverb"].Rows[0]["Adverb_English"] = textBox2.Text;
				oleDb.dataSet.Tables["Adverb"].Rows[0]["Adverb_Translation"] = textBox3.Text;
				oleDb.oleDbCommandUpdate.CommandText = "UPDATE Adverb SET " +
					"[Adverb_English] = @Adverb_English, [Adverb_Translation] = @Adverb_Translation " +
					"WHERE ([ID] = @ID)";
			}
			
			if(oleDb.ExecuteUpdate("Adverb")){
				Utilits.Console.Log("Наречие: Запись - успешно сохранена.");
				Close();
				(ParentForm as AdverbForm).TableRefresh();
			}
		}
		
		void initConditions()
		{
			label2.Text = "Условие:"; label2.Visible = true;
			textBox2.Visible = true;
			label3.Text = "Перевод:"; label3.Visible = true;
			textBox3.Visible = true;
						
			oleDb = new OleDb(Config.databaseFile);
			oleDb.dataSet.Clear();
			oleDb.dataSet.DataSetName = "Conditions";
			
			if(ThisIsNew == false)
			{
				oleDb.oleDbCommandSelect.CommandText = "SELECT * FROM Conditions WHERE (ID = " + ID + ")";
				oleDb.ExecuteFill("Conditions");
				textBox1.Text = oleDb.dataSet.Tables["Conditions"].Rows[0]["ID"].ToString();
				textBox2.Text = oleDb.dataSet.Tables["Conditions"].Rows[0]["Condition_English"].ToString();
				textBox3.Text = oleDb.dataSet.Tables["Conditions"].Rows[0]["Condition_Translation"].ToString();
			}
		}
		
		void saveConditions()
		{
			if(ThisIsNew){
				oleDb.dataSet.Clear();
				oleDb.dataSet.DataSetName = "Conditions";
				oleDb.oleDbCommandSelect.CommandText = "SELECT * FROM Conditions";
				oleDb.ExecuteFill("Conditions");
				
				oleDb.oleDbCommandInsert.CommandText = "INSERT INTO Conditions (Condition_English, Condition_Translation) VALUES (@Condition_English, @Condition_Translation)";
				oleDb.oleDbCommandInsert.Parameters.Add("@Condition_English", OleDbType.VarChar, 255, "Condition_English");
				oleDb.oleDbCommandInsert.Parameters.Add("@Condition_Translation", OleDbType.VarChar, 255, "Condition_Translation");
								
				DataRow newRow = oleDb.dataSet.Tables["Conditions"].NewRow();
				newRow["Condition_English"] = textBox2.Text;
				newRow["Condition_Translation"] = textBox3.Text;
				oleDb.dataSet.Tables["Conditions"].Rows.Add(newRow);
			}else{
				oleDb.oleDbCommandUpdate.Parameters.Add("@Condition_English", OleDbType.VarChar, 255, "Condition_English");
				oleDb.oleDbCommandUpdate.Parameters.Add("@Condition_Translation", OleDbType.VarChar, 255, "Condition_Translation");
				oleDb.oleDbCommandUpdate.Parameters.Add("@ID", OleDbType.Integer, 10, "ID");
				
				oleDb.dataSet.Tables["Conditions"].Rows[0]["Condition_English"] = textBox2.Text;
				oleDb.dataSet.Tables["Conditions"].Rows[0]["Condition_Translation"] = textBox3.Text;
				oleDb.oleDbCommandUpdate.CommandText = "UPDATE Conditions SET " +
					"[Condition_English] = @Condition_English, [Condition_Translation] = @Condition_Translation " +
					"WHERE ([ID] = @ID)";
			}
			
			if(oleDb.ExecuteUpdate("Conditions")){
				Utilits.Console.Log("Условное наклонение: Запись - успешно сохранена.");
				Close();
				(ParentForm as ConditionsForm).TableRefresh();
			}
		}
		
		void initPreposition()
		{
			label2.Text = "Предлог:"; label2.Visible = true;
			textBox2.Visible = true;
			label3.Text = "Перевод:"; label3.Visible = true;
			textBox3.Visible = true;
						
			oleDb = new OleDb(Config.databaseFile);
			oleDb.dataSet.Clear();
			oleDb.dataSet.DataSetName = "Preposition";
			
			if(ThisIsNew == false)
			{
				oleDb.oleDbCommandSelect.CommandText = "SELECT * FROM Preposition WHERE (ID = " + ID + ")";
				oleDb.ExecuteFill("Preposition");
				textBox1.Text = oleDb.dataSet.Tables["Preposition"].Rows[0]["ID"].ToString();
				textBox2.Text = oleDb.dataSet.Tables["Preposition"].Rows[0]["Preposition_English"].ToString();
				textBox3.Text = oleDb.dataSet.Tables["Preposition"].Rows[0]["Preposition_Translation"].ToString();
			}
		}
		
		void savePreposition()
		{
			if(ThisIsNew){
				oleDb.dataSet.Clear();
				oleDb.dataSet.DataSetName = "Preposition";
				oleDb.oleDbCommandSelect.CommandText = "SELECT * FROM Preposition";
				oleDb.ExecuteFill("Preposition");
				
				oleDb.oleDbCommandInsert.CommandText = "INSERT INTO Preposition (Preposition_English, Preposition_Translation) VALUES (@Preposition_English, @Preposition_Translation)";
				oleDb.oleDbCommandInsert.Parameters.Add("@Preposition_English", OleDbType.VarChar, 255, "Preposition_English");
				oleDb.oleDbCommandInsert.Parameters.Add("@Preposition_Translation", OleDbType.VarChar, 255, "Preposition_Translation");
								
				DataRow newRow = oleDb.dataSet.Tables["Preposition"].NewRow();
				newRow["Preposition_English"] = textBox2.Text;
				newRow["Preposition_Translation"] = textBox3.Text;
				oleDb.dataSet.Tables["Preposition"].Rows.Add(newRow);
			}else{
				oleDb.oleDbCommandUpdate.Parameters.Add("@Preposition_English", OleDbType.VarChar, 255, "Preposition_English");
				oleDb.oleDbCommandUpdate.Parameters.Add("@Preposition_Translation", OleDbType.VarChar, 255, "Preposition_Translation");
				oleDb.oleDbCommandUpdate.Parameters.Add("@ID", OleDbType.Integer, 10, "ID");
				
				oleDb.dataSet.Tables["Preposition"].Rows[0]["Preposition_English"] = textBox2.Text;
				oleDb.dataSet.Tables["Preposition"].Rows[0]["Preposition_Translation"] = textBox3.Text;
				oleDb.oleDbCommandUpdate.CommandText = "UPDATE Preposition SET " +
					"[Preposition_English] = @Preposition_English, [Preposition_Translation] = @Preposition_Translation " +
					"WHERE ([ID] = @ID)";
			}
			
			if(oleDb.ExecuteUpdate("Preposition")){
				Utilits.Console.Log("Предлоги: Запись - успешно сохранена.");
				Close();
				(ParentForm as PrepositionForm).TableRefresh();
			}
		}
		
		void initUnions()
		{
			label2.Text = "Союз:"; label2.Visible = true;
			textBox2.Visible = true;
			label3.Text = "Перевод:"; label3.Visible = true;
			textBox3.Visible = true;
						
			oleDb = new OleDb(Config.databaseFile);
			oleDb.dataSet.Clear();
			oleDb.dataSet.DataSetName = "Unions";
			
			if(ThisIsNew == false)
			{
				oleDb.oleDbCommandSelect.CommandText = "SELECT * FROM Unions WHERE (ID = " + ID + ")";
				oleDb.ExecuteFill("Unions");
				textBox1.Text = oleDb.dataSet.Tables["Unions"].Rows[0]["ID"].ToString();
				textBox2.Text = oleDb.dataSet.Tables["Unions"].Rows[0]["Union_English"].ToString();
				textBox3.Text = oleDb.dataSet.Tables["Unions"].Rows[0]["Union_Translation"].ToString();
			}
		}
		
		void saveUnions()
		{
			if(ThisIsNew){
				oleDb.dataSet.Clear();
				oleDb.dataSet.DataSetName = "Unions";
				oleDb.oleDbCommandSelect.CommandText = "SELECT * FROM Unions";
				oleDb.ExecuteFill("Unions");
				
				oleDb.oleDbCommandInsert.CommandText = "INSERT INTO Unions (Union_English, Union_Translation) VALUES (@Union_English, @Union_Translation)";
				oleDb.oleDbCommandInsert.Parameters.Add("@Union_English", OleDbType.VarChar, 255, "Union_English");
				oleDb.oleDbCommandInsert.Parameters.Add("@Union_Translation", OleDbType.VarChar, 255, "Union_Translation");
								
				DataRow newRow = oleDb.dataSet.Tables["Unions"].NewRow();
				newRow["Union_English"] = textBox2.Text;
				newRow["Union_Translation"] = textBox3.Text;
				oleDb.dataSet.Tables["Unions"].Rows.Add(newRow);
			}else{
				oleDb.oleDbCommandUpdate.Parameters.Add("@Union_English", OleDbType.VarChar, 255, "Union_English");
				oleDb.oleDbCommandUpdate.Parameters.Add("@Union_Translation", OleDbType.VarChar, 255, "Union_Translation");
				oleDb.oleDbCommandUpdate.Parameters.Add("@ID", OleDbType.Integer, 10, "ID");
				
				oleDb.dataSet.Tables["Unions"].Rows[0]["Union_English"] = textBox2.Text;
				oleDb.dataSet.Tables["Unions"].Rows[0]["Union_Translation"] = textBox3.Text;
				oleDb.oleDbCommandUpdate.CommandText = "UPDATE Unions SET " +
					"[Union_English] = @Union_English, [Union_Translation] = @Union_Translation " +
					"WHERE ([ID] = @ID)";
			}
			
			if(oleDb.ExecuteUpdate("Unions")){
				Utilits.Console.Log("Союзы: Запись - успешно сохранена.");
				Close();
				(ParentForm as UnionForm).TableRefresh();
			}
		}
		
		void initParticles()
		{
			label2.Text = "Частицы:"; label2.Visible = true;
			textBox2.Visible = true;
			label3.Text = "Перевод:"; label3.Visible = true;
			textBox3.Visible = true;
						
			oleDb = new OleDb(Config.databaseFile);
			oleDb.dataSet.Clear();
			oleDb.dataSet.DataSetName = "Particles";
			
			if(ThisIsNew == false)
			{
				oleDb.oleDbCommandSelect.CommandText = "SELECT * FROM Particles WHERE (ID = " + ID + ")";
				oleDb.ExecuteFill("Particles");
				textBox1.Text = oleDb.dataSet.Tables["Particles"].Rows[0]["ID"].ToString();
				textBox2.Text = oleDb.dataSet.Tables["Particles"].Rows[0]["Particle_English"].ToString();
				textBox3.Text = oleDb.dataSet.Tables["Particles"].Rows[0]["Particle_Translation"].ToString();
			}
		}
		
		void saveParticles()
		{
			if(ThisIsNew){
				oleDb.dataSet.Clear();
				oleDb.dataSet.DataSetName = "Particles";
				oleDb.oleDbCommandSelect.CommandText = "SELECT * FROM Particles";
				oleDb.ExecuteFill("Particles");
				
				oleDb.oleDbCommandInsert.CommandText = "INSERT INTO Particles (Particle_English, Particle_Translation) VALUES (@Particle_English, @Particle_Translation)";
				oleDb.oleDbCommandInsert.Parameters.Add("@Particle_English", OleDbType.VarChar, 255, "Particle_English");
				oleDb.oleDbCommandInsert.Parameters.Add("@Particle_Translation", OleDbType.VarChar, 255, "Particle_Translation");
								
				DataRow newRow = oleDb.dataSet.Tables["Particles"].NewRow();
				newRow["Particle_English"] = textBox2.Text;
				newRow["Particle_Translation"] = textBox3.Text;
				oleDb.dataSet.Tables["Particles"].Rows.Add(newRow);
			}else{
				oleDb.oleDbCommandUpdate.Parameters.Add("@Particle_English", OleDbType.VarChar, 255, "Particle_English");
				oleDb.oleDbCommandUpdate.Parameters.Add("@Particle_Translation", OleDbType.VarChar, 255, "Particle_Translation");
				oleDb.oleDbCommandUpdate.Parameters.Add("@ID", OleDbType.Integer, 10, "ID");
				
				oleDb.dataSet.Tables["Particles"].Rows[0]["Particle_English"] = textBox2.Text;
				oleDb.dataSet.Tables["Particles"].Rows[0]["Particle_Translation"] = textBox3.Text;
				oleDb.oleDbCommandUpdate.CommandText = "UPDATE Particles SET " +
					"[Particle_English] = @Particle_English, [Particle_Translation] = @Particle_Translation " +
					"WHERE ([ID] = @ID)";
			}
			
			if(oleDb.ExecuteUpdate("Particles")){
				Utilits.Console.Log("Частицы: Запись - успешно сохранена.");
				Close();
				(ParentForm as ParticlesForm).TableRefresh();
			}
		}
		
		void initModalWords()
		{
			label2.Text = "Модальное слово:"; label2.Visible = true;
			textBox2.Visible = true;
			label3.Text = "Перевод:"; label3.Visible = true;
			textBox3.Visible = true;
						
			oleDb = new OleDb(Config.databaseFile);
			oleDb.dataSet.Clear();
			oleDb.dataSet.DataSetName = "ModalWords";
			
			if(ThisIsNew == false)
			{
				oleDb.oleDbCommandSelect.CommandText = "SELECT * FROM ModalWords WHERE (ID = " + ID + ")";
				oleDb.ExecuteFill("ModalWords");
				textBox1.Text = oleDb.dataSet.Tables["ModalWords"].Rows[0]["ID"].ToString();
				textBox2.Text = oleDb.dataSet.Tables["ModalWords"].Rows[0]["ModalWord_English"].ToString();
				textBox3.Text = oleDb.dataSet.Tables["ModalWords"].Rows[0]["ModalWord_Translation"].ToString();
			}
		}
		
		void saveModalWords()
		{
			if(ThisIsNew){
				oleDb.dataSet.Clear();
				oleDb.dataSet.DataSetName = "ModalWords";
				oleDb.oleDbCommandSelect.CommandText = "SELECT * FROM ModalWords";
				oleDb.ExecuteFill("ModalWords");
				
				oleDb.oleDbCommandInsert.CommandText = "INSERT INTO ModalWords (ModalWord_English, ModalWord_Translation) VALUES (@ModalWord_English, @ModalWord_Translation)";
				oleDb.oleDbCommandInsert.Parameters.Add("@ModalWord_English", OleDbType.VarChar, 255, "ModalWord_English");
				oleDb.oleDbCommandInsert.Parameters.Add("@ModalWord_Translation", OleDbType.VarChar, 255, "ModalWord_Translation");
								
				DataRow newRow = oleDb.dataSet.Tables["ModalWords"].NewRow();
				newRow["ModalWord_English"] = textBox2.Text;
				newRow["ModalWord_Translation"] = textBox3.Text;
				oleDb.dataSet.Tables["ModalWords"].Rows.Add(newRow);
			}else{
				oleDb.oleDbCommandUpdate.Parameters.Add("@ModalWord_English", OleDbType.VarChar, 255, "ModalWord_English");
				oleDb.oleDbCommandUpdate.Parameters.Add("@ModalWord_Translation", OleDbType.VarChar, 255, "ModalWord_Translation");
				oleDb.oleDbCommandUpdate.Parameters.Add("@ID", OleDbType.Integer, 10, "ID");
				
				oleDb.dataSet.Tables["ModalWords"].Rows[0]["ModalWord_English"] = textBox2.Text;
				oleDb.dataSet.Tables["ModalWords"].Rows[0]["ModalWord_Translation"] = textBox3.Text;
				oleDb.oleDbCommandUpdate.CommandText = "UPDATE ModalWords SET " +
					"[ModalWord_English] = @ModalWord_English, [ModalWord_Translation] = @ModalWord_Translation " +
					"WHERE ([ID] = @ID)";
			}
			
			if(oleDb.ExecuteUpdate("ModalWords")){
				Utilits.Console.Log("Модальные слова: Запись - успешно сохранена.");
				Close();
				(ParentForm as ModalWordsForm).TableRefresh();
			}
		}
		
		void initIntroductoryWords()
		{
			label2.Text = "Вводное слово:"; label2.Visible = true;
			textBox2.Visible = true;
			label3.Text = "Перевод:"; label3.Visible = true;
			textBox3.Visible = true;
						
			oleDb = new OleDb(Config.databaseFile);
			oleDb.dataSet.Clear();
			oleDb.dataSet.DataSetName = "IntroductoryWords";
			
			if(ThisIsNew == false)
			{
				oleDb.oleDbCommandSelect.CommandText = "SELECT * FROM IntroductoryWords WHERE (ID = " + ID + ")";
				oleDb.ExecuteFill("IntroductoryWords");
				textBox1.Text = oleDb.dataSet.Tables["IntroductoryWords"].Rows[0]["ID"].ToString();
				textBox2.Text = oleDb.dataSet.Tables["IntroductoryWords"].Rows[0]["IntroWord_English"].ToString();
				textBox3.Text = oleDb.dataSet.Tables["IntroductoryWords"].Rows[0]["IntroWord_Translation"].ToString();
			}
		}
		
		void saveIntroductoryWords()
		{
			if(ThisIsNew){
				oleDb.dataSet.Clear();
				oleDb.dataSet.DataSetName = "IntroductoryWords";
				oleDb.oleDbCommandSelect.CommandText = "SELECT * FROM IntroductoryWords";
				oleDb.ExecuteFill("IntroductoryWords");
				
				oleDb.oleDbCommandInsert.CommandText = "INSERT INTO IntroductoryWords (IntroWord_English, IntroWord_Translation) VALUES (@IntroWord_English, @IntroWord_Translation)";
				oleDb.oleDbCommandInsert.Parameters.Add("@IntroWord_English", OleDbType.VarChar, 255, "IntroWord_English");
				oleDb.oleDbCommandInsert.Parameters.Add("@IntroWord_Translation", OleDbType.VarChar, 255, "IntroWord_Translation");
								
				DataRow newRow = oleDb.dataSet.Tables["IntroductoryWords"].NewRow();
				newRow["IntroWord_English"] = textBox2.Text;
				newRow["IntroWord_Translation"] = textBox3.Text;
				oleDb.dataSet.Tables["IntroductoryWords"].Rows.Add(newRow);
			}else{
				oleDb.oleDbCommandUpdate.Parameters.Add("@IntroWord_English", OleDbType.VarChar, 255, "IntroWord_English");
				oleDb.oleDbCommandUpdate.Parameters.Add("@IntroWord_Translation", OleDbType.VarChar, 255, "IntroWord_Translation");
				oleDb.oleDbCommandUpdate.Parameters.Add("@ID", OleDbType.Integer, 10, "ID");
				
				oleDb.dataSet.Tables["IntroductoryWords"].Rows[0]["IntroWord_English"] = textBox2.Text;
				oleDb.dataSet.Tables["IntroductoryWords"].Rows[0]["IntroWord_Translation"] = textBox3.Text;
				oleDb.oleDbCommandUpdate.CommandText = "UPDATE IntroductoryWords SET " +
					"[IntroWord_English] = @IntroWord_English, [IntroWord_Translation] = @IntroWord_Translation " +
					"WHERE ([ID] = @ID)";
			}
			
			if(oleDb.ExecuteUpdate("IntroductoryWords")){
				Utilits.Console.Log("Вводные слова: Запись - успешно сохранена.");
				Close();
				(ParentForm as IntroWordsForm).TableRefresh();
			}
		}
		
		void initInterjections()
		{
			label2.Text = "Междомение:"; label2.Visible = true;
			textBox2.Visible = true;
			label3.Text = "Перевод:"; label3.Visible = true;
			textBox3.Visible = true;
						
			oleDb = new OleDb(Config.databaseFile);
			oleDb.dataSet.Clear();
			oleDb.dataSet.DataSetName = "Interjections";
			
			if(ThisIsNew == false)
			{
				oleDb.oleDbCommandSelect.CommandText = "SELECT * FROM Interjections WHERE (ID = " + ID + ")";
				oleDb.ExecuteFill("Interjections");
				textBox1.Text = oleDb.dataSet.Tables["Interjections"].Rows[0]["ID"].ToString();
				textBox2.Text = oleDb.dataSet.Tables["Interjections"].Rows[0]["Interjection_English"].ToString();
				textBox3.Text = oleDb.dataSet.Tables["Interjections"].Rows[0]["Interjection_Translation"].ToString();
			}
		}
		
		void saveInterjections()
		{
			if(ThisIsNew){
				oleDb.dataSet.Clear();
				oleDb.dataSet.DataSetName = "Interjections";
				oleDb.oleDbCommandSelect.CommandText = "SELECT * FROM Interjections";
				oleDb.ExecuteFill("Interjections");
				
				oleDb.oleDbCommandInsert.CommandText = "INSERT INTO Interjections (Interjection_English, Interjection_Translation) VALUES (@Interjection_English, @Interjection_Translation)";
				oleDb.oleDbCommandInsert.Parameters.Add("@Interjection_English", OleDbType.VarChar, 255, "Interjection_English");
				oleDb.oleDbCommandInsert.Parameters.Add("@Interjection_Translation", OleDbType.VarChar, 255, "Interjection_Translation");
								
				DataRow newRow = oleDb.dataSet.Tables["Interjections"].NewRow();
				newRow["Interjection_English"] = textBox2.Text;
				newRow["Interjection_Translation"] = textBox3.Text;
				oleDb.dataSet.Tables["Interjections"].Rows.Add(newRow);
			}else{
				oleDb.oleDbCommandUpdate.Parameters.Add("@Interjection_English", OleDbType.VarChar, 255, "Interjection_English");
				oleDb.oleDbCommandUpdate.Parameters.Add("@Interjection_Translation", OleDbType.VarChar, 255, "Interjection_Translation");
				oleDb.oleDbCommandUpdate.Parameters.Add("@ID", OleDbType.Integer, 10, "ID");
				
				oleDb.dataSet.Tables["Interjections"].Rows[0]["Interjection_English"] = textBox2.Text;
				oleDb.dataSet.Tables["Interjections"].Rows[0]["Interjection_Translation"] = textBox3.Text;
				oleDb.oleDbCommandUpdate.CommandText = "UPDATE Interjections SET " +
					"[Interjection_English] = @Interjection_English, [Interjection_Translation] = @Interjection_Translation " +
					"WHERE ([ID] = @ID)";
			}
			
			if(oleDb.ExecuteUpdate("Interjections")){
				Utilits.Console.Log("Междометия: Запись - успешно сохранена.");
				Close();
				(ParentForm as InterjectionsForm).TableRefresh();
			}
		}
		
		
	}
}
