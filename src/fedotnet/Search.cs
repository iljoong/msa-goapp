// Generated by the protocol buffer compiler.  DO NOT EDIT!
// source: search.proto
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
/// <summary>Holder for reflection information generated from search.proto</summary>
public static partial class SearchReflection {

  #region Descriptor
  /// <summary>File descriptor for search.proto</summary>
  public static pbr::FileDescriptor Descriptor {
    get { return descriptor; }
  }
  private static pbr::FileDescriptor descriptor;

  static SearchReflection() {
    byte[] descriptorData = global::System.Convert.FromBase64String(
        string.Concat(
          "CgxzZWFyY2gucHJvdG8iGAoHUmVxdWVzdBINCgVxdWVyeRgBIAEoCSJCCgZS",
          "ZXN1bHQSDQoFdGl0bGUYASABKAkSCwoDdXJsGAIgASgJEg8KB3NuaXBwZXQY",
          "AyABKAkSCwoDbG9nGAQgASgJMicKBkdvb2dsZRIdCgZTZWFyY2gSCC5SZXF1",
          "ZXN0GgcuUmVzdWx0IgBiBnByb3RvMw=="));
    descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
        new pbr::FileDescriptor[] { },
        new pbr::GeneratedClrTypeInfo(null, new pbr::GeneratedClrTypeInfo[] {
          new pbr::GeneratedClrTypeInfo(typeof(global::Request), global::Request.Parser, new[]{ "Query" }, null, null, null),
          new pbr::GeneratedClrTypeInfo(typeof(global::Result), global::Result.Parser, new[]{ "Title", "Url", "Snippet", "Log" }, null, null, null)
        }));
  }
  #endregion

}
#region Messages
public sealed partial class Request : pb::IMessage<Request> {
  private static readonly pb::MessageParser<Request> _parser = new pb::MessageParser<Request>(() => new Request());
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public static pb::MessageParser<Request> Parser { get { return _parser; } }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public static pbr::MessageDescriptor Descriptor {
    get { return global::SearchReflection.Descriptor.MessageTypes[0]; }
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  pbr::MessageDescriptor pb::IMessage.Descriptor {
    get { return Descriptor; }
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public Request() {
    OnConstruction();
  }

  partial void OnConstruction();

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public Request(Request other) : this() {
    query_ = other.query_;
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public Request Clone() {
    return new Request(this);
  }

  /// <summary>Field number for the "query" field.</summary>
  public const int QueryFieldNumber = 1;
  private string query_ = "";
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public string Query {
    get { return query_; }
    set {
      query_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
    }
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public override bool Equals(object other) {
    return Equals(other as Request);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public bool Equals(Request other) {
    if (ReferenceEquals(other, null)) {
      return false;
    }
    if (ReferenceEquals(other, this)) {
      return true;
    }
    if (Query != other.Query) return false;
    return true;
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public override int GetHashCode() {
    int hash = 1;
    if (Query.Length != 0) hash ^= Query.GetHashCode();
    return hash;
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public override string ToString() {
    return pb::JsonFormatter.ToDiagnosticString(this);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public void WriteTo(pb::CodedOutputStream output) {
    if (Query.Length != 0) {
      output.WriteRawTag(10);
      output.WriteString(Query);
    }
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public int CalculateSize() {
    int size = 0;
    if (Query.Length != 0) {
      size += 1 + pb::CodedOutputStream.ComputeStringSize(Query);
    }
    return size;
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public void MergeFrom(Request other) {
    if (other == null) {
      return;
    }
    if (other.Query.Length != 0) {
      Query = other.Query;
    }
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public void MergeFrom(pb::CodedInputStream input) {
    uint tag;
    while ((tag = input.ReadTag()) != 0) {
      switch(tag) {
        default:
          input.SkipLastField();
          break;
        case 10: {
          Query = input.ReadString();
          break;
        }
      }
    }
  }

}

public sealed partial class Result : pb::IMessage<Result> {
  private static readonly pb::MessageParser<Result> _parser = new pb::MessageParser<Result>(() => new Result());
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public static pb::MessageParser<Result> Parser { get { return _parser; } }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public static pbr::MessageDescriptor Descriptor {
    get { return global::SearchReflection.Descriptor.MessageTypes[1]; }
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  pbr::MessageDescriptor pb::IMessage.Descriptor {
    get { return Descriptor; }
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public Result() {
    OnConstruction();
  }

  partial void OnConstruction();

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public Result(Result other) : this() {
    title_ = other.title_;
    url_ = other.url_;
    snippet_ = other.snippet_;
    log_ = other.log_;
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public Result Clone() {
    return new Result(this);
  }

  /// <summary>Field number for the "title" field.</summary>
  public const int TitleFieldNumber = 1;
  private string title_ = "";
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public string Title {
    get { return title_; }
    set {
      title_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
    }
  }

  /// <summary>Field number for the "url" field.</summary>
  public const int UrlFieldNumber = 2;
  private string url_ = "";
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public string Url {
    get { return url_; }
    set {
      url_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
    }
  }

  /// <summary>Field number for the "snippet" field.</summary>
  public const int SnippetFieldNumber = 3;
  private string snippet_ = "";
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public string Snippet {
    get { return snippet_; }
    set {
      snippet_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
    }
  }

  /// <summary>Field number for the "log" field.</summary>
  public const int LogFieldNumber = 4;
  private string log_ = "";
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public string Log {
    get { return log_; }
    set {
      log_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
    }
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public override bool Equals(object other) {
    return Equals(other as Result);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public bool Equals(Result other) {
    if (ReferenceEquals(other, null)) {
      return false;
    }
    if (ReferenceEquals(other, this)) {
      return true;
    }
    if (Title != other.Title) return false;
    if (Url != other.Url) return false;
    if (Snippet != other.Snippet) return false;
    if (Log != other.Log) return false;
    return true;
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public override int GetHashCode() {
    int hash = 1;
    if (Title.Length != 0) hash ^= Title.GetHashCode();
    if (Url.Length != 0) hash ^= Url.GetHashCode();
    if (Snippet.Length != 0) hash ^= Snippet.GetHashCode();
    if (Log.Length != 0) hash ^= Log.GetHashCode();
    return hash;
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public override string ToString() {
    return pb::JsonFormatter.ToDiagnosticString(this);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public void WriteTo(pb::CodedOutputStream output) {
    if (Title.Length != 0) {
      output.WriteRawTag(10);
      output.WriteString(Title);
    }
    if (Url.Length != 0) {
      output.WriteRawTag(18);
      output.WriteString(Url);
    }
    if (Snippet.Length != 0) {
      output.WriteRawTag(26);
      output.WriteString(Snippet);
    }
    if (Log.Length != 0) {
      output.WriteRawTag(34);
      output.WriteString(Log);
    }
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public int CalculateSize() {
    int size = 0;
    if (Title.Length != 0) {
      size += 1 + pb::CodedOutputStream.ComputeStringSize(Title);
    }
    if (Url.Length != 0) {
      size += 1 + pb::CodedOutputStream.ComputeStringSize(Url);
    }
    if (Snippet.Length != 0) {
      size += 1 + pb::CodedOutputStream.ComputeStringSize(Snippet);
    }
    if (Log.Length != 0) {
      size += 1 + pb::CodedOutputStream.ComputeStringSize(Log);
    }
    return size;
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public void MergeFrom(Result other) {
    if (other == null) {
      return;
    }
    if (other.Title.Length != 0) {
      Title = other.Title;
    }
    if (other.Url.Length != 0) {
      Url = other.Url;
    }
    if (other.Snippet.Length != 0) {
      Snippet = other.Snippet;
    }
    if (other.Log.Length != 0) {
      Log = other.Log;
    }
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public void MergeFrom(pb::CodedInputStream input) {
    uint tag;
    while ((tag = input.ReadTag()) != 0) {
      switch(tag) {
        default:
          input.SkipLastField();
          break;
        case 10: {
          Title = input.ReadString();
          break;
        }
        case 18: {
          Url = input.ReadString();
          break;
        }
        case 26: {
          Snippet = input.ReadString();
          break;
        }
        case 34: {
          Log = input.ReadString();
          break;
        }
      }
    }
  }

}

#endregion


#endregion Designer generated code
