﻿using Serenity.ComponentModel;
using Serenity.Extensibility;
using System.Reflection;

namespace Serenity.Web
{
    public class FormScriptRegistration
    {
        public static void RegisterFormScripts()
        {
            var assemblies = ExtensibilityHelper.SelfAssemblies;

            foreach (var assembly in assemblies)
                foreach (var type in assembly.GetTypes())
                {
                    var attr = type.GetCustomAttribute<FormScriptAttribute>();
                    if (attr != null)
                    {
                        string key = attr.Key;
                        if (key.IsNullOrEmpty())
                        {
                            key = type.Name;
                            const string p = "Form";
                            if (key.EndsWith(p))
                                key = key.Substring(0, key.Length - p.Length);
                        }

                        new FormScript(key, type);
                    }
                }
        }
    }
}
