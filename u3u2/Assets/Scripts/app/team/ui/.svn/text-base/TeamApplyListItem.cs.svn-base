using UnityEngine;
using app.net;

namespace app.team
{
    public class TeamApplyListItem
    {
        private TeamApplyListItemUI mUI = null;
        private TeamInfo mData = null;
        
        public TeamApplyListItem(TeamApplyListItemUI UI)
        {
            mUI = UI;
        }

        public void SetData(TeamInfo data)
        {
            mData = data;
        }

        public void Destroy()
        {
            GameObject.DestroyImmediate(mUI.gameObject, true);
            mUI = null;
        }
    }
}

