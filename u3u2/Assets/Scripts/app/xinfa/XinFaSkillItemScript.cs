using UnityEngine;
using app.db;
using app.human;
using app.role;
using app.utils;

namespace app.xinfa
{
    public class XinFaSkillItemScript
    {
        public XinFaSkillItemUI UI;

        private HumanSubSkillTemplate subSkillTpl;
        private SkillTemplate skillTemplate;
        private bool isOpen;

        private int skillLevel;

        public XinFaSkillItemScript(XinFaSkillItemUI ui)
        {
            UI = ui;
        }

        public HumanSubSkillTemplate SubSkillTpl
        {
            get { return subSkillTpl; }
        }

        public bool IsOpen
        {
            get { return isOpen; }
        }

        public int SkillLevel
        {
            get { return skillLevel; }
        }

        public SkillTemplate SkillTemplate
        {
            get { return skillTemplate; }
        }

        public bool isFromBook { get; private set; }

        public void setData(int skillId, bool isopen, int skilllevel, bool isFromBook)
        {
            if (!isFromBook)
            {
                subSkillTpl = HumanSubSkillTemplateDB.Instance.getTemplate(skillId);
            }
            skillTemplate = SkillTemplateDB.Instance.getTemplate(skillId);
            if (!isFromBook && SubSkillTpl == null)
            {
                return;
            }
            skillLevel = skilllevel;
            isOpen = isopen;
            this.isFromBook = isFromBook;
            UI.gameObject.SetActive(true);
            UI.icon.biangkuang.gameObject.SetActive(false);
            UI.skillName.text = skillTemplate.name;
            UI.skillDesc.text = (isOpen ? (" Lv" + SkillLevel) : "");
            UI.openDesc.gameObject.SetActive(!isOpen);
            if (!isOpen)
            {
                //if (SkillTemplate.isPassive == 1 && SkillLevel == 0)
                //{//是被动技能，并且当前为0级，需要手动开启
                //    UI.openDesc.text = "被动技能,需手动开启";
                //}
                //else
                //{
                int humanLevel = Human.Instance.PetModel.getLeader().getLevel();
                if (humanLevel < subSkillTpl.needHumanLevel)
                {
                    UI.openDesc.text = "角色达到" + subSkillTpl.needHumanLevel + "级可开启";
                }
                else
                {
                    //int xinfaid = HumanMainSkillToSubSkillTemplateDB.Instance.GetXinFaIdBySkillId(subSkillTpl.Id);
                    //int currentXinFaLevel = XinFaModel.instance.GetXinFaLevel(xinfaid);
                    //    //Human.Instance.PropertyManager.getIntProp(RoleBaseIntProperties.MAINSKILL_LEVEL);
                    //if (currentXinFaLevel < subSkillTpl.needMainSkillLevel)
                    //{
                        UI.openDesc.text = "未习得该技能";// +subSkillTpl.needMainSkillLevel + "级可开启";
                    //}
                }
                //}
            }

            //SourceLoader.Ins.load(PathUtil.Ins.GetUITexturePath(skillTemplate.icon, PathUtil.TEXTUER_SKILL), OnIconLoaded);
            PathUtil.Ins.SetSkillIcon(UI.icon.icon, skillTemplate.icon);
        }
        /*
        private void OnIconLoaded(RMetaEvent e)
        {
            UI.icon.icon.texture = SourceManager.Ins.GetAsset<Texture2D>(PathUtil.Ins.GetUITexturePath(skillTemplate.icon, PathUtil.TEXTUER_SKILL));
        }
        */

        public void SetOpen(bool isopen)
        {
            if (isopen)
            {
                ColorUtil.DeGray(UI.icon.icon);
            }
            else
            {
                ColorUtil.Gray(UI.icon.icon);
            }


        }
        public void setEmpty()
        {
            subSkillTpl = null;
            UI.gameObject.SetActive(false);
        }

        public void Destroy()
        {
            GameObject.DestroyImmediate(UI.gameObject, true);
            UI = null;
            subSkillTpl = null;
            skillTemplate = null;
        }

        /// <summary>
        /// 快捷技能设置id
        /// </summary>
        /// <param name="skillId"></param>
        public void SetQuick(int skillId)
        {
            UI.gameObject.SetActive(true);
            UI.icon.biangkuang.gameObject.SetActive(false);
            Sprite t = SourceManager.Ins.GetBiankuang(5);
            UI.icon.biangkuang.sprite = t;
            if (-1 == skillId)
            {
                skillTemplate = null;
                isOpen = false;
                UI.icon.icon.gameObject.SetActive(false);
            }
            else
            {

                skillTemplate = SkillTemplateDB.Instance.getTemplate(skillId);
                isOpen = true;
                if (null == skillTemplate)
                {
                    UI.icon.icon.gameObject.SetActive(false);
                    isOpen = false;
                }
                else
                {
                    PathUtil.Ins.SetSkillIcon(UI.icon.icon, skillTemplate.icon);
                }
            }
        }

        /// <summary>
        /// 快捷技能点击回调事件
        /// </summary>
        QuickClick m_quickclick;

        /// <summary>
        /// 设置快捷技能点击回调
        /// </summary>
        /// <param name="temp"></param>
        public void SetQuickAction(QuickClick temp)
        {
            m_quickclick = temp;
            UI.icon.ClickCommonItemHandler = SkillClick;
        }

        /// <summary>
        /// 快捷技能点击事件
        /// </summary>
        public void SkillClick()
        {
            if (null != m_quickclick)
            {
                m_quickclick(UI.gameObject);
            }
        }

        /// <summary>
        /// 设置箭头是否显示
        /// </summary>
        /// <param name="isshow"></param>
        public void SetJiantou(bool isshow)
        {
            UI.m_jiantou.gameObject.SetActive(isshow && IsOpen && 1 != SkillTemplate.isPassive);
        }

        /// <summary>
        /// 设置快捷技能箭头、交换位置是否显示
        /// </summary>
        /// <param name="isshow">是否显示</param>
        /// <param name="isselect">是否为当前选择</param>
        public void SetQuickJiantou(bool isshow,bool isselect)
        {
            if (isshow)
            {
                if (isselect)
                {
                    UI.m_jiantou.gameObject.SetActive(isshow && IsOpen && 1 != SkillTemplate.isPassive);
                    UI.icon.biangkuang.gameObject.SetActive(true);
                }
                else
                {
                    UI.m_change.gameObject.SetActive(isshow && IsOpen && 1 != SkillTemplate.isPassive);
                    UI.icon.biangkuang.gameObject.SetActive(false);
                } 
            }
            else
            {
                UI.m_jiantou.gameObject.SetActive(false);
                UI.m_change.gameObject.SetActive(false);
                UI.icon.biangkuang.gameObject.SetActive(false);

            }
            
        }
    }
}
