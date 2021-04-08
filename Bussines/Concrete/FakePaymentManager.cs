using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class FakePaymentManager : IPaymentService
    {
        public IResult Payment()
        {
            var random = new Random().Next(2);
            if (random == 0) return new ErrorResult(Messages.PaymentFailed);

            return new SuccessResult(Messages.PaymentSuccessful);
        }
    }
}
