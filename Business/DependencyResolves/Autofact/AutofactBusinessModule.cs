using Autofac;
using Business.Abstract;
using Business.Concrete;
using Core.Utilities.Security.Jwt;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolves.Autofact
{
    public class AutofactBusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CompanyManager>().As<ICompanyService>();
            builder.RegisterType<EfCompanyDal>().As<ICompanyDal>();

            builder.RegisterType<AccountReconcilationsDetailsManager>().As<IAccountReconcilationsDetailsService>();
            builder.RegisterType<EfAccountReconcilationsDetailDal>().As<IAccountReconcilationsDetailDal>();

            builder.RegisterType<AccountReconcilationsManager>().As<IAccountReconcilationsService>();
            builder.RegisterType<EfAccountReconcilationDal>().As<IAccountReconcilationDal>();

            builder.RegisterType<BaBsReconcilationsDetailsManager>().As<IBaBsReconcilationsDetailsService>();
            builder.RegisterType<EfBaBsReconcilationsDetailDal>().As<IBaBsReconcilationsDetailDal>();

            builder.RegisterType<BaBsReconcilationsManager>().As<IBaBsReconcilationsService>();
            builder.RegisterType<EfBaBsReconcilationDal>().As<IBaBsReconcilationDal>();

            builder.RegisterType<CurrenciesManager>().As<ICurrenciesService>();
            builder.RegisterType<EfCurrenciescDal>().As<ICurrenciescDal>();

            builder.RegisterType<CurrencyAccountManager>().As<ICurrencyAccountService>();
            builder.RegisterType<EfCurrencyAccountDal>().As<ICurrencyAccountDal>();

            builder.RegisterType<MailParametersManager>().As<IMailParametersService>();
            builder.RegisterType<EfMailParametersDal>().As<IMailParametersDal>();

            builder.RegisterType<MailManager>().As<IMailService>();
            builder.RegisterType<EfMailDal>().As<IMailDal>();

            builder.RegisterType<OperationClaimsManager>().As<IOperationClaimsService>();
            builder.RegisterType<EfOperationClaimDal>().As<IOperationClaimDal>();

            builder.RegisterType<UserCompaniesManager>().As<IUserCompaniesService>();
            builder.RegisterType<EfUserCompanieDal>().As<IUserCompanieDal>();

            builder.RegisterType<UserOperationClaimsManager>().As<IUserOperationClaimsService>();
            builder.RegisterType<EfUserOperationClaimDal>().As<IUserOperationClaimDal>();

            builder.RegisterType<UsersManager>().As<IUsersService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();

            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

            builder.RegisterType<MailTemplateManager>().As<IMailTemplateService>();
            builder.RegisterType<EfMailTemplateDal>().As<IMailTemplateDal>();

        }
    }
}
