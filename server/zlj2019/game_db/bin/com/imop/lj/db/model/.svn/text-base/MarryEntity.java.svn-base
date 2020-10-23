package com.imop.lj.db.model;

import javax.persistence.Entity;
import javax.persistence.Id;
import javax.persistence.Table;

import com.imop.lj.core.annotation.Comment;
import com.imop.lj.core.orm.BaseEntity;

/**
 * 结婚数据库实体对象
 * 
 */
@Entity
@Table(name = "t_marry_info")
@Comment(content="数据库实体类：婚姻")
public class MarryEntity implements BaseEntity<Long> {
	/** */
	private static final long serialVersionUID = 1L;
	/** 主键 UUID */
	@Comment(content="主键 UUID,队长的id,丈夫")
	private Long id;

    @Comment(content = "妻子的id")
    private Long charId;

    @Comment(content="婚姻状态，1未婚2已婚3离婚")
	private int maritalStatus;
    
    @Comment(content = "婚姻相关信息")
    private String marryProps;

    @Override
	public void setId(Long id) {
		this.id = id;
	}

    @Id
    @Override
	public Long getId() {
		return id;
	}

	public void setCharId(Long charId) {
		this.charId = charId;
	}

	public Long getCharId() {
		return charId;
	}

	public void setCharId(long charId) {
		this.charId = charId;
	}

	public int getMaritalStatus() {
		return maritalStatus;
	}

	public void setMaritalStatus(int maritalStatus) {
		this.maritalStatus = maritalStatus;
	}

	public String getMarryProps() {
		return marryProps;
	}

	public void setMarryProps(String marryProps) {
		this.marryProps = marryProps;
	}

	public static long getSerialversionuid() {
		return serialVersionUID;
	}

}
