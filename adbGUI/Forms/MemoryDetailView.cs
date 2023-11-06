using adbGUI.Methods;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using LiveCharts;
using LiveCharts.Wpf;
using LiveCharts.WinForms;
using LiveCharts.Configurations;

namespace adbGUI.Forms
{
    public partial class MemoryDetailView : Form
    {
        private const int MAX_COUNT = 300;

        private string m_selectedDevices;
        private string m_selectedApp;
        private bool m_isStartCaptureMemory = false;
        private List<string> m_packages;
        private Thread m_thread;
        private bool m_stopCaptureThread = false;

        private struct MemoryBrief
        {
            public float Total;
            public float Native;
            public float EGL;
            public float GFX;
            public float GL;
            public float Unknown;
            public int Seconds;
        }

        private class MemoryModel
        {
            public float Memory { get; set; }
            public int Seconds { get; set; }
        }

        private ChartValues<MemoryModel> m_totalMemoryValues { get; set; }
        private ChartValues<MemoryModel> m_nativeHeapMemoryValues { get; set; }
        private ChartValues<MemoryModel> m_EGLMemoryValues { get; set; }
        private ChartValues<MemoryModel> m_gfxMemoryValues { get; set; }
        private ChartValues<MemoryModel> m_glMemoryValues { get; set; }
        private ChartValues<MemoryModel> m_unknownMemoryValues { get; set; }

        public MemoryDetailView()
        {
            InitializeComponent();

            m_totalMemoryValues = new ChartValues<MemoryModel>();
            m_nativeHeapMemoryValues = new ChartValues<MemoryModel>();
            m_EGLMemoryValues = new ChartValues<MemoryModel>();
            m_gfxMemoryValues = new ChartValues<MemoryModel>();
            m_glMemoryValues = new ChartValues<MemoryModel>();
            m_unknownMemoryValues = new ChartValues<MemoryModel>();

            var mapper = Mappers.Xy<MemoryModel>()
                .X(model => model.Seconds)
                .Y(model => model.Memory);
            Charting.For<MemoryModel>(mapper);

            MemoryChart.DisableAnimations = true;
            MemoryChart.LegendLocation = LegendLocation.Bottom;
            MemoryChart.AxisX.Add(new Axis()
            {
                Title = "Time",
                DisableAnimations = true
            });
            MemoryChart.AxisY.Add(new Axis()
            {
                Title = "Memory(MB)",
                DisableAnimations = true,
            });

            MemoryChart.Series = new SeriesCollection
            {
                new LineSeries()
                {
                    Title = "Total",
                    Values = m_totalMemoryValues,
                    PointGeometrySize = 5
                },
                new LineSeries()
                {
                    Title = "Native",
                    Values = m_nativeHeapMemoryValues,
                    PointGeometry = null
                },
                new LineSeries()
                {
                    Title = "Unknown",
                    Values = m_unknownMemoryValues,
                    PointGeometry = null
                },
                new LineSeries()
                {
                    Title = "EGL",
                    Values = m_EGLMemoryValues,
                    PointGeometry = null
                },
                new LineSeries()
                {
                    Title = "GFX",
                    Values = m_gfxMemoryValues,
                    PointGeometry = null
                },
                new LineSeries()
                {
                    Title = "GL",
                    Values = m_glMemoryValues,
                    PointGeometry = null
                },
            };
        }

        private void StareOrStopBtn_Click(object sender, EventArgs e)
        {
            if (m_isStartCaptureMemory)
            {
                StopCaptureMemory();

                SetStartState();
            }
            else
            {
                if (string.IsNullOrEmpty(m_selectedApp))
                {
                    MessageBox.Show("please choose running process");
                    return;
                }

                StartCaptureMemory();

                SetStopState();
            }
        }

        private void SetStartState()
        {
            StareOrStopBtn.Text = "Start";
            m_isStartCaptureMemory = false;
            SetComponentsActive(true);
        }

        private void SetStopState()
        {
            StareOrStopBtn.Text = "Stop";
            m_isStartCaptureMemory = true;
            SetComponentsActive(false);
        }

        private void StartCaptureMemory()
        {
            if (m_isStartCaptureMemory)
                return;

            m_stopCaptureThread = false;
            m_thread = new Thread(new ThreadStart(OnCaptureMemoryFunc));
            m_thread.Start();
            Console.WriteLine("start capture thread");
        }

        private void OnCaptureMemoryFunc()
        {
            int seconds = 0;
            while (true)
            {
                if (m_stopCaptureThread)
                    break;

                string arguments = "";
                if (string.IsNullOrEmpty(m_selectedDevices) == false)
                    arguments = $"-s {m_selectedDevices}";
                arguments += $" shell dumpsys meminfo {m_selectedApp}";
                var result = CLI.GetOutput("adb", arguments);

                var lines = result.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                if (lines.Length <= 5)
                {
                    ParseMemoryError();
                    break;
                }

                ParseMemory(seconds, lines);

                Thread.Sleep(1000);

                seconds++;
            }
        }

        private void ParseMemoryError()
        {
            this.Invoke((MethodInvoker)(() =>
            {
                SetStartState();
                MessageBox.Show($"{m_selectedApp} is not running");
            }));
        }

        private float GetValueFromString(string line, char token, int index)
        {
            var array = line.Split(new char[] { token }, StringSplitOptions.RemoveEmptyEntries);
            if (array.Length > index)
            {
                if (float.TryParse(array[index], out var result))
                    return result;
            }

            return 0;
        }

        private void ParseMemory(int seconds, string[] lines)
        {
            try
            {
                MemoryBrief brief = new MemoryBrief();
                brief.Seconds = seconds;
                foreach (var line in lines)
                {
                    if (line.IndexOf("Native Heap") >= 0)
                    {
                        var pssNativeHeap = GetValueFromString(line, ' ', 2);
                        brief.Native = pssNativeHeap / 1024.0f;//kb to mb
                    }
                    else if (line.IndexOf("EGL mtrack") >= 0)
                    {
                        var pssEGL = GetValueFromString(line, ' ', 2);
                        brief.EGL = pssEGL / 1024.0f;//kb to mb
                    }
                    else if (line.IndexOf("Gfx dev") >= 0)
                    {
                        var pssGfx = GetValueFromString(line, ' ', 2);
                        brief.GFX = pssGfx / 1024.0f;//kb to mb
                    }
                    else if (line.IndexOf("GL mtrack") >= 0)
                    {
                        var pssGL = GetValueFromString(line, ' ', 2);
                        brief.GL = pssGL / 1024.0f;//kb to mb
                    }
                    else if (line.IndexOf("Unknown") >= 0)
                    {
                        var pssUnknown = GetValueFromString(line, ' ', 1);
                        brief.Unknown = pssUnknown / 1024.0f;//kb to mb
                    }
                    else if (line.IndexOf("TOTAL") >= 0)
                    {
                        var pssTotal = GetValueFromString(line, ' ', 1);
                        //var privateDirty = GetValueFromString(line, ' ', 2);
                        //var privateClean = GetValueFromString(line, ' ', 3);
                        brief.Total = pssTotal / 1024.0f;//kb to mb

                        break;
                    }
                }
                this.Invoke((MethodInvoker)(() =>
                {
                    AddMemoryData(brief);
                }));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"parse failed : {ex}");
            }
        }

        private void AddMemoryData(MemoryBrief brief)
        {
            ChangeMemoryValue(m_totalMemoryValues, brief.Total, brief.Seconds);
            ChangeMemoryValue(m_unknownMemoryValues, brief.Unknown, brief.Seconds);
            ChangeMemoryValue(m_EGLMemoryValues, brief.EGL, brief.Seconds);
            ChangeMemoryValue(m_glMemoryValues, brief.GL, brief.Seconds);
            ChangeMemoryValue(m_nativeHeapMemoryValues, brief.Native, brief.Seconds);
            ChangeMemoryValue(m_gfxMemoryValues, brief.GFX, brief.Seconds);
        }

        private void ChangeMemoryValue(ChartValues<MemoryModel> values, float memory, int seconds)
        {
            values.Add(new MemoryModel() { Memory = memory, Seconds = seconds });
            if (values.Count > MAX_COUNT)
                values.RemoveAt(0);
        }

        private void StopCaptureMemory()
        {
            if (m_isStartCaptureMemory == false)
                return;

            m_stopCaptureThread = true;
            if (m_thread != null && m_thread.IsAlive && m_thread.Join(1000) == false)
                m_thread.Abort();
            m_thread = null;
        }

        private void SetComponentsActive(bool active)
        {
            DevicesComboBox.Enabled = active;
            AppComboBox.Enabled = active;
            RefreshBtn.Enabled = active;
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            m_totalMemoryValues.Clear();
            m_unknownMemoryValues.Clear();
            m_EGLMemoryValues.Clear();
            m_glMemoryValues.Clear();
            m_nativeHeapMemoryValues.Clear();
            m_gfxMemoryValues.Clear();
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

        private void OnFormClosedAction(object sender, FormClosedEventArgs e)
        {
            DevicesWatcher.DevicesChanged -= DevicesWatcher_DevicesChanged;
            StopCaptureMemory();
        }

        private void OnFormShownAction(object sender, EventArgs e)
        {
            m_selectedDevices = HelperClass.SelectedDevice;
            DevicesComboBox.ComboBox.DataSource = DevicesWatcher.Devices;
            if (string.IsNullOrEmpty(HelperClass.SelectedDevice) == false)
            {
                int index = DevicesWatcher.Devices.IndexOf(HelperClass.SelectedDevice);
                DevicesComboBox.SelectedIndex = index;
            }

            GetApplications();
        }

        private void RefreshBtn_Click(object sender, EventArgs e)
        {
            if (m_isStartCaptureMemory)
                return;

            GetApplications();
        }

        private void GetApplications()
        {
            var oldSelectedPackage = m_selectedApp;
            m_packages = m_packages ?? new List<string>();
            m_packages.Clear();

            string arguments = "";
            if (string.IsNullOrEmpty(m_selectedDevices) == false)
                arguments = $"-s {m_selectedDevices}";
            arguments += " shell pm list packages -3";

            var packages = CLI.GetOutput("adb", arguments);
            if (string.IsNullOrEmpty(packages))
                return;

            using (var reader = new StringReader(packages))
            {
                var line = reader.ReadLine();
                while (string.IsNullOrEmpty(line) == false)
                {
                    var pkg = line.Replace("package:", "");
                    m_packages.Add(pkg);

                    line = reader.ReadLine();
                }
            }

            AppComboBox.ComboBox.DataSource = m_packages;
            int index = m_packages.IndexOf(oldSelectedPackage);
            if (index >= 0)
                AppComboBox.SelectedIndex = index;
        }

        private void OnDevicesSelectedChanged(object sender, EventArgs e)
        {
            m_selectedDevices = DevicesComboBox.SelectedItem.ToString();
        }

        private void OnAppSelectedChanged(object sender, EventArgs e)
        {
            if (AppComboBox.SelectedItem != null)
                m_selectedApp = AppComboBox.SelectedItem.ToString();
        }
    }
}
