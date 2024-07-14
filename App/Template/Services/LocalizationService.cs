using Template.Common.Interfaces;
using Microsoft.Extensions.Localization;
using Template.Helpers;
using Template.Resources.Strings;

namespace Template.Services
{
    public class LocalizationService : ILocalizationService
    {
        private IStringLocalizer<Texts> localizer;

        public LocalizationService()
        {
            this.localizer = ServiceHelper.GetService<IStringLocalizer<Texts>>();
        }


        public string GetText(string text)
        {
            var localizedText = this.localizer[text];
            return localizedText;
        }
    }
}
