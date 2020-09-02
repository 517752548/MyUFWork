using UnityEngine;

public class ShopRemoveAdItem : ShopBaseItem
{
    public override void Initialize()
    {
        base.Initialize();
    }

    protected override void InitilizeSource()
    {
        IapItem.PayType = PayType.RemoveadsType;
    }
}