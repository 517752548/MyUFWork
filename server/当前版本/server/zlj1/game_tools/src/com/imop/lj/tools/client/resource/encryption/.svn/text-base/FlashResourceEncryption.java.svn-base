package com.imop.lj.tools.client.resource.encryption;

import java.io.ByteArrayInputStream;
import java.io.ByteArrayOutputStream;
import java.io.DataInputStream;
import java.io.DataOutputStream;
import java.io.File;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.util.ArrayList;
import java.util.List;


public class FlashResourceEncryption {

	// public static byte[][] keys =
	//
	// { { (byte)0x8C, (byte)0xFF, (byte)0x9D, (byte)0xEC },
	// { (byte)0xBC, (byte)0xF3, (byte)0x8A, (byte)0x2B },
	// { (byte)0x4B, (byte)0x67, (byte)0x9D, (byte)0x55 },
	// { (byte)0x9C, (byte)0x2F, (byte)0x06, (byte)0x86 },
	// { (byte)0xCC, (byte)0xF1, (byte)0x72, (byte)0x68 },
	// { (byte)0x86, (byte)0x89, (byte)0x90, (byte)0xEE },
	// { (byte)0xDF, (byte)0xEF, (byte)0x12, (byte)0x98 },
	// { (byte)0x14, (byte)0x5C, (byte)0x8F, (byte)0xD6 },
	// { (byte)0xCC, (byte)0x00, (byte)0xFF, (byte)0x66 },
	// { (byte)0xDE, (byte)0x12, (byte)0x56, (byte)0x90 }
	//
	// };
	public static int[] keys = { 0x8CFF9DEC, 0xBCF38A2B, 0x4B679D55, 0x9C2F0686, 0xCCF17268, 0x868990EE, 0xDFEF1298, 0x145C8FD6, 0xCC00FF66,
			0xDE125690 };

	/**
	 * 获得所有文件
	 * 
	 * @param baseDir
	 * @return
	 */
	public static List<File> getFiles(File baseDir) {
		List<File> fileList = new ArrayList<File>();
		if (baseDir.isDirectory()) {
			File[] files = baseDir.listFiles();

			for (File file : files) {
				if (file.isDirectory()) {
					fileList.addAll(getFiles(file));
				} else {
					if(file.getName().toLowerCase().endsWith(".jpg") || file.getName().toLowerCase().endsWith(".png")){
						fileList.add(file);
					}
				}
			}
		} else {
			fileList.add(baseDir);
		}

		return fileList;
	}

	/**
	 * 读取二进制文件
	 * 
	 * @param file
	 * @return
	 * @throws Exception
	 */
	public static byte[] readFile(File file) throws Exception {
		byte[] bytes = new byte[2048];

		FileInputStream fis = new FileInputStream(file);
		ByteArrayOutputStream bos = new ByteArrayOutputStream(2048);
		int length = 0;
		while ((length = fis.read(bytes)) != -1) {
			bos.write(bytes, 0, length);
		}

		fis.close();
		bos.close();
		return bos.toByteArray();
	}

	/**
	 * 加密文件
	 * 
	 * @param data
	 * @return
	 * @throws Exception
	 */
	private static byte[] encrypt(byte[] data) throws Exception {
		ByteArrayInputStream bis = new ByteArrayInputStream(data);
		DataInputStream dis = new DataInputStream(bis);
		ByteArrayOutputStream bos = new ByteArrayOutputStream(2048);
		DataOutputStream dos = new DataOutputStream(bos);

		int tempInt = 0;
		int n = 0;
		// int sign = 0;
		// long position = 0;
		long length = data.length - data.length % 4;
		for (int i = 0; i < length; i += 4) {
			// position = i;
			tempInt = dis.readInt();
			dos.writeInt(tempInt ^ keys[n++ % (keys.length - 1)]);
		}
		
		//小于4个字节不加密
		for (int i = 0; i < data.length % 4; i++) {
			dos.writeByte(dis.readByte());
		}

		dos.writeBoolean(false);
		dis.close();
		bis.close();
		dos.close();
		bos.close();
		return bos.toByteArray();
	}
	
	public static void writeFile(byte[] bytes,File file) throws Exception{
		FileOutputStream fos = new FileOutputStream(file);
		fos.write(bytes);
		fos.close();
	}

	public static void encryptFile(String baseDirStr) throws Exception{
		File baseDir = new File(baseDirStr);
		if(!baseDir.exists()){
			throw new FileNotFoundException();
		}
		List<File> fileLiset = getFiles(baseDir);
		for(File file : fileLiset){
			System.out.println("开始加密:" + file);
			byte[] fileBytes = readFile(file);
			byte[] xorbytes = encrypt(fileBytes);
			writeFile(xorbytes, file);
			System.out.println("加密完成:" + file);
		}
	}
	/**
	 * @param args
	 * @throws Exception
	 */
	public static void main(String[] args) throws Exception {
		try {
			if (args.length < 1) {
				throw new RuntimeException("参数不合法");
			}
			encryptFile(args[0]);
		} catch (Exception e) {
			e.printStackTrace();
		}
	}
}
