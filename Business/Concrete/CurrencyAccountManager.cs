﻿using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Extensions.Aspects.Autofact.Validation;
using Core.Utilities.Results.Abstarct;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CurrencyAccountManager : ICurrencyAccountService
    {
        private readonly ICurrencyAccountDal _currencyAccountDal; 

        [ValidationAspect(typeof(CurrencyAccountValidator))]
        public IResult Add(CurrencyAccount currencyAccount)
        {
            _currencyAccountDal.Add(currencyAccount);
            return new SuccessResult();
        }

        [ValidationAspect(typeof(CurrencyAccountValidator))]

        public IResult AddToExcel(string filePath,int companyId)
        {
           System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            using (var stream = System.IO.File.Open(filePath, FileMode.Open, FileAccess.Read))
            {
                using(var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    while(reader.Read())
                    {
                        string code = reader.GetString(0);
                        string currencyAccountName = reader.GetString(1);
                        string address = reader.GetString(2);
                        string taxDepartment = reader.GetString(3);
                        string taxIdNumber = reader.GetString(4);
                        string identityNumber = reader.GetString(5);
                        string email = reader.GetString(6);
                        string authorized = reader.GetString(7);
                        if (code!="Cari Kodu")
                        {
                            CurrencyAccount currencyAccount = new CurrencyAccount()
                            {
                                CurrencyAccountName = currencyAccountName,
                                Address = address,
                                TaxDepartment=taxDepartment,
                                TaxIdNumber=taxIdNumber,
                                IdentityNumber=identityNumber,
                                EMail=email,
                                Authorized=authorized,
                                AddedAt=DateTime.Now,
                                Code=code,
                                CompanyId=companyId,
                                IsActive=true
                            };
                            _currencyAccountDal.Add(currencyAccount);
                        }
                    }
                }
            }
            return new SuccessResult();
        }

        public IResult Delete(CurrencyAccount currencyAccount)
        {
            _currencyAccountDal.Delete(currencyAccount);
            return new SuccessResult();
        }

        public IDataResult<CurrencyAccount> Get(int id)
        {
            return new SuccessDataResult<CurrencyAccount>(_currencyAccountDal.Get(x=>x.CurrencyAccountId==id));
        }

        public IDataResult<List<CurrencyAccount>> GetList(int companyId)
        {
            return new SuccessDataResult<List<CurrencyAccount>>(_currencyAccountDal.GetList(x => x.CompanyId == companyId));
        }
        [ValidationAspect(typeof(CurrencyAccountValidator))]
        public IResult Update(CurrencyAccount currencyAccount)
        {
            _currencyAccountDal.Update(currencyAccount);
            return new SuccessResult();
        }
    }
}
