using System;
using System.Collections.Generic;

    public abstract class PropertyType
    {
        public static readonly int BASE = 100;

        /** pet的一级属性 */
	    public readonly static int PET_PROP_A = 3;

        /** pet的二级属性 */
	    public readonly static int PET_PROP_B = 4;

        /** 基础属性（角色，pet）： 数值类型  int */
	    public readonly static int BASE_ROLE_PROPS_INT = 5;

        /** 基础属性（角色，pet）： 非数值类型  String */
	    public readonly static int BASE_ROLE_PROPS_STR = 6;


	    /**
	     * 产生属性的KEY值，用于服务器之间，服务器和客户端之间数据发送接受
	     *
	     * @param index
	     *           属性在Property类中的索引
	     * @param propertyType
	     *           Property类的类型
	     * @return
	     */
        //public static int genPropertyKey(int index, int propertyType)
        //{
        //    return propertyType * BASE + index;
        //}

	    public static void assertPropertyType(int propType) 
        {
		    if (propType != PetAProperty.TYPE && propType != PetBProperty.TYPE)
            {
			    throw new Exception("Not a valid PropLevel key [" + propType + "]");
		    }
	    }

        public static bool isPetAProp(int key)
        {
            int index = key - PET_PROP_A * BASE;
            return index > 0 && index < BASE;
        }

        public static bool isPetBProp(int key)
        {
            int index = key - PET_PROP_B * BASE;
            return index > 0 && index < BASE;
        }
    }