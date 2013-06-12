namespace Snippets.Common.DomainObjects.Models
{
    public class MovieModel
    {
        private string name;
        public string Name {
            get { return name; }
            set { name = value; }
        }

        private int id;
        public int Id {
            get { return id; }
            set { id = value; }
        }
    }
}
