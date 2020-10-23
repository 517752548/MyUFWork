
namespace app.net
{
	public class CorpsCGHandler
	{
	public static void sendCGClickCorpsPanel(
)
	{
		CGClickCorpsPanel msg = new CGClickCorpsPanel(
);
		GameConnection.Instance.sendMessage(msg);
	}
	
	public static void sendCGSearchCorps(
			int country,
			string name)
	{
		CGSearchCorps msg = new CGSearchCorps(
			country,
			name);
		GameConnection.Instance.sendMessage(msg);
	}
	
	public static void sendCGCorpsPageSkip(
			int country,
			int page)
	{
		CGCorpsPageSkip msg = new CGCorpsPageSkip(
			country,
			page);
		GameConnection.Instance.sendMessage(msg);
	}
	
	public static void sendCGClickCorpsFunction(
			long corpsId,
			int funcId)
	{
		CGClickCorpsFunction msg = new CGClickCorpsFunction(
			corpsId,
			funcId);
		GameConnection.Instance.sendMessage(msg);
	}
	
	public static void sendCGClickCorpsMemberFunction(
			long corpsMemberId,
			int funcId)
	{
		CGClickCorpsMemberFunction msg = new CGClickCorpsMemberFunction(
			corpsMemberId,
			funcId);
		GameConnection.Instance.sendMessage(msg);
	}
	
	public static void sendCGCreateCorps(
			string name,
			string notice)
	{
		CGCreateCorps msg = new CGCreateCorps(
			name,
			notice);
		GameConnection.Instance.sendMessage(msg);
	}
	
	public static void sendCGOpenCorpsPanel(
)
	{
		CGOpenCorpsPanel msg = new CGOpenCorpsPanel(
);
		GameConnection.Instance.sendMessage(msg);
	}
	
	public static void sendCGCorpsDonate(
			int num)
	{
		CGCorpsDonate msg = new CGCorpsDonate(
			num);
		GameConnection.Instance.sendMessage(msg);
	}
	
	public static void sendCGCorpsNoticeUpdate(
			string qq,
			string notice)
	{
		CGCorpsNoticeUpdate msg = new CGCorpsNoticeUpdate(
			qq,
			notice);
		GameConnection.Instance.sendMessage(msg);
	}
	
	public static void sendCGOpenCorpsMemberList(
)
	{
		CGOpenCorpsMemberList msg = new CGOpenCorpsMemberList(
);
		GameConnection.Instance.sendMessage(msg);
	}
	
	public static void sendCGOpenCorpsStorage(
)
	{
		CGOpenCorpsStorage msg = new CGOpenCorpsStorage(
);
		GameConnection.Instance.sendMessage(msg);
	}
	
	public static void sendCGAllocationItem(
			long targetId,
			StorageItemInfo[] storageItemList)
	{
		CGAllocationItem msg = new CGAllocationItem(
			targetId,
			storageItemList);
		GameConnection.Instance.sendMessage(msg);
	}
	
	public static void sendCGCorpsAddToFriend(
)
	{
		CGCorpsAddToFriend msg = new CGCorpsAddToFriend(
);
		GameConnection.Instance.sendMessage(msg);
	}
	
	public static void sendCGCorpsBatchFireMember(
			long[] targetIds)
	{
		CGCorpsBatchFireMember msg = new CGCorpsBatchFireMember(
			targetIds);
		GameConnection.Instance.sendMessage(msg);
	}
	
	public static void sendCGCorpsBatchAddApplyMember(
			long[] targetIds)
	{
		CGCorpsBatchAddApplyMember msg = new CGCorpsBatchAddApplyMember(
			targetIds);
		GameConnection.Instance.sendMessage(msg);
	}
	
	public static void sendCGCorpsMemberInfo(
)
	{
		CGCorpsMemberInfo msg = new CGCorpsMemberInfo(
);
		GameConnection.Instance.sendMessage(msg);
	}
	
	public static void sendCGCorpsQuickApply(
			int page)
	{
		CGCorpsQuickApply msg = new CGCorpsQuickApply(
			page);
		GameConnection.Instance.sendMessage(msg);
	}
	
	public static void sendCGEnterCorpswar(
)
	{
		CGEnterCorpswar msg = new CGEnterCorpswar(
);
		GameConnection.Instance.sendMessage(msg);
	}
	
	public static void sendCGCorpswarInfo(
)
	{
		CGCorpswarInfo msg = new CGCorpswarInfo(
);
		GameConnection.Instance.sendMessage(msg);
	}
	
	public static void sendCGLeaveCorpswar(
)
	{
		CGLeaveCorpswar msg = new CGLeaveCorpswar(
);
		GameConnection.Instance.sendMessage(msg);
	}
	
	public static void sendCGCorpswarRankList(
)
	{
		CGCorpswarRankList msg = new CGCorpswarRankList(
);
		GameConnection.Instance.sendMessage(msg);
	}
	
	public static void sendCGBackCorpsMap(
)
	{
		CGBackCorpsMap msg = new CGBackCorpsMap(
);
		GameConnection.Instance.sendMessage(msg);
	}
	
	public static void sendCGOpenCorpsBuildingPanel(
			int buildType)
	{
		CGOpenCorpsBuildingPanel msg = new CGOpenCorpsBuildingPanel(
			buildType);
		GameConnection.Instance.sendMessage(msg);
	}
	
	public static void sendCGUpgradeCorps(
			int buildType)
	{
		CGUpgradeCorps msg = new CGUpgradeCorps(
			buildType);
		GameConnection.Instance.sendMessage(msg);
	}
	
	public static void sendCGOpenCorpsBenifitPanel(
)
	{
		CGOpenCorpsBenifitPanel msg = new CGOpenCorpsBenifitPanel(
);
		GameConnection.Instance.sendMessage(msg);
	}
	
	public static void sendCGGetBenifit(
)
	{
		CGGetBenifit msg = new CGGetBenifit(
);
		GameConnection.Instance.sendMessage(msg);
	}
	
	public static void sendCGOpenCorpsCultivatePanel(
)
	{
		CGOpenCorpsCultivatePanel msg = new CGOpenCorpsCultivatePanel(
);
		GameConnection.Instance.sendMessage(msg);
	}
	
	public static void sendCGCultivateSkill(
			int skillId,
			int isBatch)
	{
		CGCultivateSkill msg = new CGCultivateSkill(
			skillId,
			isBatch);
		GameConnection.Instance.sendMessage(msg);
	}
	
	public static void sendCGOpenCorpsAssistPanel(
)
	{
		CGOpenCorpsAssistPanel msg = new CGOpenCorpsAssistPanel(
);
		GameConnection.Instance.sendMessage(msg);
	}
	
	public static void sendCGLearnAssistSkill(
			int skillId)
	{
		CGLearnAssistSkill msg = new CGLearnAssistSkill(
			skillId);
		GameConnection.Instance.sendMessage(msg);
	}
	
	public static void sendCGMakeItem(
			int skillId,
			int targetLevel)
	{
		CGMakeItem msg = new CGMakeItem(
			skillId,
			targetLevel);
		GameConnection.Instance.sendMessage(msg);
	}
	public static void sendCGOpenCorpsRedEnvelopePanel(
)
	{
		CGOpenCorpsRedEnvelopePanel msg = new CGOpenCorpsRedEnvelopePanel(
);
		GameConnection.Instance.sendMessage(msg);
	}
	
	public static void sendCGCreateCorpsRedEnvelope(
			int redEnvelopeType,
			string content,
			int bonusAmount)
	{
		CGCreateCorpsRedEnvelope msg = new CGCreateCorpsRedEnvelope(
			redEnvelopeType,
			content,
			bonusAmount);
		GameConnection.Instance.sendMessage(msg);
	}
	
	public static void sendCGGotCorpsRedEnvelope(
			int redEnvelopeType,
			string uuid)
	{
		CGGotCorpsRedEnvelope msg = new CGGotCorpsRedEnvelope(
			redEnvelopeType,
			uuid);
		GameConnection.Instance.sendMessage(msg);
	}
	
	public static void sendCGLookCorpsRedEnvelope(
			string uuid)
	{
		CGLookCorpsRedEnvelope msg = new CGLookCorpsRedEnvelope(
			uuid);
		GameConnection.Instance.sendMessage(msg);
	}

		public static void sendCGOpenAllocatePanel(
			int activityType)
	{
		CGOpenAllocatePanel msg = new CGOpenAllocatePanel(
			activityType);
		GameConnection.Instance.sendMessage(msg);
	}
	
	public static void sendCGAllocateActivityItem(
			int activityType,
			long targetId,
			AllocateItemInfo[] allocatingItemInfos)
	{
		CGAllocateActivityItem msg = new CGAllocateActivityItem(
			activityType,
			targetId,
			allocatingItemInfos);
		GameConnection.Instance.sendMessage(msg);
	}
	
	}
}