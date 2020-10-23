using app.human;
using app.model;
using app.pet;
using app.zone;
using UnityEngine;
using app.chenghao;
using System.Collections.Generic;
using app.state;
using app.battle;

namespace app.role
{
    public class RoleInfoScript:BaseUI
    {
        public RoleInfoUI UI;
        public CorpModel corpModel;
        public PetModel petmodel;
        private int[] useHuoliFuncId = {/*FunctionIdDef.CAIKUANG,*/FunctionIdDef.BANGPAIFUZHU};

        public RoleInfoScript(RoleInfoUI ui)
        {
            UI = ui;
            base.ui = ui.gameObject;
            corpModel = CorpModel.Ins;
            petmodel = PetModel.Ins;
            
            UI.shengmingCunchu.LabelType = ProgressBarLabelType.None;
            UI.faliCunchu.LabelType = ProgressBarLabelType.None;
            UI.ShouMingChi.LabelType = ProgressBarLabelType.None;
            UI.UpChengHaoBtn.AddClickCallBack(OpenChenghaoPanel);
            //UI.useHuoli.SetClickCallBack(OnClickUseHuoli);
            EventTriggerListener.Get(UI.roleChengHao.gameObject).onClick = openChenghao;
            InitUseHuoliList();
        }

        private void InitUseHuoliList()
        {
            //UI.defaultUseHuoliItemUI.gameObject.SetActive(false);
            //UI.objUseHuoli.SetActive(false);
            List<string> listdata = new List<string>();
            for (int i=0;i<useHuoliFuncId.Length;i++)
            {
                listdata.Add(FunctionIdDef.GetFuncNameById(useHuoliFuncId[i]));
            }

            UI.huoliDropDown.updateDropDownList(listdata);
            UI.huoliDropDown.TabChangeHandler = DropdownEvent;
        }

        private void DropdownEvent(int selectTab)
        {
            if (selectTab < useHuoliFuncId.Length)
            {
                if (FunctionModel.Ins.IsFuncOpen(useHuoliFuncId[selectTab]))
                {
                    LinkParse.Ins.linkToFunc(useHuoliFuncId[selectTab]);
                }
                else
                {
                    ZoneBubbleManager.ins.BubbleSysMsg("功能尚未开启");
                }
            }
        }


        private void openChenghao(GameObject go)
        {
            OpenChenghaoPanel();
        }
        /// <summary>
        /// 打开称号面板
        /// </summary>
        public void OpenChenghaoPanel()
        {
            ChenghaoModel.Ins.OpenChenghaoPanel();
        }

        public void updateData()
        {
            AddRoleModelToUI(Vector3.zero, Vector3.one, Human.Instance.PetModel.getLeader().getTpl(), UI.modelContainer);
            Human.Instance.updateSelfWeapon(avatarBase);
            Pet mainRole = Human.Instance.PetModel.getLeader();
            UI.roleName.text = Human.Instance.getName();
            UI.roleLevel.text = "Lv " + mainRole.getLevel();
            int hascorp = Human.Instance.PropertyManager.getIntProp(RoleBaseIntProperties.HAS_CORPS);
            if (hascorp == 1 && corpModel.MyCorpInfo != null && corpModel.MyCorpInfo.getDetailCorpsInfo() != null)
            {
                UI.bangpai.text = corpModel.MyCorpInfo.getDetailCorpsInfo().name;
            }
            else
            {
                UI.bangpai.text = "无";
            }
            //UI.xingbie.text = mainRole.getSexName();
            //UI.zhiye.text = mainRole.getJobName();

            UI.ShengMingPB.LabelType = ProgressBarLabelType.CurrentAndMax;
            UI.ShengMingPB.MaxValue = mainRole.PropertyManager.getPetIntProp(PetBProperty.HP);

            UI.HuoLiPB.LabelType = ProgressBarLabelType.CurrentAndMax;
            UI.HuoLiPB.MaxValue = ConstantModel.Ins.GetIntValueByKey(ServerConstantDef.HUOLI_KEY);
            double huoli = 0;
            double.TryParse(Human.Instance.PropertyManager.getStringProp(RoleBaseStrProperties.HUOLI), out huoli);
            UI.HuoLiPB.Value = huoli;
          //  UI.HuoLiPB.Value = double.Parse(Human.Instance.PropertyManager.getStringProp(RoleBaseStrProperties.HUOLI));

            UI.FaLiPB.LabelType = ProgressBarLabelType.CurrentAndMax;
            UI.FaLiPB.MaxValue = mainRole.PropertyManager.getPetIntProp(PetBProperty.MP);

            UI.NuQiPB.LabelType = ProgressBarLabelType.CurrentAndMax;
            UI.NuQiPB.MaxValue = ConstantModel.Ins.GetIntValueByKey(ServerConstantDef.SP_MAX);

            if (StateManager.Ins.getCurState().state == StateDef.battleState)
            {
                UpdateRoleInfoInBattle();
            }
            else
            {
                UI.ShengMingPB.Value = mainRole.curHp;
                UI.FaLiPB.Value = mainRole.curMp;
                UI.NuQiPB.Value = mainRole.curSp;
            }

            UI.Exp.LabelType = ProgressBarLabelType.CurrentAndMax;
            UI.Exp.setLongPercent(mainRole.getExpLimit(), mainRole.getExp());

            if (UI.roleChengHao != null)
            {
                UI.roleChengHao.text = ChenghaoModel.Ins.chenghaoName;
            }

            UpdatePetPool(null);
        }

        public void UpdatePetPool(RMetaEvent e)
        {
            int hpPoolMax = ConstantModel.Ins.GetIntValueByKey(ServerConstantDef.POOL_HP_MAX);
            UI.shengmingCunchu.setLongPercent(hpPoolMax, petmodel.hpPoolValue);
            UI.shengmingCunchu.label.text = petmodel.hpPoolValue + " / " + hpPoolMax;

            int mpPoolMax = ConstantModel.Ins.GetIntValueByKey(ServerConstantDef.POOL_MP_MAX);
            UI.faliCunchu.setLongPercent(mpPoolMax, petmodel.mpPoolValue);
            UI.faliCunchu.label.text = petmodel.mpPoolValue + " / " + mpPoolMax;

            int lifePoolMax = ConstantModel.Ins.GetIntValueByKey(ServerConstantDef.POOL_LIFE_MAX);
            UI.ShouMingChi.setLongPercent(lifePoolMax, petmodel.lifePoolValue);
            UI.ShouMingChi.label.text = petmodel.lifePoolValue + " / " + lifePoolMax;
        }

        public void UpdateChenghao(string chenghao)
        {
            if (UI.roleChengHao != null)
                UI.roleChengHao.text = chenghao;
        }

        public void UpdateRoleInfoInBattle()
        {
            BatCharacter role = BattleCharacterManager.ins.mainRole;
            if (role != null)
            {
                UI.ShengMingPB.Value = role.curHP;
                UI.FaLiPB.Value = role.curMP;
                UI.NuQiPB.Value = role.curSP;
            }
        }
    }
}
