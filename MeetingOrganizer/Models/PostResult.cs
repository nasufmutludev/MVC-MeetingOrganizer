using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCIntroduction.Models
{
    public class PostResult
    {
        public PostResult(bool isSuccess)
        {
            if (isSuccess)
            {
                IsSuccess = true;
                Message = "İşlem başarıyla gerçekleştirildi.";
            }
            else
            {
                Message = "İşlem gerçekleştirilemedi.";
            }
        }
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
    }
}