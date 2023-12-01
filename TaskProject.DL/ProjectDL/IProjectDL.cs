using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskProject.Common;
using TaskProject.Common.Entities;
using TaskProject.DL.BaseDL;

namespace TaskProject.DL.ProjectDL
{
    public interface IProjectDL:IBaseDL<Project>
    {
        public ServiceResult UpdateByID(Project data);

        public ServiceResult GetByUserID(Guid id);
    }
}
