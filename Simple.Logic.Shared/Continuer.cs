namespace Simple.Logic.Shared
{
    public static class C
    {

        public static Func<Task<T?>> _<T>(Func<Task<T?>> source)
        {
            return source;
        }
        public static Func<T?> _<T>(Func<T?> source)
        {
            return source;
        }


    }
}
