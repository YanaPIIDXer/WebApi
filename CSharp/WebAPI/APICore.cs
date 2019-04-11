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

			// 末尾が「/」で終わっていなかった場合、追加する。
			if(Host.Substring(Host.Length - 1) != "/")
			{
				Host += "/";
			}
		}

		/// <summary>
		/// ＡＰＩコマンドをＰＯＳＴで生成。
		/// </summary>
		/// <param name="API">ＡＰＩ</param>
		/// <returns>APICommandオブジェクト</returns>
		public APICommand CreatePost(string API)
		{
			string URL = Host + API;
			APICommand Command = APICommand.CraeteAsPost(URL);
			return Command;
		}

		/// <summary>
		/// ＡＰＩコマンドをＧＥＴで生成。
		/// </summary>
		/// <param name="API">ＡＰＩ</param>
		/// <returns>APICommandオブジェクト</returns>
		public APICommand CreateAsGet(string API)
		{
			string URL = Host + API;
			APICommand Command = APICommand.CreateAsGet(URL);
			return Command;
		}
	}
}
