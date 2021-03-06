﻿using Google.Protobuf;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using Tendermint.Abci.Servers.Sockets;
using Tendermint.Abci.Types;

namespace Tendermint.Abci.Servers
{
    public class AbciSocketServer
    {
        private readonly static Int32 DEFAULT_LISTEN_SOCKET_PORT = 46658;

        AbciSocket _socket;
        CancellationToken _cancellation;
        IList<TcSocketConnection> _activeCOnnections;

        public IPEndPoint EndpointListen { get; private set; }

        public AbciSocketServer()
        :this(DEFAULT_LISTEN_SOCKET_PORT)
        {

        }

        public AbciSocketServer(int port)
            :this(new IPEndPoint(IPAddress.Any, port))
        {
        }

        public AbciSocketServer(IPEndPoint endpoint)
        {
            EndpointListen = endpoint;

            _activeCOnnections = new List<TcSocketConnection>(3);
            _socket = new AbciSocket(EndpointListen);
        }

        public Task Start()
        {
            while(true)
            {
                var client = _socket.Accept();
                //    .ContinueWith<TcpClient>(HandleConnection, TaskContinuationOptions.LongRunning);
            }            
        }

        //private async Task<Request> HandleConnection(TcpClient client)
        //{
        //    var buffer = new byte[8192];

        //    using (var ns = client.GetStream())
        //    {
        //        var byteCount = await ns.ReadAsync(buffer, 0, buffer.Length);
        //        var bs = Google.Protobuf.ByteString.FromStream(ns);

        //        var request = Request.Parser.ParseFrom(bs);

        //        switch (request.ValueCase)
        //        {
        //            case Request.ValueOneofCase.CheckTx:
        //                break;
        //            case Request.ValueOneofCase.DeliverTx:
        //                break;
        //            case Request.ValueOneofCase.Commit:
        //                break;
        //            case Request.ValueOneofCase.BeginBlock:
        //                break;
        //            case Request.ValueOneofCase.EndBlock:
        //                break;
        //            case Request.ValueOneofCase.InitChain:
        //                break;
        //            case Request.ValueOneofCase.Info:
        //                break;
        //            case Request.ValueOneofCase.Query:
        //                break;
        //            case Request.ValueOneofCase.SetOption:
        //                break;

        //        }

        //        Console.WriteLine("[Server] Reading from client");
        //    }
        //}

        //public async Task HandleRequest(Request request)
        //{

        //}
    }    
}

