using app.battle;
using app.db;
using app.model;
using UnityEngine;
using app.human;

namespace app.story
{
    public class StoryBattleCell
    {
        public StoryBattleTemplate m_data;

        public float m_speed;

        /// <summary>
        /// 角色名称替换字符串
        /// </summary>
        private string m_role_replace = "{rolename}";

        public StoryBattleCell(StoryBattleTemplate data)
        {
            m_data = data;
        }

        /// <summary>
        /// 播放动画
        /// </summary>
        /// <param name="speed"></param>
        public void PlayVideo(float speed)
        {
            m_speed = speed;
            StoryBattleAvatar avatar = StoryManager.ins.GetBattleAvatar(m_data.targetId);
            switch (m_data.eventType)
            {
                case (int)StoryEventType.EntryText:
                    if (!string.IsNullOrEmpty(m_data.speak))
                    {//开场剧情
                        (Singleton.GetObj(typeof (StoryView)) as StoryView).showEntryText(m_data.speak);
                    }
                    break;
                case (int)StoryEventType.ShakeCamera:
                    if (m_data.posX>0)
                    {
                        float shaketime = m_data.posX*1f/1000f;
                        StoryManager.ins.ShakeCamera(shaketime);
                    }
                    break;
                case (int)StoryEventType.Skill:
                    if (avatar != null)
                    {
                        avatar.DoBatSkill(m_data);
                    }
                    break;
                case (int)StoryEventType.Dodgy:
                    if (avatar != null)
                    {
                        avatar.DoDodgy();
                    }
                    break;
                case (int)StoryEventType.Fly:
                    if (avatar != null)
                    {
                        avatar.Fly();
                    }
                    break;
                case (int)StoryEventType.RunAway:
                    if (avatar != null)
                    {
                        avatar.DoEscape();
                    }
                    break;
                case (int)StoryEventType.Music:
                    string audioname = m_data.modelName;
                    if ((AudioEnumType)m_data.posX==AudioEnumType.Skill)
                    {
                        audioname = "skill_" + audioname;
                    }
                    AudioManager.Ins.PlayAudio(audioname, (AudioEnumType)m_data.posX);
                    break;
                default:
                    if ((int)StoryStatusType.Appear == m_data.status)
                    {
                        ///创建///
                        CreateModel(m_data);
                    }
                    else if ((int)StoryStatusType.Update == m_data.status)
                    {
                        ///更新///
                        CheckUpdateModel();
                    }
                    else if ((int)StoryStatusType.DisAppear == m_data.status)
                    {
                        ///消失///
                        StoryManager.ins.DestroyOneModel(m_data.targetId);
                        return;
                    }
                    break;
            }
            //检查站位改变，站位带朝向
            CheckPosAndEuler();
            //需要单独设置朝向的
            CheckDirection();
            //检查动作更改
            CheckAnim();
            //检查说话
            CheckTalk();
            //检查名字变化
            CheckNameChange();
            //检查单独血量变化
            CheckBloodChange();
        }

        /// <summary>
        /// 创建角色
        /// </summary>
        private void CreateModel(StoryBattleTemplate cdata)
        {
            switch (cdata.targetType)
            {
                case (int)StoryObjectType.Player:
                    //是主角
                    StoryBattleAvatar avatar1 = new StoryBattleAvatar();
                    cdata.modelName = Human.Instance.get3DModel();
                    cdata.targetName = Human.Instance.getName();
                    avatar1.InitStory(cdata);
                    StoryManager.ins.AddBattleAvatar(cdata.targetId, avatar1);
                    break;
                case (int)StoryObjectType.OhterModel:
                    if (!string.IsNullOrEmpty(cdata.modelName))
                    {
                        StoryBattleAvatar avatar2 = new StoryBattleAvatar();
                        avatar2.InitStory(cdata);
                        StoryManager.ins.AddBattleAvatar(cdata.targetId, avatar2);
                    }
                    break;
                case (int)StoryObjectType.Effect:
                    if (!string.IsNullOrEmpty(cdata.modelName))
                    {
                        StoryEffect avatar3 = new StoryEffect();
                        Vector3 position3 = Vector3.zero;
                        //站位
                        position3 = SceneModel.ins.zoneCamsContainer.transform.localPosition +
                                    StoryDef.getPos(cdata);
                        avatar3.PlayEffect(cdata.modelName, cdata.targetName, position3);
                        StoryManager.ins.AddEffect(cdata.targetId, avatar3);
                    }
                    break;
            }
        }

        /// <summary>
        /// 是否更新模型
        /// </summary>
        private void CheckUpdateModel()
        {
            if (!string.IsNullOrEmpty(m_data.modelName))
            {
                StoryBattleAvatar avatar = StoryManager.ins.GetBattleAvatar(m_data.targetId);
                if (avatar!=null&&avatar.CurData.modelName!=m_data.modelName)
                {
                    avatar.changeModel(m_data);

                    //StoryManager.ins.DestroyOneModel(m_data.targetId);
                    //avatar.CurData.modelName = m_data.modelName;
                    //CreateModel(avatar.CurData);
                }
            }
        }
        /// <summary>
        /// 是否位置
        /// </summary>
        private void CheckPosAndEuler()
        {
            StoryBattleAvatar avatar = StoryManager.ins.GetBattleAvatar(m_data.targetId);
            if (avatar != null)
            {
                if (m_data.posX != 0 && (m_data.posX != avatar.CurData.posX || m_data.posY != avatar.CurData.posY))
                {
                    avatar.UpdatePosAndEuler(m_data);
                }
            }
        }

        /// <summary>
        /// 是否播放动作
        /// </summary>
        private void CheckAnim()
        {
            if (!string.IsNullOrEmpty(m_data.action))
            {
                StoryBattleAvatar myavatar = StoryManager.ins.GetBattleAvatar(m_data.targetId);
                if (null != myavatar)
                {
                    myavatar.PlayAnimation(m_data.action);
                }
            }
        }

        /// <summary>
        /// 检查是否修改朝向
        /// </summary>
        private void CheckDirection()
        {
            if (m_data.direction > 0 && m_data.direction < 9)
            {
                //设置人物朝向
                StoryBattleAvatar myavatar = StoryManager.ins.GetBattleAvatar(m_data.targetId);
                if (null != myavatar)
                {
                    myavatar.UpdateEulerAngles(m_data.direction);
                }
            }
        }
        /// <summary>
        /// 检查是否修改非主角的名字
        /// </summary>
        private void CheckNameChange()
        {
            if (!string.IsNullOrEmpty(m_data.targetName))
            {
                StoryBattleAvatar myavatar = StoryManager.ins.GetBattleAvatar(m_data.targetId);
                if (null != myavatar)
                {
                    myavatar.UpdateAvatarName(m_data.targetName);
                }
            }
        }
        /// <summary>
        /// 检查单独血量变化
        /// </summary>
        private void CheckBloodChange()
        {
            if (m_data.status!=1 && m_data.hp!=0&&m_data.eventType!=(int)StoryEventType.Skill)
            {
                StoryBattleAvatar myavatar = StoryManager.ins.GetBattleAvatar(m_data.targetId);
                if (null != myavatar)
                {
                    myavatar.XPChanged(m_data.hp,false,false,false,BatCharacterAttackType.STRENGTH,false);
                }
            }
        }
        /// <summary>
        /// 显示对话，替换主角名称
        /// </summary>
        private void CheckTalk()
        {
            if (m_data.eventType != (int) StoryEventType.EntryText)
            {//不是 开场剧情
                (Singleton.GetObj(typeof (StoryView)) as StoryView).hideEntryText();
                if (!string.IsNullOrEmpty(m_data.speak))
                {//说话
                    StoryBattleAvatar myavatar = StoryManager.ins.GetBattleAvatar(m_data.targetId);
                    if (null != myavatar)
                    {
                        string showview = m_data.speak.Replace(m_role_replace, Human.Instance.getName());
                        myavatar.ShowChatBubble(showview, false, false,2.7f);
                    }
                }
            }
        }
    }
}
