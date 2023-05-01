// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Protos/PaymentModel.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace Ecommerce.gRPCDemo.PaymentServer.Protos {

  /// <summary>Holder for reflection information generated from Protos/PaymentModel.proto</summary>
  public static partial class PaymentModelReflection {

    #region Descriptor
    /// <summary>File descriptor for Protos/PaymentModel.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static PaymentModelReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "ChlQcm90b3MvUGF5bWVudE1vZGVsLnByb3RvGh9nb29nbGUvcHJvdG9idWYv",
            "dGltZXN0YW1wLnByb3RvIlEKDE9yZGVyRGV0YWlscxIOCgZpdGVtSWQYASAB",
            "KAUSEAoIaXRlbU5hbWUYAiABKAkSEAoIcXVhbnRpdHkYAyABKAUSDQoFcHJp",
            "Y2UYBCABKAUiUgoPUGF5bWVudFJlc3BvbmNlEhQKDElzU3VjY2Vzc2Z1bBgB",
            "IAEoCRIpCgVzdGFtcBgCIAEoCzIaLmdvb2dsZS5wcm90b2J1Zi5UaW1lc3Rh",
            "bXBCKqoCJ0Vjb21tZXJjZS5nUlBDRGVtby5QYXltZW50U2VydmVyLlByb3Rv",
            "c2IGcHJvdG8z"));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { global::Google.Protobuf.WellKnownTypes.TimestampReflection.Descriptor, },
          new pbr::GeneratedClrTypeInfo(null, null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::Ecommerce.gRPCDemo.PaymentServer.Protos.OrderDetails), global::Ecommerce.gRPCDemo.PaymentServer.Protos.OrderDetails.Parser, new[]{ "ItemId", "ItemName", "Quantity", "Price" }, null, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::Ecommerce.gRPCDemo.PaymentServer.Protos.PaymentResponce), global::Ecommerce.gRPCDemo.PaymentServer.Protos.PaymentResponce.Parser, new[]{ "IsSuccessful", "Stamp" }, null, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class OrderDetails : pb::IMessage<OrderDetails>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<OrderDetails> _parser = new pb::MessageParser<OrderDetails>(() => new OrderDetails());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<OrderDetails> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Ecommerce.gRPCDemo.PaymentServer.Protos.PaymentModelReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public OrderDetails() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public OrderDetails(OrderDetails other) : this() {
      itemId_ = other.itemId_;
      itemName_ = other.itemName_;
      quantity_ = other.quantity_;
      price_ = other.price_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public OrderDetails Clone() {
      return new OrderDetails(this);
    }

    /// <summary>Field number for the "itemId" field.</summary>
    public const int ItemIdFieldNumber = 1;
    private int itemId_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int ItemId {
      get { return itemId_; }
      set {
        itemId_ = value;
      }
    }

    /// <summary>Field number for the "itemName" field.</summary>
    public const int ItemNameFieldNumber = 2;
    private string itemName_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string ItemName {
      get { return itemName_; }
      set {
        itemName_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "quantity" field.</summary>
    public const int QuantityFieldNumber = 3;
    private int quantity_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int Quantity {
      get { return quantity_; }
      set {
        quantity_ = value;
      }
    }

    /// <summary>Field number for the "price" field.</summary>
    public const int PriceFieldNumber = 4;
    private int price_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int Price {
      get { return price_; }
      set {
        price_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as OrderDetails);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(OrderDetails other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (ItemId != other.ItemId) return false;
      if (ItemName != other.ItemName) return false;
      if (Quantity != other.Quantity) return false;
      if (Price != other.Price) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (ItemId != 0) hash ^= ItemId.GetHashCode();
      if (ItemName.Length != 0) hash ^= ItemName.GetHashCode();
      if (Quantity != 0) hash ^= Quantity.GetHashCode();
      if (Price != 0) hash ^= Price.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      output.WriteRawMessage(this);
    #else
      if (ItemId != 0) {
        output.WriteRawTag(8);
        output.WriteInt32(ItemId);
      }
      if (ItemName.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(ItemName);
      }
      if (Quantity != 0) {
        output.WriteRawTag(24);
        output.WriteInt32(Quantity);
      }
      if (Price != 0) {
        output.WriteRawTag(32);
        output.WriteInt32(Price);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output) {
      if (ItemId != 0) {
        output.WriteRawTag(8);
        output.WriteInt32(ItemId);
      }
      if (ItemName.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(ItemName);
      }
      if (Quantity != 0) {
        output.WriteRawTag(24);
        output.WriteInt32(Quantity);
      }
      if (Price != 0) {
        output.WriteRawTag(32);
        output.WriteInt32(Price);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(ref output);
      }
    }
    #endif

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (ItemId != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(ItemId);
      }
      if (ItemName.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(ItemName);
      }
      if (Quantity != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(Quantity);
      }
      if (Price != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(Price);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(OrderDetails other) {
      if (other == null) {
        return;
      }
      if (other.ItemId != 0) {
        ItemId = other.ItemId;
      }
      if (other.ItemName.Length != 0) {
        ItemName = other.ItemName;
      }
      if (other.Quantity != 0) {
        Quantity = other.Quantity;
      }
      if (other.Price != 0) {
        Price = other.Price;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
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
            ItemId = input.ReadInt32();
            break;
          }
          case 18: {
            ItemName = input.ReadString();
            break;
          }
          case 24: {
            Quantity = input.ReadInt32();
            break;
          }
          case 32: {
            Price = input.ReadInt32();
            break;
          }
        }
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    void pb::IBufferMessage.InternalMergeFrom(ref pb::ParseContext input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
            break;
          case 8: {
            ItemId = input.ReadInt32();
            break;
          }
          case 18: {
            ItemName = input.ReadString();
            break;
          }
          case 24: {
            Quantity = input.ReadInt32();
            break;
          }
          case 32: {
            Price = input.ReadInt32();
            break;
          }
        }
      }
    }
    #endif

  }

  public sealed partial class PaymentResponce : pb::IMessage<PaymentResponce>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<PaymentResponce> _parser = new pb::MessageParser<PaymentResponce>(() => new PaymentResponce());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<PaymentResponce> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Ecommerce.gRPCDemo.PaymentServer.Protos.PaymentModelReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public PaymentResponce() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public PaymentResponce(PaymentResponce other) : this() {
      isSuccessful_ = other.isSuccessful_;
      stamp_ = other.stamp_ != null ? other.stamp_.Clone() : null;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public PaymentResponce Clone() {
      return new PaymentResponce(this);
    }

    /// <summary>Field number for the "IsSuccessful" field.</summary>
    public const int IsSuccessfulFieldNumber = 1;
    private string isSuccessful_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string IsSuccessful {
      get { return isSuccessful_; }
      set {
        isSuccessful_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "stamp" field.</summary>
    public const int StampFieldNumber = 2;
    private global::Google.Protobuf.WellKnownTypes.Timestamp stamp_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::Google.Protobuf.WellKnownTypes.Timestamp Stamp {
      get { return stamp_; }
      set {
        stamp_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as PaymentResponce);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(PaymentResponce other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (IsSuccessful != other.IsSuccessful) return false;
      if (!object.Equals(Stamp, other.Stamp)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (IsSuccessful.Length != 0) hash ^= IsSuccessful.GetHashCode();
      if (stamp_ != null) hash ^= Stamp.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      output.WriteRawMessage(this);
    #else
      if (IsSuccessful.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(IsSuccessful);
      }
      if (stamp_ != null) {
        output.WriteRawTag(18);
        output.WriteMessage(Stamp);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output) {
      if (IsSuccessful.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(IsSuccessful);
      }
      if (stamp_ != null) {
        output.WriteRawTag(18);
        output.WriteMessage(Stamp);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(ref output);
      }
    }
    #endif

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (IsSuccessful.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(IsSuccessful);
      }
      if (stamp_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(Stamp);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(PaymentResponce other) {
      if (other == null) {
        return;
      }
      if (other.IsSuccessful.Length != 0) {
        IsSuccessful = other.IsSuccessful;
      }
      if (other.stamp_ != null) {
        if (stamp_ == null) {
          Stamp = new global::Google.Protobuf.WellKnownTypes.Timestamp();
        }
        Stamp.MergeFrom(other.Stamp);
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
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
            IsSuccessful = input.ReadString();
            break;
          }
          case 18: {
            if (stamp_ == null) {
              Stamp = new global::Google.Protobuf.WellKnownTypes.Timestamp();
            }
            input.ReadMessage(Stamp);
            break;
          }
        }
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    void pb::IBufferMessage.InternalMergeFrom(ref pb::ParseContext input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
            break;
          case 10: {
            IsSuccessful = input.ReadString();
            break;
          }
          case 18: {
            if (stamp_ == null) {
              Stamp = new global::Google.Protobuf.WellKnownTypes.Timestamp();
            }
            input.ReadMessage(Stamp);
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
