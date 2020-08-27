namespace Data.Request
{
    public class BaseRequestParam
    {
        public int mId;
        public int version;
        public BaseRequestParam()
        {

        }
        public BaseRequestParam(ServerCode mid, int version = 0)
        {
            mId = (int)mid;
            this.version = version;
        }
    }
}