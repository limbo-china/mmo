using Message;

namespace Net { 
    public interface IPostResponser
    {
        void PostProcess(NetMessageResponse message);
    }
}
