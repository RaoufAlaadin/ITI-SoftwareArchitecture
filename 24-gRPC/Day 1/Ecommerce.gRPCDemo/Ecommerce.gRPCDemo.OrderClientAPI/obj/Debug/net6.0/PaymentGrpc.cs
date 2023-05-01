// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Payment.proto
// </auto-generated>
#pragma warning disable 0414, 1591, 8981
#region Designer generated code

using grpc = global::Grpc.Core;

namespace Ecommerce.gRPCDemo.PaymentServer.Protos {
  public static partial class Payment
  {
    static readonly string __ServiceName = "Payment";

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static void __Helper_SerializeMessage(global::Google.Protobuf.IMessage message, grpc::SerializationContext context)
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (message is global::Google.Protobuf.IBufferMessage)
      {
        context.SetPayloadLength(message.CalculateSize());
        global::Google.Protobuf.MessageExtensions.WriteTo(message, context.GetBufferWriter());
        context.Complete();
        return;
      }
      #endif
      context.Complete(global::Google.Protobuf.MessageExtensions.ToByteArray(message));
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static class __Helper_MessageCache<T>
    {
      public static readonly bool IsBufferMessage = global::System.Reflection.IntrospectionExtensions.GetTypeInfo(typeof(global::Google.Protobuf.IBufferMessage)).IsAssignableFrom(typeof(T));
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static T __Helper_DeserializeMessage<T>(grpc::DeserializationContext context, global::Google.Protobuf.MessageParser<T> parser) where T : global::Google.Protobuf.IMessage<T>
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (__Helper_MessageCache<T>.IsBufferMessage)
      {
        return parser.ParseFrom(context.PayloadAsReadOnlySequence());
      }
      #endif
      return parser.ParseFrom(context.PayloadAsNewBuffer());
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Ecommerce.gRPCDemo.PaymentServer.Protos.OrderDetails> __Marshaller_OrderDetails = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Ecommerce.gRPCDemo.PaymentServer.Protos.OrderDetails.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Ecommerce.gRPCDemo.PaymentServer.Protos.PaymentResponce> __Marshaller_PaymentResponce = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Ecommerce.gRPCDemo.PaymentServer.Protos.PaymentResponce.Parser));

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::Ecommerce.gRPCDemo.PaymentServer.Protos.OrderDetails, global::Ecommerce.gRPCDemo.PaymentServer.Protos.PaymentResponce> __Method_CheckBalance = new grpc::Method<global::Ecommerce.gRPCDemo.PaymentServer.Protos.OrderDetails, global::Ecommerce.gRPCDemo.PaymentServer.Protos.PaymentResponce>(
        grpc::MethodType.Unary,
        __ServiceName,
        "CheckBalance",
        __Marshaller_OrderDetails,
        __Marshaller_PaymentResponce);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::Ecommerce.gRPCDemo.PaymentServer.Protos.PaymentReflection.Descriptor.Services[0]; }
    }

    /// <summary>Client for Payment</summary>
    public partial class PaymentClient : grpc::ClientBase<PaymentClient>
    {
      /// <summary>Creates a new client for Payment</summary>
      /// <param name="channel">The channel to use to make remote calls.</param>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public PaymentClient(grpc::ChannelBase channel) : base(channel)
      {
      }
      /// <summary>Creates a new client for Payment that uses a custom <c>CallInvoker</c>.</summary>
      /// <param name="callInvoker">The callInvoker to use to make remote calls.</param>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public PaymentClient(grpc::CallInvoker callInvoker) : base(callInvoker)
      {
      }
      /// <summary>Protected parameterless constructor to allow creation of test doubles.</summary>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      protected PaymentClient() : base()
      {
      }
      /// <summary>Protected constructor to allow creation of configured clients.</summary>
      /// <param name="configuration">The client configuration.</param>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      protected PaymentClient(ClientBaseConfiguration configuration) : base(configuration)
      {
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Ecommerce.gRPCDemo.PaymentServer.Protos.PaymentResponce CheckBalance(global::Ecommerce.gRPCDemo.PaymentServer.Protos.OrderDetails request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return CheckBalance(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Ecommerce.gRPCDemo.PaymentServer.Protos.PaymentResponce CheckBalance(global::Ecommerce.gRPCDemo.PaymentServer.Protos.OrderDetails request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_CheckBalance, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Ecommerce.gRPCDemo.PaymentServer.Protos.PaymentResponce> CheckBalanceAsync(global::Ecommerce.gRPCDemo.PaymentServer.Protos.OrderDetails request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return CheckBalanceAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Ecommerce.gRPCDemo.PaymentServer.Protos.PaymentResponce> CheckBalanceAsync(global::Ecommerce.gRPCDemo.PaymentServer.Protos.OrderDetails request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_CheckBalance, null, options, request);
      }
      /// <summary>Creates a new instance of client from given <c>ClientBaseConfiguration</c>.</summary>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      protected override PaymentClient NewInstance(ClientBaseConfiguration configuration)
      {
        return new PaymentClient(configuration);
      }
    }

  }
}
#endregion
