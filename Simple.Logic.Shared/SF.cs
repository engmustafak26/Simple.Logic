namespace Simple.Logic.Shared
{
    public static class SF
    {
        public static async Task<SequentialFlower<TTarget?>> Flow<TTarget>(this SequentialFlower<TTarget?> model, string name,
                                            Func<Task<SequentialFlower<TTarget?>>> code)
        {
            if (model.IsComplete)
                return model;

            return await code();

        }

        public static SequentialFlower<TTarget?> Flow<TTarget>(this SequentialFlower<TTarget?> model, string name,
                                             Func<SequentialFlower<TTarget>?> code)
        {
            if (model.IsComplete)
                return model;

            return code();

        }



        public static SequentialFlower<TTarget?> Flow<TTarget>(string name, Func<SequentialFlower<TTarget>?> code)
        {
            return code();

        }

    }

}
