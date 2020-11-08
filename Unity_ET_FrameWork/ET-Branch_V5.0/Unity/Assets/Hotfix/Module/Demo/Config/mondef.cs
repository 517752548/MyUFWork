using ETModel;

namespace ETHotfix
{
	[Config((int)(AppType.ClientH |  AppType.ClientM | AppType.Gate | AppType.Map))]
	public partial class mondefCategory : ACategory<mondef>
	{
	}

	public class mondef: IConfig
	{
		public long Id { get; set; }
		public int model;
		public string script;
		public int AI;
		public string name;
		public int effect_type;
		public int effect_res;
		public int target_effect;
		public int lev;
		public int zslevel;
		public int sight;
		public int exp;
		public int inside_power_exp;
		public int MHP;
		public int mp;
		public int MinDEF;
		public int MaxDEF;
		public int MinMDEF;
		public int MaxMDEF;
		public int MinATK;
		public int MaxATK;
		public int MinMATK;
		public int MaxMATK;
		public int DODGE;
		public int HIT;
		public int minStayTime;
		public int maxStayTime;
		public int moveTime;
		public int interval;
		public int head_icon;
		public int talkgap;
		public int subType;
		public int dropID;
		public int patrol;
		public int maxmove;
		public int canPush;
		public int switch_target_type;
		public int switch_target_interval;
		public int hatred_damage_ratio;
		public int hatred_distance_ratio;
		public string editdir;
		public int type;
		public int monGroup;
		public int teleportID;
		public string defaultAI;
		public int patrolTime;
		public int deadTime;
		public int refreshTime;
		public int dirFixed;
		public int CRIRate;
		public int DUCrate;
		public int ADTR;
		public int MR;
		public int HPup;
		public int isShowRefresh;
		public int isS;
		public int bossIntegral;
		public string funcid;
		public string funcparams;
		public string dialog;
		public int canSpeak;
		public string[] randomDialog;
		public int simpleDropID;
		public int weapon;
		public int wing;
		public int title;
		public int collectTime;
		public int noShowOwner;
		public int showTomb;
	}
}
