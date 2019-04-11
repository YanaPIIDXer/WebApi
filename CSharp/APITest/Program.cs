using System;
using WebAPI;

namespace APITest
{
	class Program
	{
		static void Main(string[] args)
		{
			APICore Core1 = new APICore("http://Test1");
			Console.WriteLine(Core1.GetHost());

			APICore Core2 = new APICore("http://Test2/");
			Console.WriteLine(Core2.GetHost());
		}
	}
}
