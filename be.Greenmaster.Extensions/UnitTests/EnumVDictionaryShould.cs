﻿using be.Greenmaster.Extensions.SubTypes;
using Xunit;

namespace be.Greenmaster.Extensions.UnitTests;

public class EnumDirectoryShould
{
    private readonly string _testValue;

    public EnumDirectoryShould()
    {
        _testValue = "test if it works";
    }

    [Fact]
    public void InitiateTEnumKeyValuePairsOnCreation()
    {
        var createdDir = new EnumVDictionary<TestEnum, string>();
        if (createdDir == null) throw new ArgumentNullException(nameof(createdDir));
        Assert.True(createdDir.ContainsKey(TestEnum.Test1.ToString()));
        Assert.True(createdDir.ContainsKey(TestEnum.Tester.ToString()));
        Assert.True(createdDir.ContainsKey(TestEnum.Testing.ToString()));
    }

    [Fact]
    public void AddWhenKeyIsTypeEnumAndAlreadyExists()
    {
        var createdDir = new EnumVDictionary<TestEnum, string> { { TestEnum.Tester, _testValue } };
        Assert.Null(createdDir[TestEnum.Test1.ToString()]);
        Assert.Equal(_testValue, createdDir[TestEnum.Tester.ToString()]);
        Assert.Null(createdDir[TestEnum.Testing.ToString()]);
    }

    private enum TestEnum
    {
        Test1,Tester,Testing
    }
}