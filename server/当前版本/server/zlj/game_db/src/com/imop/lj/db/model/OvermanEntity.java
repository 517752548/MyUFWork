package com.imop.lj.db.model;

import com.imop.lj.core.annotation.Comment;
import com.imop.lj.core.orm.BaseEntity;
import com.imop.lj.core.orm.SoftDeleteEntity;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Id;
import javax.persistence.Table;
import java.sql.Timestamp;


/**
 * 宠物数据库实体对象
 * 
 */
@Entity
@Table(name = "t_overman_info")
@Comment(content="数据库实体类：师徒")
public class OvermanEntity implements BaseEntity<Long> {
	/** */
	private static final long serialVersionUID = 6931213926527000159L;

	/** 主键 UUID */
	@Comment(content="主键 UUID,自增长")
	private Long id;

    @Comment(content = "师徒相关信息")
    private String overmanProps;


    @Id
    @Override
    public Long  getId() {
        return id;
    }

    @Override
    public void setId(Long aLong) {
        this.id = aLong;
    }



    @Column(columnDefinition = "TEXT")
    public String getOvermanProps() {
        return overmanProps;
    }

    public void setOvermanProps(String overmanProps) {
        this.overmanProps = overmanProps;
    }

}
