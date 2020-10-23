package com.imop.lj.gameserver.wing;

import java.sql.Timestamp;

import com.imop.lj.common.constants.Loggers;
import com.imop.lj.core.object.LifeCycle;
import com.imop.lj.core.object.LifeCycleImpl;
import com.imop.lj.core.object.PersistanceObject;
import com.imop.lj.db.model.WingEntity;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.wing.template.WingTemplate;

/**
 * 翅膀
 */
public class Wing implements PersistanceObject<String, WingEntity>, Comparable<Wing> {
    /**
     * 道具的实例UUID
     */
    private String UUID;

    /**
     * 道具模板
     */
    private WingTemplate template;
    
    /**
     * 翅膀阶数
     */
    private int wingLevel;
    
    /**
     * 翅膀祝福值
     */
    private int wingBless;
    
    /**
     * 翅膀战斗力
     */
    private int wingPower;
    
    /**
     * 此实例是否在db中
     */
    private boolean isInDb;

    /**
     * 物品的生命期的状态
     */
    private final LifeCycle lifeCycle;


    /**
     * 所有者
     */
    private Human owner;

    /**
     * 创建时间
     */
    private Timestamp createTime;

    /**
     * 是否已装备，1-是，2-否
     */
    private int isEquip;

    public Wing() {
        super();
        lifeCycle = new LifeCycleImpl(this);
    }


    public Wing(Human owner, WingTemplate template, String UUID) {
        super();
        lifeCycle = new LifeCycleImpl(this);
        this.owner = owner;
        this.template = template;
        this.UUID = UUID;
    }


    @Override
    public void setDbId(String id) {
        this.UUID = id;

    }

    public Integer getTemplateId() {
        return this.template.getId();
    }

    @Override
    public String getDbId() {
        return UUID;
    }

    @Override
    public String getGUID() {
        return "wing#" + this.UUID;
    }

    @Override
    public boolean isInDb() {
        return isInDb;
    }

    @Override
    public void setInDb(boolean inDb) {
        this.isInDb = inDb;
    }

    @Override
    public long getCharId() {
        Human owner = getOwner();
        return owner == null ? -1 : owner.getCharId();
    }

    public void setCreateTime(Timestamp createTime) {
        this.createTime = createTime;
    }

    public void setOwner(Human owner) {
        this.owner = owner;
    }

    public WingTemplate getTemplate() {
        return template;
    }

    public void setTemplate(WingTemplate template) {
        this.template = template;
    }
    
    public int getWingLevel() {
		return wingLevel;
	}


	public void setWingLevel(int wingLevel) {
		this.wingLevel = wingLevel;
	}


	public int getWingBless() {
		return wingBless;
	}


	public void setWingBless(int wingBless) {
		this.wingBless = wingBless;
	}
	
	public int getWingPower() {
		return wingPower;
	}


	public void setWingPower(int wingPower) {
		this.wingPower = wingPower;
	}


	public int getIsEquip() {
		return isEquip;
	}


	public void setIsEquip(int isEquip) {
		this.isEquip = isEquip;
	}


	@Override
    public WingEntity toEntity() {
    	WingEntity entity = new WingEntity();
        entity.setId(this.getDbId());
        entity.setCharId(this.getCharId());
        entity.setTemplateId(this.getTemplateId());
        entity.setWingLevel(this.getWingLevel());
        entity.setWingBless(this.getWingBless());
        entity.setWingPower(this.getWingPower());
        entity.setEquipped(this.getIsEquip());
        entity.setCreateDate(this.createTime);
        return entity;
    }

    @Override
    public void fromEntity(WingEntity entity) {
        this.UUID = entity.getId();
        this.template = Globals.getTemplateCacheService().get(entity.getTemplateId(), WingTemplate.class);
        this.wingLevel = entity.getWingLevel();
        this.wingBless = entity.getWingBless();
        this.wingPower = entity.getWingPower();
        this.isEquip = entity.getEquipped();
        this.createTime = entity.getCreateDate();

        setInDb(true);
        active();

    }

    @Override
    public LifeCycle getLifeCycle() {
        return lifeCycle;
    }

    @Override
    public void setModified() {
        if (this.lifeCycle != null) {
            // 为了防止发生一些错误的使用状况,暂时把此处的检查限制得很严格
            this.lifeCycle.checkModifiable();
            if (this.lifeCycle.isActive()) {
                // 物品的生命期处于活动状态,并且该物品不是空的,则执行通知更新机制进行
                this.onUpdate();
            }
        }
    }

    public Human getOwner() {
        return owner;
    }

    public Timestamp getCreateTime() {
        return createTime;
    }

    /**
     * 物品实例被修改(新增加或者属性更新)时调用,触发更新机制
     */
    private void onUpdate() {
        if (Loggers.wingLogger.isDebugEnabled()) {
            Loggers.wingLogger.debug(String.format("update wing=%s id=%s ", this.toString(), this.UUID));
        }
        this.getOwner().getPlayer().getDataUpdater().addUpdate(this.getLifeCycle());
    }

    public void active() {
        getLifeCycle().activate();
    }


    @Override
    public int compareTo(Wing o) {
        return 1;
    }


}
