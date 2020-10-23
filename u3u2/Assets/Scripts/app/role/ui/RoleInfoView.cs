using app.human;
using app.model;
using app.pet;
using app.battle;
using UnityEngine;
using System.Collections;

namespace app.role
{
    public class RoleInfoView : BaseWnd
    {
        private const int WAIT_FRAME = 1;

        public RoleUI UI;

        private RoleInfoUI roleInfoUI;
        /// <summary>
        /// 角色信息逻辑
        /// </summary>
        private RoleInfoScript roleInfoScript;

        private RoleJiaDianUI jiadianUI;
        /// <summary>
        /// 加点逻辑
        /// </summary>
        private RoleJiaDianScript jiadianScript;

        public PetModel petmodel;
        public ChiBangModel chibangModel;
        public FunctionModel functionModel;


        public RoleInfoView()
        {
            uiName = "RoleInfoUI";
            hasSubUI = true;
        }

        public override void initWnd()
        {
            base.initWnd();

            petmodel = PetModel.Ins;
            petmodel.addChangeEvent(PetModel.UPDATE_PET_PROP, updatePetProp);
            petmodel.addChangeEvent(PetModel.UPDATE_PET_INFO, updatePetProp);
            petmodel.addChangeEvent(PetModel.UPDATE_PET_POOL, UpdatePetPool);
            chibangModel = ChiBangModel.Ins;
            functionModel = FunctionModel.Ins;

            UI = ui.AddComponent<RoleUI>();
            UI.Init();

            UI.tabButtonGroup.TabChangeHandler = tabChangeHandler;
        }
        
        private void tabChangeHandler(int index)
        {
            switch (index)
            {
                case 0:
                    if (!UI.roleInfoUI)
                    {
                        UI.StartCoroutine(InitRoleInfo(WAIT_FRAME));
                    }
                    else
                    {
                        roleInfoUI.Show();
                        roleInfoScript.ShowAvatarModel();
                        roleInfoScript.updateData();
                    }

                    if (jiadianUI != null)
                    {
                        jiadianUI.Hide();
                    }
                    UI.panelTitle.text = LangConstant.Role_INFO;

                    break;
                case 1:
                    if (roleInfoUI != null)
                    {
                        roleInfoScript.HideAvatarModel();
                        roleInfoUI.Hide();
                    }

                    UI.panelTitle.text = LangConstant.Role_Jiadian;
                    if (!UI.roleJiaDianUI)
                    {
                        UI.StartCoroutine(InitJiadianInfo(WAIT_FRAME));
                    }
                    else
                    {
                        PetModel.Ins.IsChongWu = true;
                        jiadianUI.Show();
                        jiadianScript.initAPropDian(Human.Instance.PetModel.getLeader().Id);
                        jiadianScript.show();
                    }
                    break;
                case 2:

                    break;
            }
            UI.tabButtonGroup.toggleList[index].isOn = true;
        }

        public override void show(RMetaEvent e = null)
        {
            base.show(e);
            app.main.GameClient.ins.OnBigWndShown();
            UI.tabButtonGroup.setHasAwake();
            int selectTab = 0;
            if (e != null)
            {
                object objTab = WndParam.GetWndParam(e, WndParam.SelectTab);
                if (objTab != null)
                {
                    if (int.TryParse(objTab.ToString(), out selectTab))
                    {
                        UI.tabButtonGroup.SetIndexWithCallBack(selectTab);
                    }
                }
                else
                {
                    updateCurrentPanel();
                }
            }
            else
            {
                updateCurrentPanel();
            }
            BattleModel.ins.roleInfoView = this;
            //if (roleInfoUI)
            //{
            //    roleInfoUI.objUseHuoli.SetActive(false);
            //}
        }

        private void updateCurrentPanel()
        {
            if (UI.tabButtonGroup.index != -1)
            {
                tabChangeHandler(UI.tabButtonGroup.index);
            }
            else
            {
                UI.tabButtonGroup.SetIndexWithCallBack(0);
            }
        }

        private void closeWnd()
        {
            hide();
        }

        public override void hide(RMetaEvent e = null)
        {
            if (jiadianScript != null)
            {
                jiadianScript.hide();
            }

            if (roleInfoScript != null)
            {
                roleInfoScript.HideAvatarModel();
            }
            
            base.hide(e);
            app.main.GameClient.ins.OnBigWndHidden();
            BattleModel.ins.roleInfoView = null;
        }

        public void updatePetProp(RMetaEvent e = null)
        {
            if (isShown)
            {
                updateCurrentPanel();
            }
        }

        public void UpdatePetPool(RMetaEvent e = null)
        {
            if (roleInfoScript != null)
            {
                roleInfoScript.UpdatePetPool(e);
            }
        }

        public override void Update()
        {
            base.Update();
            if (roleInfoScript != null)
            {
                roleInfoScript.Update();
            }
        }

        public void UpdateWingList(RMetaEvent e = null)
        {

        }

        public void UpdateCurWing(RMetaEvent e = null)
        {

        }

        IEnumerator InitRoleInfo(int waitFrame)
        {
            for (int i = 0; i < waitFrame; i++)
            {
                yield return null;
            }
            UI.roleInfoUI = GameObject.Instantiate(SourceManager.Ins.GetAsset<GameObject>(uiPath, uiName + "RoleInfo"));
            UI.roleInfoUI.transform.SetParent(UI.transform);
            UI.roleInfoUI.transform.localScale = Vector3.one;
            UI.roleInfoUI.SetActive(true);
            roleInfoUI = UI.roleInfoUI.AddComponent<RoleInfoUI>();
            roleInfoUI.Init();
            roleInfoScript = new RoleInfoScript(roleInfoUI);

            roleInfoScript.updateData();
            UI.closeBtn.SetClickCallBack(closeWnd);

        }

        IEnumerator InitJiadianInfo(int waitFrame)
        {
            for (int i = 0; i < waitFrame; i++)
            {
                yield return null;
            }
            UI.roleJiaDianUI = GameObject.Instantiate(SourceManager.Ins.GetAsset<GameObject>(uiPath, uiName + "JiaDian"));
            UI.roleJiaDianUI.transform.SetParent(UI.transform);
            UI.roleJiaDianUI.transform.localScale = Vector3.one;
            UI.roleJiaDianUI.gameObject.SetActive(true);
            jiadianUI = UI.roleJiaDianUI.AddComponent<RoleJiaDianUI>();
            jiadianUI.Init();
            jiadianScript = new RoleJiaDianScript(jiadianUI);

            jiadianScript.initAPropDian(Human.Instance.PetModel.getLeader().Id);
            UI.closeBtn.SetClickCallBack(closeWnd);
        }

        public override void Destroy()
        {
            petmodel.removeChangeEvent(PetModel.UPDATE_PET_PROP, updatePetProp);
            petmodel.removeChangeEvent(PetModel.UPDATE_PET_INFO, updatePetProp);
            petmodel.removeChangeEvent(PetModel.UPDATE_PET_POOL, UpdatePetPool);

            if (roleInfoScript != null)
            {
                roleInfoScript.Destroy();
                roleInfoScript = null;
            }

            if (jiadianScript != null)
            {
                jiadianScript.Destroy();
                jiadianScript = null;
            }

            base.Destroy();
            UI = null;
        }

        public void UpdateRoleInfoInBattle()
        {
            if (roleInfoScript != null)
            {
                roleInfoScript.UpdateRoleInfoInBattle();
            }
        }
    }
}