namespace Simple.Logic.Shared
{
    public class SequentialFlower<T>
    {
        public T? Value { get; set; }
        public object? MethodOutput { get; set; }
        public bool IsComplete { get; private set; }

        public SequentialFlower<T> Return()
        {
            IsComplete = true;
            return this;
        }


        public SequentialFlower<T> Success(T value)
        {

            this.Value = value;
            return this;
        }
        public SequentialFlower<T> Success(T value, object methodOutput)
        {
            this.Value = value;
            this.MethodOutput = methodOutput;
            return this;
        }


    }


}
