using System.Collections.Generic;
using System.Linq;
using app.model;

namespace app.net
{
	public class GuideGCHandler : IGCHandler
	{
		public const string GCShowGuideInfoEvent = "GCShowGuideInfoEvent";
		public const string GCFuncHasGuideEvent = "GCFuncHasGuideEvent";
		public const string GCFuncHasGuideListEvent = "GCFuncHasGuideListEvent";
		public const string GCFinishedGuideListByFuncEvent = "GCFinishedGuideListByFuncEvent";
		public const string GCFinishedGuideByFuncEvent = "GCFinishedGuideByFuncEvent";

		public GuideGCHandler()
        {
            EventCore.addRMetaEventListener(GCShowGuideInfoEvent, GCShowGuideInfoHandler);
            EventCore.addRMetaEventListener(GCFuncHasGuideEvent, GCFuncHasGuideHandler);
            EventCore.addRMetaEventListener(GCFuncHasGuideListEvent, GCFuncHasGuideListHandler);
            EventCore.addRMetaEventListener(GCFinishedGuideListByFuncEvent, GCFinishedGuideListByFuncHandler);
            EventCore.addRMetaEventListener(GCFinishedGuideByFuncEvent, GCFinishedGuideByFuncHandler);
        }
        
        private void GCShowGuideInfoHandler(RMetaEvent e)
        {
        	GCShowGuideInfo msg = e.data as GCShowGuideInfo;
            if (msg.getGuideTypeId()==(int)GuideIdDef.QianDao
                || msg.getGuideTypeId() == (int)GuideIdDef.PetTalent)
            {
                return;
            }
            //ClientLog.LogError("GCShowGuideInfo: "+msg.getGuideTypeId());
            bool CanDoImmediate = false;
            if ((GuideIdDef)(msg.getGuideTypeId()) == GuideIdDef.FirstBattle || (GuideIdDef)(msg.getGuideTypeId()) == GuideIdDef.SkillShengJi)
            {
                CanDoImmediate = true;
            }
            if (!PlayerModel.Ins.isLoginFinished)
            {
                //没有登陆完成的时候 ，不能立即显示新手引导
                CanDoImmediate = false;
            }
            if (!GuideManager.Ins.IsFuncGuide((GuideIdDef)(msg.getGuideTypeId())))
            {
                GuideManager.Ins.StartGuide((GuideIdDef)(msg.getGuideTypeId()), CanDoImmediate);
            }
        }
        
        private void GCFuncHasGuideHandler(RMetaEvent e)
        {
        	GCFuncHasGuide msg = e.data as GCFuncHasGuide;
            //ClientLog.LogError("GCFuncHasGuide: " + msg.getFuncTypeId());
            Dictionary<int, bool> dic = new Dictionary<int, bool>();
            dic.Add(msg.getFuncTypeId(), true);
            GuideManager.Ins.updateFuncHasGuide(dic);
        }
        
        private void GCFuncHasGuideListHandler(RMetaEvent e)
        {
        	GCFuncHasGuideList msg = e.data as GCFuncHasGuideList;
            Dictionary<int, bool> dic = new Dictionary<int, bool>();
            for (int i = 0; i < msg.getFuncTypeId().Length; i++)
            {
                //ClientLog.LogError("GCFuncHasGuideList: " + msg.getFuncTypeId()[i]);
                dic.Add(msg.getFuncTypeId()[i], true);
            }
            GuideManager.Ins.updateFuncHasGuide(dic);
        }
        
        private void GCFinishedGuideListByFuncHandler(RMetaEvent e)
        {
        	GCFinishedGuideListByFunc msg = e.data as GCFinishedGuideListByFunc;

            Dictionary<int, bool> dic = new Dictionary<int, bool>();
            for (int i=0;i<msg.getFuncTypeIdList().Length;i++)
            {
                //ClientLog.LogError("GCFinishedGuideListByFunc: " + msg.getFuncTypeIdList()[i]);
                dic.Add(msg.getFuncTypeIdList()[i], false);
            }
            GuideManager.Ins.updateFuncHasGuide(dic);
        }
        
        private void GCFinishedGuideByFuncHandler(RMetaEvent e)
        {
        	GCFinishedGuideByFunc msg = e.data as GCFinishedGuideByFunc;
            Dictionary<int,bool> dic = new Dictionary<int, bool>();
            dic.Add(msg.getFuncTypeId(),false);
            //ClientLog.LogError("GCFinishedGuideByFunc: " + msg.getFuncTypeId());
            GuideManager.Ins.updateFuncHasGuide(dic);
        }
        

	}
}