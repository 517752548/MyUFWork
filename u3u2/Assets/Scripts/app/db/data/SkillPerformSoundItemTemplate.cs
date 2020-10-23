using System;
using Mono.Data.Sqlite;

namespace app.db
{
    public class SkillPerformSoundItemTemplate
    {
        /// <summary>
        /// 音效id
        /// </summary>
        public String soundId;

        /// <summary>
        /// 音效开始播放的时间
        /// </summary>
        public float soundStartTime;

        /// <summary>
        /// 音效是否循环播放
        /// </summary>
        public int isLoop;

        public SkillPerformSoundItemTemplate(SqliteDataReader reader, int startIndex)
        {
            this.soundId = reader.GetString(startIndex++);
            this.soundStartTime = reader.GetFloat(startIndex++);
            this.isLoop = reader.GetInt32(startIndex++);
        }
    }
}
