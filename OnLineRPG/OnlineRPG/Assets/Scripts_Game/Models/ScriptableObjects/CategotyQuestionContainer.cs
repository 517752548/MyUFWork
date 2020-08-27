using System;
using System.Collections.Generic;
using UnityEngine;

public class CategotyQuestionContainer : ScriptableObject
{
    public int Index;
    public int CategoryID;
    public List<DailyQuestionEntity> Questions;
}
