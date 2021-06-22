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
        private static int numFirstNameCol = 0;
        private static int numLastNameCol = 0;
        private static int numAgeCol = 0;
        private static int numisAliveCol = 0;
        private static string firstLine = "";

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

            return File.ReadAllLines(file).ToList();
        }

        public static List<UserModel> ConvertToUserModels(this List<string> lines)
        {
            List<UserModel> output = new List<UserModel>();
            bool firstLineSort = true;

            foreach (string line in lines)
            {                
                string[] cols = line.Split(',');

                if(firstLineSort == true)
                {
                    firstLine = line;

                    for (int i = 0; i <= cols.Length-1; i++)
                    {
                        if(cols[i] == "FirstName")
                        {
                           numFirstNameCol = i;
                        }
                        else if(cols[i] == "LastName")
                        {
                            numLastNameCol = i;
                        }
                        else if(cols[i] == "Age")
                        {
                            numAgeCol = i;
                        }
                        else if(cols[i] == "IsAlive")
                        {
                            numisAliveCol = i;
                        }
                    }
                }
                
                if(firstLineSort == false)
                {
                    UserModel u = new UserModel();

                    u.FirstName = cols[numFirstNameCol];
                    u.LastName = cols[numLastNameCol];
                    u.Age = int.Parse(cols[numAgeCol]);

                    bool boolAlive = true;
                    if (cols[numisAliveCol] == "1")
                    {
                        boolAlive = true;
                    }
                    else if (cols[numisAliveCol] == "0")
                    {
                        boolAlive = false;
                    }
                    u.IsAlive = boolAlive;
                    output.Add(u);
                }

                firstLineSort = false;
            }
            return output;
        }

        public static void SaveToUserFile(this List<UserModel> models, string fileName)
        {
            List<string> lines = new List<string>();            


            lines.Add(firstLine);
            
            foreach(UserModel u in models)
            {
                string[] cols = new string[4];

                cols[numFirstNameCol] = u.FirstName;
                cols[numLastNameCol] = u.LastName;
                cols[numAgeCol] = Convert.ToString(u.Age);
                cols[numisAliveCol] = "";

                if (u.IsAlive == true)
                {
                    cols[numisAliveCol] = "1";
                }
                else if (u.IsAlive == false)
                {
                    cols[numisAliveCol] = "0";
                }

                string line = String.Join(",", cols);

                lines.Add(line);
            }

            File.WriteAllLines(fileName.FullFilePath(), lines);


        }




    }
}
