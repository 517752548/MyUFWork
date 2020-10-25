package com.renren.games.api.db.model;

import com.renren.games.api.annotation.Comment;

import javax.persistence.*;

/**
 * Created by wyn on 16/2/29.
 */
@Entity
@Table(name = "t_queryorder")
@Comment(content="queryorder")
public class QueryOrderEntity implements BaseEntity<Long> {
    /** 商户订单号主键 */
    @Comment(content="id")
    private Long id;

    @Comment(content="user_id")
    private String userid;

    @Comment(content="user_name")
    private String username;

    @Comment(content="order_id 第三方订单号")
    private String orderid;

    @Comment(content="amount")
    private String amount;

    @Comment(content="currency")
    private String currency;

    @Comment(content="item_id 套餐id")
    private String item_id;

    @Comment(content="game_points 充值金额")
    private String game_points;

    @Comment(content="type")
    private String type;

    @Comment(content="udid")
    private String udid;

    @Comment(content="device_id")
    private String device_id;

    @Comment(content="game_code 类似 ts")
    private String game_code;

    @Comment(content="game_domain 类似...")
    private String game_domain;

    @Comment(content="game_server_domain server_id")
    private String game_server_domain;

    @Comment(content="char_id")
    private String char_id;

    @Comment(content="char_name")
    private String char_name;

    @Comment(content="add_time 获取订单号的时间")
    private String add_time;

    @Comment(content="pay_time 充值时间")
    private String pay_time;

    @Comment(content="transfer_time 兑换时间")
    private String transfer_time;

    @Comment(content="terminal")
    private String terminal;

    @Comment(content="remark")
    private String remark;

    @Comment(content="status")
    private int status;

    @Comment(content="chargetype")
    private String chargetype;

    @Comment(content="pay_channel")
    private String pay_channel;

    @Comment(content="sub_channel")
    private String sub_channel;








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

    @Column(columnDefinition = "VARCHAR(32)")
    public String getUserid() {
        return userid;
    }

    public void setUserid(String userid) {
        this.userid = userid;
    }
    @Column(columnDefinition = "VARCHAR(32)")
    public String getUsername() {
        return username;
    }

    public void setUsername(String username) {
        this.username = username;
    }
    @Column(columnDefinition = "VARCHAR(32)")
    public String getOrderid() {
        return orderid;
    }

    public void setOrderid(String orderid) {
        this.orderid = orderid;
    }
    @Column(columnDefinition = "VARCHAR(32)")
    public String getAmount() {
        return amount;
    }

    public void setAmount(String amount) {
        this.amount = amount;
    }
    @Column(columnDefinition = "VARCHAR(32)")
    public String getCurrency() {
        return currency;
    }

    public void setCurrency(String currency) {
        this.currency = currency;
    }
    @Column(columnDefinition = "VARCHAR(32)")
    public String getItem_id() {
        return item_id;
    }

    public void setItem_id(String item_id) {
        this.item_id = item_id;
    }
    @Column(columnDefinition = "VARCHAR(32)")
    public String getGame_points() {
        return game_points;
    }

    public void setGame_points(String game_points) {
        this.game_points = game_points;
    }
    @Column(columnDefinition = "VARCHAR(32)")
    public String getType() {
        return type;
    }

    public void setType(String type) {
        this.type = type;
    }
    @Column(columnDefinition = "VARCHAR(32)")
    public String getUdid() {
        return udid;
    }

    public void setUdid(String udid) {
        this.udid = udid;
    }
    @Column(columnDefinition = "VARCHAR(32)")
    public String getDevice_id() {
        return device_id;
    }

    public void setDevice_id(String device_id) {
        this.device_id = device_id;
    }
    @Column(columnDefinition = "VARCHAR(32)")
    public String getGame_code() {
        return game_code;
    }

    public void setGame_code(String game_code) {
        this.game_code = game_code;
    }
    @Column(columnDefinition = "VARCHAR(32)")
    public String getGame_domain() {
        return game_domain;
    }

    public void setGame_domain(String game_domain) {
        this.game_domain = game_domain;
    }
    @Column(columnDefinition = "VARCHAR(32)")
    public String getGame_server_domain() {
        return game_server_domain;
    }

    public void setGame_server_domain(String game_server_domain) {
        this.game_server_domain = game_server_domain;
    }
    @Column(columnDefinition = "VARCHAR(32)")
    public String getChar_id() {
        return char_id;
    }

    public void setChar_id(String char_id) {
        this.char_id = char_id;
    }
    @Column(columnDefinition = "VARCHAR(32)")
    public String getChar_name() {
        return char_name;
    }

    public void setChar_name(String char_name) {
        this.char_name = char_name;
    }
    @Column(columnDefinition = "VARCHAR(32)")
    public String getAdd_time() {
        return add_time;
    }

    public void setAdd_time(String add_time) {
        this.add_time = add_time;
    }
    @Column(columnDefinition = "VARCHAR(32)")
    public String getPay_time() {
        return pay_time;
    }

    public void setPay_time(String expend_time) {
        this.pay_time = expend_time;
    }
    @Column(columnDefinition = "VARCHAR(32)")
    public String getTransfer_time() {
        return transfer_time;
    }

    public void setTransfer_time(String delay_time) {
        this.transfer_time = delay_time;
    }
    @Column(columnDefinition = "VARCHAR(32)")
    public String getTerminal() {
        return terminal;
    }

    public void setTerminal(String terminal) {
        this.terminal = terminal;
    }
    @Column(columnDefinition = "VARCHAR(32)")
    public String getRemark() {
        return remark;
    }

    public void setRemark(String remark) {
        this.remark = remark;
    }
    @Column(columnDefinition = "Integer")
    public int getStatus() {
        return status;
    }

    public void setStatus(int status) {
        this.status = status;
    }

    @Column(columnDefinition = "VARCHAR(32)")
    public String getChargetype() {
        return chargetype;
    }

    public void setChargetype(String chargetype) {
        this.chargetype = chargetype;
    }

    @Column(columnDefinition = "VARCHAR(32)")
    public String getPay_channel() {
        return pay_channel;
    }

    public void setPay_channel(String pay_channel) {
        this.pay_channel = pay_channel;
    }

    @Column(columnDefinition = "VARCHAR(32)")
    public String getSub_channel() {
        return sub_channel;
    }

    public void setSub_channel(String sub_channel) {
        this.sub_channel = sub_channel;
    }

    @Override
    public boolean equals(Object obj) {
        if(this == obj)
        {
            return true;
        }
        if(getClass()!=obj.getClass()){
            return false;
        }
       if(this.getId() == ((QueryOrderEntity)obj).getId()){
           return true;
       }
        return false;
    }
}
