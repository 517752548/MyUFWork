using app.net;
using app.db;
using System.Collections.Generic;


namespace app.tisheng
{
    public class TiShengItemScript
    {
        private tishengItemUI itemUI;
        public PromoteInfo info;
        private TiShengView tishengView;
        private PromoteTemplate template;

        public TiShengItemScript(tishengItemUI itemUI,TiShengView tishengView)
        {
            this.itemUI = itemUI;
            this.tishengView = tishengView;
            itemUI.buttonConfirm.SetClickCallBack(OnClickEnterFunc);
            itemUI.buttonCancle.SetClickCallBack(OnClickRemoveFunc);
        }
        public void SetData (PromoteInfo info)
        {
            this.info = info;
            SetInfo();
        }

        private void SetInfo()
        {
            if (itemUI == null || info == null)
            {
                return;
            }

            template = PromoteTemplateDB.Instance.getTemplate(info.protmoteId);
            itemUI.textDesc.text = template.promoteName;

        }


        private void OnClickEnterFunc()
        {
            tishengView.DoFunc(info.protmoteId);
        }

        private void OnClickRemoveFunc()
        {
            tishengView.RemoveShowFunc(info.protmoteId);
        }

        public void Show(bool show)
        {
            itemUI.gameObject.SetActive(show);
        }

        public void Destroy()
        {
            itemUI = null;
            info = null;
            tishengView = null;
            template = null;
        }

    }
}
