using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Terraform.ResourceDomain;
using Terraform.WorkDomain;

namespace Terraform.WinApplication.ViewModels
{
    public class MainGameViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public MainGameViewModel()
        {
            this.Jobs = new ObservableCollection<Job>();
            this.Stockpiles = new ObservableCollection<Stockpile>();
        }

        public ObservableCollection<Job> Jobs { get; private set; }

        public ObservableCollection<Stockpile> Stockpiles { get; private set; }

        public void LoadStockpiles()
        {
            Stockpile stockpile;

            stockpile = new GlobalStockpile(Resource.Collection.Iron);
            this.Stockpiles.Add(stockpile);
            stockpile = new GlobalStockpile(Resource.Collection.Wood);
            this.Stockpiles.Add(stockpile);
            stockpile = new GlobalStockpile(Resource.Collection.Stone);
            this.Stockpiles.Add(stockpile);
        }

        public void LoadJobs()
        {
            Job job;

            job = new Job("Clear rubble at A1");
            job.AddRequirement(new ResourceQuantityRequirement(Resource.Collection.Wood, 5));
            job.AddRequirement(new ResourceQuantityRequirement(Resource.Collection.Iron, 5));
            this.Jobs.Add(job);

            job = new Job("Clear rubble at B2");
            job.AddRequirement(new ResourceQuantityRequirement(Resource.Collection.Stone, 2));
            this.Jobs.Add(job);

            job = new Job("Clear rubble at C5");
            job.AddRequirement(new ResourceQuantityRequirement(Resource.Collection.Wood, 10));
            job.AddRequirement(new ResourceQuantityRequirement(Resource.Collection.Stone, 12));
            job.AddRequirement(new ResourceQuantityRequirement(Resource.Collection.Iron, 5));
            this.Jobs.Add(job);

            job = new Job("Clear rubble at B3");
            job.AddRequirement(new ResourceQuantityRequirement(Resource.Collection.Stone, 6));
            job.AddRequirement(new ResourceQuantityRequirement(Resource.Collection.Iron, 3));
            this.Jobs.Add(job);
        }

        private void NotifyPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
