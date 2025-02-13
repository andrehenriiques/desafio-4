using Desafio4.Domain.Interfaces.IRepository;
using Desafio4.Domain.Interfaces.IServices;
using Desafio4.Domain.Models;

namespace Desafio4.Application.Services;

public class AddressService(IViaCepRepository viaCepRepository) : IAddressService
{
    public async Task<ViaCepDto> GetUserAddressByUserId(int id)
    {
        return await viaCepRepository.GetUserAddressByUserId(id);
    }
}