using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SimpleCalculatorMVVM.Json_classes
{
    public class ConfigLoader
    {
        public static WindowSettings LoadWindowSettings(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("Файл с настройками окна не найден.", filePath);
            }

            string json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<WindowSettings>(json);
        }
    }
}
