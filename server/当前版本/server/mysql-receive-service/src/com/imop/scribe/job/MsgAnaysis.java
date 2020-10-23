package com.imop.scribe.job;

/**
 * @author wenping.jiang
 *	目标分析类
 */
public class MsgAnaysis {
	
	/**
	 * msg类型
	 */
	private String msgType;
	/**
	 * 总耗时
	 */
	private long totalTime;
	/**
	 * 总个数
	 */
	private long count;
	/**
	 * 最大时间
	 */
	private long maxTime;
	
	public MsgAnaysis(String msgType){
		this.msgType = msgType;
	}
	public long getTotalTime() {
		return totalTime;
	}
	public void setTotalTime(long totalTime) {
		this.totalTime = totalTime;
	}
	public long getCount() {
		return count;
	}
	public void setCount(long count) {
		this.count = count;
	}
	public long getMaxTime() {
		return maxTime;
	}
	public void setMaxTime(long maxTime) {
		this.maxTime = maxTime;
	}
	
	/**
	 * @param time
	 * 加总时间
	 */
	public void addTotalTime(int time){
		this.totalTime += time;
	}
	
	/**
	 * @param count
	 * 增加个数
	 */
	public void addCount(int count){
		this.count += count;
	}
	
	/**
	 * @param maxTime
	 * 比较最大值，如果大于最大值，则重设最大值
	 */
	public void compareMaxTime(int maxTime){
		if(this.getMaxTime() < maxTime){
			this.maxTime = maxTime;
		}
	}
	
	/**
	 * @return
	 * 获得存储字符串，顺序为最大时间，总个数，平均时间，最大时间
	 */
	public String getCsvString(){
		StringBuffer buffer = new StringBuffer();
		buffer.append(msgType);
		buffer.append(",");
		buffer.append(totalTime);
		buffer.append(",");
		buffer.append(count);
		buffer.append(",");
		if(count == 0){
			buffer.append(totalTime);
		}else{
			buffer.append(totalTime / count);
		}
		buffer.append(",");
		buffer.append(maxTime);
		return buffer.toString();
	}
}
