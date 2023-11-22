using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskProject.Common;

namespace TaskProject.DL.BaseDL
{
    public interface IBaseDL<T>
    {
        /// <summary>
        /// Kết nối tới database
        /// </summary>
        /// <returns></returns>
        public IDbConnection GetOpenConnection();

        public ServiceResult GetByID(int id);

        /// <summary>
        /// Lấy tất cả các bản ghi
        /// </summary>
        /// <returns>Danh sách toàn bộ các bản ghi</returns>
        public ServiceResult GetAllRecords();

        /// <summary>
        /// Thêm mới thông tin bản ghi
        /// </summary>
        /// <param name="record">thông tin bản ghi</param>
        /// <returns>trạng thái khi thực hiện câu lệnh sql</returns>
        public ServiceResult InsertRecord(T record);

        /// <summary>
        /// Cập nhật thông tin bản ghi
        /// </summary>
        /// <param name="recordId">id bản ghi muốn cập nhật</param>
        /// <param name="record">thông tin cập nhật</param>
        /// <returns>trạng thái thực hiện câu lệnh sql</returns>
        public ServiceResult UpdateRecord(Guid recordId, T record);

        /// <summary>
        /// Xoá bản ghi theo id 
        /// </summary>
        /// <param name="recordId">id bản ghi muốn xoá</param>
        /// <returns>trạng thái thực hiện câu lệnh sql</returns>
        public ServiceResult DeleteRecordById(Guid recordId);
        public ServiceResult DeleteRecordByIntId(int recordId);

        /// <summary>
        /// Kiểm tra id đã xuất hiện trong DB chưa
        /// </summary>
        /// <param name="id">id muốn kiểm tra</param>
        /// <returns>trạng thái thực hiện câu lệnh sql</returns>
        public ServiceResult CheckDuplicateID(string id);

    }
}
