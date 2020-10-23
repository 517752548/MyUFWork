using System.Collections.Generic;
using System.Linq;
using app.net;
using app.zone;

namespace app.relation
{
    public class RelationModel : AbsModel
    {
        public const string REFRESH_Relation_LIST = "REFRESH_Relation_LIST";
        public const string REFRESH_Recommon_LIST = "REFRESH_Recommon_LIST";
        public const string ADD_HaoYou_Success = "ADD_HaoYou_Success";
        public const string ADD_Relation_Success = "ADD_Relation_Success";
        public const string DEL_Relation_Success = "DEL_Relation_Success";

        /// <summary>
        /// 好友列表
        /// </summary>
        private List<RelationInfo> haoyouList;
        /// <summary>
        /// 黑名单列表
        /// </summary>
        private List<RelationInfo> blackList;

        /// <summary>
        /// 好友推荐列表
        /// </summary>
        private List<RelationInfo> tuijianList;
        /// <summary>
        /// 列表是否需要请求
        /// </summary>
        private bool haoyouListNeedFresh = true;
        private bool blackListNeedFresh = true;
        private bool needOpenPanel = false;
        private static RelationModel _ins;
        public static RelationModel Ins
        {
            get
            {
                if (_ins == null)
                {
                    //_ins = Singleton.getObj(typeof(RelationModel)) as RelationModel;
                    _ins = new RelationModel();
                }
                return _ins;
            }
        }
        public bool HaoyouListNeedFresh
        {
            get { return haoyouListNeedFresh; }
            set { haoyouListNeedFresh = value; }
        }

        public bool BlackListNeedFresh
        {
            get { return blackListNeedFresh; }
            set { blackListNeedFresh = value; }
        }

        /// <summary>
        /// 好友列表
        /// </summary>
        public List<RelationInfo> HaoyouList
        {
            get { return haoyouList; }
        }

        /// <summary>
        /// 黑名单列表
        /// </summary>
        public List<RelationInfo> BlackList
        {
            get { return blackList; }
        }

        /// <summary>
        /// 好友推荐列表
        /// </summary>
        public List<RelationInfo> TuijianList
        {
            get { return tuijianList; }
        }

        public void setHaoYouList(RelationInfo[] listv)
        {
            haoyouList = listv.ToList();
            if (HaoyouListNeedFresh && needOpenPanel)
            {
                WndManager.open(GlobalConstDefine.RelationView_Name);
                needOpenPanel = false;
            }
            else
            {
                dispatchChangeEvent(REFRESH_Relation_LIST, null);
            }
            HaoyouListNeedFresh = false;
        }

        public void setBlackList(RelationInfo[] listv)
        {
            blackList = listv.ToList();
            if (BlackListNeedFresh && needOpenPanel)
            {
                WndManager.open(GlobalConstDefine.RelationView_Name);
                needOpenPanel = false;
            }
            else
            {
                dispatchChangeEvent(REFRESH_Relation_LIST, null);
            }
            BlackListNeedFresh = false;
        }

        public void setTuijianList(RelationInfo[] listv)
        {
            tuijianList = listv.ToList();
            if (!WndManager.Ins.IsWndShowing(typeof(AddFriendView)))
            {
                WndManager.open(GlobalConstDefine.AddFriendView_Name);
            }
            else
            {
                dispatchChangeEvent(REFRESH_Recommon_LIST, null);
            }
        }

        public void openRelationView(bool needopenpanel)
        {
            if (HaoyouListNeedFresh || BlackListNeedFresh)
            {
                needOpenPanel = needopenpanel;
                RelationCGHandler.sendCGClickRelationPanel(RelationType.HAOYOU, 1);
                RelationCGHandler.sendCGClickRelationPanel(RelationType.HEIMINGDAN, 1);
            }
            else
            {
                WndManager.open(GlobalConstDefine.RelationView_Name);
            }
        }

        public void addRelationEnd(GCAddRelation msg)
        {
            if (msg.getRelationType() == RelationType.HAOYOU)
            {//好友
                bool hasexist = false;
                for (int i = 0; i < haoyouList.Count; i++)
                {
                    if (haoyouList[i].uuid == msg.getTargetCharId())
                    {
                        hasexist = true;
                        break;
                    }
                }
                if (!hasexist)
                {
                    haoyouList.Add(msg.getRelationInfoData());
                    dispatchChangeEvent(ADD_Relation_Success, msg);
                    dispatchChangeEvent(ADD_HaoYou_Success, msg);
                    ZoneBubbleManager.ins.BubbleSysMsg("添加好友成功");
                }

            }
            else
            {//黑名单
                bool hasexist = false;
                for (int i = 0; i < blackList.Count; i++)
                {
                    if (blackList[i].uuid == msg.getTargetCharId())
                    {
                        hasexist = true;
                        break;
                    }
                }
                if (!hasexist)
                {
                    blackList.Add(msg.getRelationInfoData());
                    dispatchChangeEvent(ADD_Relation_Success, msg);
                    //dispatchChangeEvent(ADD_Black_Success, msg);
                    ZoneBubbleManager.ins.BubbleSysMsg("添加黑名单成功");
                }

            }
        }

        public void removeRelationEnd(GCDelRelation msg)
        {
            if (msg.getRelationType() == RelationType.HAOYOU)
            {//好友
                for (int i = 0; i < haoyouList.Count; i++)
                {
                    if (haoyouList[i].uuid == msg.getTargetCharId())
                    {
                        haoyouList.RemoveAt(i);
                        dispatchChangeEvent(DEL_Relation_Success, msg);
                        ZoneBubbleManager.ins.BubbleSysMsg("移除好友成功");
                        break;
                    }
                }

            }
            else
            {//黑名单
                for (int i = 0; i < blackList.Count; i++)
                {
                    if (blackList[i].uuid == msg.getTargetCharId())
                    {
                        blackList.RemoveAt(i);
                        dispatchChangeEvent(DEL_Relation_Success, msg);
                        ZoneBubbleManager.ins.BubbleSysMsg("从黑名单移除成功");
                        break;
                    }
                }
            }
        }

        public override void Destroy()
        {
            if (haoyouList != null)
            {
                haoyouList.Clear();
                haoyouList = null;
            }

            if (blackList != null)
            {
                blackList.Clear();
                blackList = null;
            }

            if (tuijianList != null)
            {
                tuijianList.Clear();
                tuijianList = null;
            }
            HaoyouListNeedFresh = true;
            BlackListNeedFresh = true;
            needOpenPanel = false;
            _ins = null;
        }
    }
}