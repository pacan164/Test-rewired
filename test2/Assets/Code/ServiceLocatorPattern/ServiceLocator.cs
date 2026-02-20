using System;
using System.Collections.Generic;
using Code.SingletonPattern;
using UnityEngine;

namespace Code.ServiceLocatorPattern
{
    public class ServiceLocator : Singleton<ServiceLocator>
    {
        private Dictionary<Type, object> _instances = new ();

        public void Register<T>(T instance)
        {
            if (_instances.ContainsKey(typeof(T)))
            {
                Debug.Log($"Object with type {typeof(T)} Already registered");
                return;
            }
            
            _instances.Add(typeof(T), instance);
            Debug.Log($"Registered object: {typeof(T)}");
        }

        public void Unregister<T>()
        {
            if (_instances.ContainsKey(typeof(T)))
            {
                _instances.Remove(typeof(T));
                Debug.Log($"Unregistered object: {typeof(T)}");
                return;
            }
            
            Debug.Log($"There was no object with type: {typeof(T)}");
        }

        public T Resolve<T>()
        {
            if (_instances.ContainsKey(typeof(T)))
            {
                return (T) _instances[typeof(T)];
            }
            
            throw new MissingMemberException($"There was no object with type: {typeof(T)}");
        }
    }
}