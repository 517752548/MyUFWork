using BetaFramework;
using System;
using UnityEngine;

internal class PreloadAssetCommand : ICommand
{
    public object Data { get; set; }

    public void Initilize()
    {
    }

    public void Execute()
    {
//        CommandChannel commandChannel = CommandChannel.GetInstance();
//        //商店
//        commandChannel.PostCommand(CommonCommandConst.PRELOAD_ASSET_OBJECT, ViewConst.prefab_Shop500_Limited_Time_Item, 1);
//        commandChannel.PostCommand(CommonCommandConst.PRELOAD_ASSET_OBJECT, ViewConst.prefab_Shop400_Limited_Time_Item, 1);
//        commandChannel.PostCommand(CommonCommandConst.PRELOAD_ASSET_OBJECT, ViewConst.prefab_Shop_Super_Started_Item, 5);
//        commandChannel.PostCommand(CommonCommandConst.PRELOAD_ASSET_OBJECT, ViewConst.prefab_ShopNoAdsItem, 1);

    }

    public void Release()
    {
    }
}