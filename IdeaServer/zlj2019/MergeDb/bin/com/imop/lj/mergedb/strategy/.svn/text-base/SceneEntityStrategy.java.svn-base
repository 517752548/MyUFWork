package com.imop.lj.mergedb.strategy;

import java.text.MessageFormat;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import com.imop.lj.core.orm.BaseEntity;
import com.imop.lj.db.model.SceneEntity;
import com.imop.lj.mergedb.Globals;
import com.imop.lj.mergedb.log.Loggers;

/**
 * 场景信息合服策略
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public abstract class SceneEntityStrategy implements IStrategy {
	
	protected final static String TABLE_NAME = "t_scene_info";
	
	protected Map<java.lang.Long,SceneEntity> sceneEntityMap = new HashMap<java.lang.Long,SceneEntity>();

	@Override
	public void read(){
		Loggers.mergeDbLogger.info("read SceneEntity is starting...");
		long start = System.currentTimeMillis();
		List<SceneEntity> toSceneEntityList = Globals.getToDbDaoService().getMergeDao().queryAllSceneEntity();

		
		if (null == toSceneEntityList || toSceneEntityList.size() == 0) {
			String warnInfo = "To 表{0}的记录 为空";
			throw new com.imop.lj.mergedb.exception.MergeException(TABLE_NAME, "", MessageFormat.format(warnInfo, TABLE_NAME));
		} else {
			// 排重插入
			for (SceneEntity sceneEntity : toSceneEntityList) {
				addEntity(sceneEntity);
			}
		}

		long end = System.currentTimeMillis();
		String content = "任务：{0}:执行所需时间:{1}ms";
		Loggers.mergeDbLogger.info(MessageFormat.format(content, "read sceneEntity", end - start + ""));
		Loggers.mergeDbLogger.info("read sceneEntity is finished");
	}
	
	@Override
	@SuppressWarnings("rawtypes")
	public void save(){
		Loggers.mergeDbLogger.info("save sceneEntity is starting...");
		long start=System.currentTimeMillis();
		Loggers.mergeDbLogger.info(sceneEntityMap.size() + " sceneEntity need save!");
		int i=0;
		List<BaseEntity> sceneEntityList = new ArrayList<BaseEntity>();
		for(SceneEntity sceneEntity : sceneEntityMap.values()){
			i++;
			sceneEntityList.add(sceneEntity);
			if(i % Globals.getConfig().getInsertNumOnce() == 0){
				Globals.getNewDbDaoService().getMergeDao().saveAll(sceneEntityList);
				sceneEntityList = new ArrayList<BaseEntity>();
				Loggers.mergeDbLogger.info(i + " sceneEntity is saved");
			}
		}
		if(null != sceneEntityList && sceneEntityList.size() > 0){
			Globals.getNewDbDaoService().getMergeDao().saveAll(sceneEntityList);
			Loggers.mergeDbLogger.info(i + " sceneEntity is saved");
		}
		
		//清空map
		sceneEntityMap.clear();
		
		long end=System.currentTimeMillis();
		String content = "任务：{0}:执行所需时间:{1}ms";
		Loggers.mergeDbLogger.info(MessageFormat.format(content,"save sceneEntity",end-start+""));
		Loggers.mergeDbLogger.info("save sceneEntity is finished");
	}
	
	@Override
	public void delete(){
		Loggers.mergeDbLogger.info("delete sceneEntity is starting...");
		long start=System.currentTimeMillis();
		Globals.getNewDbDaoService().getMergeDao().delAllSceneEntity();
		long end=System.currentTimeMillis();
		String content = "任务：{0}:执行所需时间:{1}ms";
		Loggers.mergeDbLogger.info(MessageFormat.format(content,"delete sceneEntity",end-start+""));
		Loggers.mergeDbLogger.info("delete sceneEntity is finished");
	}
	
	protected void addEntity(SceneEntity sceneEntity) {
		sceneEntityMap.put(sceneEntity.getId(), sceneEntity);
	}
	

}
