using System.Collections;
using System.Collections.Generic;
using BetaFramework;
using UnityEngine;

namespace Bag
{
    
    public class  PetItem : BaseItem
    {
        /// <summary>
        /// 当前小人的id
        /// </summary>
        
        public string currentPetId = Const.defaultPet;
        public Dictionary<string, int> petItems = new Dictionary<string, int>();
        public bool hasNewPet = false;
        public PetItem()
        {
            loadPetData();
            if (!petItems.ContainsKey(Const.defaultPet))
            {
                petItems.Add(Const.defaultPet,1);
            }
        }

        private void loadPetData()
        {
            //初始化数据
            if (petItems.Count == 0)
            {
                petItems.Add(Const.defaultPet,1);
            }

           // testData();
        }

        //增加一个小人
        public void AddPet(string petId)
        {
            hasNewPet = true;
            bool isFindId = false;
            foreach (var item in petItems)
            {
                string id = item.Key;
                if (id != null && id.Equals(petId))
                {
                    isFindId = true;
                }
            }

            if (!isFindId)
            {
                petItems.Add(petId,1);
                Save();
            }
        }
        
        public void Save()
        {
            //AppEngine.SSystemManager.GetSystem<BagSystem>().SaveProperty(this,null);
        }
    }

}
