using System;
using System.Collections.Generic;
using System.Linq;

namespace app.db
{
    public class ItemTemplateDB
    {
        // key模板Id，value模板对象
        protected Dictionary<int, ItemTemplate> idKeyDic = new Dictionary<int, ItemTemplate>();

        protected static ItemTemplateDB _ins;
        public static ItemTemplateDB Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new ItemTemplateDB();
                }
                return _ins;
            }
        }

        private void addData(int id, ItemTemplate value)
        {
            try
            {
                this.idKeyDic.Add(id, value);
            }
            catch (Exception e)
            {
                ClientLog.LogError("ItemTemplateDB addData id:" + id + "  errorMsg:" + e.Message);
            }
        }

        public ItemTemplate getTempalte(int id)
        {
            ItemTemplate value = null;
            idKeyDic.TryGetValue(id, out value);
            return value;
        }

        /**
         * 加载所有的道具
         */
        public void loadAllCfg()
        {
            // XXX 按类型加载道具

            //加载普通物品
            loadItemTemplateByDB(NormalItemTemplateDB.Instance);
            // 加载消耗类道具
            loadItemTemplateByDB(ConsumeItemTemplateDB.Instance);
            // 加载装备
            loadItemTemplateByDB(EquipItemTemplateDB.Instance);
            // 加载技能书
            loadItemTemplateByDB(PetSkillBookItemTemplateDB.Instance);
            // 加载宝石
            loadItemTemplateByDB(GemItemTemplateDB.Instance);
            //加载仙符道具和仙符经验石
            loadItemTemplateByDB(SkillEffectItemTemplateDB.Instance);
            //加载人物技能书
            loadItemTemplateByDB(LeaderSkillBookTemplateDB.Instance);
            //加载装备打造材料
            loadItemTemplateByDB(EquipCraftItemTemplateDB.Instance);
            // 加载生活技能书
            loadItemTemplateByDB(LifeSkillBookTemplateDB.Instance);
            // TODO 其他类型道具加载

        }
        
        public void clearAllCfg()
        {
            NormalItemTemplateDB.Instance.getIdKeyDic().Clear();
            ConsumeItemTemplateDB.Instance.getIdKeyDic().Clear();
            EquipItemTemplateDB.Instance.getIdKeyDic().Clear();
            PetSkillBookItemTemplateDB.Instance.getIdKeyDic().Clear();
            GemItemTemplateDB.Instance.getIdKeyDic().Clear();
            SkillEffectItemTemplateDB.Instance.getIdKeyDic().Clear();
            LeaderSkillBookTemplateDB.Instance.getIdKeyDic().Clear();
            EquipCraftItemTemplateDB.Instance.getIdKeyDic().Clear();
            LifeSkillBookTemplateDB.Instance.getIdKeyDic().Clear();
            // TODO 其他类型道具清理
            idKeyDic.Clear();
        }

        /**
         * 按类型加载道具
         */
        private void loadItemTemplateByDB<D>(TemplateDBBase<D> db) where D : ItemTemplate
        {
            db.loadAllTemplate();
            List<int> keyList = db.getIdKeyDic().Keys.Cast<int>().ToList<int>();
            for (int i = 0; i < keyList.Count; i++)
            {
                int id = keyList[i];
                addData(id, db.getTemplate(id) as ItemTemplate);
            }
            // XXX 将原来的数据删掉，统一从该类[ItemTemplateDB]获取数据
            //db.getIdKeyDic().Clear();
        }

        /// <summary>
        /// 根据宝石组ID和等级获得宝石的模板id
        /// </summary>
        /// <param name="gemGroupId"></param>
        /// <param name="gemLevel"></param>
        /// <returns></returns>
        public int getLevelGemTpl(int gemGroupId, int gemLevel)
        {
            foreach (KeyValuePair<int, ItemTemplate> pair in idKeyDic)
            {
                if (pair.Value.itemTypeId==ItemDefine.ItemTypeDefine.GEM)
                {
                    GemItemTemplate gemtpl = (GemItemTemplate) pair.Value;
                    if (gemtpl.gemGroup == gemGroupId && gemtpl.gemLevel == gemLevel)
                    {
                        return pair.Value.Id;
                    }   
                }
            }
            return 0;
        }
    }
}
