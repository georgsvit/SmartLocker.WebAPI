using Microsoft.Extensions.Localization;
using SmartLocker.WebAPI.Domain.Constants;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace SmartLocker.WebAPI.Services
{
    public class LocalizationService : IStringLocalizer
    {
        private readonly Dictionary<string, Dictionary<string, string>> resources;

        public LocalizationService()
        {
            Dictionary<string, string> enDictionary = ErrorMessages.GetEnglishLocalization();
            Dictionary<string, string> uaDictionary = ErrorMessages.GetUkrainianLocalization();

            CheckInitializationCorrectness(enDictionary, uaDictionary);

            resources = new()
            {
                { "en", enDictionary },
                { "ua", uaDictionary }
            };
        }

        private void CheckInitializationCorrectness(Dictionary<string, string> enDictionary,
                                                    Dictionary<string, string> uaDictionary)
        {
            if (enDictionary.Count != uaDictionary.Count)
                throw new Exception("Localization service failed. Dictionaries have different number of strings.");

            foreach (var value in enDictionary)
            {
                if (!uaDictionary.ContainsKey(value.Key))
                    throw new Exception($"Localization service failed. On key {value.Key}.");
            }
        }

        public LocalizedString this[string name]
        {
            get
            {
                var currentCulture = CultureInfo.CurrentCulture.Name;
                if (resources.ContainsKey(currentCulture))
                {
                    if (resources[currentCulture].ContainsKey(name))
                    {
                        return new LocalizedString(name, resources[currentCulture][name]);
                    }
                    else
                    {
                        throw new Exception($"Localization failed. Localization string is not defined: '{name}'.");
                    }
                }
                else
                {
                    throw new Exception($"Localization failed. This culture is not supported: '{currentCulture}'.");
                }
            }
        }

        public LocalizedString this[string name, params object[] arguments] => this[name];

        public IEnumerable<LocalizedString> GetAllStrings(bool includeParentCultures)
        {
            var currentCulture = CultureInfo.CurrentCulture.Name;
            return resources[currentCulture].Select((pair) => new LocalizedString(pair.Key, pair.Value));
        }
    }
}
