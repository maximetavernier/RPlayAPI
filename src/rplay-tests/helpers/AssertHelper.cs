using System;
using Xunit;

namespace RPlay.Tests.Helpers
{
    /// <summary>
    /// Wrapper of Assert class in order to provide more assertion test
    /// </summary>
    /// <seealso cref="Assert"/>
    public class AssertHelper
    {
        #region Assert
        /// <summary>
        /// End test by throwing an assert error
        /// </summary>
        public static void Fail() {
            Assert.True(false);
        }
        #endregion

        #region Strings
        /// <summary>
        /// Check if the string is null or empty
        /// </summary>
        /// <param name="str">String that must be null or empty</param>
        public static void IsStringNullOrEmpty(string str)
        {
            Assert.True(string.IsNullOrEmpty(str));
        }
        #endregion

        #region Func
        /// <summary>
        /// Check if function throw an exception or not
        /// </summary>
        /// <typeparam name="T">Return type of function</typeparam>
        /// <typeparam name="TK">Function params type</typeparam>
        /// <param name="func">Function that must throw an exception</param>
        /// <param name="args">Argument of function</param>
        public static void ThrowException<T, TK>(Func<T, TK> func, T args = default(T))
        {
            if (func == null) throw new ArgumentNullException(nameof(func));
            try
            {
                func.Invoke(args);
                AssertHelper.Fail();
            }
            catch
            {
                ;
            }
        }

        /// <summary>
        /// Check if function throw an exception or not, and also check the type of exception
        /// </summary>
        /// <typeparam name="T">Return value of function</typeparam>
        /// <param name="func">Function that must throw an exception</param>
        /// <param name="exceptionType">Exception type</param>
        public static void ThrowExceptionOfType<T>(Func<object> func, Type exceptionType)
        {
            if (func == null)
                AssertHelper.Fail();
            Assert.Throws(exceptionType, func);
        }
        #endregion
    }
}