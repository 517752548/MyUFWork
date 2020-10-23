using app.human;
using app.role;
using app.net;
using app.db;
using app.xinfa;

namespace app.tips
{
    public class SkillTips : BaseTips
    {
        private static SkillTips mIns;

        //[Inject(ui = "skillTips")]
        //public GameObject ui;

        public SkillTipsUI UI;
        
        private PetSkillInfo mData = null;
        private SkillTemplate skilltpl = null;
        public SkillTips()
        {
            uiName = "skillTips";
        }

        public static SkillTips ins
        {
            get
            {
                if (mIns == null)
                {
                    mIns = Singleton.GetObj(typeof(SkillTips)) as SkillTips;
                }
                return mIns;
            }
        }
        
        public void ShowTips(PetSkillInfo data)
        {
            if (data==null)
            {
                return;
            }
            skilltpl = null;
            mData = data;
            preLoadUI();
        }

        public void ShowTips(SkillTemplate data)
        {
            if (data == null)
            {
                return;
            }
            skilltpl = data;
            mData = null;
            preLoadUI();
        }
        public override void initWnd()
        {
            base.initWnd();
            UI = ui.AddComponent<SkillTipsUI>();
            UI.Init();

        }
        
        public override void show(RMetaEvent e = null)
        {
            base.show(e);
            //showBgImage();
            setData();
        }

        private void setData()
        {
            if (UI != null && mData != null)
            {
                SkillTemplate skillTpl = SkillTemplateDB.Instance.getTemplate(mData.skillId);
                /*
                string path = PathUtil.Ins.GetUITexturePath(skillTpl.icon, PathUtil.TEXTUER_SKILL);
                SourceLoader.Ins.load(path, OnIconLoaded);
                */
                PathUtil.Ins.SetSkillIcon(UI.icon, skillTpl.icon);
                UI.nameTxt.text = skillTpl.name;
                UI.levelTxt.text = LangConstant.LEVEL_NAME + ": " + mData.level;
                UI.costTxt.text = LangConstant.CONSUME + ": " + (skillTpl.costBase + mData.level * skillTpl.costAdd) + ClientConstantDef.GetSkillCostTypeName(skillTpl.costTypeId);
                //UI.costTxt.text = "";
                //int mindId = Human.Instance.PropertyManager.getIntProp(RoleBaseIntProperties.MAINSKILL_TYPE);
                //int mindLv = Human.Instance.PropertyManager.getIntProp(RoleBaseIntProperties.MAINSKILL_LEVEL);
                int xinfaid = HumanMainSkillToSubSkillTemplateDB.Instance.GetXinFaIdBySkillId(skillTpl.Id);
                PetSkillInfo petskill = XinFaView.GetSkillProficiency(mData.skillId);
                int ceng = 1;
                if (null != petskill)
                {
                    ceng = petskill.layer;
                }
                UI.descTxt.text = skillTpl.GetDetailSkillDesc(xinfaid, 0, mData.level, ceng);
                UI.frame.gameObject.SetActive(false);
            }
            if (UI != null && skilltpl != null)
            {
                SkillTemplate skillTpl = skilltpl;
                /*
                string path = PathUtil.Ins.GetUITexturePath(skillTpl.icon, PathUtil.TEXTUER_SKILL);
                SourceLoader.Ins.load(path, OnIconLoaded);
                */
                PathUtil.Ins.SetSkillIcon(UI.icon, skillTpl.icon);
                UI.nameTxt.text = skillTpl.name;
                UI.levelTxt.text = "";
                UI.costTxt.text = LangConstant.CONSUME + ": " + (skillTpl.costBase + 1 * skillTpl.costAdd) + ClientConstantDef.GetSkillCostTypeName(skillTpl.costTypeId);
                //UI.costTxt.text = "";

                int xinfaid = HumanMainSkillToSubSkillTemplateDB.Instance.GetXinFaIdBySkillId(skillTpl.Id);
                PetSkillInfo petskill = XinFaView.GetSkillProficiency(skillTpl.Id);
                int ceng = 1;
                int skilllv = 1;
                if (null != petskill)
                {
                    ceng = petskill.layer;
                    skilllv = petskill.level;
                }
                UI.descTxt.text = skillTpl.GetDetailSkillDesc(xinfaid, 0, skilllv, ceng);
                UI.frame.gameObject.SetActive(false);
            }
        }
        
        /*
        private void OnIconLoaded(RMetaEvent e)
        {
            if (e.type == SourceLoader.LOAD_COMPLETE)
            {
                LoadInfo info = (LoadInfo)(e.data);
                string path = info.urlPath;
                Texture t = SourceManager.Ins.GetAsset<Texture>(path);
                if (t != null)
                {
                    UI.icon.texture = t;
                }
            }
        }
        */
    }
}