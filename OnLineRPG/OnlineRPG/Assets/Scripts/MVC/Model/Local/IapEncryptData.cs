using System.Collections.Generic;

public class IapEncryptData
{
    public List<DayEncryptData> ListDayEncrypt = new List<DayEncryptData>();

    public float GetHard(int pack, int level)
    {
        for (int i = 0; i < ListDayEncrypt.Count; i++)
        {
            if (int.Parse(ListDayEncrypt[i].Pack) == pack
                && int.Parse(ListDayEncrypt[i].Level) == level)
            {
                return float.Parse(ListDayEncrypt[i].Hard);
            }
        }

        return 0.5f;
    }
}

public class DayEncryptData
{
    public string Pack;
    public string Level;
    public string Hard;

    public DayEncryptData()
    {
        Pack = "1";
        Level = "1";
        Hard = "0.5";
    }
}