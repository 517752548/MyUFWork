namespace Data.Request
{
    public class BaseResponse
    {
        public int mId;
        public int code;
    }
    public class BaseResponseData<T> : BaseResponse
    {
        public T data;
    }
}