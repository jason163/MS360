using MS.Configuration.Startup;
using MS.Dependency;
using MS.Runtime.Caching;
using MS.Runtime.Caching.Configuration;
using MS.Runtime.Caching.Memory;
using Shouldly;
using System;
using System.Collections.Generic;
using Xunit;

namespace MS360.Tests.Runtime
{
    public  class MemoryCacheManager_Tests : TestBaseWithLocalIocManager
    {
        private readonly ICacheManager _cacheManager;
        private readonly ITypedCache<string, MyCacheItem> _cache;

        public MemoryCacheManager_Tests()
        {
            LocalIocManager.Register<IMSStartupConfiguration, MSStartupConfiguration>();
            LocalIocManager.Register<ICachingConfiguration, CachingConfiguration>();
            LocalIocManager.Register<ICacheManager, MSMemoryCacheManager>();
            LocalIocManager.Register<MyClientPropertyInjects>(DependencyLifeStyle.Transient);


            _cacheManager = LocalIocManager.Resolve<ICacheManager>();

            var defaultSlidingExpireTime = TimeSpan.FromHours(24);

            _cache = _cacheManager.GetCache<string, MyCacheItem>("MyCacheItems");
            //_cache.DefaultSlidingExpireTime.ShouldBe(defaultSlidingExpireTime);
        }


        [Fact]
        public void Simple_Get_Set_Test()
        {
            _cache.GetOrDefault("A").ShouldBe(null);

            _cache.Set("A", new MyCacheItem { Value = 42 });

            _cache.GetOrDefault("A").ShouldNotBe(null);
            _cache.GetOrDefault("A").Value.ShouldBe(42);

            _cache.Get("B", () => new MyCacheItem { Value = 43 }).Value.ShouldBe(43);
            _cache.Get("B", () => new MyCacheItem { Value = 44 }).Value.ShouldBe(43); //Does not call factory, so value is not changed

            var items1 = _cache.GetOrDefault(new string[] { "B", "C" });
            items1[0].Value.ShouldBe(43);
            items1[1].ShouldBeNull();

            var items2 = _cache.GetOrDefault(new string[] { "C", "D" });
            items2[0].ShouldBeNull();
            items2[1].ShouldBeNull();

            _cache.Set(new KeyValuePair<string, MyCacheItem>[] {
                new KeyValuePair<string, MyCacheItem>("C", new MyCacheItem{ Value = 44}),
                new KeyValuePair<string, MyCacheItem>("D", new MyCacheItem{ Value = 45})
            });

            var items3 = _cache.GetOrDefault(new string[] { "C", "D" });
            items3[0].Value.ShouldBe(44);
            items3[1].Value.ShouldBe(45);

            var items4 = _cache.Get(new string[] { "D", "E" }, (key) => new MyCacheItem { Value = key == "D" ? 46 : 47 });
            items4[0].Value.ShouldBe(45); //Does not call factory, so value is not changed
            items4[1].Value.ShouldBe(47);
        }

        [Serializable]
        public class MyCacheItem
        {
            public int Value { get; set; }

            public MyCacheItem()
            {

            }

            public MyCacheItem(int value)
            {
                Value = value;
            }
        }

        public class MyClientPropertyInjects
        {
            public ICacheManager CacheManager { get; set; }

            public int SetGetValue(int value)
            {
                return CacheManager
                    .GetCache("MyClientPropertyInjectsCache")
                    .Get("A", () =>
                    {
                        return value;
                    });
            }
        }
    }
}
