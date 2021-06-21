using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextFileChallenge.DataAccess
{
    public class TextConnector : IDataConnection
    {
        private const string StandardFile = "StandardDataSet.csv";

        


        public List<UserModel> GetUser_All()
        {
            return StandardFile.FullFilePath().LoadFile().ConvertToUserModels();
        }





    }
}
