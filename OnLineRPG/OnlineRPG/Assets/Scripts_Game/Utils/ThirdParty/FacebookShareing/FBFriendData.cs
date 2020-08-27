using System.Collections.Generic;

public class FBFriendData
{
    public string id;
    public List<FBFriendItem> listFriend = new List<FBFriendItem>();

    public FBFriendData()
    {

    }

    public FBFriendData(FBFriendJson data)
    {
        this.id = data.lid;

        for (int i =0; i < data.payload.Count; i++)
        {
            FBFriendItem friendItem = new FBFriendItem(data.payload[i]);
            this.listFriend.Add(friendItem);
        }
    }
}