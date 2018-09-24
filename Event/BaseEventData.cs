using System;
using UnityEngine;

namespace Event
{
    /// <summary>
    /// 基础事件数据类
    /// </summary>
    public class BaseEventData
    {
        /// <summary>
        /// 发送消息的物体（可为空）
        /// </summary>
        public GameObject sender;

        /// <summary>
        /// 系统事件数据基类
        /// </summary>
        public EventArgs eventArgs;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="sender">发送消息的物体</param>
        /// <param name="eventArgs">事件数据</param>
        public BaseEventData(GameObject sender, EventArgs eventArgs)
        {
            this.sender = sender;
            this.eventArgs = eventArgs;
        }

        /// <summary>
        /// 无参构造函数（发送通知消息，不包含数据）
        /// </summary>
        public BaseEventData()
        {
        }

        /// <summary>
        /// 构造函数（不包含通知的物体）
        /// </summary>
        /// <param name="eventArgs"></param>
        public BaseEventData(EventArgs eventArgs)
        {
            this.eventArgs = eventArgs;
        }
    }
}
