using UnityEngine;
using System.Collections.Generic;
using app.pet;
using UnityEngine.UI;
using app.net;
using app.utils;
using app.db;
using app.confirm;

namespace app.qichong
{
    public class QichongshuxingScript
    {
        private QichongShuxingUI UI;
        private List<Text> propAText = new List<Text>();
        private Pet currentPet;

        public QichongshuxingScript(QichongShuxingUI shuxingUI)
        {
            UI = shuxingUI;
            UI.buttonQicheng.SetClickCallBack(OnClickQicheng);
            UI.buttonFasheng.SetClickCallBack(OnClickFangSheng);
            UI.defaultText.gameObject.SetActive(false);
        }

        public void SetData(Pet pet)
        {
            currentPet = pet;
            if (pet == null)
            {
                UI.gameObject.SetActive(false);
                return;
            }
            UI.gameObject.SetActive(true);
            UpdatePropertyInfo(pet);
            SetButtonData(pet);
        }

        private void SetButtonData(Pet pet)
        {
            UI.textQicheng.text = pet.isOnFight ? "休息" : "骑乘";
        }

        private void UpdatePropertyInfo(Pet pet)
        {

            int len = propAText.Count;
            int end = PetAProperty._BEGIN + PetAProperty._SIZE;
            int cur = 0;
            for (int i = PetAProperty._BEGIN + 1; i <= PetAProperty.STAMINA + 1; i++)
            {
                string propName = LangConstant.getPetPropertyName(i);
                int propValue = pet.PropertyManager.getPetIntProp(i);

                Text t = null;
                if (len <= cur)
                {
                    t = GameObject.Instantiate(UI.defaultText);
                    t.gameObject.SetActive(true);
                    t.gameObject.transform.SetParent(UI.defaultText.gameObject.transform.parent);
                    t.gameObject.transform.localScale = UI.defaultText.gameObject.transform.localScale;
                    propAText.Add(t);
                    len++;
                }
                else
                {
                    t = propAText[cur];
                }

                t.gameObject.SetActive(true);

                if (i < PetAProperty.STAMINA + 1)
                {
                    t.text = propName + ": " + propValue;
                }
                else
                {
                    PetTemplate tpl = pet.getTpl();
                    if (tpl != null)
                    {
                        int colorId = tpl.fightLevel > PetModel.Ins.getLeader().getLevel() ? ColorUtil.RED_ID : ColorUtil.GREEN_ID;
                        t.text = "骑乘等级: " + ColorUtil.getColorText(colorId, tpl.fightLevel.ToString());
                    }
                }

                cur++;
            }



            if (cur < len - 1)
            {
                for (int i = cur + 1; i < len; i++)
                {
                    propAText[i].text = "";
                }
            }

        }

        private void OnClickFangSheng()
        {
            ConfirmWnd.Ins.ShowConfirm("放生之后的骑宠无法再次找回", "是否确认放生骑宠", confrimh);
        }

        private void confrimh(RMetaEvent e)
        {
            if (currentPet != null)
            {
                PetCGHandler.sendCGPetHorseFire(currentPet.Id);
            }
        }

        private void OnClickQicheng()
        {
            if (currentPet != null)
            {
                PetCGHandler.sendCGPetHorseRide(currentPet.Id, currentPet.isOnFight ? 0 : 1);
            }
        }

        public void Destroy()
        {
            if (propAText != null)
            {
                for (int i = 0; i < propAText.Count; i++)
                {
                    GameObject.DestroyImmediate(propAText[i].gameObject);
                }
                propAText.Clear();
                propAText = null;
            }
            GameObject.DestroyImmediate(UI.gameObject);
            UI = null;
        }
    }
}