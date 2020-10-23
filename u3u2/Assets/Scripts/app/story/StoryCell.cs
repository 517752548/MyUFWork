using UnityEngine;
using app.human;
using app.zone;
using app.npc;
using app.db;

namespace app.story
{
    public class StoryCell
    {
        public VideoTemplate m_data;
        public float m_speed;
        /// <summary>
        /// 角色名称替换字符串
        /// </summary>
        private string m_role_replace = "{rolename}";

        public StoryCell(VideoTemplate data)
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
            if ((int)StoryStatusType.Appear == m_data.eventType)
            {
                ///创建///
                CreateModel();
            }
            else if ((int)StoryStatusType.Update == m_data.eventType)
            {
                ///更新///
                CheckUpdateModel();
            }
            else
            {
                ///消失///
                StoryManager.ins.DestroyOneModel(m_data.targetId);
                return;
            }

            CheckDirection();
            CheckMove();
            CheckAnim();
            CheckText();
        }

        /// <summary>
        /// 创建角色
        /// </summary>
        public void CreateModel()
        {

            switch (m_data.targetType)
            {
                case (int)StoryObjectType.Player:
                    ///是主角///
                    StoryAvatar avatar1 = new StoryAvatar();
                    long uuid = ZoneModel.ins.playerUUID;
                    string currentModelName = Human.Instance.get3DModel();
                    Vector3 position = Vector3.zero;
                    if (1 == m_data.pixelPoint)
                    {
                        position = ZoneUtil.ConvertLeftTopPixelPos2UnityPos(new Vector2(m_data.xPoint, m_data.yPoint));
                    }
                    else
                    {
                        position = ZoneUtil.ConvertMapPathTilePos2UnityPos((int)m_data.xPoint, (int)m_data.yPoint);

                    }
                    Vector3 angle = new Vector3(0, NPCDefine.GetNpcDirectionById(m_data.direction), 0);
                    avatar1.Init(uuid, currentModelName, Human.Instance.getName(), position, angle);

                    StoryManager.ins.AddAvatar(m_data.targetId, avatar1);
                    break;
                case (int)StoryObjectType.OhterModel:
                    StoryAvatar avatar2 = new StoryAvatar();
                    Vector3 position2 = Vector3.zero;
                    if (1 == m_data.pixelPoint)
                    {
                        position2 = ZoneUtil.ConvertLeftTopPixelPos2UnityPos(new Vector2(m_data.xPoint, m_data.yPoint));
                    }
                    else
                    {
                        position2 = ZoneUtil.ConvertMapPathTilePos2UnityPos((int)m_data.xPoint, (int)m_data.yPoint);

                    }

                    Vector3 angle2 = new Vector3(0, NPCDefine.GetNpcDirectionById(m_data.direction), 0);
                    avatar2.Init(0, m_data.model3DId, m_data.playerName, position2, angle2, true, false, false);

                    StoryManager.ins.AddAvatar(m_data.targetId, avatar2);
                    break;
                case (int)StoryObjectType.Effect:
                    StoryAvatar avatar3 = new StoryAvatar();
                    Vector3 position3 = Vector3.zero;
                    if (1 == m_data.pixelPoint)
                    {
                        position3 = ZoneUtil.ConvertLeftTopPixelPos2UnityPos(new Vector2(m_data.xPoint, m_data.yPoint));
                    }
                    else
                    {
                        position3 = ZoneUtil.ConvertMapPathTilePos2UnityPos((int)m_data.xPoint, (int)m_data.yPoint);

                    }
                    avatar3.PlayEffect(m_data.model3DId, m_data.playerName, position3);

                    StoryManager.ins.AddAvatar(m_data.targetId, avatar3);
                    break;
                case (int)StoryObjectType.MapCenter:
                    Vector3 position4 = Vector3.zero;
                    if (1 == m_data.pixelPoint)
                    {
                        position4 = ZoneUtil.ConvertLeftTopPixelPos2UnityPos(new Vector2(m_data.xPoint, m_data.yPoint));
                    }
                    else
                    {
                        position4 = ZoneUtil.ConvertMapPathTilePos2UnityPos((int)m_data.xPoint, (int)m_data.yPoint);

                    }
                    ZoneCameraManager.ins.SetCameraPos(position4);
                    ZoneModel.ins.zoneMap.Update(position4, false);
                    break;
                case (int)StoryObjectType.Vibrate:
                    float shaketime = m_data.xPoint * 1f / 1000f;
                    StoryManager.ins.ShakeCamera(shaketime);
                    break;
                case (int)StoryObjectType.Music:
                    AudioManager.Ins.PlayAudio(m_data.model3DId, (AudioEnumType)m_data.xPoint);
                    break;
            }
        }

        /// <summary>
        /// 是否更新模型
        /// </summary>
        public void CheckUpdateModel()
        {
            if (!string.IsNullOrEmpty(m_data.model3DId))
            {
                StoryManager.ins.DestroyOneModel(m_data.targetId);
                CreateModel();
            }
        }

        /// <summary>
        /// 检查是否需要移动
        /// </summary>
        public void CheckMove()
        {
            ///获取下一时间点位置///
            VideoTemplate nextdata = StoryManager.ins.GetNextData(m_data);
            if (null != nextdata)
            {
                if (nextdata.xPoint == 0 && nextdata.yPoint == 0)
                {
                    return;
                }
                if (m_data.xPoint != nextdata.xPoint || m_data.yPoint != nextdata.yPoint)
                {
                    StoryAvatar myavatar = StoryManager.ins.GetAvatar(m_data.targetId);
                    if (null != myavatar)
                    {
                        Vector3 position = Vector3.zero;
                        if (1 == nextdata.pixelPoint)
                        {
                            position = ZoneUtil.ConvertLeftTopPixelPos2UnityPos(new Vector2(nextdata.xPoint, nextdata.yPoint));
                        }
                        else
                        {
                            position = ZoneUtil.ConvertMapPathTilePos2UnityPos((int)nextdata.xPoint, (int)nextdata.yPoint);
                        }
                        TweenUtil.MoveTo(myavatar.DisplayModelContainer.transform, position, (nextdata.timePoint * 1f - m_data.timePoint * 1f) / 1000f / m_speed);
                    }
                }
            }
        }

        /// <summary>
        /// 是否播放动作
        /// </summary>
        public void CheckAnim()
        {
            if (!string.IsNullOrEmpty(m_data.action))
            {
                StoryAvatar myavatar = StoryManager.ins.GetAvatar(m_data.targetId);
                if (null != myavatar)
                {
                    myavatar.PlayAnimation(m_data.action);
                }
            }
        }

        /// <summary>
        /// 检查是否修改朝向
        /// </summary>
        public void CheckDirection()
        {
            if (m_data.direction > 0 && m_data.direction < 9)
            {
                ///设置人物朝向///
                StoryAvatar myavatar = StoryManager.ins.GetAvatar(m_data.targetId);
                if (null != myavatar)
                {
                    Vector3 localEulerAngles = new Vector3(0, NPCDefine.GetNpcDirectionById(m_data.direction), 0);
                    myavatar.localEulerAngles = localEulerAngles;
                }
            }
        }

        /// <summary>
        /// 显示对话，替换主角名称
        /// </summary>
        public void CheckText()
        {
            if (!string.IsNullOrEmpty(m_data.talk))
            {
                StoryAvatar myavatar = StoryManager.ins.GetAvatar(m_data.targetId);
                if (null != myavatar)
                {
                    string showview = m_data.talk.Replace(m_role_replace, Human.Instance.getName());
                    myavatar.ShowChatBubble(showview, false, false);
                }
            }
        }
    }
}
