using Desafio4.Domain.Interfaces.IRepository;
using Desafio4.Domain.Models; 
using RestSharp;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Desafio4.Data.Rest.Repository;

public class ViaCepRepository(string baseUrl, EventHandler? onUnauthorizedResponse)
    : BaseRestRepository(baseUrl, onUnauthorizedResponse), IViaCepRepository
{
    private readonly string _baseUrl = baseUrl;

    public async Task<ViaCepDto> GetUserAddressByUserId(int id)
    {
        var jsonString = await File.ReadAllTextAsync("./Address.json");
        var people = JsonSerializer.Deserialize<List<AddressDto>>(jsonString);
        var cep = people?.FirstOrDefault(c => c.id == id)?.cep;
        if (string.IsNullOrEmpty(cep))
        {
            throw new InvalidOperationException("CEP não encontrado para o ID fornecido.");
        }
        var urlCep = $"{_baseUrl}/{cep}/json";
        var client = new RestClient();
        var request = new RestRequest(urlCep);
        var response = await client.ExecuteAsync<ViaCepDto>(request);
        if (!response.IsSuccessful || response.Data == null)
        {
            throw new Exception($"Erro ao buscar informações do CEP");
        }
        return response.Data;
    }

}