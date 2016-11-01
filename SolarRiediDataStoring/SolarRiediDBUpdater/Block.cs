using System.Collections.Generic;

namespace Linus.SolarRiedi.SolarRiediDBUpdater
{
    public class Block
    {
        public List<List<string>> Lines { get; private set; }

        public Block()
        {
            this.Lines = new List<List<string>>();
        }

        public void Add(List<string> line)
        {
            this.Lines.Add(line);
        }
    }
}
