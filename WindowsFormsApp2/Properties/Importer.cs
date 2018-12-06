using System.Collections.Generic;

namespace Importer{
    public abstract class Importer
    {
       public abstract List<Point> queryData(string querry);
    }
}
