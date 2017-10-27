using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DynamicVariableNames
{
    class Program : games
    {
        static void Main(string[] args)
        {
            dynamic gameLibrary = new games();
            Console.Write(gameLibrary.game1);
            
            Console.ReadKey();
        }
    }

    class games : DynamicObject
    {
        internal static dynamic game = new ExpandoObject();
        internal static IDictionary<string, object> dictionary = (IDictionary<string, object>)game;

        public games()
        {
            Instance();
        }

        // If you try to get a value of a property 
        // not defined in the class, this method is called.
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            // Converting the property name to lowercase
            // so that property names become case-insensitive.
            string name = binder.Name.ToLower();

            // If the property name is found in a dictionary,
            // set the result parameter to the property value and return true.
            // Otherwise, return false.
            return dictionary.TryGetValue(name, out result);
        }

        // If you try to set a value of a property that is
        // not defined in the class, this method is called.
        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            // Converting the property name to lowercase
            // so that property names become case-insensitive.
            dictionary[binder.Name.ToLower()] = value;

            // You can always add a value to a dictionary,
            // so this method always returns true.
            return true;
        }

        // Implement the TryInvokeMember method of the DynamicObject class for 
        // dynamic member calls that have arguments.
        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {
            Type dictType = typeof(Dictionary<string, object>);
            try
            {
                result = dictType.InvokeMember(
                             binder.Name,
                             BindingFlags.InvokeMethod,
                             null, dictionary, args);
                return true;
            }
            catch
            {
                result = null;
                return false;
            }
        }

        public void Instance()
        {
            for (int i = 0; i <= 3; i++)
            {
                dictionary.Add($"game{i}", "silly billy");
            }
        }
    }
}
