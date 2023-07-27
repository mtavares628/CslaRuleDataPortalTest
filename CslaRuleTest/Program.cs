// See https://aka.ms/new-console-template for more information
using ClassLibrary1;
using Csla;
using Csla.Configuration;

using Microsoft.Extensions.DependencyInjection;

Console.WriteLine("Hello, World!");

var services = new ServiceCollection();

// If you uncomment this, then ITestDal is no longer null in FetchChild, which seems to mean 
// that the dataportal is running a local fetchchild when inside of the businessrule's ExecuteAsync
//services.AddTransient<ITestDal, TestDal>();
services.AddHttpClient();
services.AddCsla(cfg => cfg
    .DataPortal(dp => dp
        .UseHttpProxy(hp =>
        {
            hp.DataPortalUrl = "https://localhost:7148/api/dataportal/";
        })));

var provider = services.BuildServiceProvider();

var portal = provider.GetRequiredService<IDataPortal<Root>>();
var root = await portal.FetchAsync();
root.Name = "root";