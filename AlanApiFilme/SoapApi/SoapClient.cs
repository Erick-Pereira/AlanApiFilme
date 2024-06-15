using System.Text;
using System.Xml;

public class SoapClient
{
    private static readonly HttpClient client = new HttpClient();

    public async Task<string> GetNumberInWords(int number)
    {
        var soapEnvelope = $@"
            <soapenv:Envelope xmlns:soapenv='http://schemas.xmlsoap.org/soap/envelope/' xmlns:web='http://www.dataaccess.com/webservicesserver/'>
                <soapenv:Header/>
                <soapenv:Body>
                    <web:NumberToWords>
                        <web:ubiNum>{number}</web:ubiNum>
                    </web:NumberToWords>
                </soapenv:Body>
            </soapenv:Envelope>";

        var url = "https://www.dataaccess.com/webservicesserver/numberconversion.wso";
        var action = "NumberToWords";

        using (var request = new HttpRequestMessage(HttpMethod.Post, url))
        {
            request.Headers.Add("SOAPAction", action);
            request.Content = new StringContent(soapEnvelope, Encoding.UTF8, "text/xml");

            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();

            // Extrair o valor por extenso da resposta XML
            var extractedValue = ExtractValueFromSoapResponse(responseContent);
            return extractedValue;
        }
    }

    private string ExtractValueFromSoapResponse(string soapResponse)
    {
        // Implementar a lógica de extração do valor do SOAP response XML
        XmlDocument doc = new XmlDocument();
        doc.LoadXml(soapResponse);

        XmlNamespaceManager ns = new XmlNamespaceManager(doc.NameTable);
        ns.AddNamespace("soapenv", "http://schemas.xmlsoap.org/soap/envelope/");
        ns.AddNamespace("web", "http://www.dataaccess.com/webservicesserver/");

        XmlNode node = doc.SelectSingleNode("//web:NumberToWordsResult", ns);
        return node?.InnerText ?? "Erro ao extrair o valor";
    }
}