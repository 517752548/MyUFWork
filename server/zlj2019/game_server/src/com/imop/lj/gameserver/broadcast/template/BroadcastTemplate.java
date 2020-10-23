package com.imop.lj.gameserver.broadcast.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.gameserver.common.SysMsgShowTypes.SysMessageType;

/**
 * 广播配置
 *
 */
@ExcelRowBinding
public class BroadcastTemplate extends BroadcastTemplateVO {
	private SysMessageType sysMessageType = null;
	
	@Override
	public void check() throws TemplateConfigException {
		// 检查showTypeId是否存在
		if (null == SysMessageType.valueOf(showTypeId)) {
			throw new TemplateConfigException(this.sheetName, getId(), String.format("推送频道 %d 不存在！", showTypeId));
		}
		sysMessageType = SysMessageType.valueOf(showTypeId);
		
		// 增加检测，{0}中间必须是数字
		if (contents.contains("{") && contents.contains("}")) {
			//"{0}鸿运当头，刷新出{1}，各位大神，赶紧来护送喽" 替换后 num为="01"
			String reg = "[^\\{\\}]*\\{([^\\{\\}]*)\\}[^\\{\\}]*";
			String num = contents.replaceAll(reg, "$1");
			try {
				Integer.parseInt(num);
			} catch  (NumberFormatException e) {
				throw new TemplateConfigException(this.sheetName, getId(), "广播参数非法，{}之间必须为数字！");
			}
		}
	}
	
	/**
	 * 获取广播频道类型
	 * @return
	 */
	public SysMessageType getSysMessageType() {
		return sysMessageType;
	}
}
