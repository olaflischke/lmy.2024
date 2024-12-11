using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Threading;

namespace MvvmMaschine.Model;

public class TennisballWurfmaschine : INotifyPropertyChanged
{

    #region Lokale Variablen
    private DispatcherTimer timTimer;
    #endregion

    public TennisballWurfmaschine()
    {
        timTimer = new DispatcherTimer();
        timTimer.Tick += TimTimer_Tick;
    }

    public event PropertyChangedEventHandler PropertyChanged;

    private void OnPropertyChanged([CallerMemberName] string changedProperty = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(changedProperty));
    }

    private void TimTimer_Tick(object sender, EventArgs e)
    {
        this.Stueckzahl++;
    }


    #region Eigenschaften der Maschine
    private int _intSpeed;

    /// <summary>
    /// Geschwindigkeit, mit der die Bälle geworfen werden.
    /// </summary>
    public int Geschwindigkeit
    {
        get { return _intSpeed; }
        set
        {
            if (value > 0)
            {
                _intSpeed = value;
                timTimer.Interval = TimeSpan.FromMilliseconds(1000 / this.Geschwindigkeit);
                OnPropertyChanged();
            }
        }
    }

    private int _intStueck;



    /// <summary>
    /// Anzahl der geworfenen Bälle.
    /// </summary>
    public int Stueckzahl
    {
        get { return _intStueck; }
        set
        {
            _intStueck = value;
            OnPropertyChanged();
        }
    }

    private bool _laeuft;

    public bool IstAmLaufen
    {
        get { return _laeuft; }
        set
        {
            _laeuft = value;
            OnPropertyChanged();
        }
    }

    #endregion

    #region Methoden
    public void Start()
    {
        timTimer.Interval = TimeSpan.FromMilliseconds(1000);
        timTimer.Start();
        this.Geschwindigkeit = 1;
        this.IstAmLaufen = true;
    }

    public void Stopp()
    {
        timTimer.Stop();
        this.IstAmLaufen = false;
    }
    #endregion

}
