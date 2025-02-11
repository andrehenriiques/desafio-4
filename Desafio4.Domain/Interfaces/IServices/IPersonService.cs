using Desafio4.Domain.Models;

namespace Desafio4.Domain.Interfaces.IServices;

public interface IPersonService
{
    public List<Person> GetAll();
}