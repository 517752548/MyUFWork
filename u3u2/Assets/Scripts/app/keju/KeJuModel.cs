using UnityEngine;
using app.net;
using app.zone;
using System.Collections.Generic;
using app.db;
using app.reward;

namespace app.keju
{
    public class KeJuModel : AbsModel
    {
        public const string UPDATE_CURRENT_EXAM = "updatecurremtexam";
        public const string KEJU_END = "KEJUEND";
        public const string UPDATE_XIANSHI_EXAM = "UPDATE_XIANSHI_EXAM";
        public const string XIANSHI_DATI_END = "XIANSHI_DATI_END";

        private ExamInfo currentExamInfo;
        private ExamInfo currentXianshiExamInfo;
        public RewardData rewardData { get; private set; }
        public RewardData xianshiRewardData { get; private set; }
        private List<KeJuAnswer> answerlist = new List<KeJuAnswer>();
        private List<KeJuAnswer> xianshiAnswerList = new List<KeJuAnswer>();

        private static KeJuModel _ins;
        public static KeJuModel Ins
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new KeJuModel();
                }
                return _ins;
            }
        }

        public void CanOpen(KeJuType type)
        {
            ExamCGHandler.sendCGExamApply((int)type);
        }
        
        public void GCExamApply(GCExamApply msg)
        {
            ClientLog.Log("keju state is " + msg.getResult());
            if (msg.getResult() == 1)
            {
                if (msg.getExamType() == (int)KeJuType.XIANSHIDATI)
                {
                    if (currentXianshiExamInfo.leftTime > 0)
                    {
                        WndManager.open(GlobalConstDefine.XianshiDatiView_name);
                    }
                }
                else if (msg.getExamType() == (int)KeJuType.PROVINCIAL)
                {
                    WndManager.open(GlobalConstDefine.KeJuView_Name);
                }
            }
            else
            {
                ZoneBubbleManager.ins.BubbleSysMsg("活动未开启!");
            }
        }


        private void RemoveWrongAnswer(int[] removeAnswer)
        {
            if (answerlist == null || removeAnswer == null)
            {
                return;
            }

            for (int i = 0; i < removeAnswer.Length; i++)
            {
                KeJuAnswer keJuAnswer = answerlist.Find(delegate (KeJuAnswer answer)
                 {
                     return answer.id == removeAnswer[i];
                 });
                keJuAnswer.UI.wrongImage.gameObject.SetActive(true);
            }

        }

        public void changeExamInfo(ExamInfo msg)
        {
            if (msg.examType == (int)KeJuType.XIANSHIDATI)
            {
                //  SetNormalExamInfo(msg);
                SetXianshiExamInfo(msg);
            }
            else if (msg.examType == (int)KeJuType.PROVINCIAL)
            {
                SetNormalExamInfo(msg);
            }
        }

        private void SetXianshiExamInfo(ExamInfo msg)
        {
            if (msg.examState == 3)
            {
                dispatchChangeEvent(XIANSHI_DATI_END, null);
            }
            currentXianshiExamInfo = msg;

            ExamTemplate examtemplate = ExamTemplateDB.Instance.getTemplate(msg.examId);
            xianshiAnswerList.Clear();
            for (int i = 0; i < 4; i++)
            {
                KeJuAnswer k = null;
                switch (i)
                {
                    case 0:
                        k = new KeJuAnswer(1, examtemplate.firstAnswer);
                        break;
                    case 1:
                        k = new KeJuAnswer(2, examtemplate.secendAnswer);
                        break;
                    case 2:
                        k = new KeJuAnswer(3, examtemplate.thirdAnswer);
                        break;
                    case 3:
                        k = new KeJuAnswer(4, examtemplate.fourthAnswer);
                        break;
                }
                k.IsRightAnswer = (i + 1 == examtemplate.rightAnswerID);
                xianshiAnswerList.Add(k);
            }

            getRandomXianshiAnswerList(true);
            xianshiRewardData = new RewardData();
            xianshiRewardData.Parse(msg.rewardInfo);
            dispatchChangeEvent(UPDATE_XIANSHI_EXAM , null);

        }

        private void SetNormalExamInfo(ExamInfo msg)
        {
            if (msg.examState == 3)
            {
                dispatchChangeEvent(KEJU_END, null);
            }

            if (currentExamInfo != null && currentExamInfo.examId == msg.examId)
            {
                RemoveWrongAnswer(msg.excludeOptions);
                return;
            }

            currentExamInfo = msg;
            ExamTemplate examtemplate = ExamTemplateDB.Instance.getTemplate(msg.examId);
            answerlist.Clear();
            for (int i = 0; i < 4; i++)
            {
                KeJuAnswer k = null;
                switch (i)
                {
                    case 0:
                        k = new KeJuAnswer(1, examtemplate.firstAnswer);
                        break;
                    case 1:
                        k = new KeJuAnswer(2, examtemplate.secendAnswer);
                        break;
                    case 2:
                        k = new KeJuAnswer(3, examtemplate.thirdAnswer);
                        break;
                    case 3:
                        k = new KeJuAnswer(4, examtemplate.fourthAnswer);
                        break;
                }
                k.IsRightAnswer = (i + 1 == examtemplate.rightAnswerID);
                answerlist.Add(k);
            }
            getRandomAnswerList(true);
            rewardData = new RewardData();
            rewardData.Parse(msg.rewardInfo);
            dispatchChangeEvent(UPDATE_CURRENT_EXAM, null);
        }

        public bool IsRightAnswer(int index)
        {
            if (index < answerlist.Count)
            {
                KeJuAnswer kja = answerlist[index];
                return kja.IsRightAnswer;
            }
            return false;
        }

        public ExamInfo getCurrentExamInfo()
        {
            return currentExamInfo;
        }

        public ExamInfo GetCurrentXianshiExamInfo()
        {
            return currentXianshiExamInfo;
        }

        public List<KeJuAnswer> getRandomAnswerList(bool random = false)
        {
            if (random)
            {
                answerlist.Sort(new CComparer());
            }
            return answerlist;
        }

        public List<KeJuAnswer> getRandomXianshiAnswerList(bool random = false)
        {
            if (random)
            {
                xianshiAnswerList.Sort(new CComparer());
            }
            return xianshiAnswerList;
        }

        public override void Destroy()
        {
            currentExamInfo = null;
            currentXianshiExamInfo = null;
            xianshiRewardData = null;
            rewardData = null;

            if(answerlist!=null)answerlist.Clear();
            answerlist = null;
            if(xianshiAnswerList!=null)xianshiAnswerList.Clear();
            xianshiAnswerList = null;
            _ins = null;
        }
    }

    class CComparer : IComparer<KeJuAnswer>
    {
        public int Compare(KeJuAnswer left, KeJuAnswer right)
        {
            return Random.Range(-100, 100);
        }
    }

    public class KeJuAnswer
    {
        private KejuButtonScript ui;
        public bool IsRightAnswer { get; set; }
        public int id { get; private set; }
        public string answer { get; private set; }

        public KejuButtonScript UI
        {
            get { return ui; }
            set
            {
                ui = value;
                ui.rightImage.gameObject.SetActive(false);
                ui.wrongImage.gameObject.SetActive(false);
            }
        }

        public KeJuAnswer(int id, string answer)
        {
            this.id = id;
            this.answer = answer;
        }

        public void afterClick()
        {
            ui.rightImage.gameObject.SetActive(IsRightAnswer);
            ui.wrongImage.gameObject.SetActive(!IsRightAnswer);
        }

    }
}