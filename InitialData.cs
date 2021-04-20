using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using VeterinaryСlinic.Entities;
using VeterinaryСlinic.Repositories;

namespace VeterinaryСlinic
{
    public class InitialData
    {
        static public void Set(PetRepository repository)
        {
            var genericRepository = repository;
            
            Owner Peter = new Owner() { Name = "Peter", Phone = "+954615245" };
            Owner Olga = new Owner() { Name = "Olga", Phone = "+215445215" };
            Owner Sancho = new Owner() { Name = "Sancho", Phone = "+32648879" };
            Owner Master = new Owner() { Name = "Master", Phone = "+154884" };

            List<IEntity> pets = new List<IEntity>()
            {
                new Pet() {Name = "GoodDog", KindOfAnimal = "Dog", Owner = Peter, RegistrationDate = new DateTime(2021,01,01)},
                new Pet() {Name = "HappyDog", KindOfAnimal = "Dog", Owner = Olga, RegistrationDate = new DateTime(2021,02,02)},
                new Pet() {Name = "BadDog", KindOfAnimal = "Dog", Owner = Sancho, RegistrationDate = new DateTime(2021,03,03)},
                new Pet() {Name = "FunnyDog", KindOfAnimal = "Dog", Owner = Master, RegistrationDate = new DateTime(2021,04,04)},
                new Pet() {Name = "GoodBoy", KindOfAnimal = "Dog", Owner = Master, RegistrationDate = new DateTime(2021,04,04)},

                new Pet() {Name = "GoodCat", KindOfAnimal = "Cat", Owner = Peter, RegistrationDate = new DateTime(2021,05,05)},
                new Pet() {Name = "HappyCat", KindOfAnimal = "Cat", Owner = Olga, RegistrationDate = new DateTime(2021,06,06)},
                new Pet() {Name = "BadCat", KindOfAnimal = "Cat", Owner = Sancho, RegistrationDate = new DateTime(2021,07,07)},
                new Pet() {Name = "FunnyCat", KindOfAnimal = "Cat", Owner = Master, RegistrationDate = new DateTime(2021,08,08)},

                new Pet() {Name = "GoodBird", KindOfAnimal = "Bird", Owner = Peter, RegistrationDate = new DateTime(2021,09,09)},
                new Pet() {Name = "HappyBird", KindOfAnimal = "Bird", Owner = Olga, RegistrationDate = new DateTime(2021,10,10)},
                new Pet() {Name = "BadBird", KindOfAnimal = "Bird", Owner = Sancho, RegistrationDate = new DateTime(2021,11,11)},

                new Pet() {Name = "GoodSnake", KindOfAnimal = "Snake", Owner = Peter, RegistrationDate = new DateTime(2021,05,02)},
                new Pet() {Name = "HappySnake", KindOfAnimal = "Snake", Owner = Olga, RegistrationDate = new DateTime(2021,05,02)},

            };

            foreach (var pet in pets)
            {
                var id = genericRepository.Insert((Pet) pet);
                Console.WriteLine($"{id} inserted");
            }

        }
    }
}
