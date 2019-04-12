/**
 * @author YanaP
 */
package WebAPI;

/**
 * APIコマンドレスポンス
 */
public interface APICommandResponse
{
	/**
	 * レスポンス
	 * @param content 取得したコンテンツ
	 */
	public abstract void onResponse(String content);
}
