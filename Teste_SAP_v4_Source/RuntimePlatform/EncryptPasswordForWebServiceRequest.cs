using System;
using OutSystems.RuntimeCommon;
using OutSystems.RuntimeCommon.Cryptography.VersionedAlgorithms;

namespace OutSystems.HubEdition.RuntimePlatform {
    
    internal sealed class EncryptPasswordForWebServiceRequest {
        private const string ENCRYPTED_SYMMETRIC_PREFIX = "#";

        public static string Encrypt(string password, Version targetServerVersion) {
    
            return ENCRYPTED_SYMMETRIC_PREFIX 
                + SecureConfidentialInformationEncryption.EncryptWithAlgorithm(password, SecureConfidentialInformationEncryption.FixedKeyAES128.Instance);

        }
    }
}
