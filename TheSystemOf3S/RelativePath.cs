using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheSystemOf3S
{
    class RelativePath
    {
        String RootPath;
        public RelativePath()
        {
            RootPath = Application.StartupPath;
            RootPath = RootPath.Substring(0, RootPath.Length - 9);
        }
        public String TemporaryPath
        {
            get
            {
                return RootPath + @"Temporary\";
            }
        }

        public String FilesIcoFolderPath
        {
            get
            {
                return RootPath + @"Resources\Ico\Files\";
            }
        }

        public String NetWorkAnalysisFolderPath
        {
            get
            {
                return RootPath + @"Resources\Ico\NetWorkAnalysis\";
            }
        }
        public string GeometrictransformationFolderPath
        {
            get
            {
                return RootPath + @"Resources\Ico\Geometrictransformation\";
            }
        }
        public String MapSearchFolderPath
        {
            get
            {
                return RootPath + @"Resources\Ico\MapSearch\";
            }
        }
        public String CoordinateFolderpath
        {
            get
            {
                return RootPath + @"Resources\Ico\Coordinate\";
            }
        }
        public String SpatialAnalysisFolderPath
        {
            get
            {
                return RootPath + @"Resources\Ico\SpatialAnalysis\";
            }
        }
        public String PageLayoutFolderPath
        {
            get
            {
                return RootPath + @"Resources\Ico\PageLayout\";
            }
        }
        public String MdbFolderPath
        {
            get
            {
                return RootPath + @"Resources\mdb\";
            }
        }

        public String MapNavigationFolderPath
        {
            get
            {
                return RootPath + @"Resources\Ico\MapNavigation\";
            }
        }

        public String TempFolderPath
        {
            get
            {
                return RootPath + @"temp\";
            }
        }

        public String MxdDocPath
        {
            get
            {
                return RootPath + @"Resources\data\地大.mxd";
            }
        }

        public String PageLayoutNavigationFolderPath
        {
            get
            {
                return RootPath + @"Resources\Ico\PageLayoutNavigation\";
            }
        }

        public String HelpFolderPath
        {
            get
            {
                return RootPath + @"Resources\Help\";
            }
        }
    }
}

