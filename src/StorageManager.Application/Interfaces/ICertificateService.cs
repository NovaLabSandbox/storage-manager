using System.Security.Cryptography.X509Certificates;

namespace StorageManager.Application.Interfaces
{
    public interface ICertificateService
    {
        X509Certificate2 CreateCertificateAuthority(string subjectName, int validityDays);
        X509Certificate2 CreateClientCertificate(X509Certificate2 caCertificate, string clientName, int validityDays);
        string ExportToPem(X509Certificate2 certificate);
        string ExportPrivateKeyToPem(X509Certificate2 certificate);
    }
}
