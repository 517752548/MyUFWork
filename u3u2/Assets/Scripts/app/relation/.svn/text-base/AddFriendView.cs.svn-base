using System.Collections.Generic;
using app.net;
using UnityEngine;
using UnityEngine.UI;
using app.main;

namespace app.relation
{
    public class AddFriendView:BaseWnd
    {
        //[Inject(ui = "AddFriendUI")]
        //public GameObject ui;

        public AddFriendUI UI;
        
        public RelationModel relationModel;

        private InputField inputText;

        private List<AddFriendItemScript> addFriendList;
        
        public AddFriendView()
        {
            uiName = "AddFriendUI";
        }

        public override void initWnd()
        {
            base.initWnd();
            
            relationModel = RelationModel.Ins;
            relationModel.addChangeEvent(RelationModel.REFRESH_Recommon_LIST, updateTuijianList);
            relationModel.addChangeEvent(RelationModel.ADD_HaoYou_Success, addHaoYouSuccess);
            
            UI = ui.AddComponent<AddFriendUI>();
            UI.Init();

            RectTransform rtf = UI.inputBg.GetComponent<RectTransform>();
            inputText = CreateInputField(Color.black, 20, UI.inputBg);
            UI.closeBtn.SetClickCallBack(clickclose);
            UI.findBtn.SetClickCallBack(clickFind);
            UI.refreshBtn.SetClickCallBack(clickRefresh);
        }

        private void clickRefresh()
        {
            RelationCGHandler.sendCGShowRecommendFriendList();
        }

        private void clickFind()
        {//查找人
            string inputstr = inputText.text;
            RelationCGHandler.sendCGAddRelationByName(RelationType.HAOYOU,inputstr);
        }

        private void clickclose()
        {
            hide();
            WndManager.open(GlobalConstDefine.RelationView_Name);
        }

        public override void show(RMetaEvent e = null)
        {
            base.show(e);
            updateTuijianList();
            GameClient.ins.OnBigWndShown();
        }
        
        public override void hide(RMetaEvent e = null)
        {
            base.hide(e);
            GameClient.ins.OnBigWndHidden();
        }
        public void updateTuijianList(RMetaEvent e=null)
        {
            List<RelationInfo> tuijianlist = relationModel.TuijianList;
            if (addFriendList==null)
            {
                addFriendList = new List<AddFriendItemScript>();
            }
            UI.defaultFriendItem.gameObject.SetActive(false);
            for (int i = 0; i < tuijianlist.Count; i++)
            {
                if (i >= addFriendList.Count)
                {
                    AddFriendItemUI item = GameObject.Instantiate(UI.defaultFriendItem);
                    AddFriendItemScript script = new AddFriendItemScript(item);
                    addFriendList.Add(script);
                    item.transform.SetParent(UI.friendListGrid.transform);
                    item.transform.localScale = Vector3.one;
                }
                addFriendList[i].setData(tuijianlist[i]);
                addFriendList[i].UI.gameObject.SetActive(true);
            }
        }

        public void addHaoYouSuccess(RMetaEvent e)
        {
            for (int i = 0; addFriendList!=null&&i < addFriendList.Count; i++)
            {
                long charid = (e.data as GCAddRelation).getTargetCharId();
                if (addFriendList[i].relationInfo.uuid.Equals(charid))
                {
                    addFriendList[i].setAddSuccess();
                    break;
                }
            }
        }
        
        public override void Destroy()
        {
            relationModel.removeChangeEvent(RelationModel.REFRESH_Recommon_LIST, updateTuijianList);
            relationModel.removeChangeEvent(RelationModel.ADD_HaoYou_Success, addHaoYouSuccess);
            if (addFriendList != null)
            {
                int len = addFriendList.Count;
                for (int i = 0; i < len; i++)
                {
                    addFriendList[i].Destroy();
                }
                addFriendList.Clear();
                addFriendList = null;
            }
            base.Destroy();
            UI = null;
        }
    }
}
