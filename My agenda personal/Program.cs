using System;
using System.Collections.Generic;
using System.Linq;


public class Contact
{
    // Properties (data of the contact)
    public int Id { get; set; }
    public string Name { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }

    // Constructor (runs when object is created)
    public Contact(int id, string name, string phone, string email, string address)
    {
        Id = id;
        Name = name;
        Phone = phone;
        Email = email;
        Address = address;
    }
}



class Program
{
    // List of contacts (from document idea)
    static List<Contact> contacts = new List<Contact>();

    static bool running = true;

    static void Main()
    {
        Console.WriteLine("My Agenda");

        while (running)
        {
            ShowMenu();

            int choice;

            try   // there was a mistake that i fount so i solve this with try and catch
            {
                choice = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Please enter a number!");
                continue; // go back to menu
            }


            switch (choice)
            {
                case 1:
                    AddContact();
                    break;

                case 2:
                    ViewContacts();
                    break;

                case 3:
                    SearchContact();
                    break;

                case 4:
                    EditContact();
                    break;

                case 5:
                    DeleteContact();
                    break;

                case 6:
                    running = false;
                    break;

                default:
                    Console.WriteLine("Invalid option");
                    break;
            }
        }
    }


    // MENU
 
    static void ShowMenu()
    {

        Console.WriteLine(new string('=', 50));
        Console.WriteLine("        Marcos Eliu Cuevas Jimenez 2025 - 1883");
        Console.WriteLine("        PATIENT SIGN-UP SYSTEM");
        Console.WriteLine(new string('=', 50));


        Console.WriteLine("1. Add Contact");
        Console.WriteLine("2. View Contacts");
        Console.WriteLine("3. Search Contact");
        Console.WriteLine("4. Edit Contact");
        Console.WriteLine("5. Delete Contact");
        Console.WriteLine("6. Exit");
        Console.WriteLine(new string('-', 50));
        Console.Write("Choose option: ");

    }

    // ADD CONTACT

    static void AddContact()
    {
        int id = contacts.Count + 1;

        Console.Write("Name: ");
        string name = Console.ReadLine();

        Console.Write("Phone: ");
        string phone = Console.ReadLine();

        Console.Write("Email: ");
        string email = Console.ReadLine();

        Console.Write("Address: ");
        string address = Console.ReadLine();

        // Create object (from document concept)
        Contact newContact = new Contact(id, name, phone, email, address);

        contacts.Add(newContact);

        Console.WriteLine("Contact added!");
    }


    // VIEW CONTACTS
  
    static void ViewContacts()
    {
        Console.WriteLine("ID  Name  Phone  Email  Address");

        foreach (Contact c in contacts)
        {
            Console.WriteLine($"{c.Id}  {c.Name}  {c.Phone}  {c.Email}  {c.Address}");
        }
    }

 
    // SEARCH CONTACT

    static void SearchContact()
    {
        Console.Write("Enter ID to search: ");
        int id;

        try     // there was a mistake that i fount so i solve this with try and catch
        {
            id = Convert.ToInt32(Console.ReadLine());
        }
        catch
        {
            Console.WriteLine("Invalid ID!");
            return;
        }

        Contact c = contacts.FirstOrDefault(x => x.Id == id);

        if (c != null)
        {
            Console.WriteLine($"{c.Name} - {c.Phone} - {c.Email} - {c.Address}");
        }
        else
        {
            Console.WriteLine("Contact not found");
        }
    }


    // EDIT CONTACT
 
    static void EditContact()
    {
        Console.Write("Enter ID to edit: ");

        int id;

        try   // there was a mistake that i fount so i solve this with try and catch
        {
            id = Convert.ToInt32(Console.ReadLine());
        }
        catch
        {
            Console.WriteLine("Invalid ID!");
            return;
        }

        Contact c = contacts.FirstOrDefault(x => x.Id == id);

        if (c != null)
        {
            Console.Write("New Name: ");
            c.Name = Console.ReadLine();

            Console.Write("New Phone: ");
            c.Phone = Console.ReadLine();

            Console.Write("New Email: ");
            c.Email = Console.ReadLine();

            Console.Write("New Address: ");
            c.Address = Console.ReadLine();

            Console.WriteLine("Contact updated!");
        }
        else
        {
            Console.WriteLine("Contact not found");
        }
    }


    // DELETE CONTACT

    static void DeleteContact()
    {
        Console.Write("Enter ID to delete: ");

        int id;

        try     // there was a mistake that i fount so i solve this with try and catch
        {
            id = Convert.ToInt32(Console.ReadLine());
        }
        catch
        {
            Console.WriteLine("Invalid ID!");
            return;
        }

        Contact c = contacts.FirstOrDefault(x => x.Id == id);

        if (c != null)
        {
            contacts.Remove(c);
            Console.WriteLine("Contact deleted!");
        }
        else
        {
            Console.WriteLine("Contact not found");
        }
    }
}