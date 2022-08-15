using ImpromptuInterface;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProxy.DynamicLog
{
    public class Log<T> : DynamicObject where T : class,new()
    {
        private readonly T _subject;
        private Dictionary<string, int> MethodeCallCount = new Dictionary<string, int>();

        public Log(T subject)
        {
            _subject = subject;
        }

        public static I As<I>() where I : class {
            if (!typeof(I).IsInterface)
                throw new ArgumentException("I must be an interface type");
            return new Log<T>(new T()).ActLike<I>();
        }

        public override string ToString()
        {
            return $"{Info}{_subject}";
        }

        public override bool TryInvokeMember(InvokeMemberBinder binder, object?[]? args, out object? result)
        {
            try
            {
                Console.WriteLine($"Invoking {_subject.GetType().Name}.{binder.Name} with arguments {string.Join(",", args)}");
                if (MethodeCallCount.ContainsKey(binder.Name))
                    MethodeCallCount[binder.Name]++;
                else
                    MethodeCallCount.Add(binder.Name,1);
                result = _subject.GetType().GetMethod(binder.Name).Invoke(_subject,args);
                return true;
            }
            catch 
            {
                result = null;
                return false;
            }
           
        }

        public string Info
        {
            get
            {
                var sb = new StringBuilder();
                foreach (var kv in MethodeCallCount)
                {
                    sb.AppendLine($"{kv.Key} called {kv.Value} time(s)");

                }

                return sb.ToString();
            }
        }

    }
}
