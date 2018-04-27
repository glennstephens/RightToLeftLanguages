using System;
using System.ComponentModel;
using System.Reflection;
using System.Resources;
using Plugin.Multilingual;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RTLExample
{
	[ContentProperty("Text")]
	public class TranslateExtension : IMarkupExtension
	{
		const string ResourceId = "RTLExample.Resources.AppResources";

		static readonly Lazy<ResourceManager> resmgr = new Lazy<ResourceManager>(() => new ResourceManager(ResourceId, typeof(TranslateExtension).GetTypeInfo().Assembly));
		
		public string Text { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
		{
            if (Text == null)
                return "";

            var ci = CrossMultilingual.Current.CurrentCultureInfo;

            var translation = resmgr.Value.GetString(Text, ci);

            if (translation == null)
            {

#if DEBUG
                throw new ArgumentException(
                    String.Format("Key '{0}' was not found in resources '{1}' for culture '{2}'.", Text, ResourceId, ci.Name),
                    "Text");
#else
				translation = Text; // returns the key, which GETS DISPLAYED TO THE USER
#endif
            }
            return translation;
        }
	}

	/// <summary>
    /// Convenient helpers, so that in XAML I can use {local:ise MyResourceName}
    /// or if comeone spells it with a z, then that should work also
    /// </summary>
    public class iseExtension : TranslateExtension { }
    public class izeExtension : iseExtension { }
}