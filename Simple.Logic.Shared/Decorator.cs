using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple.Logic.Shared
{
    public static class Decorator
    {
        public static Func<Task<T?>> Decorate<T>(this Func<Task<T?>> source, Func<Task>? pre = null, Func<Task>? post = null)
        {
            return C._(async () =>
             {
                 if (pre != null)
                     await pre();
                 var result = await source();
                 if (post != null)
                     await post();
                 return result;
             });

        }

        public static Func<T?> Decorate<T>(this Func<T?> source, Action? pre = null, Action? post = null)
        {
            return C._(() =>
            {
                if (pre != null)
                    pre();
                var result = source();
                if (post != null)
                    post();
                return result;
            });

        }


        public static Func<T?> DecorateWithTryCatch<T>(this Func<T?> source, Action<Exception>? catchLogic = null)
        {
            return C._(() =>
            {
                try
                {

                    var result = source();

                    return result;

                }
                catch (Exception ex)
                {
                    if (catchLogic != null)
                        catchLogic(ex);

                    return default;
                }

            });
        }

        public static Func<Task<T?>> Group<T>(Func<Task<T?>> body, Func<Task>? pre = null, Func<Task>? post = null)
        {
            return C._(async () =>
            {
                if (pre != null)
                    await pre();
                var result = await body();
                if (post != null)
                    await post();
                return result;
            });

        }

        public static Func<T?> Group<T>(Func<T?> body, Action? pre = null, Action? post = null)
        {
            return C._(() =>
            {
                if (pre != null)
                    pre();
                var result = body();
                if (post != null)
                    post();
                return result;
            });

        }

    }


}
