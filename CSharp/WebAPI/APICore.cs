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
		public APICore(string InHost)
		{
			Host = InHost;
			if(Host.Substring(Host.Length - 1) != "/")
			{
				Host += "/";
			}
		}

		#region Test

		/// <summary>
		/// ホストを取得。
		/// </summary>
		/// <returns>ホスト</returns>
		public string GetHost()
		{
			return Host;
		}

		#endregion

	}
}
