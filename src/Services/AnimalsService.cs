using SimpleAPI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace SimpleAPI.Services
{
    public class AnimalsService
    {
        private HashSet<Animal> _animals = new HashSet<Animal>();

        public AnimalsService()
        {
            Reload();
        }

        public void Reload()
        {
            try
            {
                string assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                string dataPath = Path.Combine(assemblyPath, "Data", "animals.txt");
                string[] names = File.ReadAllLines(dataPath);
                foreach(string name in names)
                {
                    _animals.Add(new Animal()
                    {
                        Name = name
                    });
                }
            }
            catch(IOException e)
            {
                Console.WriteLine($"Error reloading animals: {e.Message}");
                throw;
            }
        }
        
        public Animal Random()
        {
            Random r = new Random();
            var randomIndex = r.Next(0, _animals.Count);
            return _animals.ToList()[randomIndex];
        }
    }

}
