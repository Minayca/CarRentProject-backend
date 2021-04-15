using Core.Entities.Concrete;
using Core.Utilities.Results;
using System.Collections.Generic;

namespace Core.Security.JWT
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user, List<OperationClaim> claims);
    }
}
