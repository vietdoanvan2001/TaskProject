using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskProject.Common.Entities.DTO
{
    public class PagingResult
    {
        /// <summary>
        /// Dữ liệu các nhân viên thoả mãn
        /// </summary>
        public List<Users> Data { get; set; }

        /// <summary>
        /// Tổng số bản ghi thoả mãn
        /// </summary>
        public int TotalRecord { get; set; }

        /// <summary>
        /// Bản ghi bắt đầu của trang
        /// </summary>
        public int Begin { get; set; }

        /// <summary>
        /// Bản ghi kết thúc của trang
        /// </summary>
        public int End { get; set; }

        #region Constructor
        /// <summary>
        /// Kết quả trả về khi phân trang
        /// </summary>
        /// <param name="data">danh sách các bản ghi thoả mãn</param>
        /// <param name="totalRecord">tổng số bản ghi trong DB</param>
        /// <param name="begin">index bản ghi bắt đầu của trang</param>
        /// <param name="end">index bản ghi kết thúc của trang</param>
        public PagingResult(List<Users> data, int totalRecord, int begin, int end)
        {
            Data = data;
            TotalRecord = totalRecord;
            Begin = begin;
            End = end;
        }
        #endregion
    }
}
