namespace Snippets.Common.DomainObjects.Models
{
    using System.Collections.ObjectModel;
    using Snippets.Common.DomainObjects.Entities;

    public class PersonModel
    {
        private string name;
        public string Name {
            get { return name; }
            set { name = value; }
        }

        private int age;
        public int Age {
            get { return age; }
            set { age = value; }
        }

        private Location location;
        public Location Location {
            get { return location; }
            set { location = value; }
        }

        //private ObservableCollection<MovieModel> movies;
        //public ObservableCollection<MovieModel> Movies {
        //    get { return movies; }
        //    set { movies = value; }
        //}
    }
}
