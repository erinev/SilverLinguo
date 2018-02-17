using System.Windows.Forms;

namespace Silverio.Žodynas
{
    public partial class UnknownWordsTestForm : Form
    {
        public UnknownWordsTestForm()
        {
            InitializeComponent();
        }

        private const int CpNocloseButton = 0x200;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CpNocloseButton;
                return myCp;
            }
        }
    }
}
