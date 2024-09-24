//CAB301 assessment 1 
//The implementation of MemberCollection ADT
using System;
using System.Linq;


//Invariants: Capacity >= Count; Count >=0; and members in this member collection are sorted in alphabetical order by their full name (if there are two members who have the same last name, they are sorted by their first name in alphabetical order).


class MemberCollection : IMemberCollection
{
    // Fields
    private int capacity;
    private int count;
    private Member[] members; //members are sorted in alphabetical order

    // Properties

    // get the capacity of this member collection 
    // pre-condition: nil
    // post-condition: return the capacity of this member collection and this member collection remains unchanged
    public int Capacity { get { return capacity; } }

    // get the number of members in this member collection 
    // pre-condition: nil
    // post-condition: return the number of members in this member collection and this member collection remains unchanged
    public int Number { get { return count; } }

   

    // Constructor - to create an object of member collection 
    // Pre-condition: capacity > 0
    // Post-condition: an object of this member collection class is created

    public MemberCollection(int capacity)
    {
        if (capacity > 0)
        {
            this.capacity = capacity;
            members = new Member[capacity];
            count = 0;
        }
    }

    // check if this member collection is full
    // Pre-condition: nil
    // Post-condition: return true if this member collection is full; otherwise return false. This member collection remains unchanged.
    public bool IsFull()
    {
        return Number == Capacity;
    }



    // check if this member collection is empty
    // Pre-condition: nil
    // Post-condition: return true if this member collection is empty; otherwise return false. This member collection remains unchanged.
    public bool IsEmpty()
    {
        return Number == 0;
    }

    // Add a new member to this member collection
    // Pre-condition: this member collection is not full
    // Post-condition: The given member is added to this member collection and the members remains sorted in alphabetical order by their full names, if the given member does not appear in this member collection; otherwise, the given member is not added to this member collection. 
    // No duplicate has been added into this the member collection
    public void Add(IMember member)
    {
        //Check Pre-Condition
        if (IsFull())
        {
            Console.WriteLine("This Member Collection Is Full");
            return;
        }
        ///Check Postcondition (member is unique)
        if (Search(member.LastName, member.FirstName))
        {
            Console.WriteLine("Duplicate Identity Found");
            return;
        }
        //Add new member.
        members[count] = (Member) member;
        count++;

        //Insertion Sort member array.
        for (int i = 1; i <= (count - 1); i++)
        {
            Member v = members[i];
            int j = i - 1;
            while (j >= 0 && members[j].CompareTo(v) >= 0)
            {
                members[j + 1] = members[j];
                j = j - 1;
            }
            members[j + 1] = v;
        }
    }

    // Remove a given member out of this member collection
    // Pre-condition: nil
    // Post-condition: the given member is removed from this member collection, if the given member is in this member collection and the members in this member collection remains sorted in alphabetical order by their full names; otherwise, no member is removed from this member collection and this member collection remains unchanged. 
    public void Delete(string lastname, string firstname)
    {
        Member aMember = new Member(firstname, lastname);
    
        for (int i = 0; i < Number; i++)
        {
            if (members[i].CompareTo(aMember) == 0)
            {
                for (int j = i + 1; j < Number; j++)
                {
                    members[j - 1] = members[j];
                }
                members[Number - 1] = null;
                count--;
                break;
            }
        }

    }

    // Search a given member by last name and first name in this member collection 
    // Pre-condition: nil
    // Post-condition: return true if the given member is in this member collection; return false otherwise. This member collection remains unchanged.
    public bool Search(string lastname, string firstname)
    {
        Member SearchKey = new Member(firstname, lastname);
        int left = 0;
        int right = Number - 1;
        while (left <= right)
        {
            int middle = (left + right) / 2;

            if (members[middle].CompareTo(SearchKey) == 0 )
            {
                return true;
            } 
            else if (members[middle].CompareTo(SearchKey) == -1)
            {
                left = middle + 1;
            }
            else
            {
                right = middle - 1;
            }
        }
        return false;
    }

    // Remove all the members in this member collection 
    // Pre-condition: nil
    // Post-condition: Capacity remains unchanged; Number = 0; this member collection is empty.
    public void Clear()
    {
        members = new Member[capacity];
        count = 0;
    }

    // Return a string containing the information about all the members in this member collection.
    // The information includes last name, first name and contact number in this order
    // Pre-condition: nil
    // Post-condition: a string containing the information about all the members in this member collection is returned, the order of the members in the returned string is the same with that in this member collection and this collection remains unchanged. 
    //                  The information about a member includes the last name, first name and contact phone number of the member, which are separated by a comma (no whitespace before or after the comma). The members are separated by a semicolon (no white space before or after the semicolon).
    public override string ToString()
    {
        string result = ""; 

        for (int i = 0; i < count; i++)
        {
            result += members[i].ToString();
        }
        return result;
    }
}

