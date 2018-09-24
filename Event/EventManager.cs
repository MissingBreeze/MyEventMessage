using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Event
{
    /// <summary>
    /// 事件管理类
    /// </summary>
    public class EventManager
    {
        #region 实现单例

        private static EventManager _instance;

        private static readonly object obj = new object();

        public static EventManager Instance
        {
            get
            {
                if(null == _instance)
                {
                    lock (obj)
                    {
                        if (null == _instance)
                        {
                            _instance = new EventManager();
                        }
                    }
                }
                return _instance;
            }
        }

        #endregion

        /// <summary>
        /// 存放事件回调函数的字典
        /// </summary>
        private Dictionary<string, EventCallback> listenerDic = new Dictionary<string, EventCallback>();

        /// <summary>
        /// 添加事件监听
        /// </summary>
        /// <param name="type">事件类型</param>
        /// <param name="listener">事件监听回调</param>
        public void AddEvent(BaseEventType type, EventCallback listener)
        {
            string key = type.eventTypeEnum.ToString();
            if (!listenerDic.ContainsKey(key))
            {
                listenerDic.Add(key, null);
            }
            listenerDic[key] += listener;
        }

        /// <summary>
        /// 移除事件监听
        /// </summary>
        /// <param name="type">事件类型</param>
        /// <param name="listener">事件监听回调</param>
        public void RemoveEvent(BaseEventType type, EventCallback listener)
        {
            string key = type.eventTypeEnum.ToString();
            if (!listenerDic.ContainsKey(key))
            {
                Debug.LogError(key + "：事件不存在，无法移除!");
                return;
            }
            listenerDic[key] -= listener;
            if(listenerDic[key] == null)
            {
                listenerDic.Remove(key);
            }
        }

        /// <summary>
        /// 分发事件
        /// </summary>
        /// <param name="type">事件类型</param>
        /// <param name="listener">事件数据</param>
        public void DispenseEvent(BaseEventType type, BaseEventData eventData)
        {
            string key = type.eventTypeEnum.ToString();
            if (!listenerDic.ContainsKey(key))
            {
                Debug.LogError(key + "：该事件没有被监听!");
                return;
            }
            listenerDic[key](eventData);
        }

        /// <summary>
        /// 分发事件（仅通知，无数据）
        /// </summary>
        /// <param name="type">事件类型</param>
        public void DispenseEvent(BaseEventType type)
        {
            string key = type.GetType().ToString();
            if (!listenerDic.ContainsKey(key))
            {
                Debug.LogError(key + "：该事件没有被监听!");
                return;
            }
            listenerDic[key](new BaseEventData());
        }
    }
}
