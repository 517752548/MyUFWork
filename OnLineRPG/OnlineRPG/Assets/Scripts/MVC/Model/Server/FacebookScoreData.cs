using Newtonsoft.Json;

public class FacebookScoreData
{
    [JsonProperty("InviteFriendReward")]
    public string InviteFriendReward { get; set; }

    [JsonProperty("InviteFriendCount")]
    public string InviteFriendCount { get; set; }

    //	[JsonProperty("InboxGift")]
    //    public string InboxGift { get; set; }
    //
    //	[JsonProperty("InviteGift")]
    //	public string InviteGift{ get; set;}

    public FacebookScoreData()
    {
        this.InviteFriendCount = "5,10,20,40,80";
        this.InviteFriendReward = "25,50,80,100,250";
        //		this.InboxGift = "10";
        //		this.InviteGift = "25";
    }
}