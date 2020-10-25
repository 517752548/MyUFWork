package com.imop.lj.gm.autolog.model;
import java.util.List;
import com.imop.lj.gm.model.log.BaseLog;
/**
 * This is an auto generated source,please don't modify it.
 */
 
public class GmCommandLog extends BaseLog{

	//操作者姓名
    private String operatorName;
	//目标机器
    private String targetIp;
	//命令
    private String command;
	//命令描述
    private String commandDesc;
	//命令内容
    private String commandDetail;
	//返回结果
    private String returnResult;

	@SuppressWarnings("unchecked")
	@Override
	public List toList(){
		List list = super.toList();
		list.add(operatorName);
		list.add(targetIp);
		list.add(command);
		list.add(commandDesc);
		list.add(commandDetail);
		list.add(returnResult);
		return list;
	}
	
	public String getOperatorName() {
		return operatorName;
	}
	public String getTargetIp() {
		return targetIp;
	}
	public String getCommand() {
		return command;
	}
	public String getCommandDesc() {
		return commandDesc;
	}
	public String getCommandDetail() {
		return commandDetail;
	}
	public String getReturnResult() {
		return returnResult;
	}
        
	public void setOperatorName(String operatorName) {
		this.operatorName = operatorName;
	}
	public void setTargetIp(String targetIp) {
		this.targetIp = targetIp;
	}
	public void setCommand(String command) {
		this.command = command;
	}
	public void setCommandDesc(String commandDesc) {
		this.commandDesc = commandDesc;
	}
	public void setCommandDetail(String commandDetail) {
		this.commandDetail = commandDetail;
	}
	public void setReturnResult(String returnResult) {
		this.returnResult = returnResult;
	}

}