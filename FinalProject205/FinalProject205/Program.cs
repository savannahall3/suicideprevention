using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Xml;

namespace FinalProject205
{

    class Program
    {
        static void Main(string[] args)
        {
            //Created by Savanna Hall
            //have the app greet the user and ask what their depression or anxiety level is immediately
            StreamWriter fileOut = new StreamWriter("SHall.txt");
            // both StreamWriter & Reader would be 
            //able to create a log for the user to send to their provider or to keep track of their daily mood levels
            StreamReader fileIn = new StreamReader(@"C:\test\SHall.txt");
            Console.WriteLine("Hello, Savanna. ");
            

            Console.WriteLine("On a level of 1-10, what would you rate your depression or anxiety today?");
            fileOut.WriteLine("On a level of 1-10, what would you rate your depression or anxiety today?");
            int response = Convert.ToInt32(Console.ReadLine()); //take response & convert to int so the app can gage a response
            fileIn.ReadLine();

            fileOut.Close(); //closing them out 
            fileIn.Close();

            Console.WriteLine("");
            Response1(response);//using the response method to give the user an idea based on the depression level

            int response2 = response; //creating another variable 

            //spacing for the ouput
            Console.WriteLine("");
            Console.WriteLine("");

            //intitializing the method for who the user wants to contact
            Response2(response2);

            
            //an array list with the contact information
            ArrayList Contacts = new ArrayList();
            
            Contacts.Add(new Contact(){ContactLevel = 1, FirstName = "Tyler", LastName = "Rubright", PhoneNumber = "555-555-5555", Address = "1520 W Casino, Everett" });
            Contacts.Add(new Contact() { ContactLevel = 2, FirstName = "Regina", LastName = "Hall", PhoneNumber = "777-777-7777", Address = "121 MLK, Riverside" });

            
            //spacing for the output
            Console.WriteLine("");
            Console.WriteLine("");
            

            //using a while loop when the response is less than 7 to have different reactions to the users level
            while(response < 7)
            {
                if(response <= 2)
                {
                    //having the user come back tomorrow to check in 
                    Console.WriteLine("Please come back and check in with us tomorrow!");
                    int a = 3, i;
                    for (i = 0; i < 50; i++) //prints smiley symbol 250 times
                        Console.Write((char)a);
                    //Console.Write((char)1);
                    Console.ReadKey();
                }
                else if (response <= 4)
                {
                    //giving the user the option to speak to someone
                    Console.WriteLine("Would you like to talk to someone about what is on your mind or bothering you?");
                }
                else if (response <= 6)
                {
                    //using the method to have the users contacts displayed
                    Display(Contacts);
                }
                break;
            }

            //spacing for the output
            Console.WriteLine("");
            Console.WriteLine("");
            
            while (response >= 7)
            {
                //when the users response is 7 or higher contacts will be displayed
                    Display(Contacts);

                Console.WriteLine("");
                Console.WriteLine("");

                //the hotline number will be displaed and a message for the user to call it
                    HelpLine callNum = HelpLine.number;
                switch (callNum)
                {
                    case HelpLine.number:
                        Console.WriteLine("Or please call the national hotline: 1-800-273-8255");
                        break;
                }
                break;
            }
        }
        public static void Response1(int level) //method with if statement to gage a response to the user based on level of depression or anxiety
        {
            if (level <= 2)//lower level
            {
                Console.WriteLine("I'm glad to hear that your level is lower today.");
            }
            else if (level <= 4)
            {
                Console.WriteLine("I'm sorry to hear that your depression level is a little higher today.");
            }
            else if (level <= 6) //medium level
            {
                Console.WriteLine("Savanna, I think we should have you speak with one of your trusted contacts.");
            }
            else if (level <= 10) //high level - have user call/contact someone
            {
                Console.WriteLine("Okay, we should call your provider and a trusted contact immediately.");

            }
            else
            {
                return;
            }
        }
        public static void Response2(int level2) 
            //a method to differentiate between levels of 
            //depression in order to allow the user to have 
            //information of their trusted contacts displayed
        {
            if (level2 >= 5)
            {
                Console.WriteLine("Who would you like to contact?");
            }
            else { return; }

        }


        static void Display(ArrayList list)
        {
            //for loop to display contacts to user
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }

        }

        enum HelpLine 
        //an enum created to display the hotline number because it will never change.
        {
           number = 1 - 800 - 273 - 8255
        }
           
    }
    public struct Contact
        //a different class for contacts with the properties instantiated
    {
        public int ContactLevel { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
       
        
        public override string ToString()
            //this allows the information from the contacts list to be displayed without
            //having it say the namespace
        {
            return ContactLevel + "\t" + FirstName + "\t" + LastName + "\t" + PhoneNumber;

        }
    }


    class AddContacts<MyContactsName, MyContactsPhone>
    {
        //a separate class using a hashtable created for the users trusted contacts
        public List<MyContactsName> Name;
        public List<MyContactsPhone> PhoneNumber;

        public void AddContact(MyContactsName key, MyContactsPhone value)
        {
            //public void method to be able to add contacts to the hashtable/contact list
            Name.Add(key);
            PhoneNumber.Add(value);
        }

        public AddContacts()
            //a method in order to add more contacts
        {
            Name = new List<MyContactsName>();
            PhoneNumber = new List<MyContactsPhone>();
        }

    }
}
