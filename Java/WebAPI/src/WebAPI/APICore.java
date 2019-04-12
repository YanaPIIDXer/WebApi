/**
 * @author YanaP
 */
package WebAPI;

/**
 * APIコアクラス
 */
public class APICore
{
	// ホスト
	private String host;

	/**
	 * コンストラクタ
	 * @param inHost ホスト
	 */
	public APICore(String inHost)
	{
		host = inHost;
		// 末尾が「/」でなければ付加する。
		if(!host.substring(host.length() -1).equals("/"))
		{
			host += "/";
		}
	}

	/**
	 * APIコマンドをPOSTで生成。
	 * @param api API
	 * @return コマンドオブジェクト
	 */
	public APICommand createPost(String api)
	{
		APICommand command = APICommand.createAsPost(host + api);
		return command;
	}

	/**
	 * APIコマンドをGETで生成。
	 * @param api API
	 * @return コマンドオブジェクト
	 */
	public APICommand createGet(String api)
	{
		APICommand command = APICommand.createAsGet(host + api);
		return command;
	}
}
