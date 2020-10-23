package com.imop.lj.logserver;

import org.apache.mina.core.buffer.IoBuffer;

import com.imop.lj.core.msg.IMessage;
import com.imop.lj.core.msg.recognizer.IMessageRecognizer;
import com.imop.lj.core.msg.MessageParseException;
	import com.imop.lj.logserver.model.ArenaLog;
	import com.imop.lj.logserver.model.BehaviorLog;
	import com.imop.lj.logserver.model.ChargeLog;
	import com.imop.lj.logserver.model.ChatLog;
	import com.imop.lj.logserver.model.DropItemLog;
	import com.imop.lj.logserver.model.GmCommandLog;
	import com.imop.lj.logserver.model.ItemGenLog;
	import com.imop.lj.logserver.model.ItemLog;
	import com.imop.lj.logserver.model.MailLog;
	import com.imop.lj.logserver.model.MoneyLog;
	import com.imop.lj.logserver.model.OnlineTimeLog;
	import com.imop.lj.logserver.model.PlayerLoginLog;
	import com.imop.lj.logserver.model.VipLog;
	import com.imop.lj.logserver.model.TaskLog;
	import com.imop.lj.logserver.model.FormationLog;
	import com.imop.lj.logserver.model.MissionLog;
	import com.imop.lj.logserver.model.RewardLog;
	import com.imop.lj.logserver.model.EquipLog;
	import com.imop.lj.logserver.model.PetLog;
	import com.imop.lj.logserver.model.PrizeLog;
	import com.imop.lj.logserver.model.MysteryShopLog;
	import com.imop.lj.logserver.model.PetExpLog;
	import com.imop.lj.logserver.model.HorseLog;
	import com.imop.lj.logserver.model.MallLog;
	import com.imop.lj.logserver.model.ItemCostRecordLog;
	import com.imop.lj.logserver.model.PopTipsLog;
	import com.imop.lj.logserver.model.GoodActivityLog;
	import com.imop.lj.logserver.model.BattleResultLog;
	import com.imop.lj.logserver.model.PubTaskLog;
	import com.imop.lj.logserver.model.PubExpLog;
	import com.imop.lj.logserver.model.ExamLog;
	import com.imop.lj.logserver.model.CorpsLog;
	import com.imop.lj.logserver.model.TheSweeneyTaskLog;
	import com.imop.lj.logserver.model.TreasureMapLog;
	import com.imop.lj.logserver.model.TitleLog;
	import com.imop.lj.logserver.model.ForageTaskLog;
	import com.imop.lj.logserver.model.OvermanLog;
	import com.imop.lj.logserver.model.WingLog;
	import com.imop.lj.logserver.model.CommoditySellLog;
	import com.imop.lj.logserver.model.CommodityBuyLog;
	import com.imop.lj.logserver.model.CorpsTaskLog;
	import com.imop.lj.logserver.model.CorpsBuildLog;
	import com.imop.lj.logserver.model.CorpsBenefitLog;
	import com.imop.lj.logserver.model.TowerLog;
	import com.imop.lj.logserver.model.CorpsBossLog;
	import com.imop.lj.logserver.model.TimeLimitMonsterLog;
	import com.imop.lj.logserver.model.TimeLimitNpcLog;
	import com.imop.lj.logserver.model.SiegeDemonTaskLog;

/**
 * This is an auto generated source,please don't modify it.
 */
public class LogMessageRecognizer implements IMessageRecognizer {


	@Override
	public int recognizePacketLen(final IoBuffer buff) {
		// 消息头还未读到,返回null
		if (buff.remaining() < IMessage.MIN_MESSAGE_LENGTH) {
			return -1;
		}
		return IMessage.Packet.peekPacketLength(buff);
	}


	public IMessage recognize(IoBuffer buf) throws MessageParseException {
		/* 长度尚不足 */
		if (buf.remaining() < IMessage.MIN_MESSAGE_LENGTH) {
			return null;
		}

		/* 长度不足实际命令 */
		int len = buf.getShort(); // 预期长度
		if (buf.remaining() < len - 2) {
			return null;
		}

		short type = buf.getShort();
		return createMessage(type);
	}

	public static IMessage createMessage(int type)
			throws MessageParseException {

		switch (type) {
			case MessageType.LOG_ARENA_RECORD: {
				return new ArenaLog();
			}
			case MessageType.LOG_BEHAVIOR_RECORD: {
				return new BehaviorLog();
			}
			case MessageType.LOG_CHARGE_RECORD: {
				return new ChargeLog();
			}
			case MessageType.LOG_CHAT_RECORD: {
				return new ChatLog();
			}
			case MessageType.LOG_DROPITEM_RECORD: {
				return new DropItemLog();
			}
			case MessageType.LOG_GMCOMMAND_RECORD: {
				return new GmCommandLog();
			}
			case MessageType.LOG_ITEMGEN_RECORD: {
				return new ItemGenLog();
			}
			case MessageType.LOG_ITEM_RECORD: {
				return new ItemLog();
			}
			case MessageType.LOG_MAIL_RECORD: {
				return new MailLog();
			}
			case MessageType.LOG_MONEY_RECORD: {
				return new MoneyLog();
			}
			case MessageType.LOG_ONLINETIME_RECORD: {
				return new OnlineTimeLog();
			}
			case MessageType.LOG_PLAYERLOGIN_RECORD: {
				return new PlayerLoginLog();
			}
			case MessageType.LOG_VIP_RECORD: {
				return new VipLog();
			}
			case MessageType.LOG_TASK_RECORD: {
				return new TaskLog();
			}
			case MessageType.LOG_FORMATION_RECORD: {
				return new FormationLog();
			}
			case MessageType.LOG_MISSION_RECORD: {
				return new MissionLog();
			}
			case MessageType.LOG_REWARD_RECORD: {
				return new RewardLog();
			}
			case MessageType.LOG_EQUIP_RECORD: {
				return new EquipLog();
			}
			case MessageType.LOG_PET_RECORD: {
				return new PetLog();
			}
			case MessageType.LOG_PRIZE_RECORD: {
				return new PrizeLog();
			}
			case MessageType.LOG_MYSTERYSHOP_RECORD: {
				return new MysteryShopLog();
			}
			case MessageType.LOG_PETEXP_RECORD: {
				return new PetExpLog();
			}
			case MessageType.LOG_HORSE_RECORD: {
				return new HorseLog();
			}
			case MessageType.LOG_MALL_RECORD: {
				return new MallLog();
			}
			case MessageType.LOG_ITEMCOSTRECORD_RECORD: {
				return new ItemCostRecordLog();
			}
			case MessageType.LOG_POPTIPS_RECORD: {
				return new PopTipsLog();
			}
			case MessageType.LOG_GOODACTIVITY_RECORD: {
				return new GoodActivityLog();
			}
			case MessageType.LOG_BATTLERESULT_RECORD: {
				return new BattleResultLog();
			}
			case MessageType.LOG_PUBTASK_RECORD: {
				return new PubTaskLog();
			}
			case MessageType.LOG_PUBEXP_RECORD: {
				return new PubExpLog();
			}
			case MessageType.LOG_EXAM_RECORD: {
				return new ExamLog();
			}
			case MessageType.LOG_CORPS_RECORD: {
				return new CorpsLog();
			}
			case MessageType.LOG_THESWEENEYTASK_RECORD: {
				return new TheSweeneyTaskLog();
			}
			case MessageType.LOG_TREASUREMAP_RECORD: {
				return new TreasureMapLog();
			}
			case MessageType.LOG_TITLE_RECORD: {
				return new TitleLog();
			}
			case MessageType.LOG_FORAGETASK_RECORD: {
				return new ForageTaskLog();
			}
			case MessageType.LOG_OVERMAN_RECORD: {
				return new OvermanLog();
			}
			case MessageType.LOG_WING_RECORD: {
				return new WingLog();
			}
			case MessageType.LOG_COMMODITYSELL_RECORD: {
				return new CommoditySellLog();
			}
			case MessageType.LOG_COMMODITYBUY_RECORD: {
				return new CommodityBuyLog();
			}
			case MessageType.LOG_CORPSTASK_RECORD: {
				return new CorpsTaskLog();
			}
			case MessageType.LOG_CORPSBUILD_RECORD: {
				return new CorpsBuildLog();
			}
			case MessageType.LOG_CORPSBENEFIT_RECORD: {
				return new CorpsBenefitLog();
			}
			case MessageType.LOG_TOWER_RECORD: {
				return new TowerLog();
			}
			case MessageType.LOG_CORPSBOSS_RECORD: {
				return new CorpsBossLog();
			}
			case MessageType.LOG_TIMELIMITMONSTER_RECORD: {
				return new TimeLimitMonsterLog();
			}
			case MessageType.LOG_TIMELIMITNPC_RECORD: {
				return new TimeLimitNpcLog();
			}
			case MessageType.LOG_SIEGEDEMONTASK_RECORD: {
				return new SiegeDemonTaskLog();
			}

		default: {
			// TODO::考虑不要死机，可能要特殊处理
			throw new MessageParseException("Unrecognized message :" + type);
		}
		}

	}

}