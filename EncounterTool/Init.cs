using EncounterTool.Encounters;
using EncounterTool.Weather;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;

namespace EncounterTool
{
    class Init
    {
        public static EncounterCreator EncounterController;
        public static WeatherCreator WeatherController;

        static void Main(string[] args)
        {
            LoadEncounters();
            LoadWeather();

            Console.WriteLine(WeatherController.GenerateWeather() + "\n");
            Console.WriteLine(EncounterController.Environments[0].Name);
            Console.WriteLine(EncounterController.Monsters[0].Name);
            Console.WriteLine(EncounterController.Personalities[0].Name);
            Console.WriteLine(EncounterController.Relationships[0].ToString());
        }

        private static void LoadEncounters()
        {
            EncounterController = new EncounterCreator()
            {
                Environments = LoadEnvironments(),
                Monsters = LoadMonsters(),
                Personalities = LoadPersonalities(),
                Relationships = LoadRelationships()
            };

            EncounterController.Relationships[0].Target = EncounterController.Monsters[1];
        }

        private static Encounters.Environment[] LoadEnvironments()
        {
            string environmentJson = File.ReadAllText(@"..\..\..\data\environment.json");
            JArray environments = JArray.Parse(environmentJson);
            return environments.ToObject<Encounters.Environment[]>();
        }

        private static Monster[] LoadMonsters()
        {
            string monsterJson = File.ReadAllText(@"..\..\..\data\monster.json");
            JArray monsters = JArray.Parse(monsterJson);
            return monsters.ToObject<Monster[]>();
        }

        private static Personality[] LoadPersonalities()
        {
            string personalityJson = File.ReadAllText(@"..\..\..\data\personality.json");
            JArray personalities = JArray.Parse(personalityJson);
            return personalities.ToObject<Personality[]>();
        }

        private static Relationship[] LoadRelationships()
        {
            string relationshipJson = File.ReadAllText(@"..\..\..\data\relationship.json");
            JArray relationships = JArray.Parse(relationshipJson);
            return relationships.ToObject<Relationship[]>();
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
    }
}
