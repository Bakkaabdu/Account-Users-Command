// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Protos/anis_subcategory_filling_mechanism_events_history.proto
// </auto-generated>
#pragma warning disable 0414, 1591, 8981, 0612
#region Designer generated code

using grpc = global::Grpc.Core;

namespace Anis.SubcategoryFillingMechanism.Commands.Grpc.Protos.History {
  public static partial class SubcategoryFillingMechanismEventsHistory
  {
    static readonly string __ServiceName = "anis.subcategory_filling_mechanism.commands.SubcategoryFillingMechanismEventsHistory";

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
    static readonly grpc::Marshaller<global::Anis.SubcategoryFillingMechanism.Commands.Grpc.Protos.History.GetEventsRequest> __Marshaller_anis_subcategory_filling_mechanism_commands_GetEventsRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Anis.SubcategoryFillingMechanism.Commands.Grpc.Protos.History.GetEventsRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Anis.SubcategoryFillingMechanism.Commands.Grpc.Protos.History.Response> __Marshaller_anis_subcategory_filling_mechanism_commands_Response = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Anis.SubcategoryFillingMechanism.Commands.Grpc.Protos.History.Response.Parser));

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::Anis.SubcategoryFillingMechanism.Commands.Grpc.Protos.History.GetEventsRequest, global::Anis.SubcategoryFillingMechanism.Commands.Grpc.Protos.History.Response> __Method_GetEvents = new grpc::Method<global::Anis.SubcategoryFillingMechanism.Commands.Grpc.Protos.History.GetEventsRequest, global::Anis.SubcategoryFillingMechanism.Commands.Grpc.Protos.History.Response>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetEvents",
        __Marshaller_anis_subcategory_filling_mechanism_commands_GetEventsRequest,
        __Marshaller_anis_subcategory_filling_mechanism_commands_Response);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::Anis.SubcategoryFillingMechanism.Commands.Grpc.Protos.History.AnisSubcategoryFillingMechanismEventsHistoryReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of SubcategoryFillingMechanismEventsHistory</summary>
    [grpc::BindServiceMethod(typeof(SubcategoryFillingMechanismEventsHistory), "BindService")]
    public abstract partial class SubcategoryFillingMechanismEventsHistoryBase
    {
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::Anis.SubcategoryFillingMechanism.Commands.Grpc.Protos.History.Response> GetEvents(global::Anis.SubcategoryFillingMechanism.Commands.Grpc.Protos.History.GetEventsRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public static grpc::ServerServiceDefinition BindService(SubcategoryFillingMechanismEventsHistoryBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_GetEvents, serviceImpl.GetEvents).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public static void BindService(grpc::ServiceBinderBase serviceBinder, SubcategoryFillingMechanismEventsHistoryBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_GetEvents, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::Anis.SubcategoryFillingMechanism.Commands.Grpc.Protos.History.GetEventsRequest, global::Anis.SubcategoryFillingMechanism.Commands.Grpc.Protos.History.Response>(serviceImpl.GetEvents));
    }

  }
}
#endregion
