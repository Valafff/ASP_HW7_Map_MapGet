//app.MapGet:
//Специфичен для GET запросов.
//Легко используется для определения GET маршрутов.

//app.Map:
//Универсален для всех типов HTTP запросов.
//Можно использовать для создания более общих маршрутов и различных HTTP методов.

//app.MapWhen:
//Позволяет создавать условные маршруты на основе заданного предиката.
//Полезен для выполнения маршрутизации, основанной на условиях.


using System.Runtime.InteropServices;
using System.Text.Unicode;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


app.MapGet("/" , async context =>
{
	await PageConfig(context, "index.html");
});

app.Map("/page1", appBuilder =>
{
	appBuilder.Run(async context =>
	{
		await PageConfig(context, "page1.html");
	});
});

app.Map("/page2", appBuilder =>
{
	appBuilder.Run(async context =>
	{
		await PageConfig(context, "page2.html");
	});
});

app.Map("/page3", appBuilder =>
{
	appBuilder.Run(async context =>
	{
		await PageConfig(context, "page3.html");
	});
});

app.Map("/page4", appBuilder =>
{
	appBuilder.Run(async context =>
	{
		await PageConfig(context, "page4.html");
	});
});



async Task PageConfig(HttpContext context, string fileName)
{
	var path = context.Request.Path; 
	var fullPath = $"html/{path}"; 
	var response = context.Response; 
	response.ContentType = "text/html; charset=utf-8"; 
	await response.SendFileAsync($"{fullPath}/{fileName}"); 
}


app.Run();
