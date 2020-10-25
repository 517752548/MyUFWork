package com.renren.games.api.db.dao;

import com.renren.games.api.db.DBService;
import com.renren.games.api.db.model.TCDKeyEntity;
import com.renren.games.api.db.model.TUserInfoEntity;

import java.util.List;

/**
 * Created by wyn on 16/2/29.
 */
public class TCDkeyBasicDao extends BaseDao<TCDKeyEntity> {

    private String GET_TCDKEY_BY_CDKEY = "gettcdkeylistbycdtype";
    private final String[] GET_TCDKEY_BY_CDKEY_PARAMS = new String[]{"cdtype","userid"};

    public TCDkeyBasicDao(DBService dbService){
        super(dbService);
    }
    @Override
    protected Class<TCDKeyEntity> getEntityClass() {
        return TCDKeyEntity.class;
    }

    public List<TCDKeyEntity> getTCDKeyByCDTypeUser(String userid,String cdtype){
        return this.dbService.findByNamedQueryAndNamedParam(GET_TCDKEY_BY_CDKEY,GET_TCDKEY_BY_CDKEY_PARAMS,new Object[]{cdtype,userid});
    }






}
