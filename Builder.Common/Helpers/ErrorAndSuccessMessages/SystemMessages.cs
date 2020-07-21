using Builder.Common.Helpers.AppSettingConfiguration;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace Builder.Common.Helpers.ErrorAndSuccessMessages
{
    public class SystemMessages
    {
        private static List<Message> GetAllErrors()
        {
            IConfigurationRoot root = AppSettingConfig.GetAppSettingConfig();
            var errors = root.GetSection("SystemMessages");
            string filePath = errors["JsonErrorsPath"].ToLower();
            string json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<Message>>(json);

        }

        public static string GetErrorMessage(string erroreCode)
        {
            var currentError = GetAllErrors().FirstOrDefault(m => m.Message_ID == erroreCode);
            return currentError == null ? null : Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName == "en" ? currentError.Message_Description_EN: currentError.Message_Description_AR ;
        }

        private static List<Message> GetAllSuccess()
        {
            IConfigurationRoot root = AppSettingConfig.GetAppSettingConfig();
            var errors = root.GetSection("SystemMessages");
            string filePath = errors["JsonSuccessPath"].ToLower();
            string json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<Message>>(json);
        }

        public static string GetSuccessMessage(string erroreCode)
        {
            var currentSuccess = GetAllSuccess().FirstOrDefault(m => m.Message_ID == erroreCode);
            return currentSuccess == null ? null : Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName == "en" ? currentSuccess.Message_Description_EN : currentSuccess.Message_Description_AR;
        }
    }
}
