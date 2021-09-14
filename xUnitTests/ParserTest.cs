using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using NameSorter;
using FluentAssertions;
using System.Linq;

namespace xUnitTests
{
    
    public class ParserTest
    {
        string p = "Janet Parsons";

        IList<string> personList = new List<string> { "Janet Parsons", "Vaughn Lewis", "Adonis Julius Archer", "Shelby Nathan Yoder", "Marin Alvarez", "London Lindsey",
            "Beau Tristan Bentley", "Leo Gardner", "Hunter Uriah Mathew Clarke", "Mikayla Lopez", "Frankie Conner Ritter" };


        [Fact]
        public void TestRead()
        {
            NameSorter.Models.Person person1 = new NameSorter.Models.Person()
            { GivenName1 = "Hunter", GivenName2 = "Uriah", GivenName3 = "Mathew", LastName = "Clarke" };
            NameSorter.Utility.FileParser fileParser = new NameSorter.Utility.FileParser("TestCase\\person.txt");
            List<NameSorter.Models.Person> person = fileParser.SortedPersonList;
            person.Contains(person1);

        }

        [Fact]
        public void ReadwithtextTest()
        {
            NameSorter.Utility.FileParser fileParser = new NameSorter.Utility.FileParser("TestCase\\unsorted-names-list.txt");
            List<NameSorter.Models.Person> person = fileParser.PersonList;
            int count = 0;
            bool result = false;
            for (int i = 0; i < person.Count; i++)
            {
                if (person[i].ToStringBuilder().Equals(personList[i]))
                {
                    count++;
                }
            }
            if (count == person.Count)
            {
                result = true;
            }
            else
            {
                result = false;
            }
            Assert.True(result);
        }

        [Fact]
        public void SortTest()
        {
            NameSorter.Utility.FileParser fileParser = new NameSorter.Utility.FileParser("TestCase\\person.txt");
            NameSorter.Utility.FileParser sortedFile = new NameSorter.Utility.FileParser("TestCase\\sorted-names-list.txt");
            fileParser.SortedPersonList.Should().BeEquivalentTo(sortedFile.SortedPersonList);
           
        }
    }
}
