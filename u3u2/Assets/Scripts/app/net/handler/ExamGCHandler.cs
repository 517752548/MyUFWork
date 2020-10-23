using app.keju;
namespace app.net
{
    public class ExamGCHandler : IGCHandler
    {
        public const string GCExamApplyEvent = "GCExamApplyEvent";
        public const string GCExamUseItemEvent = "GCExamUseItemEvent";
        public const string GCExamChoseEvent = "GCExamChoseEvent";
        public const string GCExamInfoEvent = "GCExamInfoEvent";

        public ExamGCHandler()
        {
            EventCore.addRMetaEventListener(GCExamApplyEvent, GCExamApplyHandler);
            EventCore.addRMetaEventListener(GCExamUseItemEvent, GCExamUseItemHandler);
            EventCore.addRMetaEventListener(GCExamChoseEvent, GCExamChoseHandler);
            EventCore.addRMetaEventListener(GCExamInfoEvent, GCExamInfoHandler);
        }

        private void GCExamApplyHandler(RMetaEvent e)
        {
            GCExamApply msg = e.data as GCExamApply;

            KeJuModel.Ins.GCExamApply(msg);
        }

        private void GCExamUseItemHandler(RMetaEvent e)
        {
            //GCExamUseItem msg = e.data as GCExamUseItem;

        }

        private void GCExamChoseHandler(RMetaEvent e)
        {
            //GCExamChose msg = e.data as GCExamChose;

        }

        private void GCExamInfoHandler(RMetaEvent e)
        {
            GCExamInfo msg = e.data as GCExamInfo;
            KeJuModel.Ins.changeExamInfo(msg.getExamInfo());

        }


    }
}