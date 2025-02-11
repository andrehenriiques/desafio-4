using Desafio4.Domain.Interfaces.IRepository;
using Desafio4.Domain.Models;
using Newtonsoft.Json;
using RestSharp;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Desafio4.Data.Rest.Repository;

public class ViaCepRepository : BaseRestRepository, IViaCepRepository
{
    private string _baseUrl;
    
    public ViaCepRepository(string baseUrl, EventHandler? onUnauthorizedResponse) : base(baseUrl, onUnauthorizedResponse)
    {
        _baseUrl = baseUrl;
    }

    public Task<ViaCepDto> GetUserAddressByUserId(int id)
    { 
        var jsonString = File.ReadAllText("./Address.json");
        var pessoas = JsonSerializer.Deserialize<List<AddressDto>>(jsonString);
        var cep = pessoas?.FirstOrDefault(c => c.id == id)?.cep;
        var urlCep = $"{_baseUrl}/{cep}/json";
        var response =  Client.Execute<ViaCepDto>(new RestRequest(urlCep));
       return Task.FromResult(JsonConvert.DeserializeObject<ViaCepDto>(response.Content));
    }
}