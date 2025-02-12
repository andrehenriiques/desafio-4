using System.Net;
using RestSharp;

namespace Desafio4.Data.Rest.Repository;

public class BaseRestRepository(string baseUrl, EventHandler? onUnauthorizedResponse)
{ 
    protected readonly RestClient Client = new(new RestClientOptions(baseUrl)
    {
        ThrowOnDeserializationError = false
    });

    protected async Task<T> ExecuteOrThrowAsync<T>(RestRequest request , bool throwException = false)
    {
        var response = await Client.ExecuteAsync<T>(request, CancellationToken.None);

        if (response.StatusCode == HttpStatusCode.Unauthorized)
        {
            onUnauthorizedResponse?.Invoke(response, EventArgs.Empty);
        }

        if (response.ErrorException != null && throwException)
        {
            throw new InvalidOperationException(
                $"Erro no parse da resposta do BaseRestRepository ({request.Resource}): {response.StatusCode} - {response.Content}",
                response.ErrorException);
        }

        if (!response.IsSuccessful && throwException)
        {
            throw new HttpRequestException(
                $"Erro na resposta do BaseRestRepository ({request.Resource}): {response.StatusCode} - {response.Content}",
                null, response.StatusCode);
        }

        return response.Data!;
    }

}