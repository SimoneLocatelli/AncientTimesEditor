using Editor.WindowShell.Dependencies;

namespace Editor.WindowShell.ContentTemplates
{
    /// <summary>
    ///     Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class DefaultContentsTemplate : IDefaultContentsTemplate
    {
        public const string BottomSectionConstant = "BottomSection";

        public const string MainContentsConstant = "MainContents";

        public const string TopSectionConstant = "TopSection";

        public string BottomSection
        {
            get { return BottomSectionConstant; }
        }

        public string MainContents
        {
            get { return MainContentsConstant; }
        }

        public string TopSection
        {
            get { return TopSectionConstant; }
        }

        public DefaultContentsTemplate()
        {
            InitializeComponent();
        }
    }
}