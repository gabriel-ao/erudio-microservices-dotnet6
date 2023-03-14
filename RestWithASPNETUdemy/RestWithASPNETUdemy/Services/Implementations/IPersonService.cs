using RestWithASPNETUdemy.Model;

namespace RestWithASPNETUdemy.Services.Implementations
{
    public interface IPersonService
    {
        Person Create(Person person);
        Person FindByID(Person person);
        List<Person> FindAll();
        Person Update(Person person);
        void Delete(long Id);
    }
}
