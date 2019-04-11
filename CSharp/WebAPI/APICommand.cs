using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

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
			APICommand Command = new APICommand(URL, EHttpMethod.POST);
			return Command;
		}

		/// <summary>
		/// ＧＥＴとして生成
		/// </summary>
		/// <param name="URL">ＵＲＬ</param>
		/// <returns>APICommandオブジェクト</returns>
		public static APICommand CreateAsGet(string URL)
		{
			APICommand Command = new APICommand(URL, EHttpMethod.GET);
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
		/// POSTするデータ
		/// </summary>
		public string PostData { set; private get; }

		/// <summary>
		/// HTTPメソッド
		/// </summary>
		private enum EHttpMethod
		{
			/// <summary>
			/// POST
			/// </summary>
			POST,

			/// <summary>
			/// GET
			/// </summary>
			GET,
		}

		/// <summary>
		/// メソッド
		/// </summary>
		private EHttpMethod Method;

		/// <summary>
		/// レスポンスを取得。
		/// </summary>
		/// <returns></returns>
		public string GetResponse()
		{
			if(Method == EHttpMethod.POST && PostData != "")
			{
				// POSTする。
				byte[] Bytes = Encoding.ASCII.GetBytes(PostData);
				Request.ContentType = "application/x-www-form-urlencoded";
				Request.ContentLength = Bytes.Length;

				using (var RequestStream = Request.GetRequestStream())
				{
					RequestStream.Write(Bytes, 0, Bytes.Length);
				}
			}

			// レスポンス
			var Response = Request.GetResponse();
			string Ret = "";
			using (Response)
			{
				using (var ResponseStream = Response.GetResponseStream())
				{
					using (var ReadStream = new StreamReader(ResponseStream))
					{
						Ret = ReadStream.ReadToEnd();
					}
				}
			}
			return Ret;
		}

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="InURL">URL</param>
		/// <param name="InMethod">メソッド</param>
		private APICommand(string InURL, EHttpMethod InMethod)
		{
			URL = InURL;
			PostData = "";
			Method = InMethod;
			Request = CreateRequest();
		}

		/// <summary>
		/// WebRequestを生成。
		/// </summary>
		/// <returns>WebRequest</returns>
		private WebRequest CreateRequest()
		{
			WebRequest Req = WebRequest.Create(URL);
			if(Method == EHttpMethod.POST)
			{
				Req.Method = "POST";
			}
			else
			{
				Req.Method = "GET";
			}
			return Req;
		}
		
	}
}
