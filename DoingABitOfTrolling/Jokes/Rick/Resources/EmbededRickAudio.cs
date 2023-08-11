using DoingABitOfTrolling.Lib.Abstacts;

namespace DoingABitOfTrolling.Jokes.Rick.Resources
{
    public class EmbededRickAudio : EmbededResource<UnmanagedMemoryStream>
    {
        public EmbededRickAudio()
        {
            resource = new Lazy<UnmanagedMemoryStream>(EmbeddedRickAudioResource.rickroll_but_it_never_starts);
        }

        protected override Lazy<UnmanagedMemoryStream> resource { get; init; }
    }
}
