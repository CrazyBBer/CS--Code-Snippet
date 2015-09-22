using System;
using System.ComponentModel;
using System.Windows.Threading;

namespace CircularProgressBar
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : INotifyPropertyChanged
    {
        private readonly DispatcherTimer _timer;
        private int _currentRate;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;

            _timer = new DispatcherTimer {Interval = new TimeSpan(0, 0, 0, 0, 50)};
            _timer.Tick += timer_Tick;
            _timer.Start();
        }

        #region Properties

        private int _successRate = 100;

        public int SuccessRate
        {
            get
            {
                return _successRate;
            }
            set
            {
                if (value == _successRate) return;
                _successRate = value;
                OnPropertyChanged("SuccessRate");
            }
        }

        #endregion Properties

        private void timer_Tick(object sender, EventArgs e)
        {
            _currentRate++;
            SuccessRate = _currentRate * 100 / 100;
            if (SuccessRate == 100)
            {
                _timer.Stop();
            }
        }

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion INotifyPropertyChanged
    }
}