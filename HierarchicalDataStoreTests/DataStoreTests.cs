
using NUnit.Framework;
using Repository.Store;

namespace HierarchicalDataStoreTests
{
    [TestFixture]
    public class DataStoreTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void DataStore_Instance_is_created_should_return_not_null()
        {
            DataStore ds = DataStore.GetInstance();
            Assert.IsNotNull(ds);
        }
    }
}
