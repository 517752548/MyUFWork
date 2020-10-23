using UnityEngine;
using System.Collections.Generic;
using app.pet;
using app.net;
using System.Collections;

namespace app.qichong
{
    public class QichongView : BaseWnd
    {
        QichongUI UI;

        QichongLeftInfoUI leftInfoUI;
        QichongLeftInfoScript leftinfoScript;

        public QichongLeftInfoScript LeftinfoScript
        {
            get
            {
                return leftinfoScript;
            }
        }
        private PetModel petModel;
        private QichongXinxiScript qichongxinxiScript;

        System.Action<Pet> onclickAction = null;

        public QichongView()
        {
            uiName = "QiChongUI";
            hasSubUI = true;
        }


        public override void initWnd()
        {
            base.initWnd();
            UI = ui.AddComponent<QichongUI>();
            UI.Init();
            qichongxinxiScript = new QichongXinxiScript(UI.xinxiUI,this);
            //leftinfoScript = new QichongLeftInfoScript(UI.leftInfoUI, SelectPet,this);
            UI.closeBtn.SetClickCallBack(OnClickClose);
            UI.tabs.TabChangeHandler = ChangeTab;
            UI.tabs.SetIndexWithCallBack(0);
            //leftinfoScript.updatePanel();
            petModel = PetModel.Ins;
            petModel.addChangeEvent(PetModel.UPDATE_PET_INFO,Refresh);
            petModel.addChangeEvent(PetModel.PET_HORSE_CHANGE_NAME , Refresh);
            petModel.addChangeEvent(PetModel.UPDATE_PET_FIGHT_STATE,Refresh);
            petModel.addChangeEvent(PetModel.UPDATE_PET_LIST,Refresh);

        }

       

        public void Refresh(RMetaEvent e = null)
        {
            if (leftinfoScript == null)
            {
             //   leftinfoScript = new QichongLeftInfoScript(UI.leftInfoUI, SelectPet, this);
                UI.StartCoroutine(InitLeftUI(1));
            }
            else
            {
                leftinfoScript.updatePanel();
            }
        }

        private void SelectPet(Pet pet)
        {
            AddPetModel(pet);
            if (qichongxinxiScript == null)
            {
                qichongxinxiScript = new QichongXinxiScript(UI.xinxiUI,this);
            }
            qichongxinxiScript.SetData(pet);
        }

        private void AddPetModel(Pet pet)
        {
            if (pet == null)
            {
                RemoveAvatarModel();                
                return;
            }
            AddPetModelToUI(Vector3.zero,Vector3.zero,Vector3.one,pet,leftInfoUI.modelContainer);
        }


        private void ChangeTab(int index)
        {
            switch (index)
            {
                case 0:
                    UI.xinxiUI.gameObject.SetActive(true);
                    UI.textTitle.text = "骑宠信息";
                    break;
            }
        }

        private void OnClickClose()
        {
            hide();
        }


        public override void show(RMetaEvent e = null)
        {
            base.show(e);
            UI.Show();
            Refresh();
           
            app.main.GameClient.ins.OnBigWndShown();
        }

        public override void hide(RMetaEvent e = null)
        {
            base.hide(e);
            UI.Hide();
            app.main.GameClient.ins.OnBigWndHidden();
        }

        private IEnumerator InitLeftUI(int waitFrame)
        {
            for (int i = 0; i < waitFrame; i++)
            {
                yield return null;
            }
            UI.objQiChongLeftInfo = GameObject.Instantiate(SourceManager.Ins.GetAsset<GameObject>(uiPath, uiName + "Leftinfo")) as GameObject;
            UI.objQiChongLeftInfo.SetActive(true);         
            GameObjectUtil.Bind(UI.objQiChongLeftInfo.transform,UI.tfLeftInfoContainer,true,true);
            UI.objQiChongLeftInfo.transform.localScale = Vector3.one;
            leftInfoUI = UI.objQiChongLeftInfo.AddComponent<QichongLeftInfoUI>();
            leftInfoUI.Init();
            leftInfoUI.shengjiEffect.SetActive(false);
            leftinfoScript = new QichongLeftInfoScript (leftInfoUI,SelectPet,this);
            leftinfoScript.updatePanel();
            
        }

        public override void Destroy()
        {

            RemoveAvatarModel();
            petModel.removeChangeEvent(PetModel.UPDATE_PET_INFO, Refresh);
            petModel.removeChangeEvent(PetModel.PET_HORSE_CHANGE_NAME, Refresh);
            petModel.removeChangeEvent(PetModel.UPDATE_PET_FIGHT_STATE, Refresh);
            petModel.removeChangeEvent(PetModel.UPDATE_PET_LIST, Refresh);
            if (leftinfoScript != null)
            {
                leftinfoScript.Destroy();
                leftinfoScript = null;
            }
            if (qichongxinxiScript != null)
            {
                qichongxinxiScript.Destroy();
                qichongxinxiScript = null;
            } 

            RemoveAvatarModel();
            base.Destroy();
            UI = null;
        }




    }
}
