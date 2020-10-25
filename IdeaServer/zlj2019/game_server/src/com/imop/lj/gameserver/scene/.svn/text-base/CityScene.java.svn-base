package com.imop.lj.gameserver.scene;

import net.sf.json.JSONArray;

import com.imop.lj.core.persistance.AbstractSceneDataUpdater;
import com.imop.lj.gameserver.player.OnlinePlayerService;
import com.imop.lj.gameserver.scene.template.SceneTemplate;

/**
 * 城市场景
 *
 * @author haijiang.jin
 *
 */
public class CityScene extends Scene {
//	/** 占有度最大值 */
//	private static final int OCCUPANCY_MAX = 10000;
//	/** 繁荣 */
//	private int boom = 0;
//	/** 当前所属阵营id */
//	private int allianceId;
//	/** 3 个阵营的占有度 */
//	private int[] occupancies = new int[3];

	/**
	 * 类参数构造器
	 *
	 * @param sceneTpl
	 * @param onlinePlayerService
	 */
	public CityScene(SceneTemplate sceneTpl, OnlinePlayerService onlinePlayerService) {
		super(sceneTpl, onlinePlayerService);

		if (sceneTpl == null) {
			return;
		}

//		// 设置初始阵营
//		this.allianceId = sceneTpl.getDefaultAllianceId();
//		// 设置繁荣度
//		this.boom = sceneTpl.getDefaultBoom();
//		// 设置占有度
//		int occupancyIndex = getOccupancyIndex(sceneTpl.getDefaultAllianceId());
//		if(occupancyIndex != -1) this.occupancies[occupancyIndex] = OCCUPANCY_MAX;
//
//		// 创建银矿格子字典
//		this.silveroreGridMap = new HashMap<Integer, SilveroreGrid>();
//		this.occupyedSilverSet = new HashSet<Silverore>();

		this.initCity();
	}

//	/**
//	 * 初始化银矿格子
//	 *
//	 * @param gridCount
//	 */
//	private void initSilveroreGrid(int gridCount) {
//		if (gridCount < 0) {
//			return;
//		}
//
//		for (int i = 1; i <= gridCount; i++) {
//			// 创建并添加银矿格子
//			this.silveroreGridMap.put(i, new SilveroreGrid(this, i));
//		}
//	}

	/**
	 * 初始化城市场景
	 *
	 */
	private void initCity() {
		// 获取银矿页数
//		int silverorePageCount = this.getSceneTemplate().getSilverorePageCount();
		// 初始化银矿格子
//		this.initSilveroreGrid(silverorePageCount);
		// 获取区域页码数量
//		int districtPageCount = 99;
//		// 获取银矿页数
//		int silverorePageCount = this.getSceneTemplate().getSilverorePageCount();
	}

//	/**
//	 * 获取繁荣度
//	 *
//	 * @return
//	 */
//	public int getBoom() {
//		return this.boom;
//	}
//
//	/**
//	 * 设置繁荣度
//	 *
//	 * @param value
//	 */
//	public void setBoom(int value) {
//		this.boom = value;
//		this.setModified();
//	}





	@Override
	protected String toEntityProperties() {
		JSONArray ja = new JSONArray();
//		JSONArray occupanciesJson = new JSONArray();
//
//		for (float occupancy : this.occupancies) {
//			occupanciesJson.add((int)occupancy);
//		}

//		ja.add(this.boom);
//		ja.add((int)this.smeltPrice.getChange());
//		ja.add(occupanciesJson);
//		ja.add(this.allianceId);
//		ja.add(this.smeltPrice.getDirect());

		return ja.toString();
	}

	@Override
	protected void fromEntityProperties(String props) {
		if (props == null) {
			return;
		}

//		JSONArray ja = JSONArray.fromObject(props);
//
//		int i = 0;
//
//		this.boom = ja.getInt(i++);
//		//this.smeltPrice.setChange(ja.getInt(i++));
//
//		JSONArray occupanciesJson = ja.getJSONArray(i++);
//
//		for (int j = 0; j < this.occupancies.length; j++) {
//			// 设置占有度
//			this.occupancies[j] = occupanciesJson.getInt(j);
//		}
//
//		//设置所属阵营
//		if(ja.size() > i) {
//			this.allianceId = ja.getInt(i++);
//		}
//
//		if(ja.size() > i + 1) {
//		//	this.smeltPrice.setDirect(ja.getInt(i++));
//		}
	}

//	@Override
//	protected void showSceneDlg(Human human, List<FuncInfo> funcList) {
//		if (human == null) {
//			return;
//		}
//
//		// 获取阵营势力占有度
////		float occupancy = this.getOccupancy(human.getAllianceId());
////		// 创建城市场景对话框
//		GCShowCitySceneDlg dlg = new GCShowCitySceneDlg();
//
//		dlg.setSceneId(this.getTemplateId());
//		dlg.setName(this.getName());
//		dlg.setImage(this.getImage());
//		dlg.setDesc(this.getDesc());
//		dlg.setOutline(this.getOutline());
//		dlg.setSceneFuncList(funcList.toArray(new FuncInfo[0]));
//
//		human.sendMessage(dlg);
//	}

//	@Override
//	public int getAllianceId() {
//		return allianceId;
//	}

//	/**
//	 * 获取占有度
//	 *
//	 * @param allianceId 阵营 Id
//	 * @return
//	 */
//	public float getOccupancy(int allianceId) {
//		// 获取占有索引
//		int occupancyIndex = getOccupancyIndex(allianceId);
//
//		if (occupancyIndex == -1) {
//			return 0;
//		}
//
//		//输出时作除100处理
//		return this.occupancies[occupancyIndex] / 100f;
//	}

//	/**
//	 * 获取占有度
//	 *
//	 * @param alliance 阵营
//	 * @return
//	 *
//	 */
//	public float getOccupancy(AllianceTypes alliance) {
//		if (alliance != null) {
//			return this.getOccupancy(alliance.getIndex());
//		} else {
//			return 0.0f;
//		}
//	}

//	/**
//	 * 获取占有度索引
//	 *
//	 * @param allianceId
//	 * @return
//	 *
//	 */
//	private static int getOccupancyIndex(int allianceId) {
//		return 0;
//	}

//	/**
//	 * 增加势力占有度, 另外两个势力的占有度会随之减少
//	 *
//	 * @param allianceId 阵营势力 Id, 该值必须为: 1(同盟国)、2(轴心国)、4(共产国际)
//	 * @param addOccupancy 所增加的占有度, 该值范围在 (0, 100]
//	 *
//	 */
//	public void addOccupancy(int allianceId, float addOccupancyRatio) {
//		int addOccupancy = (int)(addOccupancyRatio * 100);
//		//如果不被2整除，则令其被2整除
//		if(addOccupancy % 2 == 1) addOccupancy--;
//
//		// 获取当前势力的占有索引
//		int oppancyIndex = getOccupancyIndex(allianceId);
//
//		if (oppancyIndex == -1) {
//			return;
//		}
//
//		if (addOccupancy <= 0) {
//			// 如果所增加的占有度小于或等于 0,
//			// 则直接退出
//			return;
//		}
//
//		if (addOccupancy > OCCUPANCY_MAX) {
//			// 所增加的占有度不应超过上限
//			addOccupancy = OCCUPANCY_MAX;
//		}
//
//		// 计算另外两个势力减少的占有度
//		int subOccupancy = addOccupancy / 2;
//		// 余数
//		int remainder = 0;
//
//		// 增加本国占有度并扣除敌国占有度
//		//
//		// 算法思路:
//		// 1. 增加本国占有度;
//		// 2. 减少敌国占有度;
//		// 3. 如果敌国占有度不足, 则令敌国占有度为 0,
//		//    并将余数累加到 remainder 变量;
//		// 以上 3 步结束后:
//		// 4. 如果 remainder 变量 > 0,
//		//    则将 remainder 分摊给另外一个敌国
//		//
//		// XXX 注意:
//		//     当阵营类型多余 3 个时, remainder 余数分摊算法可能会出问题!
//		//     但阵营类型多余 3 个的可能性不大
//		//
//		for (int i = 0; i < this.occupancies.length; i++) {
//			if (i == oppancyIndex) {
//				// 增加本国占有度
//				this.occupancies[i] += addOccupancy;
//
//				if (this.occupancies[i] > OCCUPANCY_MAX) {
//					this.occupancies[i] = OCCUPANCY_MAX;
//				}
//			} else {
//				if (this.occupancies[i] < subOccupancy) {
//					// 如果敌国占有度不足,
//					// 则令敌国占有度为 0, 并增加余数
//					remainder += subOccupancy - this.occupancies[i];
//					this.occupancies[i] = 0;
//				} else {
//					// 减少敌国占有度
//					this.occupancies[i] -= subOccupancy;
//				}
//			}
//		}
//
//		for (int i = 0; (remainder > 0) && (i < this.occupancies.length); i++) {
//			if (i == oppancyIndex) {
//				// 如果 "本国势力",
//				// 则直接进入下一次循环
//				continue;
//			}
//
//			if (this.occupancies[i] == 0) {
//				// 如果敌国占有度为 0,
//				// 则直接进入下一次循环
//				continue;
//			}
//
//			if (this.occupancies[i] < remainder) {
//				remainder -= this.occupancies[i];
//				this.occupancies[i] = 0;
//			} else/* if (this.occupancies[i] >= remainder) */{
//				this.occupancies[i] -= remainder;
//				remainder = 0;
//			}
//		}
//
//		//检查阵营归属变化
//		checkAllianceChange();
//
//		this.setModified();
//	}

//	/**
//	 * 检查城市所属改变的情况
//	 * 每次占有度改变后检查
//	 */
//	private void checkAllianceChange() {
//		//找出当前占有度最高的阵营索引
//		int curIndex = getOccupancyIndex(allianceId);
//		if(curIndex == -1) {
//			//当前无所属阵营，直接返回
//			return;
//		}
//		int curOccupancy = occupancies[curIndex];
//
//		for(int i = 0; i < occupancies.length; i++) {
//			if(curOccupancy < occupancies[i]) {
//				curOccupancy = occupancies[i];
//				curIndex = i;
//			}
//		}
//
//		int newAllianceId = getAllianceOfIndex(curIndex);
//
//		//发生所属阵营改变的情况
//		if(newAllianceId != allianceId) {
//			AllianceTypes oldAlliance = AllianceTypes.valueOf(allianceId);
//			AllianceTypes newAlliance = AllianceTypes.valueOf(newAllianceId);
//			allianceId = newAllianceId;
//
//			//发全服系统消息
//			String oldOwner = Globals.getLangService().readSysLang(oldAlliance.getNameLangKey());
//			String newOwner = Globals.getLangService().readSysLang(newAlliance.getNameLangKey());
//			Globals.getNoticeService().sendNotice(NoticeTypes.common,
//					Globals.getLangService().readSysLang(LangConstants.WORLD_CITY_ALLIIANCE_CHANGE,
//					oldOwner, getName(), newOwner));
//		}
//	}

	@Override
	public void tick() {
		super.tick();
//		System.out.println(this.getSceneTemplate().getId() + " is tick! ");
//		this.silverProcess();
	}

	@Override
	public AbstractSceneDataUpdater getSceneDataUpdater() {
		// TODO Auto-generated method stub
		return null;
	}

//	private void silverProcess(){
//		//XXX 银矿占领推送
//		if(this.occupyedSilverSet.size() > 0){
//			Iterator<Silverore> iterator =  this.occupyedSilverSet.iterator();
//			while(iterator.hasNext()){
//				Silverore silverore = iterator.next();
//				if(silverore.getHumanUUId() > 0){
//					boolean isExpried = Globals.getSilveroreService().checkExpried(silverore);
//					if(isExpried){
//						Globals.getSilveroreService().checkExpiredAndSettlement(silverore);
//						iterator.remove();
//					}
//				}else{
//					iterator.remove();
//				}
//			}
//		}
//	}
//
//	public void addOccupyedSilver(Silverore silverore){
//		this.occupyedSilverSet.add(silverore);
//	}


//	/**
//	 * 增加势力占有度, 另外两个势力的占有度会随之减少
//	 *
//	 * @param alliance 阵营, 该值必须为:
//	 * 		<li>AllianceTypes.TONGMENG(同盟国)</li>
//	 * 		<li>AllianceTypes.ZHOUXIN(轴心国)</li>
//	 * 		<li>AllianceTypes.GONGCHANGUOJI(共产国际)</li>
//	 * @param addOccupancy 所增加的占有度, 该值范围在 (0, 100]
//	 * @see AllianceTypes
//	 *
//	 */
//	public void addOccupancy(AllianceTypes alliance, float addOccupancy) {
//		if (alliance != null) {
//			this.addOccupancy(alliance.getIndex(), addOccupancy);
//		}
//	}

//	/**
//	 * 获取占有度字符串
//	 *
//	 * @return
//	 */
//	public String getOccupanciesStr() {
//		return Arrays.toString(this.occupancies);
//	}

//	/**
//	 * 获取银矿格子字典
//	 *
//	 * @return
//	 */
//	public Map<Integer, SilveroreGrid> getSilveroreGridMap() {
//		return this.silveroreGridMap;
//	}
//
//	/**
//	 * 获取银矿格子
//	 *
//	 * @param pageIndex 区域页码, 起始值为 1
//	 * @return
//	 *
//	 */
//	public SilveroreGrid getSilveroreGrid(int pageIndex) {
//		return this.silveroreGridMap.get(pageIndex);
//	}
}
