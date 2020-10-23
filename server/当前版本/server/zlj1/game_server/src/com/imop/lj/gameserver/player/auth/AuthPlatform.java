package com.imop.lj.gameserver.player.auth;

import java.util.List;

import com.imop.lj.core.enums.IndexedEnum;
import com.imop.lj.core.util.EnumUtil;
import com.imop.lj.gameserver.player.Player;

/**
 * 其他登陆平台
 * 
 * @author yuanbo.gao
 *
 */
public enum AuthPlatform implements IndexedEnum {
	G37WANWAN(2057,"765000201"),
	QQ(2020, "0"),
	
	;
	
	private AuthPlatform(int index,String fValue) {
		this.index = index;
		this.fValue = fValue;
	}

	public final int index;
	
	public final String fValue;

	@Override
	public int getIndex() {
		return index;
	}
	
	public String getfValue() {
		return fValue;
	}

	private static final List<AuthPlatform> values = IndexedEnumUtil
			.toIndexes(AuthPlatform.values());

	public static AuthPlatform valueOf(int index) {
		return EnumUtil.valueOf(values, index);
	}
	
	public static UserAuth buildOtherPlatform(Player player){
		switch (player.getAuthPlatform()) {
		case G37WANWAN:
			return new ZLJ37wanwanAuthImpl(G37WANWAN.getIndex() + "", G37WANWAN.getfValue());
		case QQ:
			return new QQAuthImpl(QQ.getIndex()+"", QQ.getfValue());
			
		default:
			return null;
		}
	}
}
