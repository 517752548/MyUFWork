package com.imop.lj.core.msg;

import java.util.List;

public interface ISliceMessage<T extends BaseMessage> {

	public abstract List<T> getSliceMessages();

}