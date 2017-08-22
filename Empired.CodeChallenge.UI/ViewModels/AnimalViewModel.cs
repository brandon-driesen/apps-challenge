using System.Collections.Generic;

namespace Empired.CodeChallenge.UI.ViewModels
{
    public class AnimalViewModel
    {
        public ICollection<string> Names { get; set; }
        public ICollection<string> Uniqueness { get; set; }
        public ICollection<string> Behaviours { get; set; }
        public ICollection<string> Colours { get; set; }
    }
}
