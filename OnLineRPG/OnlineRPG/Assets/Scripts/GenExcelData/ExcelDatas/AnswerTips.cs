// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by the FrameWork Editor.
//
//      Changes to this file will be lost if the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------
//  Build Time：2020-02-04 17:38:04.045
// ------------------------------------------------------------------------------

using System.Collections.Generic;

/// <summary>
/// 表
/// </summary>
public class AnswerTips : BaseSheet<AnswerTips_Data>
{
    /// <summary>
    /// 获取对应关卡配置 数组长度2   第一个是打错次数   第二个是发呆时间
    /// </summary>
    /// <param name="level"></param>
    /// <returns></returns>
    public int[] GetTargetLevelConfig(int level)
    {
        
        for (int i = 0; i < dataList.Count; i++)
        {
            if (dataList[i].StartLevel <= level && dataList[i].EndLevel >= level)
            {
                return new[] {dataList[i].ErrorTimes, dataList[i].StayTime};
            }
        }

        return new[] {9999, 99999};
    }
}