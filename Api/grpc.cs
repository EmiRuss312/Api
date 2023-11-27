using Grpc.Net.Client;
using UserService;

public class grpcSetvice
{
    private readonly UserService.UserService.UserServiceClient _client;

    public grpcSetvice()
    {
        var channel = GrpcChannel.ForAddress("https://localhost:7296");

        _client = new UserService.UserService.UserServiceClient(channel);
    }

    public async Task<LoginReply> Login(LoginRequest request)
    {
        var reply = await _client.LoginAsync(request);
        return reply;
    }

    public async Task<GetUserReply> GetUserData(GetUserRequest request)
    {
        var reply = await _client.GetUserAsync(request);
        return reply;
    }
}