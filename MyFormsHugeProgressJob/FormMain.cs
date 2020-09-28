using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyFormsHugeProgressJob
{
    public partial class FormMain : Form
    {

        Task _task;
        CancellationTokenSource _ts;
        CancellationToken _ct;


        const int MAX_ITERATIONS = 20;

        ProgressWindow _progressWindow;

        /// <summary>
        /// Constructor
        /// </summary>
        public FormMain()
        {
            InitializeComponent();
        }

        /******************************/
        /*       Button Events        */
        /******************************/
        #region Button Events

        /// <summary>
        /// button_Start_Task_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Start_Task_Click(object sender, EventArgs e)
        {
            _progressWindow.Show();

            EnableDisableButtons(true);

            _progressWindow.ProgressSet(MAX_ITERATIONS * MAX_ITERATIONS * MAX_ITERATIONS);
            _progressWindow.ProgressBarReset();

            _ts = new CancellationTokenSource();
            _ct = _ts.Token;
            _task = Task.Factory.StartNew(() => JobManager(), _ct);
        }

        /// <summary>
        /// button_Cancel_Task_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Cancel_Task_Click(object sender, EventArgs e)
        {
            _ts.Cancel();
            EnableDisableButtons(false);
            _progressWindow.Hide();
        }

        /// <summary>
        /// button_Toggle_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Toggle_Click(object sender, EventArgs e)
        {
            if (_progressWindow.Visible)
                _progressWindow.Hide();
            else
                _progressWindow.Show();
        }

        /// <summary>
        /// button_Close_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion
        /******************************/
        /*      Menu Events          */
        /******************************/
        #region Menu Events

        #endregion
        /******************************/
        /*      Other Events          */
        /******************************/
        #region Other Events
        
        /// <summary>
        /// Form1_Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            EnableDisableButtons(false);
            _progressWindow = new ProgressWindow();
            _progressWindow.Owner = this;
            _progressWindow.Cancel += CancelEvent;
        }

        /// <summary>
        /// CancelEvent
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelEvent(object sender, EventArgs e)
        {
            _ts.Cancel();
            EnableDisableButtons(false);
        }

        /// <summary>
        /// Form1_FormClosing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            _progressWindow.Dispose();
            e.Cancel = false;
            _progressWindow.Cancel -= CancelEvent;
        }

        #endregion
        /******************************/
        /*      Other Functions       */
        /******************************/
        #region Other Functions

        /// <summary>
        /// JobManager
        /// </summary>
        public void JobManager()
        {

            // Call the TheHugeJob
            TheHugeJob();

            _progressWindow.Invoke((Action)(() => _progressWindow.Hide()));
            // Mange button state
            EnableDisableButtons(false);
            // give a signal
            Console.Beep();
        }

        /// <summary>
        /// TheHugeJob
        /// </summary>
        public void TheHugeJob()
        {
            int i, j, k;
            Double d = 0.0;

            for (i = 0; i < MAX_ITERATIONS; i++)
                for (j = 0; j < MAX_ITERATIONS; j++)
                    for (k = 0; k < MAX_ITERATIONS; k++)
                    {
                        if (_ct.IsCancellationRequested)
                        {
                            // UI thread decided to cancel
                            Debug.WriteLine(String.Format("We have a Cancellation Requested "));
                            return;
                        }
                        d++;
                        Debug.WriteLine(String.Format("i={0} j={1} k={2} d={3}", i, j, k, d));
                        _progressWindow.ProgressBarUpDate();
                    }
        }

        /// <summary>
        /// EnableDisableButtons
        /// </summary>
        /// <param name="running"></param>
        private void EnableDisableButtons(bool running)
        {
            button_Start_Task.Invoke((Action)(() => button_Start_Task.Enabled = !running));
            button_Start_Task.Invoke((Action)(() => button_Cancel_Task.Enabled = running));
        }

        #endregion
    }
}
