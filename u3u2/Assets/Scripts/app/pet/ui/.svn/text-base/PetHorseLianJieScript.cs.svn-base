using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using app.human;
using app.net;

namespace app.pet
{
    public class PetHorseLianJieScript
    {
        List<Pet> m_PetList = null;
        List<PetHorseLianJiePackScript> m_Packs = new List<PetHorseLianJiePackScript>();
        Pet m_PetHorse = null;
        public PetHorseLianJieUI UI;

        public PetHorseLianJieScript(PetHorseLianJieUI ui)
        {
            UI = ui;
            UI.m_pack.Init();
            UI.m_pack.gameObject.SetActive(false);
            EventTriggerListener.Get(UI.m_closebtn.gameObject).onClick = ClickCloseBg;
            UI.m_savebtn.SetClickCallBack(ClickSave);
            UI.m_quxiaobtn.SetClickCallBack(ClickQuxiao);
        }

        public void show(Pet pethorse)
        {
            m_PetHorse = pethorse;
            if(null == m_PetHorse)
            {
                hide();
                return;
            }
            UI.show();
            RefreshPetLianjie();
        }

        public void hide()
        {
            UI.hide();
        }

        public void ClickCloseBg(UnityEngine.GameObject go)
        {
            hide();
        }

        public void RefreshPetLianjie()
        {
            m_PetList = Human.Instance.PetModel.getPetListByType(PetType.PET, true);
            int tlen = m_PetList.Count;
            for (int i = 0; i < tlen; i++)
            {
                if (i >= m_Packs.Count)
                {
                    PetHorseLianJiePackUI go = GameObject.Instantiate(UI.m_pack);
                    go.gameObject.SetActive(true);
                    go.transform.SetParent(UI.m_pack.transform.parent);
                    go.gameObject.transform.localScale = Vector3.one;
                    PetHorseLianJiePackScript temp = new PetHorseLianJiePackScript(go);
                    m_Packs.Add(temp);
                }
                m_Packs[i].SetPet(m_PetList[i],m_PetHorse);

            }

            for (int i = tlen; i < m_Packs.Count; ++i)
            {
                m_Packs[i].hide();
            }
        }

        private void ClickSave()
        {
            List<long> petids = new List<long>();
            List<int> flags = new List<int>();
            for (int i = 0; i < m_PetList.Count; ++i)
            {
                if (m_Packs[i].UI.m_check.isOn && 0 == m_PetList[i].PetInfo.soulLinkPetHorseId)
                {
                    //增加链接
                    petids.Add(m_PetList[i].Id);
                    flags.Add(1);
                }
                else if (!m_Packs[i].UI.m_check.isOn && 0 != m_PetList[i].PetInfo.soulLinkPetHorseId && m_PetHorse.Id == m_PetList[i].PetInfo.soulLinkPetHorseId)
                {
                    //取消链接
                    petids.Add(m_PetList[i].Id);
                    flags.Add(0);
                }
            }
            if (petids.Count > 0)
            {
                long[] petid = new long[petids.Count];
                int[] flag = new int[flags.Count];
                for (int i = 0; i < petids.Count; ++i)
                {
                    petid[i] = petids[i];
                    flag[i] = flags[i];
                }
                PetCGHandler.sendCGPetHorseSoulLinkPet(m_PetHorse.Id, petid, flag);
            }
            hide();
        }

        private void ClickQuxiao()
        {
            hide();
        }
    }
}
