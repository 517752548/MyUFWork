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
@Table(name = "t_title_info")
@Comment(content="数据库实体类：称号")
public class TitleEntity implements BaseEntity<Long> {
	/** */
	private static final long serialVersionUID = 6931213926527000159L;

    @Comment(content="所属角色")
    private long id;

    @Comment(content="正在使用的称号")
	private int inUseTplid;

    @Comment(content = "是否隐藏称号")
    private int disTitle;

    @Comment(content = "titleInfoProps")
    private String titleInfoProps;
    @Id
    @Override
    public Long getId() {
        return id;
    }

    @Override
    public void setId(Long aLong) {
        this.id = aLong;
    }

    public int getDisTitle() {
        return disTitle;
    }

    public void setDisTitle(int disTitle) {
        this.disTitle = disTitle;
    }

    public int getInUseTplid() {
        return inUseTplid;
    }

    public void setInUseTplid(int inUseTplid) {
        this.inUseTplid = inUseTplid;
    }

    @Column(columnDefinition = "TEXT")
    public String getTitleInfoProps() {
        return titleInfoProps;
    }

    public void setTitleInfoProps(String titleInfoProps) {
        this.titleInfoProps = titleInfoProps;
    }
}
