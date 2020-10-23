using UnityEngine;
using System.Collections;

namespace app.story
{
    public class StoryModel : AbsModel
    {
        public const string EXIT_STORY = "EXIT_STORY";
        private static StoryModel ins;

        public static StoryModel Ins
        {
            get
            {
                if (ins == null)
                {
                    ins = new StoryModel();
                }
                return ins;
            }
        }

        public void ExitStory()
        {
            dispatchChangeEvent(EXIT_STORY, null);
        }

        public override void Destroy()
        {
            ins = null;
        }
    }
}
