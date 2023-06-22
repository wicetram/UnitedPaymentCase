using Autofac;
using UnitedPaymentCaseWebApi.Business.Abstract;
using UnitedPaymentCaseWebApi.Business.Concrete;

namespace UnitedPaymentCaseWebApi.Business.DependencyResolvers
{
    public class AutofacWebApiBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<PaymentManager>().As<IPaymentService>();
            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<VerificationManager>().As<IVerificationService>();
        }
    }
}
