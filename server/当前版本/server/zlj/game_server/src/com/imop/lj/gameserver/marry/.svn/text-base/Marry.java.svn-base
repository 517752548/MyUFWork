package com.imop.lj.gameserver.marry;

import com.imop.lj.core.object.LifeCycle;
import com.imop.lj.core.object.LifeCycleImpl;
import com.imop.lj.core.object.PersistanceObject;
import com.imop.lj.db.model.MarryEntity;
import com.imop.lj.gameserver.common.Globals;

/**
 * Created by fengmaogen on 15/12/28.
 */
public class Marry implements PersistanceObject<Long, MarryEntity> {

    private final static long FIRE_DELAY = 259200000;

    /**
     * 生命期
     */
    private final LifeCycle lifeCycle;

    private long id;

    private long charId;

    /**
     * 此实例是否在db中
     */
    private boolean isInDb;

    /**
     * 是否删除
     */
    private int deleted;
    /**
     * 婚姻信息
     */
    private MarryCorrelationInfo marryProps;

    public Marry() {
        marryProps = new MarryCorrelationInfo();
        lifeCycle = new LifeCycleImpl(this);
    }

    @Override
    public void setDbId(Long id) {
        this.id = id;
    }

    @Override
    public Long getDbId() {
        return id;
    }

    @Override
    public String getGUID() {
        return "Marry#" + this.id;
    }

    @Override
    public boolean isInDb() {
        return this.isInDb;
    }

    @Override
    public void setInDb(boolean inDb) {
        this.isInDb = inDb;
    }

    @Override
    public long getCharId() {
        return this.charId;
    }


    public MarryCorrelationInfo getMarryCorrelationInfo() {

        return marryProps;
    }


    private void setMarryProps(String marryProps) {
        this.getMarryCorrelationInfo().initFromJson(marryProps);
    }

    public int getDeleted() {
        return deleted;
    }

    public void setDeleted(int deleted) {
        this.deleted = deleted;
    }

    @Override
    public MarryEntity toEntity() {
        MarryEntity entity = new MarryEntity();
        entity.setId(this.id);
        entity.setCharId(this.charId);
        entity.setMarryProps(this.getMarryCorrelationInfo().toJson());
        return entity;
    }

    @Override
    public void fromEntity(MarryEntity entity) {
        this.setDbId(entity.getId());
        this.setCharId(entity.getCharId());
        this.setMarryProps(entity.getMarryProps());
        setInDb(true);
        activate();
    }

    public void setCharId(Long charId) {
        this.charId = charId;
    }

    @Override
    public LifeCycle getLifeCycle() {
        return this.lifeCycle;
    }

    @Override
    public void setModified() {
        if (this.lifeCycle.isActive()) {
            Globals.getSceneService().getCommonScene().getCommonDataUpdater().addUpdate(lifeCycle);
        }
    }

    /**
     * 激活
     */
    public void activate() {
        this.lifeCycle.activate();
    }

    public void Delete() {
        onDelete();
    }

    /**
     * 删除
     */
    public void onDelete() {
        this.lifeCycle.destroy();
        Globals.getSceneService().getCommonScene().getCommonDataUpdater().addDelete(lifeCycle);
    }

    public void addMarryInfo(long now) {
        this.marryProps.setCreateTime(now);
        this.marryProps.setFiretime(0);
        setModified();
    }

    public long getFiretime() {
        return this.marryProps.getFiretime();
    }

    public void fireMarryDelay() {
        this.getMarryCorrelationInfo().setFiretime(Globals.getTimeService().now() + FIRE_DELAY);
        setModified();
    }

    /**
     * 婚姻是否在cd中, true 没在cd中,false 在cd中
     * @return
     */
    public boolean isNormalMarry() {
        if (this.getMarryCorrelationInfo().getFiretime() > 0) {
            return false;
        } else {
            return true;
        }
    }


}
