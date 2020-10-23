//package com.imop.lj.test.battle;
//
//import java.net.UnknownHostException;
//import java.util.ArrayList;
//import java.util.List;
//
//import org.junit.Before;
//import org.junit.Test;
//
//import com.mongodb.BasicDBObject;
//import com.mongodb.DB;
//import com.mongodb.DBCollection;
//import com.mongodb.DBObject;
//import com.mongodb.Mongo;
//import com.mongodb.MongoException;
//
//public class TestMongoDb {
//
//	private Mongo mg = null;
//	private DB db;
//	private DBCollection users;
//
//	@Before
//	public void init() {
//		try {
//			mg = new Mongo("192.168.1.140", 27017);
//			// mg = new Mongo("localhost", 27017);
//		} catch (UnknownHostException e) {
//			e.printStackTrace();
//		} catch (MongoException e) {
//			e.printStackTrace();
//		}
//		// 获取temp DB；如果默认没有创建，mongodb会自动创建
//		db = mg.getDB("temp");
//		// 获取users DBCollection；如果默认没有创建，mongodb会自动创建
//		users = db.getCollection("users");
////		users.drop();
//	}
//
//	@Test
//	public void test() throws UnknownHostException {
//		// 查询所有的Database
//		for (String name : mg.getDatabaseNames()) {
//			System.out.println("dbName: " + name);
//		}
//		for(int i = 4000000; i < 6000000 ; i++){
//			DBObject user = new BasicDBObject();
//			user.put("id", i);
//			user.put("a", "a");
//			user.put("b", "a");
//			user.put("c", "a");
//			user.put("d", "a");
//			user.put("e", "a");
//			user.put("f", "a");
//			user.put("g", "a");
//			user.put("h", "a");
//			user.put("i", "a");
//			users.save(user).getN();
//			System.out.println("i:" + i);
//		}
//		System.out.println("count: " + users.count());
//		
//	}
//
////	@Test
//	public void add() {
//	    //先查询所有数据
//		System.out.println("count: " + users.count());
//	    
//	    DBObject user = new BasicDBObject();
//	    user.put("name", "hoojo");
//	    user.put("age", 24);
//	    //users.save(user)保存，getN()获取影响行数
//	    //print(users.save(user).getN());
//	    
//	    //扩展字段，随意添加字段，不影响现有数据
//	    user.put("sex", "男");
//	    System.out.println(users.save(user).getN());
//	    
//	    //添加多条数据，传递Array对象
//	    System.out.println(users.insert(user, new BasicDBObject("name", "tom")).getN());
//	    
//	    //添加List集合
//	    List<DBObject> list = new ArrayList<DBObject>();
//	    list.add(user);
//	    DBObject user2 = new BasicDBObject("name", "lucy");
//	    user.put("age", 22);
//	    list.add(user2);
//	    //添加List集合
//	    System.out.println(users.insert(list).getN());
//	    
//	    //查询下数据，看看是否添加成功
//	    System.out.println("count: " + users.count());
//	}
//}
