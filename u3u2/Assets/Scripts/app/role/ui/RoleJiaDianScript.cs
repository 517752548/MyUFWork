using app.db;
using app.human;
using app.net;
using app.pet;
using System.Collections.Generic;
using app.tips;
using app.zone;
using UnityEngine;
using UnityEngine.UI;
using app.utils;

namespace app.role
{
    /// <summary>
    /// 加点逻辑
    /// </summary>
    public class RoleJiaDianScript
    {
        /// <summary>
        /// 当前已经分配的点数，顺序同 jiadianPropkeyList设置的属性顺序
        /// </summary>
        private int[] hasSharedPoint;

        private RoleJiaDianUI JiaDianUI;
        /// <summary>
        /// 当前可以分配的点数
        /// </summary>
        private int leftDian;
        /// <summary>
        /// 一级属性的UI
        /// </summary>
        private RoleJiaDianItem[] propAItem;
        /// <summary>
        /// 二级属性的文本
        /// </summary>
        private Text[] propBText;
        /// <summary>
        /// 一级属性的文本
        /// </summary>
        private Text[] propAText;
        /// <summary>
        /// 一级属性的数量
        /// </summary>
        private int propATotalNum = 5;
        /// <summary>
        /// 二级属性的数量
        /// </summary>
        private int propBTotalNum = 17;
        /// <summary>
        /// 二级属性，增加的值,key:属性的key，value为增加的值
        /// </summary>
        private Dictionary<int,float> propBAdd = new Dictionary<int, float>();

        private int MAX_DIAN;
        //private Pet currentPet;
        private long currentPetId;

        public RoleJiaDianScript(RoleJiaDianUI ui)
        {
            this.JiaDianUI = ui;
            this.init();
            JiaDianUI.JiaDianShuoMing.SetClickCallBack(jiadianshuomingOnClick);
        }

        /// <summary>
        /// 加点说明按钮点击
        /// </summary>
        private void jiadianshuomingOnClick()
        {
            PopInfoWnd.Ins.ShowInfo(
            ColorUtil.getColorText(ColorUtil.PURPLE, "强壮") + "  影响物理攻击、物理命中、物理抗暴、速度\n" +
            ColorUtil.getColorText(ColorUtil.PURPLE, "耐力") + "  影响生命、物理护甲、法术抗性\n" +
            ColorUtil.getColorText(ColorUtil.PURPLE, "敏捷") + "  影响物理护甲、物理闪避、物理暴击、速度\n" +
            ColorUtil.getColorText(ColorUtil.PURPLE, "智力") + "  影响法术强度、法术命中、法术抗暴、法力\n" +
            ColorUtil.getColorText(ColorUtil.PURPLE, "信仰") + "  影响法术抗性、法术暴击、速度", "加点说明", TextAnchor.MiddleLeft, 520);
        }

        public long CurrentPetId
        {
            set { currentPetId = value; }
        }

        #region 按钮 加减 逻辑

        private void clickJiaBtn(RMetaEvent e)
        {
            int index = this.getPropAIndex(e.data as GameObject, true);
            dojia(index);
        }

        private void clickJiaBtn(GameObject go)
        {
            int index = this.getPropAIndex(go, true);
            dojia(index);
        }

        private void dojia(int index)
        {
            if (this.propAItem[index].pg.Value >= MAX_DIAN) return;
            if (this.getOneDian())
            {
                this.propAItem[index].pg.Value = this.propAItem[index].pg.Value+1;
                Pet pet = Human.Instance.PetModel.getPet(currentPetId);
                int currentProp = pet.PetInfo.aPropAddArr[index];
                this.hasSharedPoint[index] = (int)this.propAItem[index].pg.Value - currentProp;
            }
            updateAddDian();
        }

        private void clickJianBtn(RMetaEvent e)
        {
            int index = this.getPropAIndex(e.data as GameObject, false);
            dojian(index);
        }

        private void clickJianBtn(GameObject go)
        {
            int index = this.getPropAIndex(go, false);
            dojian(index);
        }

        private void dojian(int index)
        {
            Pet pet = Human.Instance.PetModel.getPet(currentPetId);
            int currentProp = pet.PetInfo.aPropAddArr[index];
            if (this.propAItem[index].pg.Value <= currentProp)
            {
                this.propAItem[index].pg.Value = currentProp;
                return;
            }
            this.propAItem[index].pg.Value--;
            this.hasSharedPoint[index] = (int)this.propAItem[index].pg.Value - currentProp;
            updateAddDian();
        }

        private bool getOneDian()
        {
            int num = 0;
            for (int i = 0; i < this.hasSharedPoint.Length; i++)
            {
                num += this.hasSharedPoint[i];
            }
            return (num < this.leftDian);
        }

        private int getPropAIndex(GameObject go, bool jiaOrJian)
        {
            for (int i = 0; i < this.propAItem.Length; i++)
            {
                if (jiaOrJian && (this.propAItem[i].jiaBtn.gameObject == go))
                {
                    return i;
                }
                if (!jiaOrJian && (this.propAItem[i].jianBtn.gameObject == go))
                {
                    return i;
                }
            }
            return -1;
        }
        #endregion

        #region 初始化

        private void init()
        {
            MAX_DIAN = ConstantModel.Ins.GetIntValueByKey(ServerConstantDef.JIADIAN_PER_LEVEL_ROLE)*ConstantModel.Ins.GetIntValueByKey(ServerConstantDef.PLAYER_MAX_LEVEL);
            if (this.propAItem == null)
            {
                this.propAItem = this.JiaDianUI.PropAItemList.ToArray();
                this.hasSharedPoint = new int[propATotalNum];
                for (int i = 0; i < this.propAItem.Length; i++)
                {
                    this.propAItem[i].jiaBtn.SetClickCallBack(clickJiaBtn);
                    this.propAItem[i].jianBtn.SetClickCallBack(clickJianBtn);
                    InputManager.Ins.AddListener(InputManager.STATIONARY_EVENT_TYPE, this.propAItem[i].jiaBtn.gameObject, clickJiaBtn, this.propAItem[i].jiaBtn.gameObject);
                    InputManager.Ins.AddListener(InputManager.STATIONARY_EVENT_TYPE, this.propAItem[i].jianBtn.gameObject, clickJianBtn, this.propAItem[i].jianBtn.gameObject);
                    this.propAItem[i].pg.LabelType = ProgressBarLabelType.CurrentAndMax;
                    this.hasSharedPoint[i]=0;
                }
            }
            if (propBText==null)
            {
                propBText = this.JiaDianUI.PropGrid.GetComponentsInChildren<Text>();
            }
            if (propAText==null)
            {
                propAText = this.JiaDianUI.PropATextGrid.GetComponentsInChildren<Text>();
            }
            JiaDianUI.savedian.SetClickCallBack(clickSavaDian);
            JiaDianUI.xidian.SetClickCallBack(clickXiDian);
        }

        private void clickXiDian()
        {
            if (currentPetId != null && currentPetId != 0)
            {
                XiDianScript.Ins.ShowConfirm(confirmXiDian);
            }
            else
            {
                ZoneBubbleManager.ins.BubbleSysMsg("请先选择洗点对象！");
            }
        }

        private void confirmXiDian(RMetaEvent e)
        {
            if (currentPetId != null && currentPetId != 0)
            {
                PetCGHandler.sendCGPetResetPoint(currentPetId);
            }
            else
            {
                ZoneBubbleManager.ins.BubbleSysMsg("请先选择洗点对象！");
            }
        }

        public void initAPropDian(long petId)
        {
            if (petId==0)
            {
                return;
            }
            CurrentPetId = petId;
            Pet pet = Human.Instance.PetModel.getPet(currentPetId);
            leftDian = pet.PropertyManager.getPetIntProp(RoleBaseIntProperties.LEFT_POINT);

            this.JiaDianUI.Qianli.text = this.leftDian.ToString();
            for (int i = 0; i < this.propAItem.Length; i++)
            {
                int current = pet.PetInfo.aPropAddArr[i];
                this.propAItem[i].pg.MaxValue = MAX_DIAN;
                this.propAItem[i].pg.Value = current;
            }
            clear();
            updateAddDian();
        }

        #endregion

        /// <summary>
        /// 更新加点的效果
        /// </summary>
        private void updateAddDian()
        {
            propBAdd.Clear();
            
            int leftPoint = leftDian;
            
            for (int i = 0; i < this.hasSharedPoint.Length; i++)
            {
                if (this.hasSharedPoint[i] > 0)
                {
                    this.propAItem[i].addText.text = "+" + this.hasSharedPoint[i];
                }
                else
                {
                    this.propAItem[i].addText.text = string.Empty;
                }
                
                leftPoint -= this.hasSharedPoint[i];
            }
            
            this.JiaDianUI.Qianli.text = leftPoint.ToString();
            
            for (int i=PetBProperty.HP;i<PetBProperty.HP+propBTotalNum;i++)
            {
                float value = 0f;
                PetPropTemplate ppt = PetPropTemplateDB.Instance.getTemplate(i);
                value += ppt.strength!=0?hasSharedPoint[0] * (ppt.strength / ClientConstantDef.PET_DIV_BASE):0;
                value += ppt.agility != 0 ? hasSharedPoint[1] * (ppt.agility / ClientConstantDef.PET_DIV_BASE) : 0;
                value += ppt.intellect != 0 ? hasSharedPoint[2] * (ppt.intellect / ClientConstantDef.PET_DIV_BASE) : 0;
                value += ppt.faith != 0 ? hasSharedPoint[3] * (ppt.faith / ClientConstantDef.PET_DIV_BASE) : 0;
                value += ppt.stamina != 0 ? hasSharedPoint[4] * (ppt.stamina / ClientConstantDef.PET_DIV_BASE) : 0;
                propBAdd.Add(i, value);
            }
            updateDianPropB();
        }

        private void updateDianPropB()
        {
            if (PetModel.Ins.IsChongWu)
            {
                JiaDianUI.PropGrid.gameObject.SetActive(true);
                JiaDianUI.JiaDianShuoMing.gameObject.SetActive(true);
                if (null != JiaDianUI.m_qichonginfo)
                {
                    JiaDianUI.m_qichonginfo.gameObject.SetActive(false);
                }
            }
            else
            {
                JiaDianUI.PropGrid.gameObject.SetActive(false);
                JiaDianUI.JiaDianShuoMing.gameObject.SetActive(false);
                if (null != JiaDianUI.m_qichonginfo)
                {
                    JiaDianUI.m_qichonginfo.gameObject.SetActive(true);
                }
            }
            Pet pet = Human.Instance.PetModel.getPet(currentPetId);
            List<int> list = PetDef.GetPetBPropKeyListByJobType(pet.getTpl().attackTypeId);
            for (int i = 0; i < propBText.Length; i++)
            {
                float addvalue=0f;
                propBAdd.TryGetValue(list[i], out addvalue);
                string addText;
                if (float.IsNaN(addvalue)||addvalue == 0)
                {
                    addText = "";
                }
                else
                {
                    addText = "+"+((int)addvalue).ToString().ToString();
                }
                propBText[i].text = LangConstant.getPetPropertyName(list[i]) + ":"
                    + ColorUtil.getColorText(ColorUtil.WHITE_ID, pet.PropertyManager.getPetIntProp(list[i]).ToString()) + ColorUtil.getColorText(ColorUtil.GREEN, addText);
                //propBText[i].text = LangConstant.getPetPropertyName(list[i]) + ":"
                //    + pet.PropertyManager.getBProperty(list[i]) + ColorUtil.getColorText(ColorUtil.GREEN, addText);
            }

            List<int> propAList = PetDef.GetPetAPropKeyList();
            for (int i=0;i<propAList.Count;i++)
            {
                if (propAText!=null&&i < propAText.Length) propAText[i].text = LangConstant.getPetPropertyName(propAList[i]) + ":"
                    + ColorUtil.getColorText(ColorUtil.WHITE_ID, pet.PropertyManager.getPetIntProp(propAList[i]).ToString());
                //propAText[i].text = LangConstant.getPetPropertyName(propAList[i]) + ":"
                //    + pet.PropertyManager.getAProperty(propAList[i]);
                //ColorUtil.getColorText(ColorUtil.GREEN, addText)
            }
        }

        private void clickSavaDian()
        {
            Pet pet = Human.Instance.PetModel.getPet(currentPetId);
            if (hasSharedPoint != null && hasSharedPoint.Length>0)
            {
                bool isEmpty = true;
                for (int i=0;i<hasSharedPoint.Length;i++)
                {
                    if (hasSharedPoint[i] != 0)
                    {
                        isEmpty = false;
                        break;
                    }
                }
                if (!isEmpty)
                {
                    PetCGHandler.sendCGPetAddPoint(pet.Id, hasSharedPoint);
                }
            }
        }

        /// <summary>
        /// 清空数据
        /// </summary>
        public void clear()
        {
            for (int i=0;i<hasSharedPoint.Length;i++)
            {
                hasSharedPoint[i] = 0;
            }
            propBAdd.Clear();
        }

        public void show()
        {
            //JiaDianUI.gameObject.SetActive(true);
            for (int i = 0; this.propAItem != null && i < this.propAItem.Length; i++)
            {
                InputManager.Ins.AddListener(InputManager.STATIONARY_EVENT_TYPE, this.propAItem[i].jiaBtn.gameObject, clickJiaBtn, this.propAItem[i].jiaBtn.gameObject);
                InputManager.Ins.AddListener(InputManager.STATIONARY_EVENT_TYPE, this.propAItem[i].jianBtn.gameObject, clickJianBtn, this.propAItem[i].jianBtn.gameObject);
            }

            if (PetModel.Ins.IsChongWu)
            {
                JiaDianUI.PropGrid.gameObject.SetActive(true);
                JiaDianUI.JiaDianShuoMing.gameObject.SetActive(true);
                if (null != JiaDianUI.m_qichonginfo)
                {
                    JiaDianUI.m_qichonginfo.gameObject.SetActive(false);
                }
            }
            else
            {
                JiaDianUI.PropGrid.gameObject.SetActive(false);
                JiaDianUI.JiaDianShuoMing.gameObject.SetActive(false);
                if (null != JiaDianUI.m_qichonginfo)
                {
                    JiaDianUI.m_qichonginfo.gameObject.SetActive(true);
                }
            }
            
        }

        public void hide()
        {
            clear();
            JiaDianUI.gameObject.SetActive(false);
            for (int i = 0; this.propAItem != null && i < this.propAItem.Length; i++)
            {
                InputManager.Ins.RemoveListener(InputManager.STATIONARY_EVENT_TYPE, this.propAItem[i].jiaBtn.gameObject, clickJiaBtn);
                InputManager.Ins.RemoveListener(InputManager.STATIONARY_EVENT_TYPE, this.propAItem[i].jianBtn.gameObject, clickJianBtn);
            }
        }

        public void Destroy()
        {
            for (int i = 0; i < this.propAItem.Length; i++)
            {
                InputManager.Ins.RemoveListener(InputManager.STATIONARY_EVENT_TYPE, this.propAItem[i].jiaBtn.gameObject, clickJiaBtn);
                InputManager.Ins.RemoveListener(InputManager.STATIONARY_EVENT_TYPE, this.propAItem[i].jianBtn.gameObject, clickJianBtn);
            }

            GameObject.DestroyImmediate(JiaDianUI.gameObject, true);
            JiaDianUI = null;
        }

    }
}