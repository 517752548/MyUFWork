package com.imop.lj.gameserver.equip.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 打造信息
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCEqpCraftInfo extends GCMessage{
	
	/** 打造花费模板Id */
	private int costTplId;
	/** 阶数 */
	private int gradeId;
	/** 打造数据 */
	private com.imop.lj.common.model.equip.CraftInfo craftInfo;

	public GCEqpCraftInfo (){
	}
	
	public GCEqpCraftInfo (
			int costTplId,
			int gradeId,
			com.imop.lj.common.model.equip.CraftInfo craftInfo ){
			this.costTplId = costTplId;
			this.gradeId = gradeId;
			this.craftInfo = craftInfo;
	}

	@Override
	protected boolean readImpl() {

	// 打造花费模板Id
	int _costTplId = readInteger();
	//end


	// 阶数
	int _gradeId = readInteger();
	//end

	// 打造数据
	com.imop.lj.common.model.equip.CraftInfo _craftInfo = new com.imop.lj.common.model.equip.CraftInfo();

	// 基础属性key
	int _craftInfo_baseAttrKey = readInteger();
	//end
	_craftInfo.setBaseAttrKey (_craftInfo_baseAttrKey);

	// 基础属性数值
	int _craftInfo_baseAttrValue = readInteger();
	//end
	_craftInfo.setBaseAttrValue (_craftInfo_baseAttrValue);

	// 最大孔数
	int _craftInfo_holeMaxNum = readInteger();
	//end
	_craftInfo.setHoleMaxNum (_craftInfo_holeMaxNum);

	// 大概率属性列表
	int craftInfo_craftAttrInfosSize = readUnsignedShort();
	com.imop.lj.common.model.equip.CraftAttrInfo[] _craftInfo_craftAttrInfos = new com.imop.lj.common.model.equip.CraftAttrInfo[craftInfo_craftAttrInfosSize];
	int craftInfo_craftAttrInfosIndex = 0;
	for(craftInfo_craftAttrInfosIndex=0; craftInfo_craftAttrInfosIndex<craftInfo_craftAttrInfosSize; craftInfo_craftAttrInfosIndex++){
		_craftInfo_craftAttrInfos[craftInfo_craftAttrInfosIndex] = new com.imop.lj.common.model.equip.CraftAttrInfo();
	// 属性key
	int _craftInfo_craftAttrInfos_attrKey = readInteger();
	//end
	_craftInfo_craftAttrInfos[craftInfo_craftAttrInfosIndex].setAttrKey (_craftInfo_craftAttrInfos_attrKey);

	// 属性最小值
	int _craftInfo_craftAttrInfos_min = readInteger();
	//end
	_craftInfo_craftAttrInfos[craftInfo_craftAttrInfosIndex].setMin (_craftInfo_craftAttrInfos_min);

	// 属性最大值
	int _craftInfo_craftAttrInfos_max = readInteger();
	//end
	_craftInfo_craftAttrInfos[craftInfo_craftAttrInfosIndex].setMax (_craftInfo_craftAttrInfos_max);

	// 属性概率*100
	int _craftInfo_craftAttrInfos_prob = readInteger();
	//end
	_craftInfo_craftAttrInfos[craftInfo_craftAttrInfosIndex].setProb (_craftInfo_craftAttrInfos_prob);
	}
	//end
	_craftInfo.setCraftAttrInfos (_craftInfo_craftAttrInfos);

	// 属性条数列表
	int craftInfo_craftAttrNumInfosSize = readUnsignedShort();
	com.imop.lj.common.model.equip.CraftAttrNumInfo[] _craftInfo_craftAttrNumInfos = new com.imop.lj.common.model.equip.CraftAttrNumInfo[craftInfo_craftAttrNumInfosSize];
	int craftInfo_craftAttrNumInfosIndex = 0;
	for(craftInfo_craftAttrNumInfosIndex=0; craftInfo_craftAttrNumInfosIndex<craftInfo_craftAttrNumInfosSize; craftInfo_craftAttrNumInfosIndex++){
		_craftInfo_craftAttrNumInfos[craftInfo_craftAttrNumInfosIndex] = new com.imop.lj.common.model.equip.CraftAttrNumInfo();
	// 属性个数
	int _craftInfo_craftAttrNumInfos_num = readInteger();
	//end
	_craftInfo_craftAttrNumInfos[craftInfo_craftAttrNumInfosIndex].setNum (_craftInfo_craftAttrNumInfos_num);

	// 概率*100
	int _craftInfo_craftAttrNumInfos_prob = readInteger();
	//end
	_craftInfo_craftAttrNumInfos[craftInfo_craftAttrNumInfosIndex].setProb (_craftInfo_craftAttrNumInfos_prob);
	}
	//end
	_craftInfo.setCraftAttrNumInfos (_craftInfo_craftAttrNumInfos);



		this.costTplId = _costTplId;
		this.gradeId = _gradeId;
		this.craftInfo = _craftInfo;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 打造花费模板Id
	writeInteger(costTplId);


	// 阶数
	writeInteger(gradeId);


	int craftInfo_baseAttrKey = craftInfo.getBaseAttrKey ();

	// 基础属性key
	writeInteger(craftInfo_baseAttrKey);

	int craftInfo_baseAttrValue = craftInfo.getBaseAttrValue ();

	// 基础属性数值
	writeInteger(craftInfo_baseAttrValue);

	int craftInfo_holeMaxNum = craftInfo.getHoleMaxNum ();

	// 最大孔数
	writeInteger(craftInfo_holeMaxNum);

	com.imop.lj.common.model.equip.CraftAttrInfo[] craftInfo_craftAttrInfos = craftInfo.getCraftAttrInfos ();

	// 大概率属性列表
	writeShort(craftInfo_craftAttrInfos.length);
	int craftInfo_craftAttrInfosIndex = 0;
	int craftInfo_craftAttrInfosSize = craftInfo_craftAttrInfos.length;
	for(craftInfo_craftAttrInfosIndex=0; craftInfo_craftAttrInfosIndex<craftInfo_craftAttrInfosSize; craftInfo_craftAttrInfosIndex++){

	int craftInfo_craftAttrInfos_attrKey = craftInfo_craftAttrInfos[craftInfo_craftAttrInfosIndex].getAttrKey();

	// 属性key
	writeInteger(craftInfo_craftAttrInfos_attrKey);

	int craftInfo_craftAttrInfos_min = craftInfo_craftAttrInfos[craftInfo_craftAttrInfosIndex].getMin();

	// 属性最小值
	writeInteger(craftInfo_craftAttrInfos_min);

	int craftInfo_craftAttrInfos_max = craftInfo_craftAttrInfos[craftInfo_craftAttrInfosIndex].getMax();

	// 属性最大值
	writeInteger(craftInfo_craftAttrInfos_max);

	int craftInfo_craftAttrInfos_prob = craftInfo_craftAttrInfos[craftInfo_craftAttrInfosIndex].getProb();

	// 属性概率*100
	writeInteger(craftInfo_craftAttrInfos_prob);
	}
	//end

	com.imop.lj.common.model.equip.CraftAttrNumInfo[] craftInfo_craftAttrNumInfos = craftInfo.getCraftAttrNumInfos ();

	// 属性条数列表
	writeShort(craftInfo_craftAttrNumInfos.length);
	int craftInfo_craftAttrNumInfosIndex = 0;
	int craftInfo_craftAttrNumInfosSize = craftInfo_craftAttrNumInfos.length;
	for(craftInfo_craftAttrNumInfosIndex=0; craftInfo_craftAttrNumInfosIndex<craftInfo_craftAttrNumInfosSize; craftInfo_craftAttrNumInfosIndex++){

	int craftInfo_craftAttrNumInfos_num = craftInfo_craftAttrNumInfos[craftInfo_craftAttrNumInfosIndex].getNum();

	// 属性个数
	writeInteger(craftInfo_craftAttrNumInfos_num);

	int craftInfo_craftAttrNumInfos_prob = craftInfo_craftAttrNumInfos[craftInfo_craftAttrNumInfosIndex].getProb();

	// 概率*100
	writeInteger(craftInfo_craftAttrNumInfos_prob);
	}
	//end


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_EQP_CRAFT_INFO;
	}
	
	@Override
	public String getTypeName() {
		return "GC_EQP_CRAFT_INFO";
	}

	public int getCostTplId(){
		return costTplId;
	}
		
	public void setCostTplId(int costTplId){
		this.costTplId = costTplId;
	}

	public int getGradeId(){
		return gradeId;
	}
		
	public void setGradeId(int gradeId){
		this.gradeId = gradeId;
	}

	public com.imop.lj.common.model.equip.CraftInfo getCraftInfo(){
		return craftInfo;
	}
		
	public void setCraftInfo(com.imop.lj.common.model.equip.CraftInfo craftInfo){
		this.craftInfo = craftInfo;
	}
}