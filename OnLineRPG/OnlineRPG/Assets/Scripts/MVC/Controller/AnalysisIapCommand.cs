using System;
using BetaFramework;

public class AnalysisIapCommand : ICommand
{
    public object Data { get; set; }

    public void Initilize()
    {
    }

    public void Execute()
    {
        var productId = (string)Data;
        var data = DataManager.ShopData.GetPendingReceiptProduct(productId);

        if (data != null)
        {
            CommandBinder.DispatchBinding(GameEvent.CustomIapEvent, data);
            CommandBinder.DispatchBinding(GameEvent.FacebookIapEvent, data);
            CommandBinder.DispatchBinding(GameEvent.FabricIapEvent, data);
            CommandBinder.DispatchBinding(GameEvent.FirebaseIapEvent, data);
            CommandBinder.DispatchBinding(GameEvent.AppsflyerIapEvent, data);
            CommandBinder.DispatchBinding(GameEvent.AdjustIapEvent, data);
            CommandBinder.DispatchBinding(GameEvent.FlurryIapEvent, data);
            CommandBinder.DispatchBinding(GameEvent.FTDIapEvent, data);

            DataManager.ShopData.RemovePendingReceiptProduct(productId);
        }
    }

    public void Release()
    {
    }
}