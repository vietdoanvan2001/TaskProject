﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskProject.BL.BaseBL;
using TaskProject.Common;
using TaskProject.Common.Entities;

namespace TaskProject.BL
{
    public interface IUserBL: IBaseBL<Users>
    {
        /// <summary>
        /// Đăng nhập
        /// </summary>
        /// <param name="acc"></param>
        /// <returns></returns>
        public ServiceResult Login(Account acc);

        /// <summary>
        /// Lấy các user đang hoạt động
        /// </summary>
        /// <param name="acc"></param>
        /// <returns></returns>
        public ServiceResult getUser(UserFilterParam param);
    }
}
