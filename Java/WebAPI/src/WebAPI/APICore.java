/**
 * @author YanaP
 */
package WebAPI;

import java.net.HttpURLConnection;

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
}
