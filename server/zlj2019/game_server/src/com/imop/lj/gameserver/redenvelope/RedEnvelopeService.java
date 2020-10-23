package com.imop.lj.gameserver.redenvelope;

import java.text.MessageFormat;
import java.util.Collection;
import java.util.Collections;
import java.util.Comparator;
import java.util.LinkedList;
import java.util.List;
import java.util.Map;
import java.util.Set;

import com.google.common.collect.Lists;
import com.google.common.collect.Maps;
import com.imop.lj.common.InitializeRequired;
import com.imop.lj.common.LogReasons.CorpsLogReason;
import com.imop.lj.common.LogReasons.MoneyLogReason;
import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.core.util.KeyUtil;
import com.imop.lj.core.util.RandomUtil;
import com.imop.lj.db.model.RedEnvelopeEntity;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.corps.CorpsDef.CorpsEventType;
import com.imop.lj.gameserver.corps.model.Corps;
import com.imop.lj.gameserver.corps.model.CorpsEvent;
import com.imop.lj.gameserver.corps.msg.GCCreateCorpsRedEnvelope;
import com.imop.lj.gameserver.corps.msg.GCGotCorpsRedEnvelope;
import com.imop.lj.gameserver.corps.msg.GCOpenCorpsRedEnvelopePanel;
import com.imop.lj.gameserver.currency.Currency;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.mail.MailDef.MailType;
import com.imop.lj.gameserver.redenvelope.RedEnvelopeDef.RedEnvelopeStatus;
import com.imop.lj.gameserver.redenvelope.RedEnvelopeDef.RedEnvelopeType;
import com.imop.lj.gameserver.redenvelope.model.OpenRedEnveloper;
import com.imop.lj.gameserver.redenvelope.model.RandomRedEnvelopeUnit;
import com.imop.lj.gameserver.redenvelope.msg.RedEnvelopeMsgBuilder;
import com.imop.lj.gameserver.reward.Reward;
import com.imop.lj.gameserver.reward.RewardDef.RewardReasonType;
import com.imop.lj.gameserver.reward.RewardDef.RewardType;
import com.imop.lj.gameserver.reward.RewardParam;

public class RedEnvelopeService implements InitializeRequired {

	/** Map<红包uuid, 红包信息>*/
	protected Map<String, RedEnvelope> redEnvelopeMap = Maps.newHashMap();
	
	protected RedEnvelopeComparator overTimeComparator = new RedEnvelopeComparator();
	
	protected void addRedEnvelopeMap(RedEnvelope redEnvelope){
		this.redEnvelopeMap.put(redEnvelope.getUuid(), redEnvelope);
	}
	
	protected void delRedEnvelopeMap(RedEnvelope redEnvelope){
		this.redEnvelopeMap.remove(redEnvelope.getUuid());
	}
	
	protected Map<String, RedEnvelope> getRedEnvelopeMap() {
		return redEnvelopeMap;
	}
	
	class RedEnvelopeComparator implements Comparator<RedEnvelope> {
		@Override
		public int compare(RedEnvelope o1, RedEnvelope o2) {
			//按照红包创建时间升序
			if (o1.getCreateTime() < o2.getCreateTime()) {
				return 1;
			}else if(o1.getCreateTime() > o2.getCreateTime()){
				return -1;
			}
			return 0;
		}
	}
	
	/** 获得该帮派所有的红包*/
	protected List<RedEnvelope> getCorpsRedEnvelope(long corpsId){
		List<RedEnvelope> lst = Lists.newArrayList();
		for(RedEnvelope redEnvelope : redEnvelopeMap.values()){
			if(redEnvelope.getCorpsId() == corpsId
					&& redEnvelope.getDeleted() != 1){
				lst.add(redEnvelope);
			}
		}
		return lst;
	}
	
	protected RedEnvelope getRedEnvelope(String uuid) {
		if(this.redEnvelopeMap.containsKey(uuid)){
			return this.redEnvelopeMap.get(uuid);
		}
		return null;
	}

	
	
	@Override
	public void init() {
		List<RedEnvelopeEntity> redEnvelopeList = Globals.getDaoService().getRedEnvelopeDao().loadAllRedEnveEntity();
		for (RedEnvelopeEntity entity : redEnvelopeList) {
			RedEnvelope redEnvelope = new RedEnvelope();
			redEnvelope.fromEntity(entity);
			//加入到内存中
			addRedEnvelopeMap(redEnvelope);
			
		}
	}

	/**
	 * 请求打开帮派红包面板
	 * @param human
	 * @param corps
	 */
	public void handleOpenCorpsRedEnvelopePanel(Human human, Corps corps) {
		long corpsId = corps.getId();
		List<RedEnvelope> list = getCorpsRedEnvelope(corpsId);
		GCOpenCorpsRedEnvelopePanel msg = RedEnvelopeMsgBuilder.createGCOpenCorpsRedEnvelopePanel(human, list);
		human.sendMessage(msg);
	}

	/**
	 * 请求发送帮派红包
	 * @param human
	 * @param bonusAmount
	 * @param content
	 * @param corps
	 */
	public void handleCreateCorpsRedEnvelope(Human human, int bonusAmount, String content, Corps corps) {
		long roleId = human.getCharId();
		long corpsId = corps.getId();
		//是否超过帮派红包的最大数量,是否可以继续发放
		if(getCorpsRedEnvelope(corpsId).size() > Globals.getGameConstants().getCorpsRedEnvelopeMaxNum()){
			human.sendErrorMessage(LangConstants.SEND_CORPS_RED_ENVELOPE_MAX_NUM);
			return;
		}
		//玩家身上是否满足礼金金额
		if(!human.hasEnoughMoney(bonusAmount, Currency.RED_ENVELOPE, true)){
			return;
		}
		//初始化红包信息
		RedEnvelope redEnvelope = new RedEnvelope();
		redEnvelope.setUuid(KeyUtil.UUIDKey());
		redEnvelope.setCorpsId(corpsId);
		redEnvelope.setSendId(roleId);
		redEnvelope.setSendName(human.getName());
		redEnvelope.setContent(content);
		redEnvelope.setRedEnvelopeType(RedEnvelopeType.CORPS);
		redEnvelope.setRedEnvelopeStatus(RedEnvelopeStatus.CAN_OPEN);
		redEnvelope.setCreateTime(Globals.getTimeService().now());
		redEnvelope.setBonusAmount(bonusAmount);
		redEnvelope.setRemainingNum(Globals.getGameConstants().getRedEnvelopeMaxNum());
		redEnvelope.setRemainingBonus(bonusAmount);
		Map<Long, OpenRedEnveloper> openRedEnveloperMap = Maps.newHashMap();
		redEnvelope.setOpenRedEnveloperMap(openRedEnveloperMap);
		//随机金额
		Map<Integer, RandomRedEnvelopeUnit> randomRedEnvelopeMap = Maps.newHashMap();
		int[] allBonus = getBonusFromOpenRedEnvelopen(bonusAmount);
		int checkAmount = 0;
		for (int i = 0; i < allBonus.length; i++) {
			RandomRedEnvelopeUnit unit = new RandomRedEnvelopeUnit();
			unit.setId(i);
			unit.setNum(allBonus[i]);
			randomRedEnvelopeMap.put(i, unit);
			checkAmount += allBonus[i];
		}
		if(checkAmount != bonusAmount){
			Loggers.redEnvelopeLogger.error("RedEnvelopeService#getBonusFromOpenRedEnvelopen isn't correct!charId=" + roleId
					+";checkAmount =" + checkAmount);
			return;
		}
		redEnvelope.setRandomRedEnvelopeMap(randomRedEnvelopeMap);
		//存库
		redEnvelope.active();
		redEnvelope.setModified();
		//放入红包集合中
		addRedEnvelopeMap(redEnvelope);
		
		//发送帮派频道消息,可以点击的链接 TODO
		CorpsEvent redEnvelopeEvent = CorpsEvent.valueOf(CorpsEventType.BROADCAST_RED_ENVELOPE, human.getName());
		corps.addEvent(redEnvelopeEvent);
		
		//扣除玩家礼金金额
		if(!human.costMoney(bonusAmount, Currency.RED_ENVELOPE, true, 0, MoneyLogReason.CORPS_RED_ENVELOPE_REWARD,
				 MoneyLogReason.CORPS_RED_ENVELOPE_REWARD.getReasonText(), 0)){
			return;
		}
		
		//发送消息
		human.sendMessage(new GCCreateCorpsRedEnvelope(1));
		
		//刷新面板
		this.handleOpenCorpsRedEnvelopePanel(human, corps);
	}

	/**
	 * 请求领取帮派红包
	 * @param human
	 * @param uuid
	 * @param corps
	 */
	public void handleGotCorpsRedEnvelope(Human human, String uuid, Corps corps) {
		long roleId = human.getCharId();
		//红包是否存在
		if(!isRedEnvlopeExist(uuid)){
			Loggers.redEnvelopeLogger.error("RedEnvelopeService#handleGotCorpsRedEnvelope RedEnvlope isn't exist!charId=" + roleId
			+";sendId = "+ uuid);
			human.sendErrorMessage(LangConstants.RED_ENVELOPE_NOT_EXIST);
			return;
		}
		//是否是可领取状态
		if(!isCanOpen(uuid)){
			Loggers.redEnvelopeLogger.error("RedEnvelopeService#handleGotCorpsRedEnvelope RedEnvlope can't open!charId=" + roleId
			+";sendId = "+ uuid);
			return;
		}
		//得到红包对象
		RedEnvelope redEnvelope = getRedEnvelope(uuid);
		if(redEnvelope == null){
			Loggers.redEnvelopeLogger.error("RedEnvelopeService#handleGotCorpsRedEnvelope getRedEnvelope is null!charId=" + roleId
			+";sendId = "+ uuid);
			return;
		}
		//是否重复领取
		if(isGotBonusRepeatly(roleId, uuid)){
			Loggers.redEnvelopeLogger.error("RedEnvelopeService#handleGotCorpsRedEnvelope repeatly!charId=" + roleId
			+";sendId = "+ uuid);
			human.sendErrorMessage(LangConstants.OPEN_RED_ENVELOPE_REPEATLY);
			return;
		}
		//打开红包,得到随机的金额
		int bonus = 0;
		Map<Integer, RandomRedEnvelopeUnit> randomRedEnvelopeMap = redEnvelope.getRandomRedEnvelopeMap();
		if(randomRedEnvelopeMap.isEmpty()){
			Loggers.redEnvelopeLogger.error("RedEnvelopeService#getRandomRedEnvelopeMap is empty!charId=" + roleId
					+";sendId = "+ uuid);
			return;
		}
		Set<Integer> randomKeySet = randomRedEnvelopeMap.keySet();
		List<Integer> newRandomKeyLst = Lists.newArrayList();
		newRandomKeyLst.addAll(randomKeySet);
		Collections.shuffle(newRandomKeyLst);
		if(!randomRedEnvelopeMap.containsKey(newRandomKeyLst.get(0))){
			Loggers.redEnvelopeLogger.error("RedEnvelopeService#randomNum is not in randomRedEnvelopeMap!charId=" + roleId
					+";randomNum = "+ newRandomKeyLst.get(0));
			return;
		}else{
			bonus = randomRedEnvelopeMap.get(newRandomKeyLst.get(0)).getNum();
		}
		randomRedEnvelopeMap.remove(newRandomKeyLst.get(0));
		redEnvelope.setRandomRedEnvelopeMap(randomRedEnvelopeMap);
		
		if(isLastOpenRedEnvelope(uuid)){
			//是否可以变成查看状态
			redEnvelope.setRemainingNum(0);
			redEnvelope.setRemainingBonus(0);
			redEnvelope.setRedEnvelopeStatus(RedEnvelopeStatus.CAN_NOT_OPEN);
		}else{
			redEnvelope.setRemainingNum(redEnvelope.getRemainingNum() - 1);
			redEnvelope.setRemainingBonus(redEnvelope.getRemainingBonus() - bonus);
		}
		
		Map<Long, OpenRedEnveloper> openRedEnveloperMap = redEnvelope.getOpenRedEnveloperMap();
		OpenRedEnveloper openRedEnveloper = new OpenRedEnveloper();
		openRedEnveloper.setRecId(roleId);
		openRedEnveloper.setRecName(human.getName());
		openRedEnveloper.setGotBonus(bonus);
		openRedEnveloper.setOpenTime(Globals.getTimeService().now());
		openRedEnveloperMap.put(roleId, openRedEnveloper);
		redEnvelope.setOpenRedEnveloperMap(openRedEnveloperMap);
		//存库
		redEnvelope.setModified();
		
		//刷新面板
		this.handleOpenCorpsRedEnvelopePanel(human, corps);
		
		//发送邮件
		human.sendErrorMessage(LangConstants.OPEN_RED_ENVELOPE_OK, redEnvelope.getSendName(), bonus);
		Reward reward = Globals.getRewardService().createEmptyReward();
		reward.setUuid(KeyUtil.UUIDKey());
		List<RewardParam> rp = new LinkedList<RewardParam>();
		rp.add(new RewardParam(RewardType.REWARD_CURRENCY,Currency.SYS_BOND.getIndex(), bonus));
		reward.initReward(rp);
		reward.setReasonType(RewardReasonType.CORPS_RED_ENVELOPE_REWARD);
		Globals.getMailService().sendSysMail(roleId, MailType.SYSTEM,
				Globals.getLangService().readSysLang(LangConstants.CORPS_RED_ENVELOPE_MAIL_TITLE),
				MessageFormat.format(Globals.getLangService().readSysLang(LangConstants.OPEN_RED_ENVELOPE_OK),
						redEnvelope.getSendName(), bonus), reward);
		//发送消息
		human.sendMessage(new GCGotCorpsRedEnvelope(uuid ,1, bonus));
		//记录日志
		Globals.getCorpsService().sendCorpsLog(human, CorpsLogReason.CORPS_RED_ENVELOPE_REWARD,
				CorpsLogReason.CORPS_RED_ENVELOPE_REWARD.getReasonText(),
				corps, null, null);
	}

	/**
	 * 请求查看红包详情
	 * @param human
	 * @param uuid
	 */
	public void handleLookCorpsRedEnvelope(Human human, String uuid) {
		long roleId = human.getCharId();
		//红包是否存在
		if(!isRedEnvlopeExist(uuid)){
			Loggers.redEnvelopeLogger.error("RedEnvelopeService#handleGotCorpsRedEnvelope RedEnvlope isn't exist!charId=" + roleId
			+";sendId = "+ uuid);
			human.sendErrorMessage(LangConstants.RED_ENVELOPE_NOT_EXIST);
			return;
		}
		//是否是可查看状态
		if(!isCanNotOpen(uuid)){
			Loggers.redEnvelopeLogger.error("RedEnvelopeService#handleGotCorpsRedEnvelope RedEnvlope can't look!charId=" + roleId
			+";sendId = "+ uuid);
			return;
		}
		//得到红包对象
		RedEnvelope redEnvelope = getRedEnvelope(uuid);
		if(redEnvelope == null){
			Loggers.redEnvelopeLogger.error("RedEnvelopeService#handleGotCorpsRedEnvelope getRedEnvelope is null!charId=" + roleId
			+";sendId = "+ uuid);
			return;
		}
		
		//发送消息
		GCOpenCorpsRedEnvelopePanel msg = RedEnvelopeMsgBuilder.createGCOpenCorpsRedEnvelopePanel(human, redEnvelope);
		human.sendMessage(msg);
	}
	
	protected boolean isRedEnvlopeExist(String uuid){
		if(this.redEnvelopeMap.containsKey(uuid)){
			return true;
		}else{
			return false;
		}
	}
	
	protected boolean isCanOpen(String uuid) {
		if(this.redEnvelopeMap.containsKey(uuid)){
			if (RedEnvelopeStatus.CAN_OPEN == this.redEnvelopeMap.get(uuid).getRedEnvelopeStatus()) {
				return true;
			}
		}
		return false;
	}
	
	protected boolean isCanNotOpen(String uuid) {
		if(this.redEnvelopeMap.containsKey(uuid)){
			if (RedEnvelopeStatus.CAN_NOT_OPEN == this.redEnvelopeMap.get(uuid).getRedEnvelopeStatus()) {
				return true;
			}
		}
		return false;
	}
	
	/**
	 * 每次打开红包得到的金额
	 * @param remainingBonus 红包内剩余的金额
	 * @return
	 */
	protected int[] getBonusFromOpenRedEnvelopen(int remainingBonus) {
		int bonus[] = new int[Globals.getGameConstants().getRedEnvelopeMaxNum()];
		//初始值为1,这样随机到的金额至少是1
		for(int i = 0; i < Globals.getGameConstants().getRedEnvelopeMaxNum();i++){
			bonus[i] = 1;
		}
		//剩余的值
		remainingBonus -= Globals.getGameConstants().getRedEnvelopeMaxNum();
		
		for(int i = 0; i < Globals.getGameConstants().getRedEnvelopeMaxNum();i++){
			//最后一次,直接给,不随机了
			if(i == Globals.getGameConstants().getRedEnvelopeMaxNum() - 1){
				bonus[i] += remainingBonus + Globals.getGameConstants().getRedEnvelopeMaxNum() - 1;
			}else{
				bonus[i] += RandomUtil.nextEntireInt((int)(remainingBonus * Globals.getGameConstants().getOpenRedEnvelopeMinProb()),
						(int)(remainingBonus * Globals.getGameConstants().getOpenRedEnvelopeMaxProb()));
				remainingBonus -= bonus[i];
			}
		}
		
		return bonus;
	}
	
	/**
	 * 是否是最后一次打开红包
	 * @param uuid
	 * @return
	 */
	protected boolean isLastOpenRedEnvelope(String uuid) {
		if(this.redEnvelopeMap.containsKey(uuid)){
			if (this.redEnvelopeMap.get(uuid).getRemainingNum() == 1) {
				return true;
			}
		}
		return false;
	}
	
	/**
	 * 是否重复打开红包
	 * @param openId
	 * @param uuid
	 * @return
	 */
	protected boolean isGotBonusRepeatly(long openId,String uuid) {
		if(this.redEnvelopeMap.containsKey(uuid)){
			RedEnvelope redEnvelope = this.redEnvelopeMap.get(uuid);
			//方便测试用
			if(Globals.getGameConstants().getGotBonusRepeatlyFlag() == 1){
				return false;
			}else{
				return redEnvelope.getOpenRedEnveloperMap().containsKey(openId);
			}
		}
		return false;
	}

	/**
	 * 一周删除
	 */
	public void overOneWeekCheck() {
		//1.拿到当前时间
		long now = Globals.getTimeService().now();
		Collection<RedEnvelope> redEnvelopeCol = this.redEnvelopeMap.values();
		List<RedEnvelope> reList = Lists.newArrayList();
		reList.addAll(redEnvelopeCol);
		Collections.sort(reList, overTimeComparator);
		//2.过期检测
		for(RedEnvelope redEnvelope : reList){
			//已经删除的跳过
			if(redEnvelope.getDeleted() == 1){
				continue;
			}
			//拿到最早创建的红包,比较是否超时
			if(now - redEnvelope.getCreateTime() < Globals.getGameConstants().getRedEnvelopeMaxExistTime()){
				break;
			}
			
			if(now - redEnvelope.getCreateTime() >= Globals.getGameConstants().getRedEnvelopeMaxExistTime()){
				long corpsId = redEnvelope.getCorpsId();
				Corps corps = Globals.getCorpsService().getCorpsById(corpsId);
				if(corps == null){
					continue;
				}
				
				//3.在帮派时间中,提示红包过期
				CorpsEvent redEnvelopeEvent = CorpsEvent.valueOf(CorpsEventType.RED_ENVELOPE_OVER_DUE);
				corps.addEvent(redEnvelopeEvent);
				//4.删除
				redEnvelope.onDelete();
				//5.从内存中去除
				delRedEnvelopeMap(redEnvelope);
			}
		}
	}
	
	
	public boolean hasRedEnvelope(Human human){
		long roleId = human.getCharId();
		//玩家是否有帮派
		Corps corps = Globals.getCorpsService().getUserCorps(roleId);
		if(corps == null){
			return false;
		}
		
		//帮派中是否有可领取的红包
		List<RedEnvelope> list = this.getCorpsRedEnvelope(corps.getId());
		for (RedEnvelope redEnvelope : list) {
			if(redEnvelope.getRedEnvelopeStatus() == RedEnvelopeStatus.CAN_OPEN){
				return true;
			}
		}
		return false;
	}

}
