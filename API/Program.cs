using Business;
using Core.Abstracts;
using Core.Concretes.DTOs;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCustomServices();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("api/payments/{transactionId}/status", async (string transactionId, [FromQuery] string provider, [FromServices] IPaymentService paymentService) =>
{
    try
    {
        var result = await paymentService.GetPaymentStatusAsync(transactionId, provider);
        return Results.Ok(result); // 200
    }
    catch (ArgumentException ex)
    {
        return Results.BadRequest(new { error = ex.Message }); // 400
    }
    catch (Exception ex)
    {
        return Results.Problem(ex.Message); // 500
    }
});

// PaymentProcess
app.MapPost("api/payments/process", async ([FromBody] PaymentRequest request, [FromServices] IPaymentService paymentService) =>
{
    try
    {
        var result = await paymentService.ProcessPaymentAsync(request);
        return Results.Ok(result);
    }
    catch (ArgumentException ex)
    {
        return Results.BadRequest(new { error = ex.Message }); // 400
    }
    catch (Exception ex)
    {
        return Results.Problem(ex.Message); // 500
    }
});

// Refund
app.MapPost("api/payments/refund", async ([FromBody] RefundRequest request, [FromServices] IPaymentService paymentService) =>
{
    try
    {
        var result = await paymentService.ProcessRefundAsync(request);
        return Results.Ok(result);
    }
    catch (ArgumentException ex)
    {
        return Results.BadRequest(new { error = ex.Message }); // 400
    }
    catch (Exception ex)
    {
        return Results.Problem(ex.Message); // 500
    }
});

app.Run();
