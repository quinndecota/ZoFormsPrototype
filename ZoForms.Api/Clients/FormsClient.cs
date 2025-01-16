using System.Net.Http;

using ZoForms.Frontend.Models;



namespace ZoForms.Api.Clients
{
    public class FormsClient(HttpClient httpClient)
    {
        public async Task<PropertyForm[]> GetGamesAsync() =>
        await httpClient.GetFromJsonAsync<PropertyForm[]>("forms") ?? [];

        public async Task AddGameAsync(PropertyForm game) =>
            await httpClient.PostAsJsonAsync("forms", game);

        public async Task<PropertyForm> GetGameAsync(int id) =>
            await httpClient.GetFromJsonAsync<PropertyForm>($"forms/{id}") ?? throw new Exception("Form Not Found");

        public async Task UpdateFormAsync(PropertyForm updatedForm) =>
            await httpClient.PutAsJsonAsync($"forms/{updatedForm.Id}", updatedForm);

        public async Task DeleteGameAsync(PropertyForm form) =>
            await httpClient.DeleteAsync($"forms/{form.Id}");
    }
}
