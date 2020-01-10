/*
 * Created by SharpDevelop.
 * User: Catfish
 * Date: 20.01.2019
 * Time: 11:40
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using EnglishTrainer.Data;
using EnglishTrainer.Database.Local;

namespace EnglishTrainer.Database
{
	public static class VerificationDatabaseMSAccess
	{
		public static bool Verification()
		{
			OleDb oleDb;

			oleDb = new OleDb(Config.databaseFile);
			oleDb.dataSet.Clear();
			oleDb.dataSet.DataSetName = "Practice";
			oleDb.oleDbCommandSelect.CommandText = "SELECT * FROM Practice";
			if(!oleDb.ExecuteFill("Practice")) return false;
			Forms.FMain.progressLoad(5);
			oleDb.Dispose();
			
			oleDb = new OleDb(Config.databaseFile);
			oleDb.dataSet.Clear();
			oleDb.dataSet.DataSetName = "Tests";
			oleDb.oleDbCommandSelect.CommandText = "SELECT * FROM Tests";
			if(!oleDb.ExecuteFill("Tests")) return false;
			Forms.FMain.progressLoad(10);
			oleDb.Dispose();
			
			oleDb = new OleDb(Config.databaseFile);
			oleDb.dataSet.Clear();
			oleDb.dataSet.DataSetName = "EngRusVocabulary";
			oleDb.oleDbCommandSelect.CommandText = "SELECT * FROM EngRusVocabulary";
			if(!oleDb.ExecuteFill("EngRusVocabulary")) return false;
			Forms.FMain.progressLoad(15);
			oleDb.Dispose();
			
			oleDb = new OleDb(Config.databaseFile);
			oleDb.dataSet.Clear();
			oleDb.dataSet.DataSetName = "IrregularVerbs";
			oleDb.oleDbCommandSelect.CommandText = "SELECT * FROM IrregularVerbs";
			if(!oleDb.ExecuteFill("IrregularVerbs")) return false;
			Forms.FMain.progressLoad(20);
			oleDb.Dispose();
			
			oleDb = new OleDb(Config.databaseFile);
			oleDb.dataSet.Clear();
			oleDb.dataSet.DataSetName = "ModalVerbs";
			oleDb.oleDbCommandSelect.CommandText = "SELECT * FROM ModalVerbs";
			if(!oleDb.ExecuteFill("ModalVerbs")) return false;
			Forms.FMain.progressLoad(30);
			oleDb.Dispose();
			
			oleDb = new OleDb(Config.databaseFile);
			oleDb.dataSet.Clear();
			oleDb.dataSet.DataSetName = "RegularVerbs";
			oleDb.oleDbCommandSelect.CommandText = "SELECT * FROM RegularVerbs";
			if(!oleDb.ExecuteFill("RegularVerbs")) return false;
			Forms.FMain.progressLoad(40);
			oleDb.Dispose();
			
			oleDb = new OleDb(Config.databaseFile);
			oleDb.dataSet.Clear();
			oleDb.dataSet.DataSetName = "Pronouns";
			oleDb.oleDbCommandSelect.CommandText = "SELECT * FROM Pronouns";
			if(!oleDb.ExecuteFill("Pronouns")) return false;
			Forms.FMain.progressLoad(45);
			oleDb.Dispose();
			
			oleDb = new OleDb(Config.databaseFile);
			oleDb.dataSet.Clear();
			oleDb.dataSet.DataSetName = "Articles";
			oleDb.oleDbCommandSelect.CommandText = "SELECT * FROM Articles";
			if(!oleDb.ExecuteFill("Articles")) return false;
			Forms.FMain.progressLoad(50);
			oleDb.Dispose();
			
			oleDb = new OleDb(Config.databaseFile);
			oleDb.dataSet.Clear();
			oleDb.dataSet.DataSetName = "Nouns";
			oleDb.oleDbCommandSelect.CommandText = "SELECT * FROM Nouns";
			if(!oleDb.ExecuteFill("Nouns")) return false;
			Forms.FMain.progressLoad(55);
			oleDb.Dispose();
			
			oleDb = new OleDb(Config.databaseFile);
			oleDb.dataSet.Clear();
			oleDb.dataSet.DataSetName = "Adjective";
			oleDb.oleDbCommandSelect.CommandText = "SELECT * FROM Adjective";
			if(!oleDb.ExecuteFill("Adjective")) return false;
			Forms.FMain.progressLoad(60);
			oleDb.Dispose();
			
			oleDb = new OleDb(Config.databaseFile);
			oleDb.dataSet.Clear();
			oleDb.dataSet.DataSetName = "Numeral";
			oleDb.oleDbCommandSelect.CommandText = "SELECT * FROM Numeral";
			if(!oleDb.ExecuteFill("Numeral")) return false;
			Forms.FMain.progressLoad(65);
			oleDb.Dispose();
			
			oleDb = new OleDb(Config.databaseFile);
			oleDb.dataSet.Clear();
			oleDb.dataSet.DataSetName = "Adverb";
			oleDb.oleDbCommandSelect.CommandText = "SELECT * FROM Adverb";
			if(!oleDb.ExecuteFill("Adverb")) return false;
			Forms.FMain.progressLoad(70);
			oleDb.Dispose();
			
			oleDb = new OleDb(Config.databaseFile);
			oleDb.dataSet.Clear();
			oleDb.dataSet.DataSetName = "Conditions";
			oleDb.oleDbCommandSelect.CommandText = "SELECT * FROM Conditions";
			if(!oleDb.ExecuteFill("Conditions")) return false;
			Forms.FMain.progressLoad(75);
			oleDb.Dispose();
			
			oleDb = new OleDb(Config.databaseFile);
			oleDb.dataSet.Clear();
			oleDb.dataSet.DataSetName = "Preposition";
			oleDb.oleDbCommandSelect.CommandText = "SELECT * FROM Preposition";
			if(!oleDb.ExecuteFill("Preposition")) return false;
			Forms.FMain.progressLoad(80);
			oleDb.Dispose();
			
			oleDb = new OleDb(Config.databaseFile);
			oleDb.dataSet.Clear();
			oleDb.dataSet.DataSetName = "Unions";
			oleDb.oleDbCommandSelect.CommandText = "SELECT * FROM Unions";
			if(!oleDb.ExecuteFill("Unions")) return false;
			Forms.FMain.progressLoad(85);
			oleDb.Dispose();
			
			oleDb = new OleDb(Config.databaseFile);
			oleDb.dataSet.Clear();
			oleDb.dataSet.DataSetName = "Particles";
			oleDb.oleDbCommandSelect.CommandText = "SELECT * FROM Particles";
			if(!oleDb.ExecuteFill("Particles")) return false;
			Forms.FMain.progressLoad(90);
			oleDb.Dispose();
			
			oleDb = new OleDb(Config.databaseFile);
			oleDb.dataSet.Clear();
			oleDb.dataSet.DataSetName = "ModalWords";
			oleDb.oleDbCommandSelect.CommandText = "SELECT * FROM ModalWords";
			if(!oleDb.ExecuteFill("ModalWords")) return false;
			Forms.FMain.progressLoad(95);
			oleDb.Dispose();
			
			oleDb = new OleDb(Config.databaseFile);
			oleDb.dataSet.Clear();
			oleDb.dataSet.DataSetName = "IntroductoryWords";
			oleDb.oleDbCommandSelect.CommandText = "SELECT * FROM IntroductoryWords";
			if(!oleDb.ExecuteFill("IntroductoryWords")) return false;
			Forms.FMain.progressLoad(98);
			oleDb.Dispose();
			
			oleDb = new OleDb(Config.databaseFile);
			oleDb.dataSet.Clear();
			oleDb.dataSet.DataSetName = "Interjections";
			oleDb.oleDbCommandSelect.CommandText = "SELECT * FROM Interjections";
			if(!oleDb.ExecuteFill("Interjections")) return false;
			Forms.FMain.progressLoad(100);
			oleDb.Dispose();
			
			return true;
		}
		
		
		
	}
}
