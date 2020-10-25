package com.imop.lj.gameserver.mail.msg;

import java.text.Format;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.List;

import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.common.constants.ResultTypes;
import com.imop.lj.common.model.mail.MailInfo;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.mail.MailInstance;

public class MailMsgBuilder {
	
	public final static Format formatCreate = new SimpleDateFormat(Globals.getLangService().readSysLang(LangConstants.MAIL_DATE_SEND_FORMAT));
	public final static Format formatDel = new SimpleDateFormat(Globals.getLangService().readSysLang(LangConstants.MAIL_DATE_DEL_TIME_FORMAT));

	public static GCMailList buildGCMailList(int boxType, int page, int maxPage, List<MailInstance> resultList) {
		GCMailList gcMailList = new GCMailList();
		gcMailList.setBoxType(boxType);
		gcMailList.setQueryIndex(page);
		gcMailList.setTotalNums(maxPage);
		List<MailInfo> mailInfoList = new ArrayList<MailInfo>();
		for (MailInstance instance : resultList) {
			mailInfoList.add(createMailInfo(instance));
		}
		gcMailList.setMailInfos(mailInfoList.toArray(new MailInfo[0]));
		return gcMailList;
	}
	
	public static GCMailUpdate buildGCMailUpdate(MailInstance mail) {
		GCMailUpdate gcMailUpdate = new GCMailUpdate();
		gcMailUpdate.setMail(createMailInfo(mail));
		return gcMailUpdate;
	}

	public static MailInfo createMailInfo(MailInstance mail) {
		MailInfo mailInfo = new MailInfo();
		mailInfo.setUuid(mail.getMailUUID());
		mailInfo.setSenderName(mail.getSendName());
		mailInfo.setMailType(mail.getMailType().getIndex());
		mailInfo.setMailStatus(mail.getMailStatus().getIndex());
		mailInfo.setTitle(mail.getTitle());
		mailInfo.setContent(mail.getContent());
		mailInfo.setCreateTime(formatCreate.format(mail.getCreateTime()));
		mailInfo.setDeleteTime(formatDel.format(mail.getExpiredTime()));
		mailInfo.setUpdateTime(mail.getUpdateTime().getTime());
		mailInfo.setAttachmented(mail.hasAttachment() ? 1 : 0);
		mailInfo.setRecName(mail.getRecName());
		// 附件奖励信息
		mailInfo.setRewardInfo(Globals.getRewardService().convertReward(mail.getAttachmentReward()));
		return mailInfo;
	}
	
	/**
	 * 构建删除邮件成功的消息
	 * @return
	 */
	public static GCDelMail buildGCDelMail() {
		return new GCDelMail(ResultTypes.SUCCESS.val);
	}

}
