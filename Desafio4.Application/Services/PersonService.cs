

using Desafio4.Domain.Interfaces.IServices;
using Desafio4.Domain.Models;

namespace Desafio4.Application.Services;

public class PersonService: IPersonService
{
    public List<Person> GetAll()
    {
        var person = new Person { Cpf = "123.456.789-00", Email = "jose@email.com", Nome = "Jose", Telefone = "1231231" };
        var person2 = new Person { Cpf = "123.456.789-00", Email = "jose@email.com", Nome = "Jose", Telefone = "1231231" };
        return [person, person2];
    }
}