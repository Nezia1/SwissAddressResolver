using System;
using System.Collections.Generic;

namespace SwissAddressResolver
{
    class Program
    {
        static void Main(string[] args)
        {
            PostDatabase postDatabase = new PostDatabase();
            int choice = 0;
            Console.Write("Do you want to resolve a PLZ to a street or the opposite ? (1 / 2)");
            try
            {
                // Select mode
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    // PLZ to street
                    case 1:
                        Console.WriteLine("PlZ to corresponding street");
                        Console.Write("PLZ to query : ");
                        int npa = Convert.ToInt32(Console.ReadLine());
                        List<Street> matchedStreets = postDatabase.ConvertPLZToStreetNames(npa);

                        // Display formatted streets
                        foreach (Street street in matchedStreets)
                        {
                            Console.WriteLine(street.ToString());
                        }
                        break;

                    // Street to PLZ list
                    case 2:
                        Console.WriteLine("Street name to corresponding PLZ");
                        Console.Write("Street name to query : ");
                        string streetName = Console.ReadLine();
                        List<Plz> matchedPlzs = postDatabase.ConvertStreetNameToPLZ(streetName);

                        // Display found PLZ
                        foreach (Plz plz in matchedPlzs)
                        {
                            Console.WriteLine(plz.ToString());
                        }
                        break;
                    default:
                        Console.WriteLine("Error : please enter one of the choices of the list");
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
