
public class CommonDefines
{
    private const EVersionDefines VERSION_BUILD = EVersionDefines.VERSION_DEVELOMENT;
    public const int FPS = 30;
    public const int MAX_CHARACTERS_ON_SCENE = 500;
    public const string DEFAULT_FONT_NAME = "FZLanTingHei_Font";
    public const string REC_UPLOAD_URL = "http://www.wingloong.com/tapfaster/uploadfile";

    private enum EVersionDefines
    {
        VERSION_DEVELOMENT,
        VERSION_MAX
    }

    public static bool isDeversion()
    {
        return (VERSION_BUILD == EVersionDefines.VERSION_DEVELOMENT);
    }

    public static bool VersionShowFPS()
    {
        if (isDeversion())
            return true;
        return false;
    }

    public static bool NeedReportGameInfo()
    {
        if (isDeversion())
            return false;
        return true;
    }
}

