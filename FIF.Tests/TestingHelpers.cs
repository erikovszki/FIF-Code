namespace FIF.Tests
{
    public static class TestingHelpers
    {
        public static IEnumerable<object[]> CreateObjectArrayOfObjects(string name, Type type)
        {
            return (type.GetProperty(name).GetValue(Activator.CreateInstance(type), null) as IEnumerable<object>)
                .Select(x =>
                {
                    return new object[] { x };
                });
        }
    }
}
