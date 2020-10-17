using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

namespace KIS.Core.Services
{
    public static class ScriptLoader
    {
        private const string DefaultPath = "Resources";

        public static string GetEmbeddedResource<T>([CallerMemberName] string resourceName = null) => ScriptLoader.GetEmbeddedResourceByPath<T>("Resources", resourceName);

        public static string GetEmbeddedResourceByPath<T>(string path, [CallerMemberName] string resourceName = null)
        {
            Assembly assembly = typeof(T).Assembly;
            using (Stream manifestResourceStream = assembly.GetManifestResourceStream(assembly.GetName().Name + "." + path + "." + resourceName + ".sql"))
            {
                if (manifestResourceStream == null)
                    throw new ArgumentException("Resource not found", resourceName);
                using (StreamReader streamReader = new StreamReader(manifestResourceStream))
                    return streamReader.ReadToEnd();
            }
        }

        public static Lazy<string> GetLazyEmbeddedResource<T>([CallerMemberName] string resourceName = null) => new Lazy<string>((Func<string>)(() => ScriptLoader.GetEmbeddedResource<T>(resourceName)), true);

        public static Lazy<string> GetLazyEmbeddedResourceByPath<T>(
          string path,
          [CallerMemberName] string resourceName = null) => new Lazy<string>((Func<string>)(() => ScriptLoader.GetEmbeddedResourceByPath<T>(path, resourceName)), true);
    }
}
