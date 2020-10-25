package com.imop.lj.gameserver.battle.helper;

import java.util.ArrayList;
import java.util.Collection;
import java.util.Collections;
import java.util.Iterator;
import java.util.List;
import java.util.Map;

import org.slf4j.Logger;

import com.google.common.collect.Maps;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.core.util.RandomUtil;
import com.imop.lj.gameserver.battle.core.Action;
import com.imop.lj.gameserver.battle.core.BattleDef;
import com.imop.lj.gameserver.battle.core.BattleDef.EffectType;
import com.imop.lj.gameserver.battle.core.BattleDef.RangeType;
import com.imop.lj.gameserver.battle.core.BattleDef.TargetType;
import com.imop.lj.gameserver.battle.core.FightUnit;
import com.imop.lj.gameserver.battle.effect.IEffect;
import com.imop.lj.gameserver.skill.template.SkillEffectTemplate;

/**
 * 寻找目标工具类
 *
 */
public abstract class TargetHelper {
	public static final Logger logger = Loggers.battleLogger;
	
	public static final Map<Integer, int[]> CrossPosMap = Maps.newHashMap();
	static {
		/**
		 * 9 7 6 8 10
		 * 4 2 1 3 5
		 **/
		CrossPosMap.put(1, new int[]{1,2,3,6});
		CrossPosMap.put(2, new int[]{1,2,4,7});
		CrossPosMap.put(3, new int[]{1,3,5,8});
		CrossPosMap.put(4, new int[]{2,4,9});
		CrossPosMap.put(5, new int[]{3,5,10});
		CrossPosMap.put(6, new int[]{1,6,7,8});
		CrossPosMap.put(7, new int[]{2,6,7,9});
		CrossPosMap.put(8, new int[]{3,6,8,10});
		CrossPosMap.put(9, new int[]{4,7,9});
		CrossPosMap.put(10, new int[]{5,8,10});
	}

	public static List<String> toReport(List<FightUnit> targets) {
		List<String> result = new ArrayList<String>();
		Iterator<FightUnit> it = targets.iterator();
		for (; it.hasNext(); ) {
			result.add(((FightUnit) it.next()).getIdentifier());
		}
		return result;
	}

	public static boolean targetNotFound(Action action, IEffect effect) {
		if ((action.getTargets(effect) == null) || (action.getTargets(effect).isEmpty())) {
			return true;
		}
		return false;
	}
	
	public static void selectTargetOnChaos(Action action, IEffect effect) {
		List<FightUnit> fuCol = new ArrayList<FightUnit>();
		fuCol.addAll(action.getEnemies());
		fuCol.addAll(action.getFriends());
		//剔除自己
		fuCol.remove(action.getOwner());
		if (!fuCol.isEmpty()) {
			List<FightUnit> targets = new ArrayList<FightUnit>();
			//从所有战斗单元中随机一个
			int randIndex = RandomUtil.nextEntireInt(0, fuCol.size() - 1);
			targets.add(fuCol.get(randIndex));
			//设置目标
			action.setTargets(effect, targets);
		} else {
			Loggers.battleLogger.error("selectTargetOnChaos ERROR!fuCol is empty!effect=" + effect.getId() + ";action=" + action);
		}
	}

	/**
	 * 选择目标
	 * @param action
	 * @param effect
	 * @param effectTpl
	 */
	public static void selectTargets(Action action, IEffect effect, SkillEffectTemplate effectTpl, int targetNum) {
		List<FightUnit> targets = findTargets(action, effectTpl.isTargetSelf(), effectTpl.isTargetSelect(),
				effectTpl.getTargetType(), effectTpl.getRangeType(), effectTpl.getEffectType(), targetNum);
		if (targets != null && !targets.isEmpty()) {
			action.setTargets(effect, targets);
		} else {
			Loggers.battleLogger.error("selectTargets ERROR!target is null or empty!effect=" + effect.getId() + ";action=" + action);
		}
	}

	private static List<FightUnit> findTargets(Action action, boolean isTargetSelf, boolean isTargetSelect,
			TargetType targetType, RangeType rangType, EffectType effectType, int targetNum) {
		//如果不是效果本身的目标，则取主效果的目标
		if (!isTargetSelf) {
			return action.getMainTarget();
		}
		
		List<FightUnit> result = new ArrayList<FightUnit>();
		FightUnit owner = action.getOwner();
		
		//获取玩家选取的目标
		int targetPos = 0;
		if (isTargetSelect && owner.getSelTarget() > 0) {
			//玩家选择了目标，使用此目标
			targetPos = owner.getSelTarget();
		}
		
		switch (targetType) {
		case ENEMY:
			if (targetPos != 0) {
				targetPos -= BattleDef.POS_ADD;
				if (targetPos < 0) {
					targetPos = 0;
					Loggers.battleLogger.error("targetPos is less than 0!owner=" + owner.getIdentifier());
				}
			}
			result.addAll(getTargetOfCollection(true, action, targetPos, rangType, effectType, targetNum, true, false, false));
			break;
		case OUR:
			result.addAll(getTargetOfCollection(false, action, targetPos, rangType, effectType, targetNum, true, false, false));
			break;
		case MYSELF:
			result.add(owner);
			break;
		case LEADER:
		case PET:
			break;
		//捕捉宠物
		case ENEMY_CAN_CATCH:
			FightUnit canCatchPet = getEnemyCanCatch(action);
			if (canCatchPet != null) {
				result.add(canCatchPet);
			}
			break;
		//我方已死亡的
		case OUR_DEAD:
			result.addAll(getTargetOfCollection(false, action, targetPos, rangType, effectType, targetNum, false, false, false));
			break;
		//我方全部，包含已死亡的
		case OUR_ALL:
			result.addAll(getTargetOfCollection(false, action, targetPos, rangType, effectType, targetNum, false, true, false));
			break;
		//所有属于我的单位
		case MY_OWN_ALL:
			result.addAll(getMyOwnAllFus(action));
			break;
		//己方宠物
		case MY_OWN_PET:
			result.addAll(getTargetOfCollection(false, action, targetPos, rangType, effectType, targetNum, true, false, true));
			break;
		//敌方宠物
		case ENEMY_PET:
			result.addAll(getTargetOfCollection(true, action, targetPos, rangType, effectType, targetNum, true, false, true));
			break;
		//全体活的单位
		case ALL_NOT_DEAD:
			if(targetPos > BattleDef.POS_ADD){
				result.addAll(getTargetOfCollection(true, action, targetPos, rangType, effectType, targetNum, true, false));
			}else{
				result.addAll(getTargetOfCollection(false, action, targetPos, rangType, effectType, targetNum, true, false));
			}
			break;
		default:
			break;
		}

		return result;
	}
	
	/**
	 * 获取所有属于action owner的所有战斗单位，含死亡的
	 * @param action
	 * @return
	 */
	private static List<FightUnit> getMyOwnAllFus(Action action) {
		List<FightUnit> fuCol = new ArrayList<FightUnit>();
		long ownerId = action.getOwner().getOwnerId();
		for (FightUnit fu : action.getFriends()) {
			if (fu.getOwnerId() == ownerId) {
				fuCol.add(fu);
			}
		}
		for (FightUnit fu : action.getDeadFriends()) {
			if (fu.getOwnerId() == ownerId) {
				fuCol.add(fu);
			}
		}
		return fuCol;
	}
	
	private static FightUnit getEnemyCanCatch(Action action) {
		Collection<FightUnit> col = action.getEnemies();
		for (FightUnit f : col) {
			if (f.canBeCaught()) {
				//每个敌人组中只有一个，所以找到就返回
				return f;
			}
		}
		return null;
	}
	
	/**
	 * 获取目标集合
	 * @param isEnemy
	 * @param action
	 * @param targetPos
	 * @param rangType
	 * @param targetNum
	 * @param isLive
	 * @param isAll true则包含或者和死亡的人
	 * @param isPet 是否是宠物
	 * @return
	 */
	private static List<FightUnit> getTargetOfCollection(boolean isEnemy, Action action, 
			int targetPos, RangeType rangType, EffectType effectType, int targetNum, boolean isLive, boolean isAll, boolean isPet) {
		List<FightUnit> result = new ArrayList<FightUnit>();
		
		//根据需要取不同的集合，会有死亡的集合
		List<FightUnit> fuCol = new ArrayList<FightUnit>();
		if (isAll) {
			fuCol.addAll(isEnemy ? action.getEnemies() : action.getFriends());
			fuCol.addAll(isEnemy ? action.getDeadEnemies() : action.getDeadFriends());
		} else {
			if (isLive) {
				fuCol.addAll(isEnemy ? action.getEnemies() : action.getFriends());
			} else {
				fuCol.addAll(isEnemy ? action.getDeadEnemies() : action.getDeadFriends());
			}
		}
		
		//需要过滤掉【被击飞】【被捕捉】【逃跑】的对象，这样的对象不能对其操作
		Iterator<FightUnit> it = fuCol.iterator();
		while(it.hasNext()) {
			FightUnit f = it.next();
			if (!f.canOp()) {
				it.remove();
			}
		}
		
		//只需要得到宠物战斗对象
		if (isPet) {
			Iterator<FightUnit> itPet = fuCol.iterator();
			while (itPet.hasNext()) {
				FightUnit f = itPet.next();
				if (!f.isPet()) {
					itPet.remove();
				}
			} 
		}
		
		switch (rangType) {
		case RANDOM:
			if (fuCol.size() <= targetNum) {
				//数量不足targetNum个，直接返回全部
				result.addAll(fuCol);
			} else {
				//容错处理
				if (targetNum < 1) {
					targetNum = 1;
					Loggers.battleLogger.error("targetNum less than 1!");
				}
				//随机选取targetNum个人
				List<FightUnit> tmpList = new ArrayList<FightUnit>();
				if (targetPos > 0) {
					for (FightUnit fu : fuCol) {
						if (fu.getPosition() == targetPos) {
							//指定了位置的敌人
							result.add(fu);
							//排除已经选择的人
							targetNum -= 1;
						} else {
							tmpList.add(fu);
						}
					}
				} else {
					tmpList.addAll(fuCol);
				}
				if (targetNum > 0) {
					result.addAll(RandomUtils.hitObjects(tmpList, targetNum));
				}
			}
			break;
		case ONE:
			FightUnit t = null;
			
			List<FightUnit> fuList = new ArrayList<FightUnit>(fuCol);
			if (targetPos > 0) {
				//指定了位置
				t = getTargetByPos(fuCol, targetPos);
			}
			//没选到，则随机（禁止随机的除外）
			if (t == null && !isForbidRandTarget(effectType)) {
				if (fuList.size() == 1) {
					t = fuList.get(0);
				} else {
					List<FightUnit> rnd = RandomUtils.hitObjects(fuList, 1);
					if (rnd != null && rnd.size() == 1) {
						t = rnd.get(0);
					}
				}
			}
			if (t != null) {
				result.add(t);
			}
			break;
		case ALL:
			result.addAll(fuCol);
			break;
		case CROSS:
			if (targetPos <= 0) {
				//没选则随机一个
				FightUnit centerFu = fuCol.get(RandomUtil.nextEntireInt(0, fuCol.size() - 1));
				targetPos = centerFu.getPosition();
			}
			int[] posArr = CrossPosMap.get(targetPos);
			for (int i = 0; i < posArr.length; i++) {
				FightUnit tu = getTargetByPos(fuCol, posArr[i]);
				if (tu != null) {
					result.add(tu);
				}
			}
			break;
			
		default:
			break;
		}
		
		return result;
	}
	
	/**
	 * 获取目标集合
	 * @param isEnemy
	 * @param action
	 * @param targetPos
	 * @param rangType
	 * @param targetNum
	 * @param isLive
	 * @param isAll true则包含或者和死亡的人
	 * @return
	 */
	private static List<FightUnit> getTargetOfCollection(boolean isEnemy, 
			Action action, int targetPos, RangeType rangType, EffectType effectType, int targetNum, boolean isLive, boolean isAll) {
		List<FightUnit> result = new ArrayList<FightUnit>();
		
		//根据需要取不同的集合，会有死亡的集合
		List<FightUnit> fuCol = new ArrayList<FightUnit>();
		if (isAll) {
			fuCol.addAll(isEnemy ? action.getEnemies() : action.getFriends());
			fuCol.addAll(isEnemy ? action.getDeadEnemies() : action.getDeadFriends());
		} else {
			if (isLive) {
				fuCol.addAll(isEnemy ? action.getEnemies() : action.getFriends());
			} else {
				fuCol.addAll(isEnemy ? action.getDeadEnemies() : action.getDeadFriends());
			}
		}
		
		//需要过滤掉【被击飞】【被捕捉】【逃跑】的对象，这样的对象不能对其操作
		Iterator<FightUnit> it = fuCol.iterator();
		while(it.hasNext()) {
			FightUnit f = it.next();
			if (!f.canOp()) {
				it.remove();
			}
		}
		
		switch (rangType) {
		case RANDOM:
			if (fuCol.size() <= targetNum) {
				//数量不足targetNum个，直接返回全部
				result.addAll(fuCol);
			} else {
				//容错处理
				if (targetNum < 1) {
					targetNum = 1;
					Loggers.battleLogger.error("targetNum less than 1!");
				}
				//随机选取targetNum个人
				List<FightUnit> tmpList = new ArrayList<FightUnit>();
				if (targetPos > 0) {
					for (FightUnit fu : fuCol) {
						if (fu.getPosition() == targetPos) {
							//指定了位置的敌人
							result.add(fu);
							//排除已经选择的人
							targetNum -= 1;
						} else {
							tmpList.add(fu);
						}
					}
				} else {
					tmpList.addAll(fuCol);
				}
				if (targetNum > 0) {
					result.addAll(RandomUtils.hitObjects(tmpList, targetNum));
				}
			}
			break;
		case ONE:
			FightUnit t = null;
			
			List<FightUnit> fuList = new ArrayList<FightUnit>(fuCol);
			if (targetPos > 0) {
				//指定了位置
				t = getTargetByPos(fuCol, targetPos);
			}
			//没选到，则随机（禁止随机的除外）
			if (t == null && !isForbidRandTarget(effectType)) {
				if (fuList.size() == 1) {
					t = fuList.get(0);
				} else {
					List<FightUnit> rnd = RandomUtils.hitObjects(fuList, 1);
					if (rnd != null && rnd.size() == 1) {
						t = rnd.get(0);
					}
				}
			}
			if (t != null) {
				result.add(t);
			}
			break;
		case ALL:
			result.addAll(fuCol);
			break;
		case CROSS:
			if (targetPos <= 0) {
				//没选则随机一个
				FightUnit centerFu = fuCol.get(RandomUtil.nextEntireInt(0, fuCol.size() - 1));
				targetPos = centerFu.getPosition();
			}
			int[] posArr = CrossPosMap.get(targetPos);
			for (int i = 0; i < posArr.length; i++) {
				FightUnit tu = getTargetByPos(fuCol, posArr[i]);
				if (tu != null) {
					result.add(tu);
				}
			}
			break;
			
		default:
			break;
		}
		
		return result;
	}
	
	private static boolean isForbidRandTarget(EffectType effectType) {
		//嗑药的目标不能随机
		if (effectType == EffectType.UseDrugs) {
			return true;
		}
		return false;
	}
	
	/**
	 * 根据战斗对象获得攻击对象
	 * 
	 * @param unit
	 * @return
	 */
	public static Collection<FightUnit> getEnemies(FightUnit unit, 
			Collection<FightUnit> attackers, Collection<FightUnit> defenders) {
		if (!attackers.isEmpty()) {
			for (FightUnit temp : attackers) {
				if (temp.isAttacker() == unit.isAttacker()) {
					return defenders;
				} else {
					break;
				}
			}
			return attackers;
		}
		if (!defenders.isEmpty()) {
			for (FightUnit temp : defenders) {
				if (temp.isAttacker() == unit.isAttacker()) {
					return attackers;
				} else {
					break;
				}
			}
			return defenders;
		}
		return Collections.emptyList();
	}

	/**
	 * 根据战斗对象获得友军对象
	 * 
	 * @param unit
	 * @return
	 */
	public static Collection<FightUnit> getFriends(FightUnit unit,
			Collection<FightUnit> attackers, Collection<FightUnit> defenders) {
		if (!attackers.isEmpty()) {
			for (FightUnit temp : attackers) {
				if (temp.isAttacker() == unit.isAttacker()) {
					return attackers;
				} else {
					break;
				}
			}
			return defenders;
		}
		if (!defenders.isEmpty()) {
			for (FightUnit temp : defenders) {
				if (temp.isAttacker() == unit.isAttacker()) {
					return defenders;
				} else {
					break;
				}
			}
			return attackers;
		}
		return Collections.emptyList();
	}

	/**
	 * 获取指定集合的某位置的战斗对象
	 * 
	 * @param unit
	 * @return
	 */
	public static FightUnit getTargetByPos(Collection<FightUnit> targetCol, int position) {
		for (FightUnit f : targetCol) {
			if (f.getPosition() == position) {
				return f;
			}
		}
		return null;
	}
	
}