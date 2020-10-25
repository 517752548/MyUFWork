package com.imop.lj.gameserver.rank;

import java.util.ArrayList;
import java.util.Collections;
import java.util.Comparator;
import java.util.List;
import java.util.Map;
import java.util.Map.Entry;

import com.google.common.collect.Maps;
import com.imop.lj.common.InitializeRequired;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.offlinedata.PetBattleSnap;
import com.imop.lj.gameserver.offlinedata.UserSnap;
import com.imop.lj.gameserver.pet.PetDef;
import com.imop.lj.gameserver.rank.RankDef.RankType;
import com.imop.lj.gameserver.rank.msg.GCRankApply;

public class RankService implements InitializeRequired  {
	
	/** 排行map<排行榜类型,List<RankInfo>>*/
	protected Map<RankType,List<RankInfo>> rankMap = Maps.newHashMap();
	
	/** 排行榜生成时间戳*/
	protected Long timeStamp ;
	
	/** 主将列表*/
	protected List<RankInfo> leaderList = new ArrayList<RankInfo>();
	
	/** 宠物列表*/
	protected List<RankInfo> petList = new ArrayList<RankInfo>();
	
	/** 比较器列表*/
	protected Map<RankType,Comparator<RankInfo>> rankSorter = Maps.newHashMap();
	
	public static final int RANK_SIZE = 100;
	
	@Override
	public void init() {
		//初始化比较器
		initSorter();
		
		//生成排行榜
		rebuildRanks();
	}
	  
	/**
	 * 更新全部的排行榜
	 */
	public void rebuildRanks(){
		//重新加载rankInfo
		loadRankInfo();
		
		//等级排行榜
		rebuildLevelRank();
		
		//人物战力排行榜
		rebuildHumanFightPowerRank();
				
		//宠物评分排行榜
		rebuildPetScoreRank();	
		
		//侠客战力排行榜
		rebuildXiakeFightPowerRank();
		
		//刺客战力排行榜
		rebuildCikeFightPowerRank();
		
		//术士战力排行榜
		rebuildShushiFightPowerRank();
		
		//修真战力排行榜
		rebuildXiuzhenFightPowerRank();
		
		//TODO 需要加的排行榜在这里加
		
		//生成时间戳
		timeStamp = Globals.getTimeService().now();
	}
	
	protected void rebuildLevelRank() {
		//排序
		Collections.sort(leaderList,rankSorter.get(RankType.LEVEL_RANK));
		//生成目标
		ArrayList<RankInfo> targetList = new ArrayList<RankInfo>();
		int i = 1;
		for(RankInfo ri : leaderList){
			RankInfo temp = new RankInfo(ri);
			temp.setRank(i);
			targetList.add(temp);
			i++;
		}
		rankMap.put(RankType.LEVEL_RANK, targetList);
	}
	
	protected void rebuildHumanFightPowerRank() {
		Collections.sort(leaderList,rankSorter.get(RankType.HUMAN_FIGHT_POWER_RANK));
		ArrayList<RankInfo> targetList = new ArrayList<RankInfo>();
		int i = 1;
		for(RankInfo ri : leaderList){
			RankInfo temp = new RankInfo(ri);
			temp.setRank(i);
			targetList.add(temp);
			i++;
		}
		rankMap.put(RankType.HUMAN_FIGHT_POWER_RANK, targetList);
	}
	
	protected void rebuildPetScoreRank() {
		Collections.sort(petList,rankSorter.get(RankType.PET_SCORE_RANK));
		ArrayList<RankInfo> targetList = new ArrayList<RankInfo>();
		int i = 1;
		for(RankInfo ri : petList){
			RankInfo temp = new RankInfo(ri);
			temp.setRank(i);
			targetList.add(temp);
			i++;
		}
		rankMap.put(RankType.PET_SCORE_RANK, targetList);
	}
	
	protected void rebuildXiakeFightPowerRank() {
		//生成对应职业的tempList
		List<RankInfo> tempList  = new ArrayList<RankInfo>();
		int i = 1;
		for(RankInfo ri : leaderList){
			if(ri.getHumanJob() == PetDef.JobType.XIAKE.index){
				RankInfo temp = new RankInfo(ri);
				temp.setRank(i);
				tempList.add(temp);
				i++;
			}
		}
		//排序
		Collections.sort(tempList,rankSorter.get(RankType.XIAKE_FIGHT_POWER_RANK));
		rankMap.put(RankType.XIAKE_FIGHT_POWER_RANK, tempList);
	}
	
	
	protected void rebuildCikeFightPowerRank() {
		//生成对应职业的tempList
		List<RankInfo> tempList  = new ArrayList<RankInfo>();
		int i = 1;
		for(RankInfo ri : leaderList){
			if(ri.getHumanJob() == PetDef.JobType.CIKE.index){
				RankInfo temp = new RankInfo(ri);
				temp.setRank(i);
				tempList.add(temp);
				i++;
			}
		}
		//排序
		Collections.sort(tempList,rankSorter.get(RankType.CIKE_FIGHT_POWER_RANK));
		rankMap.put(RankType.CIKE_FIGHT_POWER_RANK, tempList);
	}
	
	
	protected void rebuildShushiFightPowerRank() {
		//生成对应职业的tempList
		List<RankInfo> tempList  = new ArrayList<RankInfo>();
		int i = 1;
		for(RankInfo ri : leaderList){
			if(ri.getHumanJob() == PetDef.JobType.SHUSHI.index){
				RankInfo temp = new RankInfo(ri);
				temp.setRank(i);
				tempList.add(temp);
				i++;
			}
		}
		//排序
		Collections.sort(tempList,rankSorter.get(RankType.SHUSHI_FIGHT_POWER_RANK));
		rankMap.put(RankType.SHUSHI_FIGHT_POWER_RANK, tempList);
	}
	
	protected void rebuildXiuzhenFightPowerRank() {
		//生成对应职业的tempList
		List<RankInfo> tempList  = new ArrayList<RankInfo>();
		int i = 1;
		for(RankInfo ri : leaderList){
			if(ri.getHumanJob() == PetDef.JobType.XIUZHEN.index){
				RankInfo temp = new RankInfo(ri);
				temp.setRank(i);
				tempList.add(temp);
				i++;
			}
		}
		//排序
		Collections.sort(tempList,rankSorter.get(RankType.XIUZHEN_FIGHT_POWER_RANK));
		rankMap.put(RankType.XIUZHEN_FIGHT_POWER_RANK, tempList);
	}
	
	/** 去掉list中多余的部分*/
	protected void trimList(List<RankInfo> tempList,
			ArrayList<RankInfo> targetList) {
		for(int i = 0; i < RANK_SIZE; i++){
			if(tempList.size() <= i){
				break;
			}
			targetList.add(tempList.get(i));
		}
	}
	
	protected void loadRankInfo(){
		
		leaderList.clear();
		
		petList.clear();
		
		Map<Long, UserSnap> snapMap = Globals.getOfflineDataService().getAllUserSnap();
		for(Entry<Long,UserSnap> userEntry : snapMap.entrySet()){
			for(Entry<Long, PetBattleSnap> petEntry : userEntry.getValue().getPsManager().getPetMap().entrySet()){
				RankInfo ri = new RankInfo();
				ri.setHumanId(userEntry.getKey());
				ri.setCorpsName(Globals.getCorpsService().getCorpsNameByHumanId(userEntry.getKey()));
				ri.setFightPower(petEntry.getValue().getFightPower());
				ri.setHumanJob(userEntry.getValue().getHumanJobTypeId());
				ri.setHumanName(userEntry.getValue().getName());
				ri.setLevel(userEntry.getValue().getLevel());
				ri.setPetId(petEntry.getValue().getPetId());
				ri.setPetName(petEntry.getValue().getName());
				ri.setScore(petEntry.getValue().getScore());
				ri.setLevelUpTimeStamp(petEntry.getValue().getLevelUpTime());
				ri.setRank(0);
				
				if(petEntry.getValue().isLeader()){
					leaderList.add(ri);
				}else if(petEntry.getValue().isPet()){
					petList.add(ri);
				}
				
			}
		}
		
	}
	
	protected void initSorter(){
		//等级比较器
		rankSorter.put(RankType.LEVEL_RANK, new Comparator<RankInfo>() {
	        public int compare(RankInfo o1, RankInfo o2) {
	        	Integer a = (Integer) o1.getLevel();
	            Integer b = (Integer) o2.getLevel();
	            
	            if(b != a){
	            	return b-a;
	            }else{
	            	if(o2.getLevelUpTimeStamp() <= o1.getLevelUpTimeStamp() ){
	            		return 1;
	            	}else{
	            		return -1;
	            	}
	            }
	        }
		});
		
		//人物战力比较器
		rankSorter.put(RankType.HUMAN_FIGHT_POWER_RANK, new Comparator<RankInfo>() {
	        public int compare(RankInfo o1, RankInfo o2) {
	        	Integer a = (Integer) o1.getFightPower();
	            Integer b = (Integer) o2.getFightPower();
	            //降序
	            return b.compareTo(a);
	        }
		});
		
		//宠物评分比较器
		rankSorter.put(RankType.PET_SCORE_RANK, new Comparator<RankInfo>() {
	        public int compare(RankInfo o1, RankInfo o2) {
	        	Integer a = (Integer) o1.getScore();
	            Integer b = (Integer) o2.getScore();
	            //降序
	            return b.compareTo(a);
	        }
		});
		
		//侠客战力比较器
		rankSorter.put(RankType.XIAKE_FIGHT_POWER_RANK, new Comparator<RankInfo>() {
	        public int compare(RankInfo o1, RankInfo o2) {
	        	Integer a = (Integer) o1.getFightPower();
	            Integer b = (Integer) o2.getFightPower();
	            //降序
	            return b.compareTo(a);
	        }
		});
		
		//丛刻战力比较器
		rankSorter.put(RankType.CIKE_FIGHT_POWER_RANK, new Comparator<RankInfo>() {
	        public int compare(RankInfo o1, RankInfo o2) {
	        	Integer a = (Integer) o1.getFightPower();
	            Integer b = (Integer) o2.getFightPower();
	            //降序
	            return b.compareTo(a);
	        }
		});
		
		//术士战力比较器
		rankSorter.put(RankType.SHUSHI_FIGHT_POWER_RANK, new Comparator<RankInfo>() {
	        public int compare(RankInfo o1, RankInfo o2) {
	        	Integer a = (Integer) o1.getFightPower();
	            Integer b = (Integer) o2.getFightPower();
	            //降序
	            return b.compareTo(a);
	        }
		});
		
		//修真战力比较器
		rankSorter.put(RankType.XIUZHEN_FIGHT_POWER_RANK, new Comparator<RankInfo>() {
	        public int compare(RankInfo o1, RankInfo o2) {
	        	Integer a = (Integer) o1.getFightPower();
	            Integer b = (Integer) o2.getFightPower();
	            //降序
	            return b.compareTo(a);
	        }
		});
		
	}
	
	/**
	 * 申请Rank列表 
	 * 如果timeStamp与现在的时间戳不相同则发送，否则不发送
	 * @param rankTypeId 
	 * @param timeStamp
	 */
	public void applyRank(Human human, Integer rankTypeId, Long timeStamp){
		//没有这个排行
		if(RankType.valueOf(rankTypeId) == null){
			return ;
		}
		
		//时间戳相同
		if(timeStamp == this.timeStamp){
			GCRankApply gc = new GCRankApply();
			gc.setRankType(rankTypeId);
			gc.setRankInfoList(new RankInfo[0]);
			gc.setTimeId(this.timeStamp);
			human.sendMessage(gc);
			return ;
		}
		
		//找到自己
		List<RankInfo> list = rankMap.get(RankType.valueOf(rankTypeId));
		RankInfo self = new RankInfo() ;
		for(int i = 0; i<list.size() ; i++){
			RankInfo ri = list.get(i);
			if(ri == null){
				continue;
			}
			if(ri.getHumanId() == human.getUUID()){
				self = new RankInfo(ri);
				self.setRank(i+1);
				break;
			}
		}
		
		//修正数据长度
		ArrayList<RankInfo> targetList = new ArrayList<RankInfo>();
		trimList(list,targetList);
		
		//将自己放在最后一位
		targetList.add(self);
		
		//发送
		GCRankApply gc = new GCRankApply();
		gc.setRankType(rankTypeId);
		gc.setRankInfoList(targetList.toArray(new RankInfo[0]));
		gc.setTimeId(this.timeStamp);
		human.sendMessage(gc);
	}
	
}
