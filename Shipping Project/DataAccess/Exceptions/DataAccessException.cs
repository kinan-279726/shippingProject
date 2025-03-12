using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace DataAccess.Exceptions
{
    public class DataAccessException : Exception
    {
        public DataAccessException(Exception ex , string cutomExciptiont , ILogger logger) 
        {
            logger.LogError($"main exciption {ex.Message} develpoer cutome ex {cutomExciptiont}");
        }
    }
}
