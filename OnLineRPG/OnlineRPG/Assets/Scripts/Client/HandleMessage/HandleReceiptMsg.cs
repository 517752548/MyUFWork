using System;
using BetaFramework;

public class HandleReceiptMsg : IPacketHandler
{
    public short OpCode { get; set; }

    public void Handle(IIncommingMessage message)
    {
        var data = message.Deserialize<RepReceiptPacket>();

        if (data.code == (int)RepCodes.SUCCESSED)
        {
            switch ((ReceiptCodes)data.purchase_status)
            {
                case ReceiptCodes.ERROR_UNKNOWN:
                    break;

                case ReceiptCodes.Fail:
                    break;

                case ReceiptCodes.SUCCESSED:

                    if (data.purchase_env == PurchaseEnv.OnLine)
                    {
                        //沙盒测试环境不再进行数据上传
                        CommandBinder.DispatchBinding(GameEvent.AnalysisIapEvent, data.productId);
                    } else {
						if (GameSetting.IsAllowDebugSandBoxDispatchEvent) {
							//沙盒测试环境在测试环境下需要数据上传
							CommandBinder.DispatchBinding(GameEvent.AnalysisIapEvent, data.productId);
						}
					}

					break;

                case ReceiptCodes.ERROR_CODE1:
                    break;

                case ReceiptCodes.ERROR_CODE2:
                    break;

                case ReceiptCodes.ERROR_CODE3:
                    break;

                case ReceiptCodes.ERROR_CODE4:
                    break;

                case ReceiptCodes.ERROR_CODE5:
                    break;

                case ReceiptCodes.ERROR_CODE6:
                    break;

                case ReceiptCodes.ERROR_CODE7:
                    break;

                case ReceiptCodes.ERROR_CODE8:
                    break;

                default:
                    break;
            }
        }
        else
        {
            LoggerHelper.ErrorFormat("OpCode {0} response error, error code {1}", OpCode, data.code);
        }
    }
}