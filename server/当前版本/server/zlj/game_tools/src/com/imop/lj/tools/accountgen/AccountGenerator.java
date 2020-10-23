package com.imop.lj.tools.accountgen;

import java.io.BufferedWriter;
import java.io.File;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.OutputStreamWriter;
import java.text.Format;
import java.text.SimpleDateFormat;
import java.util.Date;

/**
 * 账号自动生成
 *
 *
 */
public class AccountGenerator {

	public static void main(String[] args) throws IOException {

		File file = new File("d:\\account.sql");

		BufferedWriter writer = new BufferedWriter(new OutputStreamWriter(new FileOutputStream(file)));
		Format format = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss");
//		System.out.println(format.format(new Date()));

		for (int i = 1; i <= 100; i++) {
			String _name = "test" + String.valueOf(i);
			StringBuffer _strBuff = new StringBuffer();


			_strBuff
					.append("INSERT INTO `t_user_info` (id,name,password,role,joinTime,lastLoginTime,lastLogoutTime,failedLogins,lockStatus,muteTime) VALUES (");
			_strBuff.append(i).append(",'");
			_strBuff.append(_name).append("','");
			_strBuff.append(1).append("',");
			_strBuff.append("2").append(",");
//			_strBuff.append("'" + format.format(new Date()) + "'").append(",");
//			_strBuff.append("'" + format.format(new Date()) + "'").append(",");
//			_strBuff.append("'" + format.format(new Date()) + "'").append(",");
			_strBuff.append("null").append(",");
			_strBuff.append("null").append(",");
			_strBuff.append("null").append(",");
			_strBuff.append("0").append(",");
			_strBuff.append("0").append(",");
			_strBuff.append("0").append(");\r\n");
			System.out.println(_strBuff.toString());
			writer.write(_strBuff.toString());
		}

		writer.close();

	}

}
