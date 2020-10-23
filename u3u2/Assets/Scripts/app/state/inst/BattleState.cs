 
 
using System.Collections.Generic;
using app.db;
using app.fuben;
using app.npc;
using UnityEngine;
using app.battle;

namespace app.state
{
    public class BattleState : StateBase
    {
        /// <summary>
        /// 进入战斗后 保持开启的界面 列表
        /// </summary>
        private List<string> keepOpenWndInBattle=new List<string>();

        public BattleState()
        {
            this.state = StateDef.battleState;
            initKeepOpenWndList();
        }

        public override bool canEnter()
        {
            //没有上阵武将，不能战斗
            return true;
        }

        public override bool canLeave()
        {
            //TODO
            return true;
        }

        public override void onEnter()
        {
            base.onEnter();
            BattleManager.ins.EnterBattleState();
            //SourceManager.Ins.ingoreDispose("Battle");
            //SourceManager.Ins.ingoreDispose(PathUtil.Ins.GetUIPath("numBubble"));
            //SourceManager.Ins.ingoreDispose(PathUtil.Ins.GetUIPath("talkBubble"));
            //SourceManager.Ins.ingoreDispose(PathUtil.BATTLE_EFFECT_RELATIVE_DIR);
            //SourceManager.Ins.ingoreDispose(PathUtil.BATTLE_CHARACTER_RELATIVE_DIR);
            //SourceManager.Ins.ingoreDispose(PathUtil.BATTLE_WEAPON_RELATIVE_DIR);
            //SourceManager.Ins.ingoreDispose(PathUtil.BATTLE_FIELD_RELATIVE_DIR);
            AudioManager.Ins.PlayAudio(ClientConstantDef.BATTLE_BG_MUSIC_NAME,AudioEnumType.BackGround);
            LinkParse.Ins.ClearLink();
            FubenNormalWnd.Ins.hide();
            WndManager.Ins.HideAllCurrentShowWndExcept(keepOpenWndInBattle);
            if (JuQingManager.Ins.IsPlayingJuQing)
            {
                JuQingManager.Ins.StopJuQing();
            }
            if (GuideManager.Ins.CurrentGuideId != GuideIdDef.NONE && GuideManager.Ins.CurrentGuideId != GuideIdDef.FirstBattle)
            {//进入战斗把正在做的引导冲掉
                GuideManager.Ins.RemoveGuide(GuideManager.Ins.CurrentGuideId);
            }
        }

        public override void onLeave(StateDef nextState)
        {
            base.onLeave(nextState);
            BattleManager.ins.ExitBattleState();
            AudioManager.Ins.DestroyAll();
            if (GuideManager.Ins.CurrentGuideId==GuideIdDef.FirstBattle)
            {
                GuideManager.Ins.RemoveGuide(GuideIdDef.FirstBattle);
            }
            //SourceManager.Ins.uningoreDispose("Battle");
            //SourceManager.Ins.ClearAllReference("Battle");
            //SourceManager.Ins.uningoreDispose(PathUtil.BATTLE_EFFECT_RELATIVE_DIR);
            //SourceManager.Ins.uningoreDispose(PathUtil.BATTLE_CHARACTER_RELATIVE_DIR);
            //SourceManager.Ins.uningoreDispose(PathUtil.BATTLE_WEAPON_RELATIVE_DIR);
            //SourceManager.Ins.uningoreDispose(PathUtil.BATTLE_FIELD_RELATIVE_DIR);
        }

        public override void onUpdate()
        {
            base.onUpdate();
            BattleManager.ins.Update();
        }

        public override void onFixedUpdate()
        {
            base.onFixedUpdate();
            BattleManager.ins.FixedUpdate();
        }

        private void initKeepOpenWndList()
        {
            keepOpenWndInBattle.Add(GlobalConstDefine.RoleInfoView_Name);
        }
    }
}
