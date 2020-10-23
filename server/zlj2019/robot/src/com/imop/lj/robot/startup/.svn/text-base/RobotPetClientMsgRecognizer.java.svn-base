package com.imop.lj.robot.startup;

import java.util.HashMap;
import java.util.Map;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.common.MessageMappingProvider;
import com.imop.lj.gameserver.pet.msg.GCAddPet;
import com.imop.lj.gameserver.pet.msg.GCPetList;
import com.imop.lj.gameserver.pet.msg.GCPetInfo;
import com.imop.lj.gameserver.pet.msg.GCPetAddPoint;
import com.imop.lj.gameserver.pet.msg.GCPetChangeFightState;
import com.imop.lj.gameserver.pet.msg.GCPetChangeName;
import com.imop.lj.gameserver.pet.msg.GCPetFire;
import com.imop.lj.gameserver.pet.msg.GCPetRefreshTalentSkill;
import com.imop.lj.gameserver.pet.msg.GCPetStudyNormalSkill;
import com.imop.lj.gameserver.pet.msg.GCPetRejuven;
import com.imop.lj.gameserver.pet.msg.GCPetVariation;
import com.imop.lj.gameserver.pet.msg.GCPetArtifice;
import com.imop.lj.gameserver.pet.msg.GCPetTrainUpdate;
import com.imop.lj.gameserver.pet.msg.GCPetPerceptAddExp;
import com.imop.lj.gameserver.pet.msg.GCPetHorseRide;
import com.imop.lj.gameserver.pet.msg.GCPetHorseChangeName;
import com.imop.lj.gameserver.pet.msg.GCPetHorseFire;
import com.imop.lj.gameserver.pet.msg.GCPetHorseRejuven;
import com.imop.lj.gameserver.pet.msg.GCPetHorseArtifice;
import com.imop.lj.gameserver.pet.msg.GCPetHorseTrainUpdate;
import com.imop.lj.gameserver.pet.msg.GCPetHorsePerceptAddExp;
import com.imop.lj.gameserver.pet.msg.GCPetHorseCurPropUpdate;
import com.imop.lj.gameserver.pet.msg.GCPetFriendUnlockList;
import com.imop.lj.gameserver.pet.msg.GCPetFriendArrayList;
import com.imop.lj.gameserver.pet.msg.GCPetFriendInfo;
import com.imop.lj.gameserver.pet.msg.GCPetAddExp;
import com.imop.lj.gameserver.pet.msg.GCPetCurPropUpdate;
import com.imop.lj.gameserver.pet.msg.GCPetPoolUpdate;
import com.imop.lj.gameserver.pet.msg.GCPetResetPoint;
import com.imop.lj.gameserver.pet.msg.GCPetLeaderStudySkill;
import com.imop.lj.gameserver.pet.msg.GCPetSkillEffectUplevel;
import com.imop.lj.gameserver.pet.msg.GCPetSkillEffectUpdate;
import com.imop.lj.gameserver.pet.msg.GCPetAffination;
import com.imop.lj.gameserver.pet.msg.GCAddPetSkillbarNum;
import com.imop.lj.gameserver.pet.msg.GCPetHorseAffination;
import com.imop.lj.gameserver.pet.msg.GCAddPetHorseSkillbarNum;
import com.imop.lj.gameserver.pet.msg.GCPetHorseRefreshTalentSkill;
import com.imop.lj.gameserver.pet.msg.GCPetHorseStudyNormalSkill;
import com.imop.lj.gameserver.pet.msg.GCPetHorseSoulLinkPet;

public class RobotPetClientMsgRecognizer implements MessageMappingProvider {
	
	private Map<Short, Class<?>> msgs = new HashMap<Short, Class<?>>();
	
	@Override
	public Map<Short, Class<?>> getMessageMapping() {
		Map<Short, Class<?>> msgs = new HashMap<Short, Class<?>>();
		msgs.put(MessageType.GC_ADD_PET, GCAddPet.class);
		msgs.put(MessageType.GC_PET_LIST, GCPetList.class);
		msgs.put(MessageType.GC_PET_INFO, GCPetInfo.class);
		msgs.put(MessageType.GC_PET_ADD_POINT, GCPetAddPoint.class);
		msgs.put(MessageType.GC_PET_CHANGE_FIGHT_STATE, GCPetChangeFightState.class);
		msgs.put(MessageType.GC_PET_CHANGE_NAME, GCPetChangeName.class);
		msgs.put(MessageType.GC_PET_FIRE, GCPetFire.class);
		msgs.put(MessageType.GC_PET_REFRESH_TALENT_SKILL, GCPetRefreshTalentSkill.class);
		msgs.put(MessageType.GC_PET_STUDY_NORMAL_SKILL, GCPetStudyNormalSkill.class);
		msgs.put(MessageType.GC_PET_REJUVEN, GCPetRejuven.class);
		msgs.put(MessageType.GC_PET_VARIATION, GCPetVariation.class);
		msgs.put(MessageType.GC_PET_ARTIFICE, GCPetArtifice.class);
		msgs.put(MessageType.GC_PET_TRAIN_UPDATE, GCPetTrainUpdate.class);
		msgs.put(MessageType.GC_PET_PERCEPT_ADD_EXP, GCPetPerceptAddExp.class);
		msgs.put(MessageType.GC_PET_HORSE_RIDE, GCPetHorseRide.class);
		msgs.put(MessageType.GC_PET_HORSE_CHANGE_NAME, GCPetHorseChangeName.class);
		msgs.put(MessageType.GC_PET_HORSE_FIRE, GCPetHorseFire.class);
		msgs.put(MessageType.GC_PET_HORSE_REJUVEN, GCPetHorseRejuven.class);
		msgs.put(MessageType.GC_PET_HORSE_ARTIFICE, GCPetHorseArtifice.class);
		msgs.put(MessageType.GC_PET_HORSE_TRAIN_UPDATE, GCPetHorseTrainUpdate.class);
		msgs.put(MessageType.GC_PET_HORSE_PERCEPT_ADD_EXP, GCPetHorsePerceptAddExp.class);
		msgs.put(MessageType.GC_PET_HORSE_CUR_PROP_UPDATE, GCPetHorseCurPropUpdate.class);
		msgs.put(MessageType.GC_PET_FRIEND_UNLOCK_LIST, GCPetFriendUnlockList.class);
		msgs.put(MessageType.GC_PET_FRIEND_ARRAY_LIST, GCPetFriendArrayList.class);
		msgs.put(MessageType.GC_PET_FRIEND_INFO, GCPetFriendInfo.class);
		msgs.put(MessageType.GC_PET_ADD_EXP, GCPetAddExp.class);
		msgs.put(MessageType.GC_PET_CUR_PROP_UPDATE, GCPetCurPropUpdate.class);
		msgs.put(MessageType.GC_PET_POOL_UPDATE, GCPetPoolUpdate.class);
		msgs.put(MessageType.GC_PET_RESET_POINT, GCPetResetPoint.class);
		msgs.put(MessageType.GC_PET_LEADER_STUDY_SKILL, GCPetLeaderStudySkill.class);
		msgs.put(MessageType.GC_PET_SKILL_EFFECT_UPLEVEL, GCPetSkillEffectUplevel.class);
		msgs.put(MessageType.GC_PET_SKILL_EFFECT_UPDATE, GCPetSkillEffectUpdate.class);
		msgs.put(MessageType.GC_PET_AFFINATION, GCPetAffination.class);
		msgs.put(MessageType.GC_ADD_PET_SKILLBAR_NUM, GCAddPetSkillbarNum.class);
		msgs.put(MessageType.GC_PET_HORSE_AFFINATION, GCPetHorseAffination.class);
		msgs.put(MessageType.GC_ADD_PET_HORSE_SKILLBAR_NUM, GCAddPetHorseSkillbarNum.class);
		msgs.put(MessageType.GC_PET_HORSE_REFRESH_TALENT_SKILL, GCPetHorseRefreshTalentSkill.class);
		msgs.put(MessageType.GC_PET_HORSE_STUDY_NORMAL_SKILL, GCPetHorseStudyNormalSkill.class);
		msgs.put(MessageType.GC_PET_HORSE_SOUL_LINK_PET, GCPetHorseSoulLinkPet.class);
		return msgs;
	}
}
