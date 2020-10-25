package com.renren.games.api.db.model;

import com.renren.games.api.annotation.Comment;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Id;
import javax.persistence.Table;

/**
 * Created by wyn on 16/2/29.
 */
@Entity
@Table(name = "t_cdkey")
@Comment(content="cdkey")
public class TCDKeyEntity implements BaseEntity<String> {
    /** 玩家角色ID 主键 */
    @Comment(content="id")
    private String id;

    @Comment(content="cdtype")
    private String cdtype;

    @Comment(content="userid")
    private String userid;

    @Comment(content="itemid")
    private String itemid;


    @Override
    @Column(columnDefinition = "VARCHAR(32)")
    @Id
    public String getId() {
        return id;
    }
    @Override
    public void setId(String id) {
        this.id = id;
    }
    @Column(columnDefinition = "VARCHAR(32)")
    public String getCdtype() {
        return cdtype;
    }

    public void setCdtype(String cdtype) {
        this.cdtype = cdtype;
    }
    @Column(columnDefinition = "VARCHAR(32)")
    public String getUserid() {
        return userid;
    }
    public void setUserid(String userid) {
        this.userid = userid;
    }

    @Column(columnDefinition = "VARCHAR(32)")
    public String getItemid() {
        return itemid;
    }

    public void setItemid(String itemid) {
        this.itemid = itemid;
    }
}
