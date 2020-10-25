package com.imop.lj.gameserver.redenvelope;

import java.sql.Timestamp;
import java.util.Map;
import java.util.Map.Entry;

import com.google.common.collect.Maps;
import com.imop.lj.core.object.LifeCycle;
import com.imop.lj.core.object.LifeCycleImpl;
import com.imop.lj.core.object.PersistanceObject;
import com.imop.lj.db.model.RedEnvelopeEntity;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.redenvelope.RedEnvelopeDef.RedEnvelopeStatus;
import com.imop.lj.gameserver.redenvelope.RedEnvelopeDef.RedEnvelopeType;
import com.imop.lj.gameserver.redenvelope.model.OpenRedEnveloper;
import com.imop.lj.gameserver.redenvelope.model.RandomRedEnvelopeUnit;

import net.sf.json.JSONArray;

public class RedEnvelope implements PersistanceObject<String, RedEnvelopeEntity>{

	/** 红包uuid*/
	private String uuid;
	/** 此实例是否在db中 */
	private boolean isInDb;

	/** 邮件的生命期的状态 */
	private final LifeCycle lifeCycle;

	/** 所属帮派Id*/
	private long corpsId;
	/** 发红包玩家id*/
	private long sendId;
	/** 发红包玩家名称*/
	private String sendName;
	/** 红包内容*/
	private String content;
	/** 红包类型*/
	private RedEnvelopeType redEnvelopeType;
	/** 红包状态 */
	private RedEnvelopeStatus redEnvelopeStatus;
	/** 发送时间*/
	private long createTime;
	/** 红包总金额*/
	private int bonusAmount;
	/** 红包随机分配信息*/
	private Map<Integer, RandomRedEnvelopeUnit> randomRedEnvelopeMap = Maps.newHashMap(); 
	/** 剩余红包数量*/
	private int remainingNum;
	/** 剩余红包金额*/
	private int remainingBonus;
	
	private Timestamp deleteDate;
	private int deleted;
	/** Map<抢红包玩家Id, 抢红包的玩家信息>*/
	private Map<Long ,OpenRedEnveloper> openRedEnveloperMap = Maps.newHashMap();
	
	public RedEnvelope() {
		lifeCycle = new LifeCycleImpl(this);
	}

	public long getCorpsId() {
		return corpsId;
	}

	public void setCorpsId(long corpsId) {
		this.corpsId = corpsId;
	}

	public String getUuid() {
		return uuid;
	}

	public void setUuid(String uuid) {
		this.uuid = uuid;
	}

	public long getSendId() {
		return sendId;
	}

	public void setSendId(long sendId) {
		this.sendId = sendId;
	}

	public String getSendName() {
		return sendName;
	}

	public void setSendName(String sendName) {
		this.sendName = sendName;
	}

	public String getContent() {
		return content;
	}

	public void setContent(String content) {
		this.content = content;
	}
	
	public RedEnvelopeType getRedEnvelopeType() {
		return redEnvelopeType;
	}

	public void setRedEnvelopeType(RedEnvelopeType redEnvelopeType) {
		this.redEnvelopeType = redEnvelopeType;
	}

	public RedEnvelopeStatus getRedEnvelopeStatus() {
		return redEnvelopeStatus;
	}

	public void setRedEnvelopeStatus(RedEnvelopeStatus redEnvelopeStatus) {
		this.redEnvelopeStatus = redEnvelopeStatus;
	}

	public long getCreateTime() {
		return createTime;
	}

	public void setCreateTime(long createTime) {
		this.createTime = createTime;
	}

	public int getBonusAmount() {
		return bonusAmount;
	}

	public void setBonusAmount(int bonusAmount) {
		this.bonusAmount = bonusAmount;
	}

	public int getRemainingNum() {
		return remainingNum;
	}

	public void setRemainingNum(int remainingNum) {
		this.remainingNum = remainingNum;
	}

	public int getRemainingBonus() {
		return remainingBonus;
	}

	public void setRemainingBonus(int remainingBonus) {
		this.remainingBonus = remainingBonus;
	}
	
	public Timestamp getDeleteDate() {
		return deleteDate;
	}

	public void setDeleteDate(Timestamp deleteDate) {
		this.deleteDate = deleteDate;
	}

	public int getDeleted() {
		return deleted;
	}

	public void setDeleted(int deleted) {
		this.deleted = deleted;
	}

	public Map<Long, OpenRedEnveloper> getOpenRedEnveloperMap() {
		return openRedEnveloperMap;
	}

	public void setOpenRedEnveloperMap(Map<Long, OpenRedEnveloper> openRedEnveloperMap) {
		for(Entry<Long, OpenRedEnveloper> entry : openRedEnveloperMap.entrySet()){
			this.openRedEnveloperMap.put(entry.getKey(), entry.getValue());
		}
	}
	
	public Map<Integer, RandomRedEnvelopeUnit> getRandomRedEnvelopeMap() {
		return randomRedEnvelopeMap;
	}
	
	public void setRandomRedEnvelopeMap(Map<Integer, RandomRedEnvelopeUnit> randomRedEnvelopeMap) {
		for(Entry<Integer, RandomRedEnvelopeUnit> entry : randomRedEnvelopeMap.entrySet()){
			this.randomRedEnvelopeMap.put(entry.getKey(), entry.getValue());
		}
	}

	@Override
	public String toString() {
		return "RedEnvelope [uuid=" + uuid + ", isInDb=" + isInDb + ", lifeCycle=" + lifeCycle + ", corpsId=" + corpsId
				+ ", sendId=" + sendId + ", sendName=" + sendName + ", content=" + content + ", redEnvelopeType="
				+ redEnvelopeType + ", redEnvelopeStatus=" + redEnvelopeStatus + ", createTime=" + createTime
				+ ", bonusAmount=" + bonusAmount + ", randomRedEnvelopeMap=" + randomRedEnvelopeMap + ", remainingNum="
				+ remainingNum + ", remainingBonus=" + remainingBonus + ", deleteDate=" + deleteDate + ", deleted="
				+ deleted + ", openRedEnveloperMap=" + openRedEnveloperMap + "]";
	}

	@Override
	public void setDbId(String id) {
		this.uuid = id;
	}

	@Override
	public String getDbId() {
		return this.uuid;
	}

	@Override
	public String getGUID() {
		return "RedEnvelope#" + this.uuid;
	}

	@Override
	public boolean isInDb() {
		return isInDb;
	}

	@Override
	public void setInDb(boolean inDb) {
		this.isInDb = inDb;
	}


	@Override
	public long getCharId() {
		return 0;
	}
	
	@Override
	public RedEnvelopeEntity toEntity() {
		RedEnvelopeEntity entity = new RedEnvelopeEntity();
		entity.setId(this.getUuid());
		entity.setCorpsId(this.getCorpsId());
		entity.setSendId(this.getSendId());
		entity.setSendName(this.getSendName());
		entity.setContent(this.getContent());
		entity.setRedEnvelopeType(this.getRedEnvelopeType().getIndex());
		entity.setRedEnvelopeStatus(this.getRedEnvelopeStatus().getIndex());
		entity.setCreateTime(this.getCreateTime());
		entity.setBonusAmount(this.getBonusAmount());
		entity.setRandomRedEnveloperUnit(this.randomRedEnvelopeMapToJson());
		entity.setRemainingNum(this.getRemainingNum());
		entity.setRemainingBonus(this.getRemainingBonus());
		entity.setDeleted(this.getDeleted());
		entity.setDeleteDate(this.getDeleted() == 1 ? this.getDeleteDate(): null);
		entity.setOpenRedEnveloperInfo(this.openRedEnveloperMapToJson());
		
		return entity;
	}

	@Override
	public void fromEntity(RedEnvelopeEntity entity) {
		this.setDbId(entity.getId());
		this.setCorpsId(entity.getCorpsId());
		this.setSendId(entity.getSendId());
		this.setSendName(entity.getSendName());
		this.setContent(entity.getContent());
		this.setRedEnvelopeType(RedEnvelopeType.valueOf(entity.getRedEnvelopeType()));
		this.setRedEnvelopeStatus(RedEnvelopeStatus.valueOf(entity.getRedEnvelopeStatus()));
		this.setCreateTime(entity.getCreateTime());
		this.setBonusAmount(entity.getBonusAmount());
		this.randomRedEnvelopeMapFromJson(entity.getRandomRedEnveloperUnit());
		this.setRemainingNum(entity.getRemainingNum());
		this.setRemainingBonus(entity.getRemainingBonus());
		this.setDeleted(entity.getDeleted());
		this.setDeleteDate(entity.getDeleteDate());
		this.openRedEnveloperMapFromJson(entity.getOpenRedEnveloperInfo());
		
        setInDb(true);
        active();
	}
	
	public String randomRedEnvelopeMapToJson() {
		JSONArray jsonArr = new JSONArray();
		for (RandomRedEnvelopeUnit data : randomRedEnvelopeMap.values()) {
			jsonArr.add(data.toJson());
		}
		return jsonArr.toString();
	}
	
	public void randomRedEnvelopeMapFromJson(String jsonStr) {
		if (jsonStr == null || jsonStr.isEmpty()) {
			return;
		}
		
		JSONArray array = JSONArray.fromObject(jsonStr);
		if (array == null || array.isEmpty()) {
			return;
		}
		
		for (int i = 0; i < array.size(); i++) {
			RandomRedEnvelopeUnit data = RandomRedEnvelopeUnit.fromJson(array.getString(i));
			if (data != null) {
				randomRedEnvelopeMap.put(data.getId(), data);
			}
		}
	}
	
	public String openRedEnveloperMapToJson() {
		JSONArray jsonArr = new JSONArray();
		for (OpenRedEnveloper data : openRedEnveloperMap.values()) {
			jsonArr.add(data.toJson());
		}
		return jsonArr.toString();
	}
	
	public void openRedEnveloperMapFromJson(String jsonStr) {
		if (jsonStr == null || jsonStr.isEmpty()) {
			return;
		}
		
		JSONArray array = JSONArray.fromObject(jsonStr);
		if (array == null || array.isEmpty()) {
			return;
		}
		
		for (int i = 0; i < array.size(); i++) {
			OpenRedEnveloper data = OpenRedEnveloper.fromJson(array.getString(i));
			if (data != null) {
				openRedEnveloperMap.put(data.getRecId(), data);
			}
		}
	}
	

	@Override
	public LifeCycle getLifeCycle() {
		return lifeCycle;
	}

	@Override
	public void setModified() {
		if (this.lifeCycle.isActive()) {
			Globals.getSceneService().getCommonScene().getCommonDataUpdater().addUpdate(lifeCycle);
		}
		
	}
	
	/**
	 * 激活
	 */
	public void active() {
		this.lifeCycle.activate();
	}

	/**
	 * 删除红包
	 */
	public void delete() {
		onDelete();
	}
	
	/**
	 * 删除
	 */
	public void onDelete() {
		this.lifeCycle.destroy();
		Globals.getSceneService().getCommonScene().getCommonDataUpdater().addDelete(lifeCycle);
	}


}
