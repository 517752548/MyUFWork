package com.imop.lj.gameserver.startup;

import java.util.HashMap;
import java.util.Map;

import com.imop.lj.common.InitializeRequired;
import com.imop.lj.common.MessageMappingProvider;
import com.imop.lj.core.msg.IMessage;
import com.imop.lj.core.msg.MessageParseException;
import com.imop.lj.core.msg.MessageType;
import com.imop.lj.core.msg.recognizer.BaseMessageRecognizer;
import com.imop.lj.gameserver.activityui.msg.ActivityuiMsgMappingProvider;
import com.imop.lj.gameserver.arena.msg.ArenaMsgMappingProvider;
import com.imop.lj.gameserver.battle.msg.BattleMsgMappingProvider;
import com.imop.lj.gameserver.cdkeygift.msg.CdkeygiftMsgMappingProvider;
import com.imop.lj.gameserver.chat.msg.ChatMsgMappingProvider;
import com.imop.lj.gameserver.common.msg.CGHandshake;
import com.imop.lj.gameserver.common.msg.CommonMsgMappingProvider;
import com.imop.lj.gameserver.corps.msg.CorpsMsgMappingProvider;
import com.imop.lj.gameserver.corpsboss.msg.CorpsbossMsgMappingProvider;
import com.imop.lj.gameserver.corpstask.msg.CorpstaskMsgMappingProvider;
import com.imop.lj.gameserver.equip.msg.EquipMsgMappingProvider;
import com.imop.lj.gameserver.exam.msg.ExamMsgMappingProvider;
import com.imop.lj.gameserver.foragetask.msg.ForagetaskMsgMappingProvider;
import com.imop.lj.gameserver.goodactivity.msg.GoodactivityMsgMappingProvider;
import com.imop.lj.gameserver.guide.msg.GuideMsgMappingProvider;
import com.imop.lj.gameserver.human.msg.HumanMsgMappingProvider;
import com.imop.lj.gameserver.humanskill.msg.HumanskillMsgMappingProvider;
import com.imop.lj.gameserver.item.msg.ItemMsgMappingProvider;
import com.imop.lj.gameserver.lifeskill.msg.LifeskillMsgMappingProvider;
import com.imop.lj.gameserver.mail.msg.MailMsgMappingProvider;
import com.imop.lj.gameserver.mall.msg.MallMsgMappingProvider;
import com.imop.lj.gameserver.map.msg.MapMsgMappingProvider;
import com.imop.lj.gameserver.marry.msg.MarryMsgMappingProvider;
import com.imop.lj.gameserver.mysteryshop.msg.MysteryshopMsgMappingProvider;
import com.imop.lj.gameserver.nvn.msg.NvnMsgMappingProvider;
import com.imop.lj.gameserver.onlinegift.msg.OnlinegiftMsgMappingProvider;
import com.imop.lj.gameserver.overman.msg.OvermanMsgMappingProvider;
import com.imop.lj.gameserver.pet.msg.PetMsgMappingProvider;
import com.imop.lj.gameserver.player.msg.PlayerMsgMappingProvider;
import com.imop.lj.gameserver.plotdungeon.msg.PlotdungeonMsgMappingProvider;
import com.imop.lj.gameserver.prize.msg.PrizeMsgMappingProvider;
import com.imop.lj.gameserver.promote.msg.PromoteMsgMappingProvider;
import com.imop.lj.gameserver.pubtask.msg.PubtaskMsgMappingProvider;
import com.imop.lj.gameserver.quest.msg.QuestMsgMappingProvider;
import com.imop.lj.gameserver.rank.msg.RankMsgMappingProvider;
import com.imop.lj.gameserver.relation.msg.RelationMsgMappingProvider;
import com.imop.lj.gameserver.scene.msg.SceneMsgMappingProvider;
import com.imop.lj.gameserver.siegedemon.msg.SiegedemonMsgMappingProvider;
import com.imop.lj.gameserver.team.msg.TeamMsgMappingProvider;
import com.imop.lj.gameserver.test.msg.TestMsgMappingProvider;
import com.imop.lj.gameserver.thesweeneytask.msg.ThesweeneytaskMsgMappingProvider;
import com.imop.lj.gameserver.timelimit.msg.TimelimitMsgMappingProvider;
import com.imop.lj.gameserver.title.msg.TitleMsgMappingProvider;
import com.imop.lj.gameserver.tower.msg.TowerMsgMappingProvider;
import com.imop.lj.gameserver.trade.msg.TradeMsgMappingProvider;
import com.imop.lj.gameserver.treasuremap.msg.TreasuremapMsgMappingProvider;
import com.imop.lj.gameserver.wallow.msg.WallowMsgMappingProvider;
import com.imop.lj.gameserver.wing.msg.WingMsgMappingProvider;
import com.imop.lj.gameserver.wizardraid.msg.WizardraidMsgMappingProvider;

/**
 * 来自客户端的消息识别器
 *
 */
public class ClientMessageRecognizer extends BaseMessageRecognizer implements
		InitializeRequired {
	private Map<Short, Class<?>> msgs = new HashMap<Short, Class<?>>();

	public ClientMessageRecognizer() {
		this.init();
	}

	@Override
	public void init() {
		//registerMsgMapping(new PlayerMsgMappingProvider());
		registerMsgMapping(new MessageMappingProvider(){
			@Override
			public Map<Short, Class<?>> getMessageMapping() {
				Map<Short, Class<?>> map = new HashMap<Short, Class<?>>();
				map.put(MessageType.CG_HANDSHAKE, CGHandshake.class);
				return map;
			}
		});
		registerMsgMapping(new HumanMsgMappingProvider());
		registerMsgMapping(new CommonMsgMappingProvider());
		registerMsgMapping(new PlayerMsgMappingProvider());
		registerMsgMapping(new ItemMsgMappingProvider());
		registerMsgMapping(new ChatMsgMappingProvider());
		registerMsgMapping(new QuestMsgMappingProvider());
		registerMsgMapping(new WallowMsgMappingProvider());
		registerMsgMapping(new SceneMsgMappingProvider());
		registerMsgMapping(new TestMsgMappingProvider());
		registerMsgMapping(new PetMsgMappingProvider());
		registerMsgMapping(new MailMsgMappingProvider());
		registerMsgMapping(new RelationMsgMappingProvider());
		registerMsgMapping(new PrizeMsgMappingProvider());
		registerMsgMapping(new MysteryshopMsgMappingProvider());
		registerMsgMapping(new GoodactivityMsgMappingProvider());
		registerMsgMapping(new MallMsgMappingProvider());
		registerMsgMapping(new MallMsgMappingProvider());
		registerMsgMapping(new CdkeygiftMsgMappingProvider());
		registerMsgMapping(new MapMsgMappingProvider());
		registerMsgMapping(new BattleMsgMappingProvider());
		registerMsgMapping(new EquipMsgMappingProvider());
		registerMsgMapping(new ExamMsgMappingProvider());
		registerMsgMapping(new PubtaskMsgMappingProvider());
		registerMsgMapping(new HumanskillMsgMappingProvider());
		registerMsgMapping(new TradeMsgMappingProvider());
		registerMsgMapping(new ActivityuiMsgMappingProvider());
		registerMsgMapping(new CorpsMsgMappingProvider());
		registerMsgMapping(new RankMsgMappingProvider());
		registerMsgMapping(new TeamMsgMappingProvider());
		registerMsgMapping(new OnlinegiftMsgMappingProvider());
		registerMsgMapping(new LifeskillMsgMappingProvider());
		registerMsgMapping(new WizardraidMsgMappingProvider());
		registerMsgMapping(new ThesweeneytaskMsgMappingProvider());
		registerMsgMapping(new TreasuremapMsgMappingProvider());
		registerMsgMapping(new TitleMsgMappingProvider());
		registerMsgMapping(new ForagetaskMsgMappingProvider());
		registerMsgMapping(new OvermanMsgMappingProvider());
		registerMsgMapping(new MarryMsgMappingProvider());
		registerMsgMapping(new NvnMsgMappingProvider());
		registerMsgMapping(new WingMsgMappingProvider());
		registerMsgMapping(new ArenaMsgMappingProvider());
		registerMsgMapping(new CorpstaskMsgMappingProvider());
		registerMsgMapping(new GuideMsgMappingProvider());
		registerMsgMapping(new PromoteMsgMappingProvider());
		registerMsgMapping(new TowerMsgMappingProvider());
		registerMsgMapping(new CorpsbossMsgMappingProvider());
		registerMsgMapping(new TimelimitMsgMappingProvider());
		registerMsgMapping(new PlotdungeonMsgMappingProvider());
		registerMsgMapping(new SiegedemonMsgMappingProvider());
	}

	/**
	 * 注册消息号和消息类的映射
	 *
	 * @param mappingProvider
	 */
	private void registerMsgMapping(MessageMappingProvider mappingProvider) {
		msgs.putAll(mappingProvider.getMessageMapping());
	}

	@Override
	public IMessage createMessageImpl(short type) throws MessageParseException {
		Class<?> clazz = msgs.get(type);
		if (clazz == null) {
			throw new MessageParseException("Unknow msgType:" + type);
		} else {
			try {
				IMessage msg = (IMessage) clazz.newInstance();
				return msg;
			} catch (Exception e) {
				throw new MessageParseException(
						"Message Newinstance Failed，msgType:" + type, e);
			}
		}
	}
}
