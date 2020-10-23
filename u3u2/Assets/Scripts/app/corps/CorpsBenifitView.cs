using UnityEngine;
using System.Collections.Generic;
using app.net;
using app.db;
using app.utils;
using app.zone;
using app.model;



namespace app.corp
{
    public class CorpsBenifitView : BaseUI
    {
        private BangPaiFuLiUI mFuliUI;
        private CorpModel mCorpModel;
        private CorpsBenifitInfo mCorpsBenifitInfo;

        private bool mCanReward = false;
        private bool mHaveClick = false;
        private MoneyItemScript m_moneyItemScript;
        public CorpsBenifitView(BangPaiFuLiUI fuliUI)
        {
            mFuliUI = fuliUI;
            mCorpModel = CorpModel.Ins;
            mFuliUI.fuliItemUI.buttonReward.SetClickCallBack(OnClickReward);
            mFuliUI.fuliJinengUI.buttonReward.SetClickCallBack(OnClickItemFuzhu);
            mFuliUI.xiulianJinengUI.buttonReward.SetClickCallBack(OnClickJinengXiulian);
            mFuliUI.bangpaiHongBaoUI.buttonReward.SetClickCallBack(OnClickHongbao);
            mCorpModel.addChangeEvent(CorpModel.GET_CORPS_BENIFITINFO, UpdateCorpsBenifit);
        }

        public void CallBenifitData()
        {
            CorpsCGHandler.sendCGOpenCorpsBenifitPanel();
        }


        private void UpdateCorpsBenifit(RMetaEvent e = null)
        {
            if (e.data == null)
            {
                return;
            }
            mCorpsBenifitInfo = e.data as CorpsBenifitInfo;
            SetData();
        }

        private void SetData()
        {
            if (mCorpsBenifitInfo == null)
            {
                ClientLog.LogError("benifitinfo is null");
                return;
            }
            CorpsBenifitTemplate tpl = null;
            Dictionary<int,CorpsBenifitTemplate> templates = CorpsBenifitTemplateDB.Instance.getIdKeyDic();
            foreach (var item in templates)
            {
                if (mCorpsBenifitInfo.lastWeekContribution >= item.Value.ContributionFoot
                    && mCorpsBenifitInfo.lastWeekContribution <= item.Value.ContributionTop)
                {
                    tpl = item.Value;
                    break;
                }
            }
            if (tpl != null)
            {
                double factor = GetRewardFactor(mCorpModel.MyCorpMemberInfo.getCorpsMemInfo().memJob);

                if (mCorpsBenifitInfo.canReceive == 1)
                {
                    if (!mFuliUI.fuliItemUI.buttonReward.IsInteractable())
                    {
                        ColorUtil.DeGray(mFuliUI.fuliItemUI.buttonReward);
                        mFuliUI.fuliItemUI.buttonReward.interactable = true;
                    }
                    
                    mCanReward = true;
                    mHaveClick = false;
                }
                else
                {
                    if (mFuliUI.fuliItemUI.buttonReward.IsInteractable())
                    {
                        mFuliUI.fuliItemUI.buttonReward.interactable = false;
                        ColorUtil.Gray(mFuliUI.fuliItemUI.buttonReward);
                    }
                    
                    mCanReward = false;
                }
                if (null == m_moneyItemScript)
                {
                    m_moneyItemScript = new MoneyItemScript(mFuliUI.fuliItemUI.moneyItemUI);
                }
                long finalNum = mCanReward ? (long)(tpl.currencyNum * factor) : 0;
                m_moneyItemScript.SetMoney(tpl.currencyType, finalNum, false);
            }
            else
            {
                ClientLog.LogError("benifit template is null " + mCorpsBenifitInfo.lastWeekContribution);
            }

        }

        private void OnClickReward()
        {
            if (mCanReward && !mHaveClick)
            {
                mHaveClick = true;
                CorpsCGHandler.sendCGGetBenifit();
            }
            else
            {
                ZoneBubbleManager.ins.BubbleSysMsg(LangConstant.NOREWARD_CUR_WEAK);
            }
        }

        public void OnClickItemFuzhu()
        {
            if (FunctionModel.Ins.IsFuncOpen(FunctionIdDef.BANGPAIFUZHU))
            {
                LinkParse.Ins.linkToFunc(FunctionIdDef.BANGPAIFUZHU);
            }
            else
            {
                ZoneBubbleManager.ins.BubbleSysMsg("功能尚未开启");
            }
        }

        public void OnClickJinengXiulian()
        {
           
            if (FunctionModel.Ins.IsFuncOpen(FunctionIdDef.BANGPAIXIULIAN))
            {
                LinkParse.Ins.linkToFunc(FunctionIdDef.BANGPAIXIULIAN);
            }
            else
            {
                ZoneBubbleManager.ins.BubbleSysMsg("功能尚未开启");
            }
        }

        public void OnClickHongbao()
        {
            LinkParse.Ins.linkToFunc(FunctionIdDef.BANGPAIHONGBAO);
        }

        public double GetRewardFactor(int level)
        { 
            switch(level)
            {
                case (int)CorpTitleDef.CorpTitleType.BANGZHU:
                    return  ConstantModel.Ins.GetDoubleValueByKey(ServerConstantDef.PRESIDENT_BENIFIT_COEF);
                case (int)CorpTitleDef.CorpTitleType.FUBANGZHU:
                    return ConstantModel.Ins.GetDoubleValueByKey(ServerConstantDef.VICECHAIRMAN_BENIFIT_COEF);
                case (int)CorpTitleDef.CorpTitleType.JINGYING:
                    return ConstantModel.Ins.GetDoubleValueByKey(ServerConstantDef.ELITE_BENIFIT_COEF);
                default:
                    return 1;              
            }
        }

        public override void Destroy()
        {
            if (null != m_moneyItemScript)
            {
                m_moneyItemScript.Destroy();
            }
            mCorpsBenifitInfo = null;
            mCorpModel.removeChangeEvent(CorpModel.GET_CORPS_BENIFITINFO, UpdateCorpsBenifit);
            base.Destroy();
            mFuliUI = null;
        }
       

        

    }
}
