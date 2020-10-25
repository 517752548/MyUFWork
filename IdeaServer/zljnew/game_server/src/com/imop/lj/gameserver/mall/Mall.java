package com.imop.lj.gameserver.mall;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.LinkedList;
import java.util.List;
import java.util.Map;
import java.util.Map.Entry;

import net.sf.json.JSONArray;

import com.imop.lj.core.object.LifeCycle;
import com.imop.lj.core.object.LifeCycleImpl;
import com.imop.lj.core.object.PersistanceObject;
import com.imop.lj.db.model.MallEntity;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.offlinedata.KeyValue;

/**
 * 商城数据
 * 
 * @author xiaowei.liu
 * 
 */
public class Mall implements PersistanceObject<Long, MallEntity> {
	private long id;
	/** GM修改时，策划配置数据 */
	private long startConfigTime;
	/** GM修改时，策划配置队列 */
	private String queueConfig;

	/** 当前队列的UUID */
	private String currQueueUUID;
	/** 当前队列模版ID */
	private int currQueueId;
	/** 当前队列开始时间 */
	private long currStartTime;

	private boolean inDb;
	private LifeCycle lifeCycle;
	
	private LinkedList<Integer> timeLimitQueue;
	private Map<Integer, Integer> stock;
	
	/**最后一次播放开始公告时间*/
	private long lastStartBroadcastTime;
	/**结束公告列表*/
	private List<Integer> endBroadcastList;

	public Mall() {
		this.lifeCycle = new LifeCycleImpl(this);
		this.timeLimitQueue = new LinkedList<Integer>();
		this.stock = new HashMap<Integer, Integer>();
		this.endBroadcastList = new ArrayList<Integer>();
	}

	@Override
	public void setDbId(Long id) {
		this.id = id;
	}

	@Override
	public Long getDbId() {
		return this.id;
	}

	@Override
	public String getGUID() {
		return "mall#" + id;
	}

	@Override
	public boolean isInDb() {
		return this.inDb;
	}

	@Override
	public void setInDb(boolean inDb) {
		this.inDb = inDb;
	}

	@Override
	public long getCharId() {
		return 0;
	}

	@Override
	public MallEntity toEntity() {
		MallEntity entity = new MallEntity();
		entity.setId(this.id);
		entity.setQueueConfig(this.queueConfig);
		entity.setStartConfigTime(this.startConfigTime);
		
		entity.setCurrQueueConfig(this.toCurrQueueConfig());
		entity.setCurrQueueUUID(this.currQueueUUID);
		entity.setCurrQueueId(this.currQueueId);
		entity.setCurrStartTime(this.currStartTime);
		entity.setStockPack(this.toStockPack());
		entity.setUpdateTime(Globals.getTimeService().now());
		return entity;
	}

	public String toCurrQueueConfig(){
		JSONArray array = new JSONArray();
		for(Integer queueId : this.timeLimitQueue){
			array.add(queueId);
		}
		return array.toString();
	}
	
	public String toStockPack(){
		JSONArray array = new JSONArray();
		for(Entry<Integer, Integer> entry : this.stock.entrySet()){
			KeyValue keyValue = new KeyValue(entry.getKey(), (float)(entry.getValue().intValue()));
			array.add(keyValue.toJson());
		}
		return array.toString();
	}
	@Override
	public void fromEntity(MallEntity entity) {
		this.id = entity.getId();
		this.queueConfig = entity.getQueueConfig();
		this.startConfigTime = entity.getStartConfigTime();
		this.inDb = true;
		
		this.currQueueConfigFromJson(entity.getCurrQueueConfig());
		this.currQueueUUID = entity.getCurrQueueUUID();
		this.currQueueId = entity.getCurrQueueId();
		this.currStartTime = entity.getCurrStartTime();
		this.stockFromJson(entity.getStockPack());
	}
	
	public void currQueueConfigFromJson(String json){
		this.timeLimitQueue.clear();
		if(json == null || json.isEmpty()){
			return;
		}
		
		JSONArray array = JSONArray.fromObject(json);
		if(array == null || array.isEmpty()){
			return;
		}
		
		for(int i=0; i<array.size(); i++){
			int queueId = array.getInt(i);
			this.timeLimitQueue.add(queueId);
		}
	}
	
	public void stockFromJson(String json){
		this.stock.clear();
		if(json == null || json.isEmpty()){
			return;
		}
		
		JSONArray array = JSONArray.fromObject(json);
		if(array == null || array.isEmpty()){
			return;
		}
		
		for(int i=0; i < array.size(); i++){
			String str = array.getString(i);
			KeyValue kv = KeyValue.fromJson(str);
			if(kv == null){
				continue;
			}
			
			this.stock.put(kv.getKey(), (int)kv.getValue());
		}
	}

	@Override
	public LifeCycle getLifeCycle() {
		return this.lifeCycle;
	}

	@Override
	public void setModified() {
		this.lifeCycle.checkModifiable();
		if (this.lifeCycle.isActive()) {
			Globals.getSceneService().getCommonScene().getCommonDataUpdater()
					.addUpdate(lifeCycle);
		}
	}

	public long getId() {
		return id;
	}

	public void setId(long id) {
		this.id = id;
	}

	public long getStartConfigTime() {
		return startConfigTime;
	}

	public void setStartConfigTime(long startConfigTime) {
		this.startConfigTime = startConfigTime;
	}

	public String getQueueConfig() {
		return queueConfig;
	}

	public void setQueueConfig(String queueConfig) {
		this.queueConfig = queueConfig;
	}

	public String getCurrQueueUUID() {
		return currQueueUUID;
	}

	public void setCurrQueueUUID(String currQueueUUID) {
		this.currQueueUUID = currQueueUUID;
	}

	public int getCurrQueueId() {
		return currQueueId;
	}

	public void setCurrQueueId(int currQueueId) {
		this.currQueueId = currQueueId;
	}

	public long getCurrStartTime() {
		return currStartTime;
	}

	public void setCurrStartTime(long currStartTime) {
		this.currStartTime = currStartTime;
	}

	public LinkedList<Integer> getTimeLimitQueue() {
		return timeLimitQueue;
	}

	public void setTimeLimitQueue(LinkedList<Integer> timeLimitQueue) {
		this.timeLimitQueue = timeLimitQueue;
	}

	public Map<Integer, Integer> getStock() {
		return stock;
	}

	public void setStock(Map<Integer, Integer> stock) {
		this.stock = stock;
	}

	public void setLifeCycle(LifeCycle lifeCycle) {
		this.lifeCycle = lifeCycle;
	}

	public long getLastStartBroadcastTime() {
		return lastStartBroadcastTime;
	}

	public void setLastStartBroadcastTime(long lastStartBroadcastTime) {
		this.lastStartBroadcastTime = lastStartBroadcastTime;
	}

	public List<Integer> getEndBroadcastList() {
		return endBroadcastList;
	}

	public void setEndBroadcastList(List<Integer> endBroadcastList) {
		this.endBroadcastList = endBroadcastList;
	}
}
