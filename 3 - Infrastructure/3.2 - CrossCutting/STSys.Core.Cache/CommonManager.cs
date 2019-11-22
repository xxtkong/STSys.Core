using System;
using System.Collections.Generic;
using System.Text;

namespace STSys.Core.Cache
{
    public class CommonManager
    {
        private static readonly object lockobj = new object();
        private static volatile ICacheHelper _cache = null;
        public static ICacheHelper CacheObj
        {
            get
            {
                if (_cache == null)
                {
                    lock (lockobj)
                    {
                        if (_cache == null)
                            _cache = new CacheContext();
                    }
                }
                return _cache;
            }
        }
    }
}
