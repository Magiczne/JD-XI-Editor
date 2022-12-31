using JD_XI_Editor.Models.Patches;

namespace JD_XI_Editor.Serializing
{
    internal class DeserializationResult<T> where T : IPatch
    {
        public bool Success { get; }

        public T Patch { get; }

        public DeserializationResult(bool success, T patch)
        {
            Success = success;
            Patch = patch;
        }
    }
}
