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

        public ServiceResult getUserByListID(string listID);
        public ServiceResult getUserByID(Guid id);

        public ServiceResult DeleteByListID(string listID);

        public ServiceResult UpdateStatus(UpdateUserStatus param);

        public ServiceResult AddToTrash(UpdateUserStatus param);

        public ServiceResult GetUsersInTrash();

        public ServiceResult UpdatePassword(UpdatePasswordParam param);
    }
}
