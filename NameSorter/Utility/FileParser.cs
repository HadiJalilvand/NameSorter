using System;
using System.Collections.Generic;
using System.IO;

namespace NameSorter.Utility
{
    public class FileParser : Parser
    {
        string _fileAddress;
        public FileParser(string fileAddress) : base(new StreamReader(fileAddress))
        {
            _fileAddress = fileAddress;
            SaveResult();
        }
        public void SaveResult()
        {
            try
            {

                using (StreamWriter outputFile = new StreamWriter(GetFileNameAppendVariation(_fileAddress, "sorted-names-list")))
                {
                    SortedPersonList.ForEach(f =>
                    {
                        outputFile.WriteLine(f.ToStringBuilder());
                    });
                }


            }
            catch (Exception)
            {

                throw;
            }
        }

        private static string GetFileNameAppendVariation(string fileName, string variation)
        {
            try
            {
                string finalPath = Path.GetDirectoryName(fileName);

                string newfilename = String.Concat(variation, Path.GetExtension(fileName));

                return Path.Combine(finalPath, newfilename);
            }
            catch (Exception)
            {

                throw;
            }

        }


    }
}
