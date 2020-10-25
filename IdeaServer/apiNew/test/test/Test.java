package test;

import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;

import com.renren.games.api.util.LRUMap;

public class Test {
	static class ReadRunnable implements Runnable {
		public void run() {
			try {
				LRUMap<Integer,String> playerIds = player;
				for(Integer key : playerIds.keySet()){
					String playerId =playerIds.get(key);
					System.out.println(playerId);
				}
				System.out.println("ReadRunnable" + " read ");
			} catch (Exception e) {
				e.printStackTrace();
			}
			
		}
	}

	static class WriteRunnable implements Runnable {
		public void run() {
			try {
				int r = (int)(Math.random() * 10000f);
				player.put(r,r + "");
				System.out.println("WriteRunnable" + " add " + r);
			} catch (Exception e) {
				e.printStackTrace();
			}
			
		}
	}

	static LRUMap<Integer,String> player = new LRUMap<Integer,String>(10);
	
	static ExecutorService pool1 = Executors.newFixedThreadPool(1);
	
	static ExecutorService pool2 = Executors.newFixedThreadPool(1);
	
	public static void main(String[] args) throws InterruptedException {
		System.out.println("end");
		for(int i = 0 ; i < 1000;i++){
			pool1.submit(new ReadRunnable());
		}
		
		for(int i = 0 ; i < 1000;i++){
			pool2.submit(new WriteRunnable());
		}
		
		Thread.sleep(5000);
		System.out.println("===================");
		
		LRUMap<Integer,String> playerIds = player;
		for(Integer key : playerIds.keySet()){
			String playerId =playerIds.get(key);
			System.out.println(playerId);
		}
	}
}
