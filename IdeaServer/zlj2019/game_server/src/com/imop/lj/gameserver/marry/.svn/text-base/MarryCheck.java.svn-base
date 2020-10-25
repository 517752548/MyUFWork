package com.imop.lj.gameserver.marry;

import com.imop.lj.core.util.TimeUtils;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.heartbeat.HeartbeatTask;

/**
 * Created by zhangzhe on 16/1/2.
 */
public class MarryCheck implements HeartbeatTask
{
    private static final long CHECK_EXPIRED_SPAN = TimeUtils.MIN;
    private boolean isCanceled;
    @Override
    public long getRunTimeSpan() {
        return this.CHECK_EXPIRED_SPAN;
    }

    @Override
    public void cancel() {
        this.isCanceled = true;
    }

    @Override
    public void run() {
        if (isCanceled) {
            return;
        }

        Globals.getMarryService().checkMarryhartbeat();
    }
}
