var builder = WebApplication.CreateBuilder(args);
const string corsPolicyName = "_googleCloudAuthenticationOrigins";

{
    builder.Services.AddControllersWithViews();
    builder.Services.AddCors(options =>
    {
        options.AddPolicy(name: corsPolicyName, policy =>
        {
            policy.AllowAnyHeader();
            policy.AllowAnyMethod();
            policy.AllowAnyOrigin();
        });
    });
}

var app = builder.Build();

{
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Home/Error");
        app.UseHsts();
    }

    app.UseHttpsRedirection();
    app.UseStaticFiles();
    app.UseRouting();
    app.UseAuthorization();
    app.UseCors(policyName: corsPolicyName);
    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}"
    );
    app.Run();
}
