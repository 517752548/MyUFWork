
namespace app.net
{
	public class PetSkillInfo
	{
		/** 技能Id */
		public int skillId;
		/** 技能等级 */
		public int level;
		/** 技能消耗 */
		public int skillCost;
		/** 技能镶嵌的效果列表 */
		public PetSkillEffectInfo[] embedSkillEffectList;
		/** 层数 */
		public int layer;
		/** 熟练度 */
		public long proficiency;
	}
}