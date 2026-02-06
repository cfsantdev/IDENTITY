using System.Linq;
using System.Reflection;

namespace Inventory.Utils
{
    public static class Mapper
    {
        public static T ToAssign<S, T>(S source, T target)
        {
            foreach (PropertyInfo prop in typeof(T).GetProperties())
            {
                ToAssign<S, T>(prop, source, target);
            }

            return target;
        }

        public static T Update<T>(T source, T target)
        {
            foreach (PropertyInfo prop in typeof(T).GetProperties())
            {
                Update<T>(prop, source, target);
            }

            return target;
        }

        private static void ToAssign<S, T>(PropertyInfo prop, S source, T target)
        {
            if (prop.GetMethod == null || prop.GetMethod == default)
            {
                return;
            }

            if (prop.SetMethod == null || prop.SetMethod == default)
            {
                return;
            }

            typeof(S).GetProperties().Any(p =>
            {
                if (p.Name != prop.Name || p.PropertyType != prop.PropertyType)
                {
                    return false;
                }

                prop.SetValue(target, p.GetValue(source));

                return true;
            });
        }

        private static void Update<T>(PropertyInfo prop, T source, T target)
        {
            if (prop.GetMethod == null || prop.GetMethod == default)
            {
                return;
            }

            if (prop.SetMethod == null || prop.SetMethod == default)
            {
                return;
            }

            prop.SetValue(target, prop.GetValue(source));
        }
    }
}
