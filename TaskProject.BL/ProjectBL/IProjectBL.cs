using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskProject.BL.BaseBL;
using TaskProject.Common;
using TaskProject.Common.Entities;

namespace TaskProject.BL.ProjectBL
{
    public interface IProjectBL:IBaseBL<Project>
    {
        public ServiceResult UpdateByID(Project data);
    }
}
