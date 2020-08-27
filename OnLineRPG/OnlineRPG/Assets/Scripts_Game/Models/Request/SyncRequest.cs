﻿using UnityEngine;

namespace Data.Request
{
    public class SyncRequest : BaseRequestParam
    {
        public SyncData data;

        public SyncRequest(ServerCode mid, SyncData syncData) : base(mid)
        {
            this.data = syncData;
        }
    }
    
    public class CommDataRequest<T> : BaseRequestParam
    {
        public T data;

        public CommDataRequest(ServerCode mid, T syncData) : base(mid)
        {
            this.data = syncData;
        }
    }

    public class SyncResponse : BaseResponseData<SyncData>
    {
        
    }
}