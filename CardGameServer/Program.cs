using Model.UserInfo;
using Model.CardPlayInfo;
using Microsoft.AspNetCore.Authorization;
using Model.GameState;

var builder = WebApplication.CreateBuilder(args);

// Configure JWT token settings here
builder.Services.AddSingleton(new JwtSettings {
    // Example settings
    Key = "YourSecretKeyHere", // Use a secure key in real applications
    Issuer = "YourIssuer",
    Audience = "YourAudience"
});

builder.Services.AddSingleton<TokenService>();

var app = builder.Build();

app.MapPost("/startGame", (UserInfo userInfo, TokenService tokenService) => {
    var token = tokenService.CreateJwtToken(userInfo);

    var gameState = new GameState();


   return Results.Ok(gameState);
});

app.MapPost("/playCard", [Authorize] (CardPlayInfo playInfo) => {
    var gameState = new GameState();

   return Results.Ok(gameState);
});


app.Run();
