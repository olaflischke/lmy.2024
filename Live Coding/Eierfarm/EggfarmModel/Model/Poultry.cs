using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace EggfarmModel.Model
{
    public abstract class Poultry : IEggProducer, INotifyPropertyChanged
    {
        private string name;
        private double weight;

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        public Poultry(string name)
        {
            this.Name = name;
            this.Id = Guid.NewGuid();
            this.Eggs = new ObservableCollection<Egg>();
        }

        public Guid Id { get; init; }
        public string Name
        {
            get => name;

            set
            {
                name = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Egg> Eggs { get; set; }

        public double Weight
        {
            get => weight;
            set
            {
                weight = value;
                OnPropertyChanged();
            }
        }


        public abstract void LayEgg();
        public abstract void Eat();
    }
}