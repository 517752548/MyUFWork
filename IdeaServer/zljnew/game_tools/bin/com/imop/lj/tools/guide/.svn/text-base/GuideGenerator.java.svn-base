package com.imop.lj.tools.guide;

import java.io.File;
import java.io.IOException;
import java.util.List;

import org.apache.commons.io.FileUtils;
import org.apache.velocity.VelocityContext;

import com.imop.lj.gameserver.guide.GuideDef;
import com.imop.lj.tools.util.GeneratorHelper;

public class GuideGenerator {
	
	private static String modelName = "Test_Task";
	private static String comment = "测试引导";
	private static final String LEVEL = "level";
	private static final String QUEST = "quest";
	private static final String FUNC= "func";
	private static final String guidedef = "../game_server/src/com/imop/lj/gameserver/guide/GuideDef.java";
	private static final String guideFactory = "../game_server/src/com/imop/lj/gameserver/guide/GuidePusherFactory.java";
	private static final String guide_path = "../game_server/src/com/imop/lj/gameserver/guide/pusher/";
	private static final String guideService = "../game_server/src/com/imop/lj/gameserver/guide/GuideService.java";
	
	
	/**
	 * 修改3个地方
	 * 1. modelName,要求中间带有_
	 * 2. comment,中文注释
	 * 3. flag,level - 达到某一等级;quest - 完成任务;func - 功能开启时
	 * @param args
	 * @throws Exception
	 */
	public static void main(String[] args) throws Exception {
		
		String flag = "func";
		check();
	
		insertFuncDef(flag);
		insertFuncFactory();
		genGuide(flag);
		insertGuideService(flag);
	}
	
	private static void check() throws Exception {
		if(!modelName.contains("_")){
			throw new Exception("modelName 要带有_, " + modelName);
		}
	}

	private static void genGuide(String flag) throws Exception {
		String templateDir = "guide/";
		String templateFileName = "";
		if(flag.equals(LEVEL)){
			templateFileName = "GuideLevel.template";
		}else if(flag.equals(QUEST)){
			templateFileName = "GuideQuest.template";
		}else if(flag.equals(FUNC)){
			templateFileName = "GuideFunc.template";
		}
		VelocityContext context = new VelocityContext();
		context.put("modelName", modelName.split("_")[0]+modelName.split("_")[1]);
		context.put("bigModelName", modelName.split("_")[0].toUpperCase()+"_"+modelName.split("_")[1].toUpperCase());
		String generateToString = GeneratorHelper.generateToString(context, templateFileName, templateDir);
		String temName = (String) context.get("modelName") + "GuidePusher.java";
		System.out.println("创建 " + temName);
		FileUtils.writeStringToFile(new File(guide_path +  temName), generateToString);
	}

	@SuppressWarnings("unchecked")
	private static void insertGuideService(String flag) throws Exception {
		File cfgFile = new File(guideService);
		System.out.println("注册文件  GuideService.java");
		List<String> lines = FileUtils.readLines(cfgFile);
		if(flag.equals(LEVEL)){
			for (int i = 0; i < lines.size(); i++) {
				if (lines.get(i).contains("public void onLevelUp(Human human)")) {
					lines.add(i + 1, "		sendGuideInfo(human, GuideType."+modelName.split("_")[0].toUpperCase()+"_"+modelName.split("_")[1].toUpperCase()+");");
					break;
					
				}
				
			}
		}else if(flag.equals(QUEST)){
			for (int i = 0; i < lines.size(); i++) {
				if (lines.get(i).contains("protected void sendGuideInfoOnFinishQuest(Human human)")) {
					lines.add(i + 1, "		sendGuideInfo(human, GuideType."+modelName.split("_")[0].toUpperCase()+"_"+modelName.split("_")[1].toUpperCase()+");");
					break;
					
				}
				
			}
		}
		FileUtils.writeLines(cfgFile, lines);
	}

	@SuppressWarnings({"unchecked" })
	private static void insertFuncDef(String flag) throws IOException {
		int length = GuideDef.GuideType.values().length + 1;
		File cfgFile = new File(guidedef);
		List<String> lines = FileUtils.readLines(cfgFile);
		for (int i = 0; i < lines.size(); i++) {
			if (lines.get(i).contains("private final IGuidePusherFactory pusherFactory;")) {
				System.out.println("注册文件  GuideDef.java");
				if(flag.equals(FUNC)){
					lines.add(i - 4, "		"+modelName.split("_")[0].toUpperCase()+"_"+modelName.split("_")[1].toUpperCase()
							+"("+ length +", GuidePusherFactory."+modelName.split("_")[0]+modelName.split("_")[1]+"GuidePusherFactory, FuncTypeEnum."+ modelName +", true),");
				}else{
					lines.add(i - 4, "		"+modelName.split("_")[0].toUpperCase()+"_"+modelName.split("_")[1].toUpperCase()
							+"("+ length +", GuidePusherFactory."+modelName.split("_")[0]+modelName.split("_")[1]+"GuidePusherFactory, null, false),");
				}
				lines.add(i - 4, "		/** "+comment +"*/");
				break;
			}
			
		}
		FileUtils.writeLines(cfgFile, lines);
		
	}
	
	@SuppressWarnings({"unchecked" })
	private static void insertFuncFactory() throws IOException {
		File cfgFile = new File(guideFactory);
		List<String> lines = FileUtils.readLines(cfgFile);
		for (int i = 0; i < lines.size(); i++) {
			if (lines.get(i).contains("public class GuidePusherFactory")) {
				lines.add(i - 1, "import com.imop.lj.gameserver.guide.pusher."+modelName.split("_")[0]+modelName.split("_")[1]+"GuidePusher;");
				break;
				
			}
			
		}
		for (int i = 0; i < lines.size(); i++) {
			if (lines.get(i).contains("public class GuidePusherFactory")) {
				System.out.println("注册文件  GuidePusherFactory.java");
				lines.add(i + 1, "	};");
				lines.add(i + 1, "		}");
				lines.add(i + 1, "			return new "+modelName.split("_")[0]+modelName.split("_")[1]+"GuidePusher();");
				lines.add(i + 1, "		public AbstractGuidePusher createGuidePusher() {");
				lines.add(i + 1, "		@Override");
				lines.add(i + 1, "");
				lines.add(i + 1, "	public static IGuidePusherFactory "+modelName.split("_")[0]+modelName.split("_")[1]+"GuidePusherFactory = new IGuidePusherFactory() {");
				lines.add(i + 1, "");
				break;
				
			}
			
		}
		FileUtils.writeLines(cfgFile, lines);
		
	}
}
