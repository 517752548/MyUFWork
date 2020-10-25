package com.renren.games.api.db.model;

import com.renren.games.api.annotation.Comment;
import org.hibernate.annotations.GenericGenerator;

import javax.persistence.*;
import java.sql.Timestamp;

/**
 * Created by wyn on 16/2/29.
 */
@Entity
@Table(name = "t_user_info")
@Comment(content="DB用户信息")
public class TUserInfoEntity implements BaseEntity<Long> {
    /** 玩家角色ID 主键 */
    @Comment(content="id")
    private Long id;

    @Comment(content="name")
    private String name;

    @Comment(content="password")
    private String password;

    @Comment(content="createTime")
    private Timestamp createTime;

    @Comment(content="lastLoginTime")
    private Timestamp lastLoginTime;


    @Override
    @Column(columnDefinition = "BIGINT(20)")
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    public Long getId() {
        return id;
    }

    @Override
    public void setId(Long id) {
        this.id = id;
    }
    @Column(columnDefinition = "VARCHAR(255)")
    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }
    @Column(columnDefinition = "VARCHAR(255)")
    public String getPassword() {
        return password;
    }

    public void setPassword(String password) {
        this.password = password;
    }

    public Timestamp getCreateTime() {
        return createTime;
    }
    @Column(columnDefinition = "datetime")
    public void setCreateTime(Timestamp createTime) {
        this.createTime = createTime;
    }

    public Timestamp getLastLoginTime() {
        return lastLoginTime;
    }
    @Column(columnDefinition = "datetime")
    public void setLastLoginTime(Timestamp lastLoginTime) {
        this.lastLoginTime = lastLoginTime;
    }
}
