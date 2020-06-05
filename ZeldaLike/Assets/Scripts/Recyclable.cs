using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


abstract public class Recyclable<T>
{
    private static List<T> objects  = new List<T>();

    public void Push(T @object)
    {
        objects.Add(@object);
    }

    public T Pop()
    {
        T obj = objects[objects.Count - 1];
        objects.RemoveAt(objects.Count - 1);

        return obj;
    }
}


