using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TaskProject.BL.BaseBL;
using TaskProject.Common;
using TaskProject.Common.Funtions;
using TaskProject.DL;
using TaskProject.DL.BaseDL;
using static TaskProject.Common.Attibutes.Attibutes;

namespace TaskProject.BL
{
    public class UserBL : BaseBL<Users>, IUserBL
    {
        public IUsersDL _userDL;
        public IBaseDL<Users> _baseDL;

        public UserBL(IUsersDL userDL, IBaseDL<Users> baseDL) : base(userDL)
        {
            _userDL = userDL;
            _baseDL = baseDL;
        }

        /// <summary>
        /// Đăng nhập
        /// </summary>
        /// <param name="acc"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public ServiceResult Login(Account acc)
        {
            var result = _userDL.Login(acc);
            if(result != null && result.IsSuccess && result.Data != null)
            {
                EncodeFns encode = new EncodeFns();
                Users user = (Users)result.Data;
                if(encode.VerifyPassword(acc.Password, user.Password))
                {
                    return new ServiceResult(true, user);
                }
                else
                {
                    return new ServiceResult(false, Resource.Wrong_Account);
                }
            }
            return result;

        }

        #region Override
        /// <summary>
        /// Validate các dữ liệu đầu vào theo các rules validate của riêng class Employee
        /// author: VietDV(27/3/2023)
        /// </summary>
        /// <param name="record">form body dữ liệu cần validate</param>
        /// <param name="isInsert">cờ xác định xem có phải là API thêm mới không</param>
        /// <returns>Danh sách các lỗi</returns>
        public override List<ErrorResult> ValidateRecordCustom(Users record)
        {
            var validateFailuresCustom = new List<ErrorResult>();
            var properties = typeof(Users).GetProperties();

            foreach (var property in properties)
            {
                var propertyName = property.Name;
                var propertyValue = property.GetValue(record);

                var notDuplicateAttribute = (NotDuplicateAttribute?)property.GetCustomAttributes(typeof(NotDuplicateAttribute), false).FirstOrDefault();
                var isEmailAttribute = (IsEmailAttribute?)property.GetCustomAttributes(typeof(IsEmailAttribute), false).FirstOrDefault();
                var onlyNumberAttribute = (OnlyNumberAttribute?)property.GetCustomAttributes(typeof(OnlyNumberAttribute), false).FirstOrDefault();

                //validate trường không được trùng lặp
                //nếu là API thêm mới thì check mã nhân viên không trùng, là API sửa thì không check
                if (notDuplicateAttribute != null)
                {
                    var result = _baseDL.CheckDuplicateID(propertyValue.ToString());
                    if (result.IsSuccess == true)
                    {
                        validateFailuresCustom.Add(new ErrorResult
                        {
                            ErrorField = propertyName,
                            ErrorCode = ErrorCode.DuplicateCode,
                            DevMsg = Resource.DevMsg_ValidateFailed,
                            UserMsg = propertyName + "" + Resource.Duplicate,

                        });
                    }
                }

                //validate trường có định dạng email
                if (isEmailAttribute != null)
                {
                    if (propertyValue != null && propertyValue.ToString().Trim() != "")
                    {
                        bool isValidate = Regex.IsMatch(propertyValue.ToString(), @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                        if (!isValidate)
                        {
                            validateFailuresCustom.Add(new ErrorResult
                            {
                                ErrorField = propertyName,
                                ErrorCode = ErrorCode.WrongFormatEmail,
                                DevMsg = Resource.DevMsg_ValidateFailed,
                                UserMsg = propertyName + "" + Resource.WrongFormat,
                            });
                        }
                    }
                }

                //validate trường có định dạng chỉ chứa các chữ số
                if (onlyNumberAttribute != null)
                {
                    if (propertyValue != null && propertyValue.ToString().Trim() != "")
                    {
                        string value = propertyValue.ToString();
                        bool isNumeric = Regex.IsMatch(value, @"^\d+$");
                        if (!isNumeric)
                        {
                            validateFailuresCustom.Add(new ErrorResult
                            {
                                ErrorField = propertyName,
                                ErrorCode = ErrorCode.WrongFormatOnlyNumber,
                                DevMsg = Resource.DevMsg_ValidateFailed,
                                UserMsg = propertyName + "" + Resource.WrongOnlyNumberFormat
                            });
                        }
                    }
                }
            }

            return validateFailuresCustom;
        }
        #endregion
    }
}
