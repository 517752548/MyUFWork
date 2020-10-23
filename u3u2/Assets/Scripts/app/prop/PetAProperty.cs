    //武将一级属性
    public class PetAProperty
    {
        /** 一级属性索引开始值 */
        public static readonly int _BEGIN = 300;

	    /** 一级属性索引结束值 */
        private static int _END = _BEGIN;

	    /// <summary>
	    /// 强壮
	    /// </summary>
        public static readonly int STRENGTH = ++_END;//301

	    /// <summary>
        /// 敏捷
	    /// </summary>
        public static readonly int AGILITY = ++_END;//302

	    /// <summary>
	    /// 智力
	    /// </summary>
        public static readonly int INTELLECT = ++_END;//303

        /// <summary>
        /// 信仰
        /// </summary>
        public static readonly int FAITH = ++_END;//304

        /// <summary>
        /// 耐力
        /// </summary>
        public static readonly int STAMINA = ++_END;//305

        ///** 强壮成长 */
        //Float
        public static readonly int STRENGTH_GROWTH = ++_END;// 306

        ///** 敏捷成长 */
        //Float
        public static readonly int AGILITY_GROWTH = ++_END;// 307

        ///** 智力成长 */
        //Float
        public static readonly int INTELLECT_GROWTH = ++_END;// 308

        ///** 信仰成长 */
        //Float
        public static readonly int FAITH_GROWTH = ++_END;// 309
	
        ///** 耐力成长 */
        //Float
        public static readonly int STAMINA_GROWTH = ++_END;// 310


        /** 一级属性的个数 */
        public static int _SIZE = _END - _BEGIN;

        public static int TYPE = PropertyType.PET_PROP_A;
        

    }
