using UnityEngine;
using app.net;
using app.pet;

namespace app.relation
{
    public class AddFriendItemScript
    {
        public AddFriendItemUI UI;

        public RelationInfo relationInfo;

        public AddFriendItemScript(AddFriendItemUI ui)
        {
            UI = ui;
            UI.addFriendBtn.SetClickCallBack(clickAdd);
        }

        public void setData(RelationInfo relationinfo)
        {
            relationInfo = relationinfo;
            UI.nameText.text = relationInfo.name;
            UI.levelText.text = "Lv." + relationInfo.level;
            UI.addFriendBtn.gameObject.SetActive(true);
            UI.addSuccessImage.gameObject.SetActive(false);
            UI.icon.gameObject.SetActive(true);
            //PathUtil.Ins.SetPetIconSource(UI.icon, relationinfo.pic);
            PathUtil.Ins.SetHeadIcon(UI.icon, relationinfo.pic);
            UI.zhiyeText.text = PetJobType.GetJobNameByRoleTplId(relationInfo.pic);
        }

        private void clickAdd()
        {
            if (relationInfo != null)
            {
                RelationCGHandler.sendCGAddRelationById(RelationType.HAOYOU, relationInfo.uuid);
            }
        }

        public void setAddSuccess()
        {
            UI.addFriendBtn.gameObject.SetActive(false);
            UI.addSuccessImage.gameObject.SetActive(true);
        }
        
        public void Destroy()
        {
            GameObject.DestroyImmediate(UI.gameObject, true);
            UI = null;
        }
    }
}