/*
 * Created by SharpDevelop.
 * User: Catfish
 * Date: 12.11.2018
 * Time: 9:40
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace EnglishTrainer.Data
{
	/// <summary>
	/// Description of Config.
	/// </summary>
	public static class Config
	{
		/* Программа */	
		public static String programPath = "";			// адрес программы
		public static String resource = "";				// адрес папки ресурсов
		public static String databaseFile = "";			// адрес и имя файла базы данных base.mdb
		
		/* Локальная база данных */		
		public static String oledbConnectString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=";
	}
}
