using app.ridepet;

namespace app.partnerformation
{
	public class PartnerFormationView : BaseWnd
	{
		//[Inject(ui = "PartnerFormationUI")]
        //public GameObject ui;

        public PartnerUI UI;

	    private RidePetView ridePetView;
		
		public PartnerFormationView()
		{
			uiName = "PartnerFormationUI";
		}

		public override void initWnd()
		{
			base.initWnd();

            UI = ui.AddComponent<PartnerUI>();
            UI.Init();
			UI.closeBtn.SetClickCallBack(Close);
		    UI.tabs.TabChangeHandler = changeTab;

			PartnerFormationModel.ins.partnerUIScript = new PartnerUIScript(UI.partnerFormationUI.partnerUI);
            PartnerFormationModel.ins.formationListUIScript = new FormationListUIScript(UI.partnerFormationUI.formationUI);

            ridePetView = new RidePetView(UI.ridePetUI);
            UI.tabs.toggleList[0].gameObject.SetActive(false);


		}
		
		public override void Update()
		{
			base.Update();
			if (UI.partnerFormationUI.gameObject.activeSelf)
			{
				//PartnerFormationModel.ins.partnerUIScript.Update();
				//PartnerFormationModel.ins.formationListUIScript.Update();
			}
			else if (UI.ridePetUI.gameObject.activeSelf)
			{
				//ridePetView.Update();
			}
		}

	    private void changeTab(int index)
	    {
	        switch (index)
	        {
                case 0:
                    UI.partnerFormationUI.gameObject.SetActive(true);
                    UI.ridePetUI.gameObject.SetActive(false);
                    UI.title.text = "伙  伴";
                    PartnerFormationModel.ins.partnerUIScript.Show();
			        PartnerFormationModel.ins.formationListUIScript.Show();
	                break;
                case 1:
                    UI.title.text = "骑  宠";
                    UI.partnerFormationUI.gameObject.SetActive(false);
                    UI.ridePetUI.gameObject.SetActive(true);
                    ridePetView.show();
	                break;
	        }
	    }
		
		private void Close()
		{
			hide();
            PartnerFormationModel.ins.curOperFormationIndex = -1;
            PartnerFormationModel.ins.curOperFormationPartnerPosIndex = -1;
            PartnerFormationModel.ins.curOperFormationPartnerTplId = 0;
			if (PartnerFormationModel.ins.curOperFormationPartnerItem != null)
			{
				PartnerFormationModel.ins.curOperFormationPartnerItem.ResetStatus();
            	PartnerFormationModel.ins.curOperFormationPartnerItem = null;
			}
//			PartnerFormationModel.ins.partnerUIScript.ResetPartnerItemStatus();
		}
		
		public override void show(RMetaEvent e = null)
		{
			base.show(e);
            UI.tabs.toggleList[1].isOn = true;
            UI.tabs.SetIndexWithCallBack(1);
			app.main.GameClient.ins.OnBigWndShown();
		}
		
		public override void hide(RMetaEvent e = null)
		{
			base.hide(e);
			app.main.GameClient.ins.OnBigWndHidden();
		}
		
		public override void Destroy()
		{
			PartnerFormationModel.ins.partnerUIScript.Destroy();
			PartnerFormationModel.ins.partnerUIScript = null;
            PartnerFormationModel.ins.formationListUIScript.Destroy();
			PartnerFormationModel.ins.formationListUIScript = null;
			ridePetView.Destroy();
			ridePetView = null;
			base.Destroy();
			UI = null;
		}
	}
}