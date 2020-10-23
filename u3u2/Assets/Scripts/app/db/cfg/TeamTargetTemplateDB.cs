using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace app.db
{
    public class TeamTargetTemplateDB : TeamTargetTemplateDBBase
    {
        // TODO 可能会自定义一些属性或方法
        private List<KeyValuePair<int, TeamTargetTemplate>> mSortedIdKeyList = null;
        private Dictionary<int, string> groupIdKeyDic = null;

        private List<string> mTypes = new List<string>();

        public List<KeyValuePair<int, TeamTargetTemplate>> GetSortedIdKeyList()
        {
            if (mSortedIdKeyList == null)
            {
                //mSortedIdKeyDic = idKeyDic.OrderBy(o => o.Value.levelLimit).ToDictionary(o => o.Key, o => o.Value);
                mSortedIdKeyList = idKeyDic.OrderBy(o => o.Value.levelLimit).ToList();
            }
            return mSortedIdKeyList;
        }

        public override bool addTemplate(TeamTargetTemplate teamtargettemplate)
        {
            if (base.addTemplate(teamtargettemplate))
            {
                if (teamtargettemplate.typeName != null && teamtargettemplate.typeName != "")
                {
                    if (!mTypes.Contains(teamtargettemplate.typeName))
                    {
                        mTypes.Add(teamtargettemplate.typeName);
                        teamtargettemplate.typeId = mTypes.Count;
                    }
                    else
                    {
                        int len = mTypes.Count;
                        for (int i = 0; i < len; i++)
                        {
                            if (mTypes[i] == teamtargettemplate.typeName)
                            {
                                teamtargettemplate.typeId = i + 1;
                                break;
                            }
                        }
                    }
                }
                else
                {
                    teamtargettemplate.typeId = 0;
                }

                return true;
            }
            return false;
        }
    }
}
