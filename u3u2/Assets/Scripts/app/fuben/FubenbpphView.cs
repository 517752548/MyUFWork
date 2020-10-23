using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using app.net;


namespace app.fuben
{

    public class FubenbpphView : BaseWnd
    {

        //[Inject(ui = "FubenbpphUI")]
        //public GameObject ui;

        public FubenbpphUI UI;

        List<FbbpphItemScript> m_uiList = new List<FbbpphItemScript>();

        public TabButtonGroup m_tbg;
        
        public FubenbpphView()
        {
            uiName = "FubenbpphUI";
        }

        public override void initWnd()
        {
            base.initWnd();
            UI = ui.AddComponent<FubenbpphUI>();
            UI.Init();
            UI.m_obj_uiitem.SetActive(false);
            UI.m_btn_close.SetClickCallBack(CloseOnClick);
            m_tbg = UI.m_obj_uiitem.transform.parent.GetComponent<TabButtonGroup>();
            
        }

        public override void show(RMetaEvent e = null)
        {
            base.show(e);
            UpdateView();
        }

        public void UpdateView()
        {
            for (int i = 0; i < FubenbpjsModel.ins.Rankinfo.Length; i++)
            {
                if (i >= m_uiList.Count)
                {
                    //不够需要添加
                    FbbpphItemScript item = getOneItem();
                    item.m_ui.transform.SetParent(UI.m_obj_uiitem.transform.parent);
                    item.m_ui.transform.SetAsLastSibling();
                    item.m_ui.transform.localScale = Vector3.one;
                    m_uiList.Add(item);
                    m_tbg.AddToggle(item.m_ui.GetComponent<GameUUToggle>());
                }
                CheckThree(i);
                m_uiList[i].m_ui.m_tex_paiming.text = i.ToString();
                m_uiList[i].m_ui.gameObject.SetActive(true);
                m_uiList[i].SetData(FubenbpjsModel.ins.Rankinfo[i]);
            }
            for (int i = FubenbpjsModel.ins.Rankinfo.Length; i < m_uiList.Count; i++)
            {
                m_uiList[i].m_ui.gameObject.SetActive(false);
            }

        }

        private FbbpphItemScript getOneItem()
        {
            GameObject obj = GameObject.Instantiate(UI.m_obj_uiitem) as GameObject;
            obj.SetActive(true);
            FBbpphItemUI itemui = obj.GetComponent<FBbpphItemUI>();
            FbbpphItemScript itemUnit = new FbbpphItemScript(itemui);
            return itemUnit;
        }

        //前三名显示特殊处理
        private void CheckThree(int num) {
            if (num < 3) {
                m_uiList[num].m_ui.m_tex_paiming.gameObject.SetActive(false);
            }
            switch (num) {
                case 0:
                    PathUtil.Ins.SetSprite(m_uiList[num].m_ui.m_obj_qiansan, "1st", PathUtil.Ins.uiDependenciesPath,true);
                    break;
                case 1:
                    PathUtil.Ins.SetSprite(m_uiList[num].m_ui.m_obj_qiansan, "2nd", PathUtil.Ins.uiDependenciesPath, true);
                    break;
                case 2:
                    PathUtil.Ins.SetSprite(m_uiList[num].m_ui.m_obj_qiansan, "3rd", PathUtil.Ins.uiDependenciesPath, true);
                    break;
                default:
                    m_uiList[num].m_ui.m_obj_qiansan.gameObject.SetActive(false);
                    break;
            }
        }

        private void CloseOnClick() {
            hide();
        }

    }

    public class FbbpphItemScript {

        public FBbpphItemUI m_ui;

        public FbbpphItemScript(FBbpphItemUI ui) {
            m_ui = ui;
        }

        public void SetData(CorpsWarRankInfo info) {
            if (m_ui.m_tex_Score != null) m_ui.m_tex_Score.text = info.score.ToString();
            if (m_ui.m_tex_bpName != null) m_ui.m_tex_bpName.text = info.name.ToString();
        }

    }

}
    
