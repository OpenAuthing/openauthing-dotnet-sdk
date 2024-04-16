namespace BeniceSoft.OpenAuthing.AspNetCore.Authorization;

public class OpenAuthingAuthorizationBuilder
{
    public OpenAuthingBuilder OpenAuthingBuilder {get;}
    public OpenAuthingAuthorizationBuilder(OpenAuthingBuilder builder)
    {
        OpenAuthingBuilder = builder;
    }
}