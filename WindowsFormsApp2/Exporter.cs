using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseCommunicator;

namespace Exporter
{
    /// <summary>Class <c>Exporter</c> export files.
    /// </summary>
    public abstract class Exporter
    {
        /// <summary> This method create files from database and export them.
        /// <param name="db"> The database db contains informations which the created files need to have. </param>
        /// <returns> Returns true if the new files are created. </returns>
        /// </summary>
        public abstract bool ExportFiles(DatabaseCommunicator.DatabaseCommunicator db);
    }
}
