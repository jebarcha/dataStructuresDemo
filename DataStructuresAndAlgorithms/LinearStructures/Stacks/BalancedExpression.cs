namespace DataStructuresAndAlgorithms.Stacks
{
    public class BalancedExpression
    {
        private Stack<char> _stack = new Stack<char>();
        private readonly List<char> _leftBrackets = new List<char>() { '(', '<', '[', '{' };
        private readonly List<char> _rightBrackets = new List<char>() { ')', '>', ']', '}' };

        public bool IsBalanced(string input)
        {

            foreach (var ch in input)
            {
                if (IsLeftBracket(ch))
                    _stack.Push(ch);

                if (IsRightBracket(ch))
                {
                    if (IsEmpty()) return false;
                    
                    var top = _stack.Pop();
                    if (!BracketsMatch(top, ch)) return false;
                }
            }

            return IsEmpty();
        }

        private bool IsLeftBracket(char ch) => _leftBrackets.Contains(ch);
        private bool IsRightBracket(char ch) => _rightBrackets.Contains(ch);
        private bool BracketsMatch(char left, char right) =>
            _leftBrackets.IndexOf(left) == _rightBrackets.IndexOf(right);
        
        public bool IsEmpty() => _stack.Count == 0;

        //BEFORE:
        //public bool IsBalanced(string input)
        //{

        //    foreach (var ch in input)
        //    {
        //        if (ch == '(' || ch == '<' || ch == '[' || ch == '{')
        //            _stack.Push(ch);

        //        if (ch == ')' || ch == '>' || ch == ']' || ch == '}')
        //        {
        //            if (IsEmpty()) return false;
        //            var top = _stack.Pop();
        //            if (
        //                (ch == ')' && top != '(') ||
        //                (ch == '>' && top != '<') ||
        //                (ch == ']' && top != '[') ||
        //                (ch == '}' && top != '{')
        //               ) return false;
        //        }
        //    }

        //    return IsEmpty();
        //}

    }
}
