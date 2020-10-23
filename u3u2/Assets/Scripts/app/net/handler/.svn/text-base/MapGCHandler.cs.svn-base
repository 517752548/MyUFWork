using UnityEngine;
using app.fuben;
using app.zone;
using app.state;

namespace app.net
{
    public class MapGCHandler : IGCHandler
    {
        public const string GCMapPlayerEnterEvent = "GCMapPlayerEnterEvent";
        public const string GCMapPlayerChangedListEvent = "GCMapPlayerChangedListEvent";
        public const string GCMapPlayerSetPositionEvent = "GCMapPlayerSetPositionEvent";
        public const string GCMapAddNpcEvent = "GCMapAddNpcEvent";
        public const string GCMapAddNpcListEvent = "GCMapAddNpcListEvent";
        public const string GCMapRemoveAddNpcEvent = "GCMapRemoveAddNpcEvent";
        public const string GCMapUpdateAddNpcEvent = "GCMapUpdateAddNpcEvent";
        public const string GCMapTeamLeaderPositionEvent = "GCMapTeamLeaderPositionEvent";



        public MapGCHandler()
        {
            EventCore.addRMetaEventListener(GCMapPlayerEnterEvent, GCMapPlayerEnterHandler);
            EventCore.addRMetaEventListener(GCMapPlayerChangedListEvent, GCMapPlayerChangedListHandler);
            EventCore.addRMetaEventListener(GCMapPlayerSetPositionEvent, GCMapPlayerSetPositionHandler);
            EventCore.addRMetaEventListener(GCMapAddNpcEvent, GCMapAddNpcHandler);
            EventCore.addRMetaEventListener(GCMapAddNpcListEvent, GCMapAddNpcListHandler);
            EventCore.addRMetaEventListener(GCMapRemoveAddNpcEvent, GCMapRemoveAddNpcHandler);
            EventCore.addRMetaEventListener(GCMapUpdateAddNpcEvent, GCMapUpdateAddNpcHandler);
            EventCore.addRMetaEventListener(GCMapTeamLeaderPositionEvent, GCMapTeamLeaderPositionHandler);
        }

        private void GCMapPlayerEnterHandler(RMetaEvent e)
        {
            GCMapPlayerEnter msg = e.data as GCMapPlayerEnter;
            ZoneManager.ins.SetPlayerEnterZoneInfo(msg.getMapId(), msg.getUuid(), msg.getX(), msg.getY());
            StateBase curState = StateManager.Ins.getCurState();
            
            if (curState != null && curState.state == StateDef.zoneState)
            {
                ZoneModel.ins.entermapTimeEnd();

                StateManager.Ins.changeState(StateDef.zoneState);
                //切换地图时更新称号
                /*
                ZoneCharacter player = ZoneCharacterManager.ins.self;
				if (player != null)
                {
                    if (app.human.Human.Instance.getShowChenghao() == 1)
					{
                        player.title = app.human.Human.Instance.getChenghaoName();
                    }
                    else
                    {
                        player.title = "";
                    }
				}
                */

                //ZoneManager.ins.UpdateMapNpcs();
            }
        }

        private void GCMapPlayerChangedListHandler(RMetaEvent e)
        {
            GCMapPlayerChangedList msg = e.data as GCMapPlayerChangedList;
            ZoneManager.ins.SetZoneCharacterChangedList(msg.getMapId(), msg.getMapPlayerInfoDataList());
        }

        private void GCMapPlayerSetPositionHandler(RMetaEvent e)
        {
            GCMapPlayerSetPosition msg = e.data as GCMapPlayerSetPosition;
            ZoneCharacterManager.ins.SetCharacterPosition(msg.getMapId(), msg.getUuid(), msg.getX(), msg.getY());
        }

        private void GCMapAddNpcHandler(RMetaEvent e)
        {
            GCMapAddNpc msg = e.data as GCMapAddNpc;
            ZoneNPCManager.Ins.AddNpcMonster(msg.getNpcInfoData());
        }

        private void GCMapAddNpcListHandler(RMetaEvent e)
        {
            ZoneNPCManager.Ins.ClearNpcMonster();
            GCMapAddNpcList msg = e.data as GCMapAddNpcList;
            for (int i = 0; i < msg.getNpcInfoDataList().Length; i++)
            {
                ZoneNPCManager.Ins.AddNpcMonster(msg.getNpcInfoDataList()[i]);
            }
        }

        private void GCMapRemoveAddNpcHandler(RMetaEvent e)
        {
            GCMapRemoveAddNpc msg = e.data as GCMapRemoveAddNpc;
            for (int i = 0; i < msg.getRemoveUUIdList().Length; i++)
            {
                ZoneNPCManager.Ins.RemoveNpcMonster(msg.getRemoveUUIdList()[i]);
            }
        }

        private void GCMapUpdateAddNpcHandler(RMetaEvent e)
        {
            GCMapUpdateAddNpc msg = e.data as GCMapUpdateAddNpc;
            ZoneNPCManager.Ins.UpdateNpcMonster(msg.getNpcInfoData());
        }

        private void GCMapTeamLeaderPositionHandler(RMetaEvent e)
        {
            GCMapTeamLeaderPosition msg = e.data as GCMapTeamLeaderPosition;

            ZoneModel.ins.teamLeaderLTPixelPos = new int[]{msg.getX(), msg.getY()};

            if (ZoneModel.ins.mapTpl != null && ZoneModel.ins.mapTpl.Id == msg.getMapId())
            {
                //玩家与队长在同一张地图。
                if (ZoneManager.ins.curZoneInited)
                {
                    ZoneCharacter leader = ZoneCharacterManager.ins.GetCharacter(msg.getUuid());
                    if (leader == null)
                    {
                        ZoneCharacterManager.ins.TeamLeaderPosUpdated(leader);
                    }
                }
                else
                {
                    ZoneModel.ins.isTeamLeaderPosUpdatedBeforeZoneInited = true;
                }
            }
            else
            {
                //玩家与队长不在同一张地图。
                //ZoneManager.ins.SetPlayerEnterZoneInfo(msg.getMapId(), human.Human.Instance.Id, msg.getX(), msg.getY());
            }
            //停止自动寻路
            AutoMaticManager.Ins.StopAutoMatic();
        }

    }
}