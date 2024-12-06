using ProtoBuf;

List<int> list = new();

list = null;

list = FooNe(list);
list = FooNd(list);

list = FooNe(null);
list = FooNd(null);

List<int>? nullableList = new();
nullableList = FooNe(nullableList);
nullableList = FooNd(nullableList);

List<int> FooNe(List<int> l) => l;
List<int>? FooNd(List<int>? l) => l;

public class MyClass
{
  public string FooNe(string s) => s;
  public string? FooNd(string? s) => s;
}

public record Nested(int A);

[ProtoContract]
public record MyContract
{
  [ProtoMember(1)]
  public int? nIntNull { get; set; }
  [ProtoMember(2)]
  public int? nIntDefault { get; set; }
  [ProtoMember(3)]
  public int? nIntValued { get; set; }

  [ProtoMember(4)]
  public KeyValuePair<string?, int?>? nKvpNull { get; set; }
  [ProtoMember(5)]
  public KeyValuePair<string?, int?>? nKvpDefault { get; set; }
  [ProtoMember(6)]
  public KeyValuePair<string?, int?>? nKvpValued1 { get; set; }
  [ProtoMember(7)]
  public KeyValuePair<string?, int?>? nKvpValued2 { get; set; }

  [ProtoMember(8)]
  public KeyValuePair<string?, int?> kvpDefault { get; set; }
  [ProtoMember(9)]
  public KeyValuePair<string?, int?> kvpValued1 { get; set; }
  [ProtoMember(10)]
  public KeyValuePair<string?, int?> kvpValued2 { get; set; }

  [ProtoMember(11)]
  public int?[]? nArrayOfNullablesNull { get; set; }
  [ProtoMember(12)]
  public int?[]? nArrayOfNullablesDefault { get; set; }
  [ProtoMember(13)]
  public int?[]? nArrayOfNullablesValued { get; set; }
  [ProtoMember(14)]
  public int?[] ArrayOfNullables { get; set; }
  
  [ProtoMember(15)]
  public List<int?>? nListOfNullablesNull { get; set; }
  [ProtoMember(16)]
  public List<int?>? nListOfNullablesDefault { get; set; }
  [ProtoMember(17)]
  public List<int?>? nListOfNullablesValued { get; set; }
  [ProtoMember(18)]
  public List<int?> ListOfNullables { get; set; }

  [ProtoMember(19)]
  public Nested? nNestedNull { get; set; }
  [ProtoMember(20)]
  public Nested? nNestedDefault { get; set; }
  [ProtoMember(21)]
  public Nested? nNestedValued { get; set; }
  [ProtoMember(22)]
  public Nested NestedNull { get; set; }
  [ProtoMember(23)]
  public Nested NestedDefault { get; set; }
  [ProtoMember(24)]
  public Nested NestedValued { get; set; }

  public static MyContract Create() => new MyContract
  {
    nIntNull = null,
    nIntDefault = default,
    nIntValued = 123,

    nKvpNull = null,
    nKvpDefault = default,

    nKvpValued1 = new KeyValuePair<string?, int?>(),
    nKvpValued2 = new KeyValuePair<string?, int?>("foo", 1234),

    kvpDefault = default,
    kvpValued1 = new KeyValuePair<string?, int?>(),
    kvpValued2 = new KeyValuePair<string?, int?>("foo", 1234),

    nArrayOfNullablesNull = null,
    nArrayOfNullablesDefault = default,
    nArrayOfNullablesValued = [1, null, 2, default, 3],
    ArrayOfNullables = [1, null, 2, default, 3],

    nListOfNullablesNull = null,
    nListOfNullablesDefault = default,
    nListOfNullablesValued = new List<int?> { 1, null, 2, default, 3 },
    ListOfNullables = new List<int?> { 1, null, 2, default, 3 },

    nNestedNull = null,
    nNestedDefault = default,
    nNestedValued = new Nested(123),

    NestedNull = null,
    NestedDefault = default,
    NestedValued = new Nested(123),
  };
}
