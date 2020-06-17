using System.Collections.Generic;

namespace MovieWeb.Domain
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<MovieTag> MovieTags { get; set; }
    }
}
