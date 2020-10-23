package com.imop.scribe.util;

import java.io.BufferedReader;
import java.io.File;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.FileWriter;
import java.io.IOException;
import java.io.PrintWriter;

import com.csvreader.CsvWriter;
/**
 * @author wenping.jiang
 *	csv文件辅助
 */
public class FileUtil {

	/**
	 * @param file
	 * @param message
	 * 向文件末尾输入一串message
	 */
	public static void writeCsvLineMessage(File file, String message){
		CsvWriter writer = null;
		try {
			FileWriter fileWrite = new FileWriter(file, true);
			writer = new CsvWriter(fileWrite, '\n');
			writer.write(message);
			writer.endRecord();
		} catch (IOException e) {
			e.printStackTrace();
		}finally{
			if(writer != null){
				writer.close();
			}
		}
	}
	
	/**
	 * @param file
	 * @param message
	 * @return
	 * 返回写下的CsvWriter
	 */
	public static CsvWriter getCsvWriterMessgage(File file, String message){
		CsvWriter writer = null;
		try {
			FileWriter fileWrite = new FileWriter(file, true);
			writer = new CsvWriter(fileWrite, '\n');
			writer.write(message);
			writer.endRecord();
			return writer;
		} catch (IOException e) {
			e.printStackTrace();
		}finally{
			
		}
		return null;
	}
	/**
	 * @param file
	 * @param message
	 * 向日志文件输出
	 */
	public static void writeLogLineMessage(File file, String message){
		PrintWriter writer = null;
		try {
			FileWriter fileWrite = new FileWriter(file, true);
			writer = new PrintWriter(fileWrite);
			writer.println(message);
		} catch (IOException e) {
			e.printStackTrace();
		}finally{
			if(writer != null){
				writer.close();
			}
		}
	}

	/**
	 * @param file
	 * 文件所有内容输出
	 */
	public static void printLogLineMessage(File file){
		try {
			FileReader fr = new FileReader(file);
			BufferedReader reader = new BufferedReader(fr);
			try {
				String s;
				while((s = reader.readLine()) != null){
//					System.out.println("输出"+ s);
				}
			} catch (IOException e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			}
		} catch (FileNotFoundException e) {
			e.printStackTrace();
		}
	}
}
