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
    public class CustomerAccountProcessManager : ICustomerAccountProcessService
    {
        ICustomerAccountProcessDal _customerAccountProcessDal;

        public CustomerAccountProcessManager(ICustomerAccountProcessDal customerAccountProcessDal)
        {
            _customerAccountProcessDal = customerAccountProcessDal;
        }

        public void TAdd(CustomerAccountProcess t)
        {
            _customerAccountProcessDal.Insert(t);
        }

        public void TDelete(CustomerAccountProcess t)
        {
            _customerAccountProcessDal.Delete(t);
        }

        public CustomerAccountProcess TGetById(int id)
        {
            return _customerAccountProcessDal.GetById(id);
        }

        public List<CustomerAccountProcess> TGetList()
        {
            return _customerAccountProcessDal.GetList();
        }

        public void TUpdate(CustomerAccountProcess t)
        {
            _customerAccountProcessDal.Update(t);
        }
    }
}
