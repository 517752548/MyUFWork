public interface IConfigData
{
    void OnLoadSuccess(string asset);

    void OnLoadError(string error);
}