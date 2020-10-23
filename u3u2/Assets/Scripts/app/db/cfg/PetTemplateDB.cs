using System;
using System.Collections;
using System.Collections.Generic;

namespace app.db
{
    public class PetTemplateDB : PetTemplateDBBase
    {
        // TODO 可能会自定义一些属性或方法

        public int getRandomTplId()
        {
            int count = getIdKeyDic().Keys.Count;
            int[] arr = new int[count];
            getIdKeyDic().Keys.CopyTo(arr, 0);
            int tplId = arr[UnityEngine.Random.Range(0, arr.Length)];
            return tplId;
        }

        public List<PetTemplate> getTuJianPetTplList(int type,int pettype)
        {
            List<PetTemplate> petlist = new List<PetTemplate>();
            foreach (KeyValuePair<int, PetTemplate> pair in idKeyDic)
            {
                if (pair.Value.typeId==type)
                {
                    if (pair.Value.sortId != 0)
                    {
                        if (type == 2)
                        {//宠物
                            if (pettype == -1)
                            {//不限制
                                petlist.Add(pair.Value);
                            }
                            else if (pettype != -1 && pair.Value.petpetTypeId == pettype)
                            {//0普通，1高级宠，2神兽
                                petlist.Add(pair.Value);
                            }
                        }
                        else
                        {//骑宠
                            petlist.Add(pair.Value);
                        }
                    }
                }
            }
            petlist.Sort(sortTuJian);
            return petlist;
        }

        private int sortTuJian(PetTemplate a,PetTemplate b)
        {
            //排序id由小到大，无排序id在有排序id的前面
            if (a.sortId > b.sortId)
            {
                return 1;
            }else if (a.sortId<b.sortId)
            {
                return -1;
            }
            return 0;
        }

        public int GetAttackType(int id)
        {
            foreach (KeyValuePair<int, PetTemplate> pair in idKeyDic)
            {
                if (pair.Value.Id == id)
                {
                    return pair.Value.attackTypeId;
                }
            }
            return 1;
        }

    }
}
