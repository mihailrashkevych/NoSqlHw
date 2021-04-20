using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using VeterinaryСlinic.Entities;
using VeterinaryСlinic.Repositories;

namespace VeterinaryСlinic
{
    class Program
    {
        static void Main()
        {
            var connectionString = "mongodb://localhost:15000";
            var dbName = "petdb";
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(dbName);
            var genericRepository = new PetRepository(database);
            var collection = database.GetCollection<Pet>(typeof(Pet).Name);

            if (collection.EstimatedDocumentCount() == 0)
            {
                InitialData.Set(genericRepository);
            }

            var state = "";
            while (state != "E")
            {
                Console.Clear();
                Console.WriteLine("Input 'A' for get count each pet by kind of pet!");
                Console.WriteLine("Input 'F' for get list of pet by data descending!");
                Console.WriteLine("Input 'E' for exit..");
                
                state = Console.ReadLine().ToUpper();
                Console.WriteLine();

                switch (state)
                {
                    case "A":
                        Console.WriteLine($"{"Kind of pet",-15} | {"Count",-10}");
                        Console.WriteLine("-------------------------");
                        foreach (var item in genericRepository.Aggregate())
                        {
                            Console.WriteLine("{0,-15} | {1,-10}", item.KindOfKindOfAnimal, item.Amount);
                        }
                        Console.WriteLine();
                        Console.WriteLine("Push any for go back");
                        Console.ReadKey();
                        break;

                    case "F":
                        Console.WriteLine();
                        Console.Write("Please input number of page size:");

                        var value = Console.ReadLine();
                        var pageSize = 0;
                        try
                        {
                            pageSize = int.Parse(value);
                        }
                        catch (OverflowException)
                        {
                            Console.WriteLine($"{value} is outside the range of the Int32 type.");
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine($"The {value.GetType().Name} value '{value}' is not in a recognizable format.");
                        }

                        var page = 1;
                        while (state != "B")
                        {
                            Console.Clear();
                            Console.WriteLine("Input 'B' for go back...") ;
                            Console.WriteLine();
                            Console.WriteLine($"{"Pet Name",-20} | {"Kind of pet",-20}| {"Registration date",-25}| {"Owner name",-20}| {"Owner phone",-20}");
                            Console.WriteLine("---------------------------------------------------------------------------------------------------------");
                            foreach (var item in genericRepository.FindWithLimit(pageSize, page))
                            {
                                Console.WriteLine($"{item.Name,-21}|{item.KindOfAnimal,-21}|{item.RegistrationDate,-26}|{item.Owner.Name,-21}|{item.Owner.Phone,-21}");
                            }
                            Console.WriteLine();
                            Console.WriteLine($"Page: {page}");
                            Console.WriteLine();
                            Console.WriteLine("Input 'N' for go to the next page");
                            if (page>1)
                            {
                                Console.WriteLine("Input 'P' for go to the previous page");
                            }

                            
                            state = Console.ReadLine().ToUpper();

                            if (state == "N")
                            {
                                page++;
                            }
                            else if (state == "P" && page > 1)
                            {
                                page--;
                            }
                        }

                        break;

                    default:
                        Console.WriteLine("Wrong choice");
                        break;
                }
            }
        }
    }
}
