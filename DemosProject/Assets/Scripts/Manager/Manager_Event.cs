using System.Collections.Generic;

public class Manager_Event
{
    private static Manager_Event instance;

    private Dictionary<string, List<IEventHandler>> dictHandler;

    private Manager_Event()
    {
        dictHandler = new Dictionary<string, List<IEventHandler>>();
    }

    public static Manager_Event GetInstance()
    {
        if (instance == null)
        {
            instance = new Manager_Event();
        }

        return instance;
    }

    /// <summary>
    /// 注册事件监听
    /// </summary>
    /// <param name="type"></param>
    /// <param name="listener"></param>
    public void AddEventListenter(string type, IEventHandler listener)
    {
        if (!dictHandler.ContainsKey(type))
        {
            dictHandler.Add(type, new List<IEventHandler>());
        }

        dictHandler[type].Add(listener);
    }

    /// <summary>
    /// 移除事件监听
    /// </summary>
    /// <param name="listener"></param>
    public void RemoveEventListener(IEventHandler listener)
    {
        foreach (var item in dictHandler.Values)
        {
            if (item.Contains(listener))
            {
                item.Remove(listener);
            }
        }
    }

    /// <summary>
    /// 清空所有监听事件
    /// </summary>
    public void ClearEventListener()
    {
        if (dictHandler != null)
        {
            dictHandler.Clear();
        }
    }

    /// <summary>
    /// 派发事件 
    /// </summary>
    /// <param name="type">事件类型</param>
    /// <param name="data">时间传达的数据</param>
    public void DispachEvent(string type, object data)
    {
        if (!dictHandler.ContainsKey(type))
        {
            return;
        }

        List<IEventHandler> list = dictHandler[type];
        for (int i = 0; i < list.Count; i++)
        {
            list[i].OnEvent(type, data);
        }
    }
}