package com.imop.lj.tools.util;

import java.io.BufferedWriter;
import java.io.File;
import java.io.FileOutputStream;
import java.io.OutputStreamWriter;
import java.io.StringWriter;
import java.net.URL;
import java.util.List;
import java.util.Properties;

import org.apache.velocity.Template;
import org.apache.velocity.VelocityContext;
import org.apache.velocity.app.Velocity;
import org.apache.velocity.app.VelocityEngine;
import org.apache.velocity.texen.util.FileUtil;

import com.imop.lj.common.exception.ConfigException;
import com.imop.lj.core.util.StringUtils;
import com.imop.lj.tools.msg.FieldObject;
import com.imop.lj.tools.msg.MessageFileType;
import com.imop.lj.tools.msg.MessageObject;

/**
 * 生成器工具类
 * 
 * 
 */
public class GeneratorHelper {
	/**
	 * 根据消息类型生成消息类名称
	 * 
	 * @param msgType
	 * @return
	 */
	public static String generateServerClassName(String msgType) {
		StringBuilder className = new StringBuilder();
		className.append(msgType.substring(0, 2));
		String msgBody = msgType.substring(3);
		String[] subMsgBodys = msgBody.split("_");
		for (String subMsgBody : subMsgBodys) {
			className.append(subMsgBody.substring(0, 1).toUpperCase());
			className.append(subMsgBody.substring(1).toLowerCase());
		}
		// className.append("Msg");
		return className.toString();
	}

	public static String getClientClassName(String classFullName) {
		if (classFullName.contains("<")) {
			int beginIndex = classFullName.indexOf("<");
			int endIndex = classFullName.indexOf(">") + 1;
			classFullName = classFullName.substring(0, beginIndex) + classFullName.substring(endIndex, classFullName.length());
		}
		if (classFullName.indexOf(".") > 0) {
			List<String> list = StringUtils.getListBySplit(classFullName, "\\.");
			return list.get(list.size() - 1);
		} else {
			return classFullName;
		}
	}

	/**
	 * 获得文件所属的目录名
	 * 
	 * @param fileName
	 * @return
	 */
	public static String getDirectoryName(String fileName) {
		int lastIndex = fileName.lastIndexOf("\\");
		if (lastIndex == -1) {
			return null;
		}
		String dir = fileName.substring(0, lastIndex) + "\\";
		return dir;
	}

	/**
	 * 生成消息处理方法名称
	 * 
	 * @param msgType
	 * @return
	 */
	public static String generateHandleMethodName(String msgType) {
		StringBuilder methodName = new StringBuilder("handle");
		String msgTypeBody = msgType.substring(3);
		String[] subMsgBodys = msgTypeBody.split("_");
		for (int i = 0; i < subMsgBodys.length; i++) {
			String subMsgBody = subMsgBodys[i];
			methodName.append(StringUtils.upperCaseFirstCharOnly(subMsgBody));
		}
		return methodName.toString();
	}

	public static String getBuildPath(String fileName) {
		ClassLoader classLoader = Thread.currentThread().getContextClassLoader();
		URL url = classLoader.getResource(fileName);
		if (url == null) {
			throw new ConfigException("file:" + fileName + " does not exists");
		}
		return url.getPath();
	}

	public static void generate(VelocityContext context, String templateFileName, String outputFile, String templateDir) throws Exception {
		// 先创建父目录
		FileUtil.mkdir(new File(outputFile).getParent());
		VelocityEngine velocityEngine = new VelocityEngine();
		Properties p = new Properties();
		p.setProperty(Velocity.FILE_RESOURCE_LOADER_PATH, GeneratorHelper.getBuildPath(templateDir));
		p.setProperty(Velocity.RUNTIME_LOG, "logs/velocity.log");
		p.setProperty(Velocity.ENCODING_DEFAULT, "utf-8");
		p.setProperty(Velocity.INPUT_ENCODING, "utf-8");
		p.setProperty(Velocity.OUTPUT_ENCODING, "utf-8");
		try {
			velocityEngine.init(p);
		} catch (Exception e) {
			e.printStackTrace();
		}
		Template template = velocityEngine.getTemplate(templateFileName);
		String directoryName = getDirectoryName(outputFile);
		if (directoryName != null) {
			File file = new File(directoryName);
			if (!file.exists()) {
				file.mkdirs();
			}
		}
		BufferedWriter writer = new BufferedWriter(new OutputStreamWriter(new FileOutputStream(outputFile), "utf-8"));
		template.merge(context, writer);
		writer.flush();
		writer.close();
	}

	public static String generateToString(VelocityContext context, String templateFileName, String templateDir) throws Exception {
		// 先创建父目录
		VelocityEngine velocityEngine = new VelocityEngine();
		Properties p = new Properties();
		p.setProperty(Velocity.FILE_RESOURCE_LOADER_PATH, GeneratorHelper.getBuildPath(templateDir));
		p.setProperty(Velocity.RUNTIME_LOG, "logs/velocity.log");
		p.setProperty(Velocity.ENCODING_DEFAULT, "utf-8");
		p.setProperty(Velocity.INPUT_ENCODING, "utf-8");
		p.setProperty(Velocity.OUTPUT_ENCODING, "utf-8");
		try {
			velocityEngine.init(p);
		} catch (Exception e) {
			e.printStackTrace();
		}
		Template template = velocityEngine.getTemplate(templateFileName);

		StringWriter swriter = new StringWriter();
		template.merge(context, swriter);

		try {
			return swriter.toString();
		} finally {
			swriter.flush();
			swriter.close();
		}
	}

	/**
	 * 
	 * @param currentField
	 * @param parentFieldName
	 * @return
	 * @throws Exception
	 */
	@Deprecated
	public static String fileldTemplateToClient(FieldObject currentField, String parentFieldName, String templateFilePrefix) throws Exception {
		String baseTemplateDir = "msg/template/basic/";
		StringBuilder sb = new StringBuilder();
		String newFieldName = currentField.getSmallName();
		// String index = currentField.getSmallName()+ "_" + "index";
		// String size = currentField.getSmallName()+ "_" + "size";
		if (parentFieldName != null && !parentFieldName.equalsIgnoreCase("")) {
			newFieldName = parentFieldName + "_" + currentField.getSmallName();
			// index = newFieldName+ "_" + "index";
			// size = newFieldName+ "_" + "size";
		}

		VelocityContext context = new VelocityContext();
		context.put("field", currentField);
		context.put("newFieldName", newFieldName);

		if (currentField.getIsNewType()) {
			if (currentField.getList()) {
				// VelocityContext context = new VelocityContext();
				// context.put("field", currentField);
				// context.put("newFieldName", newFieldName);
				// sb.append("var " + newFieldName + ":" + "Vector." + "<" +
				// currentField.getType() + ">" + "\r\n");
				// sb.append("var " + index + ":int;" + "\r\n");
				// sb.append("var " + size + ":int = data.readShort();" +
				// "\r\n");
				// sb.append("for(" +index+ " = 0;" + index + "<" + size + ";" +
				// index + "++" + "){" + "\r\n");
				sb.append(GeneratorHelper.generateToString(context, templateFilePrefix + "_6.vm", baseTemplateDir));
				for (FieldObject subField : currentField.getSubFields()) {
					context.put("subField", subField);
					sb.append(GeneratorHelper.generateToString(context, templateFilePrefix + "_7.vm", baseTemplateDir));
					sb.append(fileldTemplateToClient(subField, newFieldName, templateFilePrefix));

					// VelocityContext subContext = new VelocityContext();
					// context.put("newFieldName", newFieldName);
					// sb.append(newFieldName + "[" + index + "]" +
					// " = "+newFieldName + "_" + subField.getSmallName() +
					// ";\r\n");
					sb.append(GeneratorHelper.generateToString(context, templateFilePrefix + "_8.vm", baseTemplateDir));
				}
				sb.append(GeneratorHelper.generateToString(context, templateFilePrefix + "_9.vm", baseTemplateDir));
			} else {
				// VelocityContext context = new VelocityContext();
				// context.put("field", currentField);
				// context.put("newFieldName", newFieldName);
				// sb.append("var " + newFieldName + ":" +
				// currentField.getClientType() + "=" + " new " +
				// currentField.getClientType() + "();" + "\r\n");
				sb.append(GeneratorHelper.generateToString(context, templateFilePrefix + "_3.vm", baseTemplateDir));
				for (FieldObject subField : currentField.getSubFields()) {
					context.put("subField", subField);
					sb.append(GeneratorHelper.generateToString(context, templateFilePrefix + "_4.vm", baseTemplateDir));
					sb.append(fileldTemplateToClient(subField, newFieldName, templateFilePrefix));
					// VelocityContext subContext = new VelocityContext();
					// subContext.put("field", subField);
					// subContext.put("newFieldName", newFieldName);
					// sb.append(newFieldName + "." + subField.getSmallName() +
					// " = "+newFieldName + "_" + subField.getSmallName() +
					// ";\r\n");
					sb.append(GeneratorHelper.generateToString(context, templateFilePrefix + "_5.vm", baseTemplateDir));
				}
			}
		} else {
			if (currentField.getList()) {
				// VelocityContext context = new VelocityContext();
				// context.put("field", currentField);
				// context.put("newFieldName", newFieldName);
				// sb.append("var " + newFieldName + ":" + "Vector." + "<" +
				// currentField.getType() + ">" + "\r\n");
				// sb.append("var " + index + ":int;" + "\r\n");
				// sb.append("var " + size + ":int = data.readShort();" +
				// "\r\n");
				// sb.append("for(" +index+ " = 0;" + index + "<" + size + ";" +
				// index + "++" + "){" + "\r\n");
				// if(currentField.getType().equals("Long")){
				// sb.append(newFieldName + "[" + index +
				// "]"+"= Long.read(data);" + "\r\n");
				// }else{
				// sb.append(newFieldName + "[" + index + "]"+"= data.read" +
				// currentField.getType() +"();" + "\r\n");
				// }
				// sb.append("}" + "\r\n");
				sb.append(GeneratorHelper.generateToString(context, templateFilePrefix + "_2.vm", baseTemplateDir));
			} else {
				// VelocityContext context = new VelocityContext();
				// context.put("field", currentField);
				// context.put("newFieldName", newFieldName);
				// sb.append("var " + newFieldName + ":" +
				// currentField.getType() + ";" + "\r\n");
				// if(currentField.getType().equals("Long")){
				// sb.append(newFieldName + " = Long.read(data);" + "\r\n");
				// }else{
				// sb.append(newFieldName + " = data.read" +
				// currentField.getType() +"();" + "\r\n");
				// }
				sb.append(GeneratorHelper.generateToString(context, templateFilePrefix + "_1.vm", baseTemplateDir));
			}
		}
		return sb.toString();
	}

	/**
	 * 
	 * @param currentField
	 * @param parentFieldName
	 * @return
	 * @throws Exception
	 */
	public static String fileldTemplate(FieldObject currentField, String parentFieldName, String templateFilePrefix) throws Exception {
		String baseTemplateDir = "msg/template/basic/";
		StringBuilder sb = new StringBuilder();
		String newFieldName = currentField.getSmallName();
		if (parentFieldName != null && !parentFieldName.equalsIgnoreCase("")) {
			newFieldName = parentFieldName + "_" + currentField.getSmallName();
		}

		VelocityContext context = new VelocityContext();
		context.put("field", currentField);
		context.put("newFieldName", newFieldName);

		if (currentField.getIsNewType()) {
			if (currentField.getList()) {
				sb.append(GeneratorHelper.generateToString(context, templateFilePrefix + "_6.vm", baseTemplateDir));
				for (FieldObject subField : currentField.getSubFields()) {
					context.put("subField", subField);
					sb.append(GeneratorHelper.generateToString(context, templateFilePrefix + "_7.vm", baseTemplateDir));
					sb.append(fileldTemplate(subField, newFieldName, templateFilePrefix));
					sb.append(GeneratorHelper.generateToString(context, templateFilePrefix + "_8.vm", baseTemplateDir));
				}
				sb.append(GeneratorHelper.generateToString(context, templateFilePrefix + "_9.vm", baseTemplateDir));
			} else {
				sb.append(GeneratorHelper.generateToString(context, templateFilePrefix + "_3.vm", baseTemplateDir));
				for (FieldObject subField : currentField.getSubFields()) {
					context.put("subField", subField);
					sb.append(GeneratorHelper.generateToString(context, templateFilePrefix + "_4.vm", baseTemplateDir));
					sb.append(fileldTemplate(subField, newFieldName, templateFilePrefix));
					sb.append(GeneratorHelper.generateToString(context, templateFilePrefix + "_5.vm", baseTemplateDir));
				}
			}
		} else {
			if (currentField.getList()) {
				sb.append(GeneratorHelper.generateToString(context, templateFilePrefix + "_2.vm", baseTemplateDir));
			} else {
				sb.append(GeneratorHelper.generateToString(context, templateFilePrefix + "_1.vm", baseTemplateDir));
			}
		}
		return sb.toString();
	}

	public static String getMessageFieldContent(FieldObject currentField, String parentFieldName, MessageFileType messageType) throws Exception {
		switch (messageType) {
		case AS_GC:
			return fileldTemplate(currentField, parentFieldName, "as_gc_field");
		case AS_CG:
			return fileldTemplate(currentField, parentFieldName, "as_cg_field");
		case SERVER_CG:
		case SERVER_WG:
		case WORLD_SERVER_GW:
			return fileldTemplate(currentField, parentFieldName, "java_read_field");
		case SERVER_GC:
		case SERVER_GW:
		case WORLD_SERVER_WG:
			return fileldTemplate(currentField, parentFieldName, "java_write_field");
		case CPP_CG:
			return fileldTemplate(currentField, parentFieldName, "cpp_cg_field");
		case CPP_GC:
			return fileldTemplate(currentField, parentFieldName, "cpp_gc_field");
		case LUA_CG:
			return fileldTemplate(currentField, parentFieldName, "lua_cg_field");
		case LUA_GC:
			return fileldTemplate(currentField, parentFieldName, "lua_gc_field");
		case CS_GC:
			return fileldTemplate(currentField, parentFieldName, "cs_read_field");
		case CS_CG:
			return fileldTemplate(currentField, parentFieldName, "cs_write_field");
		default:
			return "";
		}
	}

	public static void templateClientGen(List<MessageObject> messageObject, MessageFileType messageType) throws Exception {
		for (MessageObject msg : messageObject) {
			StringBuilder sb = new StringBuilder();
			// if(msg.getType().equals("GC_TEST")){
			// System.out.println();
			// }
			List<FieldObject> fieldList = msg.getFields();
			// int i = 0;
			for (FieldObject field : fieldList) {
				// System.out.println(i + "" + field) ;
				sb.append(getMessageFieldContent(field, null, messageType) + "\r\n");
				// System.out.println(getMessageFieldContent(field,null,messageType));
				// i++;
			}
			msg.setFieldAsContent(sb.toString());
		}
	}
	
	public static void templateCSClientGen(List<MessageObject> messageObject) throws Exception {
		for (MessageObject msg : messageObject) {
			StringBuilder sb = new StringBuilder();
			StringBuilder sb2 = new StringBuilder();
			List<FieldObject> fieldList = msg.getFields();
			for (FieldObject field : fieldList) {
				sb.append(getMessageFieldContent(field, null, MessageFileType.CS_GC) + "\r\n");
				sb2.append(getMessageFieldContent(field, null, MessageFileType.CS_CG) + "\r\n");
			}
			
			msg.setFieldCsReadContent(sb.toString());
			msg.setFieldCsWriteContent(sb2.toString());
		}
	}

	public static void templateCppClientGen(List<MessageObject> messageObject, MessageFileType messageType) throws Exception {
		for (MessageObject msg : messageObject) {
			StringBuilder sb = new StringBuilder();
//			if (!msg.getType().equals("CG_TEST")) {
//				return;
//			}
			List<FieldObject> fieldList = msg.getFields();
			// int i = 0;
			for (FieldObject field : fieldList) {
				// System.out.println(i + "" + field) ;
				sb.append(getMessageFieldContent(field, null, messageType) + "\r\n");
				// System.out.println(getMessageFieldContent(field,null,messageType));
				// i++;
			}
//			System.out.println(sb.toString());
			msg.setFieldCppContent(sb.toString());
		}
	}
	
	public static void templateLuaClientGen(List<MessageObject> messageObject, MessageFileType messageType) throws Exception {
		for (MessageObject msg : messageObject) {
			StringBuilder sb = new StringBuilder();
//			if (!msg.getType().equals("CG_TEST")) {
//				return;
//			}
			List<FieldObject> fieldList = msg.getFields();
			// int i = 0;
			for (FieldObject field : fieldList) {
				// System.out.println(i + "" + field) ;
				sb.append(getMessageFieldContent(field, null, messageType) + "\r\n");
				// System.out.println(getMessageFieldContent(field,null,messageType));
				// i++;
			}
//			System.out.println(sb.toString());
			msg.setFieldLuaContent(sb.toString());
		}
	}

	public static void templateJavaGen(MessageObject messageObject) throws Exception {
		// if (!messageObject.getType().equals("GC_TEST")) {
		// return;
		// }
		{
			StringBuilder sb = new StringBuilder();
			List<FieldObject> fieldList = messageObject.getFields();
			for (FieldObject field : fieldList) {
				sb.append(getMessageFieldContent(field, null, MessageFileType.SERVER_CG) + "\r\n");
			}
			messageObject.setFieldJavaReadContent(sb.toString());
		}
		// if (!messageObject.getType().equals("CG_TEST")) {
		// return;
		// }
		{
			StringBuilder sb = new StringBuilder();
			List<FieldObject> fieldList = messageObject.getFields();
			for (FieldObject field : fieldList) {
				// System.out.println(getMessageFieldContent(field,null,MessageFileType.SERVER_GC));
				sb.append(getMessageFieldContent(field, null, MessageFileType.SERVER_GC) + "\r\n");
			}
			messageObject.setFieldJavaWriteContent(sb.toString());
		}
	}
}
