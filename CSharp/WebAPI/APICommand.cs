using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;

namespace WebAPI
{
	/// <summary>
	/// ＡＰＩのコマンド
	/// </summary>
	public class APICommand
	{

		#region Static Method

		/// <summary>
		/// ＰＯＳＴとして生成
		/// </summary>
		/// <param name="URL">ＵＲＬ</param>
		/// <returns>APICommandオブジェクト</returns>
		public static APICommand CraeteAsPost(string URL)
		{
			APICommand Command = new APICommand(URL, "POST");
			return Command;
		}

		/// <summary>
		/// ＧＥＴとして生成
		/// </summary>
		/// <param name="URL">ＵＲＬ</param>
		/// <returns>APICommandオブジェクト</returns>
		public static APICommand CreateAsGet(string URL)
		{
			APICommand Command = new APICommand(URL, "GET");
			return Command;
		}

		#endregion
		
		/// <summary>
		/// URL
		/// </summary>
		private string URL;

		/// <summary>
		/// Webリクエスト
		/// </summary>
		private WebRequest Request;

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="InURL">URL</param>
		/// <param name="Method">メソッド</param>
		private APICommand(string InURL, string Method)
		{
			URL = InURL;
			Request = CreateRequest(Method);
		}

		/// <summary>
		/// WebRequestを生成。
		/// </summary>
		/// <param name="Method">メソッド</param>
		/// <returns>WebRequest</returns>
		private WebRequest CreateRequest(string Method)
		{
			WebRequest Req = WebRequest.Create(URL);
			Req.Method = Method;
			return Req;
		}
		
	}
}
