package com.imop.lj.gameserver.dirtywords;

import com.imop.lj.common.constants.Loggers;
import com.imop.lj.core.async.IIoOperation;
import com.imop.lj.core.util.IKeyWordsFilter;
import com.imop.lj.core.util.KeyWordsACFilter;
import com.imop.lj.gameserver.common.db.operation.LocalIoOperation;

/**
 * 请求过滤语言包
 *
 *
 */
public class DirtyWordsNetOperation implements LocalIoOperation {
	private WordsDirtyNetOperationCallBack callBack;
	private WordFilterNetDownload worldFiterNetDownLoad;
	private String url = "";
	private String[] str;
	
	private IKeyWordsFilter filter;
	
	public DirtyWordsNetOperation(WordFilterNetDownload worldFiterNetDownLoad,String url,WordsDirtyNetOperationCallBack callBack) {
		this.callBack = callBack;
		this.worldFiterNetDownLoad = worldFiterNetDownLoad;
		this.url = url;
	}
	
	@Override
	public int doIo() {
		try {
			if(worldFiterNetDownLoad!=null && url!=null && !url.equalsIgnoreCase("")){
				str = worldFiterNetDownLoad.download(url);
				// 生成filter
				if (str != null && str.length > 0) {
					this.filter = new KeyWordsACFilter(DirtyFilterNetService.IGNORE_CHARS, DirtyFilterNetService.SUBSTITUTE_CHAR);
					this.filter.initialize(str);
				} else {
					Loggers.dirtyWordsLogger.error("DirtyWorldsNetOperation.doIo() str is null or empty!");
				}
			}else{
				Loggers.dirtyWordsLogger.error("DirtyWorldsNetOperation.doIo() url="+url+" or WorldFiterNetDownLoad is null");
			}
		} catch (Exception e) {
			e.printStackTrace();
			Loggers.dirtyWordsLogger.error("DirtyWorldsNetOperation.doIo() exception=" + e.toString());
			return IIoOperation.STAGE_STOP_DONE;
		}
		return IIoOperation.STAGE_IO_DONE;
	}

	@Override
	public int doStart() {
		return IIoOperation.STAGE_START_DONE;
	}

	@Override
	public int doStop() {
		callBack.afterCheckComplete(filter);
		return IIoOperation.STAGE_STOP_DONE;
	}
}
