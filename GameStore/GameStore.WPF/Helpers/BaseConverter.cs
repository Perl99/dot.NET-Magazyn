using System;
using System.Windows.Markup;

namespace GameStore.WPF.Helpers
{
    public abstract class BaseConverter : MarkupExtension
    {
        public override object ProvideValue(IServiceProvider serviceProvider) => this;
    }
}
