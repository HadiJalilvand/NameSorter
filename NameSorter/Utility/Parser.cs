using NameSorter.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace NameSorter.Utility
{
    public class Parser
    {
        public List<Person> PersonList { get;}
        public List<Person> SortedPersonList { get; private set; }
        TextReader _textReader;
        public Parser(TextReader textReader)
        {
            _textReader = textReader;
            PersonList = new List<Person>();
            Read();
            Sort();
        }

        private  void Read()
        {
            // read the file
            try
            {
                using (_textReader)
                {
                    while (_textReader.Peek() > 0)
                    {
                        // parse it and store in list of objects
                        string line = _textReader.ReadLine();
                        PersonList.Add(CreateList(line));
                    }
                }
              
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                
            }
        }

        private Person CreateList(string line)
        {
            string[] namePoints = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Models.Person item;
            switch (namePoints.Length)
            {
                case 2:
                    item = new Person() { GivenName1 = namePoints[0], LastName = namePoints[1] };
                    return item;

                case 3:
                    item = new Person() { GivenName1 = namePoints[0], GivenName2 = namePoints[1], LastName = namePoints[2] };
                    return item;
                case 4:
                    item = new Person() { GivenName1 = namePoints[0], GivenName2 = namePoints[1], GivenName3 = namePoints[2], LastName = namePoints[3] };
                    return item;
                default:
                    item = new Person();
                    return item;
            }
        }

        private void Sort()
        {
            SortedPersonList = PersonList.OrderBy(o => o.GivenName3).
                       OrderBy(o => o.GivenName2).OrderBy(o => o.GivenName1).OrderBy(o => o.LastName).ToList();
        }
    }
}
