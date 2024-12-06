extern alias nullableDisable;
extern alias nullableEnable;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace NullableTest;

public class Tests
{
  [TestCase("a")]
  [TestCase("")]
#if CHECK_NU1001
  [TestCase(null)]
#endif
  public void Test1(string s)
  {
    //arrange
    nullableDisable::MyClass myClassD = new nullableDisable::MyClass();
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
    nullableDisable::MyClass myClassD = new nullableDisable::MyClass();
    nullableEnable::MyClass myClassE = new nullableEnable::MyClass();

    //act
    NullableContextAttribute? classD_FooNd = myClassD.GetType().GetMethod(
      "FooNd")?.GetCustomAttributes(typeof(NullableContextAttribute), false)?.SingleOrDefault() as NullableContextAttribute;
    NullableContextAttribute? classE_FooNd = myClassE.GetType().GetMethod(
      "FooNd")?.GetCustomAttributes(typeof(NullableContextAttribute), false)?.SingleOrDefault() as NullableContextAttribute;
    NullableContextAttribute? classD_FooNe = myClassD.GetType().GetMethod(
      "FooNe")?.GetCustomAttributes(typeof(NullableContextAttribute), false)?.SingleOrDefault() as NullableContextAttribute;
    NullableContextAttribute? classE_FooNe = myClassE.GetType().GetMethod(
      "FooNe")?.GetCustomAttributes(typeof(NullableContextAttribute), false)?.SingleOrDefault() as NullableContextAttribute;

    //assert
    Assert.Multiple(() =>
    {
      Assert.NotNull(classD_FooNd);
      Assert.NotNull(classE_FooNd);
      Assert.NotNull(classD_FooNe);
      Assert.NotNull(classE_FooNe);

      Assert.That(classD_FooNd?.Flag, Is.EqualTo(2));
      Assert.That(classE_FooNd?.Flag, Is.EqualTo(2));
      Assert.That(classE_FooNe?.Flag, Is.EqualTo(1));

      Assert.That(classE_FooNe?.Flag, Is.EqualTo(classD_FooNe?.Flag));
      Assert.That(classE_FooNd?.Flag, Is.EqualTo(classD_FooNd?.Flag));
    });
  }

  [Test]
  public void SystemTextJson([Values(JsonIgnoreCondition.Never, JsonIgnoreCondition.WhenWritingDefault, JsonIgnoreCondition.WhenWritingNull)] JsonIgnoreCondition defaultIgnoreCondition)
  {
    //arrange
    nullableDisable::MyContract dis = nullableDisable::MyContract.Create();
    nullableEnable::MyContract en = nullableEnable::MyContract.Create();
    JsonSerializerOptions options = new JsonSerializerOptions();
    options.DefaultIgnoreCondition = defaultIgnoreCondition;

    //act
    var disTxt = System.Text.Json.JsonSerializer.Serialize(dis, options);
    var enTxt = System.Text.Json.JsonSerializer.Serialize(en, options);

    var enFromDis = System.Text.Json.JsonSerializer.Deserialize<nullableEnable::MyContract>(disTxt);
    var disFromEn = System.Text.Json.JsonSerializer.Deserialize<nullableDisable::MyContract>(enTxt);

    TestContext.Out.WriteLine(disTxt);
    TestContext.Out.WriteLine(disFromEn);

    Assert.Multiple(() =>
    {
      //assert
      Assert.That(disTxt, Is.EqualTo(enTxt));
      Assert.That(enFromDis.ToString(), Is.EqualTo(disFromEn.ToString()));
      Assert.That(enFromDis.ToString(), Is.EqualTo(en.ToString()));
      Assert.That(disFromEn.ToString(), Is.EqualTo(en.ToString()));

      Assert.That(enFromDis.ArrayOfNullables, Is.EqualTo(disFromEn.ArrayOfNullables));
      Assert.That(enFromDis.nArrayOfNullablesDefault, Is.EqualTo(disFromEn.nArrayOfNullablesDefault));
      Assert.That(enFromDis.nArrayOfNullablesNull, Is.EqualTo(disFromEn.nArrayOfNullablesNull));
      Assert.That(enFromDis.nArrayOfNullablesValued, Is.EqualTo(disFromEn.nArrayOfNullablesValued));

      Assert.That(enFromDis.ListOfNullables, Is.EqualTo(disFromEn.ListOfNullables));
      Assert.That(enFromDis.nListOfNullablesDefault, Is.EqualTo(disFromEn.nListOfNullablesDefault));
      Assert.That(enFromDis.nListOfNullablesNull, Is.EqualTo(disFromEn.nListOfNullablesNull));
      Assert.That(enFromDis.nListOfNullablesValued, Is.EqualTo(disFromEn.nListOfNullablesValued));
    });
  }

  [Test]
  public void NewtonSoftJson([Values] NullValueHandling nullValueHandling)
  {
    //arrange
    nullableDisable::MyContract dis = nullableDisable::MyContract.Create();
    nullableEnable::MyContract en = nullableEnable::MyContract.Create();
    JsonSerializerSettings settings = new JsonSerializerSettings();
    settings.NullValueHandling = nullValueHandling;

    //act
    var disTxt = Newtonsoft.Json.JsonConvert.SerializeObject(dis, settings);
    var enTxt = Newtonsoft.Json.JsonConvert.SerializeObject(en, settings);

    var enFromDis = Newtonsoft.Json.JsonConvert.DeserializeObject<nullableEnable::MyContract>(disTxt);
    var disFromEn = Newtonsoft.Json.JsonConvert.DeserializeObject<nullableDisable::MyContract>(enTxt);

    TestContext.Out.WriteLine(disTxt);
    TestContext.Out.WriteLine(disFromEn);

    Assert.Multiple(() =>
    {
      //assert
      Assert.That(disTxt, Is.EqualTo(enTxt));
      Assert.That(enFromDis.ToString(), Is.EqualTo(disFromEn.ToString()));
      Assert.That(enFromDis.ToString(), Is.EqualTo(en.ToString()));
      Assert.That(disFromEn.ToString(), Is.EqualTo(en.ToString()));

      Assert.That(enFromDis.ArrayOfNullables, Is.EqualTo(disFromEn.ArrayOfNullables));
      Assert.That(enFromDis.nArrayOfNullablesDefault, Is.EqualTo(disFromEn.nArrayOfNullablesDefault));
      Assert.That(enFromDis.nArrayOfNullablesNull, Is.EqualTo(disFromEn.nArrayOfNullablesNull));
      Assert.That(enFromDis.nArrayOfNullablesValued, Is.EqualTo(disFromEn.nArrayOfNullablesValued));

      Assert.That(enFromDis.ListOfNullables, Is.EqualTo(disFromEn.ListOfNullables));
      Assert.That(enFromDis.nListOfNullablesDefault, Is.EqualTo(disFromEn.nListOfNullablesDefault));
      Assert.That(enFromDis.nListOfNullablesNull, Is.EqualTo(disFromEn.nListOfNullablesNull));
      Assert.That(enFromDis.nListOfNullablesValued, Is.EqualTo(disFromEn.nListOfNullablesValued));
    });
  }

  [Test]
  public void ProtoBufTest([Values] NullValueHandling nullValueHandling)
  {
    //arrange
    nullableDisable::MyContract dis = nullableDisable::MyContract.Create();
    dis.nArrayOfNullablesValued = [1, 2, 3]; //Protobuf doesn't support nulls in an array
    dis.ArrayOfNullables = [1, 2, 3]; //Protobuf doesn't support nulls in an array
    dis.nListOfNullablesValued = [1, 2, 3]; //Protobuf doesn't support nulls in an array
    dis.ListOfNullables = [1, 2, 3]; //Protobuf doesn't support nulls in an array
    nullableEnable::MyContract en = nullableEnable::MyContract.Create();
    en.nArrayOfNullablesValued = [1, 2, 3]; //Protobuf doesn't support nulls in an array
    en.ArrayOfNullables = [1, 2, 3]; //Protobuf doesn't support nulls in an array
    en.nListOfNullablesValued = [1, 2, 3]; //Protobuf doesn't support nulls in an array
    en.ListOfNullables = [1, 2, 3]; //Protobuf doesn't support nulls in an array
    JsonSerializerSettings settings = new JsonSerializerSettings();
    settings.NullValueHandling = nullValueHandling;

    byte[] disBuffer = new byte[1000];
    byte[] enBuffer = new byte[1000];
    using var msDis = new MemoryStream(disBuffer);
    using var msEn = new MemoryStream(enBuffer);

    //act
    ProtoBuf.Serializer.Serialize(msDis, dis);
    ProtoBuf.Serializer.Serialize(msEn, en);

    using var msDis2 = new MemoryStream(disBuffer, 0, (int)msDis.Position);
    using var msEn2 = new MemoryStream(enBuffer, 0, (int)msEn.Position);

    var enFromDis = ProtoBuf.Serializer.Deserialize<nullableEnable::MyContract>(msDis2);
    var disFromEn = ProtoBuf.Serializer.Deserialize<nullableDisable::MyContract>(msEn2);

    TestContext.Out.WriteLine(disFromEn);

    Assert.Multiple(() =>
    {
      //assert
      Assert.That(msEn, Is.EqualTo(msDis));
      Assert.That(enFromDis.ToString(), Is.EqualTo(en.ToString()));
      Assert.That(disFromEn.ToString(), Is.EqualTo(en.ToString()));

      Assert.That(enFromDis.ArrayOfNullables, Is.EqualTo(disFromEn.ArrayOfNullables));
      Assert.That(enFromDis.nArrayOfNullablesDefault, Is.EqualTo(disFromEn.nArrayOfNullablesDefault));
      Assert.That(enFromDis.nArrayOfNullablesNull, Is.EqualTo(disFromEn.nArrayOfNullablesNull));
      Assert.That(enFromDis.nArrayOfNullablesValued, Is.EqualTo(disFromEn.nArrayOfNullablesValued));

      Assert.That(enFromDis.ListOfNullables, Is.EqualTo(disFromEn.ListOfNullables));
      Assert.That(enFromDis.nListOfNullablesDefault, Is.EqualTo(disFromEn.nListOfNullablesDefault));
      Assert.That(enFromDis.nListOfNullablesNull, Is.EqualTo(disFromEn.nListOfNullablesNull));
      Assert.That(enFromDis.nListOfNullablesValued, Is.EqualTo(disFromEn.nListOfNullablesValued));
    });
  }

}
