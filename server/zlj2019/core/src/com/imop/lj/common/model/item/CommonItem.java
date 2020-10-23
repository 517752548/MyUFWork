package com.imop.lj.common.model.item;


/**
 * 物品信息
 * 
 */
public class CommonItem {
	/**
	 * 道具实例uuid，目前用于客户端实现快捷栏，不可以放入快捷栏的和道具此属性为空
	 */
	protected String uuid;
	/** 道具模板Id，标志一种具体的道具，此值相同的道具即为同一道具 */
	protected int tplId;
	/** 数量 */
	protected int count;
	/** 背包ID */
	protected int bagId;
	/** 道具在背包内位置索引 */
	protected int index;
	/** 持有者id，主背包为0 */
	protected long wearerId;
	/** 最后一次 更新时间，排序用 */
	protected long lastUpdateTime;
	/** 剩余使用时限描述 */
	protected String expireDesc;
	/** 道具的特殊属性json串 */
	protected String props;
	/** 绑定状态，0绑定，1未绑定 */
	protected int bind;

	public String getUuid() {
		return uuid;
	}

	public void setUuid(String uuid) {
		this.uuid = uuid;
	}

	public int getTplId() {
		return tplId;
	}

	public void setTplId(int tplId) {
		this.tplId = tplId;
	}

	public int getCount() {
		return count;
	}

	public void setCount(int count) {
		this.count = count;
	}

	public int getBagId() {
		return bagId;
	}

	public void setBagId(int bagId) {
		this.bagId = bagId;
	}

	public int getIndex() {
		return index;
	}

	public void setIndex(int index) {
		this.index = index;
	}

	public long getWearerId() {
		return wearerId;
	}

	public void setWearerId(long wearerId) {
		this.wearerId = wearerId;
	}

	public long getLastUpdateTime() {
		return lastUpdateTime;
	}

	public void setLastUpdateTime(long lastUpdateTime) {
		this.lastUpdateTime = lastUpdateTime;
	}
	
	public String getExpireDesc() {
		return expireDesc;
	}

	public void setExpireDesc(String expireDesc) {
		this.expireDesc = expireDesc;
	}

	public String getProps() {
		return props;
	}

	public void setProps(String props) {
		this.props = props;
	}
	
	public int getBind() {
		return bind;
	}

	public void setBind(int bind) {
		this.bind = bind;
	}

	@Override
	public String toString() {
		return "CommonItem [uuid=" + uuid + ", tplId=" + tplId + ", count="
				+ count + ", bagId=" + bagId + ", index=" + index
				+ ", wearerId=" + wearerId + ", lastUpdateTime="
				+ lastUpdateTime + ", expireDesc=" + expireDesc + ", props="
				+ props + ", bind=" + bind + "]";
	}
	

}
