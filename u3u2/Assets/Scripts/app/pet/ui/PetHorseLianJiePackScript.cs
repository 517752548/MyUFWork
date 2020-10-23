using UnityEngine;
using System.Collections;
using app.utils;
using app.human;

namespace app.pet
{
    public class PetHorseLianJiePackScript
    {
        public PetHorseLianJiePackUI UI;
        private Pet m_Pet;
        private Pet m_PetHorse;

        public PetHorseLianJiePackScript(PetHorseLianJiePackUI ui)
        {
            UI = ui;
            
        }

        public void SetPet(Pet pet,Pet pethorse)
        {
            m_Pet = pet;
            m_PetHorse = pethorse;
            if (null != pet)
            {
                UI.m_check.onValueChanged.RemoveAllListeners();
                UI.gameObject.SetActive(true);
                UI.m_petname.text = pet.getName();
                UI.m_check.interactable = true;
                UI.m_check.isOn = false;
                ColorUtil.DeGray(UI.m_checkbg);
                ///是否已经链接骑宠
                if (0 == m_Pet.PetInfo.soulLinkPetHorseId)
                {
                    UI.m_pethorsename.text = "";
                }
                else
                {
                    
                    
                    
                    ///判断骑宠是否为当前骑宠
                    if (pethorse.Id != m_Pet.PetInfo.soulLinkPetHorseId)
                    {
                        Pet temp = Human.Instance.PetModel.getPet(m_Pet.PetInfo.soulLinkPetHorseId);
                        if (null != temp)
                        {
                            UI.m_pethorsename.text = temp.getName();
                            UI.m_check.interactable = false;
                            ColorUtil.Gray(UI.m_checkbg);
                        }
                        else
                        {
                            m_Pet.PetInfo.soulLinkPetHorseId = 0;
                            UI.m_pethorsename.text = "";
                        }
                    }
                    else
                    {
                        UI.m_pethorsename.text = pethorse.getName();
                        UI.m_check.isOn = true;
                    }
                }
                UI.m_check.onValueChanged.AddListener(CheckChange);
            }
            else
            {
                hide();
            }
        }

        public void hide()
        {
            UI.gameObject.SetActive(false);
        }

        public void CheckChange(bool ischange)
        {
            if (ischange)
            {
                UI.m_pethorsename.text = m_PetHorse.getName();
            }
            else
            {
                UI.m_pethorsename.text = "";
            }
        }

    }
}
