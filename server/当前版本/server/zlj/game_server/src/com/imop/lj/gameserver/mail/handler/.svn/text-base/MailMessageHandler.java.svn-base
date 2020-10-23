package com.imop.lj.gameserver.mail.handler;

import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.common.constants.ResultTypes;
import com.imop.lj.common.constants.SharedConstants;
import com.imop.lj.common.service.DirtFilterService.WordCheckType;
import com.imop.lj.gameserver.behavior.BehaviorTypeEnum;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.corps.CorpsDef.MemberJob;
import com.imop.lj.gameserver.corps.model.CorpsMember;
import com.imop.lj.gameserver.func.FuncDef.FuncTypeEnum;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.mail.msg.CGDelAllMail;
import com.imop.lj.gameserver.mail.msg.CGDelMail;
import com.imop.lj.gameserver.mail.msg.CGGetMailAttachment;
import com.imop.lj.gameserver.mail.msg.CGMailList;
import com.imop.lj.gameserver.mail.msg.CGReadMail;
import com.imop.lj.gameserver.mail.msg.CGSaveMail;
import com.imop.lj.gameserver.mail.msg.CGSaveMailBatch;
import com.imop.lj.gameserver.mail.msg.CGSendGuildMail;
import com.imop.lj.gameserver.mail.msg.CGSendMail;
import com.imop.lj.gameserver.mail.msg.GCSendMail;
import com.imop.lj.gameserver.player.Player;

public class MailMessageHandler {

	/**
	 * 邮件列表
	 * @param player
	 * @param cgMailList
	 */
	public void handleMailList(Player player, CGMailList cgMailList) {
		if (!checkCond(player)) {
			return;
		}
		if (cgMailList.getQueryIndex() <= 0) {
			return;
		}
		if (cgMailList.getBoxType() <= 0) {
			return;
		}
		
		Globals.getMailService().showMailList(player.getHuman(), cgMailList.getQueryIndex(), cgMailList.getBoxType());
	}

	/**
	 * 读邮件
	 * @param player
	 * @param cgReadMail
	 */
	public void handleReadMail(Player player, CGReadMail cgReadMail) {
		if (!checkCond(player)) {
			return;
		}
		if (cgReadMail.getUuid() == null || cgReadMail.getUuid().equalsIgnoreCase("")) {
			return;
		}
		
		Globals.getMailService().readMail(player.getHuman(), cgReadMail.getUuid());
	}

	/**
	 * 保存一封邮件
	 * @param player
	 * @param cgSaveMail
	 */
	public void handleSaveMail(Player player, CGSaveMail cgSaveMail) {
		//XXX 暂时不提供保存功能
		return;
//		if (!checkCond(player)) {
//			return;
//		}
//		if (cgSaveMail.getUuid() == null || cgSaveMail.getUuid().equalsIgnoreCase("")) {
//			return;
//		}
//		
//		String[] uuids = {cgSaveMail.getUuid()};
//		Globals.getMailService().saveMailBatch(player.getHuman(), uuids);
	}
	
	/**
	 * 批量保存邮件
	 * @param player
	 * @param cgSaveMailBatch
	 */
	public void handleSaveMailBatch(Player player, CGSaveMailBatch cgSaveMailBatch) {
		//XXX 暂时不提供保存功能
		return;
//		if (!checkCond(player)) {
//			return;
//		}
//		String[] uuids = cgSaveMailBatch.getUuidlist();
//		if (null == uuids || uuids.length == 0) {
//			return;
//		}
//		
//		Globals.getMailService().saveMailBatch(player.getHuman(), uuids);
	}

	/**
	 * 删除一封邮件
	 * @param player
	 * @param cgDelMail
	 */
	public void handleDelMail(Player player, CGDelMail cgDelMail) {
		if (!checkCond(player)) {
			return;
		}
		if (cgDelMail.getUuid() == null || cgDelMail.getUuid().equalsIgnoreCase("")) {
			return;
		}
		String[] uuids = {cgDelMail.getUuid()};
		Globals.getMailService().delMailBatch(player.getHuman(), uuids);
	}

	/**
	 * 批量删除邮件
	 * @param player
	 * @param cgDelAllMail
	 */
	public void handleDelAllMail(Player player, CGDelAllMail cgDelAllMail) {
		if (!checkCond(player)) {
			return;
		}
		String[] uuids = cgDelAllMail.getUuidlist();
		if (null == uuids || uuids.length == 0) {
			return;
		}
		
		Globals.getMailService().delMailBatch(player.getHuman(), uuids);
	}

	/**
	 * 玩家给指定的人发邮件
	 * 
	 * @param player
	 * @param cgSendMail
	 */
	public void handleSendMail(final Player player, CGSendMail cgSendMail) {
		return;
//		if (!checkCond(player)) {
//			return;
//		}
//		Human human = player.getHuman();
//		if (human.getMailbox() == null) {
//			return;
//		}
//		
//		// 判断用户是否被禁言
//		if (player.getForibedTime() > System.currentTimeMillis()) {
//			Loggers.chatLogger.info("MailMessageHandler.handleSendMail player is foribedTalk playerId=" + player.getRoleUUID());
//			human.sendSystemMessage(LangConstants.FORIBED_SEND_MAIL);
//			return;
//		}
//				
//		// 是否到达可以发送邮件的最小战力
//		if (human.getFightPower() < Globals.getGameConstants().getTheMinPowerForSendMail()) {
//			if (Loggers.chatLogger.isInfoEnabled()) {
//				Loggers.chargeLogger.info("#MailMessageHandler.handleSendMail player power is not enough!! playerId = " + player.getRoleUUID() + ", power = " + human.getPower());
//			}
//			human.sendSystemMessage(LangConstants.POWER_IS_NOT_ENOUGH_FOR_SEND_MAIL);
//			return;
//		}
//		
//		String recName = cgSendMail.getRecName();
//		if (null == recName || recName.equalsIgnoreCase("")) {
//			return;
//		}
//		
//		// 行为次数是否已达上限
//		if (!human.getBehaviorManager().canDo(BehaviorTypeEnum.MAIL_SEND)) {
//			human.sendErrorMessage(LangConstants.MAIL_SEND_TIMES_LIMIT);
//			return;
//		}
//		
//		// 检查收件人是否存在
//		long recId = Globals.getOfflineDataService().getUserIdByName(recName);
//		if (recId <= 0) {
//			human.sendErrorMessage(LangConstants.MAIL_SEND_ERROR_RECID_NOEXIST);
//			return;
//		}
//		// 不能给自己发邮件
//		if (recId == human.getUUID()) {
//			human.sendErrorMessage(LangConstants.MAIL_SEND_FAIL_NO_SELF);
//			return;
//		}
//		
//		// 如果对方在自己的黑名单中，则不让发
//		if (Globals.getRelationService().isTargetInBlackList(human, recId)) {
//			human.sendErrorMessage(LangConstants.MAIL_SEND_FAIL_IN_MY_BLACKLIST);
//			return;
//		}
//		
//		// 如果recId在线，判断是否其黑名单，如果是则给错误提示，不让发
//		Player recPlayer = Globals.getOnlinePlayerService().getPlayer(recId);
//		if (recPlayer != null && recPlayer.getHuman() != null) {
//			// 如果收件人的黑名单中有该发件人，则提示该发件人不能发
//			if (Globals.getRelationService().isTargetInBlackList(recPlayer.getHuman(), human.getUUID())) {
//				human.sendErrorMessage(LangConstants.MAIL_SEND_FAIL_IN_BLACKLIST);
//				return;
//			}
//		}
//		
//		String title = Globals.getWordFilterService().filterHtmlTag(cgSendMail.getTitle());
//		String content = Globals.getWordFilterService().filterHtmlTag(cgSendMail.getContent());
//		// 检查标题
//		String _checkInputError = Globals.getDirtFilterService()
//				.checkInput(WordCheckType.CHAT_ANNOUNCE_DESC, title, LangConstants.GAME_INPUT_TYPE_MAIL_TITLE,
//						SharedConstants.MIN_MAIL_TITLE_LENGTH_ENG, SharedConstants.MAX_MAIL_TITLE_LENGTH_ENG, false);
//		if (_checkInputError != null) {
//			GCSendMail gcSendMailMsg = new GCSendMail();
//			gcSendMailMsg.setResult(ResultTypes.FAIL.val);
//			gcSendMailMsg.setErrorMsg(_checkInputError);
//			// 将过滤后的数据发回客户端
//			String titleAfterFilt = Globals.getDirtFilterService().filt(title);
//			gcSendMailMsg.setTitle(titleAfterFilt);
//			gcSendMailMsg.setContent(content);
//			human.sendMessage(gcSendMailMsg);
//			return;
//		}
//
//		// 检查内容
//		_checkInputError = Globals.getDirtFilterService().checkInput(WordCheckType.CHAT_ANNOUNCE_DESC, content,
//				LangConstants.GAME_INPUT_TYPE_MAIL_CONTENT, SharedConstants.MIN_MAIL_CONTENT_LENGTH_ENG, SharedConstants.MAX_MAIL_CONTENT_LENGTH_ENG,
//				false);
//		if (_checkInputError != null) {
//			GCSendMail gcSendMailMsg = new GCSendMail();
//			gcSendMailMsg.setResult(ResultTypes.FAIL.val);
//			gcSendMailMsg.setErrorMsg(_checkInputError);
//			// 将过滤后的数据发回客户端
//			String contentAfterFilt = Globals.getDirtFilterService().filt(content);
//			gcSendMailMsg.setTitle(title);
//			gcSendMailMsg.setContent(contentAfterFilt);
//			human.sendMessage(gcSendMailMsg);
//			return;
//		}
//
//		// 记录行为次数
//		human.getBehaviorManager().doBehavior(BehaviorTypeEnum.MAIL_SEND);
//		
//		// 所有检查都通过后，执行发邮件操作
//		Globals.getMailService().sendMail(human, recId, recName, title, content);
//		
//		GCSendMail gcSendMail = new GCSendMail();
//		gcSendMail.setResult(ResultTypes.SUCCESS.val);
//		human.sendMessage(gcSendMail);
//		human.sendErrorMessage(LangConstants.MAIL_SEND_SUCCESS_INFO);
	}

	/**
	 * 发送军团邮件
	 * 
	 * @param player
	 * @param cgSendGuildMail
	 */
	public void handleSendGuildMail(Player player, CGSendGuildMail cgSendGuildMail) {
		if (!checkCond(player)) {
			return;
		}

		Human human = player.getHuman();
		
		// 判断用户是否被禁言
		if (player.getForibedTime() > System.currentTimeMillis()) {
			Loggers.chatLogger.info("MailMessageHandler.handleSendGuildMail player is foribedTalk playerId="	+ player.getRoleUUID());
			human.sendSystemMessage(LangConstants.FORIBED_SEND_MAIL);
			return;
		}

		// 是否到达可以发送邮件的最小战力
		if (human.getFightPower() < Globals.getGameConstants().getTheMinPowerForSendMail()) {
			if (Loggers.chatLogger.isInfoEnabled()) {
				Loggers.chargeLogger.info("#MailMessageHandler.handleSendGuildMail player power is not enough!! playerId = "	+ player.getRoleUUID()	+ ", power = " + human.getPower());
			}
			human.sendSystemMessage(LangConstants.POWER_IS_NOT_ENOUGH_FOR_SEND_MAIL);
			return;
		}

		// 是否加入军团
		CorpsMember sender = Globals.getCorpsService().getCorpsMemberByRoleIdFromJoin(human.getUUID());
		if(sender == null || sender.getCorps() == null){
			return;
		}
		
		// 判断是否有权限
		if(!Globals.getCorpsService().checkJob(sender, MemberJob.PRESIDENT,MemberJob.VICE_CHAIRMAN)){
			human.sendErrorMessage(LangConstants.PERMISSION_NOT_ENOUGH);
			return;
		}
		
		// 行为次数是否已达上限
		if (!human.getBehaviorManager().canDo(BehaviorTypeEnum.MAIL_SEND)) {
			human.sendErrorMessage(LangConstants.MAIL_SEND_TIMES_LIMIT);
			return;
		}
		
		String title = Globals.getWordFilterService().filterHtmlTag(cgSendGuildMail.getTitle());
		String content = Globals.getWordFilterService().filterHtmlTag(cgSendGuildMail.getContent());
		// 检查标题
		String _checkTitleInputError = Globals.getDirtFilterService()
						.checkInput(WordCheckType.CHAT_ANNOUNCE_DESC, title, LangConstants.GAME_INPUT_TYPE_MAIL_TITLE,
								SharedConstants.MIN_MAIL_TITLE_LENGTH_ENG, SharedConstants.MAX_MAIL_TITLE_LENGTH_ENG, false);
		if (_checkTitleInputError != null) {
			GCSendMail gcSendMailMsg = new GCSendMail();
			gcSendMailMsg.setResult(ResultTypes.FAIL.val);
			gcSendMailMsg.setTitle(_checkTitleInputError);
			gcSendMailMsg.setErrorMsg(_checkTitleInputError);
			// 将过滤后的数据发回客户端
			String contentAfterFilt = Globals.getDirtFilterService().filt(content);
			gcSendMailMsg.setTitle(cgSendGuildMail.getTitle());
			gcSendMailMsg.setContent(contentAfterFilt);
			human.sendMessage(gcSendMailMsg);
			return;
		}
				
		// 检查内容
		String _checkInputError = Globals.getDirtFilterService().checkInput(WordCheckType.CHAT_ANNOUNCE_DESC, content,
				LangConstants.GAME_INPUT_TYPE_MAIL_CONTENT, SharedConstants.MIN_MAIL_CONTENT_LENGTH_ENG, SharedConstants.MAX_MAIL_CONTENT_LENGTH_ENG,
				false);
		if (_checkInputError != null) {
			GCSendMail gcSendMailMsg = new GCSendMail();
			gcSendMailMsg.setResult(ResultTypes.FAIL.val);
			gcSendMailMsg.setTitle(_checkTitleInputError);
			gcSendMailMsg.setErrorMsg(_checkInputError);
			// 将过滤后的数据发回客户端
			String contentAfterFilt = Globals.getDirtFilterService().filt(content);
			gcSendMailMsg.setTitle(cgSendGuildMail.getTitle());
			gcSendMailMsg.setContent(contentAfterFilt);
			human.sendMessage(gcSendMailMsg);
			return;
		}
		
		// 记录行为次数，军团邮件发一次算一封
		//human.getBehaviorManager().doBehavior(BehaviorTypeEnum.MAIL_SEND);
		
		// 发送军团邮件
		Globals.getMailService().sendCorpsMail(human, sender.getCorps(), title, content);
		 
		GCSendMail gcSendMail = new GCSendMail();
		gcSendMail.setResult(ResultTypes.SUCCESS.val);
		human.sendMessage(gcSendMail);
		human.sendErrorMessage(LangConstants.MAIL_SEND_SUCCESS_INFO);
	}

	/**
	 * 领取邮件的附件
	 * @param player
	 * @param cgGetMailAttachment
	 */
	public void handleGetMailAttachment(Player player, CGGetMailAttachment cgGetMailAttachment) {
		if (!checkCond(player)) {
			return;
		}
		if (cgGetMailAttachment.getUuid() == null || cgGetMailAttachment.getUuid().equalsIgnoreCase("")) {
			return;
		}
		
		Globals.getMailService().getMailAttachment(player.getHuman(), cgGetMailAttachment.getUuid());
	}
	
	/**
	 * 条件检查，玩家是否在线，邮件功能是否开启
	 * @param player
	 * @return
	 */
	protected boolean checkCond(Player player) {
		if (player == null || player.getHuman() == null) {
			return false;
		}
		// 判断邮件功能是否开启
		if (!Globals.getFuncService().hasOpenedFunc(player.getHuman(), FuncTypeEnum.MAIL)) {
			Loggers.humanLogger.warn("player not open func " + FuncTypeEnum.MAIL);
			return false;
		}
		return true;
	}
}
