using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI
{
	/// <summary>
	/// ＡＰＩのコアクラス
	/// </summary>
	public class APICore
	{

		/// <summary>
		/// ホスト
		/// </summary>
		private string Host;

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="InHost">ホスト</param>
		APICore(string InHost)
		{
			Host = InHost;
		}
		
	}
}
