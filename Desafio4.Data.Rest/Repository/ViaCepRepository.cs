using Desafio4.Domain.Interfaces.IRepository;
using Desafio4.Domain.Models; 
using RestSharp;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Desafio4.Data.Rest.Repository;

public class ViaCepRepository
    : BaseRestRepository, IViaCepRepository
{

    public async Task<ViaCepDto> GetUserAddressByUserId(int id)
    {
        var jsonString = await File.ReadAllTextAsync("./Address.json");
        var people = JsonSerializer.Deserialize<List<AddressDto>>(jsonString);
        var cep = people?.FirstOrDefault(c => c.id == id)?.cep;
        if (string.IsNullOrEmpty(cep))
        {
            throw new InvalidOperationException("CEP não encontrado para o ID fornecido.");
        }
        var urlCep = $"/{cep}/json";
        var request = new RestRequest(urlCep);
        var response = await Client.ExecuteAsync<ViaCepDto>(request);
        return response.Data;
    }

}