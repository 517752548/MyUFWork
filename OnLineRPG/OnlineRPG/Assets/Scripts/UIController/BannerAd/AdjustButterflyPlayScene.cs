public class AdjustButterflyPlayScene : AdjustPlaceScene
{
    protected override bool IsBannerAvailable()
    {
        return false;
    }

    protected override bool CanShowBannerForSelfReason()
    {
        return false;
    }
}