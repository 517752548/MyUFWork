using app.net;
using app.zone;
using UnityEngine;
using UnityEngine.UI;

namespace app.corp
{
    public class CreateCorpView : BaseUI
    {
        public CreateBangPaiUI UI;

        public InputField mingchengInputText;
        public InputField zongzhiInputText;

        public MoneyItemScript costMoney;

        public CreateCorpView(CreateBangPaiUI ui)
        {
            UI = ui;
            UI.quxiao.SetClickCallBack(clickClose);
            //UI.closeBtn.SetClickCallBack(clickClose);
            UI.createBangPaiBtn.SetClickCallBack(clickCreate);
        }

        private void clickClose()
        {
            UI.gameObject.SetActive(false);
        }

        private void clickCreate()
        {
            //检查名称
            if (mingchengInputText.text.Length == 0)
            {
                ZoneBubbleManager.ins.BubbleSysMsg(LangConstant.CORPNAME_CANNOT_EMPTY);
                return;
            }
            else if (mingchengInputText.text.Length < 2 || mingchengInputText.text.Length > 12)
            {
                ZoneBubbleManager.ins.BubbleSysMsg(LangConstant.CORPNAME_BUHEFA);
                return;
            }
            //检查货币
            int createCost = int.Parse(ConstantModel.Ins.GetStringValueByKey(ServerConstantDef.CREATE_CORP_COST_GOLD));
            MoneyCheck.Ins.Check(CurrencyTypeDef.GOLD,createCost, (RMetaEvent) =>
            {
                CorpsCGHandler.sendCGCreateCorps(mingchengInputText.text, zongzhiInputText.text);
                clickClose();
            });
        }

        /// <summary>
        /// 显示创建帮派界面
        /// </summary>
        public void showCreate()
        {
            UI.gameObject.SetActive(true);

            if (mingchengInputText == null)
            {
                mingchengInputText = CreateInputField(Color.black, 20, UI.mingchengInputBg);
            }
            if (zongzhiInputText == null)
            {
                zongzhiInputText = CreateInputField(Color.black, 20, UI.zongzhiInputBg);
            }
            if (costMoney == null)
            {
                costMoney = new MoneyItemScript(UI.moneyItem);
            }
            int createCost = int.Parse(ConstantModel.Ins.GetStringValueByKey(ServerConstantDef.CREATE_CORP_COST_GOLD));
            costMoney.SetMoney(CurrencyTypeDef.GOLD, createCost, true, false);
            zongzhiInputText.text = LangConstant.WELCOME_ENTRY_CORP;
        }

        public void updateRoleMoney()
        {
            if (costMoney != null)
            {
                int createCost = int.Parse(ConstantModel.Ins.GetStringValueByKey(ServerConstantDef.CREATE_CORP_COST_GOLD));
                costMoney.SetMoney(CurrencyTypeDef.GOLD, createCost, true, false);
            }
        }

        public override void Destroy()
        {
            mingchengInputText=null;
            zongzhiInputText=null;

            if (costMoney != null)
            {
                costMoney.Destroy();
            }
            costMoney = null;
            base.Destroy();
            UI = null;
        }
    }
}