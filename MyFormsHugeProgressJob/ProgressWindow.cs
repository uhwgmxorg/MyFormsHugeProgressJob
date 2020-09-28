using System;
using System.Windows.Forms;

namespace MyFormsHugeProgressJob
{
    public partial class ProgressWindow : Form
    {
        public event EventHandler Cancel;

        /// <summary>
        /// Constructor
        /// </summary>
        public ProgressWindow()
        {
            InitializeComponent();

            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            StartPosition = FormStartPosition.CenterParent;
        }

        /// <summary>
        /// ProgressWindow_Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProgressWindow_Load(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Cancel_Click(object sender, EventArgs e)
        {
            Cancel?.Invoke(null, null);
        }

        /// <summary>
        /// ProgressWindow_VisibleChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProgressWindow_VisibleChanged(object sender, EventArgs e)
        {
            Top = Owner.Top + (Owner.Height - Height) / 2;
            Left = Owner.Left +  (Owner.Width - Width) / 2;
        }

        /// <summary>
        /// ProgressWindow_FormClosing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProgressWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }

        /// <summary>
        /// UpDate
        /// </summary>
        public void ProgressBarUpDate()
        {
            progressBar1.Invoke((Action)(() => progressBar1.Value++));
        }

        /// <summary>
        /// ProgressBarReset
        /// </summary>
        public void ProgressBarReset()
        {
            progressBar1.Value = progressBar1.Minimum;
        }

        /// <summary>
        /// ProgressSet
        /// </summary>
        /// <param name="max"></param>
        /// <param name="min"></param>
        public void ProgressSet(int max, int min = 0)
        {
            progressBar1.Maximum = max;
            progressBar1.Minimum = min;
        }
    }
}
