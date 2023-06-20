namespace EleventhApplication.IServices
{
    public interface IMyService
    {
        public Task<Dictionary<string, object>> Method(string symbol);
    }
}
