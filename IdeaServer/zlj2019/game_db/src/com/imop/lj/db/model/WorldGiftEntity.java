package com.imop.lj.db.model;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.Table;

import com.imop.lj.core.annotation.Comment;
import com.imop.lj.core.orm.BaseEntity;

/**
 * @author : bing.dong E-mail: dawson119@163.com
 * @createTime : 2014年6月27日 下午12:15:34
 * @version 1.0
 */
@Entity
@Table(name = "t_world_gift")
@Comment(content="数据库实体类：全服礼包")
public class WorldGiftEntity implements BaseEntity<Integer> {
	
	private static final long serialVersionUID = 1L;
	
	@Comment(content="id")
	private Integer id;
	@Comment(content="礼包id")
	private Integer giftId;
	@Comment(content="礼包名称")
	private String giftName;
	@Comment(content="奖励物品参数")
	private String giftParams;
	@Comment(content="创建时间")
	private Long createTime;
	@Comment(content="是否删除")
	private int isDel;
	
	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	@Override
	public Integer getId() {
		return id;
	}

	@Override
	public void setId(Integer id) {
		this.id = id;
	}
	
	@Column(columnDefinition = " int(11) default 0", nullable = false)
	public int getGiftId() {
		return giftId;
	}

	public void setGiftId(int giftId) {
		this.giftId = giftId;
	}

	@Column(columnDefinition = "varchar(255) default '' ", nullable = false)
	public String getGiftName() {
		return giftName;
	}

	public void setGiftName(String giftName) {
		this.giftName = giftName;
	}

	@Column(columnDefinition = "varchar(255) default '' ", nullable = false)
	public String getGiftParams() {
		return giftParams;
	}

	public void setGiftParams(String giftParams) {
		this.giftParams = giftParams;
	}

	@Column(columnDefinition = " bigint(20) default 0", nullable = false)
	public Long getCreateTime() {
		return createTime;
	}

	public void setCreateTime(long createTime) {
		this.createTime = createTime;
	}
	
	@Column(columnDefinition = " int(11) default 0", nullable = false)
	public int getIsDel() {
		return isDel;
	}

	public void setIsDel(int isDel) {
		this.isDel = isDel;
	}
}
