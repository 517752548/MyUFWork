package com.imop.scribe.receiver;

import java.util.List;
import java.util.Map;
import java.util.concurrent.ConcurrentHashMap;
import java.util.concurrent.atomic.AtomicLong;

import org.apache.thrift.TException;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import scribe.thrift.LogEntry;
import scribe.thrift.ResultCode;
import scribe.thrift.scribe.Iface;

import com.facebook.fb303.fb_status;

/**
 * @author xin.yu
 * @author dongyong.wang
 */
public class LogHandler implements Iface {
	private static final Logger logger = LoggerFactory.getLogger("ScribeHandler");
	
	public final static String NAME = "scribe";
	public final static String VERSION = "0.0.4-r1";

	String statusDetails = "initial status";
	long alive = System.currentTimeMillis() / 1000;
	final AtomicLong counter = new AtomicLong();
	final ConcurrentHashMap<String, Long> counters = new ConcurrentHashMap<String, Long>();
	
	DatabaseLogStore store;
	
	public LogHandler() {
		// TODO more effective store init.
		store = new DatabaseLogStore();
	}

	@Override
	public String getName() throws TException {
		return NAME;
	}

	@Override
	public String getVersion() throws TException {
		return VERSION;
	}

	@Override
	public fb_status getStatus() throws TException {
		return fb_status.ALIVE;
	}

	@Override
	public String getStatusDetails() throws TException {
		return statusDetails;
	}

	@Override
	public Map<String, Long> getCounters() throws TException {
		return counters;
	}

	@Override
	public long getCounter(String key) throws TException {
		Long val = counters.get(key);
		if (val == null) {
			return 0;
		}
		return val.longValue();
	}

	@Override
	public void setOption(String key, String value) throws TException {
		// TODO Auto-generated method stub
	}

	@Override
	public String getOption(String key) throws TException {
		return null;
	}

	@Override
	public Map<String, String> getOptions() throws TException {
		return null;
	}

	@Override
	public String getCpuProfile(int profileDurationInSec) throws TException {
		return "";
	}

	@Override
	public long aliveSince() throws TException {
		return alive;
	}

	@Override
	public void reinitialize() throws TException {
	}

	@Override
	public void shutdown() throws TException {
	}

	@Override
	public ResultCode Log(List<LogEntry> messages) throws TException {
		if (logger.isDebugEnabled()) {
			logger.debug("Messages:" + messages.size());
		}
		
		long ccount = counter.addAndGet(messages.size());
		if (ccount % 1000 == 0) {
			if (logger.isInfoEnabled()) {
				logger.info("log count:" + ccount);
			}
		}
		
		store.storeLogs(messages);
		return ResultCode.OK; // OK
	}
}
