using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskProject.Common;
using TaskProject.Common.Entities;
using TaskProject.DL.BaseDL;

namespace TaskProject.DL
{
    public interface IUsersDL: IBaseDL<Users>
    {
        public ServiceResult Login(Account acc);

        public ServiceResult getUser(UserFilterParam param);

        public ServiceResult getUserByListID(string listID);

        public ServiceResult getUserByID(Guid id);
    }
}
