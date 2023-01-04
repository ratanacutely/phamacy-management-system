using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using Microsoft.SqlServer.Server;
using Newtonsoft.Json;

namespace DemoDataGridview
{
    public class IOManager
    {
        public string path = "./data/";
        public string extension = ".json";

        public void Save(object datas, string fileName)
        {
            string json = JsonConvert.SerializeObject(datas);
            string fullPath = path + fileName + extension;
            WriteText(json, fullPath);
        }

        public T Load<T>(string fileName)
        {
            string fullPath = path + fileName + extension;
            string json = ReadText(fullPath);
            return JsonConvert.DeserializeObject<T>(json);
        }
        private string ReadText(string fullPath)
        {
            if(File.Exists(fullPath))
            {
                StreamReader sr = new StreamReader(fullPath);
                string json = sr.ReadToEnd();
                sr.Close();
                return json;
            }
            return "[]";
        }

        private void WriteText(string json, string fullPath)
        {
            StreamWriter sw = new StreamWriter(fullPath);
            sw.Write(json);
            sw.Close();
        }
       
    }
}
