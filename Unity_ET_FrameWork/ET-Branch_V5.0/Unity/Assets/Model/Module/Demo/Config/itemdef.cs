namespace ETModel
{
	[Config((int)(AppType.ClientH |  AppType.ClientM | AppType.Gate | AppType.Map))]
	public partial class itemdefCategory : ACategory<itemdef>
	{
	}

	public class itemdef: IConfig
	{
		public long Id { get; set; }
		public int type;
		public string name;
		public int equiptype;
		public int ac;
		public int ac2;
		public int mac;
		public int mac2;
		public int dc;
		public int dc2;
		public int mc;
		public int mc2;
		public int sc;
		public int sc2;
		public int luck;
		public int curse;
		public int accuracy;
		public int dodge;
		public int anti_magic;
		public int anti_poison;
		public int max_hp;
		public int max_mp;
		public int max_hp_pres;
		public int max_mp_pres;
		public int holy_damage;
		public int baoji_prob;
		public int baoji_pres;
		public int drop_luck;
		public int need;
		public int needlevel;
		public int price;
		public int need_zslevel;
		public int equip_level;
		public int job;
		public int gender;
		public int equip_group;
		public int equip_comp;
		public int equip_contribute;
		public int destory_show;
		public int add_power;
		public int item_bg;
		public int recycle_money;
		public int recycle_exp;
		public int recycle_xuefu;
		public int can_use;
		public int can_destroy;
		public int can_depot;
		public int can_push;
		public int bag_show;
		public int times_limit;
		public int func_id;
		public string desp;
		public string source;
	}
}
