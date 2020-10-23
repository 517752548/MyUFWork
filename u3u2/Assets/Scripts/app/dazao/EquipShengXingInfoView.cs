namespace app.dazao
{
    public class EquipShengXingInfoView:BaseWnd
    {
        private ConfirmUI UI;

        //[Inject(ui = "ShengXingInfoUI")]
        //public GameObject ui;
        
        public EquipShengXingInfoView()
        {
            uiName = "ShengXingInfoUI";
        }
        public override void initWnd()
        {
            base.initWnd();
            UI = ui.AddComponent<ConfirmUI>();
            UI.Init();
            UI.sureBtn.SetClickCallBack(clickClose);
            UI.cancelBtn.SetClickCallBack(clickClose);
        }
        /*
        public override void initUILayer(WndType uilayer = WndType.FirstWND)
        {
            base.initUILayer(WndType.PopWND);
        }
        */
        private void clickClose()
        {
            hide();
        }
    }
}
