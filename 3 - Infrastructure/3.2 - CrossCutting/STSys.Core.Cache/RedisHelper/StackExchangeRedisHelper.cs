﻿using Common.Utility;
using StackExchange.Redis;
using STSys.Core.Domain.Core.Common;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;

namespace STSys.Core.Cache.RedisHelper
{
    
    public class StackExchangeRedisHelper
    {
        private static object _locker = new Object();
        private static StackExchangeRedisHelper _instance = null;
        private static Redlock redlock = null;
        public static StackExchangeRedisHelper Instance()
        {
            if (_instance == null)
            {
                lock (_locker)
                {
                    if (_instance == null || _instance._conn.IsConnected == false)
                    {
                        _instance = new StackExchangeRedisHelper();
                    }
                }
            }
            return _instance;
        }

        private ConnectionMultiplexer _conn;

        private string connStr = string.Format("{0}:{1},allowAdmin=true,password={2},defaultdatabase={3}",
      ConfigManagerConf.GetValue("redis:HostName"),
      ConfigManagerConf.GetValue("redis:Port"),
      ConfigManagerConf.GetValue("redis:Password"),
      ConfigManagerConf.GetValue("redis:Defaultdatabase")
      );
        /// <summary>
        /// 使用一个静态属性来返回已连接的实例，如下列中所示。这样，一旦 ConnectionMultiplexer 断开连接，便可以初始化新的连接实例。
        /// </summary>
        public StackExchangeRedisHelper()
        {
            //注册如下事件
            //_instance.ConnectionFailed += MuxerConnectionFailed;
            //_instance.ConnectionRestored += MuxerConnectionRestored;
            //_instance.ErrorMessage += MuxerErrorMessage;
            //_instance.ConfigurationChanged += MuxerConfigurationChanged;
            //_instance.HashSlotMoved += MuxerHashSlotMoved;
            //_instance.InternalError += MuxerInternalError;
            _conn = ConnectionMultiplexer.Connect(connStr);
            redlock = new Redlock(_conn);
        }


        public IDatabase GetDatabase()
        {
            try
            {
                return _conn.GetDatabase();
            }
            catch
            {
                _conn = ConnectionMultiplexer.Connect(connStr);
                return _conn.GetDatabase();
            }
        }

        public bool SetExpire(string key, int seconds)
        {
            return GetDatabase().KeyExpire(key, DateTime.Now.AddSeconds(seconds));
        }

        private string MergeKey(string key)
        {
            return key;
        }





        public T Get<T>(string key)
        {
            key = MergeKey(key);
            return GetDatabase().StringGet(key).ToString().ToModel<T>();
        }

        public string Get(string key)
        {
            key = MergeKey(key);
            return GetDatabase().StringGet(key);
        }

        public bool Set(string key, string value)
        {
            key = MergeKey(key);
            return GetDatabase().StringSet(key, value);
        }


        public string Get_Hash(string redisKey, string hashField)
        {
            redisKey = MergeKey(redisKey);
            string hashvalue = GetDatabase().HashGet(redisKey, hashField);
            return hashvalue;
        }

        public T Get_Hash<T>(string redisKey, string hashField)
        {
            redisKey = MergeKey(redisKey);
            string hashvalue = GetDatabase().HashGet(redisKey, hashField);
            return hashvalue.ToModel<T>();
        }


        /// <summary>
        /// 设置缓存
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public bool Set_Hash(string redisKey, string hashField, string value)
        {
            redisKey = MergeKey(redisKey);
            //return GetDatabase().HashSet(redisKey, hashField, Serialize(value));
            return GetDatabase().HashSet(redisKey, hashField, value);
        }







        /// <summary>
        /// 判断在缓存中是否存在该key的缓存数据
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool Exists(string key)
        {
            key = MergeKey(key);
            return GetDatabase().KeyExists(key);  //可直接调用
        }

        /// <summary>
        /// 移除指定key的缓存
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool Remove(string key)
        {
            key = MergeKey(key);
            return GetDatabase().KeyDelete(key);
        }













        /// <summary>
        /// 异步设置
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public async Task SetAsync(string key, string value)
        {
            key = MergeKey(key);
            await GetDatabase().StringSetAsync(key, value);
        }

        /// <summary>
        /// 根据key获取缓存对象
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public async Task<object> GetAsync(string key)
        {
            key = MergeKey(key);
            object value = await GetDatabase().StringGetAsync(key);
            return value;
        }

        /// <summary>
        /// 实现递增
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public long Increment(string key)
        {
            key = MergeKey(key);
            //三种命令模式
            //Sync,同步模式会直接阻塞调用者，但是显然不会阻塞其他线程。
            //Async,异步模式直接走的是Task模型。
            //Fire - and - Forget,就是发送命令，然后完全不关心最终什么时候完成命令操作。
            //即发即弃：通过配置 CommandFlags 来实现即发即弃功能，在该实例中该方法会立即返回，如果是string则返回null 如果是int则返回0.这个操作将会继续在后台运行，一个典型的用法页面计数器的实现：
            return GetDatabase().StringIncrement(key, flags: CommandFlags.FireAndForget);
        }

        /// <summary>
        /// 实现递减
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public long Decrement(string key, string value)
        {
            key = MergeKey(key);
            return GetDatabase().HashDecrement(key, value, flags: CommandFlags.FireAndForget);
        }




        /// <summary>
        /// 配置更改时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MuxerConfigurationChanged(object sender, EndPointEventArgs e)
        {
            //LogHelper.WriteInfoLog("Configuration changed: " + e.EndPoint);
        }
        /// <summary>
        /// 发生错误时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MuxerErrorMessage(object sender, RedisErrorEventArgs e)
        {
            //LogHelper.WriteInfoLog("ErrorMessage: " + e.Message);
        }
        /// <summary>
        /// 重新建立连接之前的错误
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MuxerConnectionRestored(object sender, ConnectionFailedEventArgs e)
        {
            //LogHelper.WriteInfoLog("ConnectionRestored: " + e.EndPoint);
        }
        /// <summary>
        /// 连接失败 ， 如果重新连接成功你将不会收到这个通知
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MuxerConnectionFailed(object sender, ConnectionFailedEventArgs e)
        {
            //LogHelper.WriteInfoLog("重新连接：Endpoint failed: " + e.EndPoint + ", " + e.FailureType + (e.Exception == null ? "" : (", " + e.Exception.Message)));
        }
        /// <summary>
        /// 更改集群
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MuxerHashSlotMoved(object sender, HashSlotMovedEventArgs e)
        {
            //LogHelper.WriteInfoLog("HashSlotMoved:NewEndPoint" + e.NewEndPoint + ", OldEndPoint" + e.OldEndPoint);
        }
        /// <summary>
        /// redis类库错误
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MuxerInternalError(object sender, InternalErrorEventArgs e)
        {
            //LogHelper.WriteInfoLog("InternalError:Message" + e.Exception.Message);
        }

        //场景不一样，选择的模式便会不一样，大家可以按照自己系统架构情况合理选择长连接还是Lazy。
        //建立连接后，通过调用ConnectionMultiplexer.GetDatabase 方法返回对 Redis Cache 数据库的引用。从 GetDatabase 方法返回的对象是一个轻量级直通对象，不需要进行存储。

        /// <summary>
        /// 使用的是Lazy，在真正需要连接时创建连接。
        /// 延迟加载技术
        /// 微软azure中的配置 连接模板
        /// </summary>
        //private static Lazy<ConnectionMultiplexer> lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
        //{
        //    //var options = ConfigurationOptions.Parse(constr);
        //    ////options.ClientName = GetAppName(); // only known at runtime
        //    //options.AllowAdmin = true;
        //    //return ConnectionMultiplexer.Connect(options);
        //    ConnectionMultiplexer muxer = ConnectionMultiplexer.Connect(Coonstr);
        //    muxer.ConnectionFailed += MuxerConnectionFailed;
        //    muxer.ConnectionRestored += MuxerConnectionRestored;
        //    muxer.ErrorMessage += MuxerErrorMessage;
        //    muxer.ConfigurationChanged += MuxerConfigurationChanged;
        //    muxer.HashSlotMoved += MuxerHashSlotMoved;
        //    muxer.InternalError += MuxerInternalError;
        //    return muxer;
        //});


        //#region  当作消息代理中间件使用 一般使用更专业的消息队列来处理这种业务场景
        ///// <summary>
        ///// 当作消息代理中间件使用
        ///// 消息组建中,重要的概念便是生产者,消费者,消息中间件。
        ///// </summary>
        ///// <param name="channel"></param>
        ///// <param name="message"></param>
        ///// <returns></returns>
        //public static long Publish(string channel, string message)
        //{
        //    ISubscriber sub = Instance.GetSubscriber();
        //    //return sub.Publish("messages", "hello");
        //    return sub.Publish(channel, message);
        //}

        ///// <summary>
        ///// 在消费者端得到该消息并输出
        ///// </summary>
        ///// <param name="channelFrom"></param>
        ///// <returns></returns>
        //public static void Subscribe(string channelFrom)
        //{
        //    ISubscriber sub = Instance.GetSubscriber();
        //    sub.Subscribe(channelFrom, (channel, message) =>
        //    {
        //        Console.WriteLine((string)message);
        //    });
        //}
        //#endregion

        ///// <summary>
        ///// GetServer方法会接收一个EndPoint类或者一个唯一标识一台服务器的键值对
        ///// 有时候需要为单个服务器指定特定的命令
        ///// 使用IServer可以使用所有的shell命令，比如：
        ///// DateTime lastSave = server.LastSave();
        ///// ClientInfo[] clients = server.ClientList();
        ///// 如果报错在连接字符串后加 ,allowAdmin=true;
        ///// </summary>
        ///// <returns></returns>
        //public static IServer GetServer(string host, int port)
        //{
        //    IServer server = Instance.GetServer(host, port);
        //    return server;
        //}

        ///// <summary>
        ///// 获取全部终结点
        ///// </summary>
        ///// <returns></returns>
        //public static EndPoint[] GetEndPoints()
        //{
        //    EndPoint[] endpoints = Instance.GetEndPoints();
        //    return endpoints;
        //}

        public Redlock GetRedlock()
        {
            return redlock;
        }
    }
}

