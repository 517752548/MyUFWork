package com.imop.lj.gameserver.player.persistance;

import java.util.LinkedHashMap;
import java.util.Map;

import com.imop.lj.core.annotation.NotThreadSafe;
import com.imop.lj.core.object.LifeCycle;
import com.imop.lj.core.object.PersistanceObject;
import com.imop.lj.core.persistance.AbstractDataUpdater;
import com.imop.lj.gameserver.common.db.POUpdater;
import com.imop.lj.gameserver.corpstask.CorpsTask;
import com.imop.lj.gameserver.corpstask.persistance.CorpsTaskUpdater;
import com.imop.lj.gameserver.day7target.Day7Task;
import com.imop.lj.gameserver.day7target.persistance.Day7TaskUpdater;
import com.imop.lj.gameserver.foragetask.ForageTask;
import com.imop.lj.gameserver.foragetask.persistance.ForageTaskUpdater;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.human.HumanUpdater;
import com.imop.lj.gameserver.item.Item;
import com.imop.lj.gameserver.item.ItemUpdater;
import com.imop.lj.gameserver.mail.MailInstance;
import com.imop.lj.gameserver.mail.MailUpdater;
import com.imop.lj.gameserver.offlinereward.OfflineReward;
import com.imop.lj.gameserver.offlinereward.OfflineRewardUpdater;
import com.imop.lj.gameserver.pet.PetFriend;
import com.imop.lj.gameserver.pet.PetHorse;
import com.imop.lj.gameserver.pet.PetLeader;
import com.imop.lj.gameserver.pet.PetPet;
import com.imop.lj.gameserver.pet.PetUpdater;
import com.imop.lj.gameserver.pubtask.PubTask;
import com.imop.lj.gameserver.pubtask.persistance.PubTaskUpdater;
import com.imop.lj.gameserver.quest.CommonTask;
import com.imop.lj.gameserver.quest.persistance.CommonTaskUpdater;
import com.imop.lj.gameserver.relation.Relation;
import com.imop.lj.gameserver.relation.RelationUpdater;
import com.imop.lj.gameserver.siegedemontask.SiegeDemonTask;
import com.imop.lj.gameserver.siegedemontask.persistance.SiegeDemonTaskUpdater;
import com.imop.lj.gameserver.thesweeneytask.TheSweeneyTask;
import com.imop.lj.gameserver.thesweeneytask.persistance.TheSweeneyTaskUpdater;
import com.imop.lj.gameserver.timelimit.monster.TimeLimitMonster;
import com.imop.lj.gameserver.timelimit.npc.TimeLimitNpc;
import com.imop.lj.gameserver.timelimit.persistance.TimeLimitMonsterUpdater;
import com.imop.lj.gameserver.timelimit.persistance.TimeLimitNpcUpdater;
import com.imop.lj.gameserver.treasuremap.TreasureMap;
import com.imop.lj.gameserver.treasuremap.persistance.TreasureMapUpdater;
import com.imop.lj.gameserver.wing.Wing;
import com.imop.lj.gameserver.wing.persistance.WingUpdater;

/**
 *
 * Player数据更新接口
 *
 *
 */
@NotThreadSafe
public class PlayerDataUpdater extends AbstractDataUpdater{

	private static Map<Class<? extends PersistanceObject<?, ?>>, POUpdater> operationDbMap = new LinkedHashMap<Class<? extends PersistanceObject<?, ?>>, POUpdater>();

	static {
		operationDbMap.put(Human.class, new HumanUpdater());
		operationDbMap.put(MailInstance.class, new MailUpdater());	
		operationDbMap.put(PetLeader.class, new PetUpdater());
		operationDbMap.put(PetPet.class, new PetUpdater());
		operationDbMap.put(PetFriend.class, new PetUpdater());
		operationDbMap.put(PetHorse.class, new PetUpdater());
		operationDbMap.put(Item.class, new ItemUpdater());
		operationDbMap.put(CommonTask.class, new CommonTaskUpdater());
		operationDbMap.put(Relation.class, new RelationUpdater());
		operationDbMap.put(OfflineReward.class, new OfflineRewardUpdater());
		operationDbMap.put(PubTask.class, new PubTaskUpdater());
		operationDbMap.put(TheSweeneyTask.class, new TheSweeneyTaskUpdater());
		operationDbMap.put(TreasureMap.class, new TreasureMapUpdater());
        operationDbMap.put(ForageTask.class, new ForageTaskUpdater());
        operationDbMap.put(Wing.class, new WingUpdater());
        operationDbMap.put(CorpsTask.class, new CorpsTaskUpdater());
        operationDbMap.put(TimeLimitMonster.class, new TimeLimitMonsterUpdater());
        operationDbMap.put(TimeLimitNpc.class, new TimeLimitNpcUpdater());
        operationDbMap.put(Day7Task.class, new Day7TaskUpdater());
        operationDbMap.put(SiegeDemonTask.class, new SiegeDemonTaskUpdater());

		
	}

	public PlayerDataUpdater() {
		super();
	}


	@Override
	protected void doUpdate(LifeCycle lc) {
		if (!lc.isActive()) {
			throw new IllegalStateException(
					"Only the live object can be updated.");

		}
		PersistanceObject<?, ?> po = lc.getPO();
		POUpdater poUpdater = operationDbMap.get(po.getClass());
		poUpdater.save(po);
	}

	@Override
	protected void doDel(LifeCycle lc) {
		if (!lc.isDestroyed()) {
			throw new IllegalStateException(
					"Only the destroyed object can be deleted.");
		}
		PersistanceObject<?, ?> po = lc.getPO();
		operationDbMap.get(po.getClass()).delete(po);
	}
}
