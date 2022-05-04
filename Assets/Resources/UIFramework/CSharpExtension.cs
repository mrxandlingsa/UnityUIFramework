using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public static class CSharpExtension
{
    public static TValue GetValue<TKey, TValue>(this Dictionary<TKey, TValue> dict, TKey key)
    {
        TValue value = default(TValue);
        dict.TryGetValue(key, out value);
        return value;
    }



}
