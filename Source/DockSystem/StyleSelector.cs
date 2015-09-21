using System.Windows;
using System.Windows.Controls;

namespace Editor.DockSystem
{
    public class DockStyleSelector : StyleSelector
    {
        public Style DocumentStyle { get; set; }

        public Style ToolStyle { get; set; }

        public override Style SelectStyle(object item, DependencyObject container)
        {
            if (item is DocumentTab) return DocumentStyle;

            if (item is ToolTab) return ToolStyle;

            return base.SelectStyle(item, container);
        }
    }
}