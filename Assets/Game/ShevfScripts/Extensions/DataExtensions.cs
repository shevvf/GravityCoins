using System;
using System.Collections.Generic;

using UnityEngine;

public static class DataExtensions
{
    public static string GetData<TData>(TData data)
    {
        return JsonUtility.ToJson(data);
    }

    public static TData SetData<TData>(string data)
    {
        Debug.Log(data);
        return JsonUtility.FromJson<TData>(data);
    }

    public static List<T> SetDataList<T>(string json)
    {
        string wrappedJson = $"{{\"items\":{json}}}";
        WrapperList<T> wrapper = JsonUtility.FromJson<WrapperList<T>>(wrappedJson);
        return wrapper.items;
    }

    [Serializable]
    public class WrapperList<T>
    {
        public List<T> items;
    }

    [Serializable]
    public class Wrapper<T>
    {
        public T Value;
    }
}
