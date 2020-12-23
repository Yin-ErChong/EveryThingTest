using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EveryThingTest.Model
{
    public class 序列化ModelTest:BaseModel
    {
		/// <summary>
		/// 
		/// </summary>
		public DateTime TransactionTime { set; get; }
		/// <summary>
		/// 
		/// </summary>
		public string TransactionType { set; get; }
		/// <summary>
		/// 支出金额
		/// </summary>
		public decimal TradeOutAmount { set; get; }
		/// <summary>
		/// 收入金额
		/// </summary>
		public decimal TradeInAmount { set; get; }
		/// <summary>
		/// 
		/// </summary>
		public string MoneyType { set; get; }
		/// <summary>
		/// 
		/// </summary>
		public decimal? Balance { set; get; }
		/// <summary>
		/// 
		/// </summary>
		public string OtherAccountName { set; get; }
		/// <summary>
		/// 
		/// </summary>
		public string OtherAccountNumber { set; get; }
		/// <summary>
		/// 
		/// </summary>
		public string Summary { set; get; }
		/// <summary>
		/// 
		/// </summary>
		public int TurnoverFileId { set; get; }
	}
}
