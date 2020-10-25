package com.imop.lj.robot.test;

public class ShutdownTest {

	public static void main(String[] args) {
		Runtime.getRuntime().addShutdownHook(new Thread(new ShutdownHook(1)));
		Runtime.getRuntime().addShutdownHook(new Thread(new ShutdownHook(2)));
		System.exit(0);
		System.out.println("process...");
	}
	
	public static class ShutdownHook implements Runnable {
		private int i;
		public ShutdownHook(int i){
			this.i = i;
		}
		@Override
		public void run() {
			System.out.println("Shutdown hook 【" + i + "】...");			
		}
		
	}

}
