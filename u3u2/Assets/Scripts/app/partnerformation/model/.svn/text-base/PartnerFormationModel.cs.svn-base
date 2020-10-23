using System;

namespace app.partnerformation
{
    public class PartnerFormationModel
    {
        public PartnerUIScript partnerUIScript { get; set; }
        public FormationListUIScript formationListUIScript { get; set; }

        public PartnerInfoView partnerInfoView { get; set; }

        public int curOperFormationIndex { get; set; }
        public int curOperFormationPartnerPosIndex { get; set; }
        public int curOperFormationPartnerTplId { get; set; }

        public FormationPartnerItemUIScript curOperFormationPartnerItem { get; set; }

        public int curShowingPartnerTplId { get; set; }

        private static PartnerFormationModel mIns;

        public static PartnerFormationModel ins
        {
            get
            {
                if (mIns == null)
                {
                    mIns = new PartnerFormationModel();
                }
                return mIns;
            }
        }

        public void Destroy()
        {
            partnerUIScript = null;
            formationListUIScript = null;
            partnerInfoView = null;
            curOperFormationIndex = 0;
            curOperFormationPartnerPosIndex = 0;
            curOperFormationPartnerTplId = 0;
            curOperFormationPartnerItem = null;
            curShowingPartnerTplId = 0;
            mIns = null;
        }
    }
}