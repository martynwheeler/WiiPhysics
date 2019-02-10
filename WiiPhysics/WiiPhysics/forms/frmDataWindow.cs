using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using WiimoteLib;
using ZedGraph;

namespace WiiPhysics
{
    public partial class frmDataWindow : Form
    {
        #region Form Variables
        private double _barLength;
        private float[,] _dataToSave;
        private double _endTime;
        private bool[] _graphsToShow;
        private static int _maxChannel = clsGlobal.maxChannel;
        private int _numDataPoints;
        private double _radPerPix;
        private string _scanMode;
        private Wiimote mWiimote;

        private delegate void UpdateExtensionChangedDelegate(WiimoteExtensionChangedEventArgs args);
        private delegate void UpdateWiimoteStateDelegate(WiimoteChangedEventArgs args);
        #endregion

        #region Constructor
        public frmDataWindow()
        {
            this.InitializeComponent();
            this._dataToSave = new float[_maxChannel, 1000000];
            this.list = new RollingPointPairList[_maxChannel - 1];
            this.curve = new LineItem[_maxChannel - 1];
            this.curveColor = new Color[_maxChannel - 1];
            this._graphsToShow = new bool[_maxChannel - 1];
            this.sampleTimer = new Stopwatch();
            // Need to redefine this
            this._radPerPix = (0.080403645833333343 * Math.Acos(-1.0)) / 360.0;
            for (int i = 0; i < (_maxChannel - 1); i++)
            {
                this._graphsToShow[i] = false;
            }
        }

        // Derived Constructor
        public frmDataWindow(Wiimote wm) : this()
        {
            this.mWiimote = wm;
        }
        #endregion

        #region Form Events
        private void frmDataWindow_Load(object sender, EventArgs e)
        {
            this.zg1.GraphPane.Title.Text = "Data Acquisition from WiiMote";
            this.zg1.GraphPane.XAxis.Title.Text = "Time / s";
            this.zg1.GraphPane.YAxis.Title.IsVisible = false;
        }

        private void frmDataWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.sampleTimer.IsRunning && (clsGlobal.g_objfrmMDIMain.MdiChildren.Length == 1))
            {
                clsGlobal.g_objfrmMDIMain.stopLogging();
            }
            this.mWiimote.WiimoteChanged -= new EventHandler<WiimoteChangedEventArgs>(clsGlobal.g_objfrmMDIMain.wm_WiimoteChanged);
            this.mWiimote.WiimoteExtensionChanged -= new EventHandler<WiimoteExtensionChangedEventArgs>(clsGlobal.g_objfrmMDIMain.wm_WiimoteExtensionChanged);
            this.mWiimote.Disconnect();
        }
        #endregion

        #region Private Methods
        private void CreateChart()
        {
            GraphPane graphPane = this.zg1.GraphPane;
            graphPane.CurveList.Clear();
            this.zg1.Invalidate();
            graphPane.XAxis.Scale.Min = 0.0;
            graphPane.XAxis.Scale.Max = 30.0;
            graphPane.XAxis.Scale.MinorStep = 1.0;
            graphPane.XAxis.Scale.MajorStep = 5.0;
            for (int i = 0; i < (_maxChannel - 1); i++)
            {
                this.list[i] = new RollingPointPairList(3000);
            }
            this.curveColor[0] = Color.Red;
            this.curveColor[1] = Color.Blue;
            this.curveColor[2] = Color.Green;
            this.curveColor[3] = Color.Purple;
            this.curveColor[4] = Color.Orange;
            for (int j = 0; j < (_maxChannel - 1); j++)
            {
                this.curve[j] = graphPane.AddCurve("", this.list[j], this.curveColor[j], SymbolType.None);
                this.curve[j].IsVisible = this._graphsToShow[j];
            }
        }

        private void UpdateWiimoteChanged(WiimoteChangedEventArgs args)
        {
            WiimoteState wiimoteState = args.WiimoteState;
            if (!this.sampleTimer.IsRunning)
            {
                if (wiimoteState.ButtonState.A)
                {
                    clsGlobal.g_objfrmMDIMain.startLogging();
                }
                else if (wiimoteState.ButtonState.Two)
                {
                    clsGlobal.g_objfrmMDIMain.stopLogging();
                }
            }
            else if (this.zg1.GraphPane.CurveList.Count > 0)
            {
                double r;
                float x1, x2, y1, y2;
                double totalSeconds = this.sampleTimer.Elapsed.TotalSeconds;
                this._dataToSave[0, this._numDataPoints] = Convert.ToSingle(totalSeconds);
                switch (this._scanMode)
                {
                    case "rbAccelerometer":
                        this._dataToSave[1, this._numDataPoints] = wiimoteState.AccelState.Values.X;
                        this._dataToSave[2, this._numDataPoints] = wiimoteState.AccelState.Values.Y;
                        this._dataToSave[3, this._numDataPoints] = wiimoteState.AccelState.Values.Z;
                        this._dataToSave[4, this._numDataPoints] =
                            Convert.ToSingle(Math.Sqrt((Math.Pow((double)wiimoteState.AccelState.Values.X, 2.0)
                            + Math.Pow((double)wiimoteState.AccelState.Values.Y, 2.0))
                            + Math.Pow((double)wiimoteState.AccelState.Values.Z, 2.0)));
                        for (int i = 0; i < 4; i++)
                        {
                            this.list[i].Add(totalSeconds, (double)this._dataToSave[i + 1, this._numDataPoints]);
                        }
                        break;

                    case "rbMotionSensor":
                        x1 = wiimoteState.IRState.IRSensors[0].RawPosition.X;
                        y1 = wiimoteState.IRState.IRSensors[0].RawPosition.Y;
                        x2 = wiimoteState.IRState.IRSensors[1].RawPosition.X;
                        y2 = wiimoteState.IRState.IRSensors[1].RawPosition.Y;
                        r = Math.Sqrt(Math.Pow((double)(x1 - x2), 2.0) + Math.Pow((double)(y1 - y2), 2.0));
                        this._dataToSave[1, this._numDataPoints] =
                            Convert.ToSingle((double)(this._barLength / (2.0 * Math.Tan((r * this._radPerPix) / 2.0))));
                        this.list[0].Add(totalSeconds, (double)this._dataToSave[1, this._numDataPoints]);
                        break;

                    case "rbPositionSensor":
                        this._dataToSave[1, this._numDataPoints] = wiimoteState.IRState.IRSensors[0].RawPosition.X;
                        this._dataToSave[2, this._numDataPoints] = wiimoteState.IRState.IRSensors[0].RawPosition.Y;
                        this._dataToSave[3, this._numDataPoints] = wiimoteState.IRState.IRSensors[1].RawPosition.X;
                        this._dataToSave[4, this._numDataPoints] = wiimoteState.IRState.IRSensors[1].RawPosition.Y;
                        for (int i = 0; i < 4; i++)
                        {
                            this.list[i].Add(totalSeconds, (double)this._dataToSave[i + 1, this._numDataPoints]);
                        }
                        break;

                    case "rbOneDMotion":
                        x1 = wiimoteState.IRState.IRSensors[0].RawPosition.X;
                        y1 = wiimoteState.IRState.IRSensors[0].RawPosition.Y;
                        x2 = wiimoteState.IRState.IRSensors[1].RawPosition.X;
                        y2 = wiimoteState.IRState.IRSensors[1].RawPosition.Y;
                        r = Math.Sqrt(Math.Pow((double)(x1 - x2), 2.0) + Math.Pow((double)(y1 - y2), 2.0));
                        this._dataToSave[1, this._numDataPoints] =
                            Convert.ToSingle((double)(this._barLength / (2.0 * Math.Tan((r * this._radPerPix) / 2.0))));
                        this._dataToSave[2, this._numDataPoints] = wiimoteState.AccelState.Values.Y;
                        // Determine Velocity -- this needs testing
                        if (this._numDataPoints > 0)
                        {
                            this._dataToSave[3, this._numDataPoints] =
                                (this._dataToSave[1, this._numDataPoints] - this._dataToSave[1, this._numDataPoints - 1]) / (this._dataToSave[0, this._numDataPoints] - this._dataToSave[0, this._numDataPoints - 1]);
                        }
                        for (int i = 0; i < 3; i++)
                        {
                            this.list[i].Add(totalSeconds, (double)this._dataToSave[i + 1, this._numDataPoints]);
                        }
                        break;

                    case "rbCircularMotion":
                        this._dataToSave[1, this._numDataPoints] = wiimoteState.IRState.IRSensors[0].RawPosition.X / 100F;
                        this._dataToSave[2, this._numDataPoints] = wiimoteState.IRState.IRSensors[0].RawPosition.Y / 100F;
                        this._dataToSave[3, this._numDataPoints] = wiimoteState.AccelState.Values.Y;
                        for (int i = 0; i < 3; i++)
                        {
                            this.list[i].Add(totalSeconds, (double)this._dataToSave[i + 1, this._numDataPoints]);
                        }
                        break;

                    case "rbBalanceBoard":
                        this._dataToSave[1, this._numDataPoints] = wiimoteState.BalanceBoardState.WeightKg * 9.81F;
                        this._dataToSave[2, this._numDataPoints] = wiimoteState.BalanceBoardState.SensorValuesKg.TopLeft * 9.81F;
                        this._dataToSave[3, this._numDataPoints] = wiimoteState.BalanceBoardState.SensorValuesKg.TopRight * 9.81F;
                        this._dataToSave[4, this._numDataPoints] = wiimoteState.BalanceBoardState.SensorValuesKg.BottomLeft * 9.81F;
                        this._dataToSave[5, this._numDataPoints] = wiimoteState.BalanceBoardState.SensorValuesKg.BottomRight * 9.81F;
                        for (int i = 0; i < 5; i++)
                        {
                            this.list[i].Add(totalSeconds, (double)this._dataToSave[i + 1, this._numDataPoints]);
                        }
                        break;
                }

                // Keep the X scale at a rolling 30 second interval, with one
                // major step between the max X value and the end of the axis
                Scale scale = this.zg1.GraphPane.XAxis.Scale;
                if (totalSeconds > (scale.Max - scale.MinorStep))
                {
                    scale.Max = totalSeconds + scale.MinorStep;
                    scale.Min = scale.Max - 30.0;
                }
                // Make sure the Y axis is rescaled to accommodate actual data and force a redraw
                if ((this._numDataPoints % 1) == 0)
                {
                    this.zg1.AxisChange();
                    this.zg1.Invalidate();
                }
                // check if buttons have been pressed
                if (wiimoteState.ButtonState.One)
                {
                    clsGlobal.g_objfrmMDIMain.startLogging();
                }
                else if (wiimoteState.ButtonState.Two)
                {
                    clsGlobal.g_objfrmMDIMain.stopLogging();
                }
                // check if exceeded preset logging time
                if (this.sampleTimer.Elapsed.TotalSeconds > this._endTime)
                {
                    clsGlobal.g_objfrmMDIMain.stopLogging();
                }
                else
                {
                    this._numDataPoints++;
                }
            }
        }

        private void UpdateExtensionChanged(WiimoteExtensionChangedEventArgs args)
        {
            // Not needed at present
        }
        #endregion

        #region Public Events
        public void startTimer()
        {
            if (this.sampleTimer.Elapsed.TotalSeconds == 0.0)
            {
                this.CreateChart();
                this._numDataPoints = 0;
                this.sampleTimer = Stopwatch.StartNew();
            }
            else if (this.sampleTimer.IsRunning)
            {
                this.sampleTimer.Stop();
            }
            else
            {
                this.sampleTimer.Start();
            }
        }

        public void stopTimer()
        {
            this.sampleTimer.Reset();
        }

        public void UpdateExtension(WiimoteExtensionChangedEventArgs args)
        {
            base.BeginInvoke(new UpdateExtensionChangedDelegate(this.UpdateExtensionChanged), new object[] { args });
        }

        public void UpdateState(WiimoteChangedEventArgs args)
        {
            base.BeginInvoke(new UpdateWiimoteStateDelegate(this.UpdateWiimoteChanged), new object[] { args });
        }
        #endregion

        #region Public Accessor Methods
        public double barLength
        {
            get
            {
                return this._barLength;
            }
            set
            {
                this._barLength = value;
            }
        }

        public float[,] dataToSave
        {
            get
            {
                return this._dataToSave;
            }
            set
            {
                this._dataToSave = value;
            }
        }

        public double endTime
        {
            get
            {
                return this._endTime;
            }
            set
            {
                this._endTime = value;
            }
        }

        public bool[] graphsToShow
        {
            get
            {
                return this._graphsToShow;
            }
            set
            {
                this._graphsToShow = value;
            }
        }

        public int numDataPoints
        {
            get
            {
                return this._numDataPoints;
            }
            set
            {
                this._numDataPoints = value;
            }
        }

        public string scanMode
        {
            get
            {
                return this._scanMode;
            }
            set
            {
                this._scanMode = value;
            }
        }

        public Wiimote Wiimote
        {
            get
            {
                return this.mWiimote;
            }
            set
            {
                this.mWiimote = value;
            }
        }
        #endregion
    }
}