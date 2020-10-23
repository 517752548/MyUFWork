package com.imop.lj.robot;

import java.lang.reflect.Array;
import java.lang.reflect.Field;

import com.imop.lj.common.model.item.CommonItem;
import com.imop.lj.core.util.KeyValuePair;
import com.imop.lj.gameserver.common.msg.GCMessage;

/**
 * 机器人工具类
 * 
 * @author xiaowei.liu
 * 
 */
public class RobotUtil {
	public static final Class<?>[] CLAZZS = {Boolean.class, Byte.class, Short.class, Character.class, Integer.class, Long.class, Float.class, Double.class, String.class};
	public static final Class<?>[] CAN_PARSE_CLAZZS = {Object.class, GCMessage.class};
	public static void print(String name, Object msg, String prefix) throws IllegalArgumentException, IllegalAccessException{
//		Field[] fields = msg.getClass().getDeclaredFields();
//		for(Field field : fields){
//			printField(field, msg, prefix);
//		}
		
		prefix = prefix + "\t";
		if(msg == null){
			System.out.println(prefix + name + "\tnull");
			return;
		}
		
		Class<?> clazz = msg.getClass();
		// 基本类型
		if(isPrimitive(clazz)){
			System.out.println(prefix + name + "\t" + msg);
			return;
		}
		
		// 数组
		if (clazz.isArray()) {
			int length = Array.getLength(msg);
			System.out.println(prefix + "[" + name + "\t" + length);
			for (int i = 0; i < length; i++) {
				print(i + "", Array.get(msg, i), prefix);
				if (i < length - 1) {
					System.out.println(prefix + "\t,");
				}
			}

			System.out.println(prefix + "]");
			return;
		}
		
		// 对象
		if (isCanParse(clazz)) {
			Field[] fields = clazz.getDeclaredFields();
			System.out.println(prefix + "{" + name + ":");
			for(Field field : fields){
				field.setAccessible(true);
				String _name = field.getName();
				Object _obj = field.get(msg);
				print(_name, _obj, prefix);
			}
			System.out.println(prefix + "}");

			return;
		}

		System.out.println(prefix + name + "\t" + msg);
	}
	
	
	public static boolean isCanParse(Class<?> clazz){
		for(Class<?> _clazz : CAN_PARSE_CLAZZS){
			if(clazz.getSuperclass().equals(_clazz)){
				return true;
			}
		}
		return false;
	}
	public static boolean isPrimitive(Class<?> clazz){
		if(clazz.isPrimitive()){
			return true;
		}
		
		for(Class<?> c : CLAZZS){
			if(clazz.equals(c)){
				return true;
			}
		}
		return false;
	}
	
	public static void main(String[] args) throws IllegalArgumentException, IllegalAccessException{
//		EquipAndPropsInfo info = new EquipAndPropsInfo();
//		info.setCapacity(0);
//		info.setRoleUUID(123);
//		info.setItems(new CommonItem[]{new CommonItem()});
//		info.setIntProperties(new KeyValuePair[0]);
//		info.setStrProperties(new KeyValuePair[0]);
//		
//		print("info",info, "");
	}
}
