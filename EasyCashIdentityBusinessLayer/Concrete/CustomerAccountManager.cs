using EasyCashIdentityBusinessLayer.Abstract;
using EasyCashIdentityDataAccessLayer.Abstract;
using EasyCashIdentityEntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCashIdentityBusinessLayer.Concrete
{
    public class CustomerAccountManager : ICustomerAccountService
    {
        ICustomerAccountDal _customerAccountDal;

        public CustomerAccountManager(ICustomerAccountDal customerAccountDal)
        {
            _customerAccountDal = customerAccountDal;
        }

        public void TAdd(CustomerAccount t)
        {
            _customerAccountDal.Insert(t);
        }

        public void TDelete(CustomerAccount t)
        {
            _customerAccountDal.Delete(t);
        }

        public CustomerAccount TGetById(int id)
        {
            return _customerAccountDal.GetById(id);
        }

        public List<CustomerAccount> TGetList()
        {
            return _customerAccountDal.GetList();
        }

        public void TUpdate(CustomerAccount t)
        {
            _customerAccountDal.Update(t);
        }
    }
}
