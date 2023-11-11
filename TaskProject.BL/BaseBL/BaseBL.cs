using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskProject.Common;
using TaskProject.DL;
using TaskProject.DL.BaseDL;
using static TaskProject.Common.Attibutes.Attibutes;

namespace TaskProject.BL.BaseBL
{
    public class BaseBL<T> : IBaseBL<T>
    {
        #region Field

        private IBaseDL<T> _baseDL;

        #endregion

        #region Constructor

        public BaseBL(IBaseDL<T> baseDL)
        {
            _baseDL = baseDL;
        }

        #endregion
        #region Method
        #region Method
        /// <summary>
        /// Lấy tất cả các bản ghi
        /// </summary>
        /// <returns>Danh sách toàn bộ các bản ghi</returns>
        public ServiceResult GetAllRecords()
        {
            return _baseDL.GetAllRecords();
        }

        /// <summary>
        /// Xoá bản ghi theo id 
        /// </summary>
        /// <param name="recordId">id bản ghi muốn xoá</param>
        /// <returns>trạng thái thực hiện câu lệnh sql</returns>
        public ServiceResult DeleteRecordById(Guid recordId)
        {
            return _baseDL.DeleteRecordById(recordId);
        }

        /// <summary>
        /// Cập nhật thông tin bản ghi
        /// </summary>
        /// <param name="recordId">id bản ghi muốn cập nhật</param>
        /// <param name="record">thông tin cập nhật</param>
        /// <returns>trạng thái thực hiện câu lệnh sql</returns>
        public ServiceResult UpdateRecord(Guid recordId, T record)
        {

            var validateFailures = ValidateRecord(record);


            if (validateFailures.Count > 0)
            {
                return new ServiceResult(false, validateFailures);
            }

            var validateFailuresCustom = ValidateRecordCustom(record);

            //if(validateFailuresCustom.Count > 0)
            //{
            //    return new ServiceResult(false, validateFailuresCustom);
            //}

            var response = _baseDL.UpdateRecord(recordId, record);
            if (response.IsSuccess == true)
            {
                InsertDetailData(record, recordId);
                return response;
            }
            else
            {
                return response;
            }


        }

        /// <summary>
        /// Thêm mới thông tin bản ghi
        /// </summary>
        /// <param name="record">thông tin bản ghi</param>
        /// <returns>trạng thái khi thực hiện câu lệnh sql</returns>
        public ServiceResult InsertRecord(T record)
        {
            var validatefailures = ValidateRecord(record);

            if (validatefailures.Count > 0)
            {
                return new ServiceResult(false, validatefailures);
            }

            var validateFailuresCustom = ValidateRecordCustom(record);

            if (validateFailuresCustom.Count > 0)
            {
                return new ServiceResult(false, validateFailuresCustom);
            }

            var res = _baseDL.InsertRecord(record);

            if (res.IsSuccess == true)
            {
                InsertDetailData(record, (Guid)res.Data);
                return res;
            }
            else
            {
                return res;
            }

        }

        /// <summary>
        /// Validate chung
        /// </summary>
        /// <param name="record">form body thông tin cần validate</param>
        /// <returns>Danh sách lỗi</returns>
        public List<ErrorResult> ValidateRecord(T record)
        {
            var validateFailures = new List<ErrorResult>();
            var properties = typeof(T).GetProperties();

            foreach (var property in properties)
            {
                var propertyName = property.Name;
                var propertyValue = property.GetValue(record);
                var requiredAttribute = (NotEmptyAttribute?)property.GetCustomAttributes(typeof(NotEmptyAttribute), false).FirstOrDefault();

                //Validate các trường bắt buộc
                if (requiredAttribute != null && String.IsNullOrEmpty(propertyValue?.ToString()))
                {
                    validateFailures.Add(new ErrorResult
                    {
                        ErrorField = propertyName,
                        ErrorCode = ErrorCode.InvalidData,
                        DevMsg = Resource.Error_InvalidData,
                        UserMsg = Resource.Error_InvalidData,
                    });
                }


            }
            return validateFailures;
            #endregion
        }

        /// <summary>
        /// Cho phép các class khác override để custom validate riêng
        /// </summary>
        /// <param name="record">form body thông tin cần validate</param>
        /// <param name="isInsert">cờ xác định xem có phải API thêm mới không</param>
        /// <returns></returns>
        public virtual List<ErrorResult> ValidateRecordCustom(T record)
        {
            return new List<ErrorResult>();
        }

        /// <summary>
        /// hàm thêm thông tin vào bảng detail
        /// </summary>
        /// <param name="record"></param>
        /// <param name="recordId"></param>
        public virtual void InsertDetailData(T record, Guid id) { }
        #endregion
    }
}
