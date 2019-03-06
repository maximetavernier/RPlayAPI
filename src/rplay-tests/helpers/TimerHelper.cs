using RPlay.Core.Extensions;
using System;
using System.Diagnostics;
using Xunit;

namespace RPlay.Tests.Helpers
{
    /// <summary>
    /// Wrapper of Assert class in order to provide timer tests
    /// </summary>
    /// <seealso cref="Assert"/>
    public sealed class TimerHelper
    {
        public static void IsStriclyQuicker<T, TK>(long ms, Func<T, TK> func, T args = default(T))
        {
            if (func == null) throw new ArgumentNullException(nameof(func));
            try
            {
                var watch = new Stopwatch();
                watch.Start();
                func.Invoke(args);
                watch.Stop();
                Assert.True(watch.ElapsedMilliseconds < ms);
            }
            catch (Exception ex)
            {
                ex.PrintStackTrace();
                AssertHelper.Fail();
            }
        }

        public static void IsStriclyQuicker<T>(long ms, Func<T, object> func, T args = default(T))
        {
            if (func == null) throw new ArgumentNullException(nameof(func));
            try
            {
                var watch = new Stopwatch();
                watch.Start();
                func.Invoke(args);
                watch.Stop();
                Assert.True(watch.ElapsedMilliseconds < ms);
            }
            catch (Exception ex)
            {
                ex.PrintStackTrace();
                AssertHelper.Fail();
            }
        }
    }
}