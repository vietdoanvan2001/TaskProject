using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskProject.BL.BaseBL;
using TaskProject.Common;
using TaskProject.Common.Entities;
using TaskProject.DL.BaseDL;
using TaskProject.DL;
using TaskProject.DL.ProjectDL;

namespace TaskProject.BL.ProjectBL
{
    public class ProjectBL : BaseBL<Project>, IProjectBL
    {
        public IProjectDL _projectDL;
        public IBaseDL<Project> _baseDL;

        public ProjectBL(IProjectDL projectDL,IBaseDL<Project> baseDL) : base(baseDL)
        {
            _projectDL = projectDL;
            _baseDL = baseDL;
        }

        public ServiceResult UpdateByID(Project data)
        {
            var res = _projectDL.UpdateByID(data);
            return res;
        }
    }
}
