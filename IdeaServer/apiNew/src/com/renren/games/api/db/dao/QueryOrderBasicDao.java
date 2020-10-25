package com.renren.games.api.db.dao;

import com.renren.games.api.db.DBService;
import com.renren.games.api.db.model.QueryOrderEntity;

import java.util.List;

/**
 * Created by wyn on 16/2/29.
 */
public class QueryOrderBasicDao extends BaseDao<QueryOrderEntity> {

    private String GET_USER_BY_NAME = "getuserchargeorder";
    private String GET_CHARGE_ORDER_BY_ID = "getchargeorderbyid";
    private String GET_CHARGE_ORDER_BY_ORDERID = "getchargeorderbyorderid";
    private String GET_USER_BY_CHATID = "getuserchargebycharid";
    private final String[] GET_USER_BY_NAME_PARAMS = new String[]{"userid"};
    private final String[] GET_USER_BY_CHARID_PARAMS = new String[]{"char_id"};
    private final String[] GET_CHARGE_ORDER_BY_ID_PARAMS = new String[]{"id"};
    private final String[] GET_CHARGE_ORDER_BY_ORDERID_PARAMS = new String[]{"orderid"};
    public QueryOrderBasicDao(DBService dbService){
        super(dbService);
    }
    @Override
    protected Class<QueryOrderEntity> getEntityClass() {
        return QueryOrderEntity.class;
    }

    public List<QueryOrderEntity> getChargeOrderListByUserId(String userid){
        List<QueryOrderEntity> tlist = this.dbService.findByNamedQueryAndNamedParam(GET_USER_BY_NAME,GET_USER_BY_NAME_PARAMS,new Object[]{userid});

        return tlist;
    }
    public List<QueryOrderEntity> getChargeOrderListByCharId(String charid){
        List<QueryOrderEntity> tlist = this.dbService.findByNamedQueryAndNamedParam(GET_USER_BY_CHATID,GET_USER_BY_CHARID_PARAMS,new Object[]{charid});

        return tlist;
    }
    public QueryOrderEntity getChargeOrderEntityById(Long id){
        List<QueryOrderEntity> tlist = this.dbService.findByNamedQueryAndNamedParam(GET_CHARGE_ORDER_BY_ID, GET_CHARGE_ORDER_BY_ID_PARAMS,new Object[]{id});
        if(tlist==null || tlist.size()==0){
            return null;
        }
        return tlist.get(0);
    }

    public QueryOrderEntity getChargeOrderEntityByOrderId(String orderid){
        List<QueryOrderEntity> tlist = this.dbService.findByNamedQueryAndNamedParam(GET_CHARGE_ORDER_BY_ORDERID, GET_CHARGE_ORDER_BY_ORDERID_PARAMS,new Object[]{orderid});
        if(tlist==null || tlist.size()==0){
            return null;
        }
        return tlist.get(0);
    }


}
