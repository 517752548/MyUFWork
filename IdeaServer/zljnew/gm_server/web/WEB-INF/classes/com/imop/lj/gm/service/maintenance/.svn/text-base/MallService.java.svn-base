package com.imop.lj.gm.service.maintenance;

import java.util.ArrayList;
import java.util.List;

import com.imop.lj.db.model.MallEntity;
import com.imop.lj.gm.dao.maintenance.MallDao;
import com.imop.lj.gm.model.MallVo;
import com.imop.lj.gm.utils.DateUtil;

/**
 * 商城服务
 * 
 * @author xiaowei.liu
 * 
 */
public class MallService {
	private MallDao mallDAO;

	public List<MallVo> getAllMallInfoList() {
		List<MallVo> list = new ArrayList<MallVo>();
		List<MallEntity> meList = mallDAO.getMallEntityList();
		if (meList == null || meList.isEmpty()) {
			return list;
		}

		for (MallEntity me : meList) {
			MallVo mallVo = new MallVo();
			mallVo.setMall(me);
			mallVo.setCurrStartTime(DateUtil.formateDateLong(me.getCurrStartTime()));
			mallVo.setStartConfigTime(DateUtil.formateDateLong(me.getStartConfigTime()));
			mallVo.setUpdateTime(DateUtil.formateDateLong(me.getUpdateTime()));
			list.add(mallVo);
		}
		return list;
	}

	public MallDao getMallDAO() {
		return mallDAO;
	}

	public void setMallDAO(MallDao mallDAO) {
		this.mallDAO = mallDAO;
	}

}
