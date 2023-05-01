// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: InventoryService.proto
// </auto-generated>
#pragma warning disable 0414, 1591
#region Designer generated code

using grpc = global::Grpc.Core;

namespace Ecommerce.gRPCDemo.InventoryServer.Protos {
  public static partial class InventoryService
  {
    static readonly string __ServiceName = "InventoryService";

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
    static readonly grpc::Marshaller<global::Ecommerce.gRPCDemo.InventoryServer.Protos.OrderDetails> __Marshaller_OrderDetails = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Ecommerce.gRPCDemo.InventoryServer.Protos.OrderDetails.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Ecommerce.gRPCDemo.InventoryServer.Protos.InventoryResponce> __Marshaller_InventoryResponce = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Ecommerce.gRPCDemo.InventoryServer.Protos.InventoryResponce.Parser));

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::Ecommerce.gRPCDemo.InventoryServer.Protos.OrderDetails, global::Ecommerce.gRPCDemo.InventoryServer.Protos.InventoryResponce> __Method_CheckInventory = new grpc::Method<global::Ecommerce.gRPCDemo.InventoryServer.Protos.OrderDetails, global::Ecommerce.gRPCDemo.InventoryServer.Protos.InventoryResponce>(
        grpc::MethodType.Unary,
        __ServiceName,
        "CheckInventory",
        __Marshaller_OrderDetails,
        __Marshaller_InventoryResponce);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::Ecommerce.gRPCDemo.InventoryServer.Protos.InventoryServiceReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of InventoryService</summary>
    [grpc::BindServiceMethod(typeof(InventoryService), "BindService")]
    public abstract partial class InventoryServiceBase
    {
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::Ecommerce.gRPCDemo.InventoryServer.Protos.InventoryResponce> CheckInventory(global::Ecommerce.gRPCDemo.InventoryServer.Protos.OrderDetails request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public static grpc::ServerServiceDefinition BindService(InventoryServiceBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_CheckInventory, serviceImpl.CheckInventory).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the  service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public static void BindService(grpc::ServiceBinderBase serviceBinder, InventoryServiceBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_CheckInventory, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::Ecommerce.gRPCDemo.InventoryServer.Protos.OrderDetails, global::Ecommerce.gRPCDemo.InventoryServer.Protos.InventoryResponce>(serviceImpl.CheckInventory));
    }

  }
}
#endregion
