/*
 * Created by SharpDevelop.
 * User: Catfish
 * Date: 27.01.2019
 * Time: 10:11
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;
using System.Net;
using Newtonsoft.Json;

/*
 * Библиотека Newtonsoft.Json: https://github.com/JamesNK/Newtonsoft.Json/releases
 * Яндекс ключь: https://tech.yandex.ru/keys/get/?service=trnsl
 */


namespace EnglishTrainer.Utilits
{
	public class Translation
	{
    	public string code { get; set; }
    	public string lang { get; set; }
    	public string[] text { get; set; }
	}
	
	public static class YandexTranslator
	{
		public static string Key = "";
		public static string LangRuEn = "ru-en";
		public static string LangEnRu = "en-ru";
		
		public static string Translate(string text, string lang, string key)
        {
            
			if (text.Length > 0)
            {
                try{
					WebRequest request = WebRequest.Create("https://translate.yandex.net/api/v1.5/tr.json/translate?"
                    	+ "key=" + key
                    	+ "&text=" + text
                    	+ "&lang=" + lang);

	                WebResponse response = request.GetResponse();
	
	                using (StreamReader stream = new StreamReader(response.GetResponseStream()))
	                {
	                    string line;
	
	                    if ((line = stream.ReadLine()) != null)
	                    {
	                        Translation translation = JsonConvert.DeserializeObject<Translation>(line);
	                        text = "";
	                        foreach (string str in translation.text)
	                        {
	                            text += str;
	                        }
	                    }
	                }
				}catch(Exception ex){
					Utilits.Console.LogError(ex.Message, false, true);
				}
                return text;
            }
			else
			{
                return "";
			}
        }
	}
}
