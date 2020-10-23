package com.imop.lj.gameserver.title;

import com.imop.lj.core.util.TimeUtils;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.heartbeat.HeartbeatTask;

/**
 * Created by wyn on 16/1/17.
 */
public class TitleCheck implements HeartbeatTask {
    private static final long CHECK_EXPIRED_SPAN = TimeUtils.MIN;
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

        Globals.getTitleService().checkTitle();
    }
}
