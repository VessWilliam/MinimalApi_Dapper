namespace APIDonefully;

public static class Api
{

    public static void ConfigureApi(this WebApplication app)
    {
        //All of my Api Endpoint mapping
        app.MapGet("/Users", GetUsers);
        app.MapGet("/Users/{id}", GetUser);
        app.MapPost("/Users/Create", InsertUsers);
        app.MapPut("/Users/Update", UpdateUsers);
        app.MapDelete("/Users/Delete/{id}" , DeleteUsers);
        app.MapGet("/Users/Check/{mac}", GetUserByMac  );
        app.MapGet("Users/Valid/{mac}", CheckValidUserByMac);
     }
    private static async Task<IResult> GetUsers(IUserData data)
    {
        try
        {
            return Results.Ok(await data.GetUsers());
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
    private static async Task<IResult> GetUser(int id , IUserData data)
    {
        try
        {
            var result = await data.GetUser(id);
            return result == null ? Results.NotFound("0") : Results.Ok(result);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
    private static async Task<IResult> InsertUsers(UserModels user ,  IUserData data)
    {
        try
        {
            await data.InsertUser(user);
            return Results.Ok(user);    
        }
        catch (Exception ex)
        { 
            return Results.Problem(ex.Message);
        }
    }
    private static async Task<IResult> UpdateUsers(UserModels user , IUserData data)
    {
        try
        {
            await data.UpdateUser(user);
            return Results.Ok("1");
        }
        catch (Exception ex)
        {
            return Results.Ok($"{ ex.Message} : 0");
        }
    }
    private static async Task<IResult> DeleteUsers(int id , IUserData data)
    {
        try
        {
            await data.DeleteUsers(id);
            return Results.Ok();
        }
        catch (Exception ex)
        { 
            return Results.Problem(ex.Message);
        }
    }
    private static async Task<IResult> GetUserByMac(string mac , IUserData data)
    {
        try
        {
            var result = await data.GetUserByMac(mac);
            Console.WriteLine(result);

            return result != null ? Results.Ok("1") : Results.Ok("0");

        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }

    }  
    private static async Task<IResult> CheckValidUserByMac(string mac , IUserData data)
    {
        try
        {
            var result = await data.CheckValidUserByMac(mac);
            if (result != null)
            {
                return result.DateExpire?.Date <= DateTime.Now.Date ? Results.Ok("0") : Results.Ok("1");
            }
            else
            {
                return Results.Ok("0");
            }
          
        } 
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
}
