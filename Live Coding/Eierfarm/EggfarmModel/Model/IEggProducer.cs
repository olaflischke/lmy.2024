using System.Collections.ObjectModel;

namespace EggfarmModel.Model
{
    public interface IEggProducer
    {
        string Name { get; set; }
        ObservableCollection<Egg> Eggs { get; set; }
        double Weight { get; set; }
        void LayEgg();
    }
}