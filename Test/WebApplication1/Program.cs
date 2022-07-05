using System.Net.NetworkInformation;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.WebHost.UseUrls("http://localhost:1234");
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

Ping pingSender = new Ping ();
PingOptions options = new PingOptions ();

// Use the default Ttl value which is 128,
// but change the fragmentation behavior.
options.DontFragment = true;

// Create a buffer of 32 bytes of data to be transmitted.
string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
byte[] buffer = Encoding.ASCII.GetBytes (data);
int timeout = 120;
PingReply reply = pingSender.Send ("eventstore", timeout, buffer, options);
Console.WriteLine("Ping to eventstore");
if (reply.Status == IPStatus.Success)
{
    Console.WriteLine ("Address: {0}", reply.Address.ToString ());
    Console.WriteLine ("RoundTrip time: {0}", reply.RoundtripTime);
    Console.WriteLine ("Time to live: {0}", reply.Options.Ttl);
    Console.WriteLine ("Don't fragment: {0}", reply.Options.DontFragment);
    Console.WriteLine ("Buffer size: {0}", reply.Buffer.Length);
}
else
{
    Console.WriteLine("Nie udało się");
}

app.Run();