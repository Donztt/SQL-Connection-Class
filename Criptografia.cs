using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using clsCrypt;

namespace UTILITARIOS
{
    public class Criptografia
    {
        public Criptografia()
        {
            AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(CurrentDomain_AssemblyResolve);
        }

        public static string Criptografar(string texto)
        {
            return new ClsCryptografia().CriptSenha(texto);
        }

        public static string Descriptografar(string texto)
        {
            return new ClsCryptografia().DeCriptSenha(texto);
        }

        private void CarregarDll()
        {
            var assembly = Assembly.LoadFile("CTE.ClsCrypt.dll");
            var type = assembly.GetType("CTE.ClsCrypt.dll");
        }

        public static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("CTE.ClsCrypt.dll"))
            {
                byte[] assemblyData = new byte[stream.Length];
                stream.Read(assemblyData, 0, assemblyData.Length);
                return Assembly.Load(assemblyData);
            }
        }
    }
}
