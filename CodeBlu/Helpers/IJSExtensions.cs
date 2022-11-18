using Microsoft.JSInterop;
using System.Runtime.CompilerServices;

namespace CodeBlu.Helpers
{
    public static class IJSExtensions
    {
        public static Task GuardarComo(this IJSRuntime js, string nombreArchivo, byte[] archivo)
        {
            return js.InvokeAsync<object>("saveAsFile",
                nombreArchivo,
                Convert.ToBase64String(archivo)).AsTask();
        }
    }
}
