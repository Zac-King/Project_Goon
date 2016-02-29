using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class EventSystem
{
    private static Dictionary<string, Delegate> _subscribers;
    
    public static void Notify(MessageType t, string m)                                          // [Function] // Notify all subscribers of the message
    {
        string message = FormatMessage(t, m);       // Make formated Message
        Delegate d;                                 // Make a Delegate, to store <Delegate> value

        if (_subscribers.TryGetValue(message, out d))// If Key Exist output the value to d
        {
            Callback c = d as Callback; // Cast d as Callback
            if (c != null)
            {
                c();    // Use the Delegate
            }
        }
    }
    public static void Notify<T>(MessageType t, string m, T arg)                                // [Function] // Notify all subscribers with Templated 1 Argument of the message
    {
        string message = FormatMessage(t, m);           // Make formated Message
        Delegate d;                                     // Make a Delegate, to store <Delegate> value

        if (_subscribers.TryGetValue(message, out d))   // If Key Exist output the value to d
        {
            Callback<T> c = d as Callback<T>;   // Cast d as Callback<T>
            if (c != null)
            {
                c(arg);    // Use the Delegate
            }
        }
    }
    public static void Notify<T, U>(MessageType t, string m, T arg1, U arg2)                    // [Function] // Notify all subscribers with Templated 2 Arguments of the message
    {
        string message = FormatMessage(t, m);           // Make formated Message
        Delegate d;                                     // Make a Delegate, to store <Delegate> value

        if (_subscribers.TryGetValue(message, out d))   // If Key Exist output the value to d
        {
            Callback<T, U> c = d as Callback<T, U>;   // Cast d as Callback<T, U>
            if (c != null)
            {
                c(arg1, arg2);    // Use the Delegate
            }
        }
    }
    public static void Notify<T, U, V>(MessageType t, string m, T arg1, U arg2, V arg3)         // [Function] // Notify all subscribers with Templated 3 Arguments of the message
    {
        string message = FormatMessage(t, m);           // Make formated Message
        Delegate d;                                     // Make a Delegate, to store <Delegate> value

        if (_subscribers.TryGetValue(message, out d))   // If Key Exist output the value to d
        {
            Callback<T, U, V> c = d as Callback<T, U, V>;   // Cast d as Callback<T, U, V>
            if (c != null)
            {
                c(arg1, arg2, arg3);    // Use the Delegate
            }
        }
    }

    public static void AddSubscriber(MessageType t, string m, Callback c)                       // [Function] // Add Subscriber to the Dictionary
    {
        string message = FormatMessage(t,m);

        if(!_subscribers.ContainsKey(message)) // If the Key doesn't exist; add the key and value pair to the dictionary
            _subscribers.Add(message, c);

        else                        // If Key exists: add the Delegate to the Keys Value
            _subscribers[message] = (Callback)_subscribers[message] + c;
    }
    public static void AddSubscriber<T>(MessageType t, string m, Callback<T> c)                 // [Function] // Add Subscriber with 1 Templated Delegate to the Dictionary
    {
        string message = FormatMessage(t, m);

        if (!_subscribers.ContainsKey(message)) // If the Key doesn't exist; add the key and value pair to the dictionary
            _subscribers.Add(message, c);

        else                        // If Key exists: add the Delegate to the Keys Value
            _subscribers[message] = (Callback<T>)_subscribers[message] + c;
    }
    public static void AddSubscriber<T, U>(MessageType t, string m, Callback<T, U> c)           // [Function] // Add Subscriber with 2 Templated Delegates to the Dictionary
    {
        string message = FormatMessage(t, m);

        if (!_subscribers.ContainsKey(message)) // If the Key doesn't exist; add the key and value pair to the dictionary
            _subscribers.Add(message, c);

        else                        // If Key exists: add the Delegate to the Keys Value
            _subscribers[message] = (Callback<T, U>)_subscribers[message] + c;
    }
    public static void AddSubscriber<T, U, V>(MessageType t, string m, Callback<T, U, V> c)     // [Function] // Add Subscriber with 3 Templated Delegates to the Dictionary
    {
        string message = FormatMessage(t, m);

        if (!_subscribers.ContainsKey(message)) // If the Key doesn't exist; add the key and value pair to the dictionary
            _subscribers.Add(message, c);

        else                        // If Key exists: add the Delegate to the Keys Value
            _subscribers[message] = (Callback<T, U, V>)_subscribers[message] + c;
    }

    public static void RemoveSubscriber(MessageType t, string m, Callback c)                    // [Function] // Remove Delegate from Dictionary
    {
        string message = FormatMessage(t,m);

        if (!_subscribers.ContainsKey(message))     // If Nothing at that Key; do nothing
        {
            return;
        }

        if (_subscribers[message] != null)
        {
            _subscribers[message] = (Callback)_subscribers[message] - c;        // Remove delegate from Key
        }

        if(_subscribers[message] == null)       // If there is no value for the Key after the remove
        {
            _subscribers.Remove(message);       // Delete the whole thing
        }
    }
    public static void RemoveSubscriber<T>(MessageType t, string m, Callback<T> c)              // [Function] // Remove Delegate from Dictionary
    {
        string message = FormatMessage(t, m);

        if (!_subscribers.ContainsKey(message))     // If Nothing at that Key; do nothing
        {
            return;
        }

        if (_subscribers[message] != null)
        {
            _subscribers[message] = (Callback<T>)_subscribers[message] - c;        // Remove delegate from Key
        }

        if (_subscribers[message] == null)      // If there is no value for the Key after the remove
        {
            _subscribers.Remove(message);       // Delete the whole thing
        }
    }
    public static void RemoveSubscriber<T, U>(MessageType t, string m, Callback<T, U> c)        // [Function] // Remove Delegate from Dictionary
    {
        string message = FormatMessage(t, m);

        if (!_subscribers.ContainsKey(message))     // If Nothing at that Key; do nothing
        {
            return;
        }

        if (_subscribers[message] != null)
        {
            _subscribers[message] = (Callback<T, U>)_subscribers[message] - c;        // Remove delegate from Key
        }

        if (_subscribers[message] == null)       // If there is no value for the Key after the remove
        {
            _subscribers.Remove(message);        // Delete the whole thing
        }
    }
    public static void RemoveSubscriber<T, U, V>(MessageType t, string m, Callback<T, U, V> c)  // [Function] // Remove Delegate from Dictionary
    {
        string message = FormatMessage(t, m);

        if (!_subscribers.ContainsKey(message))     // If Nothing at that Key; do nothing
        {
            return;
        }

        if (_subscribers[message] != null)
        {
            _subscribers[message] = (Callback<T, U, V>)_subscribers[message] - c;        // Remove delegate from Key
        }

        if (_subscribers[message] == null)      // If there is no value for the Key after the remove
        {
            _subscribers.Remove(message);       // Delete the whole thing
        }
    }

    private static string FormatMessage(MessageType type, string message)                       // [Function] // Ensures Messages are proper Format
    {
        return  type.ToString() + ":" + message;
    }
    
}

// Implementation ////////////////
/*
    // Example: //

    //   
    AddSubscriber(Combat, "Hit", myDelegate);
    // Templated AddSubscriber 
    AddSubscriber(Combat, "Hit", myDelegate);       // myDelegate equals a delegete with templated parameters

    // 
    Notify(Combat, "Hit");
    // Templated Notify
    Notify(combat, "Hit", 15);                      // "15" being arg1 in example, is the templated parameter that is passed with the delegate

    // 
    RemoveSubscriber(Combat, "Hit", myDelegate);
    // Templated RemoveSubscriber
    RemoveSubscriber(Combat, "Hit", myDelegate);    // myDelegate equals a delegete with templated parameters

*/
//////////////////////////////////