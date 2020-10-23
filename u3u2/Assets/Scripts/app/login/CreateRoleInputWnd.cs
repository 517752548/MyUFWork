using app.model;
using app.net;
using app.pet;
using app.zone;
using UnityEngine;
using UnityEngine.UI;

namespace app.login
{
    public class CreateRoleInputWnd:BaseWnd
    {
        public CreateRoleInputUI UI;

        public InputField inputText;
        public string randomName;

        private int selectRoleIndex = 0;

        public CreateRoleInputWnd()
        {
            useTween = false;
            uiName = "CreateRoleInputUI";
            isShowBgMask = true;
        }

        protected override void clickSpaceArea(GameObject go)
        {
            return;
        }

        public override void initWnd()
        {
            base.initWnd();

            PlayerModel.Ins.addChangeEvent(PlayerModel.GCROLENAME, gcRandomName);

            UI = ui.AddComponent<CreateRoleInputUI>();
            UI.Init();

            UI.randomBtn.SetClickCallBack(ClickRandomName);
            UI.backBtn.SetClickCallBack(ClickBackBtn);
            UI.kaishiBtn.SetClickCallBack(enterGame);
            
            inputText = CreateInputField(Color.black, 24, UI.inputbg);
            inputText.characterLimit = 12;
            if (randomName != null) inputText.text = randomName;
        }

        public void enterScene(RMetaEvent e = null)
        {
            //hide();
            //Destroy();
        }

        private void ClickBackBtn()
        {
            hide();
        }

        private void ClickRandomName()
        {
            int jobIndex = (int)Mathf.Pow(2, selectRoleIndex / 2);
            PlayerCGHandler.sendCGRoleRandomName(jobIndex % 2 == 0 ? PetSexType.NV : PetSexType.NAN);
        }

        public void gcRandomName(RMetaEvent e)
        {
            if (inputText != null)
            {
                inputText.text = (e.data as string);
            }
            else
            {
                randomName = (e.data as string);
            }
        }

        private void enterGame()
        {
            if (string.IsNullOrEmpty(inputText.text))
            {
                ZoneBubbleManager.ins.BubbleSysMsg("角色名称不能为空，请输入角色名");
                return;
            }
            ClientLog.LogWarning("创角名字"+inputText.text+"END");
            PlayerCGHandler.sendCGCreateRole(inputText.text,PlayerModel.Ins.RoleTemplate[selectRoleIndex].petTemplateId);
        }
        
        public override void show(RMetaEvent e = null)
        {
            base.show();
            selectRoleIndex = e != null ? (int)e.data : 0;
            ClickRandomName();
        }

        public override void hide(RMetaEvent e = null)
        {
            base.hide(e);
            Destroy();
        }
        
        public override void Destroy()
        {
            PlayerModel.Ins.removeChangeEvent(PlayerModel.GCROLENAME, gcRandomName);
            base.Destroy();
            UI = null;
        }
    }
}
