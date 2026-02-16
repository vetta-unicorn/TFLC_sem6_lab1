using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace TFLC_sem6_lab1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            OutputTextBox.Enabled = false;
            InputTextBox.Enabled = false;
            SetEvent();
        }

        public void SetEvent()
        {
            foreach (ToolStripMenuItem item in MainMenu.Items)
            {
                if (item.Text == "Файл")
                {
                    ToolStripMenuItem createItem = new ToolStripMenuItem();
                    createItem.Text = "Создать";
                    createItem.Click += CreateFile;
                    item.DropDownItems.Add(createItem);

                    // дальше сохранить и тд
                }
            }
        }

        public void CreateFile(object sender, EventArgs e)
        {
            InputTextBox.Enabled = true;
            InputTextBox.Text = "";
        }

        public ToolStripMenuItem FindItem(string funcName)
        {
            foreach (ToolStripMenuItem item in MainMenu.Items)
            {
                if (item.Text  == funcName)
                {
                    return item;
                }
            }
            return null;
        }
    }
}
