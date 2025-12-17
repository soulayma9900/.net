var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.PharmacieBlazor>("pharmacieblazor");

builder.Build().Run();
