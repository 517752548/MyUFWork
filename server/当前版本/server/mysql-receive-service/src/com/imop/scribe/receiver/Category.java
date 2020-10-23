package com.imop.scribe.receiver;

import java.text.DateFormat;
import java.text.ParseException;
import java.text.SimpleDateFormat;

import org.codehaus.jackson.map.ObjectMapper;

public abstract class Category {
	protected final static ObjectMapper jacksonMapper = new ObjectMapper();
	abstract public String getCategoryName();
	abstract public String getTablePrefix();
	abstract public String messageToInsertSQL(String category, String message);
	abstract public String message2svclistSql(String category, String message);
	protected final static DateFormat dateParser = new SimpleDateFormat("yyyy-MM");
	protected final static DateFormat dateFormatter = new SimpleDateFormat("yyyyMM");
	
	// utility static methods.
	
	/**
	 * Convert from Timestamp string to Year and Month string.
	 * 
	 * @param times
	 * @return Year and Month in YYYYMM format.
	 * @throws ParseException 
	 */
	public static String getYearAndMonth(String times){
		
		try {
			return dateFormatter.format(dateParser.parse(times));
		} catch (ParseException e) {
			e.printStackTrace();
		}
		return null;
	}
	
	/**
	 * Add insert into table header in SQL stringbuilder.
	 * @param sb SQL StringBuilder
	 * @param prefix table prefix
	 * @param postfix table postfix (time, serial, etc ...)
	 * @return in stringbuilder
	 */
	public static StringBuilder addInsertIntoTable(StringBuilder sb, String prefix, String postfix) {
		sb.insert(0, postfix).insert(0, '_').insert(0, prefix).insert(0, "INSERT INTO ");
		return sb;
	}
	
	public static void main(String[] args) {
		System.out.println(getYearAndMonth("2012-1-30"));
	}
}
