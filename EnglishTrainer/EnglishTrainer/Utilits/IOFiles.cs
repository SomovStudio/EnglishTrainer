/*
 * Created by SharpDevelop.
 * User: Catfish
 * Date: 27.01.2019
 * Time: 11:58
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;
using System.Text;
using EnglishTrainer.Data;

namespace EnglishTrainer.Utilits
{
	/// <summary>
	/// Description of IOFiles.
	/// </summary>
	public static class IOFiles
	{
		public static bool SaveFile(String fileName, String text)
		{
			try{
				if(!File.Exists(fileName)){ 
					File.Create(fileName).Close();
					FileStream fs = File.OpenWrite(fileName);
					Byte[] info = new UTF8Encoding(true).GetBytes(text);
	                fs.Write(info, 0, info.Length);
	                fs.Close();
	                return true;
				}else{
					File.Delete(fileName);
					File.Create(fileName).Close();
					FileStream fs = File.OpenWrite(fileName);
					Byte[] info = new UTF8Encoding(true).GetBytes(text);
	                fs.Write(info, 0, info.Length);
	                fs.Close();
	                return true;
				}
			}catch(Exception ex){
				Utilits.Console.LogError(ex.Message, false, true);
				return false;
			}
		}
		
		public static String ReadFile(String fileName)
		{
			if(!File.Exists(fileName)){ 
				Utilits.Console.LogError("File " + fileName + " does not exist", false, true);
				return null;
			}else{
				
				byte[] b = new byte[1024];
            	UTF8Encoding temp = new UTF8Encoding(true);
                String text = "";
                FileStream fs = File.OpenRead(@fileName);
                while (fs.Read(b,0,b.Length) > 0) 
	            {
	                text += temp.GetString(b) + Environment.NewLine;
	            }
                fs.Close();
                return text;
			}
		}
		
		public static void CreateConfigFile()
		{
			if(!File.Exists(Config.resource + "config.cfg")){
				String config =
					"trnsl.1.1.20190127T065523Z.3bb77cb655f010fb.f02a26c235c52bdc4e913152bf5254806dc9bcf2" 
					+ Environment.NewLine;
				SaveFile(Config.resource + "config.cfg", config);
			}
		}
		
		public static void SaveConfigFile()
		{
			String config =
				YandexTranslator.Key  + Environment.NewLine;
			SaveFile(Config.resource + "config.cfg", config);
		}
		
		public static void ReadConfigFile()
		{
			String configFileName = Config.resource + "config.cfg";
			if(File.Exists(configFileName)){
				
				String data = ReadFile(configFileName);
				String[] lines = data.Split('\n');
				String text;
				for(int i = 0; i < lines.Length; i++){
					text = lines[i];
					if(text.Length > 0){
						text = text.Remove(text.Length-1, 1);
		                if(i == 0) YandexTranslator.Key = text;
					}
				}
			}
		}
	}
}
