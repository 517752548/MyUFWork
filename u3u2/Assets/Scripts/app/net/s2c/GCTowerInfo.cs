
using System;
namespace app.net
{
/**
 * 返回通天塔面板信息
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCTowerInfo :BaseMessage
{
	/** 通天塔面板信息 */
	private TowerInfo towerInfo;

	public GCTowerInfo ()
	{
	}

	protected override void ReadImpl()
	{
	// 通天塔面板信息
	TowerInfo _towerInfo = new TowerInfo();
	// 当前玩家的通天塔层数
	int _towerInfo_curTowerLevel = ReadInt();	_towerInfo.curTowerLevel = _towerInfo_curTowerLevel;



		this.towerInfo = _towerInfo;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_TOWER_INFO;
	}
	
	public override string getEventType()
	{
		return TowerGCHandler.GCTowerInfoEvent;
	}
	

	public TowerInfo getTowerInfo(){
		return towerInfo;
	}
		

}
}