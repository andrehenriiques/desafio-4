using Desafio4.Domain.Models;

namespace Desafio4.Domain.Interfaces.IServices;

public interface IAddressService
{
    public Task<ViaCepDto> GetUserAddressByUserId(int id);
}