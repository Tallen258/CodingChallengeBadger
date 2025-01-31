using BadgerClan.Logic;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Net.Http.Json;
using System.Text.Json;


namespace Controller.Maui.ViewModels;

    public partial class MoveViewModel : ObservableObject
    {
    private readonly HttpClient _httpClient;

    public MoveViewModel(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    [RelayCommand]
    // Method that triggers the API call to scatter troops
    private async Task ScatterTroopsLeft()
    {   
            // Your API URL (replace with the actual one)
            string apiUrl = "http://localhost:5027/change/MoveLeft";
        await _httpClient.GetAsync(apiUrl);
    }

    [RelayCommand]
    private async Task ScatterTroopsRight()
    {
        string apiUrl = "http://localhost:5027/change/MoveRight";
        await _httpClient.GetAsync(apiUrl);
    }

    [RelayCommand]
    private async Task DoNothing()
    {
        string apiUrl = "http://localhost:5027/change/Nothing";
        await _httpClient.GetAsync(apiUrl);
    }

    [RelayCommand]
    private async Task RunAndGun()
    {
        string apiUrl = "http://localhost:5027/change/RunGun";
        await _httpClient.GetAsync(apiUrl);
    }

    [RelayCommand]
    private async Task MoveDownLeft()
    {
        string apiUrl = "http://localhost:5027/change/DownLeft";
        await _httpClient.GetAsync(apiUrl);
    }

    [RelayCommand]
    private async Task MoveDownRight()
    {
        string apiUrl = "http://localhost:5027/change/DownRight";
        await _httpClient.GetAsync(apiUrl);
    }

    [RelayCommand]
    private async Task MoveUpRight()
    {
        string apiUrl = "http://localhost:5027/change/UpRight";
        await _httpClient.GetAsync(apiUrl);
    }

    [RelayCommand]
    private async Task MoveUpLeft()
    {
        string apiUrl = "http://localhost:5027/change/UpLeft";
        await _httpClient.GetAsync(apiUrl);
    }
    [RelayCommand]
    private async Task Attack()
    {
        string apiUrl = "http://localhost:5027/change/Attack";
        await _httpClient.GetAsync(apiUrl);
    }

    [RelayCommand]
    private async Task RunAway()
    {
        string apiUrl = "http://localhost:5027/change/RunAway";
        await _httpClient.GetAsync(apiUrl);
    }

}


