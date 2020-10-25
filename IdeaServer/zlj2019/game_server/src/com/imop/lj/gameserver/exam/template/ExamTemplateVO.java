package com.imop.lj.gameserver.exam.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;
import com.imop.lj.core.util.StringUtils;

/**
 * 科举试题
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class ExamTemplateVO extends TemplateObject {

	/** 题目 */
	@ExcelCellBinding(offset = 1)
	protected String name;

	/** 科举类型 */
	@ExcelCellBinding(offset = 2)
	protected int typeId;

	/** 正确答案ID */
	@ExcelCellBinding(offset = 3)
	protected int rightAnswerID;

	/** 答案ID1 */
	@ExcelCellBinding(offset = 4)
	protected int firstAnswerID;

	/** 答案1 */
	@ExcelCellBinding(offset = 5)
	protected String firstAnswer;

	/** 答案ID2 */
	@ExcelCellBinding(offset = 6)
	protected int secendAnswerID;

	/** 答案2 */
	@ExcelCellBinding(offset = 7)
	protected String secendAnswer;

	/** 答案ID3 */
	@ExcelCellBinding(offset = 8)
	protected int thirdAnswerID;

	/** 答案3 */
	@ExcelCellBinding(offset = 9)
	protected String thirdAnswer;

	/** 答案ID4 */
	@ExcelCellBinding(offset = 10)
	protected int fourthAnswerID;

	/** 答案4 */
	@ExcelCellBinding(offset = 11)
	protected String fourthAnswer;

	/** 正确奖励ID */
	@ExcelCellBinding(offset = 12)
	protected int rightAnswerRewardId;

	/** 错误奖励ID */
	@ExcelCellBinding(offset = 13)
	protected int wrongAnswerRewardId;


	public String getName() {
		return this.name;
	}

	public void setName(String name) {
		if (name != null) {
			this.name = name.trim();
		}else{
			this.name = name;
		}
	}
	
	public int getTypeId() {
		return this.typeId;
	}

	public void setTypeId(int typeId) {
		this.typeId = typeId;
	}
	
	public int getRightAnswerID() {
		return this.rightAnswerID;
	}

	public void setRightAnswerID(int rightAnswerID) {
		if (rightAnswerID == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					4, "[正确答案ID]rightAnswerID不可以为0");
		}
		if (rightAnswerID < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					4, "[正确答案ID]rightAnswerID的值不得小于1");
		}
		this.rightAnswerID = rightAnswerID;
	}
	
	public int getFirstAnswerID() {
		return this.firstAnswerID;
	}

	public void setFirstAnswerID(int firstAnswerID) {
		if (firstAnswerID == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					5, "[答案ID1]firstAnswerID不可以为0");
		}
		if (firstAnswerID < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					5, "[答案ID1]firstAnswerID的值不得小于1");
		}
		this.firstAnswerID = firstAnswerID;
	}
	
	public String getFirstAnswer() {
		return this.firstAnswer;
	}

	public void setFirstAnswer(String firstAnswer) {
		if (StringUtils.isEmpty(firstAnswer)) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					6, "[答案1]firstAnswer不可以为空");
		}
		if (firstAnswer != null) {
			this.firstAnswer = firstAnswer.trim();
		}else{
			this.firstAnswer = firstAnswer;
		}
	}
	
	public int getSecendAnswerID() {
		return this.secendAnswerID;
	}

	public void setSecendAnswerID(int secendAnswerID) {
		if (secendAnswerID == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					7, "[答案ID2]secendAnswerID不可以为0");
		}
		if (secendAnswerID < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					7, "[答案ID2]secendAnswerID的值不得小于1");
		}
		this.secendAnswerID = secendAnswerID;
	}
	
	public String getSecendAnswer() {
		return this.secendAnswer;
	}

	public void setSecendAnswer(String secendAnswer) {
		if (StringUtils.isEmpty(secendAnswer)) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					8, "[答案2]secendAnswer不可以为空");
		}
		if (secendAnswer != null) {
			this.secendAnswer = secendAnswer.trim();
		}else{
			this.secendAnswer = secendAnswer;
		}
	}
	
	public int getThirdAnswerID() {
		return this.thirdAnswerID;
	}

	public void setThirdAnswerID(int thirdAnswerID) {
		if (thirdAnswerID == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					9, "[答案ID3]thirdAnswerID不可以为0");
		}
		if (thirdAnswerID < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					9, "[答案ID3]thirdAnswerID的值不得小于1");
		}
		this.thirdAnswerID = thirdAnswerID;
	}
	
	public String getThirdAnswer() {
		return this.thirdAnswer;
	}

	public void setThirdAnswer(String thirdAnswer) {
		if (StringUtils.isEmpty(thirdAnswer)) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					10, "[答案3]thirdAnswer不可以为空");
		}
		if (thirdAnswer != null) {
			this.thirdAnswer = thirdAnswer.trim();
		}else{
			this.thirdAnswer = thirdAnswer;
		}
	}
	
	public int getFourthAnswerID() {
		return this.fourthAnswerID;
	}

	public void setFourthAnswerID(int fourthAnswerID) {
		if (fourthAnswerID == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					11, "[答案ID4]fourthAnswerID不可以为0");
		}
		if (fourthAnswerID < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					11, "[答案ID4]fourthAnswerID的值不得小于1");
		}
		this.fourthAnswerID = fourthAnswerID;
	}
	
	public String getFourthAnswer() {
		return this.fourthAnswer;
	}

	public void setFourthAnswer(String fourthAnswer) {
		if (StringUtils.isEmpty(fourthAnswer)) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					12, "[答案4]fourthAnswer不可以为空");
		}
		if (fourthAnswer != null) {
			this.fourthAnswer = fourthAnswer.trim();
		}else{
			this.fourthAnswer = fourthAnswer;
		}
	}
	
	public int getRightAnswerRewardId() {
		return this.rightAnswerRewardId;
	}

	public void setRightAnswerRewardId(int rightAnswerRewardId) {
		this.rightAnswerRewardId = rightAnswerRewardId;
	}
	
	public int getWrongAnswerRewardId() {
		return this.wrongAnswerRewardId;
	}

	public void setWrongAnswerRewardId(int wrongAnswerRewardId) {
		this.wrongAnswerRewardId = wrongAnswerRewardId;
	}
	

	@Override
	public String toString() {
		return "ExamTemplateVO[name=" + name + ",typeId=" + typeId + ",rightAnswerID=" + rightAnswerID + ",firstAnswerID=" + firstAnswerID + ",firstAnswer=" + firstAnswer + ",secendAnswerID=" + secendAnswerID + ",secendAnswer=" + secendAnswer + ",thirdAnswerID=" + thirdAnswerID + ",thirdAnswer=" + thirdAnswer + ",fourthAnswerID=" + fourthAnswerID + ",fourthAnswer=" + fourthAnswer + ",rightAnswerRewardId=" + rightAnswerRewardId + ",wrongAnswerRewardId=" + wrongAnswerRewardId + ",]";

	}
}