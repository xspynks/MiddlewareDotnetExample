namespace Jala.Custom.Middleware.API.Middlewares;

public class QueryMiddleware
{
    // This field holds a reference to the next middleware in the pipeline
    private readonly RequestDelegate _next;

    public QueryMiddleware(RequestDelegate next)
    {
        // Save the reference to the next middleware in the pipeline
        _next = next;
    }

    // The InvokeAsync method is called by the ASP.NET Core request processing pipeline when the middleware is executed
    public async Task InvokeAsync(HttpContext context)
    {
        // Get the value of the "myparam" query parameter from the request
        var queryParam = context.Request.Query["myparam"];
        // Log the value of the query parameter to the console
        Console.WriteLine($"Query parameter: {queryParam}");

        // Check the value of the Path property on the request object
        if (context.Request.Path.Value == "/verifyme")
        {
            // If the path is "/verifyme", call the next middleware in the pipeline
            await _next(context);
        }
        else
        {
            // If the path is not "/verifyme", set the response status code to 404 and write a message to the response body
            context.Response.StatusCode = 404;
            await context.Response.WriteAsync("Path value is invalid");
        }
    }
}