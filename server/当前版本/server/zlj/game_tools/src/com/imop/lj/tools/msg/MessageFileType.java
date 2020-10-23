package com.imop.lj.tools.msg;

import java.util.List;

import com.imop.lj.core.enums.IndexedEnum;
import com.imop.lj.core.util.EnumUtil;


public enum MessageFileType implements IndexedEnum {
	/** AS文件CG协议 */
	AS_CG(1),
	/** AS文件GC协议 */
	AS_GC(2),
	/** 服务器CG协议 */
	SERVER_CG(3),
	/** 服务器GC协议 */
	SERVER_GC(4),
	/** 服务器WG协议 */
	SERVER_WG(5),
	/** 服务器GW协议 */
	SERVER_GW(6),
	/** 跨服服务器WG协议 */
	WORLD_SERVER_WG(7),
	/** 跨服服务器GW协议 */
	WORLD_SERVER_GW(8),
	/** CPP文件CG协议 */
	CPP_CG(9),
	/** CPP文件GC协议 */
	CPP_GC(10),
	/** LUA文件CG协议 */
	LUA_CG(11),
	/** LUA文件GC协议 */
	LUA_GC(12),
	
	/** CS文件CG协议 */
	CS_CG(13),
	/** CS文件GC协议 */
	CS_GC(14),
	;

	public final int index;

	@Override
	public int getIndex() {
		return index;
	}

	private MessageFileType(int index) {
		this.index = index;
	}

	private static final List<MessageFileType> values = IndexedEnumUtil.toIndexes(MessageFileType.values());

	public static MessageFileType valueOf(int index) {
		return EnumUtil.valueOf(values, index);
	}
}
