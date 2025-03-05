using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIF.Tests.Validators
{
    public class ValidatorTestBase
    {
        public static IEnumerable<object[]> CreateTestData(string propertyName, Type type)
        {
            return TestingHelpers.CreateObjectArrayOfObjects(propertyName, type);
        }
    }
}
