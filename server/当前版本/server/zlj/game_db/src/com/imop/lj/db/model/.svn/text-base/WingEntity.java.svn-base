package com.imop.lj.db.model;

import java.sql.Timestamp;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Id;
import javax.persistence.Table;

import com.imop.lj.core.annotation.Comment;
import com.imop.lj.core.orm.BaseEntity;


/**
 * 翅膀数据库实体对象
 * 
 */
@Entity
@Table(name = "t_wing_info")
@Comment(content="数据库实体类：翅膀")
public class WingEntity implements BaseEntity<String>, CharSubEntity {
	/** */
	private static final long serialVersionUID = 1L;

	/** 主键 UUID */
	@Comment(content="主键 UUID")
	private String id;
	
	@Comment(content="所属角色")
	private long charId;

    @Comment(content="templateId")
	private int templateId;
    
    @Comment(content="翅膀阶数")
    private int wingLevel;
    
    @Comment(content="翅膀祝福值")
    private int wingBless;
    
    @Comment(content="翅膀战斗力")
    private int wingPower;

    @Comment(content="是否已装备")
    private int equipped;

	@Comment(content="创建日期")
	private Timestamp createDate;


    @Id
	@Column(length = 36)
    @Override
    public String getId() {
        return id;
    }

    @Override
    public void setId(String aLong) {
        this.id = aLong;
    }

	@Override
	public long getCharId() {
		return charId;
	}
	
	@Column(columnDefinition = " int(11) default 0", nullable = false)
	public int getTemplateId() {
		return templateId;
	}

	public void setTemplateId(int templateId) {
		this.templateId = templateId;
	}
	
	@Column(columnDefinition = " int(2) default 0", nullable = false)
	public int getWingLevel() {
		return wingLevel;
	}

	public void setWingLevel(int wingLevel) {
		this.wingLevel = wingLevel;
	}

	@Column(columnDefinition = " int(5) default 0", nullable = false)
	public int getWingBless() {
		return wingBless;
	}

	public void setWingBless(int wingBless) {
		this.wingBless = wingBless;
	}
	
	public int getWingPower() {
		return wingPower;
	}
	
	@Column(columnDefinition = " int(5) default 0", nullable = false)
	public void setWingPower(int wingPower) {
		this.wingPower = wingPower;
	}

	@Column(columnDefinition = " int(1) default 0", nullable = false)
	public int getEquipped() {
		return equipped;
	}

	public void setEquipped(int equipped) {
		this.equipped = equipped;
	}

	public Timestamp getCreateDate() {
		return createDate;
	}

	public void setCreateDate(Timestamp createDate) {
		this.createDate = createDate;
	}

	public void setCharId(long charId) {
		this.charId = charId;
	}

    
}
