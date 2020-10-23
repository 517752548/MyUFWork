using app.dazao;
using app.human;
using app.qianghua;
using app.zone;

namespace app.net
{
	public class EquipGCHandler : IGCHandler
	{
		public const string GCEqpCraftEvent = "GCEqpCraftEvent";
		public const string GCEqpCraftInfoEvent = "GCEqpCraftInfoEvent";
		public const string GCEqpUpstarEvent = "GCEqpUpstarEvent";
		public const string GCEqpGemTakedownEvent = "GCEqpGemTakedownEvent";
		public const string GCEqpGemSetEvent = "GCEqpGemSetEvent";
		public const string GCEqpGemSynthesisEvent = "GCEqpGemSynthesisEvent";
		public const string GCEqpRecastEvent = "GCEqpRecastEvent";
		public const string GCEqpDecomposeEvent = "GCEqpDecomposeEvent";
		public const string GCEqpHoleEvent = "GCEqpHoleEvent";

		public EquipGCHandler()
        {
            EventCore.addRMetaEventListener(GCEqpCraftEvent, GCEqpCraftHandler);
            EventCore.addRMetaEventListener(GCEqpCraftInfoEvent, GCEqpCraftInfoHandler);
            EventCore.addRMetaEventListener(GCEqpUpstarEvent, GCEqpUpstarHandler);
            EventCore.addRMetaEventListener(GCEqpGemTakedownEvent, GCEqpGemTakedownHandler);
            EventCore.addRMetaEventListener(GCEqpGemSetEvent, GCEqpGemSetHandler);
            EventCore.addRMetaEventListener(GCEqpGemSynthesisEvent, GCEqpGemSynthesisHandler);
            EventCore.addRMetaEventListener(GCEqpRecastEvent, GCEqpRecastHandler);
            EventCore.addRMetaEventListener(GCEqpDecomposeEvent, GCEqpDecomposeHandler);
            EventCore.addRMetaEventListener(GCEqpHoleEvent, GCEqpHoleHandler);
        }

        private void GCEqpCraftHandler(RMetaEvent e)
        {
            GCEqpCraft msg = e.data as GCEqpCraft;
            Human.Instance.PetModel.GCEqpCraftHandler(msg);
            EventCore.dispathRMetaEventByParms(EquipDaZaoScript.DAZAO_RESULT, msg);
        }

        private void GCEqpCraftInfoHandler(RMetaEvent e)
        {
            GCEqpCraftInfo msg = e.data as GCEqpCraftInfo;
            EventCore.dispathRMetaEventByParms(EquipDaZaoScript.DAZAO_INFO, msg);
        }

        private void GCEqpUpstarHandler(RMetaEvent e)
        {
            GCEqpUpstar msg = e.data as GCEqpUpstar;
            Human.Instance.PetModel.GCEqpUpstarHandler(msg);
            EventCore.dispathRMetaEventByParms(EquipShengXingScript.SHENGXING_RESULT, msg.getResult());
        }

        private void GCEqpGemSynthesisHandler(RMetaEvent e)
        {
            GCEqpGemSynthesis msg = e.data as GCEqpGemSynthesis;
            //ClientLog.LogError("GCEqpGemSynthesisHandler:getSucNum:" + msg.getSucNum() + " getFailNum:" + msg.getFailNum());
            if (msg.getSucNum() > 0)
            {
                //ZoneBubbleManager.ins.BubbleSysMsg("合成成功！");
                EventCore.dispathRMetaEventByParms(EquipHeChengScript.HECHENG_RESULT, null);
            }
            //if (msg.getFailNum() > 0)
            //{
            //    ZoneBubbleManager.ins.BubbleSysMsg("合成失败！");
            //}
        }

        private void GCEqpRecastHandler(RMetaEvent e)
        {
            GCEqpRecast msg = e.data as GCEqpRecast;
            if (msg.getResult() == 1)
            {
                ZoneBubbleManager.ins.BubbleSysMsg("重铸成功！");
            }
            else
            {
                ZoneBubbleManager.ins.BubbleSysMsg("重铸失败！");
            }
            EventCore.dispathRMetaEventByParms(EquipChongZhuScript.CHONGZHU_RESULT, msg.getResult());
        }

        private void GCEqpDecomposeHandler(RMetaEvent e)
        {
            GCEqpDecompose msg = e.data as GCEqpDecompose;
            if (msg.getResult() == 1)
            {
                ZoneBubbleManager.ins.BubbleSysMsg("分解成功！");
            }
            else
            {
                ZoneBubbleManager.ins.BubbleSysMsg("分解失败！");
            }
            EventCore.dispathRMetaEventByParms(EquipFenJieScript.FENJIE_RESULT, msg.getResult());
        }

        private void GCEqpGemSetHandler(RMetaEvent e)
        {
            GCEqpGemSet msg = e.data as GCEqpGemSet;
            string str;
            if (msg.getFinalGemItemId() == 0)
            {
                str = "镶嵌失败，宝石消失";
            }else if (msg.getGemItemId()==msg.getFinalGemItemId())
            {
                str = "镶嵌成功";
            }else
            {
                int l = ConstantModel.Ins.GetIntValueByKey(ServerConstantDef.GEM_LEVEL_COEF);
                str = "宝石等级降低" + l + "级,且镶嵌到装备上";
            }
            ZoneBubbleManager.ins.BubbleSysMsg(str);

            //if ((msg.getFinalGemItemId() != 0))
            //{
                EventCore.dispathRMetaEventByParms(EquipBaoshiScript.UPDATE_RESULT, msg);
            //}
        }

		private void GCEqpGemTakedownHandler(RMetaEvent e)
        {
        	GCEqpGemTakedown msg = e.data as GCEqpGemTakedown;
            string str;
            if (msg.getFinalGemItemId() == 0)
            {
                str = "摘除成功，宝石消失";
            }
            else if (msg.getGemItemId() == msg.getFinalGemItemId())
            {
                str = "摘除成功";
            }
            else
            {
                int l = ConstantModel.Ins.GetIntValueByKey(ServerConstantDef.GEM_LEVEL_COEF);
                str = "宝石等级降低" + l + "级,且摘除成功";
            }
            ZoneBubbleManager.ins.BubbleSysMsg(str);
            EventCore.dispathRMetaEventByParms(EquipBaoshiScript.UPDATE_RESULT, msg);
        }

        private void GCEqpHoleHandler(RMetaEvent e)
        {
            GCEqpHole msg = e.data as GCEqpHole;
            if (msg.getResult() == 1)
            {
                ZoneBubbleManager.ins.BubbleSysMsg((msg.getIsRefresh() == 1) ? "洗孔成功！" : "打孔成功！");
                EventCore.dispathRMetaEventByParms(EquipBaoshiScript.UPDATE_RESULT, msg);
            }
            else
            {
                ZoneBubbleManager.ins.BubbleSysMsg((msg.getIsRefresh() == 1) ? "洗孔失败！" : "打孔失败！");
            }
        }
        
	}
}