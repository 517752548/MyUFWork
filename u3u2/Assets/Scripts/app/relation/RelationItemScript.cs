using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using app.net;
using app.relation;
using UnityEngine;
using app.db;

namespace app.relation
{

    public class RelationItemScript
    {
        public RelationItemUI UI;
        public RelationInfo data;
        public int currentRelationType;
        public MailInfoData mailInfo;
        public PlayerData playerdata;
        
        private RelationView relationView;

        public RelationItemScript(RelationItemUI ui)
        {
            UI = ui;
            if (UI.zhankaiBtn != null)
            {
                UI.zhankaiBtn.SetClickCallBack(clickZhankai);
            }
            if (UI.shanchuBtn!=null) UI.shanchuBtn.SetClickCallBack(clickShanChu);
            UI.toggel.AddValueChangedCallBack(HandleChange);
        }

        private void HandleChange(bool isOn)
        {
            if (!isOn || mailInfo == null)
            {
                return;
            }
            MailCGHandler.sendCGReadMail(mailInfo.uuid);

        }

        private void clickShanChu()
        {
            
        }

        private void clickZhankai()
        {
            if (relationView == null)
            {
                relationView = Singleton.GetObj(typeof(RelationView)) as RelationView;
            }
            relationView.showOperate(currentRelationType, data);
        }
        /// <summary>
        /// 设置为系统消息
        /// </summary>
        public void setSystemRelation()
        {
            UI.nameText.text = "系统消息";
            //UI.levelText.text = "";
            UI.riqiText.text = "";
            UI.zhankaiBtn.gameObject.SetActive(false);
            UI.shanchuBtn.gameObject.SetActive(false);
            PathUtil.Ins.SetHeadIcon(UI.icon, "gm");
            //UI.icon.gameObject.SetActive(true);
            //PathUtil.Ins.SetRawImageSource(UI.icon, "gm", PathUtil.TEXTUER_HEAD);
        }
        /// <summary>
        /// 设置好友、黑名单 数据
        /// </summary>
        /// <param name="relationinfo"></param>
        public void setRelationData(RelationInfo relationinfo, int relationTYpe)
        {
            currentRelationType = relationTYpe;
            data = relationinfo;
            UI.nameText.text = data.name;
            UI.levelText.text = "Lv." + data.level;
            UI.riqiText.text = "";
            UI.zhankaiBtn.gameObject.SetActive(true);
            UI.shanchuBtn.gameObject.SetActive(false);
            UI.icon.gameObject.SetActive(true);

            PetTemplate petTpl = PetTemplateDB.Instance.getTemplate(relationinfo.pic);
            if (petTpl != null)
            {
                PathUtil.Ins.SetHeadIcon(UI.icon, petTpl.modelId);
            }
        }
        /// <summary>
        /// 设置 最近联系人 数据
        /// </summary>
        /// <param name="relationinfo"></param>
        public void setLianXiRenData(PlayerData relationinfo)
        {
            playerdata = relationinfo;
            UI.nameText.text = playerdata.getData(PlayerDataKeyDef.ZUIJINLIANXIREN_DATA_NAME);
            if (UI.levelText != null) UI.levelText.text = "Lv." + playerdata.getData(PlayerDataKeyDef.ZUIJINLIANXIREN_DATA_LV);
            if (UI.riqiText != null) UI.riqiText.text = "";
            UI.zhankaiBtn.gameObject.SetActive(true);
            UI.shanchuBtn.gameObject.SetActive(false);
            UI.icon.gameObject.SetActive(true);
            //PathUtil.Ins.SetPetIconSource(UI.icon, int.Parse(playerdata.getData(PlayerDataKeyDef.ZUIJINLIANXIREN_DATA_PHOTO)));
            PetTemplate petTpl = PetTemplateDB.Instance.getTemplate(int.Parse(playerdata.getData(PlayerDataKeyDef.ZUIJINLIANXIREN_DATA_PHOTO)));
            if (petTpl != null)
            {
                PathUtil.Ins.SetHeadIcon(UI.icon, petTpl.modelId);
            }
        }
        /// <summary>
        /// 设置邮件数据
        /// </summary>
        /// <param name="mailinfo"></param>
        public void setMailData(MailInfoData mailinfo)
        {
            mailInfo = mailinfo;
            UI.nameText.text = mailInfo.senderName;
            UI.riqiText.text = mailInfo.createTime;
            SetMainIsOpened(mailinfo.mailStatus);
        }

        private void SetMainIsOpened(int status)
        {
            bool isOpend = status == 2;
            if (UI.yiduSign != null)
            {
                UI.yiduSign.gameObject.SetActive(isOpend);
            }
        }
        
        public void Destroy()
        {
            GameObject.DestroyImmediate(UI.gameObject, true);
            UI = null;
        }
    }
}