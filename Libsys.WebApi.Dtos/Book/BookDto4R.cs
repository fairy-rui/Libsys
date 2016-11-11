using Apstars.Application.Dto;
using System;

namespace Libsys.WebApi.Dtos
{
    /// <summary>
    /// 查看书籍DTO 
    /// </summary>
    public class BookDto4R : EntityDto
    {
        public string Name { get; set; }    //名称
        public string Description { get; set; } //描述信息       
        public DateTime? PublishDate { get; set; }  //出版日期  
        public string PublisherName { get; set; }    //出版社
        public string ISBN { get; set; }    //ISBN      
        public decimal UnitPrice { get; set; }  //价格
    }
}
