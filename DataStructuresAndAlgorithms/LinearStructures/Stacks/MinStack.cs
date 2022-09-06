namespace DataStructuresAndAlgorithms.Stacks
{
    public class MinStack
    {
        private System.Collections.Generic.Stack<int> _stack = new System.Collections.Generic.Stack<int>();
        private System.Collections.Generic.Stack<int> _minStack = new Stack<int>();

        public void Push(int item)
        {
            _stack.Push(item);

            if (IsEmpty(_minStack))
                _minStack.Push(item);
            else if (item < _minStack.Peek())
                _minStack.Push(item);
        }

        public int Pop()
        {
            if (IsEmpty(_stack))
                throw new InvalidOperationException(); // IllegalStateException();

            var top = _stack.Pop();

            if (_minStack.Peek() == top)
                _minStack.Pop();

            return top;
        }
        private bool IsEmpty(System.Collections.Generic.Stack<int> stack) => stack.Count == 0;
        public int Min()
        {
            return _minStack.Peek();
        }
        public override String ToString()
        {
            return DataUtils.Utils.Array2String(_stack);
        }
    }
}
