using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace AutomationPractice.PageObjects.Dto
{
    public class UserCredetialsDto
    {
        public string Alias { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public static List<UserCredetialsDto> GetUserCredentialsList()
        {
            //var myFile = @"C:\Users\Adina\Projects\AgileHub_Testare_Automatizata\Adina Final Projects\AutomationPractice\AutomationPractice.SpecFlow\TestData\UserCredentials.json";
            var TestDataFolderPath = Path.GetDirectoryName(Assembly.GetCallingAssembly().Location).Replace("bin\\Debug\\net48", "TestData");
            var myFile = $@"{TestDataFolderPath}\UserCredentials.json";

            try
            {
                using (var reader = new StreamReader(myFile))
                {
                    var json = reader.ReadToEnd();
                    var config = JObject.Parse(json).SelectToken("Users").ToString();
                    var usersList = JsonConvert.DeserializeObject<List<UserCredetialsDto>>(config);
                    return usersList;
                }
            }
            catch (Exception)
            {
                throw new Exception($"There's a problem with file {myFile}");
            }
        }

        public static UserCredetialsDto GetUserCredetials(string alias)
        {
            return GetUserCredentialsList().First(obj => obj.Alias == alias);
        }
        
    }
}
