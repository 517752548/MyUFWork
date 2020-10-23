using app.pet;
using app.role;

public class PetPropertyManager : RolePropertyManager<Pet>
    {
        public PetPropertyManager(Pet role) : base(role)
        {
        }

        /// <summary>
        /// 获取武将非战斗的int属性
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public int getPetIntProp(int index)
        {
            //int key = PropertyType.genPropertyKey(index, PropertyType.BASE_ROLE_PROPS_INT);
            return this.getInt(index);
        }

        /// <summary>
        /// 获取武将非战斗的long属性
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public long getPetLongProp(int index)
        {
            //int key = PropertyType.genPropertyKey(index, PropertyType.BASE_ROLE_PROPS_STR);
            return this.getLong(index);
        }

        /// <summary>
        /// 获取武将非战斗的string属性
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public string getPetStringProp(int index)
        {
            //int key = PropertyType.genPropertyKey(index, PropertyType.BASE_ROLE_PROPS_STR);
            return this.getString(index);
        }

        public bool IsBind()
        {
            int bind = getPetIntProp(RoleBaseIntProperties.PET_BIND);
            return bind == 0;
        }
    /*

        /// <summary>
        /// 获取武将战斗一级属性
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
	    public int getAProperty(int index) 
        {
            //int key = PropertyType.genPropertyKey(index, PropertyType.PET_PROP_A);
            return this.getInt(index);
	    }

        /// <summary>
        /// 获取武将战斗二级属性
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public int getBProperty(int index)
        {
            //int key = PropertyType.genPropertyKey(index, PropertyType.PET_PROP_B);
            return this.getInt(index);
	    }

     */  

    }