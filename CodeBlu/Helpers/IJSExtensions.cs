using Microsoft.JSInterop;
using System.Runtime.CompilerServices;

namespace CodeBlu.Helpers
{
    public static class IJSExtensions
    {
        //este metodo invoca otro metodo de javaScript y devuelve una Task, sirve para exportar en CSV
        public static Task GuardarComo(this IJSRuntime js, string nombreArchivo, byte[] archivo)
        {
            return js.InvokeAsync<object>("saveAsFile",
                nombreArchivo,
                Convert.ToBase64String(archivo)).AsTask();
        }
    }
}
