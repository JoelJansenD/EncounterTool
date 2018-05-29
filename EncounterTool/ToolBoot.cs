using EncounterTool.Encounters;
using EncounterTool.Weather;
using Newtonsoft.Json;
using System;
using System.IO;

namespace EncounterTool
{
    class ToolBoot
    {
        public static EncounterCreator EncounterController;
        public static WeatherCreator WeatherController;

        static void Main(string[] args)
        {
            LoadEnvironments();
            LoadMonsters();
            //LoadWeather();
            //Console.WriteLine(WeatherController.GenerateWeather());
            Console.WriteLine(EncounterController.Environments[0].Name);
            Console.WriteLine(EncounterController.Monsters[0].Name);
        }

        private static void LoadEnvironments()
        {
            string environJson = File.ReadAllText(@"..\..\..\data\environment.json");
            EncounterController = JsonConvert.DeserializeObject<EncounterCreator>(environJson);
        }

        private static void LoadMonsters()
        {
            string monsterJson = File.ReadAllText(@"..\..\..\data\monster.json");
            MonsterWrapper monsterList = JsonConvert.DeserializeObject<MonsterWrapper>(monsterJson);
            EncounterController.Monsters = monsterList.monsters;
        }

        private static void LoadWeather()
        {
            string weatherJson = File.ReadAllText(@"..\..\..\data\weather.json");
            WeatherController = JsonConvert.DeserializeObject<WeatherCreator>(weatherJson);

            if(WeatherController.Precipitations == null)
            {
                WeatherController.Precipitations = new Precipitation[0];
            }

            if (WeatherController.Temperatures == null)
            {
                WeatherController.Temperatures = new Temperature[0];
            }

            if (WeatherController.Winds == null)
            {
                WeatherController.Winds = new Wind[0];
            }
        }

        private struct MonsterWrapper
        {
            public Monster[] monsters;
        }
    }
}
