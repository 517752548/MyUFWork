package com.imop.lj.gameserver.overman;

import com.google.common.collect.Lists;
import com.imop.lj.core.object.LifeCycle;
import com.imop.lj.core.object.LifeCycleImpl;
import com.imop.lj.core.object.PersistanceObject;
import com.imop.lj.db.model.OvermanEntity;
import com.imop.lj.gameserver.common.Globals;
import net.sf.json.JSONArray;

import java.util.List;

/**
 * Created by zhangzhe on 15/12/24.
 */
public class Overman implements PersistanceObject<Long, OvermanEntity> {

    private final static Integer HAD_GET_REWARD = 1; //已经领取的奖励
    private final static Integer NOT_HAD_GET_REWARD = 0; //没有领取奖励
    private final static int DELAY_DELETE_LOWERMAN = 79200000;
    /**
     * 生命期
     */
    private final LifeCycle lifeCycle;

    private Long id;


    /**
     * 此实例是否在db中
     */
    private boolean isInDb;

    private List<LowermanInfo> lowermanlist = Lists.newArrayList();

    public Overman() {
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
        return "Overman#" + this.id;
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
        return this.id;
    }

    @Override
    public OvermanEntity toEntity() {
        OvermanEntity entity = new OvermanEntity();
        entity.setId(this.id);
        entity.setOvermanProps(this.getOvermanProps());
        return entity;
    }

    private String getOvermanProps() {
        JSONArray array = new JSONArray();
        for (LowermanInfo l : this.getLowermans()) {
            array.add(l.toJson());
        }
        return array.toString();
    }

    @Override
    public void fromEntity(OvermanEntity entity) {
        this.setDbId(entity.getId());
        this.initOvermanList(entity.getOvermanProps());
        this.setInDb(true);

    }

    private void initOvermanList(String overmanProps) {
        JSONArray js = JSONArray.fromObject(overmanProps);
        for (int i = 0; i < js.size(); i++) {
            LowermanInfo l = new LowermanInfo();
            l.initFromJson(js.getString(i));
            this.lowermanlist.add(l);
        }
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

    public List<LowermanInfo> getLowermans() {

        return lowermanlist;
    }

    /**
     * 过滤已经删除的lowermans
     *
     * @return
     */
    public List<LowermanInfo> getNormalLowermans() {
        List<LowermanInfo> tlowerlist = Lists.newArrayList();
        for (LowermanInfo l : lowermanlist) {
            if (l.getDeleteTime() == 0) {
                tlowerlist.add(l);
            }
        }
        return tlowerlist;
    }

    public int getLowermenCount() {
        return lowermanlist.size();
    }


    public void addNewLowerman(Long lowermancharId) {
        LowermanInfo l = new LowermanInfo();
        l.setUuid(lowermancharId);
        l.setCreateTime(Globals.getTimeService().now());
        this.lowermanlist.add(l);
        setModified();
    }

    /**
     * @param lowermanCharId
     * @param checkforce     是否检查删除时间
     * @return
     */
    public boolean isLowerman(long lowermanCharId, boolean checkforce) {
        for (LowermanInfo l : this.lowermanlist) {

            if (l.getUuid() == lowermanCharId) {
                if (checkforce) {
                    if (l.getDeleteTime() == 0) {
                        return true;
                    }
                } else {
                    return true;
                }
            }
        }

    return false;

}

    public void fireLowerinfo(Long lowermamCharId) {
        int index = -1;
        for (int i = 0; i < this.lowermanlist.size(); i++) {
            if (lowermanlist.get(i).getUuid() == lowermamCharId) {
                index = i;
                break;
            }
        }
        if (index >= 0) {
            lowermanlist.remove(index);
        }
        setModified();

    }

    public LowermanInfo getLowermanInfo(long lowermancharId) {
        for (LowermanInfo l : this.lowermanlist) {
            if (l.getUuid() == lowermancharId) {
                return l;
            }
        }
        return null;
    }

    public Integer getOvermanRewardByLowermanIndex(long lowermancharId, Integer overtemplateid) {
        int hadget = NOT_HAD_GET_REWARD; // 0是没有使用的
        LowermanInfo l = this.getLowermanInfo(lowermancharId);
        List<OvermanDef.OVERMAN_REWARD> hadgetlist = l.getHadGetOvermanRewardList();
        for (OvermanDef.OVERMAN_REWARD r : hadgetlist) {
            if (r.getIndex() == overtemplateid)
                hadget = HAD_GET_REWARD;
        }
        return hadget;
    }

    /**
     * 增加师傅的奖励
     *
     * @param rewardId
     */
    public boolean addOvermanReward(long lowermanCharId, int rewardId) {
        LowermanInfo l = this.getLowermanInfo(lowermanCharId);
        if (l == null) {
            return false;
        }
        l.addOvermanReward(rewardId);
        this.setModified();
        return true;
    }

    public Integer getLowermanRewardByIndex(long lowermancharId, Integer overtemplateid) {
        int hadget = NOT_HAD_GET_REWARD; // 0是没有使用的
        LowermanInfo l = this.getLowermanInfo(lowermancharId);
        List<OvermanDef.OVERMAN_REWARD> hadgetlist = l.getHadGetLowermanRewardList();
        for (OvermanDef.OVERMAN_REWARD r : hadgetlist) {
            if (r.getIndex() == overtemplateid) {
                hadget = HAD_GET_REWARD;
                break;
            }
        }
        return hadget;
    }

    /**
     * 增加徒弟的奖励
     *
     * @param lowermancharId
     * @param rewardId
     */

    public boolean addLowermanReward(long lowermancharId, int rewardId) {
        LowermanInfo l = this.getLowermanInfo(lowermancharId);
        if (l == null) {
            return false;
        }
        l.addLowermanReward(rewardId);
        this.setModified();
        return true;
    }

    public void fireLowerinfodelayed(long lowermanCharId) {
        int index = -1;
        for (int i = 0; i < this.lowermanlist.size(); i++) {
            if (lowermanlist.get(i).getUuid() == lowermanCharId) {
                lowermanlist.get(i).setDeleteTime(Globals.getTimeService().now() + DELAY_DELETE_LOWERMAN);
                break;
            }
        }
        setModified();
    }
}
