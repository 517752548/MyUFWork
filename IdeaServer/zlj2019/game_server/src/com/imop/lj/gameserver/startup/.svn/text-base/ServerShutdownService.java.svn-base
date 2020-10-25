package com.imop.lj.gameserver.startup;

import java.io.Serializable;
import java.util.Collection;
import java.util.List;
import java.util.Map;

import com.imop.lj.common.constants.Loggers;
import com.imop.lj.core.object.LifeCycle;
import com.imop.lj.core.object.PersistanceObject;
import com.imop.lj.core.orm.BaseEntity;
import com.imop.lj.core.persistance.AbstractSceneDataUpdater;
import com.imop.lj.core.persistance.DataUpdater.UpdateEntry;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.player.OnlinePlayerService;
import com.imop.lj.gameserver.player.Player;
import com.imop.lj.gameserver.player.PlayerConstants;
import com.imop.lj.gameserver.player.async.SavePlayerRoleOperation;
import com.imop.lj.gameserver.player.persistance.PlayerDataUpdater;
import com.imop.lj.gameserver.scene.Scene;

/**
 *
 * gameserver关闭时的一些逻辑处理
 *
 *
 */
public class ServerShutdownService {

	/**
	 * 同步的将所有在线玩家的PlayerDataUpdater中所有待更新的数据全部同步更新一遍<br/>
	 * 此操作在关闭SceneTaskScheduler之后做，保证所有场景已经停止tick
	 */
	public void synSaveAllPlayerOnShutdown() {
		OnlinePlayerService olPlayerService = Globals.getOnlinePlayerService();
		synSavePlayerDataUpdater(olPlayerService);
		synSavePlayerBaseData(olPlayerService);
		
		// 保存场景数据
		synSaveSceneDataUpdater();
	}

	/**
	 * 同步保存每一个在线玩家的PlayerDataUpdater中的所有尚未保存数据
	 */
	private void synSavePlayerDataUpdater(OnlinePlayerService olPlayerService) {
		// 同步保存每一个在线玩家的PlayerDataUpdater中的所有为保存数据
		System.out.println("#synSavePlayerDataUpdater#");
		
		Collection<Long> allOnlines = olPlayerService
				.getAllOnlinePlayerRoleUUIDs();
		
		System.out.println("#synSavePlayerDataUpdater#allOnlines.size="+allOnlines.size());
		
		for (Long roleUUID : allOnlines) {
			Player player = Globals.getOnlinePlayerService().getPlayer(
					roleUUID);
			if (player == null) {
				
				System.out.println("#synSavePlayerDataUpdater#player is null!roleUUID="+roleUUID);
				
				continue;
			}
			
			System.out.println("#synSavePlayerDataUpdater#roleUUID="+roleUUID);
			
			PlayerDataUpdater updater = player.getDataUpdater();
			Map<Object, UpdateEntry> changedMap = updater.getChangedObjects();
			if (changedMap.isEmpty()) {
				
				System.out.println("#synSavePlayerDataUpdater#changedMap is empty="+roleUUID);
				
				continue;
			}
			
			System.out.println("#synSavePlayerDataUpdater#changedMap size="+changedMap.size()+"="+roleUUID);
			
			for (UpdateEntry entry : changedMap.values()) {
				LifeCycle lc = entry.obj;
				try {
					if (entry.operation == UpdateEntry.OPER_UPDATE) {
						// 执行更新操作
						synUpdateOrSave(lc.getPO());
					} else if (entry.operation == UpdateEntry.OPER_DEL) {
						// 执行删除操作
						synDelete(lc.getPO());
					}
				} catch (Exception e) {
					Loggers.gameLogger.error(
							"exception occur when server shutdown", e);
				}
			}
		}
	}

	private static enum Oper {
		save {
			@Override
			public <I extends Serializable, T extends BaseEntity<I>> void execute(
					PersistanceObject<I, T> po) {
//				dao.save(po.toEntity());
				Globals.getDaoService().getDBService().save(po.toEntity());
			}
		},
		update {
			@Override
			public <I extends Serializable, T extends BaseEntity<I>> void execute(
					PersistanceObject<I, T> po) {
//				dao.update(po.toEntity());
				Globals.getDaoService().getDBService().update(po.toEntity());
			}
		},
		delete {
			@Override
			public <I extends Serializable, T extends BaseEntity<I>> void execute(
					PersistanceObject<I, T> po) {
//				dao.delete(po.toEntity());
				Globals.getDaoService().getDBService().delete(po.toEntity());
			}
		};

		public abstract <I extends Serializable, T extends BaseEntity<I>> void execute(
				PersistanceObject<I, T> po);
	}


	private void synUpdateOrSave(PersistanceObject<?,?>  po) {
		boolean save = !(po.isInDb());
		if (save) {
			doOperByType(po, Oper.save);
		} else {
			doOperByType(po, Oper.update);
		}
	}

	private void synDelete(PersistanceObject<?,?> po) {
		doOperByType(po, Oper.delete);
	}

	private void doOperByType(PersistanceObject<?,?> po, Oper oper) {
		System.out.println("#ServerShutdownService#doOperByType#start.oper="+oper);
		
		if (po != null) {
			oper.execute(po);
		} else {
			Loggers.gameLogger.error("po is null! on server shutdown!");
		}
		
		System.out.println("#ServerShutdownService#doOperByType#end.oper="+oper);
	}

	/**
	 * 关服时同步保存每一个在线玩家的基本数据，即HumanEntity中的数据
	 */
	private void synSavePlayerBaseData(OnlinePlayerService olPlayerService) {
		Collection<Long> allOnlines = olPlayerService
				.getAllOnlinePlayerRoleUUIDs();
		for (Long roleUUID : allOnlines) {
			Player player = Globals.getOnlinePlayerService()
					.getPlayer(roleUUID);
			SavePlayerRoleOperation operation = new SavePlayerRoleOperation(
					player, PlayerConstants.CHARACTER_INFO_MASK_BASE, true);
			operation.doStart();
			operation.doIo();
		}
	}
	
	private void synSaveSceneDataUpdater() {
		System.out.println("#synSaveSceneDataUpdater#start");
		List<Scene> sceneList = Globals.getSceneService().getAllScenes();
		for (Scene scene : sceneList) {
			AbstractSceneDataUpdater updater = scene.getSceneDataUpdater();
			if (updater == null) {
				System.out.println("#synSaveSceneDataUpdater#updater is null.scene="+scene.getClass().getSimpleName());
				continue;
			}
			Map<Object, UpdateEntry> changedMap = updater.getChangedObjects();
			if (changedMap.isEmpty()) {
				System.out.println("#synSaveSceneDataUpdater#changedMap is empty.scene="+scene.getClass().getSimpleName());
				continue;
			}
			
			System.out.println("#synSaveSceneDataUpdater#changedMap size="+changedMap.size()+".scene="+scene.getClass().getSimpleName());
			
			for (UpdateEntry entry : changedMap.values()) {
				LifeCycle lc = entry.obj;
				try {
					if (entry.operation == UpdateEntry.OPER_UPDATE) {
						// 执行更新操作
						synUpdateOrSave(lc.getPO());
					} else if (entry.operation == UpdateEntry.OPER_DEL) {
						// 执行删除操作
						synDelete(lc.getPO());
					}
				} catch (Exception e) {
					Loggers.gameLogger.error(
							"exception occur when server shutdown", e);
				}
			}
		}
		System.out.println("#synSaveSceneDataUpdater#end");
	}
}
