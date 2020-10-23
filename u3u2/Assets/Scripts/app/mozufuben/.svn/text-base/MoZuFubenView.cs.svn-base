using app.db;
using app.human;
using app.net;
using app.pet;
using app.utils;

namespace app.mozufuben
{
    public class MoZuFubenView:BaseWnd
    {
        public MoZuFubenUI UI;

        public MoZuFubenView()
        {
            uiName = "MoZuFuBenUI";
        }

        public override void initWnd()
        {
            base.initWnd();
            
            UI = ui.AddComponent<MoZuFubenUI>();
            UI.Init();
            UI.closeBtn.SetClickCallBack(clickclose);
            UI.enterputongFuben.AddClickCallBack(clickEnterPutong);
            UI.enterkunnanFuben.AddClickCallBack(clickEnterKunnan);

            //MoZuFubenModel.Ins.addChangeEvent(MoZuFubenModel.Ins.UPDATE_MOZU_DATA,updateData);
        }

        private void clickEnterPutong()
        {
            SiegedemonCGHandler.sendCGSiegedemonAskEnterTeam(MoZuFubenModel.Ins.MoZuFuBenType_NORMAL);
            hide();
        }

        private void clickEnterKunnan()
        {
            SiegedemonCGHandler.sendCGSiegedemonAskEnterTeam(MoZuFubenModel.Ins.MoZuFuBenType_HARD);
            hide();
        }

        private void clickclose()
        {
             hide();
        }

        public override void show(RMetaEvent e = null)
        {
            base.show(e);
            updateData();
            SourceLoader.Ins.load(PathUtil.Ins.mozuAtlasPath, loadComplete, null, null, false, LoadArgs.SLIMABLE, LoadContentType.ABL);
        }

        private void loadComplete(RMetaEvent e)
        {
            PathUtil.Ins.SetSprite(UI.putongImage, "putongmozu",PathUtil.Ins.mozuAtlasPath,true);
            PathUtil.Ins.SetSprite(UI.kunnanImage, "kunnanmozu", PathUtil.Ins.mozuAtlasPath, true);
            UI.putongImage.gameObject.SetActive(true);
            UI.kunnanImage.gameObject.SetActive(true);
        }

        public void updateData(RMetaEvent e=null)
        {
            Pet mainRole = Human.Instance.PetModel.getLeader();
                int mylevel = mainRole.getLevel();
            int funcid =  FunctionIdDef.PUTONGMOZU;
            ActivityUITemplate at = ActivityUITemplateDB.Instance.GetActivityTemplateByFuncId(funcid);
            int needlevel = ConstantModel.Ins.GetIntValueByKey(ServerConstantDef.MOZU_PUTONG_OPENLEVEL);
            UI.putongLevel.text = ColorUtil.getColorText(mylevel >= needlevel, needlevel + "级开启");
            UI.putongDesc.text = (at!=null)?at.desc:"";

            funcid = FunctionIdDef.KUNNANMOZU;
            at = ActivityUITemplateDB.Instance.GetActivityTemplateByFuncId(funcid);
            needlevel = ConstantModel.Ins.GetIntValueByKey(ServerConstantDef.MOZU_KUNNAN_OPENLEVEL);
            UI.kunnanLevel.text = ColorUtil.getColorText(mylevel >= needlevel, needlevel + "级开启");
            UI.kunnanDesc.text = (at != null) ? at.desc : "";
        }

        public override void Destroy()
        {
            //MoZuFubenModel.Ins.removeChangeEvent(MoZuFubenModel.Ins.UPDATE_MOZU_DATA, updateData);
            if (UI != null)
            {
                UI.closeBtn.ClearClickCallBack();
                UI.enterputongFuben.ClearClickCallBack();
                UI.enterkunnanFuben.ClearClickCallBack();
            }
            UI = null;
            base.Destroy();
        }

        public override void hide(RMetaEvent e = null)
        {
            base.hide(e);

        }
    }
}
