using System;

namespace Naukri.InspectorMaid.Core
{
    public interface IDeclaredTypeProvider
    {
        /// <summary>
        /// <para>
        /// The type that annotated this attribute.
        /// </para>
        /// [NOTICE] This attribute is used to simplify the implementation structure.
        /// It is exposed because it needs to interact with code from other assemblies, breaking encapsulation.
        /// Do not use or modify it casually unless you understand its purpose.
        /// </summary>
        public Type DeclaredType { get; set; }
    }
}
