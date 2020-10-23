using System;
using System.Collections.Generic;
using app.role;
using app.db;
using anticheat;
using app.net;

namespace app.pet
{
    public class Pet : Role, IComparable<Pet>
    {
        // 唯一id
        private OLong id;
        public long Id
        {
            get { return id; }
            set { id = value; }
        }

        // 战斗属性管理器
        private PetPropertyManager propertyManager;

        public PetPropertyManager PropertyManager
        {
            get { return propertyManager; }
        }

        /// <summary>
        /// 消息中的武将信息缓存
        /// </summary>
        public PetInfo PetInfo
        {
            get { return petInfo; }
            set { petInfo = value; }
        }
        
        /// <summary>
        /// 宠物是否出战
        /// </summary>
        public bool isOnFight { get; set; }
        
        /// <summary>
        /// 当前血
        /// </summary>
        public int curHp { get; set; }
        
        /// <summary>
        /// 当前蓝
        /// </summary>
        public int curMp { get; set; }
        
        /// <summary>
        /// 当前怒气
        /// </summary>
        public int curSp { get; set; }
        
        /// <summary>
        /// 当前寿命（目前只有宠物有寿命）
        /// </summary>
        public int life { get; set; }

        /// <summary>
        /// 当前忠诚度
        /// </summary>
        public int loy { get; set; }
        /// <summary>
        /// 当前亲密度
        /// </summary>
        public int clo { get; set; }
        /// <summary>
        /// 到期时间
        /// </summary>
        public long deadline { get; set; }

        public SkillShortcutInfo[] skillShortcutInfos { get; set; }

        /// <summary>
        /// 武将装备增加的属性字典，缓存，在穿脱装备时清空
        /// </summary>
        private Dictionary<int, int> equipAddPropDic;

        /// <summary>
        /// 消息中的武将信息缓存
        /// </summary>
        private PetInfo petInfo;
        
        private PetTemplate petTpl;

        public Pet(long uuid):base(RoleTypes.PET)
        {
            this.id = uuid;
            this.propertyManager = new PetPropertyManager(this);

            //模板属性有了后，需要按照模板初始化武将
            //this.propertyManager.addPropChangedEvent(init, RoleBaseIntProperties.TEMPLET_ID);
        }

        public void init()
        {
            // 初始化武将技能
            initPetSkill();
        }

        private void initPetSkill()
        {

        }

        public bool isLeader()
        {
            return PetInfo.petType == (int)PetType.LEADER;
        }

        public int getLevel()
        {
            return this.propertyManager.getPetIntProp(RoleBaseIntProperties.LEVEL);
        }

        public int getStar()
        {
            return this.propertyManager.getPetIntProp(RoleBaseIntProperties.STAR);
        }

        public int getColorId()
        {
            return this.propertyManager.getPetIntProp(RoleBaseIntProperties.COLOR);
        }

        public string getName()
        {
            return this.propertyManager.getPetStringProp(RoleBaseStrProperties.NAME);
        }

        public int getTplId()
        {
            return this.propertyManager.getPetIntProp(RoleBaseIntProperties.TEMPLET_ID);
        }

        public int getFightPower()
        {
            return this.propertyManager.getPetIntProp(RoleBaseIntProperties.FIGHT_POWER);
        }

        public long getExp()
        {
            return this.propertyManager.getPetLongProp(RoleBaseStrProperties.EXP);
        }

        public long getExpLimit()
        {
            return this.propertyManager.getPetLongProp(RoleBaseStrProperties.LEVEL_UP_NEED_EXP);
        }

        public int getSex()
        {
            return getTpl().sexId;//this.propertyManager.getPetIntProp(RoleBaseIntProperties.SEX);
        }

        public int getJob()
        {
            return getTpl().jobId;//this.propertyManager.getPetIntProp(RoleBaseIntProperties.JOB_TYPE);
        }
        
        /**
         * 野兽、妖怪、精灵和人形
         */
        public int getBodyType()
        {
            return getTpl().petpetKindId;
        }

        public string getSexName()
        {
            int sex = getTpl().sexId;//this.propertyManager.getPetIntProp(RoleBaseIntProperties.SEX);
            return PetSexType.GetSexName(sex);
        }

        public string getJobName()
        {
            int job = getTpl().jobId;//this.propertyManager.getPetIntProp(RoleBaseIntProperties.JOB_TYPE);
            return PetJobType.GetJobName(job);
        }
        /// <summary>
        /// 是否正在出战
        /// </summary>
        /// <returns></returns>
        /*
        public bool IsPetOnFight()
        {
            int isfight = this.propertyManager.getPetIntProp(RoleBaseIntProperties.IS_FIGHT);
            return isfight == 1 ? true : false;
        }
        */
        /**
         * 获取武将模板对象
         */
        public PetTemplate getTpl()
        {
            if (petTpl == null)
            {
                petTpl = PetTemplateDB.Instance.getTemplate(petInfo.tplId);
            }
            return petTpl;
        }

        public bool isStarMax()
        {
            return getStar() >= ClientConstantDef.PET_MAX_STAR;
        }

        public bool isColorMax()
        {
            return getColorId() >= ConstantModel.Ins.GetIntValueByKey(ServerConstantDef.PET_MAX_QUALITY_ID);
        }

        /// <summary>
        /// 获取武将装备增加的属性字典
        /// </summary>
        /// <param name="petId"></param>
        /// <returns>可能为null</returns>
        public Dictionary<int, int> GetPetEquipAddProp()
        {
            return null;
            //if (equipAddPropDic != null)
            //{
            //    return equipAddPropDic;
            //}

            //Dictionary<int, int> aPropKeyDic = new Dictionary<int, int>();
            //equipAddPropDic = new Dictionary<int, int>();
            //ItemBag itembag = Human.Instance.PetModel.getEquipItemBag(this.Id);
            //if (itembag != null)
            //{
            //    //将所有装备增加的属性合并
            //    int c = itembag.itemList.Count;
            //    for (int i = 0; i < c; i++)
            //    {
            //        EquipItemTemplate equipTpl = itembag.itemList[i].equipItemTemplate;
            //        int c1 = equipTpl.propList.Count;
            //        for (int j = 0; j < c1; j++)
            //        {
            //            if (equipTpl.propList[j].propKey == null ||
            //                equipTpl.propList[j].propKey.Length <= 0)
            //            {
            //                continue;
            //            }

            //            int k = int.Parse(equipTpl.propList[j].propKey);
            //            int v = equipTpl.propList[j].propValue;
            //            int curV = 0;
            //            if (PropertyType.isPetAProp(k))
            //            {
            //                //一级属性加到一起，后面再处理
            //                if (aPropKeyDic.ContainsKey(k))
            //                {
            //                    aPropKeyDic.TryGetValue(k, out curV);
            //                    aPropKeyDic.Remove(k);
            //                }
            //                aPropKeyDic.Add(k, curV + v);
            //            }
            //            else
            //            {
            //                //二级属性，加到一起
            //                if (equipAddPropDic.ContainsKey(k))
            //                {
            //                    equipAddPropDic.TryGetValue(k, out curV);
            //                    equipAddPropDic.Remove(k);
            //                }
            //                equipAddPropDic.Add(k, curV + v);
            //            }
            //        }
            //    }

            //    //将一级属性转化为二级属性，与当前值合并
            //    Dictionary<int, int> addBDic = PetPropTemplateDB.Instance.getAddBPropValueDic(aPropKeyDic);
            //    foreach (int bk in addBDic.Keys)
            //    {
            //        int bv = 0;
            //        addBDic.TryGetValue(bk, out bv);
            //        if (bv > 0)
            //        {
            //            int curBv = 0;
            //            if (equipAddPropDic.ContainsKey(bk))
            //            {
            //                equipAddPropDic.TryGetValue(bk, out curBv);
            //                equipAddPropDic.Remove(bk);
            //            }
            //            equipAddPropDic.Add(bk, curBv + bv);
            //        }
            //    }
            //}
            //return equipAddPropDic;
        }

        /// <summary>
        /// 穿脱装备时，清空缓存
        /// </summary>
        public void onPutOnOffEquip()
        {
            //穿脱装备时，清空缓存
            if (this.equipAddPropDic != null)
            {
                this.equipAddPropDic.Clear();
                this.equipAddPropDic = null;
            }
        }

        public PetSkillInfo GetSkillInfo(int skillId)
        {
            int len = PetInfo.skillList.Length;
            for (int i = 0; i < len; i++)
            {
                if (PetInfo.skillList[i].skillId == skillId)
                {
                    return PetInfo.skillList[i];
                }
            }
            return null;
        }
        
        public int CompareTo(Pet pet)
        {
            if (pet == this)
            {
                return 0;
            }

            //bool thisIsOnFight = this.itemData.IsPetOnFight();
            bool thisIsOnFight = this.isOnFight;
            //bool itemIsOnFight = item.itemData.IsPetOnFight();
            bool itemIsOnFight = pet.isOnFight;

            if (thisIsOnFight != itemIsOnFight)
            {
                if (thisIsOnFight && !itemIsOnFight)
                {
                    return -1;
                }
                else if (!thisIsOnFight && itemIsOnFight)
                {
                    return 1;
                }
            }

            int thisLv = this.getLevel();
            int itemLv = pet.getLevel();

            if (thisLv > itemLv)
            {
                return -1;
            }
            else if (itemLv > thisLv)
            {
                return 1;
            }

            if (this.Id > pet.Id)
            {
                return -1;
            }
            else if (this.Id < pet.Id)
            {
                return 1;
            }

            return 0;
        }

        public override string ToString()
        {
            return "Pet [id=" + Id + ", name=" + getName() + ", level=" + getLevel() + "]";
        }

        public void Destroy()
        {
            // 唯一id
            id=0;
            Id = 0;
            petInfo = null;
            petTpl = null;
            isOnFight=false;
            curHp=0;
            curMp =0;
            curSp =0;
            life = 0;
            if (equipAddPropDic != null)
            {
                equipAddPropDic.Clear();
            }
        }

    }
}
