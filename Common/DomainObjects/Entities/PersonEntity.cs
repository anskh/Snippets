namespace Snippets.Common.DomainObjects.Entities
{
    using System.Collections.Generic;

    public class PersonEntity
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Location Location { get; set; }

        //public ICollection<MovieEntity> Movies { get; set; }
    }
}
