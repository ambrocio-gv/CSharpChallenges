using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextFileChallenge.DataAccess
{
    public static class TextConnectorExtension
    {
        public static IDataConnection Connection { get; private set; }
        public static string FullFilePath(this string fileName)
        {
            return $"{ ConfigurationManager.AppSettings["filePath"] }\\{ fileName }";
        }

        public static List<string> LoadFile(this string file)
        {
            if (!File.Exists(file))
            {
                return new List<string>();
            }

            return File.ReadAllLines(file).Skip(1).ToList();
        }

        public static List<UserModel> ConvertToUserModels(this List<string> lines)
        {
            List<UserModel> output = new List<UserModel>();

            foreach (string line in lines)
            {
                

                string[] cols = line.Split(',');

                


                UserModel u = new UserModel();

                u.FirstName = cols[0];
                u.LastName = cols[1];
                u.Age = int.Parse(cols[2]);

                bool boolAlive = true;
                if(cols[3] == "1")
                {
                    boolAlive = true;
                } 
                else if (cols[3] == "0")
                {
                    boolAlive = false;
                }
                u.IsAlive = boolAlive;
                output.Add(u);

            }

            return output;

        }


    }
}
