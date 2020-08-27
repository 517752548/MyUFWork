public interface IDownloadListener
{
    void OnError(int transactionId, string errorMessage);

    void OnUpdate(int transactionId, float progress);

    void OnSuccess(int transactionId, byte[] bytes);
}