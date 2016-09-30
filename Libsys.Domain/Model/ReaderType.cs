namespace Libsys.Domain.Model
{
    /// <summary>
    /// 读者类型
    /// </summary>
    public partial class ReaderType
    {
        public string TypeName { get; set; }    //类型名称
        public int BookMaxBorrowed { get; set; }    //最大借阅册数
        public int BookMaxReserved { get; set; }    //最大预约册数
        public int LoanPeriod { get; set; }     //借期
        public bool Reserved { get; set; }      //是否可以预约
        public bool Renewed { get; set; }       //是否可以续借
    }
}
