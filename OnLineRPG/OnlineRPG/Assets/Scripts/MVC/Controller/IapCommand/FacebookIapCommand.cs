using BetaFramework;
using System;

internal class FacebookIapCommand : ICommand
{
    public object Data { get; set; }

    public void Execute()
    {
        try
        {
            IapProductConfig_Data productData = (IapProductConfig_Data)Data;

            string productDollarPrice = productData.ProductDollarPrice;
            string isoCurrencyCode = "USD";

        }
        catch (Exception ex)
        {
            LoggerHelper.Exception(ex);
        }
    }

    public void Initilize()
    {
    }

    public void Release()
    {
    }
}