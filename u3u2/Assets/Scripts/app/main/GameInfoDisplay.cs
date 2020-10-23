using UnityEngine;
using app.state;
using app.zone;
using app.battle;

namespace app.main
{
    public class GameInfoDisplay : MonoBehaviour
    {
        private Texture2D mBg;
        private float mScale = 1.0f;

        void Awake()
        {
            mBg = Texture2D.blackTexture;
            mScale = (float)UGUIConfig.UISpaceHeight / (float)UGUIConfig.designHeight;
            mBg.Resize((int)(182.0f * mScale), (int)(20.0f * mScale));
        }
        

        public static long MLastFps
        {
            get { return mLastFps; }
        }

        void Update()
        {
            UpdateTick();
        }

        void OnGUI()
        {
            DrawFps();
        }

        private void DrawFps()
        {
            StateBase state = StateManager.Ins.getCurState();
            if (state != null)
            {
                GUI.backgroundColor = Color.red;
                GUIStyle style = new GUIStyle();
                style.fontSize = (int)(16.0f * mScale);
                style.normal.background = mBg;
                if (mLastFps > 30)
                {
                    style.normal.textColor = new Color(0, 1, 0);
                }
                else if (mLastFps > 16)
                {
                    style.normal.textColor = new Color(1, 1, 0);
                }
                else
                {
                    style.normal.textColor = new Color(1, 0, 0);
                }

                int playerCount = 0;
                int chaCountForFPS = 0;
                if (state.state == StateDef.zoneState)
                {
                    playerCount = ZoneCharacterManager.ins.othersCount + 1;
                    chaCountForFPS = ZoneCharacterManager.ins.othersCountForFPS + ZoneNPCManager.Ins.NpcCount + 1;
                }
                else if (state.state == StateDef.battleState)
                {
                    
                    playerCount = chaCountForFPS = BattleCharacterManager.ins.attackersCount + BattleCharacterManager.ins.defendersCount;
                }

                GUI.Label(new Rect(0, 0, mBg.width, mBg.height), "FPS: " + mLastFps + " 同屏玩家数:" + playerCount/* + "\n本场景总人数: " + chaCountForFPS*/, style);
            }
        }

        private long mFrameCount = 0;
        private long mLastFrameTime = 0;
        static long mLastFps = 0;
        private void UpdateTick()
        {
            if (true)
            {
                mFrameCount++;
                long nCurTime = TickToMilliSec(System.DateTime.Now.Ticks);
                if (mLastFrameTime == 0)
                {
                    mLastFrameTime = nCurTime;
                }

                if ((nCurTime - mLastFrameTime) >= 1000)
                {
                    long fps = (long)(mFrameCount * 1.0f / ((nCurTime - mLastFrameTime) / 1000.0f));

                    mLastFps = fps;

                    mFrameCount = 0;

                    mLastFrameTime = nCurTime;
                }
            }
        }
        public static long TickToMilliSec(long tick)
        {
            return tick / (10 * 1000);
        }
    }
}