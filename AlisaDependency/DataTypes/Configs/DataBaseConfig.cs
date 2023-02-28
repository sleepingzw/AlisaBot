using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlisaDependency.DataTypes.Configs
{
    public class DataBaseConfig
    {
        public string serverAddress = "";
        public string serverPort = "";
        public string userName = "";
        public string password = "";
        public string dataBaseName = "";
        public string OutConfig()
        {
            return $"server={serverAddress};port={serverPort};user={userName};password={password};database={dataBaseName}";
        }
    }
}
