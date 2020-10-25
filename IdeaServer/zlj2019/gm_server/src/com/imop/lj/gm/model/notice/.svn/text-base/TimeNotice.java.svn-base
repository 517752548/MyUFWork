package com.imop.lj.gm.model.notice;

import java.io.Serializable;
import java.sql.Timestamp;

import net.sf.json.JSONObject;

import com.imop.lj.gm.constants.NoticeConstants.ChatNoticeSubType;
import com.imop.lj.gm.constants.NoticeConstants.NoticeType;
import com.imop.lj.gm.service.xls.ExcelLangManagerService;
import com.imop.lj.gm.utils.StringUtil;

/**
 * 定时公告
 * @author linfan
 *
 */
public class TimeNotice implements Serializable {

	private static final long serialVersionUID = -3871334485197341321L;

	/** id */
	private int id;

	/** 开始时间 */
	private Timestamp startTime;

	/** 结束时间 */
	private Timestamp endTime;

	/** 间隔 */
	private int intervalTime;

	/** server_id */
	private String serverIds;

	/** 内容*/
	private String content;

	/** 操作员 */
	private String operator;

	/** 定时公告:0,全服开启;1,按线开启 */
	private byte openType;

	/** 公告的显示类型：0-系统公告 1-聊天公告 */
	private byte type;

	/** 公告的子类型 0-默认 1-公告 2-GM喊话 3-NPC喊话 4-其他 */
	private byte subType;

	/**
	 * 创建公告命令
	 *
	 * @param notice
	 * @return
	 */
	public static String createNoticeCmd(TimeNotice notice) {
		String _content = notice.getContent();
		int _type = notice.getType();

		JSONObject _o = new JSONObject();
		//我们的游戏公告无需服务器id
		//_o.put("ids", notice.getServerIds());
		if(_type == NoticeType.CHAT_NOTICE.getIndex()){
			_o.put("type", "" + NoticeType.CHAT_NOTICE.getShowType());
			ChatNoticeSubType _subType = ChatNoticeSubType.indexOf(notice.getSubType());
			String _subTypeName = ExcelLangManagerService.readGmLang(_subType.getLangId());
			_content = _subTypeName + _content;
		}

		_o.put("content", _content);
		String _cmd = "notice " + _o.toString();
		return _cmd;
	}

	public byte getType() {
		return type;
	}

	public void setType(byte type) {
		this.type = type;
	}

	public byte getSubType() {
		return subType;
	}

	public void setSubType(byte subType) {
		this.subType = subType;
	}

	public byte getOpenType() {
		return openType;
	}

	public void setOpenType(byte openType) {
		this.openType = openType;
	}

	public int getId() {
		return id;
	}

	public void setId(int id) {
		this.id = id;
	}

	public Timestamp getStartTime() {
		return startTime;
	}

	public void setStartTime(Timestamp startTime) {
		this.startTime = startTime;
	}

	public Timestamp getEndTime() {
		return endTime;
	}

	public void setEndTime(Timestamp endTime) {
		this.endTime = endTime;
	}

	public int getIntervalTime() {
		return intervalTime;
	}

	public void setIntervalTime(int intervalTime) {
		this.intervalTime = intervalTime;
	}

	public String getServerIds() {
		return serverIds;
	}

	public void setServerIds(String serverIds) {
		this.serverIds = serverIds;
	}

	public String getContent() {
		return StringUtil.filterContent(content);
	}

	public void setContent(String content) {
		this.content = content;
	}

	public String getOperator() {
		return operator;
	}

	public void setOperator(String operator) {
		this.operator = operator;
	}

}
