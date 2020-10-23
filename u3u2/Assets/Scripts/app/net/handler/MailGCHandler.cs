using app.relation;

namespace app.net
{
	public class MailGCHandler : IGCHandler
	{
		public const string GCMailListEvent = "GCMailListEvent";
		public const string GCMailUpdateEvent = "GCMailUpdateEvent";
		public const string GCSendMailEvent = "GCSendMailEvent";
		public const string GCDelMailEvent = "GCDelMailEvent";
		public const string GCGetMailAttachmentEvent = "GCGetMailAttachmentEvent";

	    private MailModel mailModel;

		public MailGCHandler()
        {
            EventCore.addRMetaEventListener(GCMailListEvent, GCMailListHandler);
            EventCore.addRMetaEventListener(GCMailUpdateEvent, GCMailUpdateHandler);
            EventCore.addRMetaEventListener(GCSendMailEvent, GCSendMailHandler);
            EventCore.addRMetaEventListener(GCDelMailEvent, GCDelMailHandler);
            EventCore.addRMetaEventListener(GCGetMailAttachmentEvent, GCGetMailAttachmentHandler);

		    //mailModel = Singleton.getObj(typeof (MailModel)) as MailModel;
            mailModel = MailModel.Ins;
        }
        
        private void GCMailListHandler(RMetaEvent e)
        {
        	GCMailList msg = e.data as GCMailList;
            if (msg.getBoxType()==1)
            {//�ռ���
                mailModel.setReceiveMailList(msg.getMailInfos());
            }
        }
        
        private void GCMailUpdateHandler(RMetaEvent e)
        {
        	GCMailUpdate msg = e.data as GCMailUpdate;
            mailModel.updateMail(msg.getMail());
        }
        
        private void GCSendMailHandler(RMetaEvent e)
        {
        	GCSendMail msg = e.data as GCSendMail;
        	
        }
        
        private void GCDelMailHandler(RMetaEvent e)
        {
        	GCDelMail msg = e.data as GCDelMail;
        	
        }
        
        private void GCGetMailAttachmentHandler(RMetaEvent e)
        {
        	GCGetMailAttachment msg = e.data as GCGetMailAttachment;
        	
        }
        

	}
}