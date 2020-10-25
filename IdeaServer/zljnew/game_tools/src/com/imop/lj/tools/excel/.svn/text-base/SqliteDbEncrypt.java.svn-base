package com.imop.lj.tools.excel;

import java.io.File;
import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.io.OutputStream;

public class SqliteDbEncrypt {

	public static String DB_FILE = "../game_tools/target/cs_target/sql/";

	public static final byte[] ENC_ARR = { 1, 0, 0, 1, 1, 0, 1, 1 };

	public static final int ENC_BYTE_NUM = ENC_ARR.length;

	public static void main(String[] args) throws Exception {
		if (args.length > 0) {
			DB_FILE += args[0];
		} else {
			DB_FILE = "e:/config_1001.db";
		}
		
		File dbFile = new File(DB_FILE);
		if (!dbFile.exists()) {
			throw new Exception("db file [" + DB_FILE + "] is not exist!");
		}

		String tmpFileName = DB_FILE + ".tmp";
		File tmpFile = new File(tmpFileName); 

		boolean ed = false;
		InputStream in = null;
		OutputStream out = null;
		try {
			out = new FileOutputStream(tmpFileName);

			byte[] tempbytes = new byte[1024];
			in = new FileInputStream(dbFile);
			while (in.read(tempbytes) != -1) {
				if (!ed) {
					ed = true;
					for (int i = 0; i < ENC_BYTE_NUM; i++) {
						tempbytes[i] = (byte) (tempbytes[i] ^ ENC_ARR[i]);
					}
				}

				out.write(tempbytes);
			}
			out.flush();

			
			
		} catch (Exception e1) {
			e1.printStackTrace();
		} finally {
			if (in != null) {
				try {
					in.close();
				} catch (IOException e1) {
				}
			}
			if (out != null) {
				try {
					out.close();
				} catch (IOException e1) {
				}
			}
			
			dbFile.delete();
			boolean f = tmpFile.renameTo(new File(DB_FILE));
			System.out.println("renameto flag=" + f);
		}

		System.out.println("end SqliteDbEncrypt");
	}

	public static byte[] int2Bytes(int num) {
		byte[] byteNum = new byte[4];
		for (int ix = 0; ix < 4; ++ix) {
			int offset = 32 - (ix + 1) * 8;
			byteNum[ix] = (byte) ((num >> offset) & 0xff);
		}
		return byteNum;
	}

	public static int bytes2Int(byte[] byteNum) {
		int num = 0;
		for (int ix = 0; ix < 4; ++ix) {
			num <<= 8;
			num |= (byteNum[ix] & 0xff);
		}
		return num;
	}
}
