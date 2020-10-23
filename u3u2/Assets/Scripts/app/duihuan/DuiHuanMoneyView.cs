using app.human;
using app.net;
using app.pet;
using app.db;

namespace app.duihuan
{
    public class DuiHuanMoneyView:BaseWnd
    {

        public DuiHuanMoneyView()
        {
            uiName = "DuihuanMoneyUI";
        }

        private static DuiHuanMoneyView ins;
        /// <summary>
        /// 1金子兑换100银子
        /// 1金票兑换100银票
        /// </summary>
        private int duihuanRate = 100;

        private DuihuanMoneyUI UI;
        private InputTextUIScript shuliang;
        private MoneyItemScript huode;
        private MoneyItemScript yongyou;
        private int duihuanMoneyKey;

        public static DuiHuanMoneyView Ins
        {
            get
            {
                if (ins==null)
                {
                    ins = new DuiHuanMoneyView();
                }
                return ins;
            }
        }

        public override void initWnd()
        {
            base.initWnd();
            UI = ui.AddComponent<DuihuanMoneyUI>();
            UI.Init();
            UI.tbg.TabChangeHandler = onChangeTab;
            shuliang = new InputTextUIScript(UI.shuliang);
            shuliang.setCanChange();
            shuliang.setCanInputNum(7);
            shuliang.setDefaultValue(1,0);
            shuliang.TabChangeHandler = changeShuliang;
            huode = new MoneyItemScript(UI.huafei);
            yongyou = new MoneyItemScript(UI.yongyou);
            
            UI.closeBtn.SetClickCallBack(clickClose);
            UI.duihuanBtn.SetClickCallBack(clickDuiHuan);

            PetModel.Ins.addChangeEvent(PetModel.UPDATE_HUMAN_PROP, updateCurrency);
        }

        public void updateCurrency(RMetaEvent e)
        {
            switch (UI.tbg.index)
            {
                case 0:
                    yongyou.SetMoney(CurrencyTypeDef.BOND, Human.Instance.GetCurrencyValue(CurrencyTypeDef.BOND), false, false);
                    break;
                case 1:
                    yongyou.SetMoney(CurrencyTypeDef.GIFT_BOND, Human.Instance.GetCurrencyValue(CurrencyTypeDef.GIFT_BOND), false, false);
                    break;
                case 2:
                    yongyou.SetMoney(CurrencyTypeDef.BOND, Human.Instance.GetCurrencyValue(CurrencyTypeDef.BOND), false, false);
                    break;
            }
        }

        private void changeShuliang(int offset)
        {
            int zongjia = shuliang.CurrentValue * duihuanRate;

            switch (UI.tbg.index)
            {
                case 0:
                    huode.SetMoney(CurrencyTypeDef.GOLD_2,zongjia,false,false);
                    break;
                case 1:
                    huode.SetMoney(CurrencyTypeDef.GOLD, zongjia, false, false);
                    break;
                case 2:
                    huode.SetMoney(CurrencyTypeDef.GUA_JI_POINT2, zongjia, false, false);
                    break;
            }
        }

        private void onChangeTab(int tab)
        {
            switch (tab)
            {
                case 0:
                    shuliang.setData(1, 1, int.MaxValue, 1, CurrencyTypeDef.BOND);
                    huode.SetMoney(CurrencyTypeDef.GOLD_2, duihuanRate, false, false);
                    yongyou.SetMoney(CurrencyTypeDef.BOND, Human.Instance.GetCurrencyValue(CurrencyTypeDef.BOND), false, false);
                    UI.tipsTxt.text = "注:1金子可兑换"+duihuanRate+"银子，兑换必须为整数单位。";
                    UI.title.text = "金子兑换银子";
                    break;
                case 1:
                    shuliang.setData(1, 1, int.MaxValue, 1, CurrencyTypeDef.GIFT_BOND);
                    huode.SetMoney(CurrencyTypeDef.GOLD, duihuanRate, false, false);
                    yongyou.SetMoney(CurrencyTypeDef.GIFT_BOND, Human.Instance.GetCurrencyValue(CurrencyTypeDef.GIFT_BOND), false, false);
                    UI.tipsTxt.text = "注:1金票可兑换" + duihuanRate + "银票，兑换必须为整数单位。";
                    UI.title.text = "金票兑换银票";
                    break;
                case 2:
                    shuliang.setData(1, 1, int.MaxValue, 1, CurrencyTypeDef.BOND);
                    huode.SetMoney(CurrencyTypeDef.GUA_JI_POINT2, duihuanRate, false, false);
                    yongyou.SetMoney(CurrencyTypeDef.BOND, Human.Instance.GetCurrencyValue(CurrencyTypeDef.BOND), false, false);
                    UI.tipsTxt.text = "注:1金子可兑换"+duihuanRate+"挂机点，兑换必须为整数单位。";
                    UI.title.text = "金子兑换挂机点";
                    break;
            }
        }

        public void ShowDuiHuan(int duihuanMoneyKeyv)
        {
            duihuanMoneyKey = duihuanMoneyKeyv;
            preLoadUI();
        }

        public override void show(RMetaEvent e = null)
        {
            base.show(e);

            switch (duihuanMoneyKey)
            {
                case CurrencyTypeDef.GOLD_2:
                    duihuanRate = ExchangeTemplateDB.Instance.GetScale(CurrencyTypeDef.BOND, CurrencyTypeDef.GOLD_2);
                    UI.tbg.SetIndexWithCallBack(0);
                    break;
                case CurrencyTypeDef.GOLD:
                    duihuanRate = ExchangeTemplateDB.Instance.GetScale(CurrencyTypeDef.GIFT_BOND, CurrencyTypeDef.GOLD);
                    UI.tbg.SetIndexWithCallBack(1);
                    break;
                case CurrencyTypeDef.GUA_JI_POINT2:
                    duihuanRate = ExchangeTemplateDB.Instance.GetScale(CurrencyTypeDef.BOND, CurrencyTypeDef.GUA_JI_POINT2);
                    UI.tbg.SetIndexWithCallBack(2);
                    break;
            }
        }

        private void clickClose()
        {
            hide();
        }

        private void clickDuiHuan()
        {
            switch (UI.tbg.index)
            {
                case 0:
                    MoneyCheck.Ins.Check(CurrencyTypeDef.BOND, shuliang.CurrentValue,sureDuihuanYinzi);
                    break;
                case 1:
                    MoneyCheck.Ins.Check(CurrencyTypeDef.GIFT_BOND, shuliang.CurrentValue, sureDuihuanYinPiao);
                    break;
                case 2:
                    MoneyCheck.Ins.Check(CurrencyTypeDef.BOND, shuliang.CurrentValue, sureDuihuanGuaJiDian);
                    break;
            }
            
        }

        private void sureDuihuanYinzi(RMetaEvent e)
        {
            HumanCGHandler.sendCGCurrencyExchange(CurrencyTypeDef.BOND, shuliang.CurrentValue, CurrencyTypeDef.GOLD_2);
        }

        private void sureDuihuanYinPiao(RMetaEvent e)
        {
            HumanCGHandler.sendCGCurrencyExchange(CurrencyTypeDef.GIFT_BOND, shuliang.CurrentValue, CurrencyTypeDef.GOLD);
        }

        private void sureDuihuanGuaJiDian(RMetaEvent e)
        {
            HumanCGHandler.sendCGCurrencyExchange(CurrencyTypeDef.BOND, shuliang.CurrentValue, CurrencyTypeDef.GUA_JI_POINT2);
        }
        
        public override void Destroy()
        {
            PetModel.Ins.removeChangeEvent(PetModel.UPDATE_HUMAN_PROP, updateCurrency);
            UI.closeBtn.ClearClickCallBack();
            UI.duihuanBtn.ClearClickCallBack();

            shuliang.Destroy();
            huode.Destroy();
            yongyou.Destroy();

            base.Destroy();
        }

    }

}
