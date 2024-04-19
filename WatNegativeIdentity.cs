public bool HasNegativeIdentity(int num)
{
    return num == -num;
}

public void NegativeIdentityTests()
{
    // negative identity is when a negated integer is equal to its non-negated value.
    // in reality, 0 is the only integer with negative identity.
    // however, in the world of computers....

    // some true examples
    Assert.IsTrue(HasNegativeIdentity(0)); // 0 == -0
    Assert.IsFalse(HasNegativeIdentity(1)); // 1 != -1  
    Assert.IsFalse(HasNegativeIdentity(-5)); // -5 != 5

    Assert.IsFalse(HasNegativeIdentity(Int32.MaxValue)); // 2147483647 != -2147483647
    
    // wat?
    Asssert.IsTrue(HasNegativeIdentity(Int32.MinValue)); // -2147483648 == -(-2147483648) (waaat??)

    // waaaat?
    int val = Int32.MinValue;
    Assert.IsTrue(val != 0 && HasNegativeIdentity(val)); // incorrect in reality
    // phenomena of 2's complement
}
