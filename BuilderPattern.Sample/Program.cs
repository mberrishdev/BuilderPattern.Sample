

// ასეთ დროს იქმნება WebApplicationBuilder-ი, რომელიც გვეხმარება, შემდეგ მარტივად დავაკონფიგურიროთ სხვადასხვა პარამეტრები
// დავამტოთ სერვისები,
// წავიკითხოთ სეტინგები და აშ
// მისი მთავარი მიზანია, რომ არ მოგვწიოს კონფიგურაციის აწყობა კონტრუქტორის საშუალებით. რომელიც საკმაოდ ჩახლართავს
// კოდს, და წაუკითხავს გახდის. 
// ბილდერის გამოყენებით გაცილებით მარტივად შეიძლება კოდის წაკითხვა
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// რომ არა ბილდერ პატერნი, საჭირო იქნება WebApplication-ის შექმნის დროს, კონსტრუქტორის საშუალები, ჩაგვემატებია IServiceCollection-ში
//http კლიენტი
builder.Services.AddHttpClient("myClient", client =>
{
    client.BaseAddress = new Uri("https://api.example.com");
});

// რომ არა ბილდერ პატერნი, მოგვიწევდა ასეთი კოდის დაწერა (რომელიც რეალურად არ იმუშავებს, რადგან არ არის მზგავსი ფუნქციონალი იმპლემენტირებული)
// var services = new ServiceCollection();
//
// var client = new HttpClient
// {
//     BaseAddress = new Uri("https://api.example.com")
// };
//
// services.AddSingleton(client);
//
// var serviceProvider = services.BuildServiceProvider();
//
// var app = new WebApplication(serviceProvider);


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();
