/**
 * @author YanaP
 */
import WebAPI.*;

/**
 * テストクラス
 */
public class Test
{
	public static void main(String[] args)
	{
		APICore core = new APICore("http://qiita.com/api/v2/");
		APICommand testCommand = core.createGet("users?page=1&per_page=10");

		boolean result = testCommand.getResponse((content) ->
		{
			System.out.println(content);
		});

		if(!result)
		{
			System.out.println("Fuck");
			return;
		}
	}
}
