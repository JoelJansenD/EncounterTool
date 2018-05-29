using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EncounterTool.Weather
{
    class WeatherCreator
    {
        private Random random;
        public Precipitation[] Precipitations;
        public Temperature[] Temperatures;
        public Wind[] Winds;
        
        public WeatherCreator()
        {
            Temperatures = new Temperature[0];
            Winds = new Wind[0];
            random = new Random();
        }
        
        public string GenerateWeather()
        {
            return $"{ GetTemperature() }\n{ GetWind() }\n{ GetPrecipitation() }";
        }

        private string GetPrecipitation()
        {
            if (Precipitations.Length == 0)
            {
                return "";
            }

            Precipitation[] ordered = Precipitations.OrderBy(p => p.On).ToArray();

            int die = ordered.Last().On;
            int result = random.Next(1, die + 1);

            foreach (Precipitation precipitation in ordered)
            {
                if (result <= precipitation.On)
                {
                    return precipitation.Text;
                }
            }

            return "";
        }

        private string GetTemperature()
        {
            if (Temperatures.Length == 0)
            {
                return "";
            }

            Temperature[] ordered = Temperatures.OrderBy(o => o.On).ToArray();

            int die = ordered.Last().On;
            int result = random.Next(1, die + 1);

            foreach (Temperature temperature in ordered)
            {
                if (result <= temperature.On)
                {
                    return temperature.WriteText();
                }
            }

            return "";
        }

        private string GetWind()
        {
            if(Winds.Length == 0)
            {
                return "";
            }

            Wind[] ordered = Winds.OrderBy(w => w.On).ToArray();

            int die = ordered.Last().On;
            int result = random.Next(1, die + 1);

            foreach(Wind wind in ordered)
            {
                if(result <= wind.On)
                {
                    return wind.Text;
                }
            }

            return "";
        }
    }
}
