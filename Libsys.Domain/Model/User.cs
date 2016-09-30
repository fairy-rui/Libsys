using System;

namespace Libsys.Domain.Model
{
    /// <summary>
    /// 图书馆用户
    /// </summary>
    public partial class User
    {
        public string CredentialNo { get; set; }    //证件号（学工号）
        public string PasswordHash { get; set; }    //密码hash值
        public string IDNumber { get; set; }    //身份证号
        public string Name { get; set; }    //姓名
        public string Sex { get; set; }     //性别
        public string Phone { get; set; }   //手机
        public string Email { get; set; }   //邮箱
        public DateTime DateRegistered { get; set; }    //注册日期   
        public DateTime? DateLastAuthenticated { get; set; }    //最近授权日期
        public bool Locked { get; set; }    //是否锁住

    }
}
