using Microsoft.EntityFrameworkCore;
using TestDataLoader.Db;
using TestDataLoader.GraphQL;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseInMemoryDatabase("FooDb"));

builder.Services
    .AddGraphQLServer()
    .AddSorting()
    .AddProjections()
    .AddFiltering()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>()
    .ModifyRequestOptions(opt => opt.IncludeExceptionDetails = true)
    .AddApolloFederation();

var app = builder.Build();
app.UseRouting();
app.UseEndpoints(c =>
{
    c.MapGraphQL();
    c.MapBananaCakePop();
});


app.RunWithGraphQLCommands(args);