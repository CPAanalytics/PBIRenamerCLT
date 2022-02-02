using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PBIRenamer;

namespace PBIRenamerCLT
{
    class Program
    {
        static void Main(string[] args)
        {
            var _pbifile =
                new PbiFile(
                    "C:\\Users\\jchevalier\\Source\\Repos\\CPAanalytics\\PBIRenamer\\RenamerTest\\test_files\\Sales.pbix");
            _pbifile.SearchForMeasureName("MeasuresCAC.ttm_cac_ltv_margin");
        }


        public bool FolderOrFile(string location)
        {
            return true;
        }

        public void IterateFolder(string folder)
        {

        }

        public void ReplaceInFile(string file)
        {

        }
    }
}
