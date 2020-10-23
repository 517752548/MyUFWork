package com.imop.lj.gameserver.battlereport;

import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.concurrent.atomic.AtomicLong;

/**
 * 战报id生成工具
 * @author yue.yan
 *
 */
public class BattleReportIdGenerator {

	/** 7位顺序号，8位日期，3为毫秒时间戳 */
	private static long SEQUENCE_MAX = 10000000l;
	private static int TIMESTAMP_MAX = 1000;
	
	private int datePrefix;
	
	private AtomicLong sequence;
	
	public BattleReportIdGenerator() {
	}
	
	public void reset(int datePrefix, int sequence) {
		this.datePrefix = datePrefix;
		this.sequence = new AtomicLong(sequence);
	}
	
	public void resetWithMaxId(int datePrefix, long maxId) {
		this.datePrefix = datePrefix;
		this.sequence = new AtomicLong(maxId / TIMESTAMP_MAX % SEQUENCE_MAX + 1);
	}
	
	public long generate(long now) {
		return (SEQUENCE_MAX * datePrefix + sequence.getAndIncrement()) * 1000 + now % 1000;
	}
	
	public int getDatePrefix(long id) {
		return (int)(id / SEQUENCE_MAX / TIMESTAMP_MAX);
	}
	
	public int getDatePrefix(Date date) {
		String datePrefixStr = new SimpleDateFormat("yyyyMMdd").format(date);
		return Integer.parseInt(datePrefixStr);
	}
	
	public static void main(String[] args) {
		BattleReportIdGenerator idGenerator = new BattleReportIdGenerator();
		idGenerator.reset(idGenerator.getDatePrefix(new Date()), 0);
		System.out.println(idGenerator.generate(System.currentTimeMillis()));
		System.out.println(idGenerator.generate(System.currentTimeMillis()));
		System.out.println(idGenerator.generate(System.currentTimeMillis()));

	}
	
}
