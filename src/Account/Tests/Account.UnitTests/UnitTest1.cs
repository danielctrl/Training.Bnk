using Account.Domain.Common;

namespace Account.UnitTests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var x = new Asd();
            var y = x;
            var xx = x == y;
        }
    }

    public class Asd : ValueObject
    {
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return 1;
            yield return 2;
        }
    }
}