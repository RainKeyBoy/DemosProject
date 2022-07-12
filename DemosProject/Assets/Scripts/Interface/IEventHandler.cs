public interface IEventHandler
{
    void OnEvent(string type, object data);
}