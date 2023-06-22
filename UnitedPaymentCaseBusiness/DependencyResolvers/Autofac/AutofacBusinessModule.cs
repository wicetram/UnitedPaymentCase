using Autofac;
using UnitedPaymentCaseBusiness.Abstract;
using UnitedPaymentCaseBusiness.Concrete;
using UnitedPaymentCaseDataAccess.Abstract;
using UnitedPaymentCaseDataAccess.Concrete.EntityFramework;

namespace UnitedPaymentCaseBusiness.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CustomerManager>().As<ICustomerService>();
            builder.RegisterType<EfCustomerDal>();

            builder.RegisterType<TransactionManager>().As<ITransactionService>();
            builder.RegisterType<EfTransactionDal>();
        }
    }
}
