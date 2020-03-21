using System;
using UnityEngine;

namespace Circuits
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class ReadOnlyInPlayModeAttribute : PropertyAttribute { }
}
