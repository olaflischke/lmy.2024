using EggfarmModel.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EierfarmMvvmUi
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private Poultry? selectedAnimal;

        public MainWindowViewModel()
        {
            NewDuckCommand = new RelayCommand(p => true, a => NewDuck());
            NewChickenCommand = new RelayCommand(p => true, a => NewChicken());

            FeedCommand = new RelayCommand(p => SelectedAnimal != null, a => FeedAnimal());
            LayEggCommand = new RelayCommand(p => SelectedAnimal != null, a => LayEgg());
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void LayEgg()
        {
            SelectedAnimal?.LayEgg();
        }

        private void FeedAnimal()
        {
            SelectedAnimal?.Eat();
        }

        private void NewDuck()
        {
            Duck duck = new Duck();
            this.Animals.Add(duck);
            this.SelectedAnimal = duck;
        }

        private void NewChicken()
        {
            Chicken chicken = new Chicken();
            this.Animals.Add(chicken);
            this.SelectedAnimal = chicken;
        }

        public ObservableCollection<Poultry> Animals { get; set; } = new();
        public Poultry? SelectedAnimal
        {
            get => selectedAnimal;
            set
            {
                selectedAnimal = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedAnimal)));
            }
        }
        public RelayCommand NewDuckCommand { get; init; }
        public RelayCommand NewChickenCommand { get; init; }
        public RelayCommand FeedCommand { get; init; }
        public RelayCommand LayEggCommand { get; init; }



    }
}
