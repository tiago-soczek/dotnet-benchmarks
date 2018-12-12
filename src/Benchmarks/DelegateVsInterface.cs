using BenchmarkDotNet.Attributes;
using System;

namespace Benchmark
{
    [ClrJob, CoreJob]
    public class DelegateVsInterface
    {
        private Func<object, object> onBegin = _ => { return null; };
        private Action<object> onEnd = _ => { };
        private IWrapper wrapper = new DummyWrapper();
        private object cmd = new object();

        [Benchmark]
        public object Delegate()
        {
            var ctx = onBegin(cmd);

            onEnd(ctx);

            return ctx;
        }

        [Benchmark]
        public object Interface()
        {
            var ctx = wrapper.OnBegin(cmd);

            wrapper.OnEnd(ctx);

            return ctx;
        }

        private interface IWrapper
        {
            object OnBegin(object cmd);
            void OnEnd(object context);
        }

        public class DummyWrapper : IWrapper
        {
            public object OnBegin(object cmd) => null;

            public void OnEnd(object context)
            {
            }
        }
    }
}
