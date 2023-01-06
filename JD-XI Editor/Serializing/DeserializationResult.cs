using JD_XI_Editor.Models.Patches;

namespace JD_XI_Editor.Serializing
{
    internal class DeserializationResult<T> where T : IPatch
    {
        public DeserializationStatus Status { get; }

        public T Patch { get; }

        public DeserializationResult(DeserializationStatus status, T patch)
        {
            Status = status;
            Patch = patch;
        }
    }
}
