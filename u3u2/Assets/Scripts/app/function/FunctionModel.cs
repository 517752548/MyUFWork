using System.Collections.Generic;
using System.Linq;
using app.config;
using app.net;
using app.npc;
using app.zone;
using UnityEngine;

namespace app.model
{
    public class FunctionModel : AbsModel
    {
        private List<FuncShowInfo> funcList;
        /// <summary>
        /// 等待播放特效的按钮
        /// </summary>
        public List<FuncShowInfo> waitingShowFunc;

        public const string FUNC_INFO_UPDATE = "FUNC_INFO_UPDATE";
        public const string ADD_NEW_FUNC = "ADD_NEW_FUNC";
        /// <summary>
        /// 功能id与界面GameObject关联字典
        /// </summary>
        private Dictionary<int, GameObject> funcBindObjDic;

        private static FunctionModel _ins;
        public static FunctionModel Ins
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new FunctionModel();
                }
                return _ins;
            }
        }

        public void setFuncList(GCFuncList msg)
        {
            funcList = msg.getFuncInfoList().ToList();
            /*
            string str = "";
            for (int i=0;i<funcList.Count;i++)
            {
                str += "id:" + funcList[i].funcType + " isOpened:" + funcList[i].isOpened + " effect:" + funcList[i].effect + "\n";
            }
            ClientLog.LogWarning("功能按钮：\n" + str);
            */
            updateFuncView();
        }

        public void updateFunc(GCFuncUpdate msg)
        {
            if (funcList==null)
            {
                return;
            }
            bool hasFunc = false;
            for (int i = 0; i < funcList.Count; i++)
            {
                if (funcList[i].funcType == msg.getFuncInfo().funcType)
                {
                    hasFunc = true;
                    funcList[i] = msg.getFuncInfo();
                    break;
                }
            }
            if (hasFunc)
            {
                //更新功能按钮信息
                dispatchChangeEvent(FUNC_INFO_UPDATE, msg.getFuncInfo());
            }
            else
            {
                if (msg.getFuncInfo().isOpened!=1)
                {
                    return;
                }
                //if (StateManager.Ins.getCurState().state==StateDef.zoneState)
                //{
                //    //增加功能按钮
                //    funcList.Add(msg.getFuncInfo());
                //    dispatchChangeEvent(ADD_NEW_FUNC, msg.getFuncInfo());
                //}
                //else
                //{
                    if (waitingShowFunc == null)
                    {
                        waitingShowFunc = new List<FuncShowInfo>();
                    }
                    waitingShowFunc.Add(msg.getFuncInfo());
                    if (ZoneUI.ins.addNewFuncId==0&&!JuQingManager.Ins.IsPlayingJuQing)
                    {
                        checkAddNewFunc();
                    }
                //}
            }
            //更新功能对应界面对象 的状态
            updateOneFuncView(msg.getFuncInfo());
        }

        public bool checkAddNewFunc()
        {
            if (waitingShowFunc != null && waitingShowFunc.Count>0)
            {
                FuncShowInfo funcinfo = waitingShowFunc[0];
                waitingShowFunc.RemoveAt(0);
                //增加功能按钮
                funcList.Add(funcinfo);
                dispatchChangeEvent(ADD_NEW_FUNC,funcinfo);
                return true;
            }
            return false;
        }

        public bool hasNewFuncOpen()
        {
            return (waitingShowFunc != null && waitingShowFunc.Count > 0);
        }

        public bool checkFuncOpen(int functionid1,int functionid2=0)
        {
            if (IsFuncOpen(functionid1) && (functionid2 == 0 || (functionid2!=0&&IsFuncOpen(functionid2))))
            {
                return true;
            }
            else
            {
                ZoneBubbleManager.ins.BubbleSysMsg("功能尚未开启，请努力！");
                return false;
            }
        }

        /// <summary>
        /// 获得功能是否开启
        /// </summary>
        /// <param name="funcId"></param>
        /// <returns></returns>
        public bool IsFuncOpen(int funcId)
        {
            bool hasOpen = false;
            if (funcId == FunctionIdDef.CANGKU || funcId == FunctionIdDef.XIAN_HU_ZUORI || funcId == FunctionIdDef.LING_XI_XIANHU_ZUORI || funcId == FunctionIdDef.LING_XI_XIANHU_SHANGZHOU)
            {
                return true;
            }
            if (!ServerConfig.instance.IsPassedCheck&&funcId == FunctionIdDef.DUIHUANJIANGLI)
            {
                return false;
            }
            for (int i = 0; i < funcList.Count; i++)
            {
                if (funcList[i].funcType == funcId && funcList[i].isOpened == 1)
                {
                    hasOpen = true;
                    break;
                }
            }
            return hasOpen;
        }
        
        /// <summary>
        /// 获得功能是否需要显示小红点。
        /// </summary>
        /// <param name="funcId"></param>
        /// <returns></returns>
        public bool IsFuncNeedRedDot(int funcId)
        {
            for (int i = 0; i < funcList.Count; i++)
            {
                if (funcList[i].funcType == funcId && funcList[i].isOpened == 1 && funcList[i].effect != 0)
                {
                   return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 添加功能与界面对象（按钮、页签）的绑定
        /// </summary>
        /// <param name="functionId"></param>
        /// <param name="go"></param>
        public void AddFuncBindObj(int functionId,GameObject go)
        {
            if (funcBindObjDic==null)
            {
                funcBindObjDic = new Dictionary<int, GameObject>();
            }
            if (!funcBindObjDic.ContainsKey(functionId))
            {
                funcBindObjDic.Add(functionId,go);
            }
            else
            {
                funcBindObjDic[functionId] = go;
            }
            bool find = false;
            //更新功能对应界面对象 的状态
            for (int i = 0; funcList != null && i < funcList.Count; i++)
            {
                if (funcList[i].funcType == functionId)
                {
                    updateOneFuncView(funcList[i]);
                    find = true;
                    break;
                }
            }
            if (!find)
            {
                go.SetActive(false);
            }
        }
        
        public void RemoveFuncBindObj(int functionId, GameObject go)
        {
            if (funcBindObjDic==null)
            {
                return;
            }
            
            if (funcBindObjDic.ContainsKey(functionId))
            {
                if (funcBindObjDic[functionId] == go)
                {
                    funcBindObjDic.Remove(functionId);
                }
            }
        }

        /// <summary>
        /// 更新功能对应界面对象的状态
        /// </summary>
        public void updateFuncView()
        {
            for (int i=0;funcList!=null&&i<funcList.Count;i++)
            {
                updateOneFuncView(funcList[i]);
            }
        }

        public void updateOneFuncView(FuncShowInfo funcinfo)
        {
            if (funcBindObjDic != null && funcinfo !=null&& funcBindObjDic.ContainsKey(funcinfo.funcType))
            {
                if (funcBindObjDic[funcinfo.funcType]!=null)
                {
                    funcBindObjDic[funcinfo.funcType].gameObject.SetActive(funcinfo.isOpened == 1);
                }
            }
        }

        public override void Destroy()
        {
            _ins = null;
            funcList.Clear();
            funcList = null;
            if (waitingShowFunc != null)
            {
                waitingShowFunc.Clear();
                waitingShowFunc = null;
            }
            if (funcBindObjDic != null)
            {
                funcBindObjDic.Clear();
                funcBindObjDic = null;
            }
        }
    }
}