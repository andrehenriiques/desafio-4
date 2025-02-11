using Desafio4.Domain.Interfaces.IRepository;
using Desafio4.Domain.Interfaces.IServices;
using Desafio4.Domain.Models;

namespace Desafio4.Application.Services;

public class AddressService: IAddressService
{
    private IViaCepRepository _viaCepRepository;

    public AddressService(IViaCepRepository viaCepRepository)
    {
        _viaCepRepository = viaCepRepository;
    }
    
    public Task<ViaCepDto> GetUserAddressByUserId(int id)
    {
        return _viaCepRepository.GetUserAddressByUserId(id);
    }
}