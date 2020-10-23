package com.imop.lj.gameserver.overman;

/**
 * Created by zhangzhe on 16/1/5.
 */
public class TempFireOvermanInfo {
    private long overmanCharId;
    private long lowermanCharId;
    private int overmanAgree = -1; //初始化-1,不同意0,同意1
    private int lowermanAgree = -1;

    public TempFireOvermanInfo(long overmanCharId,long lowermanCharId){
        this.overmanCharId = overmanCharId;
        this.lowermanCharId = lowermanCharId;
        this.overmanAgree = -1 ;
        this.lowermanAgree = -1;
    }

    public long getOvermanCharId() {
        return overmanCharId;
    }

    public void setOvermanCharId(long overmanCharId) {
        this.overmanCharId = overmanCharId;
    }

    public long getLowermanCharId() {
        return lowermanCharId;
    }

    public void setLowermanCharId(long lowermanCharId) {
        this.lowermanCharId = lowermanCharId;
    }

    public int getOvermanAgree() {
        return overmanAgree;
    }

    public void setOvermanAgree(int overmanAgree) {
        this.overmanAgree = overmanAgree;
    }

    public int getLowermanAgree() {
        return lowermanAgree;
    }

    public void setLowermanAgree(int lowermanAgree) {
        this.lowermanAgree = lowermanAgree;
    }

    public boolean bothcanagree(){
        return (this.overmanAgree == 1) && (this.lowermanAgree == 1);
    }
    public boolean needreturn(){
        return (this.overmanAgree != -1) && (this.lowermanAgree != -1);
    }
}
