// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Protos/anis_subcategory_filling_mechanism_events_history.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021, 8981
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace Anis.SubcategoryFillingMechanism.Commands.Grpc.Protos.History {

  /// <summary>Holder for reflection information generated from Protos/anis_subcategory_filling_mechanism_events_history.proto</summary>
  public static partial class AnisSubcategoryFillingMechanismEventsHistoryReflection {

    #region Descriptor
    /// <summary>File descriptor for Protos/anis_subcategory_filling_mechanism_events_history.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static AnisSubcategoryFillingMechanismEventsHistoryReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "Cj5Qcm90b3MvYW5pc19zdWJjYXRlZ29yeV9maWxsaW5nX21lY2hhbmlzbV9l",
            "dmVudHNfaGlzdG9yeS5wcm90bxIrYW5pcy5zdWJjYXRlZ29yeV9maWxsaW5n",
            "X21lY2hhbmlzbS5jb21tYW5kcxofZ29vZ2xlL3Byb3RvYnVmL3RpbWVzdGFt",
            "cC5wcm90byI7ChBHZXRFdmVudHNSZXF1ZXN0EhQKDGN1cnJlbnRfcGFnZRgB",
            "IAEoBRIRCglwYWdlX3NpemUYAiABKAUiVQoIUmVzcG9uc2USSQoGZXZlbnRz",
            "GAEgAygLMjkuYW5pcy5zdWJjYXRlZ29yeV9maWxsaW5nX21lY2hhbmlzbS5j",
            "b21tYW5kcy5FdmVudE1lc3NhZ2UiuwEKDEV2ZW50TWVzc2FnZRIWCg5jb3Jy",
            "ZWxhdGlvbl9pZBgBIAEoCRItCglkYXRlX3RpbWUYAiABKAsyGi5nb29nbGUu",
            "cHJvdG9idWYuVGltZXN0YW1wEgwKBGRhdGEYAyABKAkSDAoEdHlwZRgEIAEo",
            "CRIQCghzZXF1ZW5jZRgFIAEoBRIPCgd2ZXJzaW9uGAYgASgFEhQKDGFnZ3Jl",
            "ZGF0ZV9pZBgHIAEoCRIPCgd1c2VyX2lkGAggASgJMq4BCihTdWJjYXRlZ29y",
            "eUZpbGxpbmdNZWNoYW5pc21FdmVudHNIaXN0b3J5EoEBCglHZXRFdmVudHMS",
            "PS5hbmlzLnN1YmNhdGVnb3J5X2ZpbGxpbmdfbWVjaGFuaXNtLmNvbW1hbmRz",
            "LkdldEV2ZW50c1JlcXVlc3QaNS5hbmlzLnN1YmNhdGVnb3J5X2ZpbGxpbmdf",
            "bWVjaGFuaXNtLmNvbW1hbmRzLlJlc3BvbnNlQkCqAj1BbmlzLlN1YmNhdGVn",
            "b3J5RmlsbGluZ01lY2hhbmlzbS5Db21tYW5kcy5HcnBjLlByb3Rvcy5IaXN0",
            "b3J5YgZwcm90bzM="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { global::Google.Protobuf.WellKnownTypes.TimestampReflection.Descriptor, },
          new pbr::GeneratedClrTypeInfo(null, null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::Anis.SubcategoryFillingMechanism.Commands.Grpc.Protos.History.GetEventsRequest), global::Anis.SubcategoryFillingMechanism.Commands.Grpc.Protos.History.GetEventsRequest.Parser, new[]{ "CurrentPage", "PageSize" }, null, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::Anis.SubcategoryFillingMechanism.Commands.Grpc.Protos.History.Response), global::Anis.SubcategoryFillingMechanism.Commands.Grpc.Protos.History.Response.Parser, new[]{ "Events" }, null, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::Anis.SubcategoryFillingMechanism.Commands.Grpc.Protos.History.EventMessage), global::Anis.SubcategoryFillingMechanism.Commands.Grpc.Protos.History.EventMessage.Parser, new[]{ "CorrelationId", "DateTime", "Data", "Type", "Sequence", "Version", "AggredateId", "UserId" }, null, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  [global::System.Diagnostics.DebuggerDisplayAttribute("{ToString(),nq}")]
  public sealed partial class GetEventsRequest : pb::IMessage<GetEventsRequest>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<GetEventsRequest> _parser = new pb::MessageParser<GetEventsRequest>(() => new GetEventsRequest());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pb::MessageParser<GetEventsRequest> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Anis.SubcategoryFillingMechanism.Commands.Grpc.Protos.History.AnisSubcategoryFillingMechanismEventsHistoryReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public GetEventsRequest() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public GetEventsRequest(GetEventsRequest other) : this() {
      currentPage_ = other.currentPage_;
      pageSize_ = other.pageSize_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public GetEventsRequest Clone() {
      return new GetEventsRequest(this);
    }

    /// <summary>Field number for the "current_page" field.</summary>
    public const int CurrentPageFieldNumber = 1;
    private int currentPage_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int CurrentPage {
      get { return currentPage_; }
      set {
        currentPage_ = value;
      }
    }

    /// <summary>Field number for the "page_size" field.</summary>
    public const int PageSizeFieldNumber = 2;
    private int pageSize_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int PageSize {
      get { return pageSize_; }
      set {
        pageSize_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override bool Equals(object other) {
      return Equals(other as GetEventsRequest);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Equals(GetEventsRequest other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (CurrentPage != other.CurrentPage) return false;
      if (PageSize != other.PageSize) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override int GetHashCode() {
      int hash = 1;
      if (CurrentPage != 0) hash ^= CurrentPage.GetHashCode();
      if (PageSize != 0) hash ^= PageSize.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void WriteTo(pb::CodedOutputStream output) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      output.WriteRawMessage(this);
    #else
      if (CurrentPage != 0) {
        output.WriteRawTag(8);
        output.WriteInt32(CurrentPage);
      }
      if (PageSize != 0) {
        output.WriteRawTag(16);
        output.WriteInt32(PageSize);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output) {
      if (CurrentPage != 0) {
        output.WriteRawTag(8);
        output.WriteInt32(CurrentPage);
      }
      if (PageSize != 0) {
        output.WriteRawTag(16);
        output.WriteInt32(PageSize);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(ref output);
      }
    }
    #endif

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int CalculateSize() {
      int size = 0;
      if (CurrentPage != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(CurrentPage);
      }
      if (PageSize != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(PageSize);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(GetEventsRequest other) {
      if (other == null) {
        return;
      }
      if (other.CurrentPage != 0) {
        CurrentPage = other.CurrentPage;
      }
      if (other.PageSize != 0) {
        PageSize = other.PageSize;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(pb::CodedInputStream input) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      input.ReadRawMessage(this);
    #else
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 8: {
            CurrentPage = input.ReadInt32();
            break;
          }
          case 16: {
            PageSize = input.ReadInt32();
            break;
          }
        }
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalMergeFrom(ref pb::ParseContext input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
            break;
          case 8: {
            CurrentPage = input.ReadInt32();
            break;
          }
          case 16: {
            PageSize = input.ReadInt32();
            break;
          }
        }
      }
    }
    #endif

  }

  [global::System.Diagnostics.DebuggerDisplayAttribute("{ToString(),nq}")]
  public sealed partial class Response : pb::IMessage<Response>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<Response> _parser = new pb::MessageParser<Response>(() => new Response());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pb::MessageParser<Response> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Anis.SubcategoryFillingMechanism.Commands.Grpc.Protos.History.AnisSubcategoryFillingMechanismEventsHistoryReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public Response() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public Response(Response other) : this() {
      events_ = other.events_.Clone();
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public Response Clone() {
      return new Response(this);
    }

    /// <summary>Field number for the "events" field.</summary>
    public const int EventsFieldNumber = 1;
    private static readonly pb::FieldCodec<global::Anis.SubcategoryFillingMechanism.Commands.Grpc.Protos.History.EventMessage> _repeated_events_codec
        = pb::FieldCodec.ForMessage(10, global::Anis.SubcategoryFillingMechanism.Commands.Grpc.Protos.History.EventMessage.Parser);
    private readonly pbc::RepeatedField<global::Anis.SubcategoryFillingMechanism.Commands.Grpc.Protos.History.EventMessage> events_ = new pbc::RepeatedField<global::Anis.SubcategoryFillingMechanism.Commands.Grpc.Protos.History.EventMessage>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public pbc::RepeatedField<global::Anis.SubcategoryFillingMechanism.Commands.Grpc.Protos.History.EventMessage> Events {
      get { return events_; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override bool Equals(object other) {
      return Equals(other as Response);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Equals(Response other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if(!events_.Equals(other.events_)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override int GetHashCode() {
      int hash = 1;
      hash ^= events_.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void WriteTo(pb::CodedOutputStream output) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      output.WriteRawMessage(this);
    #else
      events_.WriteTo(output, _repeated_events_codec);
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output) {
      events_.WriteTo(ref output, _repeated_events_codec);
      if (_unknownFields != null) {
        _unknownFields.WriteTo(ref output);
      }
    }
    #endif

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int CalculateSize() {
      int size = 0;
      size += events_.CalculateSize(_repeated_events_codec);
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(Response other) {
      if (other == null) {
        return;
      }
      events_.Add(other.events_);
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(pb::CodedInputStream input) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      input.ReadRawMessage(this);
    #else
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            events_.AddEntriesFrom(input, _repeated_events_codec);
            break;
          }
        }
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalMergeFrom(ref pb::ParseContext input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
            break;
          case 10: {
            events_.AddEntriesFrom(ref input, _repeated_events_codec);
            break;
          }
        }
      }
    }
    #endif

  }

  [global::System.Diagnostics.DebuggerDisplayAttribute("{ToString(),nq}")]
  public sealed partial class EventMessage : pb::IMessage<EventMessage>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<EventMessage> _parser = new pb::MessageParser<EventMessage>(() => new EventMessage());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pb::MessageParser<EventMessage> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Anis.SubcategoryFillingMechanism.Commands.Grpc.Protos.History.AnisSubcategoryFillingMechanismEventsHistoryReflection.Descriptor.MessageTypes[2]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public EventMessage() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public EventMessage(EventMessage other) : this() {
      correlationId_ = other.correlationId_;
      dateTime_ = other.dateTime_ != null ? other.dateTime_.Clone() : null;
      data_ = other.data_;
      type_ = other.type_;
      sequence_ = other.sequence_;
      version_ = other.version_;
      aggredateId_ = other.aggredateId_;
      userId_ = other.userId_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public EventMessage Clone() {
      return new EventMessage(this);
    }

    /// <summary>Field number for the "correlation_id" field.</summary>
    public const int CorrelationIdFieldNumber = 1;
    private string correlationId_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public string CorrelationId {
      get { return correlationId_; }
      set {
        correlationId_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "date_time" field.</summary>
    public const int DateTimeFieldNumber = 2;
    private global::Google.Protobuf.WellKnownTypes.Timestamp dateTime_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public global::Google.Protobuf.WellKnownTypes.Timestamp DateTime {
      get { return dateTime_; }
      set {
        dateTime_ = value;
      }
    }

    /// <summary>Field number for the "data" field.</summary>
    public const int DataFieldNumber = 3;
    private string data_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public string Data {
      get { return data_; }
      set {
        data_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "type" field.</summary>
    public const int TypeFieldNumber = 4;
    private string type_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public string Type {
      get { return type_; }
      set {
        type_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "sequence" field.</summary>
    public const int SequenceFieldNumber = 5;
    private int sequence_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int Sequence {
      get { return sequence_; }
      set {
        sequence_ = value;
      }
    }

    /// <summary>Field number for the "version" field.</summary>
    public const int VersionFieldNumber = 6;
    private int version_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int Version {
      get { return version_; }
      set {
        version_ = value;
      }
    }

    /// <summary>Field number for the "aggredate_id" field.</summary>
    public const int AggredateIdFieldNumber = 7;
    private string aggredateId_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public string AggredateId {
      get { return aggredateId_; }
      set {
        aggredateId_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "user_id" field.</summary>
    public const int UserIdFieldNumber = 8;
    private string userId_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public string UserId {
      get { return userId_; }
      set {
        userId_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override bool Equals(object other) {
      return Equals(other as EventMessage);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Equals(EventMessage other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (CorrelationId != other.CorrelationId) return false;
      if (!object.Equals(DateTime, other.DateTime)) return false;
      if (Data != other.Data) return false;
      if (Type != other.Type) return false;
      if (Sequence != other.Sequence) return false;
      if (Version != other.Version) return false;
      if (AggredateId != other.AggredateId) return false;
      if (UserId != other.UserId) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override int GetHashCode() {
      int hash = 1;
      if (CorrelationId.Length != 0) hash ^= CorrelationId.GetHashCode();
      if (dateTime_ != null) hash ^= DateTime.GetHashCode();
      if (Data.Length != 0) hash ^= Data.GetHashCode();
      if (Type.Length != 0) hash ^= Type.GetHashCode();
      if (Sequence != 0) hash ^= Sequence.GetHashCode();
      if (Version != 0) hash ^= Version.GetHashCode();
      if (AggredateId.Length != 0) hash ^= AggredateId.GetHashCode();
      if (UserId.Length != 0) hash ^= UserId.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void WriteTo(pb::CodedOutputStream output) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      output.WriteRawMessage(this);
    #else
      if (CorrelationId.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(CorrelationId);
      }
      if (dateTime_ != null) {
        output.WriteRawTag(18);
        output.WriteMessage(DateTime);
      }
      if (Data.Length != 0) {
        output.WriteRawTag(26);
        output.WriteString(Data);
      }
      if (Type.Length != 0) {
        output.WriteRawTag(34);
        output.WriteString(Type);
      }
      if (Sequence != 0) {
        output.WriteRawTag(40);
        output.WriteInt32(Sequence);
      }
      if (Version != 0) {
        output.WriteRawTag(48);
        output.WriteInt32(Version);
      }
      if (AggredateId.Length != 0) {
        output.WriteRawTag(58);
        output.WriteString(AggredateId);
      }
      if (UserId.Length != 0) {
        output.WriteRawTag(66);
        output.WriteString(UserId);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output) {
      if (CorrelationId.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(CorrelationId);
      }
      if (dateTime_ != null) {
        output.WriteRawTag(18);
        output.WriteMessage(DateTime);
      }
      if (Data.Length != 0) {
        output.WriteRawTag(26);
        output.WriteString(Data);
      }
      if (Type.Length != 0) {
        output.WriteRawTag(34);
        output.WriteString(Type);
      }
      if (Sequence != 0) {
        output.WriteRawTag(40);
        output.WriteInt32(Sequence);
      }
      if (Version != 0) {
        output.WriteRawTag(48);
        output.WriteInt32(Version);
      }
      if (AggredateId.Length != 0) {
        output.WriteRawTag(58);
        output.WriteString(AggredateId);
      }
      if (UserId.Length != 0) {
        output.WriteRawTag(66);
        output.WriteString(UserId);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(ref output);
      }
    }
    #endif

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int CalculateSize() {
      int size = 0;
      if (CorrelationId.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(CorrelationId);
      }
      if (dateTime_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(DateTime);
      }
      if (Data.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Data);
      }
      if (Type.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Type);
      }
      if (Sequence != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(Sequence);
      }
      if (Version != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(Version);
      }
      if (AggredateId.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(AggredateId);
      }
      if (UserId.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(UserId);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(EventMessage other) {
      if (other == null) {
        return;
      }
      if (other.CorrelationId.Length != 0) {
        CorrelationId = other.CorrelationId;
      }
      if (other.dateTime_ != null) {
        if (dateTime_ == null) {
          DateTime = new global::Google.Protobuf.WellKnownTypes.Timestamp();
        }
        DateTime.MergeFrom(other.DateTime);
      }
      if (other.Data.Length != 0) {
        Data = other.Data;
      }
      if (other.Type.Length != 0) {
        Type = other.Type;
      }
      if (other.Sequence != 0) {
        Sequence = other.Sequence;
      }
      if (other.Version != 0) {
        Version = other.Version;
      }
      if (other.AggredateId.Length != 0) {
        AggredateId = other.AggredateId;
      }
      if (other.UserId.Length != 0) {
        UserId = other.UserId;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(pb::CodedInputStream input) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      input.ReadRawMessage(this);
    #else
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            CorrelationId = input.ReadString();
            break;
          }
          case 18: {
            if (dateTime_ == null) {
              DateTime = new global::Google.Protobuf.WellKnownTypes.Timestamp();
            }
            input.ReadMessage(DateTime);
            break;
          }
          case 26: {
            Data = input.ReadString();
            break;
          }
          case 34: {
            Type = input.ReadString();
            break;
          }
          case 40: {
            Sequence = input.ReadInt32();
            break;
          }
          case 48: {
            Version = input.ReadInt32();
            break;
          }
          case 58: {
            AggredateId = input.ReadString();
            break;
          }
          case 66: {
            UserId = input.ReadString();
            break;
          }
        }
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalMergeFrom(ref pb::ParseContext input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
            break;
          case 10: {
            CorrelationId = input.ReadString();
            break;
          }
          case 18: {
            if (dateTime_ == null) {
              DateTime = new global::Google.Protobuf.WellKnownTypes.Timestamp();
            }
            input.ReadMessage(DateTime);
            break;
          }
          case 26: {
            Data = input.ReadString();
            break;
          }
          case 34: {
            Type = input.ReadString();
            break;
          }
          case 40: {
            Sequence = input.ReadInt32();
            break;
          }
          case 48: {
            Version = input.ReadInt32();
            break;
          }
          case 58: {
            AggredateId = input.ReadString();
            break;
          }
          case 66: {
            UserId = input.ReadString();
            break;
          }
        }
      }
    }
    #endif

  }

  #endregion

}

#endregion Designer generated code
