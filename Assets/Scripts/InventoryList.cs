using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Dynamic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

// Das keyword "where" gefolgt vom Typenparameter T beschreibt, welche Datentypen als Parameter zulässig sind 
// (in diesem Fall nur Klassen, genauer gesagt alle Referenztypen, also auch interfaces, delegates und arrays)
public class InventoryList<T> where T: class
{
    private T _item;
    public T item {
        get { return _item; } 
        set { _item = value; }
    }

    public InventoryList()
    {
        UnityEngine.Debug.Log("Generic List initialized...");
    }

    public void SetItem(T newItem)
    {
        _item = newItem;
        UnityEngine.Debug.Log("New item added...");
    }
}
