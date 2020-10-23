using System.Collections.Generic;
using System.Linq;
using app.bag;
using app.human;
using app.net;
using app.item;
using app.zone;

namespace app.pet
{
    public class PetModel : AbsModel
    {
        public const string UPDATE_PET_EQUIP_BAG_EVENT = "UPDATE_PET_EQUIP_BAG_EVENT";
        public const string UPDATE_PET_EQUIP_BAG_LIST_EVENT = "UPDATE_PET_EQUIP_BAG_LIST_EVENT";
        public const string UPDATE_PET_GEM_BAG_EVENT = "UPDATE_PET_GEM_BAG_EVENT";
        public const string UPDATE_PET_GEM_BAG_LIST_EVENT = "UPDATE_PET_GEM_BAG_LIST_EVENT";
        public const string UPDATE_PET_PROP = "UPDATE_PET_PROP";
        public const string UPDATE_PET_INFO = "UPDATE_PET_INFO";
        public const string UPDATE_HUMAN_PROP = "UPDATE_HUMAN_PROP";
        public const string UPDATE_PET_LIST = "UPDATE_PET_LIST";
        public const string UPDATE_XINFA_LEVEL = "UPDATE_XINFA_LEVEL";
        public const string UPDATE_CURRENT_XINFA = "UPDATE_CURRENT_XINFA";

        public const string UPDATE_PET_FRIEND_ARRAY = "UPDATE_PET_FRIEND_ARRAY";

        public const string UPDATE_PET_FIGHT_STATE = "UPDATE_PET_FIGHT_STATE";

        public const string UPDATE_PET_POOL = "UPDATE_PET_POOL";

        public const string UPDATE_PET_Chenghao = "UPDATE_PET_Chenghao"; //更新称号列表

        public const string FIRE_PET_HORSE_RESLT = "FIRE_PET_HORSE_RESLT";//放生骑宠结果

        public const string PET_HORSE_CHANGE_NAME = "PET_HORSE_CHANGE_NAME";//骑宠改名

        public const string PET_HORSE_HUAN_TONG = "PET_HORSE_HUAN_TONG";//骑宠还童

        public const string PET_JINENG_LAN_UPDATE = "PET_JINENG_LAN_UPDATE";///宠物技能栏更新
        public const string UPDATE_SERVER_TIME = "UPDATE_SERVER_TIME";
        //public const string PET_QUICK_SKILL_REFRESH = "PET_QUICK_SKILL_REFRESH";///宠物快捷技能更新
        //public const string PET_ZIZHIDAN_UPDATE = "PET_ZIZHIDAN_UPDATE";///更新资质丹选择

        public PetFriendArrayInfo[] petFriendArrayInfoList { get; private set; }
        public int curPetFriendArrayIdx { get; private set; }

        public long hpPoolValue { get; private set; }
        public long mpPoolValue { get; private set; }
        public long lifePoolValue { get; private set; }

        // 武将字典，key为武将唯一id
        private Dictionary<long, Pet> petDic = new Dictionary<long, Pet>();

        //模板Id索引的字典，方便按模板Id查找武将
        private Dictionary<int, long> petTplIdDic = new Dictionary<int, long>();

        //英雄装备背包,英雄id做Key
        private Dictionary<long, ItemBag> petBagDic = new Dictionary<long, ItemBag>();

        //英雄宝石背包,英雄id做Key
        private Dictionary<long, ItemBag> petGemBagDic = new Dictionary<long, ItemBag>();

        //主将，即玩家对应的武将
        private Pet leader;
        private Pet ridePet;
        /// <summary>
        /// 当前打开界面是宠物还是骑宠
        /// </summary>
        private bool m_IsChongWu = true;
        public bool IsChongWu
        {
            get
            {
                return m_IsChongWu;
            }
            set
            {
                m_IsChongWu = value;
            }
        }
        private static PetModel _ins;
        public static PetModel Ins
        {
            get
            {
                if (_ins == null)
                {
                    //_ins = Singleton.getObj(typeof(PetModel)) as PetModel;
                    _ins = new PetModel();
                }
                return _ins;
            }
        }
     
        public PetModel()
        {
            petFriendArrayInfoList = null;
            curPetFriendArrayIdx = -1;
        }

        public void initPetList(List<Pet> petList)
        {
            if (petList == null || petList.Count <= 0)
            {
                return;
            }

            int len = petList.Count;
            for (int i = 0; i < len; i++)
            {
                ClientLog.Log("init AddPetId :" + petList[i].Id.ToString() + " pettype:" + petList[i].RoleType);
                addPet(petList[i]);
            }
            
            ridePet = null;
            
            List<Pet> ridePets = getPetListByType(PetType.PET_FOR_RIDE);
            len = ridePets.Count;
            for (int i = 0; i < len; i++)
            {
                if (ridePets[i].isOnFight)
                {
                    ridePet = ridePets[i];
                    break;
                }
            }
        }

        public Pet getPet(long id)
        {
            Pet pet = null;
            if (petDic.ContainsKey(id))
            {
                petDic.TryGetValue(id, out pet);
            }
            return pet;
        }

        public Pet getPetByTplId(int petTplId)
        {
            long petId = 0;
            if (petTplIdDic.ContainsKey(petTplId))
            {
                petTplIdDic.TryGetValue(petTplId, out petId);
            }
            if (petId > 0)
            {
                return getPet(petId);
            }
            return null;
        }

        public bool hasPet(int petTplId)
        {
            return getPetByTplId(petTplId) != null;
        }

        public bool addPet(Pet pet)
        {
            if (null != pet)
            {
                long id = pet.Id;
                // 武将Id是否合法，且武将不是已经有的武将
                if (id > 0 && getPet(pet.Id) == null)
                {
                    petDic.Add(id, pet);
                    if (!petTplIdDic.ContainsKey(pet.getTplId()))
                    {
                        petTplIdDic.Add(pet.getTplId(), pet.Id);
                    }
                    if (pet.isLeader())
                    {
                        this.leader = pet;
                    }
                    return true;
                }
            }
            return false;
        }

        public void dispathcAddPet()
        {
            dispatchChangeEvent(UPDATE_PET_LIST, null);
        }

        public void UpdatePetInfo(PetInfo info)
        {
            Pet pet = getPet(info.petId);
            if (pet != null)
            {
                pet.PetInfo = info;
                dispatchChangeEvent(UPDATE_PET_INFO, pet.Id);
            }
        }

        public Pet UpdatePetIntProps(long uuid, KeyValuePairIntData[] propsArr)
        {
            Pet pet = getPet(uuid);
            if (pet != null)
            {
                pet.PropertyManager.updateIntDic(propsArr);
                //  if (pet.PetInfo.petType == (int)PetType.PET_FOR_RIDE)
                //   {
                //      pet.isOnFight = (pet.PropertyManager.getPetIntProp(RoleBaseIntProperties.IS_FIGHT) == 1);
                //   }
                dispatchPetPropChange(pet.Id);
            }
            return pet;
        }

        private void updatePetAPropAdd(GCPetAddPoint msg)
        {
            if (msg.getResult() == 1)
            {
                Pet pet;
                petDic.TryGetValue(msg.getPetId(), out pet);
                if (pet != null)
                {
                    pet.PetInfo.aPropAddArr = msg.getAPropAddArr();
                }
            }
        }

        public void removePet(long petId)
        {
            Pet pet = getPet(petId);
            if (pet != null)
            {
                petDic.Remove(pet.Id);
                petTplIdDic.Remove(pet.getTplId());
                petTplIdDic.Add(pet.getTplId(), pet.Id);
            }
            dispatchChangeEvent(UPDATE_PET_LIST, null);
        }

        public Pet getLeader()
        {
            return leader;
        }
        
        public Pet getRidePet()
        {
            return ridePet;
        }

        public Pet getChongWu(bool isOnFight = true)
        {
            List<Pet> petlist = getPetListByType(PetType.PET);
            for (int i = 0; i < petlist.Count; i++)
            {
                //if (isOnFight&&petlist[i].IsPetOnFight())
                if (isOnFight && petlist[i].isOnFight)
                {
                    return petlist[i];
                }
                else if (!isOnFight)
                {
                    return petlist[i];
                }
            }
            return null;
        }

        public Pet getFirstChongWu()
        {
            List<Pet> petlist = getPetListByType(PetType.PET);
            if (petlist != null && petlist.Count > 0) return petlist[0];
            return null;
        }

        public PetSkillInfo[] GetLeaderSkillInfoList()
        {
            return getLeader().PetInfo.skillList;
        }

        public bool IsLeaderSkillOpen(int skillTplId)
        {
            PetSkillInfo[] skillList = GetLeaderSkillInfoList();
            for (int i = 0; i < skillList.Length; i++)
            {
                if (skillList[i].skillId == skillTplId)
                {
                    return true;
                }
            }
            return false;
        }

        public PetSkillInfo GetLeaderSkillInfo(int skillTplId)
        {
            PetSkillInfo[] skillList = GetLeaderSkillInfoList();
            for (int i = 0; i < skillList.Length; i++)
            {
                if (skillList[i].skillId == skillTplId)
                {
                    return skillList[i];
                }
            }
            return null;
        }

        public PetSkillInfo[] GetPetSkillInfoList()
        {
            Pet pet = getChongWu();
            if (pet != null)
            {
                return pet.PetInfo.skillList;
            }
            return null;
        }

        public List<Pet> getAllPet()
        {
            List<Pet> petList = new List<Pet>(petDic.Count);
            foreach (long id in petDic.Keys)
            {
                petList.Add(getPet(id));
            }
            return petList;
        }
        /// <summary>
        /// 根据类型获得pet列表
        /// </summary>
        /// <param name="pettype"></param>
        /// <returns></returns>
        public List<Pet> getPetListByType(PetType petType,bool sort=false)
        {
            List<Pet> petList = new List<Pet>();
            foreach (long id in petDic.Keys)
            {
                Pet pet = getPet(id);
                if (pet != null && pet.PetInfo.petType == (int)petType)
                {
                    petList.Add(pet);
                }
            }
            if (sort)
            {
                petList.Sort((a, b) => a.CompareTo(b));
            }
            return petList;
        }

        private List<int> getSortedPetList()
        {
            List<int> petList = new List<int>(petDic.Count);
            foreach (long id in petDic.Keys)
            {
                petList.Add(getPet(id).getTplId());
            }
            petList.Sort(ownedListSortor);
            return petList;
        }

        private int ownedListSortor(int aId, int bId)
        {
            Pet a = getPetByTplId(aId);
            Pet b = getPetByTplId(bId);
            return ownedListSortor(a, b);
        }

        private int ownedListSortor(Pet a, Pet b)
        {
            //优先按照等级由高到低进行排序，等级相同则按照星级由高到低进行排序，星级相同则按照品阶由高到低进行排序，再相同则按照英雄ID有小到大进行排序
            int levelA = a.getLevel();
            int levelB = b.getLevel();
            int starA = a.getStar();
            int starB = b.getStar();
            int colorA = a.getColorId();
            int colorB = b.getColorId();
            long idA = a.Id;
            long idB = b.Id;
            //等级
            if (levelA > levelB)
            {
                return -1;
            }
            else if (levelA < levelB)
            {
                return 1;
            }
            //星级
            if (starA > starB)
            {
                return -1;
            }
            else if (starA < starB)
            {
                return 1;
            }
            //品质
            if (colorA > colorB)
            {
                return -1;
            }
            else if (colorA < colorB)
            {
                return 1;
            }
            //唯一Id
            if (idA < idB)
            {
                return -1;
            }
            else if (idA > idB)
            {
                return 1;
            }

            return 0;
        }

        public void petAddPointCallBack(GCPetAddPoint msg)
        {
            if (msg.getResult() == 1)
            {
                updatePetAPropAdd(msg);
                dispatchChangeEvent(UPDATE_PET_PROP, msg.getPetId());
            }
        }
        public void GCPetChangeFightStateHandler(GCPetChangeFightState msg)
        {
            if (msg.getResult() == 1)
            {
                UpdatePetFightState(msg.getPetId(), msg.getState());
            }
        }

        public void GCPetHorseChangeFightState(GCPetHorseRide horseRide)
        {
            if (horseRide.getResult() == 1)
            {
                UpdatePetFightState(horseRide.getPetId(), horseRide.getState());
            }
        }

        public void UpdatePetFightState(long uuid, int state)
        {
            Pet changedPet = null;
            if (petDic.ContainsKey(uuid))
            {
                changedPet = petDic[uuid];
                changedPet.isOnFight = (state == 1);
                
                if ((PetType)changedPet.PetInfo.petType == PetType.PET_FOR_RIDE)
                {
                    if (changedPet.isOnFight)
                    {
                        ridePet = changedPet;
                    }
                    else
                    {
                        ridePet = null;
                    }
                }
                
                //dispatchChangeEvent(UPDATE_PET_PROP, msg.getPetId());
            }

            if (changedPet != null)
            {
                PetType petType = (PetType)changedPet.PetInfo.petType;
                List<Pet> sameTypePets = this.getPetListByType(petType);
                int petsLen = sameTypePets.Count;

                for (int i = 0; i < petsLen; i++)
                {
                    if (sameTypePets[i].isOnFight)
                    {
                        if (sameTypePets[i].Id != uuid)
                        {
                            if (sameTypePets[i].isOnFight)
                            {
                                sameTypePets[i].isOnFight = false;
                                //dispatchChangeEvent(UPDATE_PET_PROP, allPet[i].Id);
                            }
                        }
                    }
                }
                dispatchChangeEvent(UPDATE_PET_FIGHT_STATE, uuid);
            }
        }

        public void GCPetChangeNameHandler(GCPetChangeName msg)
        {
            if (msg.getResult() == 1)
            {
                dispatchChangeEvent(UPDATE_PET_PROP, msg.getPetId());
            }
        }
        public void GCPetVariationHandler(GCPetVariation msg)
        {
            if (msg.getResult() == 1)
            {
                ZoneBubbleManager.ins.BubbleSysMsg("恭喜您，变异成功，获得一只变异宠！");
            }
            else
            {
                ZoneBubbleManager.ins.BubbleSysMsg("很遗憾，变异失败，请再接再厉！");
            }
        }

        public void GCEqpCraftHandler(GCEqpCraft msg)
        {
            if (msg.getResult() == 1)
            {
                ZoneBubbleManager.ins.BubbleSysMsg("恭喜你，打造成功！");
            }
            else
            {
                ZoneBubbleManager.ins.BubbleSysMsg("很遗憾！打造失败");
            }
        }

        public void GCEqpUpstarHandler(GCEqpUpstar msg)
        {
            if (msg.getResult() == 1)
            {
                ZoneBubbleManager.ins.BubbleSysMsg("恭喜你，升星成功！");
            }
            else
            {
                ZoneBubbleManager.ins.BubbleSysMsg("很遗憾！升星失败");
            }
        }

        /// <summary>
        /// 派发主角信息改变事件
        /// </summary>
        public void dispatchPetPropChange(long petid)
        {
            dispatchChangeEvent(UPDATE_PET_PROP, petid);
        }

        /// <summary>
        /// 派发主角信息改变事件
        /// </summary>
        public void dispatchHumanPropChange()
        {
            dispatchChangeEvent(UPDATE_HUMAN_PROP, null);

        }

        public void dispatchPetHorseNameChange()
        {
            dispatchChangeEvent(PET_HORSE_CHANGE_NAME, null);
        }

        /// <summary>
        /// 派发心法切换事件
        /// </summary>
        public void dispatchCurrentXinFaChange()
        {
            dispatchChangeEvent(UPDATE_CURRENT_XINFA, null);
        }

        #region 英雄装备包内容
        /// <summary>
        /// 设置背包
        /// </summary>
        /// <param name="gcBagUpdate"></param>
        public void setItemList(GCBagUpdate gcBagUpdate)
        {
            ItemBag itembag = getEquipItemBag(gcBagUpdate.getWearerId());
            if (itembag == null)
            {
                itembag = new ItemBag();
            }
            itembag.setItemBag(gcBagUpdate);
            petBagDic.Add(gcBagUpdate.getWearerId(), itembag);
        }

        /// <summary>
        /// 根据背包id和英雄id 获得背包
        /// </summary>
        /// <param name="bagId"></param>
        /// <returns></returns>
        public ItemBag getEquipItemBag(long wearerId)
        {
            if (petBagDic.ContainsKey(wearerId))
            {
                ItemBag itembag;
                petBagDic.TryGetValue(wearerId, out itembag);
                return itembag;
            }
            return null;
        }

        /// <summary>
        /// 获得主将背包
        /// </summary>
        /// <param name="bagId"></param>
        /// <returns></returns>
        public ItemBag getLeaderEquipItemBag()
        {
            long wearerId = getLeader().Id;
            if (petBagDic.ContainsKey(wearerId))
            {
                ItemBag itembag;
                petBagDic.TryGetValue(wearerId, out itembag);
                return itembag;
            }
            return null;
        }

        public void itemsUpdate(List<CommonItemData> items)
        {
            List<long> wearerIds = new List<long>();
            List<KeyValuePair<int, ItemDetailData[]>> list = new List<KeyValuePair<int, ItemDetailData[]>>();
            int len = items.Count;
            for (int i = 0; i < len; i++)
            {
                CommonItemData item = items[i];
                long petId = item.wearerId;
                if (!wearerIds.Contains(petId))
                {
                    wearerIds.Add(petId);
                }
                ItemBag itembag = getEquipItemBag(petId);
                int oldValue = itembag.getHasNumByIndex(item.index);
                if (item.count == -1)
                {
                    //删除
                    ItemDetailData removedItem = itemRemove(item.wearerId, item.index, false);
                    if (removedItem != null)
                    {
                        list.Add(new KeyValuePair<int, ItemDetailData[]>(-1, new ItemDetailData[]{removedItem}));
                    }
                }
                else
                {
                    ItemDetailData oldItem = itemUpdate(item, false);
                    if (oldItem == null)
                    {
                        list.Add(new KeyValuePair<int, ItemDetailData[]>(1, new ItemDetailData[]{ itembag.getItemByUUID(item.uuid) }));
                    }
                    else
                    {
                        list.Add(new KeyValuePair<int, ItemDetailData[]>(0, new ItemDetailData[]{oldItem, itembag.getItemByUUID(item.uuid)}));
                    }
                }
                Human.Instance.ItemChangeHandler(item, oldValue);
            }

            len = wearerIds.Count;
            for (int i = 0; i < len; i++)
            {
                getPet(wearerIds[i]).onPutOnOffEquip();
            }

            dispatchChangeEvent(UPDATE_PET_EQUIP_BAG_LIST_EVENT, list);

            Human.Instance.UpdatePlayerModel();
        }

        /// <summary>
        /// 物品槽加入物品或物品槽更新
        /// </summary>
        /// <param name="itemupdate"></param>
        public ItemDetailData itemUpdate(CommonItemData itemupdate, bool updateNow = true)
        {
            long petId = itemupdate.wearerId;
            ItemBag itembag = getEquipItemBag(petId);
            if (itembag == null)
            {//没有这个物品的包，创建新背包，并且放入
                itembag = new ItemBag();
            }
            
            ItemDetailData oldItemData = itembag.getItemByIndex(itemupdate.index);
            bool add = itembag.updateItem(itemupdate);

            if (updateNow)
            {
                //穿脱装备需要更新武将
                getPet(itemupdate.wearerId).onPutOnOffEquip();
                if (add)
                {
                    dispatchChangeEvent(UPDATE_PET_EQUIP_BAG_EVENT, new KeyValuePair<int, ItemDetailData[]>(1, new ItemDetailData[]{itembag.getItemByUUID(itemupdate.uuid)}));
                }
                else
                {
                    dispatchChangeEvent(UPDATE_PET_EQUIP_BAG_EVENT, new KeyValuePair<int, ItemDetailData[]>(0, new ItemDetailData[]{oldItemData, itembag.getItemByUUID(itemupdate.uuid)}));
                }

                Human.Instance.UpdatePlayerModel();
            }

            if (add)
            {
                return null;
            }
            return oldItemData;
        }

        /// <summary>
        /// 删除一个物品
        /// </summary>
        /// <param name="itemupdate"></param>
        public ItemDetailData itemRemove(long wearerId, int index, bool updateNow = true)
        {
            ItemBag itembag = getEquipItemBag(wearerId);
            if (itembag == null)
            {//没有这个物品的包，创建新背包，并且放入
                //itembag = new ItemBag();
                return null;
            }

            ItemDetailData itemData = itembag.getItemByIndex(index);
            if (itemData != null)
            {
                itembag.removeItem(index);
                if (updateNow)
                {
                    dispatchChangeEvent(UPDATE_PET_EQUIP_BAG_EVENT, new KeyValuePair<int, ItemDetailData[]>(-1, new ItemDetailData[]{itemData}));
                    Human.Instance.UpdatePlayerModel();

                    //穿脱装备需要更新武将
                    getPet(wearerId).onPutOnOffEquip();
                }
            }
            return itemData;
        }

        /// <summary>
        /// 删除一个物品
        /// </summary>
        /// <param name="itemupdate"></param>
        /*
        public void itemRemove(GCRemoveItem itemRemove)
        {
            ItemBag itembag = getEquipItemBag(itemRemove.getWearerId());
            if (itembag == null)
            {//没有这个物品的包，创建新背包，并且放入
                itembag = new ItemBag();
            }
            itembag.removeItem(itemRemove.getIndex());
            dispatchChangeEvent(UPDATE_PET_EQUIP_BAG_EVENT, null);
            Human.Instance.UpdatePlayerModel();
            //穿脱装备需要更新武将
            getPet(itemRemove.getWearerId()).onPutOnOffEquip();
        }
        */

        /// <summary>
        /// 交换两个物品
        /// </summary>
        /// <param name="itemSwap"></param>
        public void itemSwap(GCSwapItem itemSwap)
        {
            ItemBag ToItemBag = null;
            ItemBag FromItemBag = null;
            if (itemSwap.getToBagId() == ItemDefine.BagId.MAIN_BAG)
            {//To主背包
                ToItemBag = Human.Instance.BagModel.getItemBag(ItemDefine.BagId.MAIN_BAG);
            }
            else if (itemSwap.getToBagId() == ItemDefine.BagId.PET_BAG)
            {//To武将背包
                ToItemBag = Human.Instance.PetModel.getEquipItemBag(itemSwap.getToWearerId());
            }
            if (itemSwap.getFromBagId() == ItemDefine.BagId.MAIN_BAG)
            {//From主背包
                FromItemBag = Human.Instance.BagModel.getItemBag(ItemDefine.BagId.MAIN_BAG);
            }
            else if (itemSwap.getFromBagId() == ItemDefine.BagId.PET_BAG)
            {//From武将背包
                FromItemBag = Human.Instance.PetModel.getEquipItemBag(itemSwap.getFromWearerId());
            }
            if (ToItemBag != null && FromItemBag != null)
            {
                //取出 To 和 From 的当前数据
                ItemDetailData toItemDetail = ToItemBag.getItemByIndex(itemSwap.getToIndex());
                ItemDetailData fromItemDetail = FromItemBag.getItemByIndex(itemSwap.getFromIndex());
                //将from放到to上
                CommonItemData toItemUpdate = new CommonItemData();
                toItemUpdate.bagId = itemSwap.getToBagId();
                toItemUpdate.index = itemSwap.getToIndex();
                toItemUpdate.tplId = fromItemDetail.commonItemData.tplId;
                toItemUpdate.uuid = fromItemDetail.commonItemData.uuid;
                toItemUpdate.count = fromItemDetail.commonItemData.count;
                toItemUpdate.lastUpdateTime = fromItemDetail.commonItemData.lastUpdateTime;
                toItemUpdate.props = fromItemDetail.commonItemData.props;
                if (itemSwap.getToBagId() == ItemDefine.BagId.MAIN_BAG)
                {
                    toItemUpdate.wearerId = 0;
                }
                else
                {
                    toItemUpdate.wearerId = fromItemDetail.commonItemData.wearerId;
                }
                ToItemBag.updateItem(toItemUpdate);
                
                int res = 0;

                if (toItemDetail != null)
                {//To有物品,放到from上去
                    CommonItemData fromItemUpdate = new CommonItemData();
                    fromItemUpdate.bagId = itemSwap.getFromBagId();
                    fromItemUpdate.index = itemSwap.getFromIndex();
                    fromItemUpdate.tplId = toItemDetail.commonItemData.tplId;
                    fromItemUpdate.uuid = toItemDetail.commonItemData.uuid;
                    fromItemUpdate.count = toItemDetail.commonItemData.count;
                    fromItemUpdate.lastUpdateTime = toItemDetail.commonItemData.lastUpdateTime;
                    fromItemUpdate.wearerId = toItemDetail.commonItemData.wearerId;
                    fromItemUpdate.props = toItemDetail.commonItemData.props;
                    FromItemBag.updateItem(fromItemUpdate);

                    if (itemSwap.getFromBagId()==ItemDefine.BagId.MAIN_BAG)
                    {
                        BagModel.Ins.dispatchChangeEvent(BagModel.UPDATE_ITEM_EVENT, FromItemBag.getItemByUUID(fromItemUpdate.uuid));
                    }
                    if (itemSwap.getToBagId()==ItemDefine.BagId.MAIN_BAG)
                    {
                        BagModel.Ins.dispatchChangeEvent(BagModel.UPDATE_ITEM_EVENT, ToItemBag.getItemByUUID(toItemUpdate.uuid));
                    }
                }
                else
                {//To没有物品，删除from数据
                    string itemuuid = FromItemBag.removeItem(itemSwap.getFromIndex());
                    if (itemSwap.getFromBagId() == ItemDefine.BagId.MAIN_BAG&&itemuuid!=null)
                    {
                        BagModel.Ins.dispatchChangeEvent(BagModel.REMOVE_ITEM_EVENT, itemuuid);
                    }
                    if (itemSwap.getToBagId()==ItemDefine.BagId.MAIN_BAG)
                    {
                        BagModel.Ins.dispatchChangeEvent(BagModel.ADD_ITEM_EVENT, ToItemBag.getItemByUUID(toItemUpdate.uuid));
                    }
                    
                    res = -1;
                }
                switch (fromItemDetail.itemTemplate.itemTypeId)
                {
                    case ItemDefine.ItemTypeDefine.EQUIP:
                        KeyValuePair<int, ItemDetailData[]> kv;
                        if (itemSwap.getFromBagId() == ItemDefine.BagId.PET_BAG)
                        {
                            if (fromItemDetail != null)
                            {
                                kv = new KeyValuePair<int, ItemDetailData[]>(res, new ItemDetailData[]{fromItemDetail});
                            }
                            else
                            {
                                kv = new KeyValuePair<int, ItemDetailData[]>(res, null);
                            }
                            dispatchChangeEvent(UPDATE_PET_EQUIP_BAG_EVENT, kv);
                        }
                        else if (itemSwap.getToBagId() == ItemDefine.BagId.PET_BAG)
                        {
                            if (toItemDetail != null)
                            {
                                kv = new KeyValuePair<int, ItemDetailData[]>(res, new ItemDetailData[]{toItemDetail});
                            }
                            else
                            {
                                kv = new KeyValuePair<int, ItemDetailData[]>(res, null);
                            }
                            dispatchChangeEvent(UPDATE_PET_EQUIP_BAG_EVENT, kv);
                        }
                        
                        Human.Instance.UpdatePlayerModel();
                        break;
                    case ItemDefine.ItemTypeDefine.GEM:
                        dispatchChangeEvent(UPDATE_PET_GEM_BAG_EVENT, null);
                        break;
                    default:
                        break;
                }
                Human.Instance.BagModel.dispatchChangeEvent(BagModel.UPDATE_BAG_EVENT, null);
            }
        }

        /// <summary>
        /// 武将是否已穿满9件装备
        /// </summary>
        /// <param name="petId"></param>
        /// <returns></returns>
        public bool isPetEquipFull(long petId)
        {
            ItemBag bag = getEquipItemBag(petId);
            if (bag != null)
            {
                ClientLog.LogWarning(bag.itemList.Count);

                return bag.itemList.Count >= ClientConstantDef.PET_MAX_EQUIP_NUM;
            }
            return false;
        }

        #endregion

        /// <summary>
        /// 获得当前穿的时装的id
        /// </summary>
        /// <returns></returns>
        public int GetFashionTplId()
        {
            ItemBag leaderBag = Human.Instance.PetModel.getLeaderEquipItemBag();
            if (leaderBag != null)
            {
                ItemDetailData shizhuangData = leaderBag.getEquipItemDetailByPosition(ItemDefine.ItemPositionDefine.FASHION);
                if (shizhuangData != null)
                {
                    return shizhuangData.equipItemTemplate.Id;
                }
            }
            return -1;
        }

        /// <summary>
        /// 获得当前穿的时装的模型
        /// </summary>
        /// <returns></returns>
        public string GetFashionModelString()
        {
            ItemBag leaderBag = Human.Instance.PetModel.getLeaderEquipItemBag();
            if (leaderBag != null)
            {
                ItemDetailData shizhuangData = leaderBag.getEquipItemDetailByPosition(ItemDefine.ItemPositionDefine.FASHION);
                if (shizhuangData != null)
                {
                    return shizhuangData.itemTemplate.modelId;
                }
            }
            return null;
        }

        public void UpdateFashionWear()
        {

        }

        public void UpdatePetFriendArrayInfoList(PetFriendArrayInfo[] infoList, int curIdx)
        {
            petFriendArrayInfoList = infoList;
            curPetFriendArrayIdx = curIdx;
            dispatchChangeEvent(UPDATE_PET_FRIEND_ARRAY, null);
        }

        public void GCPetCurPropUpdateHandler(GCPetCurPropUpdate msg)
        {
            Pet pet = getPet(msg.getPetId());
            if (pet != null)
            {
                pet.curHp = msg.getHp();
                pet.curMp = msg.getMp();
                pet.curSp = msg.getSp();
                pet.life = msg.getLife();
                dispatchChangeEvent(UPDATE_PET_PROP, pet.Id);
            }
        }

        public void GCPetPoolUpdateHandler(GCPetPoolUpdate msg)
        {
            hpPoolValue = msg.getHpPool();
            mpPoolValue = msg.getMpPool();
            lifePoolValue = msg.getLifePool();
            dispatchChangeEvent(UPDATE_PET_POOL, null);
        }

        #region 骑宠相关
        private GCPetHorseFire mFireReslut;
        private GCPetHorseChangeName mChangeName;

        public GCPetHorseFire petHorseFireResult
        {
            get
            {
                return mFireReslut;
            }
            set
            {
                mFireReslut = value;
                dispatchChangeEvent(FIRE_PET_HORSE_RESLT, value);
            }
        }

        public GCPetHorseChangeName GCPetHorseChangeName
        {
            get
            {
                return mChangeName;
            }
            set
            {
                mChangeName = value;
                dispatchChangeEvent(PET_HORSE_CHANGE_NAME, value);
            }
        }

        public bool HaveQichong()
        {
            List<Pet> list = getPetListByType(PetType.PET_FOR_RIDE);
            return (list.Count > 0);
        }

        public void GCPetHorseCurPropUpdateHandler(GCPetHorseCurPropUpdate msg)
        {
            Pet pet = getPet(msg.getPetId());
            if (pet != null)
            {
                pet.loy = msg.getLoy();
                pet.clo = msg.getClo();
                pet.life = msg.getLife();
                pet.deadline = msg.getDeadline();
                dispatchChangeEvent(UPDATE_PET_PROP, pet.Id);
            }
        }

        #endregion

        public override void Destroy()
        {
            if (petFriendArrayInfoList!=null)
            {
                petFriendArrayInfoList.ToList().Clear();
            }
            petFriendArrayInfoList=null;
            foreach (KeyValuePair<long, Pet> pair in petDic)
            {
                pair.Value.Destroy();
            }
            petDic.Clear();
            petTplIdDic.Clear();
            foreach (KeyValuePair<long, ItemBag> itemBag in petBagDic)
            {
                itemBag.Value.Destroy();
            }
            petBagDic.Clear();
            foreach (KeyValuePair<long, ItemBag> itemBag in petGemBagDic)
            {
                itemBag.Value.Destroy();
            }
            petGemBagDic.Clear();
            if (leader!=null)
            {
                leader.Destroy();
            }
            leader = null;

            if (ridePet!=null)
            {
                ridePet.Destroy();
            }
            ridePet = null;
            mFireReslut=null;
            mChangeName=null;
            curPetFriendArrayIdx = -1;
            hpPoolValue = 0;
            mpPoolValue = 0;
            lifePoolValue = 0;

            _ins = null;
        }

    }
}