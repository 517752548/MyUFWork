using System.Collections.Generic;

public class FBFriendItem
{
	public string id;
    public string photoUrl;
    public string name;
	public string world;
	public string subWorld;
	public string level;
	public string score;
	public Dictionary<string,string> sentInvited;

	public FBFriendItem()
	{
		id = "001";
		photoUrl = "default";
		name = "name";
		world = "2";
		subWorld = "3";
		level = "10";
		score = "0";
		sentInvited = new Dictionary<string,string>();
	}

    public FBFriendItem(string _id, string _photoUrl, string _name, string _world, string _subWorld, string _level, string _score, Dictionary<string, string> _sendInvited)
    {
        id = _id;
        photoUrl = _photoUrl;
        name = _name;
        world = _world;
        subWorld = _subWorld;
        level = _level;
        score = _score;
        sentInvited = new Dictionary<string, string>();
    }

    public int GetScore()
    {
        return int.Parse(score);
    }

	public FBFriendItem(FBFriendJsonItem item)
    {
		ConvertToFriendInfo (item);
    }

    public void ConvertToFriendInfo(FBFriendJsonItem item)
    {
//        this.id = item.uid;
//        this.pathUrl = item.path;
//        this.photoUrl = item.photo;
//        this.name = item.text;
    }

}