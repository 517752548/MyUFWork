package com.imop.scribe.receiver.category;

import java.io.IOException;
import java.util.Iterator;
import java.util.Set;
import java.util.Map.Entry;

import org.codehaus.jackson.JsonNode;
import org.codehaus.jackson.JsonProcessingException;
import org.codehaus.jackson.node.ObjectNode;

import com.imop.scribe.receiver.Category;
import com.imop.scribe.receiver.SVCList;

public class User extends Category {
	final static String CATEGORY_NAME = "probe.user";
	final static String TABLE_PREFIX = "user";
	/**
	 * svcList的数据库名称
	 */
	final static String TABLE_NAME_SVCLIST = "svclist";
	
	@Override
	public String getCategoryName() {
		return CATEGORY_NAME;
	}

	@Override
	public String getTablePrefix() {
		return TABLE_PREFIX;
	}

	@Override
	public String messageToInsertSQL(String category, String message) {
		try {
			ObjectNode root = (ObjectNode) jacksonMapper.readTree(message);

			StringBuilder sb0 = new StringBuilder(" (");
			StringBuilder sb1 = new StringBuilder();
			String timePostfix = "";

			Iterator<Entry<String, JsonNode>> iter = root.getFields();

			int pos = 0;
			while (iter.hasNext()) {
				Entry<String, JsonNode> entry = iter.next();

				if (pos != 0) {
					sb0.append(",");
					sb1.append(",");
				}

				String key = entry.getKey();

				sb0.append(key);
				if (key.compareTo("detail_blob") == 0) {
					ObjectNode node = (ObjectNode) entry.getValue();
					sb1.append("\"").append(node.toString().replace("\"", "\\\""))
							.append("\"");
				} else {
					sb1.append(entry.getValue().toString());
				}
				
				if (key.compareTo("ts_end") == 0) {
					timePostfix = getYearAndMonth(entry.getValue().getTextValue());
				}
				pos += 1;
			}

			sb0.append(") VALUES (").append(sb1).append(")");
			return addInsertIntoTable(sb0, TABLE_PREFIX, timePostfix).toString();

		} catch (JsonProcessingException ex) {
			return null;
		} catch (IOException ex) {
			return null;
		}
	}

	@Override
	public String message2svclistSql(String category, String message) {
		try {
			ObjectNode root = (ObjectNode) jacksonMapper.readTree(message);
			StringBuilder sb0 = new StringBuilder("INSERT INTO ").append(
					TABLE_NAME_SVCLIST).append(" (");
			StringBuilder sb1 = new StringBuilder();
			String[][] svc = new String[4][2];
			Set<String> set = SVCList.getInstance().getSvcSet();
			Iterator<Entry<String, JsonNode>> iter = root.getFields();
			int pos = 0;
			int pos1 = 0;
			while (iter.hasNext()) {
				Entry<String, JsonNode> entry = iter.next();
				String key = entry.getKey();
				String value = entry.getValue().toString().replace("\"", "");
				if(key.trim().equalsIgnoreCase("gameid")){
					svc[0][0] = key;
					svc[0][1] = value;
				} else if(key.trim().equalsIgnoreCase("svrid")){
					svc[1][0] = key;
					svc[1][1] = value;
				} else if(key.trim().equalsIgnoreCase("svcid")){
					svc[2][0] = key;
					svc[2][1] = value;
				} else if(key.trim().equalsIgnoreCase("svc_type")){
					svc[3][0] = key;
					svc[3][1] = value;
				}
			}
			StringBuilder setkey = new StringBuilder();
			for (int i = 0; i < svc.length; i++) {
				if(svc[i][0] == null || svc[i][1] == null){
					return null;
				} else {
					if(pos1 != 0){
						setkey.append(",");
					}
					setkey.append(svc[i][1]);
				}
				pos1++;
			}
			if(!set.contains(setkey.toString())){
				for (int i = 0; i < svc.length; i++) {
					if(pos != 0){
						sb0.append(",");
						sb1.append(",");
					}
					sb0.append(svc[i][0]);
					sb1.append("'" + svc[i][1] + "'");
					pos++;
				}
				sb0.append(") VALUES (").append(sb1).append(")");
				set.add(setkey.toString());
				return sb0.toString();
			} else {
				return null;
			}
		} catch (JsonProcessingException ex) {
			return null;
		} catch (IOException ex) {
			return null;
		}
	}

}
