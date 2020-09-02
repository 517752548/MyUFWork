using System;
using BetaFramework;

public class SalePopupCommand : ICommand
{
    private bool m_RemainTimePop = false;
    public object Data { get; set; }

    public void Initilize()
    {
    }

    public void Execute()
    {
        try
        {
            var repGiftData = DataManager.GiftData;
            if (repGiftData == null) return;

            var type = (IapType)repGiftData.Type;
            if (type == IapType.SaleGift
                && (repGiftData.Config == null || string.IsNullOrEmpty(repGiftData.Config.Id)))
            {
                return;
            }

            var currentAbsLevel = AppEngine.SSystemManager.GetSystem<ClassicGameSystem>().currentLevel.Value;
//            var completeLevelPerDay = DataManager.PlayerData.CompleteLevelPerDay;
            var popTimesPerDay = DataManager.ShopData.PromotePopupTimesPerDay;

            //当前解锁关卡数小于礼包限定弹出的关卡数
            if (currentAbsLevel < repGiftData.FPL)
                return;

            //每天弹出次数达到上限
            if (popTimesPerDay >= repGiftData.PN)
                return;

//            //如果同步窗口弹出了，就不弹促销
//            if (UIManager.GetUI(ViewConst.prefab_SelectCloudProgressDialog) != null
//                || UIManager.GetUI(ViewConst.prefab_ChooseSyncDataTipDialog) != null
//                || UIManager.GetUI(ViewConst.prefab_ChooseSyncDataDialog) != null)
//            {
//                return;
//            }

            //每天过几关弹出
//            if (completeLevelPerDay != 0 && completeLevelPerDay % repGiftData.PL == 0)
//            {
//                ShowPromotionDialog(repGiftData);
//                return;
//            }

            //新手限时逻辑
            if (!m_RemainTimePop
                && repGiftData.Time <= repGiftData.PT)
            {
                ShowPromotionDialog(repGiftData);
                m_RemainTimePop = true;
            }
        }
        catch (Exception ex)
        {
            LoggerHelper.Exception(ex);
        }
    }

    public void Release()
    {
        m_RemainTimePop = false;
    }

    private void ShowPromotionDialog(RepGiftData data)
    {
        var type = (IapType)data.Type;
        switch (type)
        {
            case IapType.Normal:
                break;

            case IapType.NoviceGift:
                UIManager.OpenUIAsync(ViewConst.prefab_Promotion_NewPlayer_Dialog);
                ++DataManager.ShopData.PromotePopupTimesPerDay;
                break;

            case IapType.SaleGift:
                UIManager.OpenUIAsync(ViewConst.prefab_Promotion_Normal_Dialog);
                ++DataManager.ShopData.PromotePopupTimesPerDay;
                break;

            default:
                break;
        }
    }
}