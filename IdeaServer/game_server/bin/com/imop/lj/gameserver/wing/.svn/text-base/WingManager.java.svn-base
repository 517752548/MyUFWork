package com.imop.lj.gameserver.wing;

import java.util.ArrayList;
import java.util.Collection;
import java.util.List;
import java.util.Map;

import com.google.common.collect.Maps;
import com.imop.lj.db.model.WingEntity;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.db.RoleDataHolder;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.human.JsonPropDataHolder;
import com.imop.lj.gameserver.wing.persistance.WingDbManager;


public class WingManager implements JsonPropDataHolder, RoleDataHolder {



    private Human human;

    /**Map<templateId,翅膀> */
    private Map<Integer, Wing> allWingMap = Maps.newHashMap();

	/** 装备中的翅膀Id，可为0 */
	private Integer wingingId = 0;

	public static final int EQUIPPED = 1;
	public static final int NOT_EQUIPPED = 2;
	
    public WingManager(Human human) {
        super();
        this.human = human;
    }


	@Override
	public void checkAfterRoleLoad() {
		//重新计算战力
		for (Wing w : allWingMap.values()) {
			w.setWingPower(Globals.getWingService().calcWingFightPower(w));
		}
	}


	@Override
	public void checkBeforeRoleEnter() {
		
	}


	@Override
	public String toJsonProp() {
		return null;
	}


	@Override
	public void loadJsonProp(String value) {
		
	}

	/**
	 * 获取装备中的翅膀的模板Id，没有则为0
	 * @return
	 */
	public int getWingingTplId() {
		Wing w = getWinging();
		if(w == null)
		{
			return 0;
		}
		return w.getTemplateId();
	}
	
    public Wing getWingByTemplateId(int templateId) {
        if (allWingMap.containsKey(templateId)) {
            return allWingMap.get(templateId);
        }
        return null;
    }
    
    /**
     * 获取装备中的翅膀
     * @return
     */
    public Wing getWinging(){
    	Collection<Wing> c= allWingMap.values();
    	for (Wing wing : c) {
			if (wing.getIsEquip() == EQUIPPED) {
				return wing;
			}
		}
    	return null;
    }

	public Human getOwner() {
		return human;
	}

	public void addNewWing(Wing w) {
		allWingMap.put(w.getTemplateId(), w);
		setWingingId(w.getTemplateId());
	}


	public List<Wing> getAllWingList() {
		List<Wing> wList = new ArrayList<Wing>();
		wList.addAll(allWingMap.values());
		return wList;
	}

	public void load() {
	    List<WingEntity> wlist = WingDbManager.getInstance().loadWingsFromDB(this);
        for (WingEntity we : wlist) {
            Wing w = new Wing();
            w.fromEntity(we);
            w.setOwner(human);
            addNewWing(w);
        }
	}


	public Integer getWingingId() {
		return wingingId;
	}


	public void setWingingId(Integer wingingId) {
		this.wingingId = wingingId;
	}

}
