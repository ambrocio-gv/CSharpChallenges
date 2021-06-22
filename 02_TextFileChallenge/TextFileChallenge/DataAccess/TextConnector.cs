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
        private const string AdvancedFile = "AdvancedDataSet.csv";
        private const string SelectedFile = StandardFile;


        public List<UserModel> GetUser_All()
        {
            return SelectedFile.FullFilePath().LoadFile().ConvertToUserModels();
        }

        public UserModel CreateUser(UserModel model)
        {           
            List<UserModel> users = SelectedFile.FullFilePath().LoadFile().ConvertToUserModels();
            users.Add(model);
            return model;
        }

        public void SaveUser_All(List<UserModel> users)
        {            
            users.SaveToUserFile(SelectedFile);
        }
    }
}
