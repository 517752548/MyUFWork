/**
 *
 */
package com.imop.lj.gm.service.db;

import java.io.File;
import java.io.IOException;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.Iterator;
import java.util.List;
import java.util.Map;
import java.util.Map.Entry;

import javax.xml.parsers.DocumentBuilder;
import javax.xml.parsers.DocumentBuilderFactory;
import javax.xml.parsers.ParserConfigurationException;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.w3c.dom.DOMException;
import org.w3c.dom.Document;
import org.w3c.dom.Element;
import org.w3c.dom.NodeList;
import org.xml.sax.SAXException;

import com.imop.lj.gm.dto.TreeNode;
import com.imop.lj.gm.utils.LangUtils;

/**
 * 权限 Service
 *
 * @author linfan
 *
 */
public class PrivilegeService {

	/** 该类所在的根路径 */
	private static String path = LangUtils.getRootPath() + "/i18n/";
	
	private static Map<String, Element> macros;

	/** SysUserService LOG */
	private static final Logger logger = LoggerFactory
			.getLogger(PrivilegeService.class);

	/**
	 * 得到系统角色
	 *
	 * @return 系统角色List
	 */
	@SuppressWarnings("unchecked")
	public static HashMap getRoleMap() {
		File inFile = new File(path + LangUtils.getLanguage() + "/role.xml");
		DocumentBuilderFactory dbf = DocumentBuilderFactory.newInstance();
		DocumentBuilder db = null;
		Document doc = null;
		HashMap roleList = new HashMap<String, String>();
		try {
			db = dbf.newDocumentBuilder();
			doc = (Document) db.parse(inFile);
			NodeList roles = doc.getElementsByTagName("role");
			for (int i = 0; i < roles.getLength(); i++) {
				Element el = (Element) roles.item(i);
				String role = el.getAttribute("name");
				String lev = el.getAttribute("lev");
				roleList.put(role,lev);
			}
		} catch (ParserConfigurationException pce) {
			logger.error("ParserConfigurationException:", pce);
		} catch (SAXException e) {
			logger.error("ParserConfigurationException:", e);
		} catch (DOMException dom) {
			logger.error("DOMException:", dom.getMessage());
		} catch (IOException ioe) {
			logger.error("IOException:", ioe);
		}
		return roleList;
	}

	@SuppressWarnings("unchecked")
	public  List getRoleListByRole(HashMap<String, String> map, String role) {
		List roleList = new ArrayList<String>();
		Iterator it = map.entrySet().iterator();
		while(it.hasNext()){
			 Entry enty = (Entry) it.next();
//			 String vaule = (String) enty.getValue();
//			 if(Integer.valueOf(vaule)> Integer.valueOf(map.get(role))){
				 roleList.add(enty.getKey());
//			 }
		}

		return roleList;
	}

	/**
	 * 根据用户的角色,加载权限菜单树
	 *
	 * @param role
	 *            用户角色
	 * @return TreeNode类型的List
	 */
	public List<TreeNode> getTreeList(String role) {
		String treeXml = "";
		if("1".equals(LangUtils.getDBType())){
			treeXml = "master.tree.xml";
		}else {
			treeXml = "slave.tree.xml";
		}
		File inFile = new File(path + LangUtils.getLanguage() + "/"+treeXml);
		List<String> treeList = new ArrayList<String>();
		List<TreeNode> menuList = new ArrayList<TreeNode>();
		// 为解析XML作准备，创建DocumentBuilderFactory实例,指定DocumentBuilder
		DocumentBuilderFactory dbf = DocumentBuilderFactory.newInstance();
		DocumentBuilder db = null;
		Document doc = null;
		NodeList trees = null;
		try {
			db = dbf.newDocumentBuilder();
			doc = (Document) db.parse(inFile);
			 trees = doc.getElementsByTagName("tree");
			  for (int i = 0; i < trees.getLength(); i++) {
					Element tree = (Element) trees.item(i);
					if (role.equals(tree.getAttribute("role_id"))) {
						NodeList subtrees = tree.getElementsByTagName("tnode");
						for (int j = 0; j < subtrees.getLength(); j++) {
							Element subtree = (Element) subtrees.item(j);
							String menu_id = subtree.getAttribute("menu_id");
							treeList.add(menu_id);
						}
					}
				}
				if ((treeList != null) && ("*").equals(treeList.get(0))) {
					menuList = getAllMenu();
					return menuList;
				}
				List<String> menuIdList = getMenuIdList(treeList);
				for (int i = 0; i < menuIdList.size(); i++) {
					List<TreeNode> treeNodeList = getSubMenu(menuIdList.get(i),
							treeList);
					TreeNode tnode = getMenu(menuIdList.get(i));
					menuList.add(tnode);
					menuList.addAll(treeNodeList);
				}
		} catch (ParserConfigurationException pce) {
			logger.error("ParserConfigurationException:", pce);
		} catch (DOMException dom) {
			logger.error("DOMException:", dom.getMessage());
		} catch (IOException ioe) {
			logger.error("DOMEIOExceptionxception:", ioe);
		} catch (SAXException e) {
			logger.error("SAXException:", e);
		}
		return menuList;
	}

	@SuppressWarnings("unchecked")
	private List<String> getMenuIdList(List menus) {
		List<String> menuIdList = new ArrayList<String>();
		for (int i = 0; i < menus.size(); i++) {
			String[] m = ((String) menus.get(i)).split("_");
			String menu_id = m[0];
			if (!menuIdList.contains(menu_id)) {
				menuIdList.add(menu_id);
			}
		}
		return menuIdList;

	}

	@SuppressWarnings("unchecked")
	private List<TreeNode> getSubMenu(String menuID, List submenusID) {
		Document root = getDoc();
		NodeList submenus = root.getElementsByTagName("submenu");
		List<TreeNode> treeNodeList = new ArrayList<TreeNode>();
		List<String> tempIDList = new ArrayList<String>();
		for (int i = 0; i < submenusID.size(); i++) {
			String tempID = (String) submenusID.get(i);
			String[] tem = tempID.split("_");
			if (menuID.equals(tem[0])) {
				tempIDList.add(tempID);
			}
		}
		for (int j = 0; j < tempIDList.size(); j++) {
			String submenuID = tempIDList.get(j);
			String[] m = submenuID.split("_");
			for (int i = 0; i < submenus.getLength(); i++) {
				Element submenu = (Element) submenus.item(i);
				if ("*".equals(m[1])
						&& (submenu.getAttribute("id").substring(0, 1)
								.equals(menuID))) {
					treeNodeList.add(getTreeNode(submenu));
				} else if (submenu.getAttribute("id").equals(submenuID)) {
					treeNodeList.add(getTreeNode(submenu));
					break;
				}

			}
		}
		
		
		//添加嵌入的menu
		Document macroRoot = getMacroDoc();
		NodeList macroSubmenus = macroRoot.getElementsByTagName("submenu");
		
		for (int j = 0; j < tempIDList.size(); j++) {
			String submenuID = tempIDList.get(j);
			String[] m = submenuID.split("_");
			//添加macro
			for (int i = 0; i < macroSubmenus.getLength(); i++) {
				Element submenu = (Element) macroSubmenus.item(i);
				if ("*".equals(m[1])
						&& (submenu.getAttribute("id").substring(0, 1)
								.equals(menuID))) {
					treeNodeList.add(getTreeNode(submenu));
				} else if (submenu.getAttribute("id").equals(submenuID)) {
					treeNodeList.add(getTreeNode(submenu));
					break;
				}
			}
		}
		
		return treeNodeList;
	}

	private List<TreeNode> getAllMenu() {
		Document root = getDoc();
		NodeList menus = root.getElementsByTagName("menu");
		List<TreeNode> treeNodeList = new ArrayList<TreeNode>();
		for (int i = 0; i < menus.getLength(); i++) {
			Element m = (Element) menus.item(i);
			String menuID = m.getAttribute("id");
			List<TreeNode> subTreeNodeList = getSubMenuByMenu(menuID);
			TreeNode tnode = getMenu(menuID);
			treeNodeList.add(tnode);
			treeNodeList.addAll(subTreeNodeList);

		}
		return treeNodeList;
	}

	/**
	 * @param menuID
	 * @return
	 */
	private List<TreeNode> getSubMenuByMenu(String menuID) {
		Document root = getDoc();
		NodeList submenus = root.getElementsByTagName("submenu");
		List<TreeNode> treeNodeList = new ArrayList<TreeNode>();
		for (int i = 0; i < submenus.getLength(); i++) {
			Element submenu = (Element) submenus.item(i);
			if (submenu.getAttribute("pid").equals(menuID)) {
				treeNodeList.add(getTreeNode(submenu));
			}
		}
		
		//添加嵌入的menu
		Document macroRoot = getMacroDoc();
		NodeList macroSubmenus = macroRoot.getElementsByTagName("submenu");
		
		for (int i = 0; i < macroSubmenus.getLength(); i++) {
			Element submenu = (Element) macroSubmenus.item(i);
			if (submenu.getAttribute("pid").equals(menuID)) {
				treeNodeList.add(getTreeNode(submenu));
			}
		}
		
		return treeNodeList;
	}

	private TreeNode getMenu(String menuID) {
		Document root = getDoc();
		TreeNode tnode = null;
		NodeList menus = root.getElementsByTagName("menu");
		for (int i = 0; i < menus.getLength(); i++) {
			Element menu = (Element) menus.item(i);
			if (menuID.equals(menu.getAttribute("id"))) {

				tnode = getTreeNode(menu);
				break;
			}

		}
		return tnode;

	}

	private TreeNode getTreeNode(Element e) {
		TreeNode tNode = new TreeNode();
		tNode.setId(e.getAttribute("id"));
		tNode.setName(e.getAttribute("name"));
		tNode.setUrl(e.getAttribute("url"));
		tNode.setPid(e.getAttribute("pid"));
		return tNode;
	}

	private Document getDoc() {
		File inFile = new File(path + LangUtils.getLanguage() + "/menu.xml");
		DocumentBuilderFactory dbf = DocumentBuilderFactory.newInstance();
		DocumentBuilder db = null;
		Document doc = null;
		try {
			db = dbf.newDocumentBuilder();
			doc = (Document) db.parse(inFile);
		} catch (ParserConfigurationException pce) {
			logger.error("ParserConfigurationException:", pce);
		}catch (SAXException e) {
			logger.error("ParserConfigurationException:", e);
		} catch (DOMException dom) {
			logger.error("DOMException:", dom.getMessage());
		} catch (IOException ioe) {
			logger.error("IOException:", ioe);
		}
		return doc;
	}
	
	/***
	 * 初始化macros
	 */
	private void initMacros() {
		if(macros == null) {
			macros = new HashMap<String, Element>();
		} else {
			return;
		}
		File inFile = new File(path + LangUtils.getLanguage() + "/macros.xml");
		DocumentBuilderFactory dbf = DocumentBuilderFactory.newInstance();
		DocumentBuilder db = null;
		Document doc = null;
		try {
			db = dbf.newDocumentBuilder();
			doc = (Document) db.parse(inFile);
		} catch (ParserConfigurationException pce) {
			logger.error("ParserConfigurationException:", pce);
		}catch (SAXException e) {
			logger.error("ParserConfigurationException:", e);
		} catch (DOMException dom) {
			logger.error("DOMException:", dom.getMessage());
		} catch (IOException ioe) {
			logger.error("IOException:", ioe);
		}
		NodeList menus = doc.getElementsByTagName("macro");
		NodeList roles = doc.getElementsByTagName("role");
		for (int i = 0; i < roles.getLength(); i++) {
			Element el = (Element) roles.item(i);
			String id = el.getAttribute("id");
			macros.put(id, el);
		}
	}
	
	private Document getMacroDoc() {
		File inFile = new File(path + LangUtils.getLanguage() + "/macros.xml");
		DocumentBuilderFactory dbf = DocumentBuilderFactory.newInstance();
		DocumentBuilder db = null;
		Document doc = null;
		try {
			db = dbf.newDocumentBuilder();
			doc = (Document) db.parse(inFile);
		} catch (ParserConfigurationException pce) {
			logger.error("ParserConfigurationException:", pce);
		}catch (SAXException e) {
			logger.error("ParserConfigurationException:", e);
		} catch (DOMException dom) {
			logger.error("DOMException:", dom.getMessage());
		} catch (IOException ioe) {
			logger.error("IOException:", ioe);
		}
		return doc;
	}

}
