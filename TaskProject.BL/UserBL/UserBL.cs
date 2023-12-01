using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TaskProject.BL.BaseBL;
using TaskProject.Common;
using TaskProject.Common.Entities;
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
        private IConfiguration _configuration;

        public UserBL(IUsersDL userDL, IBaseDL<Users> baseDL, IConfiguration configuration) : base(userDL)
        {
            _userDL = userDL;
            _baseDL = baseDL;
            _configuration = configuration;
        }

        /// <summary>
        /// Lấy các user đang hoạt động
        /// </summary>
        /// <param name="acc"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public ServiceResult getUser(UserFilterParam param)
        {
            var result = _userDL.getUser(param);
            return result;
        }

        public ServiceResult getUserByID(Guid id)
        {
            var result = _userDL.getUserByID(id);
            return result;
        }

        public ServiceResult getUserByListID(string listID)
        {
            var result = _userDL.getUserByListID(listID);
            return result;
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
                    var temp = new 
                    {
                        data = user,
                        token = GenarateToken(user)
                    };
                    return new ServiceResult(true, temp);
                }
                else
                {
                    return new ServiceResult(false, Resource.Wrong_Account);
                }
            }
            return result;

        }

        //public string GenarateToken(Users user)
        //{
        //    // Khóa bí mật để ký token (thay thế bằng khóa thực tế trong ứng dụng thực)
        //    string secretKey = "TheRandomKeyCreatedByDoanVanViet";
        //    var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(secretKey));

        //    // Tạo thông tin tuyển dụng
        //    var claims = new[]
        //    {
        //    new Claim(JwtRegisteredClaimNames.Name, user.FullName),
        //    new Claim(JwtRegisteredClaimNames.Email, user.Email),
        //    new Claim("UserID", user.Id.ToString())
        //};

        //    // Tạo token
        //    var token = new JwtSecurityToken(
        //        issuer: "http://localhost:8080/",        // Địa chỉ phát hành token
        //        audience: "http://localhost:8080/",    // Địa chỉ sử dụng token
        //        claims: claims,
        //        expires: DateTime.UtcNow.AddMinutes(2),  // Thời điểm hết hạn của token
        //        signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
        //    );

        //    // Chuyển đổi token thành chuỗi JWT
        //    var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);
        //    return jwtToken;
        //}

        public string GenarateToken(Users user)
        {
            // Tạo thông tin tuyển dụng
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Name, user.FullName),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("UserID", user.Id.ToString()) };
            var securitykey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securitykey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                _configuration["jwt:issuer"], _configuration["jwt:audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(1),
                signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
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
                            UserMsg = Resource.Duplicate,

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

        public ServiceResult DeleteByListID(string listID)
        {
            var res = _userDL.DeleteByListID(listID);
            return res;
        }

        public ServiceResult UpdateStatus(UpdateUserStatus param)
        {
            var res = _userDL.UpdateStatus(param);
            return res;
        }

        public ServiceResult AddToTrash(UpdateUserStatus param)
        {
            var res = _userDL.AddToTrash(param);
            return res;
        }



        public ServiceResult GetUsersInTrash()
        {
            var res = _userDL.GetUsersInTrash();
            return res;
        }

        public ServiceResult UpdatePassword(UpdatePasswordParam param)
        {
            var temp = new Account();
            temp.UserName = param.UserName;
            temp.Password = param.OldPassword;

            var result = Login(temp);
            if(result != null && !result.IsSuccess)
            {
                return result;
            }
            EncodeFns encode = new EncodeFns();
            param.NewPassword = encode.HashPassword(param.NewPassword);
            
            var res = _userDL.UpdatePassword(param);
            return res;
        }
        #endregion
    }
}
