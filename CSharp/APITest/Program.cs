using System;
using WebAPI;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Collections;
using System.Collections.Generic;

#pragma warning disable 649

namespace APITest
{
	class Program
	{
		[DataContract]
		class UserData
		{
			[DataMember]
			public string description;

			[DataMember]
			public string facebook_id;

			[DataMember]
			public int followees_count;

			[DataMember]
			public int followers_count;

			[DataMember]
			public string github_login_name;

			[DataMember]
			public string id;

			[DataMember]
			public int items_count;

			[DataMember]
			public string linkedin_id;

			[DataMember]
			public string location;

			[DataMember]
			public string name;

			[DataMember]
			public string organization;

			[DataMember]
			public int permanent_id;

			[DataMember]
			public string profile_image_url;

			[DataMember]
			public bool team_only;

			[DataMember]
			public string twitter_screen_name;

			[DataMember]
			public string website_url;
		}
		
		static void Main(string[] args)
		{
			APICore Core = new APICore("http://qiita.com/api/v2/");
			var Command = Core.CreateAsGet("users?page=1&per_page=50");
			Command.GetResponse((Response) =>
			{
				Console.WriteLine("URI:" + Response.ResponseUri.ToString() + "\n");
				var Serializer = new DataContractJsonSerializer(typeof(IList<UserData>));
				IList<UserData> Users = (IList<UserData>)Serializer.ReadObject(Response.GetResponseStream());
				if(Users == null)
				{
					Console.WriteLine("Fuck!!");
					return;
				}
				foreach(var User in Users)
				{
					Console.WriteLine("Id:" + User.id);
				}
			});
		}
	}
}
