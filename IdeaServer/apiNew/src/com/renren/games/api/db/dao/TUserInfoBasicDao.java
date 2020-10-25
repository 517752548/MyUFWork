package com.renren.games.api.db.dao;

import com.renren.games.api.db.DBService;
import com.renren.games.api.db.model.TUserInfoEntity;

import java.util.List;

/**
 * Created by wyn on 16/2/29.
 */
public class TUserInfoBasicDao extends BaseDao<TUserInfoEntity> {

    private String GET_USER_BY_NAME = "getuserbyname";
    private final String[] GET_USER_BY_NAME_PARAMS = new String[]{"name"};

    public TUserInfoBasicDao(DBService dbService){
        super(dbService);
    }
    @Override
    protected Class<TUserInfoEntity> getEntityClass() {
        return TUserInfoEntity.class;
    }

    public TUserInfoEntity getTUserInfoByName(String name){
        List<TUserInfoEntity> tlist = this.dbService.findByNamedQueryAndNamedParam(GET_USER_BY_NAME,GET_USER_BY_NAME_PARAMS,new Object[]{name});
        if(tlist==null || tlist.size()==0){
            return null;
        }
        return tlist.get(0);
    }

}
