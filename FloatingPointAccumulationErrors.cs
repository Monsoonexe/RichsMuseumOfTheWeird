public static void FloatingPointAccumulationErrors()
{
    // looping vs math operators changes outcome of result
    float oneMultiply = 0.1f * 10;

    // let's use a loop instead!
    float oneLoop = 0;
    for (int i = 0; i < 10; i++)
    {
        oneLoop += 0.1f;
    }

    // mathematically, this should not be the case.
    // but in compupter world, we have floating-point accumulation errors
    Assert.IsTrue(oneMultiply != oneLoop);
}
