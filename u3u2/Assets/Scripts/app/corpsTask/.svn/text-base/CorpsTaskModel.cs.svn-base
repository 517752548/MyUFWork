using app.net;

public class CorpsTaskModel : AbsModel
{
    public const string CORPSTASKOPENPANEL = "CORPSTASKOPENPANEL";
    public const string COPRSTASKDONE = "COPRSTASKDONE";
    public const string CORPSTASJUPDATE = "CORPSTASJUPDATE";

    public bool haveFinishCorpsTask = false;

    private GCOpenCorpstaskPanel mOpenCorpsTaskPanel;
    private GCCorpstaskDone mCorpsTaskDone;
    private GCCorpstaskUpdate mCorpsTaskUpdate;

    private static CorpsTaskModel mInstance;

    public GCOpenCorpstaskPanel openCorpsTaskPanel
    {
        get
        {
            return mOpenCorpsTaskPanel;
        }
        set
        {
            mOpenCorpsTaskPanel = value;
            if (value != null)
            {
                haveFinishCorpsTask = value.getFinishTimes() >= value.getTotalTimes();
            }
            dispatchChangeEvent(CORPSTASKOPENPANEL,null);
        }
    }

    
    public static CorpsTaskModel instance
    {
        get
        {
            if (mInstance == null)
            {
                mInstance = new CorpsTaskModel();
            }
            return mInstance;
        }
    }
    
    public GCCorpstaskDone corpsTaskDone
    {
        set
        {
            mCorpsTaskDone = value;
            haveFinishCorpsTask = true;
            dispatchChangeEvent(COPRSTASKDONE,null);
        }
        get
        {
            return mCorpsTaskDone;
        }
    }
    
    public GCCorpstaskUpdate corpsTaskUpdate
    {
        set
        {
            mCorpsTaskUpdate = value;
            QuestInfoData info = mCorpsTaskUpdate.getQuestInfo();
            QuestModel.Ins.updateOneQuest(info);
           
            dispatchChangeEvent(CORPSTASJUPDATE,null);
        }
        get
        {
            return mCorpsTaskUpdate;
        }
    }
    
    public override void Destroy()
    {
        haveFinishCorpsTask = false;

        mInstance = null;
        mOpenCorpsTaskPanel = null;
        mCorpsTaskDone = null;
        mCorpsTaskUpdate = null;
    }
}
