using Microsoft.Extensions.Localization;
using Template.Helpers;
using Template.Resources.Strings;

namespace Template.Extensions
{
    /// <summary>
    /// MarkUp extension to load localization text from resx files
    /// </summary>
    [ContentProperty(nameof(Key))]
    public class LocalizeExtension : IMarkupExtension
    {
        private IStringLocalizer<Texts> localizer;

        /// <summary>
        /// Key to search
        /// </summary>
        public string Key { get; set; } = string.Empty;


        /// <summary>
        /// Loads the extension
        /// </summary>
        public LocalizeExtension()
        {
            this.localizer = ServiceHelper.GetService<IStringLocalizer<Texts>>();
        }


        /// <summary>
        /// Returns a value for a given keu
        /// </summary>
        public object ProvideValue(IServiceProvider serviceProvider)
        {
            var localizedText = this.localizer[Key];
            return localizedText;
        }


        object IMarkupExtension.ProvideValue(IServiceProvider serviceProvider) => ProvideValue(serviceProvider);
    }
}
