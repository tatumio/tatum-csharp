namespace Tatum.CSharp.Utils.DebugMode
{
    public class DebugModeOptions
    {
        /// <summary>
        /// DebugMode logs will have all the sensitive data obfuscated.
        /// </summary>
        public bool HideSecrets { get; set; } = true;
        
        /// <summary>
        /// If provided will serve as an additional target to save DebugMode logs.
        /// </summary>
        public string DumpFilePath { get; set; }
    }
}