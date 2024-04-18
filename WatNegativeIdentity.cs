public bool HasNegativeIdentity(int num)
{
    return num == -num;
}

public void NegativeIdentityTests()
{
    Assert.IsTrue(HasNegativeIdentity(0)); // 0 == -0
    Assert.IsFalse(HasNegativeIdentity(1)); // 1 != -1  
    Assert.IsFalse(HasNegativeIdentity(-5)); // -5 != 5

    // wat?
    Assert.IsFalse(HasNegativeIdentity(Int32.MaxValue)); // 2147483647 != -2147483647
    Asssert.IsTrue(HasNegativeIdentity(Int32.MinValue)); // 2147483648 == -2147483648 (waaat??)

    // phenomena of 2's complement
}
