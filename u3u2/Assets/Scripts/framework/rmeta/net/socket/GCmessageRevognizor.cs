// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 4.0.30319.1
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------
using System;
using app.net;
public class GCmessageRevognizor
    {
        public GCmessageRevognizor()
        {
        }
        public BaseMessage RecognizeMsg(byte[] bytes)
        {
            if (bytes.Length < BaseMessage.MIN_MSG_LEN)
            {
                return null;
            }
            try
            {
                short _len = RecognizeMsgLen(bytes);
                if (_len > bytes.Length || _len < 0)
                {
                    return null;
                }

                short _type = RecognizeMsgType(bytes);
                return MessageReciver.createMessage(_type);
            } catch (Exception ex)
            {
                ClientLog.LogError("GCMessageRevognizor error" + ex.ToString());
            }
            return null;
        }
        private short RecognizeMsgLen(byte[] bytes)
        {
            if (bytes.Length < BaseMessage.MIN_MSG_LEN)
            {
                return -1;
            }
            byte _high = bytes [0];
            byte _low = bytes [1];
            return (short)(_high << 8 | _low);

        }
        private short RecognizeMsgType(byte[] bytes)
        {
            if (bytes.Length < BaseMessage.MIN_MSG_LEN)
            {
                return -1;
            }
            byte _high = bytes [2];
            byte _low = bytes [3];
            return (short)(_high << 8 | _low);
        }
        
    }