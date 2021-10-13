using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace CPDWeatherApp
{
    public class WeatherDataService
    {
        public WeatherDataService()
        {

        }

        public async Task<IEnumerable<WeatherObject>> GetWeatherObjectAsync()
        {
            try
            {
                var request = WebRequest.Create("https://api.openweathermap.org/data/2.5/forecast?id=2761369&appid=a39fcb63dd4a836ea465cacf485ff54e");
                request.ContentType = "application/json";
                request.Method = "GET";

                using (HttpWebResponse response = await request.GetResponseAsync() as HttpWebResponse)
                {
                    IEnumerable<WeatherObject> result = await Task.Run(() => {

                        var weatherObjectsList = new List<WeatherObject>();

                        if (response.StatusCode != HttpStatusCode.OK)
                        {
                            return null;
                        }

                        using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                        {
                            var json = reader.ReadToEnd();
                            Debug.WriteLine("Json: " + json);
                            if (string.IsNullOrEmpty(json))
                            {
                                Debug.WriteLine("Error: Empty JSON");
                            }
                            else
                            {
                                // Experimental for now
                                // Parse JSON to some kind of object here as soon as API Key is activated
                                var weatherData = JObject.Parse(json)["list"];

                                foreach (var weatherItem in weatherData)
                                {
                                    DateTime tempTime = DateTime.Now;
                                    bool correctDate = DateTime.TryParse((string)weatherItem["dt_txt"], out tempTime);

                                    WeatherObject tempItem = new WeatherObject();
                                    tempItem.Icon = (string)weatherItem["weather"][0]["icon"];
                                    tempItem.Timestamp = tempTime;
                                    tempItem.Condition = (string)weatherItem["weather"][0]["description"];
                                    tempItem.Temperature = (string)weatherItem["main"]["temp"];
                                    tempItem.Pressure = (string)weatherItem["main"]["pressure"];
                                    tempItem.Humidity = (string)weatherItem["main"]["humidity"];
                                    tempItem.CloudCover = (string)weatherItem["clouds"]["all"];
                                    tempItem.WindSpeed = (string)weatherItem["wind"]["speed"];
                                    tempItem.WindDirection = (string)weatherItem["wind"]["deg"];
                                    try
                                    {
                                        tempItem.Rain3h = (string)weatherItem["rain"]["3h"];
                                    }
                                    catch(Exception ex)
                                    {
                                        tempItem.Rain3h = "0";
                                    }
                                    try
                                    {
                                        tempItem.Snow3h = (string)weatherItem["snow"]["3h"];
                                    }
                                    catch(Exception ex)
                                    {
                                        tempItem.Snow3h = "0";
                                    }
                                   
                                    weatherObjectsList.Add(tempItem);
                                    //Debug.WriteLine("TempItem: " + tempItem.Icon);
                                    //Debug.WriteLine("TempItem: " + tempItem.Timestamp);
                                    //Debug.WriteLine("TempItem: " + tempItem.Condition);
                                    //Debug.WriteLine("TempItem: " + tempItem.Temperature);
                                    //Debug.WriteLine("TempItem: " + tempItem.Pressure);
                                    //Debug.WriteLine("TempItem: " + tempItem.Humidity);
                                    //Debug.WriteLine("TempItem: " + tempItem.CloudCover);
                                    //Debug.WriteLine("TempItem: " + tempItem.WindSpeed);
                                    //Debug.WriteLine("TempItem: " + tempItem.WindDirection);
                                    //Debug.WriteLine("TempItem: " + tempItem.Rain3h);
                                    //Debug.WriteLine("TempItem: " + tempItem.Snow3h);


                                }

                            }
                        }
                        return weatherObjectsList;
                    });

                    return result;
                }
            }
            catch (WebException ex)
            {
                Debug.WriteLine("Error: " + ex);
                return null;
            }



        }



    }
}
