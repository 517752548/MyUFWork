using System.Collections.Generic;
using System.Linq;
using app.net;

namespace app.relation
{
    public class MailStatus
    {
        /** 未读 */
        public const int UNREAD = 1;
        /** 已读 */
        public const int READED = 2;
        /** 已保存 */
        public const int SAVED = 4;
        /** 已发送 */
        public const int SENDED = 8;
    }

    public class MailModel : AbsModel
    {
        public const string REFRESH_LIST = "REFRESH_LIST";
        public const string UPDATE_MAIL_INFO = "UPDATE_MAIL_INFO";
        private static MailModel _ins;
        public static MailModel Ins
        {
            get
            {
                if (_ins == null)
                {
                    //_ins = Singleton.getObj(typeof(MailModel)) as MailModel;
                    _ins = new MailModel();
                }
                return _ins;
            }
        }
        /// <summary>
        /// 收件箱
        /// </summary>
        private List<MailInfoData> mailList;

        /// <summary>
        /// 收件箱
        /// </summary>
        public List<MailInfoData> MailList
        {
            get { return mailList; }
        }

        public void setReceiveMailList(MailInfoData[] mailistv)
        {
            mailList = mailistv.ToList();
            dispatchChangeEvent(REFRESH_LIST, null);
        }

        public void updateMail(MailInfoData mailInfo)
        {
            for (int i = 0; i < mailList.Count; i++)
            {
                if (mailList[i].uuid == mailInfo.uuid)
                {
                    mailList[i] = mailInfo;
                    break;
                }
            }
            dispatchChangeEvent(UPDATE_MAIL_INFO, mailInfo);
        }

        public override void Destroy()
        {
            if (mailList != null)
            {
                mailList.Clear();
                mailList = null;
            }
            _ins = null;
        }
    }
}