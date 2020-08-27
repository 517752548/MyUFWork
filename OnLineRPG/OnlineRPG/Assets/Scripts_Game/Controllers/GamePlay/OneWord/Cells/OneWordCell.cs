using BetaFramework;
using UnityEngine;

namespace Scripts_Game.Controllers.GamePlay.OneWord
{
    public class OneWordCell : BaseCell
    {
        
    }

    public class OneWordWord : BaseNormalWord
    {
        private OneWordLevel level;
        public OneWordWord(BaseCellManager cellManager, OneWordLevel level) 
            : base(cellManager, new BaseQuestionEntity()
            {
                ID = int.Parse(level.QuestionId), 
                Question = level.Question, 
                Answer = level.Answer
            })
        {
            this.level = level;
        }
    }
}