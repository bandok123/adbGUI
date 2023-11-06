using adbGUI.Methods;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace adbGUI.Forms
{
    public partial class LogcatView : Form
    {
        private string m_selectedDevices;
        private Process m_logcatProcess;
        private bool m_isLogcatStarted = false;
        private int m_lineNumber = 0;

        public LogcatView()
        {
            InitializeComponent();
        }

        private void OnFormLoadAction(object sender, EventArgs e)
        {
            DevicesWatcher.DevicesChanged += DevicesWatcher_DevicesChanged;
        }

        private void DevicesWatcher_DevicesChanged(object sender, List<string> devices)
        {
            m_selectedDevices = "";
            DevicesComboBox.ComboBox.Invoke((MethodInvoker)(() => DevicesComboBox.ComboBox.DataSource = devices));
        }

        private void AddMessage(Color color, string msg)
        {
            m_lineNumber++;
            logviewBox.SelectionColor = color;
            logviewBox.AppendText($"[{m_lineNumber}] {msg}{Environment.NewLine}");
        }

        private void StartOrStopBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(m_selectedDevices))
            {
                MessageBox.Show("please connect device firstly!!");
                return;
            }

            if (m_isLogcatStarted)
            {
                StopLogcatProcess();
                m_isLogcatStarted = false;
                StartOrStopBtn.Text = "Start";
                FilterTextBox.Enabled = true;
                AddMessage(Color.Black, "stop logcat");
            }
            else
            {
                StopLogcatProcess();

                m_logcatProcess = new Process();

                string arguments = "";
                if (string.IsNullOrEmpty(m_selectedDevices) == false)
                    arguments += $"-s { m_selectedDevices}";

                arguments += " logcat";
                
                if (string.IsNullOrEmpty(FilterTextBox.Text) == false)
                    arguments += $" \"{FilterTextBox.Text}\"";

                ProcessStartInfo startInfo = new ProcessStartInfo()
                {
                    FileName = "adb",
                    Arguments = arguments,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    StandardOutputEncoding = UTF8Encoding.UTF8,
                    StandardErrorEncoding = UTF8Encoding.UTF8
                };

                m_logcatProcess.EnableRaisingEvents = true;
                m_logcatProcess.ErrorDataReceived += new DataReceivedEventHandler(OnLogcatErrorDataReceived);
                m_logcatProcess.OutputDataReceived += new DataReceivedEventHandler(OnLogcatOutputDataReceived);
                m_logcatProcess.StartInfo = startInfo;

                m_logcatProcess.Start();

                m_logcatProcess.BeginErrorReadLine();
                m_logcatProcess.BeginOutputReadLine();

                m_isLogcatStarted = true;
                StartOrStopBtn.Text = "Stop";
                FilterTextBox.Enabled = false;
                AddMessage(Color.Black, $"Start logcat {arguments}");
            }
        }

        private void OnLogcatOutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (String.IsNullOrEmpty(e.Data))
                return;

            if (this.InvokeRequired)
                this.Invoke(new Action<object, DataReceivedEventArgs>(OnLogcatOutputDataReceived), sender, e);
            else
            {

                string str = e.Data;
                string color = "0x000000";
                if (str.IndexOf(" V ") != -1) { color = "0xBBBBBB"; }
                else if (str.Contains(" D ")) { color = "0x0070BB"; }
                else if (str.Contains(" I ")) { color = "0x48BB31"; }
                else if (str.Contains(" W ")) { color = "0xBBBB23"; }
                else if (str.Contains(" E ")) { color = "0xFF0006"; }
                else if (str.Contains(" A ")) { color = "0x8F0005"; }

                AddMessage(ColorTranslator.FromHtml(color), str);
            }
        }

        private void OnLogcatErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (string.IsNullOrEmpty(e.Data))
                return;

            if (this.InvokeRequired)
                this.Invoke(new Action<object, DataReceivedEventArgs>(OnLogcatErrorDataReceived), sender, e);
            else
            {
                AddMessage(Color.Red, e.Data);
            }
        }

        private void OnFormClosedAction(object sender, FormClosedEventArgs e)
        {
            DevicesWatcher.DevicesChanged -= DevicesWatcher_DevicesChanged;
            StopLogcatProcess();
        }

        private void OnFormShown(object sender, EventArgs e)
        {
            m_selectedDevices = HelperClass.SelectedDevice;
            DevicesComboBox.ComboBox.DataSource = DevicesWatcher.Devices;
            if (string.IsNullOrEmpty(HelperClass.SelectedDevice) == false)
            {
                int index = DevicesWatcher.Devices.IndexOf(HelperClass.SelectedDevice);
                DevicesComboBox.SelectedIndex = index;
            }
        }

        private void OnDevicesIndexChanged(object sender, EventArgs e)
        {
            m_selectedDevices = DevicesComboBox.SelectedItem.ToString();
        }

        private void StopLogcatProcess()
        {
            if (m_logcatProcess != null)
            {
                if (m_logcatProcess.HasExited == false)
                    m_logcatProcess.Kill();
                m_logcatProcess = null;
            }
        }

        private void xxxSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (m_isLogcatStarted)
                return;

            FilterTextBox.Text = "xxx *:S";
        }

        private void regexxxxxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (m_isLogcatStarted)
                return;

            FilterTextBox.Text = "--regex=xxx";
        }

        private void uidxxxxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (m_isLogcatStarted)
                return;

            FilterTextBox.Text = "--uid=xxx";
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            m_lineNumber = 0;
            logviewBox.Clear();
        }
    }
}
