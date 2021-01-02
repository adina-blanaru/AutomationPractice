using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;

namespace AutomationPractice.SpecFlow.TestData
{
    public class ScenarioData
    {
        public class CategoryDto
        {
            public string Name;
            public string[] Subcategories;
        }
        public string ScenarioName { get; set; }
        public string[] Menus { get; set; }
        public CategoryDto[] Categories { get; set; }

        public static List<ScenarioData> LoadTestDataFromFile()
        {
            //var myFile = $"{Environment.CurrentDirectory}\\TestData\\MyTestDataJson.json";
            var myFile = @"C:\Users\Adina\Projects\AgileHub_Testare_Automatizata\Adina Final Projects\AutomationPractice\AutomationPractice.SpecFlow\TestData\TestDataJson.json";

            try
            {
                using (var reader = new StreamReader(myFile))
                {
                    var json = reader.ReadToEnd();
                    var config = JObject.Parse(json).SelectToken("ScenarioDto").ToString();
                    var testDataList = JsonConvert.DeserializeObject<List<ScenarioData>>(config);

                    return testDataList;
                }

            }
            catch (Exception)
            {
                throw new Exception($"There's a problem with file {myFile}");
            }

        }

    }
}
