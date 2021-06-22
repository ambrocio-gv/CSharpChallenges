using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TextFileChallenge.DataAccess
{
    public interface IDataConnection
    {
        List<UserModel> GetUser_All();

        UserModel CreateUser(UserModel model);

        void SaveUser_All(List<UserModel> users);
    }
}
