namespace Backend.Infra.Assemblies
{
    public class AssembliesManagement
    {
        private static AssembliesManagement _i;

        public static AssembliesManagement i 
        {
            get
            {
                if (_i == null)
                    _i = new AssembliesManagement();

                return _i;
            }
        }

        private AssembliesManagement()
        {

        }

        public Type GetType(string name)
        {
            // search in a current assembly
            Type type = Type.GetType(name);
            if (type != null && type != default)
                return type;

            // search in others assemblies
            foreach (var asm in AppDomain.CurrentDomain.GetAssemblies())
            {
                type = asm.GetType(name);
                if (type != null && type != default)
                    return type;
            }

            return null;
        }
    }
}
