using System;
using UserManagemant.Database;

namespace UserManagemant.Services
{
    public class UserCode
    {
        private readonly AppDbContext _appDbContext;
        private const int MinNumber = 10000;
        private const int MaxNumber = 99999;
        public UserCode()
        {
            _appDbContext = new AppDbContext();
        }


        public string GenarateAndReturnUniqueUserCode()
        {
            Random random = new Random();

            string userCode = "E" + random.Next(MinNumber, MaxNumber).ToString();

            while (_appDbContext.Employees.Any(e => e.UserCode == userCode))
            {
                userCode = "E" + random.Next(MinNumber, MaxNumber).ToString();
            }

            return userCode;
        }
    }
}
