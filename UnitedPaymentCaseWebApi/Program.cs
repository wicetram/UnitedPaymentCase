using Autofac;
using Autofac.Extensions.DependencyInjection;
using UnitedPaymentCaseBusiness.DependencyResolvers.Autofac;
using UnitedPaymentCaseWebApi.Business.DependencyResolvers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(new AutofacBusinessModule()));
builder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(new AutofacWebApiBusinessModule()));

//builder.Services.AddTransient<IPaymentService, PaymentManager>();
//builder.Services.AddTransient<IUserService, UserManager>();
//builder.Services.AddTransient<IVerificationService, VerificationManager>();

//builder.Services.AddTransient<ICustomerService, CustomerManager>();
//builder.Services.AddTransient<ICustomerDal, EfCustomerDal>();

//builder.Services.AddTransient<ITransactionService, TransactionManager>();
//builder.Services.AddTransient<ITransactionDal, EfTransactionDal>();

//builder.Services.AddTransient<EfCustomerDal>();
//builder.Services.AddTransient<EfTransactionDal>();

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

app.Run();
