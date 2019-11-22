﻿using DotNetty.Buffers;
using DotNetty.Codecs;
using DotNetty.Transport.Bootstrapping;
using DotNetty.Transport.Channels;
using DotNetty.Transport.Channels.Sockets;
using STSys.Core.DotNettyRPC.Extention;
using STSys.Core.DotNettyRPC.Handler;
using STSys.Core.DotNettyRPC.Helper;
using System;
using System.Dynamic;
using System.Linq;
using System.Text;

namespace STSys.Core.DotNettyRPC
{
    class RPCClientProxy : DynamicObject
    {
        static RPCClientProxy()
        {
            _bootstrap = new Bootstrap()
                .Group(new MultithreadEventLoopGroup())
                .Channel<TcpSocketChannel>()
                .Option(ChannelOption.TcpNodelay, true)
                .Handler(new ActionChannelInitializer<ISocketChannel>(channel =>
                {
                    IChannelPipeline pipeline = channel.Pipeline;
                    pipeline.AddLast("framing-enc", new LengthFieldPrepender(8));
                    pipeline.AddLast("framing-dec", new LengthFieldBasedFrameDecoder(int.MaxValue, 0, 8, 0, 8));

                    pipeline.AddLast(new ClientHandler(_clientWait));
                }));
        }
        public string ServerIp { get; set; }
        public int ServerPort { get; set; }
        public string ServiceName { get; set; }
        public Type ServiceType { get; set; }
        static Bootstrap _bootstrap { get; }
        static ClientWait _clientWait { get; } = new ClientWait();
        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {
            try
            {
                ResponseModel response = null;
                IChannel client = null;
                try
                {
                    client = TaskHelper.RunSync(() => _bootstrap.ConnectAsync($"{ServerIp}:{ServerPort}".ToIPEndPoint()));
                }
                catch
                {
                    throw new Exception("连接到服务端失败!");
                }
                if (client != null)
                {
                    _clientWait.Start(client.Id.AsShortText());
                    RequestModel requestModel = new RequestModel
                    {
                        ServiceName = ServiceName,
                        MethodName = binder.Name,
                        Paramters = args.ToList()
                    };
                    var sendBuffer = Unpooled.WrappedBuffer(requestModel.ToJson().ToBytes(Encoding.UTF8));

                    client.WriteAndFlushAsync(sendBuffer);
                    var responseStr = _clientWait.Wait(client.Id.AsShortText()).ResponseString;
                    response = responseStr.ToObject<ResponseModel>();
                }
                else
                {
                    throw new Exception("连接到服务端失败!");
                }

                if (response == null)
                    throw new Exception("服务器超时未响应");
                else if (response.Success)
                {
                    Type returnType = ServiceType.GetMethod(binder.Name).ReturnType;
                    if (returnType == typeof(void))
                        result = null;
                    else
                        result = response.Data.ToObject(returnType);

                    return true;
                }
                else
                    throw new Exception($"服务器异常，错误消息：{response.Msg}");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
