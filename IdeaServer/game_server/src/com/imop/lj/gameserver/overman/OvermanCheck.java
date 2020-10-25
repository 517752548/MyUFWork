package com.imop.lj.gameserver.overman;

import com.imop.lj.core.util.TimeUtils;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.heartbeat.HeartbeatTask;

/**
 * Created by zhangzhe on 15/12/31.
 */
public class OvermanCheck implements HeartbeatTask {
	
    private static final long CHECK_EXPIRED_SPAN = 10 * TimeUtils.MIN;
    private boolean isCanceled;

    @Override
    public long getRunTimeSpan() {
        return this.CHECK_EXPIRED_SPAN;
    }

    @Override
    public void cancel() {
        isCanceled = true;

    }

    @Override
    public void run() {
        if (isCanceled) {
            return;
        }

        Globals.getOvermanService().checkOvermanhartbeat();
    }
}
