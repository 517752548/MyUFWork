package com.imop.lj.common.constants;

import java.util.List;

import com.imop.lj.core.enums.IndexedEnum;
import com.imop.lj.core.util.EnumUtil;

/**
 * 终端类型枚举
 *
 * @author haijiang.jin
 * @since 2011/10/17
 *
 */
public enum TerminalTypeEnum implements IndexedEnum {
	/** web端 */
	WEB(1,"","pc"),
	/** iphone端 */
	IPHONE(2,"IPHONE","ios"),
	/** ipad端 */
	IPAD(3,"IPAD","ios"),
	/** ipad端 */
	ANDROID(4,"ANDROID","android"),
	;

	private String source;

	private String terminalTypeName;
	private TerminalTypeEnum(int index,String source,String terminalTypeName) {
		this.index = index;
		this.source = source;
		this.terminalTypeName = terminalTypeName;
	}

	public final int index;

	@Override
	public int getIndex() {
		return index;
	}

	public String getSource(){
		return this.source;
	}

	private static final List<TerminalTypeEnum> values = IndexedEnumUtil
			.toIndexes(TerminalTypeEnum.values());

	public static TerminalTypeEnum valueOf(int index) {
		return EnumUtil.valueOf(values, index);
	}

	/**
	 * 返回平台名称
	 * @return
	 */
	public String getTerminalTypeName(){
		return this.terminalTypeName;
	}
}
