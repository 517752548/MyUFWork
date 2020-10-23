using System.Collections.Generic;

namespace app.db
{
    public class PetPropItemTemplateDB : PetPropItemTemplateDBBase
    {
        // TODO 可能会自定义一些属性或方法

        /// <summary>
        /// 根据Dropdownindex获得PetPropItemTemplate
        /// </summary>
        /// <param name="zizhiindex"></param>
        /// <param name="dropdownindex"></param>
        /// <returns></returns>
        public PetPropItemTemplate GetPropItem(int zizhiindex,int dropdownindex)
        {

            int index = 0;
            foreach (KeyValuePair<int, PetPropItemTemplate> pair in idKeyDic)
            {
                if (pair.Value.propIndex == zizhiindex)
                {
                    if (dropdownindex == index)
                    {
                        return pair.Value;
                    }
                    ++index;
                }
            }

            return null;
        }

        /// <summary>
        /// 根据资质丹索引获得Dropdownindex
        /// </summary>
        /// <param name="zizhiindex"></param>
        /// <param name="zizhidanindex"></param>
        /// <returns></returns>
        public PetPropItemTemplate GetPropItemByDropDownIndex(int zizhiindex, int zizhidanindex)
        {
            foreach (KeyValuePair<int, PetPropItemTemplate> pair in idKeyDic)
            {
                if (pair.Value.propIndex == zizhiindex && pair.Value.propItemIndex == zizhidanindex)
                {
                        return pair.Value;
                }
            }
            return null;

        }

        /// <summary>
        /// 根据资质丹索引获得Dropdownindex
        /// </summary>
        /// <param name="zizhiindex"></param>
        /// <param name="zizhidanindex"></param>
        /// <returns></returns>
        public int GetDropDownIndex(int zizhiindex, int zizhidanindex)
        {
            int index = 0;
            foreach (KeyValuePair<int, PetPropItemTemplate> pair in idKeyDic)
            {
                if (pair.Value.propIndex == zizhiindex)
                {
                    if (pair.Value.propItemIndex == zizhidanindex)
                    {
                        return index;
                    }
                    ++index;
                }
            }
            return -1;
           
        }
    }
}
