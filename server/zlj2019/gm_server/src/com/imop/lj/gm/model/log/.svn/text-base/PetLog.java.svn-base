package com.imop.lj.gm.model.log;

import java.util.List;

public class PetLog extends BaseLog {
    private int petTempId;
    private long petId;
    private int petLevel;
    private long exp;



	public int getPetTempId() {
		return petTempId;
	}



	public void setPetTempId(int petTempId) {
		this.petTempId = petTempId;
	}



	public long getPetId() {
		return petId;
	}



	public void setPetId(long petId) {
		this.petId = petId;
	}



	public int getPetLevel() {
		return petLevel;
	}



	public void setPetLevel(int petLevel) {
		this.petLevel = petLevel;
	}



	public long getExp() {
		return exp;
	}



	public void setExp(long exp) {
		this.exp = exp;
	}



	@SuppressWarnings("unchecked")
	@Override
	public List toList() {
		List list = super.toList();
		list.add(petId);
		list.add(petTempId);
		list.add(petLevel);
		list.add(exp);
		return list;
	}

}