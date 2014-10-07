﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Senparc.Weixin.Entities;

namespace Senparc.Weixin.MessageHandlers
{
    public interface IMessageHandler<TRest, TResp> : IMessageHandlerDocument
        where TRest : IRequestMessageBase
        where TResp : IResponseMessageBase
    {
        /// <summary>
        /// 发送者用户名（OpenId）
        /// </summary>
        string WeixinOpenId { get; }

        /// <summary>
        /// 取消执行Execute()方法。一般在OnExecuting()中用于临时阻止执行Execute()。
        /// 默认为False。
        /// 如果在执行OnExecuting()执行前设为True，则所有OnExecuting()、Execute()、OnExecuted()代码都不会被执行。
        /// 如果在执行OnExecuting()执行过程中设为True，则后续Execute()及OnExecuted()代码不会被执行。
        /// 建议在设为True的时候，给ResponseMessage赋值，以返回友好信息。
        /// </summary>
        bool CancelExcute { get; set; }

        /// <summary>
        /// 请求实体
        /// </summary>
        TRest RequestMessage { get; set; }
        /// <summary>
        /// 响应实体
        /// 只有当执行Execute()方法后才可能有值
        /// </summary>
        TResp ResponseMessage { get; set; }

        /// <summary>
        /// 是否使用了MessageAgent代理
        /// </summary>
        bool UsedMessageAgent { get; set; }

        /// <summary>
        /// 执行微信请求
        /// </summary>
        void Execute();
    }
}
