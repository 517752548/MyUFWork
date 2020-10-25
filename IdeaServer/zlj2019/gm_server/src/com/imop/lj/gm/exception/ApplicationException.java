
package com.imop.lj.gm.exception;


@SuppressWarnings("serial")
public class ApplicationException extends Exception {
	private String msg;
	private int errCode;

	public ApplicationException(){
		super();
	}
	public ApplicationException(int errCode,String msg){
		super(msg);
		this.msg=msg;
		this.errCode=errCode;
	}

	public ApplicationException(int errCode,String msg,Throwable cause){
		super(msg,cause);
		this.msg=msg;
		this.errCode=errCode;
	}

	public ApplicationException(int errCode,Throwable cause){
		super(cause);
		this.errCode=errCode;
	}
	public String getMsg() {
		return msg;
	}
	public void setMsg(String msg) {
		this.msg = msg;
	}
	public int getErrCode() {
		return errCode;
	}
	public void setErrCode(int errCode) {
		this.errCode = errCode;
	}
}
