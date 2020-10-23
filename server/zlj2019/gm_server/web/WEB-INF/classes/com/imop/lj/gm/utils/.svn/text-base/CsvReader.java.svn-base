package com.imop.lj.gm.utils;

import info.monitorenter.cpdetector.io.ASCIIDetector;
import info.monitorenter.cpdetector.io.CodepageDetectorProxy;
import info.monitorenter.cpdetector.io.JChardetFacade;
import info.monitorenter.cpdetector.io.ParsingDetector;
import info.monitorenter.cpdetector.io.UnicodeDetector;

import java.io.BufferedReader;
import java.io.File;
import java.io.FileInputStream;
import java.io.IOException;
import java.io.InputStreamReader;
import java.nio.charset.Charset;
import java.util.ArrayList;
import java.util.List;

import org.apache.commons.lang.StringUtils;

/**
 * 操作csv文件类
 *
 */
public class CsvReader {

	private BufferedReader bufferedreader = null;

	@SuppressWarnings("unchecked")
	private List list = new ArrayList();

	public CsvReader() {

	}

	@SuppressWarnings("unchecked")
	public CsvReader(String filename) throws IOException {
		//bufferedreader = new BufferedReader(new FileReader(filename));
		bufferedreader = new BufferedReader(new InputStreamReader(new FileInputStream(filename),getCharset(filename)));
		String stemp = null;
		while (StringUtils.isNotBlank(stemp = bufferedreader.readLine())) {
			stemp = new String(stemp.getBytes("utf-8"), "utf-8");
			list.add(stemp);
		}
	}

	@SuppressWarnings("unchecked")
	public List getList() {
		return list;
	}

	public int getRowNum() {
		return list.size();
	}

	/**
	 * 得到i行的列的数目
	 * @param i
	 * @return 列数
	 */
	public int getColNum(int i) {
		if (!list.toString().equals("[]")) {
			if (list.get(i).toString().contains(",")) {
				int len = (list.get(i).toString()+"1").split(",").length;
				return len;
			} else if (list.get(i).toString().trim().length() != 0) {
				return 1;
			} else {
				return 0;
			}
		} else {
			return 0;
		}
	}


	/**
	 * 得到行的信息
	 * @param index
	 * @return
	 */
	public String getRowInfo(int row) {
		if (this.list.size() != 0){
			return (String) list.get(row).toString()+" ";
		}
		else{
			return null;
		}
	}


	/**
	 * 得到行数
	 * @param index
	 * @return
	 */
	public String getRow(int index) {
		if (this.list.size() != 0)
			return (String) list.get(index);
		else
			return null;
	}

	/**
	 * 获取一个单元的数据
	 * @param row 行
	 * @param col 列
	 * @return 单元数据
	 */
	public String getString(int row, int col) {
		String temp = null;
		int colnum = this.getColNum(row);
		if (colnum > 1) {
			String rowInfo =list.get(row).toString()+" ";
			temp = rowInfo.split(",")[col];
		} else if (colnum == 1) {
			temp = list.get(row).toString();
		} else {
			temp = null;
		}
		return temp;
	}

	/**
	 * 关闭操作器
	 * @throws IOException
	 */
	public void csvClose() throws IOException {
		this.bufferedreader.close();
	}

	/**
	 * 返回数据 list
	 * @param filename
	 * @return
	 * @throws IOException
	 */
	@SuppressWarnings("unchecked")
	public List testRun(String filename) throws IOException {
		CsvReader cu = new CsvReader(filename);
		for (int i = 0; i < cu.getRowNum(); i++) {
			for (int j = 0; j < cu.getColNum(i); j++) {
				list.add(cu.getString(i, j));
			}
		}
		cu.csvClose();
		return list;
	}

	public static void main(String[] args) throws IOException {
		CsvReader test = new CsvReader();
		test.testRun("D:/csv/export1.csv");
		System.out.println(test.testRun("D:/csv/prize.csv"));//TODO -remove
	}

	public static Charset getCharset(String filename){
		CodepageDetectorProxy detector = CodepageDetectorProxy.getInstance();
		detector.add(new ParsingDetector(false));
		detector.add(JChardetFacade.getInstance());
		detector.add(ASCIIDetector.getInstance());
		detector.add(UnicodeDetector.getInstance());
		Charset charset = null;
		File file = new File(filename);
		try{
			charset = detector.detectCodepage(file.toURI().toURL());
			System.out.println("charset is :\t "+charset.name());
		} catch (Exception e){
			e.printStackTrace();
			return Charset.forName("utf-8");
		}
		return charset;
	}
}
