namespace Assignment_1__Community_Library_System_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Test Search
            Console.WriteLine("Search: Test case 1");
            MemberCollection searchCollection1 = new MemberCollection(10);
            searchCollection1.Add(new Member("Willow", "Smith", "0123456789", "1234"));
            bool result1 = searchCollection1.Search("Smith", "Willow");
            Console.WriteLine("Search Result for 1 member in collection: " + result1);

            Console.WriteLine("Search: Test case 3");
            MemberCollection searchCollection3 = new MemberCollection(10);
            searchCollection3.Add(new Member("J", "Smith", "0123456789", "1234"));
            searchCollection3.Add(new Member("J", "Bieber", "0123456789", "1234"));
            searchCollection3.Add(new Member("A", "Winehouse", "0123456789", "1234"));
            searchCollection3.Add(new Member("D", "Fike", "0123456789", "1234"));
            searchCollection3.Add(new Member("F", "Ocean", "0123456789", "1234"));
            Console.WriteLine(searchCollection3.ToString());
            bool result3 = searchCollection3.Search("Smith", "J");
            Console.WriteLine("Search Result for 1 member in collection: " + result3);


            //Test Delete
            Console.WriteLine("Delete: Test case");
            MemberCollection deleteCollection = new MemberCollection(6);
            deleteCollection.Add(new Member("J", "Timberlake"));
            deleteCollection.Add(new Member("M", "Jackson"));
            deleteCollection.Add(new Member("B", "Mars"));
            deleteCollection.Delete("Jackson", "M");
            Console.WriteLine(deleteCollection.ToString());
        }
    }
}
