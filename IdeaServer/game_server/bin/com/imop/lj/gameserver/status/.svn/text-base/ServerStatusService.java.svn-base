package com.imop.lj.gameserver.status;

import java.util.ConcurrentModificationException;
import java.util.concurrent.TimeUnit;

import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.config.GameServerConfig;
import com.imop.lj.gameserver.common.log.GameErrorLogInfo;
import com.imop.platform.local.callback.ICallback;
import com.imop.platform.local.response.IResponse;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.common.constants.SharedConstants;
import com.imop.lj.core.util.ErrorsUtil;
import com.imop.lj.core.util.ReportServerStatus.ServerStatusType;
import com.mchange.util.AssertException;

/**
 * 服务器状态服务
 *
 */
public class ServerStatusService {

	private ServerStatusType status = ServerStatusType.STATUS_INIT;

	private volatile boolean reporting;

	public ServerStatusType getStatus() {
		switch (status) {
		case STATUS_INIT:
		case STATUS_LIMITED:
		case STATUS_STOPPING:
		case STATUS_STOPPED:
		case STATUS_ERROR:
		case STATUS_RUN: {
			return this.status;
		}
		default:
			throw new AssertException("mismatch ServerStatusType");
		}
	}

	public void setStatus(ServerStatusType status) {
		this.status = status;
	}

	public void stopping() {
		this.status = ServerStatusType.STATUS_STOPPING;
	}

	public void stopped() {
		this.status = ServerStatusType.STATUS_STOPPED;
	}

	public void run() {
		this.status = ServerStatusType.STATUS_RUN;
	}

	public void limited() {
		this.status = ServerStatusType.STATUS_LIMITED;
	}

	public void reportToLocal() {
		reportToLocal(getStatus());
	}

	public void reportToLocalSync() {
		reportToLocalSync(getStatus());
	}

	public void reportToLocal(ServerStatusType status) {
		GameServerConfig config = Globals.getServerConfig();
//		if (config.getIsDebug() || config.getAuthType() != SharedConstants.AUTH_TYPE_INTERFACE) {
//			return;
//		}
		if (config.getAuthType() != SharedConstants.AUTH_TYPE_INTERFACE) {
			return;
		}
		if (!config.isTurnOnLocalInterface()) {
			return;
		}
		Globals.getAsyncLocalService().reportServerStatus(config.getLocalHostId(), status.getStatusCode(), "");
//		Globals.getLocalHandler().statusReport(config.getLocalHostId(),	status.getStatusCode(), "");
	}

	public void reportToLocalSync(ServerStatusType status) {
		if (!Globals.getServerConfig().isTurnOnLocalInterface()) {
			return;
		}
		
		GameServerConfig config = Globals.getServerConfig();
//		if (config.getIsDebug() || config.getAuthType() != SharedConstants.AUTH_TYPE_INTERFACE) {
//			return;
//		}
		if (config.getAuthType() != SharedConstants.AUTH_TYPE_INTERFACE) {
			return;
		}
		if (reporting) {
			throw new ConcurrentModificationException();
		}
		reporting = true;
		Globals.getSynLocalService().reportServerStatus(config.getLocalHostId(), status.getStatusCode(), "",
				new ICallback() {

					@Override
					public void onSuccess(IResponse iresponse) {
						reporting = false;
					}

					@Override
					public void onFail(IResponse iresponse) {
						reporting = false;
					}
				}
		);
		while (reporting) {
			try {
				TimeUnit.SECONDS.sleep(1);
			} catch (InterruptedException e) {
				Loggers.gameLogger.error(ErrorsUtil.error(GameErrorLogInfo.INVOKE_REPORT_LOCAL_ONLINE_ERR,
						"#GS.ServerStatusService.reportToLocalSync", "report return fail!"));
			}
		}
	}

}
