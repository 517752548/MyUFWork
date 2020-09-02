using BetaFramework;
using System;

public class FlurryIapCommand : ICommand
{
    public object Data { get; set; }

    public void Execute()
    {
        IapProductConfig_Data productData = (IapProductConfig_Data)Data;

        float fPrice = DataManager.IapData.GetLocalizedPrice(productData.ProductLocalizedPrice);
        string productId = productData.ProductID;
        string transactionID = productData.TransactionID;
        string isoCurrencyCode = productData.IsoCurrencyCode;

//        ReportDataManager.FlurryLogPayment(productId, productId, fPrice, isoCurrencyCode, transactionID);
    }

    public void Initilize()
    {
    }

    public void Release()
    {
    }
}