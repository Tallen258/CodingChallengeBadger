using BadgerClan.Logic;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Controller.Maui.ViewModels;
using Grpc.Net.Client;
using GrpcLogic;
using System.Threading.Channels;
namespace Controller.Maui.Views;

public partial class MoveView : ContentPage
{
    public MoveView(MoveViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;

    }
}
//public partial class MoveViewModel : ObservableObject
//{
//    // Observable property to hold the response from the gRPC call
//    [ObservableProperty]
//    private ScatterResponse _response;

//    // Constructor
//    public MoveViewModel()
//    {
//    }

//    // Method to trigger the gRPC call
//    public async Task TriggerApiCall()
//    {
//        try
//        {
//            // Create the gRPC channel
//            using var channel = GrpcChannel.ForAddress("http://localhost:5000");

//            //var client = new IGameBotService.IGameBotServiceClient(channel);

//            var request = new ScatterRequest
//            {
//                YourTeamId = "team123",
//                MoveRequests = new List<MoveRequest>()  // Add your move requests if needed
//            };

//            // Call the API
//            var response = await client.ScatterMoveAsync(request);

//            // Update the response property (UI will automatically reflect this change)
//            Response = response;
//        }
//        catch (Exception ex)
//        {
//            // Handle any errors here (log or show error messages)
//            Console.WriteLine($"Error: {ex.Message}");
//        }
//    }
//}
