using RestWithASPNETUdemy.Model;

namespace RestWithASPNETUdemy.Services.Implementations
{
    public class PersonServiceImplementation : IPersonService
    {
        private volatile int count;
        public Person Create(Person person)
        {
            return person;
        }

        public void Delete(long Id)
        {
            // quando conectar a base, sera ajustado
        }

        public List<Person> FindAll()
        {
            List<Person> persons = new List<Person>();
            for (int i = 0; i < 8; i++)
            {
                Person person = MockPerson(i);
                persons.Add(person);
            }

            return persons;
        }

        public Person FindByID(Person person)
        {
            return new Person { Id = 1, FirstName = "Gab", LastName = "Oliveira", Address = "Hortolândia - São Paulo - Brasil", Gender = "Male" };
        }

        public Person Update(Person person)
        {
            return person;
        }

        private Person MockPerson(int i)
        {
            return new Person { Id = IncrementAndGet(), FirstName = "Person Name " + i, LastName = "Parson LastName", Address = "mocklandia city", Gender = "Male" };
        }

        private long IncrementAndGet()
        {
            return Interlocked.Increment(ref count);
        }
    }
}
