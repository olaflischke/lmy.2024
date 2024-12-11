using MvvmMaschine.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmMaschine.ViewModel
{
    public class MainWindowViewModel
    {
        public MainWindowViewModel()
        {
            this.Maschine = new TennisballWurfmaschine();

            this.StartCommand = new RelayCommand(p => CanStarten(), a => Starten());
            this.StoppCommand = new RelayCommand(p => CanStoppen(), a => Stoppen());
        }

        private bool CanStarten()
        {
            return !this.Maschine.IstAmLaufen;
        }

        private void Starten()
        {
            this.Maschine.Start();
        }

        private bool CanStoppen()
        {
            return this.Maschine.IstAmLaufen;
        }

        private void Stoppen()
        {
            this.Maschine.Stopp();
        }

        public TennisballWurfmaschine Maschine { get; set; }
        public RelayCommand StartCommand { get; set; }
        public RelayCommand StoppCommand { get; set; }
    }
}
