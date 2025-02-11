using Desafio4.Domain.Models;

namespace Desafio4.Domain.Interfaces.IRepository;

public interface IViaCepRepository
{
    public Task<ViaCepDto> GetUserAddressByUserId(int id);
}