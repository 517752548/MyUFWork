package com.imop.lj.gameserver.title;

import java.text.MessageFormat;
import java.util.Collection;
import java.util.HashSet;
import java.util.Map;
import java.util.Set;

import com.google.common.collect.Maps;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.core.object.LifeCycle;
import com.imop.lj.core.object.LifeCycleImpl;
import com.imop.lj.core.object.PersistanceObject;
import com.imop.lj.db.model.TitleEntity;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.title.template.TitleTemplate;

import net.sf.json.JSONArray;
import net.sf.json.JSONObject;

/**
 * Created by zhangzhe on 15/12/16.
 */
public class Title implements PersistanceObject<Long, TitleEntity> {

    public final static int NOT_DIS_TITLE = 0;
    public final static int DIS_TITLE = 1;
    public final static int NOT_TITLE = 0;
    /**
     * 用户的uuid
     */
    private long UUID;

    /**
     * 道具模板
     */
    private int inUseTplid;

    private Map<Integer, TitleInfo> titleInfoList;
    /**
     * 此实例是否在db中
     */
    private boolean isInDb;

    /**
     * 物品的生命期的状态
     */
    private final LifeCycle lifeCycle;

    private int disTitle;

    /**
     * 是否已经变更了
     */
    private boolean modified;

    public Title(long charId) {
        super();
        this.UUID = charId;
        this.inUseTplid = NOT_TITLE;
        lifeCycle = new LifeCycleImpl(this);
        titleInfoList = Maps.newHashMap();
        active();
    }

    public boolean addTitleInfo(int tplid) {
        if (titleInfoList.containsKey(tplid)) {
            updateTitleInfo(tplid, titleInfoList.get(tplid),true);
        } else {
            createTitleInfo(tplid);
        }
        return true;

    }

    private void createTitleInfo(int tplid) {
        TitleInfo tinfo = new TitleInfo(tplid);
        tinfo.setTitleName(this.getDisTitleName(tplid));
        this.titleInfoList.put(tplid, tinfo);
        if(tinfo.getTitleEndTime()>0){
            Globals.getTitleService().addNeedCheck(this.UUID);
        }
        setModified();
    }

    private void updateTitleInfo(int tplid,TitleInfo tinfo,boolean updateTitleName) {
        if (tinfo == null) {
            return;
        }
        TitleTemplate template = Globals.getTemplateCacheService().get(tplid, TitleTemplate.class);
        if(updateTitleName) {
            tinfo.setTitleName(this.getDisTitleName(tplid));
        }
        if (template.getDeadtime() > 0) {
            tinfo.setTitleEndTime(tinfo.getTitleEndTime() + template.getDeadtime());
        }
    }

    @Override
    public void setDbId(Long id) {
        this.UUID = id;

    }

    @Override
    public Long getDbId() {
        return UUID;
    }

    @Override
    public String getGUID() {
        return "title#" + this.UUID;
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
        return this.UUID;
    }


    @Override
    public TitleEntity toEntity() {
        TitleEntity entity = new TitleEntity();
        entity.setId(this.getDbId());
        entity.setInUseTplid(this.inUseTplid);
        entity.setTitleInfoProps(titleInfoListToString());
        entity.setDisTitle(this.disTitle);
        return entity;
    }

    private String titleInfoListToString() {
        JSONArray jsarray = new JSONArray();
        Collection<TitleInfo> tlist = titleInfoList.values();
        for(TitleInfo t :tlist){
            jsarray.add(t.toJson());
        }
        return jsarray.toString();
    }

    @Override
    public void fromEntity(TitleEntity entity) {
        this.UUID = entity.getId();
        this.inUseTplid = entity.getInUseTplid();
        toTitleInfoList(entity.getTitleInfoProps());
        this.disTitle = entity.getDisTitle();
        setInDb(true);
        active();

    }

    private void toTitleInfoList(String titleInfoProps) {

        JSONArray or = JSONArray.fromObject(titleInfoProps);
        for (int i = 0; i < or.size(); i++) {
            JSONObject jsobject = or.getJSONObject(i);
            TitleInfo t = new TitleInfo();
            t.fromJson(jsobject);
            titleInfoList.put(t.getTemplateId(), t);
            if(t.getTitleEndTime()>0){
                Globals.getTitleService().addNeedCheck(UUID);
            }
        }
    }

    @Override
    public LifeCycle getLifeCycle() {
        return lifeCycle;
    }

    @Override
    public void setModified() {
        if (this.lifeCycle != null) {
            modified = true;
            // 为了防止发生一些错误的使用状况,暂时把此处的检查限制得很严格
            this.lifeCycle.checkModifiable();
            if (this.lifeCycle.isActive()) {
                // 物品的生命期处于活动状态,并且该物品不是空的,则执行通知更新机制进行
                this.onUpdate();
            }
        }
    }

    public static boolean isEmpty(Title title) {
        return title == null;
    }

    /**
     * 物品实例被修改(新增加或者属性更新)时调用,触发更新机制
     */
    private void onUpdate() {
        if (Loggers.titleLogger.isDebugEnabled()) {
            Loggers.titleLogger.debug(String.format("update title=%s id=%s ", this.toString(), this.UUID));
        }
        Globals.getSceneService().getCommonScene().getCommonDataUpdater().addUpdate(lifeCycle);
    }

    public void active() {
        getLifeCycle().activate();
    }

    /**
     * 删除信息
     */
    public void delete() {

        onDelete();
    }

    /**
     * 实例被删除,触发删除机制
     */
    protected void onDelete() {
        this.lifeCycle.destroy();
        Globals.getSceneService().getCommonScene().getCommonDataUpdater().addDelete(this.lifeCycle);
    }

    public Map<Integer, TitleInfo> getAllTitleInfo() {
        return this.titleInfoList;
    }

    public TitleInfo getTitleInfo(Integer tplid) {
        if (!this.titleInfoList.containsKey(tplid)) {
            return null;
        }
        return this.titleInfoList.get(tplid);
    }

    public int getDisTitle() {
        return disTitle;
    }

    public void setDisTitle(int disTitle) {
        this.disTitle = disTitle;
        setModified();
    }

    public long getUUID() {
        return UUID;
    }

    public void setUUID(long UUID) {
        this.UUID = UUID;
    }

    public int getInUseTplid() {
        return inUseTplid;
    }

    public void setInUseTplid(int inUseTplid) {
        this.inUseTplid = inUseTplid;
        setModified();
    }

    public boolean canUseTitle(int tplid) {
        if (!titleInfoList.containsKey(tplid)) {
            return false;
        }
        TitleInfo titleinfo = titleInfoList.get(tplid);
        if (titleinfo.getTitleEndTime() == 0 || Globals.getTimeService().now() < titleinfo.getTitleEndTime()) {
            return true;
        }
        return false;
    }

    public String getDisTitleName(int tplid) {
        String distitlename = "";

        TitleTemplate template = Globals.getTemplateCacheService().get(tplid, TitleTemplate.class);
        if (template == null) {
        	 if (Loggers.titleLogger.isDebugEnabled()) {
                 Loggers.titleLogger.error("Get TitleTemplate is null!tplId = "+ tplid);
             }
            return distitlename;
        }
        TitleDef.TitleTemplateType titletemplae = TitleDef.TitleTemplateType.indexOf(template.getId());
        if(titletemplae == null){
        	if (Loggers.titleLogger.isDebugEnabled()) {
        		Loggers.titleLogger.error("TitleDef.TitleTemplateType.indexOf is null!title index = "+ template.getId());
        	}
        	 return distitlename;
        }
        switch (titletemplae) {
            case CORPS_PRESIDENT:
            case CORPS_VICE_CHAIRMAN:
            case CORPS_ELITE:
            case CORPS_MEMBER:
                distitlename = MessageFormat.format(template.getDescname(), Globals.getCorpsService().getCorpsNameByHumanId(this.UUID));
                break;
            case OVERMAN_LOWERMAN:
                distitlename = MessageFormat.format(template.getDescname(), Globals.getOvermanService().getOvermanName(this.UUID));
                break;
            case MARRY_HASBAND:
            case MARRY_WIFE:
                distitlename = MessageFormat.format(template.getDescname(), Globals.getMarryService().getSpouseName(this.UUID));
                break;
            default:
                distitlename = template.getDescname();
                break;
        }
        return distitlename;
    }

    public void removeTitleInfo(int tplid) {
        if(tplid==inUseTplid){
            Globals.getTitleService().emptyTitle(this.UUID);
        }
        if(this.titleInfoList.containsKey(tplid)){
            this.titleInfoList.remove(tplid);
            setModified();
        }
    }

    public void checkTitle() {
    	if (titleInfoList == null || titleInfoList.isEmpty()) {
    		return;
    	}
    	
    	Set<Integer> s = new HashSet<Integer>();
    	s.addAll(titleInfoList.keySet());
        for (Integer k : s) {
        	TitleInfo tinfo = titleInfoList.get(k);
        	if (tinfo == null) {
        		continue;
        	}
            if(tinfo.getTitleEndTime()>0 && Globals.getTimeService().now()>tinfo.getTitleEndTime()){
                removeTitleInfo(tinfo.getTemplateId());
            }
        }
    }
}
