package com.imop.lj.test.battle;

import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;

import com.imop.lj.core.util.MD5Util;

public class TestA {
	
	static ExecutorService battleCharUnBindExecutor = Executors.newSingleThreadExecutor();
	
	public static void main(String[] args) {
		TestRunable a = new TestRunable();
		
		battleCharUnBindExecutor.submit(a);
	}
}
