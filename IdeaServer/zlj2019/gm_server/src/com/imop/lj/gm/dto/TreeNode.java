package com.imop.lj.gm.dto;

/**
 * 菜单树对象信息
 *
 * @author linfan
 *
 */
public class TreeNode {

	/** 菜单id */
	private String id;

	/** 菜单名称 */
	private String name;

	/** 菜单地址 */
	private String url;

	/** 菜单父级菜单id */
	private String pid;

	public String getPid() {
		return pid;
	}

	public void setPid(String pid) {
		this.pid = pid;
	}

	private String p_name;

	public String getId() {
		return id;
	}

	public void setId(String id) {
		this.id = id;
	}

	public String getName() {
		return name;
	}

	public void setName(String name) {
		this.name = name;
	}

	public String getUrl() {
		return url;
	}

	public void setUrl(String url) {
		this.url = url;
	}

	public String getP_name() {
		return p_name;
	}

	public void setP_name(String p_name) {
		this.p_name = p_name;
	}

}
