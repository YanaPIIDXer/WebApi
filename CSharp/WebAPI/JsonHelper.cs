using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;

namespace WebAPI
{
	/// <summary>
	/// Jsonヘルパーメソッド群
	/// </summary>
	public static class JsonHelper
	{
		/// <summary>
		/// シリアライズ
		/// </summary>
		/// <param name="Obj">オブジェクト</param>
		/// <returns>シリアライズされたJson文字列</returns>
		public static string Serialize(object Obj)
		{
			string Json = "";
			using (MemoryStream MemStream = new MemoryStream())
			{
				var Serializer = new DataContractJsonSerializer(Obj.GetType());
				Serializer.WriteObject(MemStream, Obj);
				Json = Encoding.UTF8.GetString(MemStream.ToArray());
			}
			return Json;
		}

		/// <summary>
		/// デシリアライズ
		/// </summary>
		/// <typeparam name="T">オブジェクトの型</typeparam>
		/// <param name="SourceStream">ストリーム</param>
		/// <returns>デシリアライズされたオブジェクト</returns>
		public static T Deserialize<T>(Stream SourceStream)
		{
			var Serializer = new DataContractJsonSerializer(typeof(T));
			return (T)Serializer.ReadObject(SourceStream);
		}

		/// <summary>
		/// デシリアライズ
		/// </summary>
		/// <typeparam name="T">オブジェクトの型</typeparam>
		/// <param name="Json">Json文字列</param>
		/// <returns>デシリアライズされたオブジェクト</returns>
		public static T Deserialize<T>(string Json)
		{
			using (MemoryStream SourceStream = new MemoryStream(Encoding.UTF8.GetBytes(Json)))
			{
				return Deserialize<T>(SourceStream);
			}
		}
	}
}
