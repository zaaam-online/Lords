using System;
namespace Lords.City
{
    public class Labor
    {
        private LaborCategory _serfs;
        private LaborCategory _shepherds;
        private LaborCategory _herders;
        private LaborCategory _farmers;

        public Labor()
        { }

        public LaborCategory Serfs { get => _serfs; set => _serfs = value; }
        public LaborCategory Shepherds { get => _shepherds; set => _shepherds = value; }
        public LaborCategory Herders { get => _herders; set => _herders = value; }
        public LaborCategory Farmers { get => _farmers; set => _farmers = value; }
    }

    public class LaborCategory
    {
        private string _name = string.Empty;
        private int _numberOfWorkers = 0;
        private int _numberOfNeededWorkers = 0;

        public string Name { get => _name; set => _name = value; }
        public int Workers { get => _numberOfWorkers; set => _numberOfWorkers = value; }
        public int NeededWorkers { get => _numberOfNeededWorkers; set => _numberOfNeededWorkers = value; }
    }
}
