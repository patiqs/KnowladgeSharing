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
