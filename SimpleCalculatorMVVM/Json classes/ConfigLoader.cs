using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SimpleCalculatorMVVM
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

        public static FontSettings LoadFontSettings(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("Файл с настройками шрифтов не найден.", filePath);
            }

            string json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<FontSettings>(json);
        }
    }
}
