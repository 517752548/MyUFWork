using UnityEngine;
using System.Collections;
using app.db;
using app.net;

namespace app.pet
{
    public class QuickPetSkillItem : PetSkillItem
    {
        bool m_isopen = false;
        public Transform m_jiantou;
        public Transform m_change;
        ClickPetSkillItemHandler m_clickHandler = null;
        public QuickPetSkillItem(CommonItemUI ui, ClickPetSkillItemHandler clickHandler = null):base(ui,clickHandler)
        {
            m_jiantou = ui.transform.Find("jiantou");
            m_change = ui.transform.Find("change");
            m_clickHandler = clickHandler;
            if (clickHandler != null)
            {
                UI.ClickCommonItemHandler = onClick;
            }
        }

        private void onClick()
        {
            if (null != m_clickHandler)
            {
                if (UI.transform.name.Contains("ZZCommonItemUI"))
                {
                    base.onClick();
                }
                else
                {
                    int index = System.Convert.ToInt32(UI.transform.name);
                    int skillid = -1;
                    QuickData temp = new QuickData();
                    temp.m_index = index;
                    temp.m_skillid = skillid;
                    m_clickHandler(temp);
                }
            }
        }

        public new void setEmpty()
        {
            if (null != m_jiantou)
            {
                m_jiantou.gameObject.SetActive(false);
            }
            if (null != m_change)
            {
                m_change.gameObject.SetActive(false);
            }
            base.setEmpty();
        }

        public new void SetData(PetSkillInfo skillInfo)
        {
            //SkillTemplate skillTemplate = SkillTemplateDB.Instance.getTemplate(skillInfo.skillId);
            base.SetData(skillInfo);
            if (null != m_jiantou)
            {
                m_jiantou.gameObject.SetActive(false);
            }
            if (null != m_change)
            {
                m_change.gameObject.SetActive(false);
            }
        }

        public new void SetData(SkillTemplate skillTemplate)
        {
            base.SetData(skillTemplate);
            if (null != m_jiantou)
            {
                m_jiantou.gameObject.SetActive(false);
            }
            if (null != m_change)
            {
                m_change.gameObject.SetActive(false);
            }
        }

        public void SetOpen(bool isopen)
        {
            m_isopen = isopen;
            SetGray(!m_isopen);
        }

        /// <summary>
        /// 快捷技能设置id
        /// </summary>
        /// <param name="skillId"></param>
        public void SetQuick(int skillId)
        {
            UI.gameObject.SetActive(true);
            UI.biangkuang.gameObject.SetActive(false);
            if (null == UI.biangkuang.sprite)
            {
                Sprite t = SourceManager.Ins.GetBiankuang(5);
                UI.biangkuang.sprite = t;
            }
            if (-1 == skillId)
            {
                m_isopen = false;
                setEmpty();
            }
            else
            {

                SkillTemplate skillTemplate = SkillTemplateDB.Instance.getTemplate(skillId);
                m_isopen = true;
                if (null == skillTemplate)
                {
                    m_isopen = false;
                    setEmpty();
                }
                else
                {
                    SetData(skillTemplate);
                }
            }
        }

        /// <summary>
        /// 设置箭头是否显示
        /// </summary>
        /// <param name="isshow"></param>
        public void SetJiantou(bool isshow)
        {
            m_jiantou.gameObject.SetActive(isshow && m_isopen && 1 != GetTplData().isPassive);
        }

        /// <summary>
        /// 设置快捷技能箭头、交换位置是否显示
        /// </summary>
        /// <param name="isshow">是否显示</param>
        /// <param name="isselect">是否为当前选择</param>
        public void SetQuickJiantou(bool isshow, bool isselect)
        {
            if (isshow)
            {
                if (isselect)
                {
                    m_jiantou.gameObject.SetActive(isshow && m_isopen && 1 != GetTplData().isPassive);
                    UI.biangkuang.gameObject.SetActive(true);
                }
                else
                {
                    m_change.gameObject.SetActive(isshow && m_isopen && 1 != GetTplData().isPassive);
                    UI.biangkuang.gameObject.SetActive(false);
                }
            }
            else
            {
                m_jiantou.gameObject.SetActive(false);
                m_change.gameObject.SetActive(false);
                UI.biangkuang.gameObject.SetActive(false);

            }

        }

    }
}
