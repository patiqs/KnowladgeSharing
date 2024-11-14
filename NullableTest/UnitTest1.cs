extern alias nullableDisable;
extern alias nullableEnable;
using System.Runtime.CompilerServices;
using MyClass = nullableDisable::MyClass;

namespace NullableTest;

public class Tests
{
  [TestCase("a")]
  [TestCase("")]
  [TestCase(null)]
  public void Test1(string s)
  {
    //arrange
    MyClass myClassD = new MyClass();
    nullableEnable::MyClass myClassE = new nullableEnable::MyClass();

    //act
    string resultDd = myClassD.FooNd(s);
    string resultEd = myClassE.FooNd(s);
    string resultDe = myClassD.FooNe(s);
    string resultEe = myClassE.FooNe(s);

    //assert
    Assert.That(resultDd, Is.EqualTo(s));
    Assert.That(resultEd, Is.EqualTo(s));
    Assert.That(resultDe, Is.EqualTo(s));
    Assert.That(resultEe, Is.EqualTo(s));
  }

  [Test]
  public void TestAttribute()
  {
    //arrange
    MyClass myClassD = new MyClass();
    nullableEnable::MyClass myClassE = new nullableEnable::MyClass();

    //act
   NullableContextAttribute? attributeDd = myClassD.GetType().GetMethod(
     nameof(MyClass.FooNd))?.GetCustomAttributes(typeof(NullableContextAttribute), false)?.SingleOrDefault() as NullableContextAttribute;
   NullableContextAttribute? attributeEd = myClassE.GetType().GetMethod(
     nameof(MyClass.FooNd))?.GetCustomAttributes(typeof(NullableContextAttribute), false)?.SingleOrDefault() as NullableContextAttribute;
   NullableContextAttribute? attributeDe = myClassD.GetType().GetMethod(
     nameof(MyClass.FooNe))?.GetCustomAttributes(typeof(NullableContextAttribute), false)?.SingleOrDefault() as NullableContextAttribute;
   NullableContextAttribute? attributeEe = myClassE.GetType().GetMethod(
     nameof(MyClass.FooNe))?.GetCustomAttributes(typeof(NullableContextAttribute), false)?.SingleOrDefault() as NullableContextAttribute;

    //assert
    Assert.Multiple(() =>
    {
      Assert.NotNull(attributeDd);
      Assert.That(attributeDd?.Flag, Is.EqualTo(2));
      Assert.NotNull(attributeEd);
      Assert.That(attributeEd?.Flag, Is.EqualTo(2));
      Assert.NotNull(attributeDe);
      Assert.That(attributeDe?.Flag, Is.EqualTo(2));
      Assert.NotNull(attributeEe);
      Assert.That(attributeEe?.Flag, Is.EqualTo(2));
    });
  }
}
